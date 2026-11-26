using System;
using System.IO;
using System.Text;
using System.Windows.Forms;

class Program
{
    static void Main()
    {
        Console.OutputEncoding = Encoding.UTF8;

        if (!File.Exists("Name.dat"))
        {
            Console.WriteLine("Файл Name.dat не знайдено! Спочатку запустіть першу програму.");
            Console.ReadLine();
            return;
        }

        StringBuilder result = new StringBuilder();
        int count = 0;

        using (FileStream f = new FileStream("Name.dat", FileMode.Open))
        using (BinaryReader r = new BinaryReader(f, Encoding.UTF8))
        {
            int n = r.ReadInt32();
            for (int i = 0; i < n; i++)
            {
                string name = r.ReadString();
                // Українська «А» та латинська «A»
                if (name.StartsWith("А", StringComparison.OrdinalIgnoreCase) ||
                    name.StartsWith("A", StringComparison.OrdinalIgnoreCase))
                {
                    result.AppendLine(name);
                    count++;
                }
            }
        }

        string text = count == 0
            ? "Імен, що починаються з літери А, немає."
            : "Імена, що починаються з літери А:\n" + result;

        Console.WriteLine(text);                    
        MessageBox.Show(text, "Результат");         
    }
}