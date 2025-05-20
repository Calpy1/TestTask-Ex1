namespace TestEx1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Choose an option:\n\nCompress \"string\"\nDecompress \"string\"\n"); 
            string userText = Console.ReadLine(); //Получаем строку от пользователя
            string[] parts = userText.Split(' ', StringSplitOptions.RemoveEmptyEntries); //Делим строку по ' ', игнорируем пустые элементы

            if (parts.Length < 2) //Нам необходимо две части
            {
                Console.WriteLine("Invalid input");
                return;
            }

            string command = parts[0]; //Команда. Compress или Decompress
            string info = parts[1]; //Часть для компрессии или декомпрессии
            string output = string.Empty; //Переменная для результата

            CompressionEngine compressionEngine = new CompressionEngine(info);

            if (command.StartsWith("co", StringComparison.OrdinalIgnoreCase))
            {
                output = compressionEngine.Compression();
            }

            if (command.StartsWith("de", StringComparison.OrdinalIgnoreCase))
            {
                output = compressionEngine.Decompression();
            }

            Console.WriteLine(output);
        }
    }
}
