using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace BenDingActive.Help
{
  public  class IniFile
    {
        public string path;

        public IniFile()
        {
            var is64Bit = Environment.Is64BitOperatingSystem;
            path = is64Bit ? @"C:\Program Files (x86)\Microsoft\本鼎医保插件\BenDing.ini" : @"C:\Program Files\Microsoft\BenDingActiveSetup\BenDing.ini";
        }

        [DllImport("kernel32")]
        private static extern long WritePrivateProfileString(string section,
            string key, string val, string filePath);

        [DllImport("kernel32")]

        private static extern int GetPrivateProfileString(string section,
            string key, string def, StringBuilder retVal, int size, string filePath);

        public void IniWriteValue(string Section, string Key, string Value)
        {
            WritePrivateProfileString(Section, Key, Value, this.path);
        }


        public string IniReadValue(string Section, string Key)
        {
            StringBuilder temp = new StringBuilder(102410);

            int i = GetPrivateProfileString(Section, Key, "", temp, 102410, this.path);

            return temp.ToString();

        }

        /// <summary>
        /// 获取xml标头
        /// </summary>
        /// <returns></returns>
        public string GetIni()
        {
            var is64Bit = Environment.Is64BitOperatingSystem;
            path = is64Bit ? @"C:\Program Files (x86)\Microsoft\本鼎医保插件\BenDing.ini" : @"C:\Program Files\Microsoft\BenDingActiveSetup\BenDing.ini";
            IniFile myFile = new IniFile();
            var port = myFile.IniReadValue("BenDingSet", "Port");
            return port;
        }
        /// <summary>
        /// 获取发送端口
        /// </summary>
        /// <returns></returns>
        public string SendPort()
        {
            var is64Bit = Environment.Is64BitOperatingSystem;
            path = is64Bit ? @"C:\Program Files (x86)\Microsoft\本鼎医保插件\BenDing.ini" : @"C:\Program Files\Microsoft\BenDingActiveSetup\BenDing.ini";
            IniFile myFile = new IniFile();
            var port = myFile.IniReadValue("SendPort", "Port");
            return port;
        }
        /// <summary>
        /// 获取接受端口
        /// </summary>
        /// <returns></returns>
        public string AcceptPort()
        {
            var is64Bit = Environment.Is64BitOperatingSystem;
            path = is64Bit ? @"C:\Program Files (x86)\Microsoft\本鼎医保插件\BenDing.ini" : @"C:\Program Files\Microsoft\BenDingActiveSetup\BenDing.ini";
            IniFile myFile = new IniFile();
            var port = myFile.IniReadValue("AcceptPort", "Port");
            return port;
        }
    }
}
