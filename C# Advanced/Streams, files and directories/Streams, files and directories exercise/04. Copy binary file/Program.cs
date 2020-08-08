using System;
using System.IO;

namespace _04._Copy_binary_file
{
    class Program
    {
        static void Main(string[] args)
        {
            string picPath = "copyMe.png";
            string picCopyPath = "copyMe-copy.png";

            using (FileStream reader = new FileStream(picPath, FileMode.Open))
            {
                using (FileStream writer = new FileStream(picCopyPath, FileMode.Create))
                {
                    while (true)
                    {
                        byte[] buffer = new byte[4096];

                        int size = reader.Read(buffer, 0, buffer.Length);
                        if (size == 0)
                        {
                            break;
                        }
                        writer.Write(buffer, 0, size);
                    }
                }
            }
        }
    }
}
