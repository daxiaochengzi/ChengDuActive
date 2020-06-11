using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace BenDingActive.Test
{
    /// <summary>
    /// 门诊挂号回参
    /// </summary>
    [XmlRoot("output", IsNullable = false)]
    public class OutpatientRegisterOutputXmlDto
    {/// <summary>
     /// 服务机构编号
     /// </summary>
        [XmlElementAttribute("akb020")]
        public string ServiceOrganizationNo { get; set; }
        /// <summary>
        /// 医保经办机构
        /// </summary>
        [XmlElementAttribute("yab003")]
        public string MedicalInsuranceOrganization { get; set; }
        /// <summary>
        /// 支付类别 (城职门诊0201,城居门诊0203)
        /// </summary>
        [XmlElementAttribute("aka130")]
        public string PayType { get; set; }
        /// <summary>
        /// 就诊编号 len(20)
        /// </summary>
        [XmlElementAttribute("akc190")]
        public string VisitNo { get; set; }
        /// <summary>
        /// 医保个人编号 
        /// </summary>
        [XmlElementAttribute("aac001")]
        public string PersonalCoding { get; set; }
        /// <summary>
        /// 病人姓名
        /// </summary>
        [XmlElementAttribute("aac003")]
        public string PatientName { get; set; }
        /// <summary>
        /// 病人性别 1男 2女
        /// </summary>
        [XmlElementAttribute("aac004")]
        public string PatientSex { get; set; }
        /// <summary>
        /// 出生日期
        /// </summary>
        [XmlElementAttribute("aac006")]
        public string Birthday { get; set; }
        /// <summary>
        /// 报销类别
        /// </summary>
        [XmlElementAttribute("ykd007")]
        public string ReimbursementType { get; set; }
        /// <summary>
        /// 门诊统筹待遇享受状态
        /// </summary>
        [XmlElementAttribute("yke484")]
        public string OutpatientOverallPlanningState { get; set; }
        /// <summary>
        ///  经办人姓名
        /// </summary>
        [XmlElementAttribute("aae011")]
        public string OperationName { get; set; }
        /// <summary>
        ///  经办时间
        /// </summary>
        [XmlElementAttribute("aae036")]
        public string OperationTime { get; set; }
        /// <summary>
        ///  结算单据号
        /// </summary>
        [XmlElementAttribute("yka103")]
        public string SettlementNo { get; set; }
        /// <summary>
        ///  合计金额
        /// </summary>
        [XmlElementAttribute("yka055")]
        public decimal TotalAmount { get; set; }
        /// <summary>
        ///  全自费
        /// </summary>
        [XmlElementAttribute("yka056")]
        public decimal TotalSelfPay { get; set; }
        /// <summary>
        ///  挂钩自付
        /// </summary>
        [XmlElementAttribute("yka057")]
        public decimal HookSelfPay { get; set; }
        /// <summary>
        /// 符合范围
        /// </summary>
        [XmlElementAttribute("yka111")]
        public string UseRange { get; set; }

        /// <summary>
        /// 个人账户余额
        /// </summary>
        [XmlArrayAttribute("grzhye")]
        [XmlArrayItem("row")]
        public List<UserInfoDatagrzhyeList>  AccountBalance { get; set; }

        /// <summary>
        /// 账户支付合计
        /// </summary>
        [XmlElementAttribute("yka065")]
        public decimal AccountPayTotal { get; set; }
        /// <summary>
        /// 社保支付合计 【如果是城乡居民，该节点含义表示本次门诊补助支出】
        /// </summary>
        [XmlElementAttribute("yka107")]
        public decimal MedicalInsurancePayTotal { get; set; }
        /// <summary>
        /// 现金支付
        /// </summary>
        [XmlElementAttribute("ykh012")]
        public decimal CashPayment { get; set; }
        /// <summary>
        /// 数据明细
        /// </summary>
        [XmlArrayAttribute("dataset")]
        [XmlArrayItem("row")]
        public List<OutpatientRegisterOutputXmlDataSetDto> DataSetRow { get; set; }
        /// <summary>
        /// 费用明细
        /// </summary>
        [XmlArrayAttribute("fymxdataset")]

        [XmlArrayItem("row")]
        public List<OutpatientRegisterOutputXmlCostDetailDto> CostDetailRow { get; set; }

    }
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public class OutpatientRegisterOutputXmlDataSetDto
    {
        /// <summary>
        /// 参保中心
        /// </summary>
        [XmlElementAttribute("yab139")]
        public string InsuranceCenter { get; set; }
        /// <summary>
        /// 费用分段标准
        /// </summary>
        [XmlElementAttribute("aka213")]

        public string CostSegment { get; set; }
        /// <summary>
        ///起付线
        /// </summary>
        [XmlElementAttribute("yka115")]

        public decimal Deductible { get; set; }
        /// <summary>
        ///进入起付线
        /// </summary>
        [XmlElementAttribute("yka058")]
        public decimal InputDeductible { get; set; }
        /// <summary>
        /// 报销比例
        /// </summary>
        [XmlElementAttribute("ykc125")]
        public decimal ReimbursementProportion { get; set; }

        /// <summary>
        /// 社保基金支付金额
        /// </summary>
        [XmlElementAttribute("yka107")]
        public decimal MedicalInsurancePayTotal { get; set; }

        /// <summary>
        /// 个人账户支付
        /// </summary>
        [XmlElementAttribute("yka065")]
        public decimal AccountPay { get; set; }

        /// <summary>
        /// 就诊结算方式
        /// </summary>
        [XmlElementAttribute("ykc121")]
        public string SettlementType { get; set; }
        /// <summary>
        /// 清算分中心
        /// </summary>
        [XmlElementAttribute("ykb037")]
        public string SettlementPlaceCenter { get; set; }
        /// <summary>
        /// 清算方式
        /// </summary>
        [XmlElementAttribute("yka054")]
        public string CenterSettlementType { get; set; }
        /// <summary>
        /// 清算类别  城镇职工:城镇职工门;城乡居民城:乡居民门诊;
        /// </summary>
        [XmlElementAttribute("yka316")]
        public string CenterSettlementCostType { get; set; }

    }
    /// <summary>
    /// 费用明细
    /// </summary>
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public class OutpatientRegisterOutputXmlCostDetailDto
    {/// <summary>
     /// 项目明细编号
     /// </summary>
        [XmlElementAttribute("yka105")]
        public string ProjectDetailNo { get; set; }
        /// <summary>
        /// 限制价格
        /// </summary>
        [XmlElementAttribute("yka299")]
        public decimal LimitPrice { get; set; }
        /// <summary>
        ///自付比例
        /// </summary>
        [XmlElementAttribute("yka096")]
        public decimal SelfPayProportion { get; set; }
        /// <summary>
        ///  全自费
        /// </summary>
        [XmlElementAttribute("yka056")]
        public decimal TotalSelfPay { get; set; }

        /// <summary>
        ///  挂钩自付
        /// </summary>
        [XmlElementAttribute("yka057")]
        public decimal HookSelfPay { get; set; }
        /// <summary>
        /// 符合范围
        /// </summary>
        [XmlElementAttribute("yka111")]
        public string UseRange { get; set; }
        /// <summary>
        /// 限制使用
        /// </summary>
        [XmlElementAttribute("yke011")]
        public string LimitUse { get; set; }

    }
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public class UserInfoDatagrzhyeList
    {
        /// <summary>
        /// 账户种类
        /// </summary>
        [XmlElementAttribute("ykc303")]

        public string AccountType { get; set; }
        /// <summary>
        /// 账户余额
        /// </summary>
        [XmlElementAttribute("ykc194")]

        public decimal AccountBalance { get; set; }
    }
}
