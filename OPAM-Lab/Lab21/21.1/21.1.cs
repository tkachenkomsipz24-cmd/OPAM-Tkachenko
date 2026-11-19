using System;
using System.IO;
using System.Text;

namespace Lab21_Task1_Write
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            Console.InputEncoding = Encoding.UTF8;

            string filePath = @"C:\Users\tkace\OneDrive\Desktop\Name.txt";

            int count;
            while (true)
            {
                Console.Write("Введіть кількість імен для запису у файл: ");
                if (int.TryParse(Console.ReadLine(), out count) && count > 0)
                    break;

                Console.WriteLine("Помилка! Введіть ціле додатне число.");
            }

            using (StreamWriter sw = new StreamWriter(filePath, false, Encoding.UTF8))
            {
                for (int i = 0; i < count; i++)
                {
                    string name;
                    while (true)
                    {
                        Console.Write($"Введіть {i + 1}-е ім'я: ");
                        name = Console.ReadLine()?.Trim();

                        if (!string.IsNullOrEmpty(name))
                            break;

                        Console.WriteLine("Ім'я не може бути порожнім! Повторіть введення.");
                    }

                    sw.WriteLine(name);
                }
            }

            Console.WriteLine($"\nДані успішно записано у файл: {filePath}");
            Console.ReadLine();
        }
    }
}