using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using BenDingActive.Help;


namespace BenDingActive
{ 

  public class SendService
{
        private UDPClient udpClient = null;
        private string replyStr = null;
        public SendService()
        {
            Init(); 
        }
        public void Init()
        {
            var iniFile = new IniFile();
            udpClient = new UDPClient("127.0.0.1", Convert.ToInt32(iniFile.AcceptPort()));
            udpClient.UDPMessageReceived += UdpClient_UDPMessageReceived;
        }
        private void UdpClient_UDPMessageReceived(UdpStateEventArgs args)
        {
            replyStr = Encoding.UTF8.GetString(args.buffer);
          
        }
        public string SendData(string param,string operatorId)
        {  //发送数据id
            var sendDataId = Guid.NewGuid().ToString();
            var iniFile = new IniFile();
            iniFile.IniWriteValue("SendData", " Value", param);
            string resultData = null;
            udpClient.Send(sendDataId);
            while (true)
            {
                if (replyStr != null)
                {
                    break;
                }
            }
            ////释放对象
            //udpClient.udpClient=null;
            if (sendDataId != replyStr)
            {
                Logs.LogErrorWrite(new LogParam()
                {
                    Params = param,
                    ResultData = replyStr,
                    Msg = "数据id不一致请检查 "+"[初始id:"+ sendDataId + "]" ,
                    OperatorCode = operatorId
                });
                throw new Exception("数据id不一致请检查");
            }
            resultData = iniFile.IniReadValue("AcceptData", " Value");
            return resultData;
        }
    }
}
