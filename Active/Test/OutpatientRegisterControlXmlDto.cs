using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace BenDingActive.Test
{
    /// <summary>
    /// 门诊挂号控制
    /// </summary>
    [XmlRoot("control", IsNullable = false)]
    public class OutpatientRegisterControlXmlDto
    {   /// <summary>
        /// 明细条数
        /// </summary>
        [XmlElementAttribute("nums", IsNullable = false)]
        public int Nums { get; set; }
        /// <summary>
        /// 合计费用
        /// </summary>
        [XmlElementAttribute("yka055", IsNullable = false)]
        public decimal TotalAmount { get; set; }

    }
}
