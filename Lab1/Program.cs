using System;
using System.Linq;
using System.Windows.Forms;

namespace Lab1
{
    public static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        /// 


        //Task:

        // +, -, *, / (binar operations)
        //^ (put number in the power)

        // mod, div

        // =, <, >

        // <=, >=, <>

        public static string ComputeColumnName(int number)
        {
            if (number < 0)
            {
                return "";
            }
            string columnName = "";
            if (number < 26)
            {
                return ((char)(number % 26 + 65)).ToString();
            }
            columnName += ((char)(number % 26 + 65)).ToString();
            columnName += ComputeColumnName(number / 26 - 1);
            return columnName;
        }

        public static string Reverse(string s)
        {
            char[] charArray = s.ToCharArray();
            Array.Reverse(charArray);
            return new string(charArray);
        }

        public static string PrintColumnName(int number)
        {
           return Reverse(ComputeColumnName(number));
        }


        public static (string, int) ParseIdentifier(string identifier)
        {
            var columnRow = ("", 0);
            var row = "";

            foreach (var t in identifier.Where(t => t >= 'A' && t <= 'Z'))
            {
                columnRow.Item1 += t.ToString();
            }

            foreach (var t in identifier.Where(t => t >= '0' && t <= '9'))
            {
                row += t.ToString();
            }

            columnRow.Item2 = int.Parse(row);

            return columnRow;
        }


        [STAThread]
        static void Main()
        {
            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }
}
