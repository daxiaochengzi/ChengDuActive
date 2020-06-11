using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace BenDingActive.Model.Dto.YiHai
{
    [XmlRoot("output", IsNullable = false)]
    public class MedicalInsuranceSignInXmlDto
    {/// <summary>
        ///  
        /// </summary>

        [XmlArrayItem("row")]
        public List<MedicalInsuranceSignInXmlRowDto> Row { get; set; }
    }
    /// <summary>
    /// 
    /// </summary>
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public class MedicalInsuranceSignInXmlRowDto
    {   /// <summary>
        /// 医保经办机构
        /// </summary>
        [XmlElementAttribute("yab003", IsNullable = false)]
        public string MedicalInsuranceOrganization { get; set; }
        /// <summary>
        /// 签到状态
        /// </summary>
        [XmlElementAttribute("yke190", IsNullable = false)]
        public int SignInState { get; set; }
        /// <summary>
        /// 批次号
        /// </summary>
        [XmlElementAttribute("yke189", IsNullable = false)]
        public string BatchNo { get; set; }
        /// <summary>
        /// 签到时间
        /// </summary>
        [XmlElementAttribute("yke191", IsNullable = false)]
        public string SignInTime { get; set; }
    }
}
