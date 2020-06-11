using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BenDingActive.Model.YiHai
{
   public class DealModel
    {
        
        #region 银海接口属性

       

        /// <summary>
        /// 交易编号
        /// </summary>
        public string TransactionNumber = string.Empty;
        /// <summary>
        /// 交易控制
        /// </summary>
        public string TransactionControlXml = string.Empty;
        /// <summary>
        /// 交易输入
        /// </summary>
        public string TransactionInputXml = string.Empty;
        /// <summary>
        /// 批次编号
        /// </summary>
        public string BatchNo = string.Empty;
        /// <summary>
        /// 交易流水号
        /// </summary>
        public string SerialNumber = string.Empty;

        /// <summary>
        /// 交易验证码
        /// </summary>
        public string VerificationCode = string.Empty;

        /// <summary>
        ///交易输出
        /// </summary>
        public string TransactionOutputXml = string.Empty;


        /// <summary>
        /// 返回代码，小于0时，返回错误
        /// </summary>
        public int along_appcode = -1;

        #endregion


        ///// <summary>
        ///// 当前调用名称
        ///// </summary>
        //public string DealName = string.Empty;

        /// <summary>
        /// 返回XML时，解析的Xpath 
        /// </summary>
        public string ResultXmlXpath ;


        /// <summary>
        /// 输出文件路径
        /// </summary>
        public string OutputFilePath;



        ///// <summary>
        ///// 判断银海接口是否返回成功
        ///// </summary>
        ///// <returns></returns>
        //public bool IsYanHaiSuccess
        //{
        //    get { return along_appcode >= 0; }
        //}


        /// <summary>
        /// 错误等信息
        /// </summary>
        public string Msg; 
    }
}
