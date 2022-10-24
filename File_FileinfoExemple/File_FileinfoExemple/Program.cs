using System.IO;

namespace File_FileinfoExemple
{
    class Program
    {
        static void Main(string[] args)
        {
            string sorcePath = @"c:\temp\file1.txt";
            string targetPath = @"c:\temp\file2.txt";

            try
            {
                FileInfo fileInfo = new FileInfo(sorcePath);
                fileInfo.CopyTo(targetPath);
                string[] lines = File.ReadAllLines(targetPath);
                foreach (string line in lines)
                {
                    Console.WriteLine(line);
                }
            }
            catch (IOException e)
            {

                Console.WriteLine("An error occured");
                Console.WriteLine(e.Message);
            }
        }
    }
}