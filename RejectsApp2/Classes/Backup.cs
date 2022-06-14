using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.IO;
using System.IO.Pipes;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using RejectsApp2.Properties;

namespace RejectsApp2
{
    class Backup
    {
        private DateTime today;
        private DateTime endOfMonth;
        private Thread backupThread;
        public Backup()
        {
            today = DateTime.Now.Date;
            endOfMonth = new DateTime(today.Year, today.Month, DateTime.DaysInMonth(today.Year,today.Month));
        }

        public void StartBackup()
        {
            try
            {
                backupThread = new Thread(new ThreadStart(Run_InitiateBackup));
                backupThread.IsBackground = true;
                backupThread.Start();
            }
            catch
            {
                MessageBox.Show("An error has occured backing up the database.");
                throw;
            }



        }
        private void Run_InitiateBackup()
        {
            var sourcePath = ConnectionSettings.Default.connString;
            string destinationPath ="";
            if (today.DayOfWeek == DayOfWeek.Friday)
                destinationPath = ConnectionSettings.Default.fridayBackup;

            else if (endOfMonth.Day == today.Day)
                destinationPath = ConnectionSettings.Default.endOfMonthBackup;

            else return;


            using (var source = new SQLiteConnection(sourcePath))
            using (var destination = new SQLiteConnection(destinationPath))
            {
                source.Open();
                destination.Open();
                source.BackupDatabase(destination, "main", "main", -1, null, 0);
            }



        }
    }
}
