using System;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Security.Cryptography;

namespace Hash
{
    public class Hash
    {
        private static string ByteArrayToString(byte[] arrInput)
        {
            int i;
            StringBuilder sOutput = new StringBuilder(arrInput.Length);
            for (i = 0; i < arrInput.Length - 1; i++)
            {
                sOutput.Append(arrInput[i].ToString("X2"));
            }
            return sOutput.ToString();
        }

        public static string[] Hashing(string path)
        {
            byte[] hashBytes;
            int i = 0;
            string[] files = Directory.GetFiles(path, "*.*", SearchOption.AllDirectories); ;
            foreach (string file in files)
            {
                using (var inputFileStream = File.OpenRead(file))
                {
                    var md5 = MD5.Create();
                    hashBytes = md5.ComputeHash(inputFileStream);
                    files[i] = ByteArrayToString(hashBytes);
                    i++;
                }
            }
            return files;
        }
    }
}
