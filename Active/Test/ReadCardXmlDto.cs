using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace BenDingActive.Test
{
    /// <summary>
    //
    /// </summary>
    [XmlRoot("control", IsNullable = false)]
    public  class ReadCardXmlDto
    {
        public string edition { get; set; }
    }
}
