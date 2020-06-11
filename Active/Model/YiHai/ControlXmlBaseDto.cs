using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace BenDingActive.Model.YiHai
{
    [XmlRoot("control", IsNullable = false)]
    public class ControlXmlBaseDto
    {/// <summary>
        /// 医保经办机构
        /// </summary>
        [XmlElementAttribute("yab003", IsNullable = false)]
        public string MedicalInsuranceHandleNo { get; set; }
    }
}
