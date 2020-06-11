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
    [XmlRoot("data", IsNullable = false)]
    public class CancelOutpatientSettlementDataXmlDto
    {/// <summary>
     /// 费用合计
     /// </summary>
        [XmlElement("yka055", IsNullable = false)]
        public decimal TotalAmount { get; set; }
        /// <summary>
        /// 社保支付总合计
        /// </summary>
        [XmlElement("yka107", IsNullable = false)]
        public decimal MedicalInsurancePayTotalAmount { get; set; }
        /// <summary>
        /// 账户支付
        /// </summary>
        [XmlElement("yka065", IsNullable = false)]
        public decimal AccountPay { get; set; }
    }
}
