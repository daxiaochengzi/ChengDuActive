using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace BenDingActive.Test
{
    [XmlRoot("data", IsNullable = false)]
    public class SignInDataXmlDto
    {/// <summary>
     /// 医保经办机构
     /// </summary>
        [XmlElementAttribute("yab003", IsNullable = false)]
        public string MedicalInsuranceOrganization { get; set; }
    }
}
