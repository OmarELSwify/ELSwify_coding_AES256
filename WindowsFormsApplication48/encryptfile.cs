using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Security.Cryptography;

namespace WindowsFormsApplication48
{
  public   class encryptfile
    {
        private TripleDESCryptoServiceProvider des = new TripleDESCryptoServiceProvider();
        public encryptfile(string key)
        {
            des.Key = UTF8Encoding.UTF8.GetBytes(key);
            des.Mode = CipherMode.ECB;
        }
public void encrypt(string filepath)
        {
            byte[] Bytes = File.ReadAllBytes(filepath);
            byte[] ebytes = des.CreateEncryptor().TransformFinalBlock(Bytes, 0, Bytes.Length);
            File.WriteAllBytes(filepath, ebytes);
        }
        public void decrypt(string filepath)
        {
            byte[] Bytes = File.ReadAllBytes(filepath);
            byte[] dbytes = des.CreateDecryptor().TransformFinalBlock(Bytes, 0, Bytes.Length);
            File.WriteAllBytes(filepath,dbytes);
        }
    }
}
