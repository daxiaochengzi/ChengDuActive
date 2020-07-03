using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BenDingActive.Model.BendParam
{
 public   class GetYinHaiBaseParam
    {
        /// <summary>
        /// 交易控制
        /// </summary>
        public string TransactionControlXml { get; set; }
        /// <summary>
        /// 交易输入
        /// </summary>
        public string TransactionInputXml { get; set; }
        /// <summary>
        /// 交易码
        /// </summary>
        public string TransactionNumber { get; set; }
        /// <summary>
        /// 操作人员
        /// </summary>
        public string UserId { get; set; }
        /// <summary>
        /// 交易流水号
        /// </summary>
        public string SerialNumber { get; set; }
        /// <summary>
        /// 交易验证码
        /// </summary>
        public string VerificationCode { get; set; }
    }
}
