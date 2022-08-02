using System.IO;

namespace ConsoleUI
{
    class Program
    {
        static void Main()
        {
            Console.Write("Please enter the path: ");
            string input = Console.ReadLine();
            string[] filenames;
            filenames = AddFilenames(input);
            string[] randomized = Randomize(filenames);
            Copy(input, randomized);
        }
        public static string[] AddFilenames(string path)
        {
            string[] filenames = Directory.GetFiles(path);
            return filenames;
        }
        static string[] Randomize(string[] filenames)
        {
            Random rnd = new();
            string[] randomized = new string[5];
            for (int i = 0; i < 5; i++)
            {
                int current = rnd.Next(filenames.Length);
                randomized[i] = filenames[current];
            }
            return randomized;
        }
        static void Copy(string path, string[] randomized)
        {
            DirectoryInfo dir = new DirectoryInfo(path);
            dir.CreateSubdirectory("Test");
            for(int i = 0; i < randomized.Length; i++)
            {
                File.Copy(randomized[i], @$"{path}\Test\file{i}.jpg", true);
            }
        }
    }
}
