using ExercicioDeFixacao.Entities;
using System.Globalization;

namespace Exemple_Path
{
    class Program
    {
        static void Main(string[] Args)
        {
            Console.WriteLine("Enter file full path: ");
            string sourceFile = Console.ReadLine();

            try
            {
                string[] lines = File.ReadAllLines(sourceFile);

                string sourceFolderPath = Path.GetDirectoryName(sourceFile);
                string targetFolderPath = @$"{sourceFolderPath}\out";
                string targetFile = @$"{targetFolderPath}\summary.csv";

                Directory.CreateDirectory(targetFolderPath);

                using (StreamWriter summary = File.AppendText(targetFile))
                {
                    foreach (string line in lines)
                    {
                        string[] fields = line.Split(',');
                        string name = fields[0];
                        double price = double.Parse(fields[1], CultureInfo.InvariantCulture);
                        int amount = int.Parse(fields[2]);

                        Product produto = new Product(name, price, amount);

                        summary.WriteLine($"{produto.Name},{produto.Total().ToString("F2", CultureInfo.InvariantCulture)}");
                    }
                }
            }
            catch (IOException e)
            {
                Console.WriteLine("An error occurred");
                Console.WriteLine(e.Message);
            }
            catch(SystemException e)
            {
                Console.WriteLine("An error occurred");
                Console.WriteLine(e.Message);
            }
        }
    }
}