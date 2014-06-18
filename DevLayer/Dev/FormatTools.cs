using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Net;
using System.IO;
using System.Reflection;
using System.Threading;

namespace WebApplication1
{
    /// <summary>
    /// PP's FormatTools -20140320 ver-
    /// 数据格式转化工具
    /// </summary>
    public static class FormatTools
    {
        #region 数据格式转换

        /// <summary>
        /// 转化任意数据为Int（无效返回0）
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static int ParseInt(object obj)
        {
            int result;
            if (obj != null && int.TryParse(obj.ToString(), out result))
                return result;
            else
                return 0;
        }

        /// <summary>
        /// 转化任意数据为Int?（无效返回null）
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static int? ParseNInt(object obj)
        {
            int? result = null;
            int i;
            if (obj != null && int.TryParse(obj.ToString(), out i))
                result = i;
            return result;
        }

        /// <summary>
        /// 转化任意数据为double（无效返回0）
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static double ParseDouble(object obj)
        {
            double result;
            if (obj != null && double.TryParse(obj.ToString(), out result))
                return result;
            else
                return 0;
        }

        /// <summary>
        /// 转化任意数据为double?（无效返回null）
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static double? ParseNDouble(object obj)
        {
            double? result = null;
            double d;
            if (obj != null && double.TryParse(obj.ToString(), out d))
                result = d;
            return result;
        }

        /// <summary>
        /// 转化任意数据为指定小数位数的double?（无效返回null）
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="i">小数位数</param>
        /// <returns></returns>
        public static double? ParseNDouble(object obj, int i)
        {
            double? result = null;
            double d;
            if (obj != null && double.TryParse(obj.ToString(), out d))
                result = d;
            if (result != null)
                while (i > 0)
                {
                    result /= 10;
                    i--;
                }
            return result;
        }

        /// <summary>
        /// 转化任意数据为long（无效返回0）
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static long ParseLong(object obj)
        {
            long result;
            if (obj != null && long.TryParse(obj.ToString(), out result))
                return result;
            else
                return 0;
        }

        /// <summary>
        /// 转化任意数据为byte（无效返回0）
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static byte ParseByte(object obj)
        {
            byte result;
            if (obj != null && byte.TryParse(obj.ToString(), out result))
                return result;
            else
                return 0;
        }

        /// <summary>
        /// 转化任意数据为byte?（无效返回null）
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static byte? ParseNByte(object obj)
        {
            byte? result = null;
            byte b;
            if (obj != null && byte.TryParse(obj.ToString(), out b))
                result = b;
            return result;
        }

        /// <summary>
        /// 转化任意数据为DateTime（无效返回new DateTime()）
        /// 特别的，可以识别YYYYMMDD格式的8位数字并进行转化
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static DateTime ParseDate(object obj)
        {
            DateTime result;
            if (obj != null && DateTime.TryParse(obj.ToString(), out result))
                return result;
            if (obj != null && obj.ToString().Length == 8 && ParseInt(obj) > 0)
                return new DateTime(ParseInt(obj.ToString().Substring(0, 4)), ParseInt(obj.ToString().Substring(4, 2)), ParseInt(obj.ToString().Substring(6, 2)));
            return new DateTime();
        }

        /// <summary>
        /// 转化任意数据为DateTime（无效返回null）
        /// 特别的，可以识别YYYYMMDD格式的8位数字并进行转化
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static DateTime? ParseNDate(object obj)
        {
            DateTime result;
            if (obj != null && DateTime.TryParse(obj.ToString(), out result))
                return result;
            if (obj != null && obj.ToString().Length == 8 && ParseInt(obj) > 0)
                return new DateTime(ParseInt(obj.ToString().Substring(0, 4)), ParseInt(obj.ToString().Substring(4, 2)), ParseInt(obj.ToString().Substring(6, 2)));
            return null;
        }

        /// <summary>
        /// 转化任意数据为string（无效返回null）
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static string ParseString(object obj)
        {
            return obj == null ? null : obj.ToString();
        }

        /// <summary>
        /// 转化任意数据为string（无效返回""）
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static string ParseStringE(object obj)
        {
            return obj == null ? "" : obj.ToString();
        }

        /// <summary>
        /// 转化日期为string（无效或new则返回""）
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static string Date2String(object obj)
        {
            DateTime result = new DateTime();
            try
            {
                result = (DateTime)obj;
            }
            catch { }
            return result == new DateTime() ? "" : result.ToString("yyyy-MM-dd");
        }

        /// <summary>
        /// 将日期做Oracle数据库可null处理，若无效或new则返回""
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static object Date2Oracle(object obj)
        {
            DateTime result = new DateTime();
            try
            {
                result = (DateTime)obj;
            }
            catch { }
            return result == new DateTime() ? (object)"" : obj;
        }

        /// <summary>
        /// 转化任意数据为decimal
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static decimal ParseDecimal(object obj)
        {
            decimal result;
            if (obj != null && decimal.TryParse(obj.ToString(), out result))
                return result;
            else
                return 0;
        }

        /// <summary>
        /// 转化任意数据为bool（特例：1/0转化为true/false）
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static bool ParseBool(object obj)
        {
            bool result = false;
            if (obj != null)
            {
                if (obj.ToString() == "0")
                    return false;
                if (obj.ToString() == "1")
                    return true;
                bool.TryParse(obj.ToString(), out result);
            }
            return result;
        }

        /// <summary>
        /// 转化任意数据为TimeSpan
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static TimeSpan ParseTimeSpan(object obj)
        {
            TimeSpan result;
            if (obj != null && TimeSpan.TryParse(obj.ToString(), out result))
                return result;
            else
                return new TimeSpan();
        }

        /// <summary>
        /// UTF8编码字符串转化为Base64编码
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string UTF8ToBase64(string str)
        {
            if (str == null)
                return null;
            try
            {
                return Convert.ToBase64String(Encoding.UTF8.GetBytes(str));
            }
            catch
            {
                return null;
            }
        }

        /// <summary>
        /// Base64编码字符串转化为UTF8编码
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string Base64ToUTF8(string str)
        {
            if (str == null)
                return null;
            try
            {
                return Encoding.UTF8.GetString(Convert.FromBase64String(str));
            }
            catch
            {
                return null;
            }
        }

        #endregion

        #region 检查工具

        /// <summary>
        /// 检查是否含有null项
        /// </summary>
        /// <param name="objs"></param>
        /// <returns></returns>
        public static bool IsAnyNull(params object[] objs)
        {
            if (objs == null)
                return false;
            foreach (object obj in objs)
                if (obj == null)
                    return true;
            return false;
        }

        /// <summary>
        /// 检查是否含有空字符串
        /// </summary>
        /// <param name="strs"></param>
        /// <returns></returns>
        public static bool IsAnyNullOrWhiteSpace(params string[] strs)
        {
            if (strs == null)
                return false;
            foreach (string str in strs)
                if (string.IsNullOrWhiteSpace(str))
                    return true;
            return false;
        }

        /// <summary>
        /// 检查是否有0项
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public static bool IsAnyZero(params int[] nums)
        {
            if (nums == null)
                return false;
            foreach (int num in nums)
                if (num == 0)
                    return true;
            return false;
        }

        /// <summary>
        /// 过滤SQL敏感词
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static bool SqlFilter(string input)
        {
            if (string.IsNullOrWhiteSpace(input))
                return false;
            string[] words = { "and", "exec", "insert", "select", "delete", "update", "chr", "mid", "master", "or", "truncate", "char", "declare", "join" };
            foreach (string word in words)
                if (input.ToLower().Contains(word + " ") || (input.ToLower().Contains(" " + word)))
                    return true;
            return false;
        }

        #endregion

        #region 正则截取Xml

        /// <summary>
        /// 截取找到的第一个节点内容
        /// </summary>
        /// <param name="xml"></param>
        /// <param name="nodeName">节点名（允许但不推荐使用正则表达式）</param>
        /// <param name="pattern">节点内容的正则表达式</param>
        /// <returns></returns>
        public static string SeekXmlNodeValue(string xml, string nodeName, string pattern = RegexMode.SmallNodeNormal)
        {
            if (FormatTools.IsAnyNullOrWhiteSpace(xml, nodeName, pattern))
                return null;
            try
            {
                Regex r = new Regex(string.Format(@"<{0}>{1}</{0}>", nodeName, pattern));
                Match m = r.Match(xml);
                if (!m.Success)
                    return null;
                return m.Value.Substring(nodeName.Length + 2, m.Value.Length - 2 * nodeName.Length - 5);
            }
            catch { }
            return null;
        }

        /// <summary>
        /// 截取找到的符合条件的所有节点
        /// </summary>
        /// <param name="xml"></param>
        /// <param name="nodeName">节点名（允许但不推荐使用正则表达式）</param>
        /// <param name="pattern">节点内容的正则表达式</param>
        /// <returns></returns>
        public static List<string> SeekXmlNodeValues(string xml, string nodeName, string pattern = RegexMode.SmallNodeNormal)
        {
            if (FormatTools.IsAnyNullOrWhiteSpace(xml, nodeName, pattern))
                return null;
            List<string> values = null;
            try
            {
                Regex r = new Regex(string.Format(@"<{0}>{1}</{0}>", nodeName, pattern));
                MatchCollection mc = r.Matches(xml);
                values = new List<string>();
                if (mc.Count > 0)
                    foreach (Match m in mc)
                        values.Add(m.Value.Substring(nodeName.Length + 2, m.Value.Length - 2 * nodeName.Length - 5));
            }
            catch { }
            return values;
        }

        /// <summary>
        /// 常用的正则截取模式
        /// </summary>
        public static class RegexMode
        {
            /// <summary>
            /// 小节点模式
            /// 取出一个最小节点当中包含的任意字符
            /// </summary>
            public const string SmallNodeNormal = "[^<>]*?";

            /// <summary>
            /// 大节点模式
            /// 取出一个允许包含子节点的节点内容
            /// </summary>
            public const string BigNodeNormal = "\\S*?";
        }
        #endregion

        /// <summary>
        /// 将两个List中的数据合并到一个新的List中。
        /// List中的每一个实体均保持原有引用。
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="list1"></param>
        /// <param name="list2"></param>
        /// <returns></returns>
        public static List<T> ListCombine<T>(List<T> list1, List<T> list2)
        {
            List<T> result = new List<T>();
            if (list1 != null && list1.Count > 0)
                foreach (T entity in list1)
                    result.Add(entity);
            if (list2 != null && list2.Count > 0)
                foreach (T entity in list2)
                    result.Add(entity);
            return result;
        }

        #region 复制 施工中

        /// <summary>
        /// 简单复制类的值。
        /// 类中含有引用类型字段时，会 导致引用复制该字段。
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="input"></param>
        /// <returns></returns>
        public static T SampleCopy<T>(T input) where T : class,new()
        {
            T Result = null;
            if (input != null)
            {
                try
                {
                    Result = new T();
                    Type type = typeof(T);
                    PropertyInfo[] Props = type.GetProperties(BindingFlags.Public | BindingFlags.Instance);
                    foreach (PropertyInfo p in Props)
                    {
                        object ElementValue = p.GetValue(input, null);
                        p.SetValue(Result, ElementValue, null);
                    }
                }
                catch { }
            }
            return Result;
        }

        /// <summary>
        /// Developing
        /// 完全复制类与结构的值。不能用于复制List。
        /// 无论类中是否含有引用类型字段，都 不会 复制引用，而是创建一个具有相同值的副本。
        /// 除非input为object，否则不需要强制指定inputType。inputType与T不统一时，无法进行复制。
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="input"></param>
        /// <param name="inputType"></param>
        /// <returns></returns>
        public static T ValueCopy<T>(T input, Type inputType = null)
        {
            T result = default(T);
            if (input != null)
            {
                try
                {
                    Type type = (inputType == null ? typeof(T) : inputType);
                    result = (T)Activator.CreateInstance(type);
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

        #endregion

        /// <summary>
        /// 附加超时限制运行方法。
        /// </summary>
        /// <typeparam name="T">返回值类型</typeparam>
        /// <param name="func">需要执行的方法</param>
        /// <param name="timeOut">超时限制（毫秒）</param>
        /// <param name="output">方法输出结果</param>
        /// <returns>是否成功执行完毕</returns>
        public static bool ExecFuncWithTimeOut<T>(Func<T> func, int timeOut, out T output)
        {
            bool isExecFinished = false;
            T result = default(T);
            Thread th = new Thread(() => { result = func(); isExecFinished = true; });
            try
            {
                th.Start();
                SpinWait.SpinUntil(() => (isExecFinished || !th.IsAlive), timeOut);
            }
            catch { }
            if (th.IsAlive)
                th.Abort();

            output = result;
            return isExecFinished;
        }
    }
}
