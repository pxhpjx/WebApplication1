using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _Console
{
    class Program
    {
        static void Main(string[] args)
        {
            string filepath = Path.Combine("D:\\", "cpu.txt");


            string[] lines = System.IO.File.ReadAllLines(filepath,Encoding.GetEncoding("utf-8"));

            Console.WriteLine(ReadFile(filepath, "utf-8"));
            foreach (string line in lines) {
                //Console.WriteLine(line);
                string[] datas = line.Split(new string[] { "\t" },StringSplitOptions.None);
                //Console.WriteLine("-" + datas[0] + "-");
            }

            Console.ReadKey();
        }

        public static string ReadFile(string filePath,string encode="gb2312")
        {
            if (File.Exists(filePath)) {
                using (StreamReader vStreamReader = new StreamReader(filePath, UnicodeEncoding.GetEncoding(encode)))
                {
                    string tempStr = vStreamReader.ReadToEnd();
                    vStreamReader.Close();
                    return tempStr;
                }
            }
            return "";
            
        }
    }
}
