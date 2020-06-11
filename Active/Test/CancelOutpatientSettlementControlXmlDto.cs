using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace BenDingActive.Test
{
    /// <summary>
    /// 门诊取消结算
    /// </summary>
    [XmlRoot("control", IsNullable = false)]
    public class CancelOutpatientSettlementControlXmlDto
    {
        /// <summary>
        /// 就诊编号
        /// </summary>
        [XmlElement("akc190", IsNullable = false)]
        public string VisitNo { get; set; }
        /// <summary>
        /// 结算编号
        /// </summary>
        [XmlElement("yka103", IsNullable = false)]
        public string SettlementNo { get; set; }

        /// <summary>
        ///支付类别
        /// </summary>
        [XmlElement("aka130", IsNullable = false)]

        public string PayType { get; set; }
    }
}
