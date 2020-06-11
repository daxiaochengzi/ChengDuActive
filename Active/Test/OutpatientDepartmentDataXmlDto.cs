using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace BenDingActive.Test
{
    [XmlRoot("data", IsNullable = false)]
    public class OutpatientDepartmentDataXmlDto
    {
        public OutpatientDepartmentDataXmlSerialNumberDto row { get; set; }
        /// <summary>
        /// 费用明细
        /// </summary>

        [XmlArrayAttribute("datasetmx")]
        [XmlArrayItem("row")]
        public List<OutpatientDepartmentDataXmlRowDto> costDetail  { get; set; }
        /// <summary>
        /// 医嘱明细
        /// </summary>
        [XmlArrayAttribute("datasetyz")]
        [XmlArrayItem("row")]
        public List<OutpatientDepartmentDataXmlDetailDto> OrdersDetail { get; set; }

        
    }
    /// <summary>
    /// 费用明细
    /// </summary>
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public class OutpatientDepartmentDataXmlRowDto
    {
        /// <summary>
        /// 流水号 len(20)
        /// </summary>
        [XmlAttribute("yka105")]
        public string DetailId { get; set; }
        /// <summary>
        /// 医保项目编码
        /// </summary>
        [XmlAttribute("yka094")]
        public string ProjectCode { get; set; }
        /// <summary>
        /// 基层项目名称
        /// </summary>
        [XmlAttribute("yka095")]
        public string DirectoryName { get; set; }
        /// <summary>
        /// 数量
        /// </summary>
        [XmlAttribute("akc226")]
        public decimal Quantity { get; set; }
        /// <summary>
        /// 单价
        /// </summary>
        [XmlAttribute("akc225")]
        public decimal UnitPrice { get; set; }
        /// <summary>
        /// 金额
        /// </summary>
        [XmlAttribute("yka055")]
        public decimal Amount { get; set; }

        /// <summary>
        /// 审核标志
        /// </summary>
        [XmlAttribute("yke186")]
        public string ApprovalMark { get; set; } = "";
        /// <summary>
        /// 开单科室编码
        /// </summary>
        [XmlAttribute("yka097")]
        public string BillDepartmentId { get; set; }="";
        /// <summary>
        /// 开单科室名称
        /// </summary>
        [XmlAttribute("yka098")]
        public string BillDepartment { get; set; } = "";
        /// <summary>
        /// 开单医生姓名
        /// </summary>
        [XmlAttribute("yka099")]
        public string BillDoctorName { get; set; } = "";
        /// <summary>
        /// 执行科室编码
        /// </summary>
        [XmlAttribute("yka100")]
        public string OperateDepartmentId { get; set; } = "";
        /// <summary>
        /// 执行科室名称
        /// </summary>
        [XmlAttribute("yka101")]
        public string OperateDepartmentName { get; set; } = "";
        /// <summary>
        /// 执行医生姓名
        /// </summary>
        [XmlAttribute("yka102")]
        public string OperateDoctorName { get; set; }

        /// <summary>
        /// 经办人
        /// </summary>
        [XmlAttribute("aae011")]
        public string Operators { get; set; }


        /// <summary>
        /// 明细录入时间 (yyyy-mm-dd hh:mm:ss)
        /// </summary>
        [XmlAttribute("yke123")]
        public string DetailInputTime { get; set; }
        /// <summary>
        /// 明细发生时间 (yyyy-mm-dd hh:mm:ss)
        /// </summary>
        [XmlAttribute("aae036")]
        public string DetailTime { get; set; }
        /// <summary>
        /// 手术编号
        /// </summary>
        [XmlAttribute("ykd040")]
        public string OperationNo { get; set; } = "";
        /// <summary>
        /// 医嘱序号
        /// </summary>
        [XmlAttribute("yke112")]
        public string OrdersSortNo { get; set; } = "";
        /// <summary>
        /// 备注
        /// </summary>
        [XmlAttribute("aae013")]
        public string Remark { get; set; } = "";

        /// <summary>
        ///使用方式 （固定值 01）
        /// </summary>
        [XmlAttribute("yke201")]
        public string UserMethod { get; set; } = "01";
        /// <summary>
        /// 处方号 len(15)
        /// </summary>
        [XmlAttribute("yke134")]
        public string PrescriptionNo { get; set; }
        /// <summary>
        /// 药品进价
        /// </summary>
        [XmlAttribute("yke553")]
        public decimal InputPrice { get; set; }
        /// <summary>
        /// 外检标志
        /// </summary>
        [XmlAttribute("yke676")]
        public string ExternalInspectSign { get; set; } = "";
        /// <summary>
        /// 外检医院编码
        /// </summary>
        [XmlAttribute("yke677")]
        public string ExternalInspectHospitalNo { get; set; } = "";

        /// <summary>
        /// 外检医院编码
        /// </summary>
        [XmlAttribute("ykf008")]
        public string DoctorCode { get; set; } = "";
        /// <summary>
        /// 设备编号
        /// </summary>
        [XmlAttribute("ykf013")]
        public string EquipmentCode { get; set; } = "";
        /// <summary>
        /// 医院对码流水号
        /// </summary>
        [XmlAttribute("ake005")]
        public string HospitalPairingCode { get; set; } = "";
        /// <summary>
        /// 药品编码/诊疗项目编码
        /// </summary>
        [XmlAttribute("yka059")]
        public string DirectoryCode { get; set; }
        /// <summary>
        /// 诊断编码
        /// </summary>
        [XmlAttribute("ykd018")]
        public string DiagnosticCode { get; set; } = "";
        /// <summary>
        /// 诊断内容
        /// </summary>
        [XmlAttribute("yke122")]
        public string DiagnosticContent { get; set; } = "";

        //yke112
    }
    /// <summary>
    /// 医嘱明细
    /// </summary>
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public class OutpatientDepartmentDataXmlDetailDto
    {
        /// <summary>
        /// 医嘱序号
        /// </summary>
        [XmlElementAttribute("yke112", IsNullable = false)]
        public string OrdersSortNo { get; set; } = "";
        /// <summary>
        /// 医嘱内容
        /// </summary>
        [XmlElementAttribute("yke113", IsNullable = false)]
        public string OrdersContent { get; set; } = "";
        /// <summary>
        /// 医生姓名
        /// </summary>
        [XmlElementAttribute("yka287", IsNullable = false)]
        public string DoctorName { get; set; } = "";
        /// <summary>
        /// 医生编码
        /// </summary>
        [XmlElementAttribute("ykf008", IsNullable = false)]
        public string DoctorCode { get; set; } = "";
        /// <summary>
        /// 医嘱科室编码
        /// </summary>
        [XmlElementAttribute("aaz307", IsNullable = false)]
        public string OrdersDepartmentCode { get; set; } = "";

        /// <summary>
        /// 医嘱科室名称
        /// </summary>
        [XmlElementAttribute("akf002", IsNullable = false)]
        public string OrdersDepartmentName { get; set; } = "";
        /// <summary>
        /// 医院对码编号
        /// </summary>
        [XmlElementAttribute("ake005", IsNullable = false)]
        public string HospitalCodeNo { get; set; } = "";
        /// <summary>
        /// 医嘱类别
        /// </summary>
        [XmlElementAttribute("yke365", IsNullable = false)]
        public string OrdersType { get; set; } = "";
        /// <summary>
        /// 医嘱分类
        /// </summary>
        [XmlElementAttribute("yke658", IsNullable = false)]
        public string OrdersClassify { get; set; } = "";
        /// <summary>
        /// 剂量单位
        /// </summary>
        [XmlElementAttribute("yke351", IsNullable = false)]
        public string DoseUnit { get; set; } = "";
        /// <summary>
        /// 剂量
        /// </summary>
        [XmlElementAttribute("yke352", IsNullable = false)]
        public int Dose { get; set; } = 1;

        /// <summary>
        /// 用药途径
        /// </summary>
        [XmlElementAttribute("yke355", IsNullable = false)]
        public string UserRoad { get; set; } = "";
        /// <summary>
        /// 每次用量
        /// </summary>
        [XmlElementAttribute("yke654", IsNullable = false)]
        public int EveryTimeDosage { get; set; } = 1;
        /// <summary>
        /// 每次用量单位
        /// </summary>
        [XmlElementAttribute("yke655", IsNullable = false)]
        public string EveryTimeDosageUnit { get; set; } = "";
        /// <summary>
        /// 发药量
        /// </summary>
        [XmlElementAttribute("yke656", IsNullable = false)]
        public string Dosage { get; set; } = "";
        /// <summary>
        /// 发药量单位
        /// </summary>
        [XmlElementAttribute("yke657", IsNullable = false)]
        public string DosageUnit { get; set; } = "";
        /// <summary>
        /// 频次
        /// </summary>
        [XmlElementAttribute("yke350", IsNullable = false)]
        public int Frequency { get; set; } = 1;
        /// <summary>
        /// 使用天数
        /// </summary>
        [XmlElementAttribute("yke446", IsNullable = false)]
        public int UseDays { get; set; } = 1;

    }
    /// <summary>
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public class OutpatientDepartmentDataXmlSerialNumberDto
    {
        /// <summary>
        /// 流水号
        /// </summary>
        [XmlElementAttribute("yka105", IsNullable = false)]
        public string DetailId { get; set; }
    }
    //SerialNumber
}
