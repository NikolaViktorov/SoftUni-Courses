using System;
using System.IO;
using System.IO.Compression;

namespace _06._.Zip_and_Extract
{
    class Program
    {
        static void Main(string[] args)
        {
            string pic = "copyMe.png";
            string zipFile = @"..\..\..\myNewZip.zip";

            using (var archive = ZipFile.Open(zipFile, ZipArchiveMode.Create))
            {
                archive.CreateEntryFromFile(pic, Path.GetFileName(pic));
            }
        }
    }
}
