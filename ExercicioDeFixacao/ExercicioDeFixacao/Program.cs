using ExercicioDeFixacao.Entities;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;

namespace Exemple_Path
{
    class Program
    {
        static void Main(string[] Args)
        {
            Console.WriteLine("Enter file full path: ");
            string sourceFile = Console.ReadLine();

            List<Product> produtos = new List<Product>();
            try
            {
                string sourceFolderPath = Path.GetDirectoryName(sourceFile);
                string targetFolderPath = @$"{sourceFolderPath}\out";
                string targetFile = @$"{targetFolderPath}\summary.csv";

                string[] lines = File.ReadAllLines(sourceFile);

                Directory.CreateDirectory(targetFolderPath);

                foreach (string line in lines)
                {
                    string[] fields = line.Split(',');
                    string name = fields[0];
                    double price = double.Parse(fields[1], CultureInfo.InvariantCulture);
                    int amount = int.Parse(fields[2]);
                    produtos.Add(new Product(name, price, amount));
                }
                using (StreamWriter summary = File.AppendText(targetFile))
                {
                    foreach (Product produto in produtos)
                    {
                        summary.WriteLine($"{produto.Name},{produto.Total().ToString("F2",CultureInfo.InvariantCulture)}");
                    }
                }
            }
            catch (IOException e)
            {
                Console.WriteLine("An error occurred");
                Console.WriteLine(e.Message);
            }
        }
    }
}