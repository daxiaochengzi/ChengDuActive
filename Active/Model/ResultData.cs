
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace BenDingActive.Model
{
  public  class ResultData
    {
        public object Row { get; set; }
    }
    public struct CopyDataStruct
    {
        public IntPtr dwData;
        public int cbData;

        [MarshalAs(UnmanagedType.LPStr)]
        public string lpData;
    }

   
}
