using System;

namespace Lab18_Task1
{
    class Program
    {
        static bool InputDouble(ref double val, string prompt)
        {
            while (true)
            {
                Console.Write($"{prompt} (за замовчуванням {val}, Enter щоб залишити): ");
                string input = Console.ReadLine() ?? "";
                if (string.IsNullOrWhiteSpace(input))
                    return true;

                if (double.TryParse(input.Replace('.', ','), out double parsed) || 
                    double.TryParse(input.Replace(',', '.'), System.Globalization.NumberStyles.Any, System.Globalization.CultureInfo.InvariantCulture, out parsed))
                {
                    val = parsed;
                    return true;
                }
                Console.WriteLine("Помилка! Введіть коректне дійсне число.");
            }
        }

        static double CalculateExpression(double x, double y, double z)
        {
            double part1 = Math.Log10(Math.Abs(Math.Sin(x) + y)) / 87.0;
            double part2 = 234.0 / Math.Log10(Math.Abs(Math.Sin(x * y) + 3.0));
            double part3 = Math.Log10(Math.Abs(Math.Sin(3.1) + Math.Pow(x, 2) * y)) / z;
            return part1 + part2 + part3;
        }

        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            double x = 1.5, y = 0.1, z = 0.5;

            InputDouble(ref x, "Введіть x");
            InputDouble(ref y, "Введіть y");
            InputDouble(ref z, "Введіть z");

            if (z == 0)
            {
                Console.WriteLine("Помилка: ділення на нуль (z не може дорівнювати 0).");
                return;
            }

            double s = CalculateExpression(x, y, z);
            Console.WriteLine($"\nПри x = {x}, y = {y}, z = {z} значення виразу S = {s:F6}");
        }
    }
}