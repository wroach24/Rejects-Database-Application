using System;
using System.Windows.Forms;
using Microsoft.Reporting.WinForms;
using RejectsApp2.Properties;

namespace RejectsApp2
{
    public partial class DisplayReport : Form
    {
        public Home home;

        public DisplayReport(Home home)
        {
            InitializeComponent();
            this.home = home;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            var conString = ConnectionSettings.Default.connString;
            var query =
                "SELECT * FROM rejects ORDER BY Date_Rejected DESC LIMIT 1000"; //ALTER
            var path = ConnectionSettings.Default.excelString;
            var cmd = new Commands();
            var dt = cmd.GetValuesForReport(query);
            //var oledbConn = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + path +
            //                                    ";Extended Properties='Excel 12.0;HDR=YES;IMEX=1;';");

            //oledbConn.Open();

            var ds = new DataSet1();
            ds.Tables.Add(dt);

            var rds = new ReportDataSource();
            reportViewer1.LocalReport.ReportPath =
                @"C:\Users\30053901\source\repos\RejectsApp2\RejectsApp2\Report1.rdlc";
            var names = reportViewer1.LocalReport.GetDataSourceNames();
            rds.Name = names[0];
            rds.Value = ds.Tables[1];
            //foreach (DataColumn column in ds.Tables)
            //{
            //    MessageBox.Show(column.ToString());
            //}
            reportViewer1.LocalReport.DataSources.Clear();
            reportViewer1.LocalReport.DataSources.Add(rds);
            reportViewer1.PrinterSettings.DefaultPageSettings.Margins.Bottom = 0;
            reportViewer1.PrinterSettings.DefaultPageSettings.Margins.Top = 0;
            reportViewer1.PrinterSettings.DefaultPageSettings.Margins.Left = 0;
            reportViewer1.PrinterSettings.DefaultPageSettings.Margins.Right = 0;
            reportViewer1.SetDisplayMode(DisplayMode.PrintLayout);
            reportViewer1.ZoomMode = ZoomMode.PageWidth;
            reportViewer1.RefreshReport();


            //var ds = new DataSet();

            //var cmd = new OleDbCommand();
            //cmd.Connection = oledbConn;
            //cmd.CommandType = CommandType.Text;

            //cmd.CommandText = "SELECT Reject_Number FROM [Sheet1$]";


            //var oleda = new OleDbDataAdapter();
            //oleda = new OleDbDataAdapter(cmd);
            //oleda.Fill(ds);
            //ds.Tables[0].TableName = "DataTable1";
        }

        private void button1_Click(object sender, EventArgs e)
        {
        }

        private void reportViewer1_Load(object sender, EventArgs e)
        {
        }

        private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
        }

        private void dataGridView1_CellContentClick_2(object sender, DataGridViewCellEventArgs e)
        {
        }

        private void DisplayReport_FormClosing(object sender, FormClosingEventArgs e)
        {
            home.Show();
        }
    }
}