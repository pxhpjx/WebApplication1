using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fund.Web.Admin.Web.EntityLayer
{
    /// <summary>
    /// 通用查询结果类。设置Result值推荐使用SetValue方法代替直接赋值。
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class ResultInfo<T>
    {
        private bool isSuccess = false;
        public bool IsSuccess
        {
            get { return isSuccess; }
            set { isSuccess = value; }
        }
        private string message = "";
        public string Message
        {
            get { return message; }
            set { message = value; }
        }
        public T Result { get; set; }


        public void SetValue(T value)
        {
            isSuccess = true;
            Result = value;
        }
    }
}
