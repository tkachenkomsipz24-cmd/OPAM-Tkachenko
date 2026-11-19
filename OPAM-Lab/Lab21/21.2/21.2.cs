using System;
using System.IO;
using System.Text;

namespace Lab21_Task1_Read
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;

            string filePath = @"C:\Users\tkace\OneDrive\Desktop\Name.txt";

            if (!File.Exists(filePath))
            {
                Console.WriteLine("Помилка: файл Name.txt не знайдено! Зчитування неможливе.");
                Console.ReadLine();
                return;
            }

            Console.WriteLine("Імена з файлу, які починаються на літеру 'А':\n");

            bool found = false;
            using (StreamReader sr = new StreamReader(filePath, Encoding.UTF8))
            {
                while (!sr.EndOfStream)
                {
                    string line = sr.ReadLine();
                    if (!string.IsNullOrWhiteSpace(line))
                    {
                        string trimmed = line.Trim();
                        if (trimmed.StartsWith("А", StringComparison.OrdinalIgnoreCase) ||
                            trimmed.StartsWith("A", StringComparison.OrdinalIgnoreCase))
                        {
                            Console.WriteLine("- " + trimmed);
                            found = true;
                        }
                    }
                }
            }

            if (!found)
            {
                Console.WriteLine("Імен на літеру 'А' у файлі не знайдено.");
            }

            Console.ReadLine();
        }
    }
}