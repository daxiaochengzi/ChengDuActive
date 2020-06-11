using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace BenDingActive.Test
{
    [XmlRoot("Control", IsNullable = false)]
    public class OutpatientDepartmentControlXmlDto
    {  ///<summary>
       /// 就诊编号(条数大于50存在就诊编码)
       /// </summary>
        [XmlElementAttribute("akc190", IsNullable = false)]
        public string VisitNo { get; set; } = "";
        ///// <summary>
        ///// 个人编码
        ///// </summary>
        //[XmlElementAttribute("aac001", IsNullable = false)]
        //public string PersonalCoding { get; set; }
        ///// <summary>
        ///// 支付类别
        ///// </summary>
        //[XmlElementAttribute("aka130", IsNullable = false)]
        //public string PaymentCategory { get; set; }
        ///// <summary>
        ///// 医保经办机构
        ///// </summary>
        //[XmlElementAttribute("yab003", IsNullable = false)]
        //public string MedicalInsuranceOrganization { get; set; }
        /// <summary>
        /// 总条数  (小于50条)
        /// </summary>

        public int nums { get; set; }
        /// <summary>
        /// 总金额  0.00
        /// </summary>
        [XmlElementAttribute("yka055", IsNullable = false)]
        public decimal TotalAmount { get; set; }

        /// <summary>
        /// 版本号
        /// </summary>
        public string edition { get; set; } = "5.0";
        //yka055
        /// <summary>
        /// 结算标致  -居民不传值或传0  --职工传1
        /// </summary>
        [XmlElementAttribute("yke550", IsNullable = false)]
        public int SettlementSign { get; set; }
        
    }
}
