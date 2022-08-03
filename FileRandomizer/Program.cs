using System.IO;

namespace ConsoleUI
{
    class Program
    {
        static void Main()
        {
            string input = HandleInput("Please enter the path: ");
            int amount = 10;
            bool isAmountCorrect = Int32.TryParse(HandleInput("How many files do you want to randomize?"), out int result);
            if (isAmountCorrect)
            {
                amount = result;
            }
            else
                Console.WriteLine("Incorrect amount inputted, defaulting to 10"); ;
            string[] filenames = AddFilenames(input);
            string[] randomized = Randomize(filenames, amount);
            Copy(input, randomized);
        }
        static string HandleInput(string message)
        {
            Console.WriteLine(message);
            string? input = Console.ReadLine();
            if (input is null)
                input = "";
            return input;
        }
        public static string[] AddFilenames(string path)
        {
            string[] filenames = Directory.GetFiles(path);
            return filenames;
        }
        static string[] Randomize(string[] filenames, int amount)
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
