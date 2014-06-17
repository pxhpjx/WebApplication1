using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using System.Xml;
using System.Xml.Serialization;

namespace WebApplication1
{
    public static class LogRecord
    {
        private static string LogPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Log");

        #region 文本日志

        /// <summary>
        /// 将字符串数组作为日志记录。每个字符串占用一行。
        /// </summary>
        /// <param name="content"></param>
        public static void WriteLog(string[] content, string type = null)
        {
            string fileName = DateTime.Now.ToString("yyyy-MM-dd") + ".log";
            string dirPath = LogPath;
            if (!string.IsNullOrWhiteSpace(type))
                dirPath = Path.Combine(LogPath, type);
            WriteFile(dirPath, fileName, content);
        }

        /// <summary>
        /// 记录自动附加时间的简单日志。
        /// </summary>
        /// <param name="content"></param>
        public static void WriteLog(string content, string type = null, bool isSingleLine = true)
        {
            string fileName = DateTime.Now.ToString("yyyy-MM-dd") + ".log";
            string dirPath = LogPath;
            if (!string.IsNullOrWhiteSpace(type))
                dirPath = Path.Combine(LogPath, type);
            if (isSingleLine)
                content = string.Format("[{0}]\t{1}", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff"), content);
            else
                content = string.Format("[{0}]\r\n{1}\r\n", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff"), content);
            WriteFile(dirPath, fileName, content);
        }

        public static void WriteLog(LogInfo log)
        {
            if (log != null)
                WriteLog(log.ToStringArray(), log.Type.ToString());
        }

        /// <summary>
        /// 记录字符串数组到文件。每个字符串占用一行。
        /// </summary>
        /// <param name="dirPath"></param>
        /// <param name="fileName"></param>
        /// <param name="content"></param>
        /// <param name="encoding"></param>
        /// <param name="fileMode"></param>
        private static void WriteFile(string dirPath, string fileName, string[] content, string encoding = "UTF-8", FileMode fileMode = FileMode.OpenOrCreate)
        {
            if (content == null || content.Length == 0)
                return;

            FileStream stream = null;
            try
            {
                if (!Directory.Exists(dirPath))
                    Directory.CreateDirectory(dirPath);

                stream = new FileStream(Path.Combine(dirPath, fileName), fileMode, FileAccess.Write);
                StreamWriter writer = new StreamWriter(stream, Encoding.GetEncoding(encoding));
                writer.BaseStream.Seek(0, SeekOrigin.End);
                foreach (string str in content)
                    writer.WriteLine(str);
                writer.Flush();
                writer.Close();
            }
            catch (Exception ex)
            {
                WriteLog("Save Error：" + ex.Message, "SelfError");
            }
            if (stream != null)
                stream.Close();
        }

        /// <summary>
        /// 记录字符串到文件。
        /// </summary>
        /// <param name="dirPath"></param>
        /// <param name="fileName"></param>
        /// <param name="content"></param>
        /// <param name="encoding"></param>
        /// <param name="fileMode"></param>
        private static void WriteFile(string dirPath, string fileName, string content, string encoding = "UTF-8", FileMode fileMode = FileMode.OpenOrCreate)
        {
            FileStream stream = null;
            try
            {
                if (!Directory.Exists(dirPath))
                    Directory.CreateDirectory(dirPath);

                stream = new FileStream(Path.Combine(dirPath, fileName), fileMode, FileAccess.Write);
                StreamWriter writer = new StreamWriter(stream, Encoding.GetEncoding(encoding));
                writer.BaseStream.Seek(0, SeekOrigin.End);
                writer.WriteLine(content);
                writer.Flush();
                writer.Close();
            }
            catch { }
            if (stream != null)
                stream.Close();
        }

        public static string ReadFile(string filePath, string encoding = "UTF-8")
        {
            string result = null;
            try
            {
                StreamReader reader = new StreamReader(filePath, UnicodeEncoding.GetEncoding(encoding));
                result = reader.ReadToEnd();
                reader.Close();
            }
            catch { }
            return result;
        }

        #endregion

        #region XML日志

        /// <summary>
        /// 记录不包含子节点简单格式XML日志
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="Item"></param>
        /// <param name="Subfolder"></param>
        public static void WriteSampleXmlLog<T>(T Item, string Subfolder = "")
        {
            XmlDocument doc = new XmlDocument();
            XmlDeclaration dec = doc.CreateXmlDeclaration("1.0", "UTF-8", null);
            doc.AppendChild(dec);
            XmlElement root;
            try { root = doc.CreateElement(typeof(T).ToString()); }
            catch { root = doc.CreateElement("DefaultRootNode"); }
            doc.AppendChild(root);

            Type type = typeof(T);
            object obj = Activator.CreateInstance(type);
            PropertyInfo[] Props = type.GetProperties(BindingFlags.Public | BindingFlags.Instance);
            foreach (PropertyInfo p in Props)
            {
                string ElementName = p.Name.Substring(0);
                object ElementValue = p.GetValue(Item, null);
                XmlElement element = doc.CreateElement(ElementName);
                element.InnerText = ElementValue == null ? "" : ElementValue.ToString();
                root.AppendChild(element);
            }
            string Path = LogPath + "\\" + Subfolder;
            if (!Directory.Exists(Path))
                Directory.CreateDirectory(Path);
            doc.Save(Path + (Subfolder != "" ? "\\" : "") + DateTime.Now.ToString("yyyyMMddHHmmssfff") + ".xml");
        }

        /// <summary>
        /// 读取指定文件夹中指定数目的XML日志
        /// </summary>
        /// <param name="Amount"></param>
        /// <param name="Subfolder"></param>
        /// <returns></returns>
        public static List<XmlDocument> ReadXmlLogs(int Amount, string Subfolder = "")
        {
            List<XmlDocument> Result = new List<XmlDocument>();
            try
            {
                string[] Files = System.IO.Directory.GetFiles(LogPath + (string.IsNullOrWhiteSpace(Subfolder) ? "" : "\\") + Subfolder, "*.xml");
                if (Amount > Files.Length)
                    Amount = Files.Length;
                for (int i = Files.Length - 1; i >= Files.Length - Amount; i--)
                {
                    XmlDocument Doc = new XmlDocument();
                    Doc.Load(Files[i]);
                    Result.Add(Doc);
                }
            }
            catch { }
            return Result;
        }

        /// <summary>
        /// 读取指定文件夹中指定数目的日志实体
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="Amount"></param>
        /// <param name="Subfolder"></param>
        /// <returns></returns>
        public static List<T> ReadXmlLogs<T>(int Amount, string Subfolder = "")
        {
            List<T> Result = new List<T>();
            try
            {
                string[] Files = System.IO.Directory.GetFiles(LogPath + (string.IsNullOrWhiteSpace(Subfolder) ? "" : "\\") + Subfolder, "*.xml");
                if (Amount > Files.Length)
                    Amount = Files.Length;
                for (int i = Files.Length - 1; i >= Files.Length - Amount; i--)
                {
                    XmlSerializer serializer = new XmlSerializer(typeof(T));
                    XmlReader xr = XmlReader.Create(Files[i], null);
                    T x = (T)serializer.Deserialize(xr);
                    Result.Add(x);
                }
            }
            catch { }
            return Result;
        }

        /// <summary>
        /// 写可序列化实体的XML日志
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="item"></param>
        /// <param name="Subfolder"></param>
        public static void WriteSerXmlLog<T>(T item, string Subfolder = "")
        {
            XmlDocument xml = new XmlDocument();
            XmlSerializer serializer = new XmlSerializer(typeof(T));
            string Path = LogPath + "\\" + Subfolder;
            if (!Directory.Exists(Path))
                Directory.CreateDirectory(Path);
            XmlWriter xw = XmlWriter.Create(Path + (Subfolder != "" ? "\\" : "") + DateTime.Now.ToString("yyyyMMddHHmmssfff") + ".xml");
            serializer.Serialize(xw, item);
            xw.Close();
        }

        /// <summary>
        /// 读可序列化实体的XML日志
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="Path"></param>
        /// <returns></returns>
        public static T ReadSerXmlLog<T>(string Path)
        {
            if (File.Exists(Path))
            {
                XmlSerializer serializer = new XmlSerializer(typeof(T));
                XmlReader xr = XmlReader.Create(Path, null);
                T x = (T)serializer.Deserialize(xr);
                return x;
            }
            else
                return default(T);
        }

        #endregion
    }


    public partial class LogInfo
    {
        public DateTime Time { get; set; }

        public string Message { get; set; }

        public LogType Type { get; set; }

        public virtual string[] ToStringArray()
        {
            string[] result = new string[3];
            DateTime d = DateTime.Now;
            if (Time != default(DateTime))
                d = Time;
            result[0] = "Time:\t" + d.ToString("yyyy-MM-dd HH:mm:ss.fff");
            result[1] = "Message:\r\n" + Message;
            result[2] = "";
            return result;
        }
    }

    public enum LogType
    {
        Debug = 0,
        Error = 1,
        Warn = 2,
        Info = 3
    }
}
