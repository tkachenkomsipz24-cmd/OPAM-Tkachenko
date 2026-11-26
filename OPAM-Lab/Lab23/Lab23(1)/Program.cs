using System;
using System.IO;
using System.Text;

class Program
{
    const int NameLen = 30;

    static void Main()
    {
        Console.OutputEncoding = Encoding.UTF8;
        Console.InputEncoding = Encoding.UTF8;

        int n;
        Console.Write("Скільки імен ввести? ");
        while (!int.TryParse(Console.ReadLine(), out n) || n <= 0)
            Console.Write("Помилка! Введіть натуральне число: ");

        FileStream f = new FileStream("Name.dat", FileMode.Create);
        BinaryWriter w = new BinaryWriter(f, Encoding.Unicode);

        for (int i = 0; i < n; i++)
        {
            string name;
            while (true)
            {
                Console.Write("Ім'я №" + (i + 1) + ": ");
                name = (Console.ReadLine() ?? "").Trim();
                bool ok = name.Length > 0 && name.Length <= NameLen;
                foreach (char c in name)
                    if (!char.IsLetter(c) && c != '\'' && c != '-')
                        ok = false;
                if (ok) break;
                Console.WriteLine("Помилка! Лише літери, довжина від 1 до " + NameLen + ".");
            }
            w.Write(name.PadRight(NameLen));
        }

        w.Close();
        Console.WriteLine("Файл Name.dat створено. Розмір: " + new FileInfo("Name.dat").Length + " байт.");
        Console.ReadLine();
    }
}