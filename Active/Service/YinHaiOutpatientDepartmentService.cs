using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BenDingActive.Help;
using BenDingActive.Model.Dto.Bend;
using BenDingActive.Model.Dto.YiHai;
using BenDingActive.Model.Json;
using BenDingActive.Model.Params.OutpatientDepartment;
using BenDingActive.Model.YiHai;
using Newtonsoft.Json;


namespace BenDingActive.Service
{

    public class YinHaiOutpatientDepartmentService
    {

        /// <summary>
        /// 获取个人基础资料
        /// </summary>
        /// <param name="controlParam"></param>
        /// <param name="inputParam"></param>
        /// <param name="operatorId"></param>
        /// <returns></returns>
        public ApiJsonResultData GetUserInfo(string controlParam, string inputParam, string operatorId)
        {
            var resultData = new ApiJsonResultData { Success = true };
            var data = new ResidentUserInfoJsonDto();

            string xmlStr = @"<?xml version='1.0' encoding='GBK' standalone='yes'?>
                              <output>
                    <aac001>010025489</aac001>
                    <aac002>510103196510030982</aac002>
                    <aac003>李蓉</aac003>
                    <aac004>2</aac004>
                    <aac006>1965-10-03 00:00:00</aac006>
                    <akc023>54</akc023>
                    <akc021>02</akc021>
                    <ykc117></ykc117>
                    <grzhye>
                        <row>
                            <ykc303>城乡居民基本医疗帐户</ykc303>
                            <ykc194>0.00</ykc194>
                        </row>
                    </grzhye>
                    <yab003>0003</yab003>
                    <aae013></aae013>
                    <aab001>51010600100100</aab001>
                    <aab004>金牛-荷花池辖区街道办事处-荷花社区</aab004>
                    <ydbz></ydbz>
                    <gsdataset>
                        <yke109></yke109>
                        <alc022></alc022>
                        <aka130></aka130>
                    </gsdataset>
                </output>";

            var iniParam = new DealModel()
            {
                TransactionNumber = "03",
                TransactionControlXml = XmlHelp.YinHaiXmlSerialize(new UserInfoControlXmlDto() { edition = "3" }),
                TransactionInputXml = XmlHelp.YinHaiXmlSerialize(new UserInfoDataXmlDto()),
            };
            try
            {
                Logs.LogWrite(new LogParam()
                {
                    Params = controlParam,
                    ResultData = inputParam,
                    OperatorCode = operatorId

                });
                //YinHaiCOM.CallDeal(iniParam);
                iniParam.TransactionOutputXml = xmlStr;
                iniParam.along_appcode = 1;
                if (iniParam.along_appcode < 0) throw new Exception("yiHai" + iniParam.Msg);
                if (string.IsNullOrWhiteSpace(iniParam.TransactionOutputXml)) throw new Exception("yiHai医保执行获取个人信息为空");
                var userData = XmlHelp.YiHaiDeSerializerModelJson(new GetUserInfoJsonDto(), iniParam.TransactionOutputXml);
                var userEntity = GetUserInfoEntity(userData);
                resultData.Data = JsonConvert.SerializeObject(userEntity);

                Logs.LogWriteData(new LogWriteDataParam
                {
                    JoinJson = "",
                    ReturnJson = JsonConvert.SerializeObject(iniParam),
                    OperatorId = operatorId

                });
            }
            catch (Exception e)
            {
                resultData.Success = false;
                resultData.Message = e.Message;
                Logs.LogErrorWrite(new LogParam()
                {
                    Msg = e.Message + "error:" + e.StackTrace,
                    OperatorCode = operatorId,
                    ResultData = JsonConvert.SerializeObject(iniParam)

                });

            }

            return resultData;

        }
        public GetUserInfoDto GetUserInfoEntity(GetUserInfoJsonDto param)
        {
            decimal accountBalance = 0;
            string insuranceType = null;

            if (param.AccountInfo != null)
            {
                accountBalance = param.AccountInfo.Row.AccountBalance;
                if (!string.IsNullOrWhiteSpace(param.AccountInfo.Row.AccountType))
                {
                    insuranceType = param.AccountInfo.Row.AccountType.IndexOf("职工") < 0 ? "342" : "310";
                }
            }
            //医保标识
            string medicalInsuranceSign = null;
            if (!string.IsNullOrWhiteSpace(param.MedicalInsuranceSign))
            {
                if (param.MedicalInsuranceSign == "1") medicalInsuranceSign = "本地";
                if (param.MedicalInsuranceSign == "2") medicalInsuranceSign = "省内异地";
                if (param.MedicalInsuranceSign == "3") medicalInsuranceSign = "省外异地";
            }
            var resulData = new GetUserInfoDto()
            {
                Age = param.Age,
                Birthday = param.Birthday,
                IdCardNo = param.IdCardNo,
                PatientName = param.PatientName,
                PatientSex = param.PatientSex,
                PersonalCoding = param.PersonalCoding,
                AccountBalance = accountBalance,
                InsuranceType = insuranceType,
                MedicalInsuranceSign = medicalInsuranceSign,
                InsuranceName = param.AccountInfo?.Row.AccountType
            };

            return resulData;
        }
        /// <summary>
        /// 获取签到人员id
        /// </summary>
        public ApiJsonResultData GetSignInUserId(string controlParam, string inputParam, string operatorId)
        {
            var resultData = new ApiJsonResultData();
            var userId = YinHaiCOM.GetSignInUserId();
            //为空时
            if (string.IsNullOrWhiteSpace(userId)) resultData.Success = false;
            resultData.Data = userId;

            return resultData;
        }
        /// <summary>
        /// 医保签到
        /// </summary>
        /// <param name="controlParam"></param>
        /// <param name="inputParam"></param>
        /// <param name="operatorId"></param>
        /// <returns></returns>
        public ApiJsonResultData MedicalInsuranceSignIn(string controlParam, string inputParam, string operatorId)
        {
          
            //var resultXmlData = new MedicalInsuranceSignInXmlDto();
            //var xmlRowList = new List<MedicalInsuranceSignInXmlRowDto>
            //{
            //    new MedicalInsuranceSignInXmlRowDto()
            //    {
            //        BatchNo = DateTime.Now.ToString("yyyyMMddHHmmss"),
            //        SignInState = 1,
            //        SignInTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"),
            //        MedicalInsuranceOrganization = "007"
            //    }
            //};
            //resultXmlData.Row = xmlRowList;


            var iniParam = new YiHaiMedicalInsuranceOperationParam
            {
                //TransactionOutputXml = XmlHelp.YinHaiXmlSerialize(resultXmlData),
                TransactionNumber = "05",
                ControlParam = controlParam,
                OperatorId = operatorId,
                InputParam = inputParam
            };
            string msg;
            var initData= YinHaiCOM.Init(out msg);
            if (initData == false)throw new  Exception("初始化失败:"+ msg);
           var  resultData = YiHaiMedicalInsuranceOperation(iniParam);
            YinHaiCOM.SetSignInUserId(operatorId);
            return resultData;

        }
        /// <summary>
        /// 取消医保签到
        /// </summary>
        /// <param name="controlParam"></param>
        /// <param name="inputParam"></param>
        /// <param name="operatorId"></param>
        /// <returns></returns>
        public ApiJsonResultData CancelMedicalInsuranceSignIn(string controlParam, string inputParam, string operatorId)
        {

            var iniParam = new YiHaiMedicalInsuranceOperationParam
            {
                TransactionOutputXml = XmlHelp.YinHaiXmlSerialize(new OutputXmlBaseDto()),
                TransactionNumber = "06",
                ControlParam = controlParam,
                OperatorId = operatorId,
                InputParam = inputParam,
            };
            var resultData = YiHaiMedicalInsuranceOperation(iniParam);
            return resultData;
        }
        /// <summary>
        /// 医院信息上传
        /// </summary>
        /// <param name="controlParam"></param>
        /// <param name="inputParam"></param>
        /// <param name="operatorId"></param>
        /// <returns></returns>
        public ApiJsonResultData HospitalInfoUpload(string controlParam, string inputParam, string operatorId)
        {

            var iniParam = new YiHaiMedicalInsuranceOperationParam
            {

                TransactionNumber = "100",
                ControlParam = controlParam,
                OperatorId = operatorId,
                InputParam = inputParam,
            };
            var resultData = YiHaiMedicalInsuranceOperation(iniParam);
            return resultData;
        }
        /// <summary>
        ///查询医院信息
        /// </summary>
        /// <param name="controlParam"></param>
        /// <param name="inputParam"></param>
        /// <param name="operatorId"></param>
        /// <returns></returns>
        public ApiJsonResultData QueryHospitalInfo(string controlParam, string inputParam, string operatorId)
        {

            var iniParam = new YiHaiMedicalInsuranceOperationParam
            {

                TransactionNumber = "102",
                ControlParam = controlParam,
                OperatorId = operatorId,
                InputParam = inputParam,
            };
            var resultData = YiHaiMedicalInsuranceOperation(iniParam);
            return resultData;
        }
        /// <summary>
        ///查询icd10信息
        /// </summary>
        /// <param name="controlParam"></param>
        /// <param name="inputParam"></param>
        /// <param name="operatorId"></param>
        /// <returns></returns>
        public ApiJsonResultData QueryIcd10(string controlParam, string inputParam, string operatorId)
        {

            var iniParam = new YiHaiMedicalInsuranceOperationParam
            {

                TransactionNumber = "92",
                ControlParam = controlParam,
                OperatorId = operatorId,
                InputParam = inputParam,
            };
            var resultData = YiHaiMedicalInsuranceOperation(iniParam);
            return resultData;
        }
        /// <summary>
        ///查询医院信息
        /// </summary>
        /// <param name="controlParam"></param>
        /// <param name="inputParam"></param>
        /// <param name="operatorId"></param>
        /// <returns></returns>
        public ApiJsonResultData QueryDataCode(string controlParam, string inputParam, string operatorId)
        {

            var iniParam = new YiHaiMedicalInsuranceOperationParam
            {

                TransactionNumber = "93",
                ControlParam = controlParam,
                OperatorId = operatorId,
                InputParam = inputParam,
            };
            var resultData = YiHaiMedicalInsuranceOperation(iniParam);
            return resultData;
        }
        /// <summary>
        /// 门诊挂号
        /// </summary>
        /// <param name="controlParam"></param>
        /// <param name="inputParam"></param>
        /// <param name="operatorId"></param>
        /// <returns></returns>
        public ApiJsonResultData OutpatientRegister(string controlParam, string inputParam, string operatorId)
        {



            var iniParam = new YiHaiMedicalInsuranceOperationParam
            {

                TransactionNumber = "110",
                ControlParam = controlParam,
                OperatorId = operatorId,
                InputParam = inputParam,
            };




            var resultData = YiHaiMedicalInsuranceOperation(iniParam);
            return resultData;
        }
        /// <summary>
        /// 门诊费用明细上传
        /// </summary>
        /// <param name="controlParam"></param>
        /// <param name="inputParam"></param>
        /// <param name="operatorId"></param>
        /// <returns></returns>
        public ApiJsonResultData OutpatientDetailUpload(string controlParam, string inputParam, string operatorId)
        {

            var iniParam = new YiHaiMedicalInsuranceOperationParam
            {

                TransactionNumber = "111",
                ControlParam = controlParam,
                OperatorId = operatorId,
                InputParam = inputParam,
            };
            var resultData = YiHaiMedicalInsuranceOperation(iniParam);
            return resultData;
        }
        /// <summary>
        /// 门诊结算
        /// </summary>
        /// <param name="controlParam"></param>
        /// <param name="inputParam"></param>
        /// <param name="operatorId"></param>
        /// <returns></returns>
        public ApiJsonResultData OutpatientSettlement(string controlParam, string inputParam, string operatorId)
        {

            var iniParam = new YiHaiMedicalInsuranceOperationParam
            {

                TransactionNumber = "11",
                ControlParam = controlParam,
                OperatorId = operatorId,
                InputParam = inputParam,
            };
            var resultData = YiHaiMedicalInsuranceOperation(iniParam);
            return resultData;
        }
        /// <summary>
        /// 门诊结算打印
        /// </summary>
        /// <param name="controlParam"></param>
        /// <param name="inputParam"></param>
        /// <param name="operatorId"></param>
        /// <returns></returns>
        public ApiJsonResultData OutpatientSettlementPrint(string controlParam, string inputParam, string operatorId)
        {

            var iniParam = new YiHaiMedicalInsuranceOperationParam
            {

                TransactionNumber = "55",
                ControlParam = controlParam,
                OperatorId = operatorId,
                InputParam = inputParam,
            };
            var resultData = YiHaiMedicalInsuranceOperation(iniParam);
            return resultData;
        }
        /// <summary>
        /// 门诊取消结算
        /// </summary>
        /// <param name="controlParam"></param>
        /// <param name="inputParam"></param>
        /// <param name="operatorId"></param>
        /// <returns></returns>
        public ApiJsonResultData CancelOutpatientSettlement(string controlParam, string inputParam, string operatorId)
        {

            var iniParam = new YiHaiMedicalInsuranceOperationParam
            {

                TransactionNumber = "12",
                ControlParam = controlParam,
                OperatorId = operatorId,
                InputParam = inputParam,
            };
            var resultData = YiHaiMedicalInsuranceOperation(iniParam);
            return resultData;
        }
        /// <summary>
        /// 查询不确定交易
        /// </summary>
        /// <param name="controlParam"></param>
        /// <param name="inputParam"></param>
        /// <param name="operatorId"></param>
        /// <returns></returns>
        public ApiJsonResultData Getuncertaintytrade(string controlParam, string inputParam, string operatorId)
        {
            var resultData = new ApiJsonResultData { Success = true };
            var param = new YiHaiMedicalInsuranceOperationParam
            {


                ControlParam = controlParam,
                OperatorId = operatorId,
                InputParam = inputParam,
            };

            var iniParam = new DealModel()
            {
                TransactionNumber = param.ControlParam,
            };
            try
            {

                Logs.LogWrite(new LogParam()
                {
                    Params = param.ControlParam,
                    ResultData = param.InputParam,
                    OperatorCode = param.OperatorId
                });

                if (!string.IsNullOrWhiteSpace(param.TransactionOutputXml))
                {
                    iniParam.TransactionOutputXml = param.TransactionOutputXml;
                    iniParam.along_appcode = 1;
                }
                else
                {

                    //YinHaiCOM.Getuncertaintytrade(iniParam);
                    //测试数据
                    iniParam.along_appcode = 1;
                    var outputData = new QueryUncertainTransactionOutputXmlDto();
                    var listRow = new List<QueryUncertainTransactionOutputRowXmlDto>();
                    listRow.Add(new QueryUncertainTransactionOutputRowXmlDto()
                    { SerialNumber = "12C0000SJ37F6E2F8",
                        Key = new List<QueryUncertainTransactionOutputRowKeyXmlDto>()
                        {
                            new QueryUncertainTransactionOutputRowKeyXmlDto()
                            { SettlementNo = "0003S293400370",
                              VisitNo = "00002005289161163",
                                ReimbursementType = "门诊结算"
                            },new QueryUncertainTransactionOutputRowKeyXmlDto()
                            {
                                SettlementNo = "0003S293400370",
                                VisitNo = "00002005289161163",
                                ReimbursementType = "门诊结算"
                            }
                        }
                    });
                    outputData.Row = listRow;
                    iniParam.TransactionOutputXml = XmlHelp.YinHaiXmlSerialize(outputData);
                    //----

                    if (iniParam.along_appcode < 0) throw new Exception("yinHaiMsg" + iniParam.Msg);
                }
               

                resultData.Data = JsonConvert.SerializeObject(iniParam);

                Logs.LogWriteData(new LogWriteDataParam
                {
                    JoinJson = "",
                    ReturnJson = resultData.Data.ToString(),
                    OperatorId = param.OperatorId

                });
            }
            catch (Exception e)
            {
                resultData.Success = false;
                resultData.Message = e.Message;
                Logs.LogErrorWrite(new LogParam()
                {
                    Msg = e.Message + "error:" + e.StackTrace,
                    OperatorCode = param.OperatorId,
                    ResultData = JsonConvert.SerializeObject(iniParam)

                });

            }

            return resultData;

        }
        /// <summary>
        /// 取消交易
        /// </summary>
        /// <param name="controlParam"></param>
        /// <param name="inputParam"></param>
        /// <param name="operatorId"></param>
        /// <returns></returns>
        public ApiJsonResultData CancelDeal(string controlParam, string inputParam, string operatorId)
        {
            var resultData = new ApiJsonResultData { Success = true };
            var param = new YiHaiMedicalInsuranceOperationParam
            {

                TransactionNumber = inputParam,

                OperatorId = operatorId,

            };

            var iniParam = new DealModel()
            {
                SerialNumber = inputParam,
                TransactionInputXml = param.InputParam,

            };
            try
            {

                Logs.LogWrite(new LogParam()
                {
                    Params = param.ControlParam,
                    ResultData = param.InputParam,
                    OperatorCode = param.OperatorId
                });

                if (!string.IsNullOrWhiteSpace(param.TransactionOutputXml))
                {
                    iniParam.TransactionOutputXml = param.TransactionOutputXml;
                    iniParam.along_appcode = 1;
                }
                else
                {



                    YinHaiCOM.CancelDeal(iniParam);
                    if (iniParam.along_appcode < 0) throw new Exception("yinHaiMsg" + iniParam.Msg);
                }
                resultData.Data = JsonConvert.SerializeObject(iniParam);

                Logs.LogWriteData(new LogWriteDataParam
                {
                    JoinJson = "",
                    ReturnJson = resultData.Data.ToString(),
                    OperatorId = param.OperatorId

                });
            }
            catch (Exception e)
            {
                resultData.Success = false;
                resultData.Message = e.Message;
                Logs.LogErrorWrite(new LogParam()
                {
                    Msg = e.Message + "error:" + e.StackTrace,
                    OperatorCode = param.OperatorId,
                    ResultData = JsonConvert.SerializeObject(iniParam)

                });

            }

            return resultData;

        }
        /// <summary>
        /// 确认交易
        /// </summary>
        /// <param name="controlParam"></param>
        /// <param name="inputParam"></param>
        /// <param name="operatorId"></param>
        /// <returns></returns>
        public ApiJsonResultData ConfirmDeal(string controlParam, string inputParam, string operatorId)
        {
            var resultData = new ApiJsonResultData { Success = true };
            var param = new YiHaiMedicalInsuranceOperationParam
            {


                ControlParam = controlParam,
                OperatorId = operatorId,
                InputParam = inputParam,
            };

            var iniParam = new DealModel()
            {
                SerialNumber = controlParam,
                VerificationCode = inputParam,


            };
            try
            {

                Logs.LogWrite(new LogParam()
                {
                    Params = param.ControlParam,
                    ResultData = param.InputParam,
                    OperatorCode = param.OperatorId
                });

                if (!string.IsNullOrWhiteSpace(param.TransactionOutputXml))
                {
                    iniParam.TransactionOutputXml = param.TransactionOutputXml;
                    iniParam.along_appcode = 1;
                }
                else
                {



                    //YinHaiCOM.ConfirmDeal(iniParam);

                    //测试
                    iniParam.along_appcode = 1;
                    if (iniParam.along_appcode < 0) throw new Exception("yinHaiMsg" + iniParam.Msg);
                }
                resultData.Data = JsonConvert.SerializeObject(iniParam);

                Logs.LogWriteData(new LogWriteDataParam
                {
                    JoinJson = "",
                    ReturnJson = resultData.Data.ToString(),
                    OperatorId = param.OperatorId

                });
            }
            catch (Exception e)
            {
                resultData.Success = false;
                resultData.Message = e.Message;
                Logs.LogErrorWrite(new LogParam()
                {
                    Msg = e.Message + "error:" + e.StackTrace,
                    OperatorCode = param.OperatorId,
                    ResultData = JsonConvert.SerializeObject(iniParam)

                });

            }

            return resultData;

        }

        /// <summary>
        /// 获取服务项目
        /// </summary>
        /// <param name="controlParam"></param>
        /// <param name="inputParam"></param>
        /// <param name="operatorId"></param>
        /// <returns></returns>
        public ApiJsonResultData GetServiceCatalog(string controlParam, string inputParam, string operatorId)
        {

            var iniParam = new YiHaiMedicalInsuranceOperationParam
            {

                TransactionNumber = "91",
                ControlParam = controlParam,
                OperatorId = operatorId,
                InputParam = inputParam,
            };
            var resultData = YiHaiMedicalInsuranceOperation(iniParam);
            return resultData;
        }
        /// <summary>
        /// 银海医保执行
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        private ApiJsonResultData YiHaiMedicalInsuranceOperation(YiHaiMedicalInsuranceOperationParam param)
        {
            var resultData = new ApiJsonResultData { Success = true };
            var iniParam = new DealModel()
            {
                TransactionNumber = param.TransactionNumber,
                TransactionControlXml = param.ControlParam,
                TransactionInputXml = param.InputParam,

            };
            try
            {

                Logs.LogWrite(new LogParam()
                {
                    Params = param.ControlParam,
                    ResultData = param.InputParam,
                    OperatorCode = param.OperatorId
                });

                if (!string.IsNullOrWhiteSpace(param.TransactionOutputXml))
                {
                    iniParam.TransactionOutputXml = param.TransactionOutputXml;
                    iniParam.along_appcode = 1;
                }
                else
                {
                    //YinHaiCOM.CallDeal(iniParam);
                    //测试执行
                    iniParam = GetDealModelTest(param);
                    if (iniParam.along_appcode < 0) throw new Exception("yinHaiMsg" + iniParam.Msg);
                }

                resultData.OtherInfo = iniParam.SerialNumber;
                resultData.Data = JsonConvert.SerializeObject(iniParam);

                Logs.LogWriteData(new LogWriteDataParam
                {
                    JoinJson = "",
                    ReturnJson = resultData.Data.ToString(),
                    OperatorId = param.OperatorId

                });
            }
            catch (Exception e)
            {
                resultData.Success = false;
                resultData.Message = e.Message;
                Logs.LogErrorWrite(new LogParam()
                {
                    Msg = e.Message + "error:" + e.StackTrace,
                    OperatorCode = param.OperatorId,
                    ResultData = JsonConvert.SerializeObject(iniParam)

                });

            }

            return resultData;
        }

        #region Test
        /// <summary>
        /// 获取测试数据
        /// </summary>
        /// <returns></returns>
        private DealModel GetDealModelTest(YiHaiMedicalInsuranceOperationParam param)
        {

            var resultData = new DealModel()
            {
                TransactionNumber = param.TransactionNumber,
                TransactionControlXml = param.ControlParam,
                TransactionInputXml = param.InputParam,
                along_appcode = 1
            };
            string xmlStr = null;
            xmlStr = "<?xml version=\"1.0\" encoding=\"GBK\" standalone=\"yes\"?>";
            //挂号
            if (param.TransactionNumber == "110")
            {
                xmlStr += @"
                      <output>
                            <yac112>3</yac112>
                            <akc190>00032005299161202</akc190>
                            <aka130>0203</aka130>
                            <aac001>010025489</aac001>
                            <aac003>李蓉</aac003>
                            <aac004>2</aac004>
                            <aac006>1965-10-03 00:00:00</aac006>
                            <aae013></aae013>
                            <akb020>098041</akb020>
                            <aae011>李茜</aae011>
                            <aae036>2020-05-29 17:27:48</aae036>
                            <yka103>00032005296415696</yka103>
                            <yka055>3.00</yka055>
                            <yka056>3.00</yka056>
                            <yka111>0.00</yka111>
                            <yka057>0.00</yka057>
                            <grzhye>
                                <row>
                                    <ykc303>城乡居民基本医疗帐户</ykc303>
                                    <ykc194>0.00</ykc194>
                                </row>
                            </grzhye>
                            <yka065>0.00</yka065>
                            <yka107>0.00</yka107>
                            <ykd007>01</ykd007>
                            <ykh012>3.00</ykh012>
                            <yab003>0003</yab003>
                            <dataset>
                                <row>
                                    <yka316>68</yka316>
                                    <yab139>0003</yab139>
                                    <aka213>0101</aka213>
                                    <yka115>0.00</yka115>
                                    <yka058>0.00</yka058>
                                    <ykc125>0.0000</ykc125>
                                    <yka107>0.00</yka107>
                                    <yka065>0.00</yka065>
                                    <ykc121>0101</ykc121>
                                    <ykb037>0008</ykb037>
                                    <yka054>01</yka054>
                                </row>
                            </dataset>
                            <ykc008_c>不享受</ykc008_c>
                            <yke484>3</yke484>
                            <fymxdataset>
                                <row>
                                    <yka105>5055095653710533604</yka105>
                                    <yka299>1.00</yka299>
                                    <yka096>1.0000</yka096>
                                    <yka056>3.0000</yka056>
                                    <yka057>0.0000</yka057>
                                    <yka111>0.0000</yka111>
                                    <yke011>0</yke011>
                                    <yka095>挂号费</yka095>
                                    <akc226>1.0000</akc226>
                                    <akc225>3.0000</akc225>
                                    <yka055>3.0000</yka055>
                                </row>
                            </fymxdataset>
                        </output>";
                resultData.TransactionOutputXml = xmlStr;
                resultData.BatchNo = "0003S293400370";
                resultData.SerialNumber = "110C0003SJ37F6E43E";
                resultData.VerificationCode = "213323699";

            }

            //上传费用
            if (param.TransactionNumber == "111")
            {
                xmlStr += @"
                        <output>
                            <fymxdataset>
                                <row>
                                    <yka105>5664372604401824683</yka105>
                                    <yka299>999999999.00</yka299>
                                    <yka096>0.0000</yka096>
                                    <yka056>0.0000</yka056>
                                    <yka057>0.0000</yka057>
                                    <yka111>3.0000</yka111>
                                    <yke011>0</yke011>
                                    <yke474></yke474>
                                    <yke492></yke492>
                                    <yke493>3</yke493>
                                    <yke494>
                                        <![CDATA[ 违反【诊断库与科室关联】]]>
                                    </yke494>
                                    <yka095>阿莫西林胶囊</yka095>
                                    <akc226>1.0000</akc226>
                                    <akc225>3.0000</akc225>
                                    <yka055>3.0000</yka055>
                                </row>
                            </fymxdataset>
                        </output>";
                resultData.TransactionOutputXml = xmlStr;

            }
            //结算
            if (param.TransactionNumber == "11")
            {
                xmlStr += @"
                        <output>
                  <yac112>1</yac112> 
                  <akc190>00002005289161163</akc190> 
                  <aka130>0201</aka130> 
                  <aac001>010000502</aac001> 
                  <akb020>098041</akb020> 
                  <aae011>李茜</aae011> 
                  <aae036>2020-05-28 18:19:42</aae036> 
                  <yka103>00002005286415621</yka103> 
                  <yka055>2.50</yka055> 
                  <yka056>0.00</yka056> 
                  <yka111>2.25</yka111> 
                  <yka057>0.25</yka057> 
                  <yka065>0.00</yka065> 
                  <yka107>0.00</yka107> 
                  <ykd007>01</ykd007> 
                  <ykh012>2.50</ykh012> 
                  <yab003>0000</yab003> 
                <dataset>
                <row>
                  <yka316>21</yka316> 
                  <yab139>0000</yab139> 
                  <aka213>0101</aka213> 
                  <yka115>0.00</yka115> 
                  <yka058>0.00</yka058> 
                  <ykc125>0.0000</ykc125> 
                  <yka107>0.00</yka107> 
                  <yka065>0.00</yka065> 
                  <ykc121>0101</ykc121> 
                  <ykb037>0008</ykb037> 
                  <yka054>01</yka054> 
                  </row>
                  </dataset>
                 <fymxdataset>
                 <row>
                  <yka105>5751238559876800263</yka105> 
                  <yka299>999999999.00</yka299> 
                  <yka096>0.1000</yka096> 
                  <yka056>0.0000</yka056> 
                  <yka057>0.2500</yka057> 
                  <yka111>2.2500</yka111> 
                  <yke011>0</yke011> 
                  </row>
                  </fymxdataset>
                 <grzhye>
                 <row>
                  <ykc303>城镇职工基本医疗帐户</ykc303> 
                  <ykc194>0.00</ykc194> 
                  </row>
                  </grzhye>
                  </output>";
                resultData.TransactionOutputXml = xmlStr;
                resultData.BatchNo = "0000S293400211";
                resultData.SerialNumber = "11C0000SJ37F6E2F2";
                resultData.VerificationCode = "206541290";

            }

            //取消结算
            if (param.TransactionNumber == "12")
            {
                xmlStr += @"
                        <output>
                  <yac112>1</yac112> 
                  <akc190>00002005289161163</akc190> 
                  <aka130>0201</aka130> 
                  <aac001>010000502</aac001> 
                  <akb020>098041</akb020> 
                  <aae011>李茜</aae011> 
                  <aae036>2020-05-28 18:19:42</aae036> 
                  <yka103>00002005286415621</yka103> 
                  <yka055>2.50</yka055> 
                  <yka056>0.00</yka056> 
                  <yka111>2.25</yka111> 
                  <yka057>0.25</yka057> 
                  <yka065>0.00</yka065> 
                  <yka107>0.00</yka107> 
                  <ykd007>01</ykd007> 
                  <ykh012>2.50</ykh012> 
                  <yab003>0000</yab003> 
                <dataset>
                <row>
                  <yka316>21</yka316> 
                  <yab139>0000</yab139> 
                  <aka213>0101</aka213> 
                  <yka115>0.00</yka115> 
                  <yka058>0.00</yka058> 
                  <ykc125>0.0000</ykc125> 
                  <yka107>0.00</yka107> 
                  <yka065>0.00</yka065> 
                  <ykc121>0101</ykc121> 
                  <ykb037>0008</ykb037> 
                  <yka054>01</yka054> 
                  </row>
                  </dataset>
                 <fymxdataset>
                 <row>
                  <yka105>5751238559876800263</yka105> 
                  <yka299>999999999.00</yka299> 
                  <yka096>0.1000</yka096> 
                  <yka056>0.0000</yka056> 
                  <yka057>0.2500</yka057> 
                  <yka111>2.2500</yka111> 
                  <yke011>0</yke011> 
                  </row>
                  </fymxdataset>
                 <grzhye>
                 <row>
                  <ykc303>城镇职工基本医疗帐户</ykc303> 
                  <ykc194>0.00</ykc194> 
                  </row>
                  </grzhye>
                  </output>";
                resultData.TransactionOutputXml = xmlStr;
                resultData.BatchNo = "0000S293400215";
                resultData.SerialNumber = "12C0000SJ37F6E2F8";
                resultData.VerificationCode = "497473752";

            }

            if (param.TransactionNumber == "55")
            {
                xmlStr += @"<output></output>";
                resultData.TransactionOutputXml = xmlStr;
            }
            if (param.TransactionNumber == "05")
            {
                xmlStr += @"<output><row><yab003>0022</yab003><yke190>1</yke190><yke189>0022S293400084</yke189><yke191>2020-05-27 17:38:21</yke191><aae013></aae013> </row></output>";
                resultData.TransactionOutputXml = xmlStr;
            }

            return resultData;
        }

        #endregion
    }
}
