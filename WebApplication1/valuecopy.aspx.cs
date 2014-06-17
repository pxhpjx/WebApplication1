using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1
{
    public partial class valuecopy : System.Web.UI.Page
    {
        class cl
        {
            public int pi { get; set; }
            private string ps { get; set; }
            public List<string> ls { get; set; }

            public void f()
            {
                ps = "www";
            }
        }



        protected void Page_Load(object sender, EventArgs e)
        {
            Type ttt = Type.GetType("System.String");

            List<string> ls = new List<string>();
            ls.Add("1");
            ls.Add("11");
            ls.Add("111");

            List<string> ls1, ls2;
            ls1 = ls;
            ls2 = ls as List<string>;
            ls[0] = "www";
            List<object> lo = (object)ls as List<object>;

            cl c1, c2;
            c1 = new cl();
            c1.pi = 1;
            c1.ls = ls;
            c1.f();
            c2 = ValueCopy(c1);
            //object ols = (object)ls;
            //object ols2 = ValueCopy(ols, typeof(List<string>));
            //List<string> lsc = ValueCopy(ls);
            //lsc = ListCopy(ls);
            //lsc = FormatTools.CreateListByType(ttt) as List<string>;
        }


        public static T ValueCopy<T>(T input, Type inputType = null)
        {
            T result = default(T);
            if (input != null)
            {
                try
                {
                    Type type = (inputType == null ? typeof(T) : inputType);
                    result = (T)Activator.CreateInstance(type);
                    if (type.FullName.IndexOf("System.Collections.Generic.List") == 0)
                    {
                        Type itemType = Type.GetType(type.FullName.Substring(35, type.FullName.IndexOf(',') - 35));
                        result = (T)CreateListByType(itemType);


                    }
                    PropertyInfo[] Props = type.GetProperties(BindingFlags.Public | BindingFlags.Instance | BindingFlags.NonPublic);
                    if (type.IsValueType)
                    {
                        if (Props == null)
                            return input;
                        if (Props.ToList().Find(item => !item.PropertyType.IsValueType) == null)
                            return input;
                    }
                    foreach (PropertyInfo p in Props)
                    {
                        Type t = p.PropertyType;
                        object ElementValue = p.GetValue(input, null);
                        if (!t.IsValueType && t.FullName != "System.String")
                        {
                            object value = ValueCopy(ElementValue, t);
                            p.SetValue(result, value, null);
                        }
                        else
                            p.SetValue(result, ElementValue, null);
                    }
                }
                catch { }
            }
            return result;
        }


        /// <summary>
        /// 使用指定的Type生成空List
        /// </summary>
        /// <param name="inputType"></param>
        /// <returns></returns>
        public static object CreateListByType(Type inputType)
        {
            object result = null;
            try
            {
                MethodInfo mi = typeof(FormatTools).GetMethod("CreateList").MakeGenericMethod(inputType);
                result = mi.Invoke("", null);
            }
            catch { }
            return result;
        }

        /// <summary>
        /// 创建List。
        /// 为反射提供入口，不做其他用途。
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static List<T> CreateList<T>()
        {
            return new List<T>();
        }

        public static List<T> ListCopy<T>(List<T> inputList)
        {
            List<T> result = null;
            if (inputList == null)
                return result;
            result = new List<T>();
            foreach (T item in inputList)
            {
                T output = ValueCopy(item);
                result.Add(output);
            }




            return result;
        }







    }
}