using System;
using System.Windows.Forms;
using Microsoft.VisualBasic;

namespace UnitTkachenko
{
    public static class analizText
    {
        public static bool rozdilZnak(char c)
        {
            if (c == ' ' || c == '.' || c == ',' || c == ':' || c == ';')
                return true;
            else
                return false;
        }
    }

    public static class corectInput
    {
        public static bool inputDouble(ref double x, string povidom)
        {
            string s = x.ToString();
        Povtor:
            s = Interaction.InputBox(povidom, "Введення", s);
            try
            {
                x = Convert.ToDouble(s);
            }
            catch (System.FormatException)
            {
                if (MessageBox.Show("Ви вели не дійсне число.\n\nБажаєте повторити?", "Увага",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                    goto Povtor;
                else
                    return false;
            }
            return true;
        }

        public static bool inputInt(ref int x, string povidom)
        {
            string s = x.ToString();
        Povtor:
            s = Interaction.InputBox(povidom, "Введення", s);
            try
            {
                x = Convert.ToInt32(s);
            }
            catch (System.FormatException)
            {
                if (MessageBox.Show("Ви вели не ціле число.\n\nБажаєте повторити?", "Увага",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                    goto Povtor;
                else
                    return false;
            }
            return true;
        }
    }
}