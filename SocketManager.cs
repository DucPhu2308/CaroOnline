using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CaroLAN
{
    internal class SocketManager
    {
        #region Client
        Socket Client;
        public bool ConnectServer()
        {
            IPEndPoint iep = new IPEndPoint(System.Net.IPAddress.Parse(IP), Port);
            Client = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            try
            {
                Client.Connect(iep);
                return true;
            }
            catch
            {
                return false;
            }
        }
        #endregion

        #region Server
        Socket Server;
        public void CreateServer()
        {
            IPEndPoint iep = new IPEndPoint(IPAddress.Parse(IP), Port);
            Server = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            Server.Bind(iep);
            Server.Listen(10);

            Thread acceptClient = new Thread(() =>
            {
                Client = Server.Accept();
            });
            acceptClient.IsBackground = true;
            acceptClient.Start();
        }
        #endregion

        #region Both
        public String IP = "127.0.0.1";
        public int Port = 9999;
        public bool isServer = true;
        public const int BUFFER = 1024;

        public bool Send(object data)
        {
            byte[] sendData = Serialize(data);
            if (isServer)
                return SendData(Client, sendData);
            else
                return SendData(Server, sendData);
        }
        public object Receive()
        {
            byte[] receiveData = new byte[BUFFER];
            if (isServer)
                ReceiveData(Client, receiveData);
            else
                ReceiveData(Server, receiveData);
            return Deserialize(receiveData);
        }
        public bool SendData(Socket target, byte[] data)
        {
            return target.Send(data) == 1 ? true : false;
        }
        public bool ReceiveData(Socket target, byte[] data)
        {
            return target.Receive(data) == 1 ? true : false;
        }
        public static String GetLocalIPv4(System.Net.NetworkInformation.NetworkInterfaceType _type)
        {
            String output = "";
            foreach (System.Net.NetworkInformation.NetworkInterface item in System.Net.NetworkInformation.NetworkInterface.GetAllNetworkInterfaces())
            {
                if (item.NetworkInterfaceType == _type && item.OperationalStatus == System.Net.NetworkInformation.OperationalStatus.Up)
                {
                    foreach (System.Net.NetworkInformation.UnicastIPAddressInformation ip in item.GetIPProperties().UnicastAddresses)
                    {
                        if (ip.Address.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork)
                        {
                            output = ip.Address.ToString();
                        }
                    }
                }
            }
            return output;
        }
        public object Deserialize(byte[] data)
        {
            using (System.IO.MemoryStream ms = new System.IO.MemoryStream(data))
            {
                System.Runtime.Serialization.Formatters.Binary.BinaryFormatter bf = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
                ms.Position = 0;
                return bf.Deserialize(ms);
            }
        }
        public byte[] Serialize(object obj)
        {
            using (System.IO.MemoryStream ms = new System.IO.MemoryStream())
            {
                System.Runtime.Serialization.Formatters.Binary.BinaryFormatter bf = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
                bf.Serialize(ms, obj);
                return ms.ToArray();
            }
        }
        #endregion
    }
}
