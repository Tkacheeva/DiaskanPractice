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

        public static string[] Hashing(string[] paths)
        {
            byte[] hashBytes;
            int i = 0;
            string[] res = paths;
            foreach (string path in paths)
            {
                using (var inputFileStream = File.OpenRead(path))
                {
                    var md5 = MD5.Create();
                    hashBytes = md5.ComputeHash(inputFileStream);
                    res[i] = ByteArrayToString(hashBytes);
                    i++;
                }
            }
            return res;
        }
    }
}
