using System;
using System.Data.SQLite;
using System.Threading;
using System.Windows.Forms;
using RejectsApp2.Properties;

namespace RejectsApp2
{
    internal class Backup
    {
        private Thread backupThread;
        private DateTime endOfMonth;
        private DateTime today;

        public Backup()
        {
            today = DateTime.Now.Date;
            endOfMonth = new DateTime(today.Year, today.Month, DateTime.DaysInMonth(today.Year, today.Month));
        }

        public void StartBackup()
        {
            try
            {
                backupThread = new Thread(Run_InitiateBackup);
                backupThread.IsBackground = true;
                backupThread.Start();
            }
            catch
            {
                MessageBox.Show("An error has occured backing up the database.");
                throw;
            }
        }
        public void StartBackup(char manualFlag)
        {
            try
            {
                backupThread = new Thread(() => Run_InitiateBackup('m'));
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
            var destinationPath = "";
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
                source.Close();
                destination.Close();
            }
        }
        
        private void Run_InitiateBackup(char manualFlag)
            //signals admin ran a manual backup
        {
            var sourcePath = ConnectionSettings.Default.connString;
            var destinationPath = ConnectionSettings.Default.manualBackup;

            using (var source = new SQLiteConnection(sourcePath))
            using (var destination = new SQLiteConnection(destinationPath))
            {
                source.Open();
                destination.Open();
                source.BackupDatabase(destination, "main", "main", -1, null, 0);
                source.Close();
                destination.Close();
            }
        }
    }
   
}