using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace BenDingActive.Test
{
    /// <summary>
    /// 门诊明细上传回参
    /// </summary>
    [XmlRoot("output", IsNullable = false)]
    public class OutpatientDetailUploadOutputXmlDto
    {
        /// <summary>
        /// 费用明细
        /// </summary>
        [XmlArrayAttribute("fymxdataset")]
        [XmlArrayItem("row")]
        public List<OutpatientDetailUploadOutputCostDetailXmlDto> CostDetail { get; set; }
    }
    /// <summary>
    /// 费用明细
    /// </summary>
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public class OutpatientDetailUploadOutputCostDetailXmlDto
    {/// <summary>
     /// 费用明细ID len(20)
     /// </summary>
        [XmlElementAttribute("yka105", IsNullable = false)]
        public string DetailId { get; set; }
        /// <summary>
        /// 基层项目名称
        /// </summary>
        [XmlElementAttribute("yka095", IsNullable = false)]
        public string DirectoryName { get; set; }
        /// <summary>
        /// 数量
        /// </summary>
        [XmlElementAttribute("akc226", IsNullable = false)]
        public decimal Quantity { get; set; }
        /// <summary>
        /// 单价
        /// </summary>
        [XmlElementAttribute("akc225", IsNullable = false)]
        public decimal UnitPrice { get; set; }
        /// <summary>
        /// 金额
        /// </summary>
        [XmlElementAttribute("yka055", IsNullable = false)]
        public decimal Amount { get; set; }
        /// <summary>
        /// 基金支付单价
        /// </summary>
        [XmlElementAttribute("yke474", IsNullable = false)]
        public string FundPayUnitPrice { get; set; }
        /// <summary>
        /// 基金支付总价
        /// </summary>
        [XmlElementAttribute("yke492", IsNullable = false)]
        public string FundPayAmount { get; set; }


        /// <summary>
        /// 	社保网审标志
        /// </summary>
        [XmlElementAttribute("yke493", IsNullable = false)]
        public string MedicalInsuranceExamineSign { get; set; }

        /// <summary>
        /// 	社保网审提示信息
        /// </summary>
        [XmlElementAttribute("yke494", IsNullable = false)]
        public string MedicalInsuranceMsg { get; set; }

    }
}
