using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace BenDingActive.Test
{
    [XmlRoot("control", IsNullable = false)]
    public class SignInControlXmlDto
    {  /// <summary>
       /// 操作人员姓名
       /// </summary>
        [XmlElementAttribute("aae011", IsNullable = false)]
        public string OperationName { get; set; }
    }
}
