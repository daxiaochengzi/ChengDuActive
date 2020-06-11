using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BenDingActive.Model.Dto.YiHai
{/// <summary>
/// 获取用户信息
/// </summary>
  public  class GetUserInfoDto
    {/// <summary>
     /// 个人编码
     /// </summary>


        public string PersonalCoding { get; set; }

        /// <summary>
        /// 行政区域
        /// </summary>


        public string AdministrativeArea { get; set; }
        /// <summary>
        /// 姓名
        /// </summary>


        public string PatientName { get; set; }
        /// <summary>
        /// 性别
        /// </summary>


        public string PatientSex { get; set; }
        /// <summary>
        /// 出生日期 Birthday
        /// </summary>


        public string Birthday { get; set; }
        /// <summary>
        /// 险种类型310:城镇职工基本医疗保险342：城乡居民基本医疗保险根据获取的险种类型，调用对应的职工或者居民接口办理入院。
        /// </summary>
        public string InsuranceType { get; set; }
        /// <summary>
        /// 险种名称
        /// </summary>
        public string InsuranceName { get; set; }
        /// <summary>
        /// 医保标识
        /// </summary>
        public string MedicalInsuranceSign { get; set; }

        ///// <summary>
        ///// 人员分类
        ///// </summary>


        //public string PersonnelClassification { get; set; }


        /// <summary>
        /// 身份证号
        /// </summary>


        public string IdCardNo { get; set; }
        /// <summary>
        /// 实足年龄
        /// </summary>


        public string Age { get; set; }
        ///// <summary>
        ///// 社区名称
        ///// </summary>


        //public string CommunityName { get; set; }
        /// <summary>
        /// 居民医保账户余额ResidentInsuranceBalance
        /// </summary>


        public decimal AccountBalance { get; set; }
       
       
        /// <summary>
        /// 过程返回值(为1时正常，否则不正常)
        /// </summary>
        public string ReturnState { get; set; }
        /// <summary>
        /// 系统错误信息
        /// </summary>
        public string Msg { get; set; }
    }
}
