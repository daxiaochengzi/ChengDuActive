using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using BenDingActive.Help;
using BenDingActive.Model;
using BenDingActive.Model.BendParam;
using BenDingActive.Model.Params.OutpatientDepartment;
using BenDingActive.Service;
using Newtonsoft.Json;


namespace BenDingActive
{
    [Guid("67475F7D-57A1-45AD-96F3-428A679B2E6C")]
    public class MacActiveX : ActiveXControl
    {

        ///// <summary>
        //  /// 门诊方法集合
        //  /// </summary>
        //  /// <param name="param"></param>
        //  /// <param name="baseParam"></param>
        //  /// <param name="methodName"></param>
        //  /// <returns></returns>
        //public string OutpatientMethods(string param, string baseParam, string methodName)
        //{
        //    //反射获取 命名空间 + 类名
        //    string className = "BenDingActive.Service.OutpatientDepartmentService";
        //    var resultData=  MedicalInsuranceExecute(param, baseParam, methodName, className);
        //    return resultData;
        //}
        ///// <summary>
        ///// 住院方法集合
        ///// </summary>
        ///// <param name="param"></param>
        ///// <param name="baseParam"></param>
        ///// <param name="methodName"></param>
        ///// <returns></returns>
        //public string HospitalizationMethods(string param, string baseParam, string methodName)
        //{
        //    //反射获取 命名空间 + 类名
        //    string className = "BenDingActive.Service.HospitalizationService";
        //    var resultData = MedicalInsuranceExecute(param, baseParam, methodName, className);
        //    return resultData;
        //}
        /// <summary>
        /// 银海医保方法集合
        /// </summary>
        /// <param name="param"></param>
        
        /// <returns></returns>
        public string YinHaiMethods(string param)
        {
            var resultData=new ApiJsonResultData();
            var  iniParam=  JsonConvert.DeserializeObject<GetYinHaiBaseParam>(param);
            var yinHaiService = new YinHaiService();
            if (iniParam != null)
            {
                switch (iniParam.SerialNumber)
                {
                    case "ConfirmDeal":
                        resultData = yinHaiService.ConfirmDeal(iniParam.SerialNumber, iniParam.VerificationCode,
                            iniParam.UserId);
                        break;
                    case "CancelDeal":
                        resultData = yinHaiService.CancelDeal(iniParam.SerialNumber, iniParam.VerificationCode,
                            iniParam.UserId);
                        break;
                    case "Getuncertaintytrade":
                        resultData = yinHaiService.CancelDeal(iniParam.TransactionControlXml, iniParam.TransactionInputXml,
                            iniParam.UserId);
                        break;
                    case "03":
                        resultData = yinHaiService.GetUserInfo(iniParam.TransactionControlXml, iniParam.TransactionInputXml,
                            iniParam.UserId);
                        break;
                    default:
                         resultData = yinHaiService.YiHaiMedicalInsuranceOperation(new YiHaiMedicalInsuranceOperationParam
                         {
                             ControlParam =iniParam.TransactionControlXml,
                             InputParam = iniParam.TransactionInputXml,
                             OperatorId = iniParam.UserId,
                             TransactionNumber = iniParam.TransactionNumber
                         });
                        break;

                }
            }

            ////反射获取 命名空间 + 类名
            //string className = "BenDingActive.Service.YinHaiService";
            //var resultData = YinHaiMedicalInsuranceExecute(controlParam, inputParam, methodName, operatorId, className);
            return JsonConvert.SerializeObject(resultData);
        }
        /// <summary>
        /// 启动Udp服务端
        /// </summary>
        private void StartUdpServer(string operatorId)
        {
            var is64Bit = Environment.Is64BitOperatingSystem;
            string path = is64Bit ? @"C:\Program Files (x86)\Microsoft\本鼎医保插件\BenDingUdpServer.exe" : @"C:\Program Files\Microsoft\BenDingActiveSetup\BenDingUdpServer.exe";
            if (System.Diagnostics.Process.GetProcessesByName("bendingudpserver").ToList().Count > 0)
            {
                //存在
            }
            else
            {
                try
                {
                    string strExePath = path; //带有EXE名字的完整路径；
                    ProcessStartInfo procInfo = new ProcessStartInfo(strExePath);
                    // 隐藏EXE运行的窗口
                    procInfo.WindowStyle = ProcessWindowStyle.Hidden;
                    // exe运行
                    Process procBatch = Process.Start(procInfo);
                    System.Threading.Thread.Sleep(2000);  //2秒
                    // 取得EXE运行后的返回值，返回值只能是整型 
                }
                catch (Exception e)
                {
                       Logs.LogErrorWrite(
                        new LogParam()
                        {
                            Msg = e.Message,
                            OperatorCode = operatorId
                        }
                    );
                }
            }
        }
        /// <summary>
        /// 医保执行
        /// </summary>
        /// <param name="param"></param>
        /// <param name="baseParam"></param>
        /// <param name="methodName"></param>
        /// <param name="operatorId"></param>
        /// <param name="namespaces"></param>
        /// <returns></returns>
        private string YinHaiMedicalInsuranceExecute(string param, string baseParam, string methodName, string operatorId, string namespaces)
        {
            string resultData = null;
            try
            {
                //反射获取 命名空间 + 类名
                string className = namespaces;
                //传递参数
                Object[] paras = new Object[] { param, baseParam, operatorId };
                Type t = Type.GetType(className);
                object obj = Activator.CreateInstance(t);
                //直接调用
                MethodInfo method = t.GetMethod(methodName);
                if (method != null)
                {

                    var data = method.Invoke(obj, paras);
                    resultData = JsonConvert.SerializeObject(data);
                }
                else
                {
                    resultData = JsonConvert.SerializeObject(new ApiJsonResultData
                    {
                        Success = false,
                        Message = "当前插件方法不存在!!!"
                    });
                }

            }
            catch (Exception e)
            {
                resultData = JsonConvert.SerializeObject(new ApiJsonResultData
                {
                    Success = false,
                    Message = e.Message.ToString()
                });
                Logs.LogWrite(new LogParam()
                {
                    Params = param,
                    ResultData = methodName,
                    Msg = e.Message.ToString()
                });
            }
            return resultData;
        }
        ///// <summary>
        ///// 医保执行
        ///// </summary>
        ///// <param name="param"></param>
        ///// <param name="baseParam"></param>
        ///// <param name="methodName"></param>
        ///// <param name="namespaces"></param>
        ///// <returns></returns>
        //private string MedicalInsuranceExecute(string param, string baseParam, string methodName,string namespaces)
        //{
        //    string resultData = null;
        //    try
        //    {
        //        //反射获取 命名空间 + 类名
        //        string className = namespaces;
        //        //传递参数
        //        Object[] paras = new Object[] { param, JsonConvert.DeserializeObject<HisBaseParam>(baseParam) };
        //        Type t = Type.GetType(className);
        //        object obj = Activator.CreateInstance(t);
        //        //直接调用
        //        MethodInfo method = t.GetMethod(methodName);
        //        if (method != null)
        //        {
        //            var data = method.Invoke(obj, paras);
        //            resultData = JsonConvert.SerializeObject(data);
        //            //释放内存
        //            GC.Collect();
        //            GC.WaitForPendingFinalizers();
        //        }
        //        else
        //        {
        //            resultData = JsonConvert.SerializeObject(new ApiJsonResultDataActive
        //            {
        //                Success = false,
        //                Message = "当前插件方法不存在!!!"
        //            });
        //        }

        //    }
        //    catch (Exception e)
        //    {
        //        resultData = JsonConvert.SerializeObject(new ApiJsonResultDataActive
        //        {
        //            Success = false,
        //            Message = e.Message.ToString()
        //        });
        //        LogsActive.LogWrite(new LogParamActive()
        //        {
        //            Params = param,
        //            ResultData = methodName,
        //            Msg = e.Message.ToString()
        //        });
        //    }
        //    return resultData;
        //}

        /// <summary>
        /// 获取版本号
        /// </summary>
        /// <returns></returns>
        public int GetVersionNumber()
        { //生成数据文件夹
            XmlHelp.CheckFolders();
            return 100;
        }
    }
}
