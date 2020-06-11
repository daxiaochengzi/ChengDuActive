using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BenDingActive.Model.Params.OutpatientDepartment
{
   public class YiHaiMedicalInsuranceOperationParam
    {/// <summary>
    /// 控制参数
    /// </summary>
        public string ControlParam { get; set; }
        /// <summary>
        /// 输入参数
        /// </summary>
        public string InputParam { get; set; }
        /// <summary>
        /// 操作人员id
        /// </summary>
        public string  OperatorId { get; set; }
        /// <summary>
        /// 交易编号
        /// </summary>
        public  string TransactionNumber { get; set; }
        public  string TransactionOutputXml { get; set; }
    }
}
