namespace Exemple_DirectoryDirectoryInfo
{
    class Program
    {
        static void Main(string[] Args)
        {
            string path = @"c:\temp\myfolder";

            try
            {
                // Listar todas as SubPastas dentro da pasta "myfolder"
                IEnumerable<string> folders = Directory.EnumerateDirectories(path, "*.*", SearchOption.AllDirectories);
                Console.WriteLine("FOLDERS :");
                foreach (string s in folders)
                {
                    Console.WriteLine(s);
                }
                Console.WriteLine();

                //Listar os arquivos a partir de uma pasta seleconada
                IEnumerable<string> files = Directory.EnumerateFiles(path, "*.*", SearchOption.AllDirectories);
                Console.WriteLine("FILES :");
                foreach (string s in files)
                {
                    Console.WriteLine(s);
                }
                Console.WriteLine();

                //Criar uma pasta
                Directory.CreateDirectory($@"{path}\newfolder"); //Basta prover o caminho completo para a nova pasta

            }
            catch(IOException e)
            {
                Console.WriteLine("An error occurred");
                Console.WriteLine(e.Message);
            }
        }
    }
}