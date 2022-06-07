using System;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Reporting.WinForms;
using RejectsApp2.Properties;
using static RejectsApp2.Commands;

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


        private  void reportViewer1_LoadAsync(object sender, EventArgs e)
        {
            var query =
                "SELECT * FROM rejects WHERE Date_of_Disposition >= '2022-03-10' ORDER BY Date_of_Disposition "; //ALTER
            var dt =  GetValuesForReport(query);
            var ds = new DataSet1();
            var rds = new ReportDataSource();

            ds.Tables.Add(dt);

            //changing report to the report path, need to relative path before publishing.
            reportViewer1.LocalReport.ReportPath = ConnectionSettings.Default.testReportFile;

            var names = reportViewer1.LocalReport.GetDataSourceNames();
            rds.Name = names[0];
            rds.Value = ds.Tables[1]; //assigning the report datasource to the datatable obtained from query

            reportViewer1.LocalReport.DataSources.Clear();
            reportViewer1.LocalReport.DataSources.Add(rds);
            reportViewer1.PrinterSettings.DefaultPageSettings.Margins.Bottom = 0;
            reportViewer1.PrinterSettings.DefaultPageSettings.Margins.Top = 0;
            reportViewer1.PrinterSettings.DefaultPageSettings.Margins.Left = 0;
            reportViewer1.PrinterSettings.DefaultPageSettings.Margins.Right = 0;
            reportViewer1.SetDisplayMode(DisplayMode.PrintLayout);
            reportViewer1.ZoomMode = ZoomMode.PageWidth;
            reportViewer1.RefreshReport();
        }


        private void DisplayReport_FormClosing(object sender, FormClosingEventArgs e)
        {
            home.Show();
        }
    }
}