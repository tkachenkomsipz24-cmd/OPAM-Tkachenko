using System;
using System.IO;
using System.Text;

class Program
{
    const int NameLen = 30;
    const int LenZap = 1 + NameLen * 2;

    static void Main()
    {
        Console.OutputEncoding = Encoding.UTF8;
        Console.InputEncoding = Encoding.UTF8;

        if (!File.Exists("Name.dat"))
        {
            Console.WriteLine("Файл Name.dat не знайдено!");
            Console.ReadLine();
            return;
        }

        long sizeBefore = new FileInfo("Name.dat").Length;

        int k;
        Console.Write("Скільки імен дописати? ");
        while (!int.TryParse(Console.ReadLine(), out k) || k <= 0)
            Console.Write("Помилка! Введіть натуральне число: ");

        FileStream f = new FileStream("Name.dat", FileMode.Open, FileAccess.Write);
        BinaryWriter w = new BinaryWriter(f, Encoding.Unicode);
        w.BaseStream.Seek(0, SeekOrigin.End);

        for (int i = 0; i < k; i++)
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
        Console.WriteLine("Розмір до дозапису: " + sizeBefore + " байт.");
        Console.WriteLine("Розмір після дозапису: " + new FileInfo("Name.dat").Length + " байт.");
        Console.ReadLine();
    }
}
