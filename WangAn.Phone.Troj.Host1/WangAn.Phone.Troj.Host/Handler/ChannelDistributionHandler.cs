using System;
using System.Collections.Generic;
using InOut;
using InOut.PacketImp;

namespace IIE.Phone.Troj.Host.Handler
{
    public class ChannelDistributionHandler
    {
        
        public Dictionary<int, IPacket> PacketMap { get; private set; }
        
        public Dictionary<int, TemporaryStorage> TempDataMap { get; private set; }

        public Dictionary<int, IPacketHandler> PacketHandlerMap { get; private set; }

        public ChannelDistributionHandler()
        {
            PacketMap = new Dictionary<int, IPacket>();
            TempDataMap = new Dictionary<int, TemporaryStorage>();
            PacketHandlerMap = new Dictionary<int, IPacketHandler>();
            
            RegisterListener(0, new CommandPacket());
            TempDataMap[0] = new TemporaryStorage();
            PacketHandlerMap[0] = new CommandHandler();

        }



        public bool RegisterListener(int chan, IPacket packet)
        {
            if (!(PacketMap.ContainsKey(chan)))
            {
                PacketMap[chan] = packet;
                TempDataMap[chan] =  new TemporaryStorage();
                return true;
            }
            return false;
        }

        public bool RegisterHandler(int chan, IPacketHandler han)
        {
            if (!(PacketHandlerMap.ContainsKey(chan)))
            {
                PacketHandlerMap.Add(chan, han);
                return true;
            }
            return false;
        }

        public bool RemoveListener(int chan)
        {
            try
            {
                if ((PacketMap.ContainsKey(chan)))
                {
                    PacketMap.Remove(chan);
                    TempDataMap.Remove(chan);
                    PacketHandlerMap.Remove(chan);
                    return true;
                }
            }
            catch (Exception)
            {
                return false;
            }
            return false;

        }

        public int GetFreeChannel()
        {
            int i = new Random().Next()*1000;
            while (PacketMap.ContainsKey(i))
            {
                i = new Random().Next() * 1000;
            }
            return i;
        }


        public IPacket GetPacketMap(int chan)
        {
            return PacketMap[chan];
        }

        public IPacketHandler GetPacketHandlerMap(int chan)
        {
            return PacketHandlerMap[chan];
        }

        public TemporaryStorage GetStorage(int chan)
        {
            return TempDataMap[chan];
        }
    }
}
