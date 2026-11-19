using System;
using System.IO;
using System.Windows.Forms;

namespace Lab20_2
{
    class Program
    {
        static void Main(string[] args)
        {
            string filePath = @"C:\Users\tkace\OneDrive\Desktop\Tkachenko.txt";

            if (!File.Exists(filePath))
            {
                MessageBox.Show("Файл із даними письменників відсутній.\n\nЗчитування виконати неможливо!", "Увага",
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            string[] writers = File.ReadAllLines(filePath);

            string res = "";
            for (int i = 0; i < writers.Length; i++)
            {
                res += $"{i + 1}. {writers[i]}\n";
            }

            MessageBox.Show("Перелік улюблених письменників:\n\n" + res, "Результати",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}