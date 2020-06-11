using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace BenDingActive.Test
{
    /// <summary>
    /// 门诊挂号
    /// </summary>
    [XmlRoot("data", IsNullable = false)]
    public class OutpatientRegisterDataXmlDto
    {   /// <summary>
        /// 挂号类型 (1.普通门诊 2.急诊 3.专家门诊 4.其他 )
        /// </summary>
        [XmlElementAttribute("yke309")]
        public string RegisterType { get; set; }
        /// <summary>
        /// 医保科室编码
        /// </summary>
        [XmlElementAttribute("yka382")]
        public string MedicalInsuranceDepartmentCode { get; set; }
        /// <summary>
        /// 基层科室编码
        /// </summary>
        [XmlElementAttribute("yke506")]
        public string BaseDepartmentCode { get; set; }
        /// <summary>
        /// 基层科室名称
        /// </summary>
        [XmlElementAttribute("yka383")]
        public string BaseDepartmentName { get; set; }
        /// <summary>
        /// 经办人姓名
        /// </summary>
        [XmlElementAttribute("AAE011")]
        public string OperatorName { get; set; }
        /// <summary>
        /// 经办时间 (yyyy-MM-dd HH:mm:ss)
        /// </summary>
        [XmlElementAttribute("aae036")]
        public string OperatorTime { get; set; }

        /// <summary>
        /// 费用明细
        /// </summary>
        [XmlArrayAttribute("datasetfymx")]
        [XmlArrayItem("row")]
        public List<OutpatientRegisterDataXmlRow> DetailRow { get; set; }
    }
    /// <summary>
    /// 费用明细
    /// </summary>
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public class OutpatientRegisterDataXmlRow
    {

        /// <summary>
        /// 流水号
        /// </summary>
        [XmlAttribute("yka105")]
        public string BusinessId { get; set; }
        /// <summary>
        /// 医保项目编码
        /// </summary>
        [XmlAttribute("yka094")]
        public string MedicalInsuranceProjectCode { get; set; }
        /// <summary>
        /// 目录名称
        /// </summary>
        [XmlAttribute("yka095")]
        public string DirectoryName { get; set; }
        /// <summary>
        ///  数量 (可以为0)
        /// </summary>

        [XmlAttribute("akc226")]
        public int Num { get; set; }
        /// <summary>
        ///  单价
        /// </summary>
        [XmlAttribute("akc225")]
        public decimal Price { get; set; }

        /// <summary>
        ///  合计金额
        /// </summary>
        [XmlAttribute("yka055")]
        public decimal TotalAmount { get; set; }
        /// <summary>
        /// 经办人
        /// </summary>
        [XmlAttribute("aae011")]
        public string Operator { get; set; }
        /// <summary>
        /// 录入时间
        /// </summary>
        [XmlAttribute("aae036")]
        public string InputTime { get; set; }
        /// <summary>
        /// 发生时间
        /// </summary>
        [XmlAttribute("yke123")]
        public string HappenTime { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        [XmlAttribute("aae013")]
        public string Remark { get; set; } = "";

    }
}
