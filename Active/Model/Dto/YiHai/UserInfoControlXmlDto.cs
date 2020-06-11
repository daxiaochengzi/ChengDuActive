using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace BenDingActive.Model.Dto.YiHai
{
    [XmlRoot("control", IsNullable = false)]
    public class UserInfoControlXmlDto
    {
        public string edition { get; set; }
    }
}
