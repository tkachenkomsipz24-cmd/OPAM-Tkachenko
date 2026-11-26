using System;
using System.IO;
using System.Text;

class Program
{
    static void Main()
    {
        Console.OutputEncoding = Encoding.UTF8;
        Console.InputEncoding = Encoding.UTF8;

        if (!File.Exists("Name.dat"))
        {
            Console.WriteLine("Файл Name.dat не знайдено!");
            return;
        }

        int k;
        Console.Write("Скільки імен дописати? ");
        while (!int.TryParse(Console.ReadLine(), out k) || k <= 0)
            Console.Write("Помилка! Введіть натуральне число: ");

        using (FileStream f = new FileStream("Name.dat", FileMode.Open))
        {
            BinaryReader r = new BinaryReader(f, Encoding.UTF8);
            BinaryWriter w = new BinaryWriter(f, Encoding.UTF8);

            int n = r.ReadInt32();        
            f.Seek(0, SeekOrigin.Begin);
            w.Write(n + k);                
            f.Seek(0, SeekOrigin.End);     

            for (int i = 0; i < k; i++)
            {
                Console.Write($"Ім'я №{i + 1}: ");
                string name = Console.ReadLine().Trim();
                while (name.Length == 0)
                {
                    Console.Write("Порожній рядок! Повторіть: ");
                    name = Console.ReadLine().Trim();
                }
                w.Write(name);
            }
            w.Flush();
        }
        Console.WriteLine("Дані дописано.");
    }
}