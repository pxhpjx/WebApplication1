using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1
{
    public partial class base64 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //string res = File.ReadAllText(@"C:\Users\PangJiaxi\Desktop\fairyselect", Encoding.UTF8);
            ////string response = AesDecrypt(res);

            //string kkk = "-----BEGIN PUBLIC KEY-----\nMFwwDQYJKoZIhvcNAQEBBQADSwAwSAJBAM5U06JAbYWdRBrnMdE2bEuDmWgUav7x\nNKm7i8s1Uy/\nfvpvfxLeoWowLGIBKz0kDLIvhuLV8Lv4XV0+aXdl2j4kCAwEAAQ=\n=\n-----END PUBLIC KEY-----";

            //                            HAioZTZXFFo04qGwqNDcG/5/1R2M2p/GyvkwNJROK/JiNIEM0MX9J/Jkyz87Z/JBttIz+kZa892BbblXMHBSyQ==
            //string k = AesDecryptASCII("oXADrnUapwDsO2yaAVyOLKFZypWRi3fUW89Vz2t/5TXrHe2wWTAj2JMiHHQKYKG2B4GfREflZTL3YnZQSSykUw==", kkk);
            ////AESDecrypttoSingle(@"C:\Users\PangJiaxi\Desktop\fairyselect");

            //DecryptTextFromFile(@"C:\Users\PangJiaxi\Desktop\fairyselect");
            string u16 = ":\xcf\xd9\x0e\x10\xa5k\x05 \xe6f\xc0)\x03+\xa8";
            string u16d = "Os/ZDhClawUg5mbAKQMrqA==\n";


        }

        public static string AesDecrypt(string str, string key = "rBwj1MIAivVN222b")
        {
            if (string.IsNullOrEmpty(str))
                return null;

            Byte[] toEncryptArray = Encoding.UTF8.GetBytes(str);
            int l = str.Length;

            RijndaelManaged rm = new RijndaelManaged();
            rm.Key = Encoding.UTF8.GetBytes(key);
            rm.Mode = CipherMode.ECB;
            rm.Padding = PaddingMode.Zeros;
            ICryptoTransform cTransform = rm.CreateDecryptor();
            try
            {
                Byte[] resultArray = cTransform.TransformFinalBlock(toEncryptArray, 0, toEncryptArray.Length);

                return Encoding.UTF8.GetString(resultArray);
            }
            catch { }
            return null;
        }

        public static string AesDecrypt64(string str, string key = "rBwj1MIAivVN222b")
        {
            if (string.IsNullOrEmpty(str))
                return null;

            Byte[] toEncryptArray = Convert.FromBase64String(str);

            RijndaelManaged rm = new RijndaelManaged();
            rm.Key = Encoding.UTF8.GetBytes(key);
            rm.Mode = CipherMode.ECB;
            rm.Padding = PaddingMode.Zeros;
            ICryptoTransform cTransform = rm.CreateDecryptor();

            Byte[] resultArray = cTransform.TransformFinalBlock(toEncryptArray, 0, toEncryptArray.Length);
            return Convert.ToBase64String(resultArray);
        }

        public static string AesDecryptASCII(string str, string key = "rBwj1MIAivVN222b")
        {
            if (string.IsNullOrEmpty(str))
                return null;

            Byte[] toEncryptArray = Convert.FromBase64String(str);

            RijndaelManaged rm = new RijndaelManaged();
            rm.Key = Convert.FromBase64String(key);
            rm.Mode = CipherMode.ECB;
            rm.Padding = PaddingMode.Zeros;
            ICryptoTransform cTransform = rm.CreateDecryptor();

            Byte[] resultArray = cTransform.TransformFinalBlock(toEncryptArray, 0, toEncryptArray.Length);
            return Convert.ToBase64String(resultArray);
        }

        public static bool AESDecrypttoSingle(string filePath, string strKey = "rBwj1MIAivVN222b")//(解密文件路径，解密密码)
        {
            string dir = Directory.GetParent(filePath).ToString();
            Rijndael aes = Rijndael.Create();

            FileStream fs = File.OpenRead(filePath);

            aes.Key = Encoding.UTF8.GetBytes(strKey);

            //byte[] decryptBytes = new byte[(int)fs.Length];
            //fs.Read(decryptBytes, 0, (int)fs.Length);
            //fs.Close();

            byte[] decryptBytes = Convert.FromBase64String("oXADrnUapwDsO2yaAVyOLKFZypWRi3fUW89Vz2t/5TXrHe2wWTAj2JMiHHQKYKG2B4GfREflZTL3YnZQSSykUw==");

            MemoryStream ms = new MemoryStream(decryptBytes);
            CryptoStream cs = new CryptoStream(fs, aes.CreateDecryptor(), CryptoStreamMode.Read);
            StreamReader sReader = new StreamReader(cs);

            string val = null;

            try
            {
                // Read the data from the stream 
                // to decrypt it.
                val = sReader.ReadLine();


            }
            catch (Exception e)
            {
                Console.WriteLine("An error occurred: {0}", e.Message);
            }

            cs.Read(decryptBytes, 0, decryptBytes.Length);//填充无效，无法被移除。
            cs.FlushFinalBlock();
            fs.Close();
            fs = File.OpenWrite(dir + "\\Encryption.txt");
            foreach (byte b in ms.ToArray())
            {
                fs.WriteByte(b);
            }
            fs.Close();
            cs.Close();
            ms.Close();
            return true;


        }


        public static string DecryptTextFromFile(String FileName)
        {
            try
            {
                // Create or open the specified file. 
                FileStream fStream = File.Open(FileName, FileMode.OpenOrCreate);

                // Create a new Rijndael object.
                Rijndael RijndaelAlg = Rijndael.Create();
                RijndaelAlg.Key = Encoding.UTF8.GetBytes("rBwj1MIAivVN222b");
                //RijndaelAlg.Key = Convert.FromBase64String("rBwj1MIAivVN222b");

                // Create a CryptoStream using the FileStream 
                // and the passed key and initialization vector (IV).
                CryptoStream cStream = new CryptoStream(fStream,
                    RijndaelAlg.CreateDecryptor(),
                    CryptoStreamMode.Read);

                // Create a StreamReader using the CryptoStream.
                StreamReader sReader = new StreamReader(cStream);

                string val = null;

                try
                {
                    // Read the data from the stream 
                    // to decrypt it.
                    val = sReader.ReadLine();


                }
                catch (Exception e)
                {
                    Console.WriteLine("An error occurred: {0}", e.Message);
                }
                finally
                {

                    // Close the streams and
                    // close the file.
                    sReader.Close();
                    cStream.Close();
                    fStream.Close();
                }

                // Return the string. 
                return val;
            }
            catch (CryptographicException e)
            {
                Console.WriteLine("A Cryptographic error occurred: {0}", e.Message);
                return null;
            }
            catch (UnauthorizedAccessException e)
            {
                Console.WriteLine("A file error occurred: {0}", e.Message);
                return null;
            }
        }
    }
}
