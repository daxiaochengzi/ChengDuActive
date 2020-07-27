
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Newtonsoft.Json;
using System.Diagnostics;
using BenDingActive;
using BenDingActive.Help;
using BenDingActive.Model.BendParam;
using BenDingActive.Model.Json;
using BenDingActive.Model.Params;
using BenDingActive.Model.YiHai;
using BenDingActive.Service;
using BenDingActive.Test;


namespace BenDingForm
{
    public partial class Form1 : Form
    {
        YinHaiService yinHaiService = new YinHaiService();
        OutpatientDepartmentService _residentd = new OutpatientDepartmentService();
        public string UserId = "E075AC49FCE443778F897CF839F3B924";
        public string medicalInsuranceOrganization = "0003";

        public string DetailId = CommonHelp.GuidToStr(Guid.NewGuid().ToString());
        public string DetailTwo = CommonHelp.GuidToStr(Guid.NewGuid().ToString());


        //public string DetailId = CommonHelp.GuidToStr("E74B3C11F23A4C4F90F2528A22E5BE29");
        //public string DetailTwo = CommonHelp.GuidToStr("60D333ABE4DF4E9BB048C8F1F5C608C5");

        //HisBaseParam _hisBase=new HisBaseParam()
        //{
        //    YbOrgCode = "99999",
        //    EmpID = "E075AC49FCE443778F897CF839F3B924",
        //    OrgID = "51072600000000000000000513435964",
        //    BID = "6721F4DA50B349AF9F5F387707C1647A",
        //    BsCode = "23",
        //    TransKey = "6721F4DA50B349AF9F5F387707C1647A"
        //};
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //居民保险
            //string baseParam = JsonConvert.SerializeObject(new HisBaseParam()
            //{
            //    YbOrgCode = "99999",
            //    EmpID = "E075AC49FCE443778F897CF839F3B924",
            //    OrgID = "51072600000000000000000513435964",
            //    BID= "6721F4DA50B349AF9F5F387707C1647A",
            //    BsCode = "23",
            //    TransKey = "6721F4DA50B349AF9F5F387707C1647A"
            //});
            var paramEntity = new UserInfoParam();
            paramEntity.PI_CRBZ = "1";
            paramEntity.PI_SFBZ = "513701199002124815";

            //var data = _residentd.GetUserInfo(JsonConvert.SerializeObject(paramEntity), JsonConvert.DeserializeObject<HisBaseParam>(baseParam));
            //textBox1.Text = data;
        }



        private void button6_Click(object sender, EventArgs e)
        {
            //string ddd;
            //var serviceData = new MacActiveX();
            //var ccc = serviceData.YiHaiOutpatientMethods("123", "123", "MedicalInsuranceSignIn", "123");

            //YinHaiCOM.RegYinHaiDll( out ddd);
            //Logs.LogWriteData(new LogWriteDataParam()
            //{
            //    JoinJson = "45345345",
            //    ReturnJson = "444"
            //});
            //var paramEntity = new UserInfoParam();
            //paramEntity.PI_CRBZ = "1";
            //paramEntity.PI_SFBZ = "513701199002124815";

            //var paramEntity = "{\"PI_SFBZ\":\"511521201704210171\",\"PI_CRBZ\":\"1\"}";
            //var baseParam = "{\"OperatorId\":\"E075AC49FCE443778F897CF839F3B924\",\"Account\":\"cpq2677\",\"Pwd\":\"888888\"}";

            //var data = _residentd.GetUserInfo(paramEntity, JsonConvert.DeserializeObject<HisBaseParam>(baseParam));
        }

        private void button1_Click_1(object sender, EventArgs e)
        {



            var controlXmlData = new OutpatientRegisterControlXmlDto()
            {
                TotalAmount = 3,
                Nums = 1,
            };
            var detailRow = new List<OutpatientRegisterDataXmlRow>();
            detailRow.Add(new OutpatientRegisterDataXmlRow()
            {
                DirectoryName = "挂号费",
                MedicalInsuranceProjectCode = "ZL110100001",
                BusinessId = CommonHelp.GuidToStr(Guid.NewGuid().ToString()),
                HappenTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"),
                InputTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"),
                Num = 1,
                Price = 3,
                Operator = "李茜",
                TotalAmount = 3

            });
            var xmlData = new OutpatientRegisterDataXmlDto()
            {
                RegisterType = "1",
                MedicalInsuranceDepartmentCode = "02010000",
                OperatorTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"),
                OperatorName = "李茜",
                BaseDepartmentName = "内科",
                BaseDepartmentCode = "4617180898677846617",
                DetailRow = detailRow

            };
            var controlXml = XmlHelp.YinHaiXmlSerialize(controlXmlData);
            var dataXml = XmlHelp.YinHaiXmlSerialize(xmlData);
            var resultData = yinHaiService.OutpatientRegister(controlXml,
                dataXml, UserId);
            var resultDto = JsonConvert.DeserializeObject<DealModel>(resultData.Data.ToString());
           
            var userData = XmlHelp.YinHaiDeSerializerXml<OutpatientRegisterOutputXmlDto>(resultDto.TransactionOutputXml);
            //MessageBoxShow(resultData);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var operateTime = Convert.ToDateTime("2020-05-25 08:35:36").ToString("yyyy-MM-dd HH:mm:ss");
            var doctorName = "李茜";
            var controlXmlData = new OutpatientDetailUploadControlXmlDto()
            {
                Edition = "5.0",
                MedicalInsuranceOrganization = medicalInsuranceOrganization,
                Nums = 1,
                PersonalCode = "010025489",
                PayType = "0203",
                VisitNo = "00032005299161201",
                TotalAmount = 3
            };
            //阿莫西林胶囊
            var uploadDataXml = new OutpatientDetailUploadDataXmlDto();
            //明细
            var costDetail = new List<OutpatientDetailUploadDataCostDetailXmlDto>()
             {//86902840000014
                 new OutpatientDetailUploadDataCostDetailXmlDto()
                 {
                     Amount = 3,
                     ApprovalMark = "1",
                     DetailId =  DetailTwo,
                     DirectoryCode = CommonHelp.GuidToStr("F4BC9264D52B4ED4AED5A0C56055C337") ,
                     DirectoryName = "阿莫西林胶囊",
                     ProjectCode="86902840000014",
                     OperateDoctorCode = "4861632382718291017",
                     OperateDoctorDepartment = "02010000",
                     OperateDoctorNo = "4861632382718291017",
                     Operators = "李茜",
                     PrescriptionNo = "202005140001",
                     OutpatientCostType = "01",
                     Quantity = 1,
                     UnitPrice = 3,
                     DetailInputTime=operateTime,
                     OperateDoctorRange="101",
                     DetailHappenTime= DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"),

                 }
             };
            uploadDataXml.CostDetail = costDetail;
            //西药
            uploadDataXml.WesternDrugDetail = new List<OutpatientWesternDrugPrescriptionDetail>()
            {
                new OutpatientWesternDrugPrescriptionDetail()
                {//CommonHelp.GuidToStr("912B7C53266442D29CDD73F4784CFB29")
                    PrescriptionNo = "202005140001",
                    GetDrugPerson = "李勇",
                    UseDrugEndTime = operateTime,
                    UseDrugStartTime = DateTime.Now.AddDays(1).ToString("yyyy-MM-dd HH:mm:ss"),

                }
            };
            //挂号信息
            uploadDataXml.RegisterDetail = new OutpatientDetailUploadDataRegisterDetailXmlDto()
            {
                OperateDoctorCode = "4861632382718291017",
                OperateDoctorName = doctorName
            };
            //服务对象明细
            uploadDataXml.ServiceObjectDetail = new OutpatientDetailUploadDataServiceObjectDetailXmlDto()
            {
                OperationName = doctorName,
                OperationTime = operateTime,
              

            };
            var medicalRecordDetail = new OutpatientDetailUploadDataOutpatientMedicalRecordDetailXmlDto()
            {
                Age = 30,
                Birthday = "1990-02-05",
                AntecedentHistory = "头痛",
                DepartmentAreaCode = "02010000",
                DiagnosisStartTime = operateTime,
                DiagnosisTime = operateTime,
                DoctorCode = "4861632382718291017",
                FindDiseaseTime = operateTime,
                IsConfirmDiagnosis = 1,
                IsConsultation = 1,
                IsRepeatedDiagnosis = 0,
                IsTrauma = 0,
                Job = "工人",
                MainDiagnosis = "头痛",
                OperatorName = doctorName,
                WestMedicineFirstDiagnosis= "F90.000",
                PhysiqueInspect = "T36.5℃",
                VisitType = "1",
                SymptomDetail = new List<OutpatientDetailUploadDataSymptomDetailXmlDto>()
                {
                    new OutpatientDetailUploadDataSymptomDetailXmlDto()
                    {
                        DiagnosisCode = "01",
                        DiagnosisName = "头痛"
                    }
                },
                DiagnosisDetail = new List<OutpatientDetailUploadDataDiagnosisDetailXmlDto>()
                {
                    new OutpatientDetailUploadDataDiagnosisDetailXmlDto()
                    {
                        DiagnosisCode = "F90.000",
                        DiagnosisName = "头痛",
                        DiagnosisType = "2"
                    }
                }


            };
            uploadDataXml.MedicalRecordDetail = medicalRecordDetail;

            var dataXml = XmlHelp.YinHaiXmlSerialize(uploadDataXml);
            var controlXml = XmlHelp.YinHaiXmlSerialize(controlXmlData);
            var resultData = yinHaiService.OutpatientDetailUpload(controlXml, dataXml, UserId);

            var resultDto = JsonConvert.DeserializeObject<DealModel>(resultData.Data.ToString());

            var userData = XmlHelp.YinHaiDeSerializerXml<OutpatientDetailUploadOutputXmlDto>(resultDto.TransactionOutputXml);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            var dataXml = OutpatientDepartmentDataXml();
            string dataXmlstr = "<?xml version=\"1.0\" encoding=\"GBK\" standalone=\"yes\"?>";
            dataXmlstr += "";
              var controlXml = new OutpatientDepartmentControlXmlDto();
            controlXml.edition = "5.0";
            controlXml.nums = 1;
            controlXml.TotalAmount = 6;
            //controlXml.VisitNo = "00032005299161201";
            controlXml.SettlementSign = 1;
            //controlXml.MedicalInsuranceOrganization = medicalInsuranceOrganization;
            var resultData = yinHaiService.OutpatientSettlement(
              XmlHelp.YinHaiXmlSerialize(controlXml),
              XmlHelp.YinHaiXmlSerialize(dataXml),
              UserId);
            var resultDto = JsonConvert.DeserializeObject<DealModel>(resultData.Data.ToString());
            var userData = XmlHelp.YinHaiDeSerializerXml<OutpatientSettlementOutputXmlDto>(resultDto.TransactionOutputXml);
            MessageBoxShow(resultData);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="costDetail"></param>
        /// <param name="outpatientBase"></param>
        /// <param name="organizationCode"></param>
        /// <returns></returns>
        private OutpatientDepartmentDataXmlDto OutpatientDepartmentDataXml()
        {


            var resultData = new OutpatientDepartmentDataXmlDto();
            var costDetailData = new List<OutpatientDepartmentDataXmlRowDto>();
            var ordersDetailData = new List<OutpatientDepartmentDataXmlDetailDto>();
            var costDetailItem = new OutpatientDepartmentDataXmlRowDto()
            {
                DetailId = DetailTwo,
                //ProjectCode = "86902503000658",
                //DirectoryName = "头孢他啶",
                DirectoryName = "阿莫西林胶囊",
                ProjectCode = "86902840000014",
                Quantity = 3,
                UnitPrice =1,
                Amount = 3,
                //UnitPrice = Convert.ToDecimal("0.5"),
                //Amount = Convert.ToDecimal("2.5"),
                Operators = "李茜",
                OrdersSortNo= "86902503000658",
                DetailInputTime = Convert.ToDateTime(DateTime.Now).ToString("yyyy-MM-dd HH:mm:ss"),
                DetailTime = Convert.ToDateTime(DateTime.Now).ToString("yyyy-MM-dd HH:mm:ss"),
                DirectoryCode = CommonHelp.GuidToStr("FDCC7B2A446C4B40BC2D9EBA36AF8E4A")
            };
       
            costDetailData.Add(costDetailItem);
         
            //costDetailData;
            resultData.costDetail = costDetailData;
            //resultData.row = new OutpatientDepartmentDataXmlSerialNumberDto
            //{
            //    DetailId = DetailTwo
            //};


            var ordersDetailItem = new OutpatientDepartmentDataXmlDetailDto()
            {
                OrdersSortNo = "86902503000658",
                OrdersContent = "头痛",
                DoctorName = "李茜",
                DoctorCode = CommonHelp.GuidToStr("E075AC49FCE443778F897CF839F3B924"),
                OrdersDepartmentCode = "02010000",
                OrdersDepartmentName = "内科",
                HospitalCodeNo = "",
                OrdersType = "",
                OrdersClassify = "",
                DoseUnit = "",
                Dose = 1,
                UserRoad = "",
                EveryTimeDosage = 1,
                EveryTimeDosageUnit = "",
                Dosage = "",
                DosageUnit = "",
                Frequency = 1,
                UseDays = 1


            };
            ordersDetailData.Add(ordersDetailItem);


            resultData.OrdersDetail = ordersDetailData;

            return resultData;
        }

        private void button5_Click(object sender, EventArgs e)
        {  //输入xml
            string inputXmLStr = @"<?xml version='1.0' encoding='gb2312' standalone='yes'?>
                    <data>
                      <datasetyyjbxx>
                        <yke411>1</yke411>
                      </datasetyyjbxx>
                      <datasetcw>
                        <row>
                          <yke410>0</yke410>
                          <yke411>3</yke411>
                          <yke414>02010000</yke414>
                          <yke506>4625897907689607045</yke506>
                          <yke412>内科病区</yke412>
                          <yke413>006</yke413>
                          <aae011>李茜</aae011>
                          <aae036>2020-05-25 08:53:52</aae036>
                        </row>
                      </datasetcw>
                      <datasetks>
                        <row>
                          <yke414>02010000</yke414>
                          <yke506>5009920413175244308</yke506>
                          <yke415>外科</yke415>
                          <yke416>""</yke416>
                          <yke417>1</yke417>
                          <aae011>李茜</aae011>
                   <aae036>2020-05-25 08:53:52</aae036>
                        </row>
                      </datasetks>
                      <datasetyzry>
                        <row>
                          <yke418>02</yke418>
                          <yke419>4861632382718291017</yke419>
                          <aac003>李茜</aac003>
                          <aac002>222</aac002>
                          <aac004>2</aac004>
                          <yke420>103</yke420>
                          <yke421>222</yke421>
                          <yke422>222</yke422>
                          <yke423>1</yke423>
                          <akc023>2</akc023>
                          <yke424>281</yke424>
                          <yke432>成都</yke432>
                          <yke425>1</yke425>
                          <aae011>李茜</aae011>
                          <aae036>2020-05-25 08:53:52</aae036>
                          <yke414>02010000</yke414>
                          <yke431>2020-06-07 00:00:00</yke431>
                        </row>
                      </datasetyzry>
                    </data>";

            string inputXmLStrs = @"<?xml version='1.0' encoding='gb2312' standalone='yes'?>
                    <data>
                    <datasetcw>
                        <row>
                          <yke410>0</yke410>
                          <yke411>3</yke411>
                          <yke414>02010000</yke414>
                          <yke506>4625897907689607045</yke506>
                          <yke412>内科病区</yke412>
                          <yke413>008</yke413>
                          <aae011>李茜</aae011>
                          <aae036>2020-05-25 08:53:52</aae036>
                        </row>
                      </datasetcw></data>";
            var controlDataXml = new ControlXmlBaseDto()
            {
                MedicalInsuranceHandleNo = "0003"
            };

            var controlXml = XmlHelp.YinHaiXmlSerialize(controlDataXml);
            var resultData = yinHaiService.HospitalInfoUpload(controlXml, inputXmLStrs, UserId);
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button6_Click_1(object sender, EventArgs e)
        {
            string msg = "";
            var resultData = YinHaiCOM.Init(out msg);
            if (resultData)
            {
                MessageBox.Show("初始化成功!!!");
            }

        }


        private void btn_read_Card_Click(object sender, EventArgs e)
        {
            var controlDataXml = new ReadCardXmlDto()
            {
                edition = "3"
            };
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
           var userData = XmlHelp.YiHaiDeSerializerModelJson(new GetUserInfoJsonDto(), xmlStr);
           var resultData = yinHaiService.GetUserInfo("", "", UserId);
           var dds= yinHaiService.GetUserInfoEntity(userData);


        }

        private void button7_Click(object sender, EventArgs e)
        {

            var ccc = new GetYinHaiBaseParam()
            {
                TransactionControlXml = "<?xml version=\'1.0\' encoding=\'gb2312\' standalone=\'yes\'?>\r\n<control>\r\n  <aae011>李茜</aae011>\r\n</control>",
                SerialNumber = "05",
                TransactionInputXml = "<?xml version=\'1.0\' encoding=\'gb2312\' standalone=\'yes\'?>\r\n<data>\r\n  <yab003>0003</yab003>\r\n</data>"
            };
            string dd = "{'TransactionControlXml':'<?xml version=\'1.0\' encoding=\'gb2312\' standalone=\'yes\'?>\r\n<control>\r\n  <aae011>李茜</aae011>\r\n</control>','TransactionInputXml':'<?xml version=\'1.0\' encoding=\'gb2312\' standalone=\'yes\'?>\r\n<data>\r\n  <yab003>0003</yab003>\r\n</data>','TransactionNumber':'05','UserId':'E075AC49FCE443778F897CF839F3B924'}";
            var control = new SignInControlXmlDto()
            {
                OperationName = "李茜"
            };
            var data = new SignInDataXmlDto()
            {   //0003
                MedicalInsuranceOrganization = "0003"
            };
            var controlXml = XmlHelp.YinHaiXmlSerialize(control);
            string dataXml = XmlHelp.YinHaiXmlSerialize(data);
            var resultData = yinHaiService.MedicalInsuranceSignIn(controlXml, dataXml, UserId);
            MessageBoxShow(resultData);
            //var serviceData = new MacActiveX();
            //var resultData = serviceData.YinHaiMethods(JsonConvert.SerializeObject(ccc));
        }

        private void MessageBoxShow(ApiJsonResultData resultData)
        {
            if (!resultData.Success)
            {
                MessageBox.Show(resultData.Message);
            }

        }
        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button9_Click(object sender, EventArgs e)
        {
            string xmlControl = @"<?xml version='1.0' encoding='GBK' standalone='yes'?>
                <control>
                   <yab003>0003</yab003>
                </control>";

            string xmlInput = @"<?xml version='1.0' encoding='GBK' standalone='yes'?>
                            <data>
                            <dir>C:\Program Files (x86)\Microsoft\本鼎医保插件\xmlData</dir>
                            </data>";

            var resultData = yinHaiService.GetServiceCatalog(xmlControl, xmlInput, UserId);
        }

        private void button8_Click(object sender, EventArgs e)
        {
            //string xmlControl = @"<?xml version='1.0' encoding='GBK' standalone='yes'?>
            //    <control>
            //       <yab003>0003</yab003>
            //    </control>";

            //string xmlInput = @"<?xml version='1.0' encoding='GBK' standalone='yes'?>
            //                <data>
            //                <dir>C:\Program Files (x86)\Microsoft\本鼎医保插件\xmlData</dir>
            //                </data>";

            // var resultData = YinHaiCOM.Getuncertaintytrade(xmlControl, xmlInput, UserId);
        }

        private void button11_Click(object sender, EventArgs e)
        {
            var resultData = yinHaiService.Getuncertaintytrade("11","11", UserId);
            MessageBoxShow(resultData);
          

        }

        private void button12_Click(object sender, EventArgs e)
        {
            var resultData = yinHaiService.CancelDeal(null, "120C0000SJ37F70E09", UserId);
            MessageBoxShow(resultData);
        }

        private void button13_Click(object sender, EventArgs e)
        {
            //string xmlControl = @"<?xml version='1.0' encoding='GBK' standalone='yes'?>
            //    <control>
            //       <yab003>0003</yab003>
            //    </control>";

            //string xmlInput = @"<?xml version='1.0' encoding='GBK' standalone='yes'?>
            //                <data>
            //                <dir>C:\Program Files (x86)\Microsoft\本鼎医保插件\xmlData</dir>
            //                </data>";

            var xmlControl = "20C0003SJ37F70D8F";
            var xmlInput = "860324518";
            var resultData = yinHaiService.ConfirmDeal(xmlControl, xmlInput, UserId);

            MessageBoxShow(resultData);
        }

        private void button10_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            var control = new CancelOutpatientSettlementControlXmlDto()
            {
            VisitNo= "00032006239161482",
            SettlementNo= "00002006286416502",
            PayType= "0203",
            };
            var data = new CancelOutpatientSettlementDataXmlDto()
            {  
                MedicalInsurancePayTotalAmount=0,
                TotalAmount= Convert.ToDecimal(6.00),
                AccountPay = 0,
            };
            var controlXml = XmlHelp.YinHaiXmlSerialize(control);
            string dataXml = XmlHelp.YinHaiXmlSerialize(data);
            var resultData = yinHaiService.CancelOutpatientSettlement(controlXml, dataXml, UserId);
            MessageBoxShow(resultData);
        }

        private void button10_Click_1(object sender, EventArgs e)
        {
            string controlXml = @"<?xml version='1.0' encoding='GBK' standalone='yes' ?> 
            <control>
               <cxlx>3</cxlx>
               <aae030>1900-05-25 08:53:52</aae030>
               <aae031>2020-06-25 08:53:52</aae031>
               <yab003>0003</yab003>  --固定值0000
            </control>";
         
            string dataXml = @"<?xml version='1.0' encoding='GBK' standalone='yes'?>
                <data>
	                <dir>C:\Program Files (x86)\Microsoft\本鼎医保插件\xmlData</dir>	
                </data>";

            var resultData = yinHaiService.QueryHospitalInfo(controlXml, dataXml, UserId);
            MessageBoxShow(resultData);
        }

        private void btn_icd10_Click(object sender, EventArgs e)
        {
            string controlXml = @"<?xml version='1.0' encoding='GBK' standalone='yes' ?> 
            <control>
             <yab003>0003</yab003>
               <yae036></yae036>
            </control>";

            string dataXml = @"<?xml version='1.0' encoding='GBK' standalone='yes'?>
                <data>
	                <dir>C:\Program Files (x86)\Microsoft\本鼎医保插件\xmlData</dir>	
                </data>";

            var resultData = yinHaiService.QueryIcd10(controlXml, dataXml, UserId);
            MessageBoxShow(resultData);
        }

        private void btn_datacode_Click(object sender, EventArgs e)
        {

            string controlXml = @"<?xml version='1.0' encoding='GBK' standalone='yes' ?> 
            <control>
             <yab003>0003</yab003>
             
            </control>";

            string dataXml = @"<?xml version='1.0' encoding='GBK' standalone='yes'?>
                <data>
	                <dir>C:\Program Files (x86)\Microsoft\本鼎医保插件\xmlData</dir>	
                </data>";

            var resultData = yinHaiService.QueryDataCode(controlXml, dataXml, UserId);
            MessageBoxShow(resultData);
        }

        private void button14_Click(object sender, EventArgs e)
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
                    // 取得EXE运行后的返回值，返回值只能是整型 
                }
                catch (Exception ex)
                {
                }
            }
        }
         
        private void button15_Click(object sender, EventArgs e)
        {
            var sendInfo = new SendService();
            var sss = sendInfo.SendData(textBox1.Text,"");
            textBox2.Text = sss;

        }

        private void button16_Click(object sender, EventArgs e)
        {
            var activeX = new MacActiveX();
            var control = new SignInControlXmlDto()
            {
                OperationName = "李茜"
            };
            var data = new SignInDataXmlDto()
            {   //098041
                MedicalInsuranceOrganization = "0003"
            };
            var controlXml = XmlHelp.YinHaiXmlSerialize(control);
            string dataXml = XmlHelp.YinHaiXmlSerialize(data);
            //var resultData=  activeX.YinHaiMethods(controlXml, dataXml, "MedicalInsuranceSignIn", "123");
        }

        private void button7_Click_1(object sender, EventArgs e)
        {
            var activeX = new MacActiveX();
            //var resultData = activeX.YinHaiMethods("GetSignInUserId", "GetSignInUserId", "GetSignInUserId", "123");
        }

        private void btn_Register_Click(object sender, EventArgs e)
        {
            var activeX = new MacActiveX();
            var service = new YinHaiService();
            var testParam = service.GetTestParam("21");
            //var resultData = activeX.YinHaiMethods(testParam.TransactionControlXml, 
            //                    testParam.TransactionInputXml, 
            //                    "HospitalizationRegister", 
            //                    "123");
        }

        private void btn_Cancel_Click(object sender, EventArgs e)
        {
            var activeX = new MacActiveX();
            var service = new YinHaiService();
            var testParam = service.GetTestParam("26");
            //var resultData = activeX.YinHaiMethods(testParam.TransactionControlXml,
            //    testParam.TransactionInputXml,
            //    "CancelHospitalizationRegister",
            //    "123");
        }

        private void btn_model_Click(object sender, EventArgs e)
        {
            var activeX = new MacActiveX();
            var service = new YinHaiService();
            var testParam = service.GetTestParam("23");
            //var resultData = activeX.YinHaiMethods(testParam.TransactionControlXml,
            //    testParam.TransactionInputXml,
            //    "ModifyHospitalizationRegister",
            //    "123");
        }

        private void btnSettlement_Click(object sender, EventArgs e)
        {
            string controlXml = @"<?xml version='1.0' encoding='GBK' standalone='yes' ?> 
           <control><akc190>00032006309161680</akc190><aac001>010025489</aac001><aka130>0309</aka130><yab003>0003</yab003><aae011>李茜</aae011><print>0</print></control>";

            string dataXml = @"<?xml version='1.0' encoding='GBK' standalone='yes'?>
               <data><yka055>3.60</yka055><nums>1</nums><yka110></yka110><aae011>李茜</aae011></data>";

            var resultData = yinHaiService.LeaveHospitalizationSettlement(controlXml, dataXml, UserId);
        }

        private void btnCognizance_Click(object sender, EventArgs e)
        {
            string controlXml = CommonHelp.GetYinHaiXmlHead();
            controlXml += @"<control>
                        <yab003>0003</yab003> 
                        </control>";

            string dataXml = CommonHelp.GetYinHaiXmlHead()+ "<data></data>";
            var resultData = yinHaiService.OpSpecialCognizance(controlXml, dataXml, UserId);
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void btnCancelUpload_Click(object sender, EventArgs e)
        {
            string controlXml = CommonHelp.GetYinHaiXmlHead();
            controlXml += @"<control> 
                             <akc190>00032007249161869</akc190>
                           <aac001>010025489</aac001>
                           <aka130>0204</aka130>
                           <yab003>0003</yab003>
</control> ";

            string dataXml = CommonHelp.GetYinHaiXmlHead() + 
                             "<data><row yka105='5595364812663565850'/></data>";
            var resultData = yinHaiService.CancelUploadHospitalizationDetail(controlXml, dataXml, UserId);
        }

        private void btnQuerySpecialDiseases_Click(object sender, EventArgs e)
        {//
            string controlXml = CommonHelp.GetYinHaiXmlHead();
            controlXml += @"<control> 
            <ykc112>100000010516129</ykc112>
            <aka130>0204</aka130>
            <cxlx>1</cxlx>
                                     
                                       <aac001>010025489</aac001>

                                       <yab003>0003</yab003>
</control> ";

            string dataXml = CommonHelp.GetYinHaiXmlHead() +
                             "<data></data>";
            var resultData = yinHaiService.QuerySpecialDiseases(controlXml, dataXml, UserId);
        }

        private void btnQueryCognizance_Click(object sender, EventArgs e)
        {

            string controlXml = CommonHelp.GetYinHaiXmlHead();
            controlXml += @"<control> 
            <yab003>0003</yab003> //默认为0000
              <aac001>010025489</aac001>
                 </control> ";

            string dataXml = CommonHelp.GetYinHaiXmlHead() +
                             "<data></data>";
            var resultData = yinHaiService.QueryOpSpecialCognizance(controlXml, dataXml, UserId);
        }
    }


}
