using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace BenDingActive.Model.Json
{
   public class GetUserInfoJsonDto
    {
        /// <summary>
        /// 个人编码
        /// </summary>

        [JsonProperty(PropertyName = "aac001")]
        public string PersonalCoding { get; set; }
        /// <summary>
        /// 身份证号
        /// </summary>

        [JsonProperty(PropertyName = "aac002")]
        public string IdCardNo { get; set; }
        /// <summary>
        /// 姓名
        /// </summary>

        [JsonProperty(PropertyName = "aac003")]
        public string PatientName { get; set; }
        /// <summary>
        /// 性别
        /// </summary>

        [JsonProperty(PropertyName = "aac004")]
        public string PatientSex { get; set; }

        /// <summary>
        /// 出生日期 Birthday
        /// </summary>

        [JsonProperty(PropertyName = "aac006")]
        public string Birthday { get; set; }
        /// <summary>
        /// 实足年龄
        /// </summary>

        [JsonProperty(PropertyName = "akc023")]
        public string Age { get; set; }
        /// <summary>
        /// 账户信息
        /// </summary>
        [JsonProperty(PropertyName = "grzhye")]
        public UserInfogrzhye AccountInfo { get; set; }
        /// <summary>
        /// 享受待遇标识
        /// </summary>
        [JsonProperty(PropertyName = "bkc121")]
        public string EnjoyTreatmentMark { get; set; }
        /// <summary>
        /// 不享受待遇信息
        /// </summary>
        [JsonProperty(PropertyName = "bkc124")]
        public string UnEnjoyTreatmentMsg { get; set; }
        /// <summary>
        /// 医保标识
        /// </summary>
        [JsonProperty(PropertyName = "ydbz")]
        public string MedicalInsuranceSign { get; set; }
    }

    public class UserInfogrzhye
    {
        public UserInfogrzhyeList Row { get; set; }
    }

    public class UserInfogrzhyeList
    {
        /// <summary>
        /// 账户种类
        /// </summary>
        [JsonProperty(PropertyName = "ykc303")]
        public string AccountType { get; set; }
        /// <summary>
        /// 账户余额
        /// </summary>
        [JsonProperty(PropertyName = "ykc194")]
        public decimal AccountBalance { get; set; }
    }
}
