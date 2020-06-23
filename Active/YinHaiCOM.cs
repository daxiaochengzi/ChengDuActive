using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using BenDingActive.Model.YiHai;


namespace BenDingActive
{
    public static class YinHaiCOM
    {  
        static System.Type yh = Type.GetTypeFromProgID("YinHai.ChenDu.Interface");
        static Object yhObject;
        //签到人员id
        static string SignInUserId = "";
        /// <summary>
        /// 设置签到人员id
        /// </summary>
        /// <param name="userId"></param>
        public static void SetSignInUserId(string userId)
        {
            SignInUserId = userId;
        }
        /// <summary>
        /// 获取签到人员id
        /// </summary>
        /// <param name="userId"></param>
        public static string GetSignInUserId()
        {
            var userId = SignInUserId;
            return userId;
        }
        /// <summary>
        /// 释放资源
        /// </summary>
        public static bool Destroy()
        {
            return yh_interface_destroy();
        }
        /// <summary>
        /// 交易主函数，完成所有医疗业务的实际处理（可能存在用户交互界面）
        /// </summary>
        /// <param name="dealModel"></param>
        public static void CallDeal(DealModel dealModel)
        {
      
                yh_interface_call(
                    dealModel.TransactionNumber,
                    dealModel.TransactionControlXml, 
                    dealModel.TransactionInputXml,
                    ref dealModel.BatchNo,
                    ref dealModel.SerialNumber,
                    ref dealModel.VerificationCode,
                    ref dealModel.TransactionOutputXml, 
                    ref dealModel.along_appcode, 
                    ref dealModel.Msg);
           




        }
        /// <summary>
        /// 确认交易(只需要传入流水号，和交易码来确认交易)
        /// </summary>
        /// <param name="dealModel"></param>
        /// <param name="msg"></param>
        /// <returns></returns>
        public static void ConfirmDeal(DealModel dealModel)
        {
            if (yhObject == null) yhObject = System.Activator.CreateInstance(yh);
            yh_interface_confirm(dealModel.SerialNumber, dealModel.VerificationCode, ref dealModel.along_appcode, ref dealModel.Msg);
        }
        /// <summary>
        /// 查询不确定的交易
        /// </summary>
        /// <param name="dealModel"></param>
        /// <param name="msg"></param>
        /// <returns></returns>
        public static void Getuncertaintytrade(DealModel dealModel)
        {
            if (yhObject == null) yhObject = System.Activator.CreateInstance(yh);
            yh_interface_getuncertaintytrade(dealModel.TransactionNumber, ref dealModel.TransactionOutputXml, ref dealModel.along_appcode, ref dealModel.Msg);
        }

        /// <summary>
        /// 取消交易（只需要传入交易流水号）
        /// </summary>
        /// <param name="dealModel"></param>
        /// <param name="msg"></param>
        /// <returns></returns>
        public static void CancelDeal(DealModel dealModel)
        {
            if (yhObject == null) yhObject = System.Activator.CreateInstance(yh);
            yh_interface_cancel(dealModel.SerialNumber, ref dealModel.along_appcode, ref dealModel.Msg);
        }

        /// <summary>
        /// 主交易
        /// </summary>
        /// <param name="astr_jybh">交易编号</param>
        /// <param name="astr_jykz_xml">控制入参</param>
        /// <param name="astr_jysr_xml">入参数据</param>
        /// <param name="astr_pcbh"></param>
        /// <param name="astr_jylsh">交易流水号</param>
        /// <param name="astr_jyyzm">交易验证码</param>
        /// <param name="astr_jysc_xml"> 交易输出</param>
        /// <param name="along_appcode">交易标志</param>
        /// <param name="astr_appmsg">交易信息</param>
        private static void yh_interface_call(
            string astr_jybh,
            string astr_jykz_xml,
            string astr_jysr_xml,
            ref string astr_pcbh,
            ref string astr_jylsh,
            ref string astr_jyyzm,
            ref string astr_jysc_xml,
            ref int along_appcode,
            ref string astr_appmsg)

        {
           

            object[] args = new object[] {
                astr_jybh,
                astr_jykz_xml,
                astr_jysr_xml,
                astr_pcbh,
                astr_jylsh,
                astr_jyyzm,
                astr_jysc_xml,
                along_appcode,
                astr_appmsg,
             };

            ParameterModifier pm = new ParameterModifier(9);
            pm[0] = false;
            pm[1] = false;
            pm[2] = false;
            pm[3] = true;
            pm[4] = true;
            pm[5] = true;
            pm[6] = true;
            pm[7] = true;
            pm[8] = true;
            //yhObject = System.Activator.CreateInstance(yh);
            ParameterModifier[] pmd = { pm };
            if (yhObject == null) yhObject = System.Activator.CreateInstance(yh);
     
            yh.InvokeMember("yh_interface_call", BindingFlags.InvokeMethod, null,
                yhObject, args, pmd, System.Globalization.CultureInfo.CurrentCulture, null);
            object o0 = args[0].ToString();
            object o1 = args[1].ToString();
            object o2 = args[2].ToString(); 
            astr_pcbh = args[3].ToString();
            astr_jylsh = args[4].ToString();
            astr_jyyzm = args[5].ToString();// kc09k2
             astr_jysc_xml = args[6].ToString();
            along_appcode = Convert.ToInt32(args[7].ToString());
            astr_appmsg = args[8]!=null? args[8].ToString():null;

            
        }
        public static bool Init(out string msg)
        {

            int Appcode = -1;
            msg = string.Empty;
            object[] args = new object[] { Appcode, msg };
            yhObject = System.Activator.CreateInstance(yh);
            ParameterModifier pm = new ParameterModifier(2);
            pm[0] = true;
            pm[1] = true;
            ParameterModifier[] pmd = { pm };
            yh.InvokeMember("yh_interface_init", BindingFlags.InvokeMethod, null,
                yhObject, args, pmd, System.Globalization.CultureInfo.CurrentCulture, null);

            string o1 = args[0].ToString();
            string o2 = args[1].ToString();

            if (Convert.ToInt32(o1) < 0)
            {
                msg = o2;
                return false;
            }

            //测试
            //msg = "";
            return true;
        }

        private static bool yh_interface_destroy()
        {
            try
            {
                yh.InvokeMember("yh_interface_destroy", BindingFlags.InvokeMethod, null,
                         yhObject, null);
                return true;
            }
            catch (Exception ex)
            {
                return false;

            }
        }

        private static void yh_interface_confirm(string astr_jylsh, string astr_jyyzm, ref int along_appcode, ref string astr_appmsg)
        {
            if (yhObject == null) yhObject = System.Activator.CreateInstance(yh);
            object[] args = new object[] {astr_jylsh,astr_jyyzm,
                            along_appcode,astr_appmsg };

            ParameterModifier pm = new ParameterModifier(4);
            pm[0] = false;
            pm[1] = false;
            pm[2] = true;
            pm[3] = true;
            //yhObject = System.Activator.CreateInstance(yh);
            ParameterModifier[] pmd = { pm };
            yh.InvokeMember("yh_interface_confirm", BindingFlags.InvokeMethod, null,
                yhObject, args, pmd, System.Globalization.CultureInfo.CurrentCulture, null);
            object o0 = args[0].ToString();
            object o1 = args[1].ToString();

            along_appcode = Convert.ToInt32(args[2].ToString());
            astr_appmsg = args[3].ToString();


        }
        private static void yh_interface_cancel(string astr_jylsh, ref int along_appcode, ref string astr_appmsg)
        {
            if (yhObject == null) yhObject = System.Activator.CreateInstance(yh);
            object[] args = new object[] { astr_jylsh, along_appcode, astr_appmsg };

            ParameterModifier pm = new ParameterModifier(3);
            pm[0] = false;
            pm[1] = true;
            pm[2] = true;

            ParameterModifier[] pmd = { pm };
            //yhObject = System.Activator.CreateInstance(yh);
            yh.InvokeMember("yh_interface_cancel", BindingFlags.InvokeMethod, null,
                yhObject, args, pmd, System.Globalization.CultureInfo.CurrentCulture, null);
            object o0 = args[0].ToString();

            along_appcode = Convert.ToInt32(args[1].ToString());
            astr_appmsg = args[2].ToString();
        }
        private static void yh_interface_getuncertaintytrade(string astr_jybh, ref string astr_jgxml, ref int along_appcode, ref string astr_appmsg)
        {
            if (yhObject == null) yhObject = System.Activator.CreateInstance(yh);
            object[] args = new object[] { astr_jybh, astr_jgxml, along_appcode, astr_appmsg };

            ParameterModifier pm = new ParameterModifier(4);
            pm[0] = false;
            pm[1] = true;
            pm[2] = true;
            pm[3] = true;
            ParameterModifier[] pmd = { pm };
           // yhObject = System.Activator.CreateInstance(yh);
            yh.InvokeMember("yh_interface_getuncertaintytrade", BindingFlags.InvokeMethod, null,
                yhObject, args, pmd, System.Globalization.CultureInfo.CurrentCulture, null);
            object o0 = args[0].ToString();
            astr_jgxml = args[1].ToString();
            along_appcode = Convert.ToInt32(args[2].ToString());
            astr_appmsg = args[3].ToString();
        }
    }
    

}

