using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace PIB2C.WinUI
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new frmMain());
        }
    }
}
