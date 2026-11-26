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

        if (!File.Exists("Name.dat"))
        {
            Console.WriteLine("Файл Name.dat не знайдено! Спочатку запустіть першу програму.");
            Console.ReadLine();
            return;
        }

        FileStream f = new FileStream("Name.dat", FileMode.Open);
        BinaryReader r = new BinaryReader(f, Encoding.Unicode);

        int countZap = (int)(r.BaseStream.Length / LenZap);
        if (countZap == 0)
        {
            Console.WriteLine("Дані відсутні!");
            r.Close();
            Console.ReadLine();
            return;
        }

        Console.WriteLine("Розмір файлу: " + r.BaseStream.Length + " байт, записів: " + countZap);
        Console.WriteLine("Імена, що починаються з літери А:");

        int found = 0;
        for (int i = 0; i < countZap; i++)
        {
            r.BaseStream.Seek((long)i * LenZap, SeekOrigin.Begin);
            string name = r.ReadString().TrimEnd();
            if (name.StartsWith("А", StringComparison.OrdinalIgnoreCase) ||
                name.StartsWith("A", StringComparison.OrdinalIgnoreCase))
            {
                Console.WriteLine(name);
                found++;
            }
        }

        if (found == 0)
            Console.WriteLine("Таких імен немає.");

        r.Close();
        Console.ReadLine();
    }
}