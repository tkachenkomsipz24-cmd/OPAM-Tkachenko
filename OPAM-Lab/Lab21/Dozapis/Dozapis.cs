using System;
using System.IO;
using System.Text;

namespace Lab21_Task2_Append
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            Console.InputEncoding = Encoding.UTF8;

            string filePath = @"C:\Users\tkace\OneDrive\Desktop\Name.txt";

            if (!File.Exists(filePath))
            {
                Console.WriteLine("Помилка: файл Name.txt ще не створено! Спочатку виконайте першу програму.");
                Console.ReadLine();
                return;
            }

            int addCount;
            while (true)
            {
                Console.Write("Скільки нових імен ви бажаєте дозаписати у файл? ");
                if (int.TryParse(Console.ReadLine(), out addCount) && addCount > 0)
                    break;

                Console.WriteLine("Помилка! Введіть ціле додатне число.");
            }

            using (StreamWriter sw = new StreamWriter(filePath, true, Encoding.UTF8))
            {
                for (int i = 0; i < addCount; i++)
                {
                    string name;
                    while (true)
                    {
                        Console.Write($"Введіть нове ім'я ({i + 1} з {addCount}): ");
                        name = Console.ReadLine()?.Trim();

                        if (!string.IsNullOrEmpty(name))
                            break;

                        Console.WriteLine("Ім'я не може бути порожнім!");
                    }

                    sw.WriteLine(name);
                }
            }

            Console.WriteLine("\nНові імена успішно дозаписано у файл Name.txt!");
            Console.WriteLine("Тепер знову запустіть Програму 2 для перевірки оновленого списку.");
            Console.ReadLine();
        }
    }
}