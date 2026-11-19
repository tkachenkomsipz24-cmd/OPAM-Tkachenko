using System;

namespace Lab18_Task3
{
    class Program
    {
        static int InputInt(string prompt)
        {
            while (true)
            {
                Console.Write(prompt);
                if (int.TryParse(Console.ReadLine(), out int val) && val > 0)
                    return val;
                Console.WriteLine("Помилка! Введіть натуральне (ціле додатне) число.");
            }
        }

        static int GCD(int a, int b)
        {
            if (b == 0)
                return a;
            return GCD(b, a % b);
        }

        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            int a = InputInt("Введіть перше натуральне число: ");
            int b = InputInt("Введіть друге натуральне число: ");

            int result = GCD(a, b);
            Console.WriteLine($"\nНайбільший спільний дільник чисел {a} та {b} дорівнює: {result}");
        }
    }
}