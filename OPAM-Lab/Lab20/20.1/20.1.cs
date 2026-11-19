using System;
using System.IO;
using System.Windows.Forms;
using Microsoft.VisualBasic;

namespace Lab20_1
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] writers = new string[5];

            for (int i = 0; i < writers.Length; i++)
            {
            povtorI:
                writers[i] = Interaction.InputBox($"Введіть прізвище {(i + 1)}-го улюбленого письменника:", "Введення даних");

                if (string.IsNullOrWhiteSpace(writers[i]))
                {
                    if (MessageBox.Show("Прізвище не введено!\n\nБажаєте повторити?", "Увага",
                        MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
                    {
                        goto povtorI;
                    }
                    else
                    {
                        return;
                    }
                }
            }

            string mainPath = @"C:\Users\tkace\OneDrive\Desktop\Tkachenko.txt";
            string flashPath = @"D:\Shportko.txt";

            File.WriteAllLines(mainPath, writers);

            if (File.Exists(flashPath))
            {
                File.Delete(flashPath);
            }

            File.Copy(mainPath, flashPath);

            MessageBox.Show("Дані успішно збережено у файл та скопійовано!", "Результати",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}