using System.IO;

namespace ConsoleUI
{
    class Program
    {
        static void Main()
        {
            string path = CheckForPath();
            int fileAmount = CheckForAmount();
            string[] filenames = AddFilenames(path);
            string[] filenamesRandomized = RandomizeFiles(filenames, fileAmount);
            Copy(path, filenamesRandomized);
            Console.WriteLine("Done! Press any key to exit...");
        }
        static string HandleInput(string message)
        {
            Console.WriteLine(message);
            string? input = @Console.ReadLine();
            if (input is null)
                input = "";
            return input;
        }
        static int CheckForAmount()
        {
            bool isAmountCorrect = Int32.TryParse(HandleInput("How many files do you want to randomize?"), out int amount);
            if (!isAmountCorrect)
            {
                Console.WriteLine("Incorrect amount inputted, defaulting to 10");
                amount = 10;
            }
            return amount;
        }

        static string CheckForPath()
        {
            string output = HandleInput("Please enter the path: ");
            while (!Directory.Exists(output))
            {
                output = HandleInput("Please enter a correct path.");
            }
            return output;
        }
        static string[] AddFilenames(string path)
        {
            string[] filenames = Directory.GetFiles(path);
            return filenames;
        }
        static string[] RandomizeFiles(string[] filenames, int amount)
        {
            Random rnd = new();
            string[] randomized = new string[amount];
            for (int i = 0; i < amount; i++)
            {
                int current = rnd.Next(filenames.Length);
                randomized[i] = filenames[current];
            }
            return randomized;
        }
        static void Copy(string path, string[] randomized)
        {
            DirectoryInfo dir = new(path);
            dir.CreateSubdirectory("Copied");
            for(int i = 0; i < randomized.Length; i++)
            {
                File.Copy(randomized[i], @$"{path}\Copied\file{i + 1}.jpg", true);
            }
        }
    }
}
