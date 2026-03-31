using System;
using System.IO;

namespace Modularr1
{
    public static class task1
    {
        private delegate string TextOperation(string input);

        public static void Run()
        {
            string file1 = "textPD25.txt";
            string file2 = "resultPD25.txt";

            File.WriteAllText(file1, "C# is good\nPD25 testing this code\nEnd of file");
            File.WriteAllText(file2, "");

            TextOperation op1 = ToUpperText;
            TextOperation op2 = CountChars;
            TextOperation op3 = CountWords;

            ProcessFile(file1, file2, op1);
            ProcessFile(file1, file2, op2);
            ProcessFile(file1, file2, op3);

            Console.WriteLine("Готово");
        }

        static void ProcessFile(string inPath, string outPath, TextOperation operation)
        {
            string text = File.ReadAllText(inPath);
            string result = operation(text);
            File.AppendAllText(outPath, result + "\n-------------\n");
        }

        static string ToUpperText(string text)
        {
            return text.ToUpper();
        }

        static string CountChars(string text)
        {
            return "Кількість символів: " + text.Length;
        }

        static string CountWords(string text)
        {
            string[] words = text.Split(new char[] { ' ', '\n' }, StringSplitOptions.RemoveEmptyEntries);
            return "Кількість слів: " + words.Length;
        }
    }
}
