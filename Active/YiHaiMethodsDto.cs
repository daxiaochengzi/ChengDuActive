using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BenDingActive
{//string param, string baseParam, string methodName, string operatorId
    public class YiHaiMethodsDto
    {
        /// <summary>
        /// 控制参数
        /// </summary>
        public string ControlParam { get; set; }
        /// <summary>
        /// 输入参数
        /// </summary>
        public string InputParam { get; set; }
        /// <summary>
        /// 方法名称
        /// </summary>
        public string MethodName { get; set; }
        /// <summary>
        /// 用户id
        /// </summary>
        public string OperatorId { get; set; }
       
    }
}
