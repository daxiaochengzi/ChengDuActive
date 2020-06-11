using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using BenDingActive.Help;


namespace BenDingActive
{
    public class UdpStateEventArgs : EventArgs
    {
        public IPEndPoint remoteEndPoint;
        public byte[] buffer = null;
    }

    public delegate void UDPReceivedEventHandler(UdpStateEventArgs args);

    public class UDPClient
    {
        public UdpClient udpClient;
        public event UDPReceivedEventHandler UDPMessageReceived;
        string remoteIp = "127.0.0.1";
        int remotePort ;
        public UDPClient(string locateIP, int locatePort)
        {
            var iniFile = new IniFile();
            remotePort = Convert.ToInt32(iniFile.SendPort());
            IPAddress locateIp = IPAddress.Parse(locateIP);
            IPEndPoint locatePoint = new IPEndPoint(locateIp, locatePort);
            try
            {
                udpClient = new UdpClient(locatePoint);

                //监听创建好后，创建一个线程，开始接收信息
                Task.Run(() =>
                {
                    while (true)
                    {
                        //var socket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
                        //var ipPoint = new IPEndPoint(IPAddress.Parse(ipAdrr), 2012);
                        //socket.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.ReuseAddress, true);  //SocketOptionName.ReuseAddress是关键
                        //socket.Bind(ipPoint);


                        UdpStateEventArgs udpReceiveState = new UdpStateEventArgs();

                        if (udpClient != null)
                        {
                            IPEndPoint remotePoint = new IPEndPoint(IPAddress.Parse(remoteIp), remotePort);
                            var received = udpClient.Receive(ref remotePoint);
                            udpReceiveState.remoteEndPoint = remotePoint;
                            udpReceiveState.buffer = received;
                            UDPMessageReceived?.Invoke(udpReceiveState);
                        }
                        else
                        {
                            break;
                        }
                    }
                });
            }
            catch (Exception e)
            {
               Logs.LogErrorWrite(new LogParam()
               {   Msg = e.Message,
                   OperatorCode = "upd通信错误信息"
               });
            }



        }

        public void Send(string msg)
        {


            if (udpClient != null)
            {

                IPAddress remoteIpAddr = IPAddress.Parse(remoteIp);
                IPEndPoint remotePoint = new IPEndPoint(remoteIpAddr, remotePort);
                byte[] buffer = Encoding.UTF8.GetBytes(msg);
                udpClient?.Send(buffer, buffer.Length, remotePoint);
                
            }
        }
    }
}
