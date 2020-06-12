using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace BenDingActive.Model.Dto.YiHai
{
    /// <summary>
    /// 不确定交易回参
    /// </summary>
    [XmlRoot("output", IsNullable = false)]
    public class QueryUncertainTransactionOutputXmlDto
    {/// <summary>
        /// 
        /// </summary>
        [XmlElementAttribute("row", IsNullable = false)]
        public List<QueryUncertainTransactionOutputRowXmlDto> Row { get; set; }
    }

    public class QueryUncertainTransactionOutputRowXmlDto
    {/// <summary>
        /// 交易流水号
        /// </summary>
        [XmlElementAttribute("yke014")]
        public string SerialNumber { get; set; }
        [XmlElementAttribute("key", IsNullable = false)]
        public List<QueryUncertainTransactionOutputRowKeyXmlDto> Key { get; set; }
    }
    public class QueryUncertainTransactionOutputRowKeyXmlDto
    {/// <summary>
        /// 就诊编号
        /// </summary>
        [XmlElementAttribute("akc190")]
        public string VisitNo { get; set; }
        /// <summary>
        /// 结算编号
        /// </summary>
        [XmlElementAttribute("yka103")]
        public string SettlementNo { get; set; }
        /// <summary>
        /// 报销类型
        /// </summary>
        [XmlElementAttribute("ykd007")]
        public string ReimbursementType { get; set; }
    }
}
