using System;

namespace Lab18_Task2
{
    class Program
    {
        static double InputDouble(string prompt, double defaultValue)
        {
            while (true)
            {
                Console.Write($"{prompt} (Enter для {defaultValue}): ");
                string input = Console.ReadLine() ?? "";
                if (string.IsNullOrWhiteSpace(input))
                    return defaultValue;

                if (double.TryParse(input.Replace(',', '.'), System.Globalization.NumberStyles.Any, System.Globalization.CultureInfo.InvariantCulture, out double result))
                    return result;

                Console.WriteLine("Помилка! Введіть число.");
            }
        }

        static double GetHeight(double y0, double v0, double t)
        {
            const double g = 9.8;
            return y0 + v0 * t - (g * t * t) / 2.0;
        }

        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            double y0 = InputDouble("Введіть початкову висоту y0 (м)", 1.0);
            double v0 = InputDouble("Введіть початкову швидкість v0 (м/с)", 20.0);

            double[] times = { 1.0, 2.0, 3.0 };

            Console.WriteLine("\nРезультати обчислень:");
            foreach (double t in times)
            {
                double h = GetHeight(y0, v0, t);
                Console.WriteLine($"Через {t} сек. висота м'яча становитиме: {h:F2} м");
            }
        }
    }
}