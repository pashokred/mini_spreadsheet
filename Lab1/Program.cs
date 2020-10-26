using System;
using System.Windows.Forms;

namespace Lab1
{
    internal static class Program
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
            (string, int) columnRow = ("", 0);
            string row = "";

            for (int i = 0; i < identifier.Length; ++i)
            {
                if (identifier[i] >= 'A' && identifier[i] <= 'Z')
                {
                    columnRow.Item1 += identifier[i].ToString();
                }
            }
            for (int i = columnRow.Item1.Length; i < identifier.Length; ++i)
            {
                if (identifier[i] >= '0' && identifier[i] <= '9')
                {
                    row += identifier[i].ToString();
                }
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
