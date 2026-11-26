using System;
using System.IO;
using System.Text;

class Program
{
    static void Main()
    {
        Console.OutputEncoding = Encoding.UTF8;
        Console.InputEncoding = Encoding.UTF8;

        int n;
        Console.Write("Скільки імен ввести? ");
        while (!int.TryParse(Console.ReadLine(), out n) || n <= 0)
            Console.Write("Помилка! Введіть натуральне число: ");

        using (FileStream f = new FileStream("Name.dat", FileMode.Create))
        using (BinaryWriter w = new BinaryWriter(f, Encoding.UTF8))
        {
            w.Write(n);

            for (int i = 0; i < n; i++)
            {
                string name;
                Console.Write($"Ім'я №{i + 1}: ");
                while (true)
                {
                    name = Console.ReadLine().Trim();
                    // перевірка: не порожнє і містить лише літери
                    bool ok = name.Length > 0;
                    foreach (char c in name)
                        if (!char.IsLetter(c) && c != '\'' && c != '-') ok = false;
                    if (ok) break;
                    Console.Write("Помилка! Ім'я має містити лише літери. Повторіть: ");
                }
                w.Write(name);
            }
        }
        Console.WriteLine("Файл Name.dat створено.");
        Console.ReadLine();
    }
}