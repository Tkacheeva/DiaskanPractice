using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.IO.Compression;

namespace Archivation
{
    public class Archivator
    {
        public static void Compress(string path)
        {
            string[] sourceFile = Directory.GetFiles(path, "*.*", SearchOption.AllDirectories);
            string compressedFile = path + ".gz"; 
            foreach (string file in sourceFile)
            {
                using (FileStream sourceStream = new FileStream(file, FileMode.OpenOrCreate))
                {
                    using (FileStream targetStream = File.Create(compressedFile))
                    {
                        using (GZipStream compressionStream = new GZipStream(targetStream, CompressionMode.Compress))
                        {
                            sourceStream.CopyTo(compressionStream);
                        }
                    }
                }
            }
        }
    }
}
