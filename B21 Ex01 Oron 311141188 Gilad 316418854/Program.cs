using System;
using System.Windows.Forms;

namespace B21_Ex01_Oron_311141188_Gilad_316418854
{
    public static class Program
    {
        [STAThread]
        public static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm());
        }
    }
}