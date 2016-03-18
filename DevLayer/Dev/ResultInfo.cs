using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApplication1
{
    /// <summary>
    /// 通用查询结果类。设置Result值推荐使用SetValue方法代替直接赋值。
    /// </summary>
    /// <typeparam name="T"></typeparam>
    [Serializable]
    public class ResultInfo<T>
    {
        private int code = 0;
        public int Code
        {
            get { return code; }
            set { code = value; }
        }
        private string message = null;
        public string Message
        {
            get { return message; }
            set { message = value; }
        }

        private T value = default(T);
        public T Value
        {
            get { return value; }
            set { this.value = value; }
        }

        //public int Code { get; set; }

        //public string Message { get; set; }

        //public T Value { get; set; }

        public ResultInfo<T> SetValue(T value, string msg = null, int code = 200)
        {
            Code = code;
            Value = value;
            Message = msg;
            return this;
        }

        public static ResultInfo<T> CreateResult(T value, string msg = null, int code = 200)
        {
            ResultInfo<T> r = new ResultInfo<T>();
            r.Value = value;
            r.Message = msg;
            r.Code = code;
            return r;
        }

        public static ResultInfo<T> CreateResult(Func<T> func)
        {
            try
            {
                return CreateResult(func());
            }
            catch (Exception ex)
            {
                LogRecord.WriteLogExt(ex.ToString());
                return CreateResult(default(T), ex.Message, 500);
            }
        }
    }
}