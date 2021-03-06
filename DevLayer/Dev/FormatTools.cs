﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Net;
using System.IO;
using System.Reflection;
using System.Threading;
using System.Security.Cryptography;

namespace WebApplication1
{
    /// <summary>
    /// PP's FormatTools -20151218 ver-
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
        /// 特别的，可以识别yyyyMMdd格式的8位数字并进行转化
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static DateTime ParseDate(object obj)
        {
            DateTime result;
            if (obj != null && DateTime.TryParse(obj.ToString(), out result))
                return result;
            try
            {
                if (obj != null && obj.ToString().Length == 8 && ParseInt(obj) > 0)
                    return new DateTime(ParseInt(obj.ToString().Substring(0, 4)), ParseInt(obj.ToString().Substring(4, 2)), ParseInt(obj.ToString().Substring(6, 2)));
            }
            catch { }
            return default(DateTime);
        }

        /// <summary>
        /// 转化任意数据为DateTime（无效返回null）
        /// 特别的，可以识别yyyyMMdd格式的8位数字并进行转化
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static DateTime? ParseNDate(object obj)
        {
            DateTime result;
            if (obj != null && DateTime.TryParse(obj.ToString(), out result))
                return result;
            try
            {
                if (obj != null && obj.ToString().Length == 8 && ParseInt(obj) > 0)
                    return new DateTime(ParseInt(obj.ToString().Substring(0, 4)), ParseInt(obj.ToString().Substring(4, 2)), ParseInt(obj.ToString().Substring(6, 2)));
            }
            catch { }
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
        /// 转化任意数据为string（无效返回string.Empty）
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static string ParseStringE(object obj)
        {
            return obj == null ? string.Empty : obj.ToString();
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

        /// <summary>
        /// Base64编码字符串转化为byte[]
        /// 可以自动处理UrlSafe的字符串，可以自动填充
        /// </summary>
        /// <param name="strBase64"></param>
        /// <returns></returns>
        public static byte[] GetBase64Array(string strBase64)
        {
            if (string.IsNullOrEmpty(strBase64))
                return null;

            strBase64 = strBase64.Replace("-", "+").Replace("_", "/");
            int i = 0;
            Byte[] result = null;
            while (result == null && i < 3)
            {
                try
                {
                    result = Convert.FromBase64String(strBase64);
                }
                catch
                {
                    strBase64 += "=";
                    i++;
                }
            }
            return result;
        }

        /// <summary>
        /// byte[]转化为UTF8字符串
        /// </summary>
        /// <param name="array"></param>
        /// <returns></returns>
        public static string GetUTF8String(byte[] array)
        {
            if (array == null || array.Length == 0)
                return null;
            try
            {
                return Encoding.UTF8.GetString(array);
            }
            catch { }
            return null;
        }

        /// <summary>
        /// byte[]转化为Base64字符串
        /// </summary>
        /// <param name="array"></param>
        /// <returns></returns>
        public static string GetBase64String(byte[] array)
        {
            if (array == null || array.Length == 0)
                return null;
            try
            {
                return Convert.ToBase64String(array);
            }
            catch { }
            return null;
        }

        /// <summary>
        /// AES解密
        /// </summary>
        /// <param name="toDecryptArray"></param>
        /// <param name="key"></param>
        /// <param name="cm"></param>
        /// <param name="pm"></param>
        /// <returns></returns>
        public static byte[] AESDecrypt(byte[] toDecryptArray, byte[] key, CipherMode cm = CipherMode.ECB, PaddingMode pm = PaddingMode.PKCS7)
        {
            if (toDecryptArray == null || key == null)
                return null;
            try
            {
                RijndaelManaged rm = new RijndaelManaged();
                rm.Key = key;
                rm.Mode = cm;
                rm.Padding = pm;
                return rm.CreateDecryptor().TransformFinalBlock(toDecryptArray, 0, toDecryptArray.Length);
            }
            catch { }
            return null;
        }

        /// <summary>
        /// AES加密
        /// </summary>
        /// <param name="toEncryptArray"></param>
        /// <param name="key"></param>
        /// <param name="cm"></param>
        /// <param name="pm"></param>
        /// <returns></returns>
        public static byte[] AESEncrypt(byte[] toEncryptArray, byte[] key, CipherMode cm = CipherMode.ECB, PaddingMode pm = PaddingMode.PKCS7)
        {
            if (toEncryptArray == null || key == null)
                return null;
            try
            {
                RijndaelManaged rm = new RijndaelManaged();
                rm.Key = key;
                rm.Mode = cm;
                rm.Padding = pm;
                return rm.CreateEncryptor().TransformFinalBlock(toEncryptArray, 0, toEncryptArray.Length);
            }
            catch { }
            return null;
        }

        /// <summary>
        /// 获取Dictionary值
        /// 如果不存在对应Key，则返回Value类型默认值
        /// </summary>
        /// <typeparam name="T1"></typeparam>
        /// <typeparam name="T2"></typeparam>
        /// <param name="dic"></param>
        /// <param name="key"></param>
        /// <returns></returns>
        public static T2 GetDicValue<T1, T2>(Dictionary<T1, T2> dic, T1 key)
        {
            if (dic == null || !dic.ContainsKey(key))
                return default(T2);
            return dic[key];
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
        public static T SampleCopy<T>(T input) where T : class, new()
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
                catch { Result = default(T); }
            }
            return Result;
        }

        /// <summary>
        /// 简单复制类的值。
        /// 可以对属性对应的不相关的类进行复制。
        /// 类中含有引用类型字段时，会 导致引用复制该字段。
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="input"></param>
        /// <returns></returns>
        public static T2 SampleCopy<T1, T2>(T1 input) where T2 : class, new()
        {
            T2 Result = null;
            if (input != null)
            {
                try
                {
                    Result = new T2();
                    PropertyInfo[] t1Props = typeof(T1).GetProperties(BindingFlags.Public | BindingFlags.Instance);
                    PropertyInfo[] t2Props = typeof(T2).GetProperties(BindingFlags.Public | BindingFlags.Instance);
                    foreach (PropertyInfo p in t1Props)
                    {
                        object ElementValue = p.GetValue(input, null);
                        PropertyInfo p2 = t2Props.FirstOrDefault(item => item.Name == p.Name);
                        try
                        {
                            if (p2 != null)
                                p2.SetValue(Result, ElementValue, null);
                        }
                        catch { }
                    }
                }
                catch
                {
                    Result = default(T2);
                }
            }
            return Result;
        }

        /// <summary>
        /// Developing
        /// 完全复制类与结构的值。不能用于复制数组集合类型。
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
                    if (type.IsArray || type.Namespace == "System.Collections.Generic")
                        return result;
                    if (type.IsValueType || type.FullName == "System.String")
                        //{
                        //if (Props == null)
                        //    return input;
                        //if (Props.ToList().Find(item => !item.PropertyType.IsValueType) == null)
                        return input;
                    //}
                    result = (T)Activator.CreateInstance(type);
                    PropertyInfo[] Props = type.GetProperties(BindingFlags.Public | BindingFlags.Instance | BindingFlags.NonPublic);
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

        public static void QuickDispose<T>(T source) where T : IDisposable
        {
            if (source != null)
                source.Dispose();
        }

        /// <summary>
        /// 移除字符串中的指定范围之内的连续空格
        /// </summary>
        /// <param name="str">需要处理的字符串</param>
        /// <param name="minCount">连续空格数量最小值</param>
        /// <param name="maxCount">连续空格数量最大值</param>
        /// <returns></returns>
        public static string TrimSpaces(string str, int minCount = 2, int maxCount = 999)
        {
            if (string.IsNullOrWhiteSpace(str))
                return str;
            str = str.Trim();
            Regex reg = new Regex(" {" + minCount.ToString() + "," + maxCount.ToString() + "}");
            Match m = reg.Match(str);
            while (m.Success)
            {
                str = str.Replace(m.Value, "");
                m = reg.Match(str);
            }
            return str;
        }

        /// <summary>
        /// 安全移除前导和尾部空白
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string SafeTrim(this string str)
        {
            if (str == null)
                return null;
            return str.Trim();
        }


        /// <summary>
        /// 切出字符串中指定位置开始指定数目的部分，切出部分会被从源字符串中移除
        /// 若允许越界，越界时自动停止并返回；否则按出错处理
        /// </summary>
        /// <param name="input">需要处理的字符串</param>
        /// <param name="cutLen">需要切出字符串的长度</param>
        /// <param name="cutStart">需要切出字符串的开始位置</param>
        /// <param name="allowOverstep">是否允许越界</param>
        /// <returns></returns>
        public static string CutOutString(ref string input, int cutLen, int cutStart = 0, bool allowOverstep = false)
        {
            if (string.IsNullOrWhiteSpace(input) || cutLen <= 0 || cutStart < 0 || cutStart > input.Length)
                return null;

            string result = null;
            if (input.Length < cutLen + cutStart)
            {
                if (!allowOverstep)
                    return result;
                result = input.Substring(cutStart);
                input = input.Remove(cutStart);
                return result;
            }
            result = input.Substring(cutStart, cutLen);
            input = input.Remove(cutStart, cutLen);
            return result;
        }

        /// <summary>
        /// 按位取出指定位置开始的字符串
        /// </summary>
        /// <param name="input">需要处理的字符串</param>
        /// <param name="encoding">字符编码</param>
        /// <param name="cutLen">获取字符串的长度</param>
        /// <param name="cutStart">取出字符串的起始位置</param>
        /// <param name="isNeedCutOut">是否需要从源字符串中切出</param>
        /// <returns></returns>
        public static string GetStringByByte(ref string input, Encoding encoding, int cutLen, int cutStart = 0, bool isNeedCutOut = true)
        {
            if (string.IsNullOrWhiteSpace(input) || encoding == null || cutLen <= 0 || cutStart < 0)
                return null;

            string result = string.Empty, ir = input;
            int cur = 0, esp = 0;
            while (cur < input.Length)
            {
                char cc = input[cur];
                byte[] bs = encoding.GetBytes(new char[] { cc });
                if (esp < cutStart)
                {
                    esp += bs.Length;
                    cur++;
                    continue;
                }
                if (esp > cutStart && result == string.Empty)
                    return null;
                if (encoding.GetBytes(result).Length + bs.Length > cutLen)
                    return null;
                if (esp >= cutStart)
                    result += input[cur];
                if (encoding.GetBytes(result).Length == cutLen)
                {
                    if (isNeedCutOut)
                        input = input.Remove(input.IndexOf(result), result.Length);
                    return result;
                }
                esp += bs.Length;
                cur++;
            }
            return null;
        }

        /// <summary>
        /// 按位填充字符串
        /// </summary>
        /// <param name="oriStr">原字符串</param>
        /// <param name="encoding">字符编码</param>
        /// <param name="len">填充结果长度</param>
        /// <param name="spaceChar">填充用字符</param>
        /// <param name="isRightSpace">填充方向</param>
        /// <returns></returns>
        public static string SpaceStringByByte(string oriStr, Encoding encoding, int len, char spaceChar, bool isRightSpace)
        {
            if (oriStr == null)
                oriStr = string.Empty;
            if (encoding == null || len <= 0 || oriStr.Length > len)
                return null;
            string result = null;
            int count = 0;
            foreach (char c in oriStr)
            {
                byte[] bs = encoding.GetBytes(new char[] { c });
                count += bs.Length;
                if (count > len)
                    return null;
                result += c;
            }
            while (count < len)
            {
                count++;
                if (isRightSpace)
                    result += spaceChar;
                else
                    result = spaceChar + result;
            }
            return result;
        }

        /// <summary>
        /// 读取\\uXXXX格式的UTF8字符串
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static string ReadUTF8String(string input)
        {
            if (string.IsNullOrWhiteSpace(input))
                return input;
            string result = null;
            string[] arr = input.Split(new string[] { "\\u" }, StringSplitOptions.RemoveEmptyEntries);
            try
            {
                foreach (string s in arr)
                    result += (char)Convert.ToInt32(s.Substring(0, 4), 16) + s.Substring(4);
                return result;
            }
            catch { }
            return null;
        }

        /// <summary>
        /// 比较两个同类型实体，提取出值不相同的字段
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="oldObject">旧的实体</param>
        /// <param name="newObject">新的实体</param>
        /// <param name="ignore">忽略的字段名</param>
        /// <returns></returns>
        public static string CompareValue<T>(T oldObject, T newObject, List<string> ignore = null) where T : class, new()
        {
            if (oldObject == null && newObject == null)
                return null;
            oldObject = oldObject ?? new T();
            newObject = newObject ?? new T();

            try
            {
                StringBuilder sb = new StringBuilder();
                Type type = typeof(T);
                PropertyInfo[] Props = type.GetProperties(BindingFlags.Public | BindingFlags.Instance);
                foreach (PropertyInfo p in Props)
                {
                    if (ignore != null && ignore.Contains(p.Name))
                        continue;
                    object oldValue = p.GetValue(oldObject, null);
                    object newValue = p.GetValue(newObject, null);
                    string o = null, n = null;
                    if (oldValue != null)
                        o = oldValue.ToString();
                    if (newValue != null)
                        n = newValue.ToString();
                    if (o != n)
                        sb.AppendFormat("PropertyName:{0},OldValue:{1},NewValue:{2}|", p.Name, o, n);
                }
                return sb.ToString().TrimEnd('|');
            }
            catch
            {
                return null;
            }
        }
    }
}
