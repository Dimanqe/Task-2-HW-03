using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_2_HW_03
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string URL = @"C:\\Users\\dsank\\Desktop\\Test";
            Console.WriteLine(GetDirectorySize(URL));
        }
        static long GetDirectorySize(string path)
        {
            long size = 0;
            try
            {
                DirectoryInfo directoryInfo = new DirectoryInfo(path);
                foreach (FileInfo file in directoryInfo.GetFiles())
                {
                    size += file.Length;
                }
                foreach (DirectoryInfo subDirectory in directoryInfo.GetDirectories())
                {
                    size += GetDirectorySize(subDirectory.FullName);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка при получении размера папки: {ex.Message}");
            }
            return size;
        }
    }
}
