using System;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Concurrent;
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

        public static void Hashing(string path)
        {
            byte[] hashBytes;
            string[] files = Directory.GetFiles(path, "*.*", SearchOption.AllDirectories);
            ConcurrentBag<string> res = new ConcurrentBag<string>();
            Parallel.ForEach(files, file =>
            {
                using (var inputFileStream = File.OpenRead(file))
                {
                    var md5 = MD5.Create();
                    hashBytes = md5.ComputeHash(inputFileStream);
                    res.Add(ByteArrayToString(hashBytes) + "\t" + file);
                }
            });
            File.WriteAllLines(path + "hash.txt", res.ToArray());
        }
    }
}
