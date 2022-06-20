using System;
using System.Windows.Forms;

namespace RejectsApp2
{
    internal static class Driver
    {
        [STAThread]
        private static void Main()
        {
            var backupDatabase = new Backup();
            backupDatabase.StartBackup();
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Home());
        }
    }
}