using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace BenDingActive.Test
{
    /// <summary>
    /// 门诊明细上传控制
    /// </summary>
    [XmlRoot("control", IsNullable = false)]
    public class OutpatientDetailUploadControlXmlDto
    {  /// <summary>
        /// 就诊编号
        /// </summary>
        [XmlElement("akc190", IsNullable = false)]
        public string VisitNo { get; set; }
        /// <summary>
        /// 个人编码
        /// </summary>
        [XmlElement("aac001", IsNullable = false)]

        public string PersonalCode { get; set; }
        /// <summary>
        ///支付类别
        /// </summary>
        [XmlElement("aka130", IsNullable = false)]

        public string PayType { get; set; }
        /// <summary>
        ///医保机构
        /// </summary>
        [XmlElement("yab003", IsNullable = false)]

        public string MedicalInsuranceOrganization { get; set; }

        /// <summary>
        ///明细条数
        /// </summary>
        [XmlElement("nums", IsNullable = false)]

        public int Nums { get; set; }
        /// <summary>
        /// 费用合计
        /// </summary>
        [XmlElement("yka055", IsNullable = false)]
        public decimal TotalAmount { get; set; }

        /// <summary>
        ///版本号
        /// </summary>
        [XmlElement("edition", IsNullable = false)]
        public string Edition { get; set; } = "5.0";
    }
}
