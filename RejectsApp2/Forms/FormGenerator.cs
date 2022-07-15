using System;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.Globalization;
using System.Text;
using System.Transactions;
using System.Windows.Forms;
using System.Xml;
using Microsoft.Reporting.WinForms;
using RejectsApp2.Properties;
using static RejectsApp2.Commands;
using static RejectsApp2.GenerateDefinedReport;

namespace RejectsApp2
{
    public partial class FormGenerator : Form
    {
        public FormGenerator()
        {
            InitializeComponent();
        }


        private void FormGenerator_Load(object sender, EventArgs e)
        {
            var productDt = GetValuesForForm("SELECT * FROM Product_Lines");
            var responsibleDt = GetValuesForForm("SELECT * FROM Responsible");

            FillOutDropMenu(productDt, comboBox1);
            FillOutDropMenu(responsibleDt, comboBox2);
        }


        private void button2_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            reportViewer2.Reset();
            GenerateScrapReport(this);
            Cursor = Cursors.Default;
        }

        private void reportViewer2_Load(object sender, EventArgs e)
        {
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            reportViewer2.Reset();
            GenerateReceivingReport(this);
            Cursor = Cursors.Default;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            reportViewer2.Reset();
            GenerateOpenItemReport(this);
            Cursor = Cursors.Default;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            reportViewer2.Reset();
            GenerateProductReport(this);
            Cursor = Cursors.Default;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            reportViewer2.Reset();

            if (!string.IsNullOrEmpty(PartNumTextBox.Text))
                GeneratePartNumReport(this);
            else
                MessageBox.Show("You cannot generate a part history report without a part number entered.");
            Cursor = Cursors.Default;
        }

        private void tabPage1_Click(object sender, EventArgs e)
        {
        }

        private void DisplayAllButton_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            Cursor = Cursors.WaitCursor;
            reportViewer2.Reset();
            GenerateAllReport(this);
            reportViewer2.ZoomMode = ZoomMode.FullPage;
            Cursor = Cursors.Default;
        }
    }

    public static class GenerateDefinedReport
    {
        private const string startQuery = "SELECT * FROM Rejects";

        private static string GenerateWhereQuery(FormGenerator fields)
        {
            var whereQuery = " WHERE ";
            var productLineValue = fields.comboBox1.Text;
            var responsibleLineValue = fields.comboBox2.Text;
            var vendorIDValue = fields.textBox1.Text;
            var partNumValue = fields.PartNumTextBox.Text;

            if (fields.dateTimePicker1.Checked || fields.dateTimePicker2.Checked)
            {
                DateTime? dispositionStartDateUserInput = null;
                DateTime? dispositionEndDateUserInput = null;
                var dateQuery = "";
                //checking if one date, no date, or both date boxes are checked and adjusting input accordingly

                dispositionStartDateUserInput = fields.dateTimePicker1.Checked ?  fields.dateTimePicker1.Value.Date : DateTime.MinValue;
               
                dispositionEndDateUserInput = fields.dateTimePicker2.Checked ?  fields.dateTimePicker2.Value.Date : DateTime.MaxValue;

                //after figuring out the date range input by user begin building query
                dateQuery = "Date_of_Disposition >= '" + dispositionStartDateUserInput.Value
                                .ToString("yyyy/MM/dd HH:mm:ss", CultureInfo.InvariantCulture).Replace("/", "-") +
                            "' AND Date_of_Disposition <= '" + dispositionEndDateUserInput.Value.Date
                                .ToString("yyyy/MM/dd HH:mm:ss", CultureInfo.InvariantCulture).Replace("/", "-") + "' ";
                whereQuery += dateQuery;
            }

            //if the text field isn't empty append the query for finding WHERE product_line equals value specified by the user

            if (!string.IsNullOrEmpty(productLineValue))
            {
                if (whereQuery != " WHERE ")
                    whereQuery += "AND ";

                var productQuery = "Product_Line = '" + productLineValue + "' ";
                whereQuery += productQuery;
            }

            //if the text field isn't empty append the query for finding WHERE responsible equals value specified by the user
            if (!string.IsNullOrEmpty(responsibleLineValue))
            {
                if (whereQuery != " WHERE ")
                    whereQuery += "AND ";

                var responsibleQuery = "Responsible = '" + responsibleLineValue + "' ";
                whereQuery += responsibleQuery;
            }

            //if the text field isn't empty append the query for finding WHERE vendor equals value specified by the user
            if (!string.IsNullOrEmpty(vendorIDValue))
            {
                if (whereQuery != " WHERE ")
                    whereQuery += "AND ";

                var vendorQuery = "Vendor_ID = '" + vendorIDValue + "' ";
                whereQuery += vendorQuery;
            }

            //if the text field isn't empty append the query for finding WHERE partnum equals value specified by the user
            if (!string.IsNullOrEmpty(partNumValue))
            {
                if (whereQuery != " WHERE ")
                    whereQuery += "AND ";

                var productQuery = "Part_Number = '" + partNumValue + "' OR Part_Number = '"+partNumValue.ToLower()+"' OR Part_Number = '" +partNumValue.ToUpper()+"'";
                whereQuery += productQuery;
            }

            //if all the forms are empty, return empty
            if (whereQuery == " WHERE ")
                return "";
            return whereQuery;
        }

        public static void GenerateAllReport(FormGenerator fields)
        {
            var path = ConnectionSettings.Default.allRepFile;
            var whereQuery = GenerateWhereQuery(fields);
            var finalQuery = AppendQuery(whereQuery,"");
            GenerateReport(finalQuery,fields,path);
        }
        public static void GeneratePartNumReport(FormGenerator fields)
        {
            var path = ConnectionSettings.Default.partNumRepFile;
            var whereQuery = GenerateWhereQuery(fields);
            var finalQuery = AppendQuery(whereQuery, "");
            GenerateReport(finalQuery, fields, path);
        }

        public static void GenerateProductReport(FormGenerator fields)
        {
            var path = ConnectionSettings.Default.productRepFile;
            var whereQuery = GenerateWhereQuery(fields);
            var lastPortion = "substr(Reject_Number,1,1) == 'L' ";
            var finalQuery = AppendQuery(whereQuery, lastPortion);
            GenerateReport(finalQuery, fields, path);
        }

        public static void GenerateReceivingReport(FormGenerator fields)
        {
            var path = ConnectionSettings.Default.recRepFile;
            var whereQuery = GenerateWhereQuery(fields);
            var lastPortion = "substr(Reject_Number,1,1) == 'R' ";
            var finalQuery = AppendQuery(whereQuery, lastPortion);
            GenerateReport(finalQuery, fields, path);
        }

        public static void GenerateOpenItemReport(FormGenerator fields)
        {
            var path = ConnectionSettings.Default.openRepFile;
            var whereQuery = GenerateWhereQuery(fields);
            var lastPortion = "(Disposition IS NULL OR Disposition == '') ";
            var finalQuery = AppendQuery(whereQuery, lastPortion, "");
            GenerateReport(finalQuery, fields, path);
        }

        public static void GenerateScrapReport(FormGenerator fields)
        {
            var path = ConnectionSettings.Default.scrapRepFile;
            var whereQuery = GenerateWhereQuery(fields);
            var lastPortion =
                "Disposition != 'Use as is' AND Disposition != 'Use after rework' AND Disposition != 'Return to vendor' AND Disposition != '' AND Disposition IS NOT NULL  ";
            var finalQuery = AppendQuery(whereQuery, lastPortion);
            GenerateReport(finalQuery, fields, path);
        }

        //appends the last portion of queries to form the final query
        private static string AppendQuery(string whereQuery, string lastPortion)
        {
            //check if the lastportion of the query is null, check if the query has a where portion and adjust query accordingly.
            if (whereQuery == "")
            {
                whereQuery += " WHERE " + lastPortion;
                return startQuery + whereQuery + "ORDER BY Date_of_Disposition ASC";
            }
            
            whereQuery = string.IsNullOrEmpty(lastPortion) ? whereQuery + " " : whereQuery += " AND " + lastPortion;
            return startQuery + whereQuery + "ORDER BY Date_of_Disposition ASC";
        }

        private static string AppendQuery(string whereQuery, string lastPortion, string openTag)
        {
            //check if the lastportion of the query is null, check if the query has a where portion and adjust query accordingly.
            
            whereQuery = whereQuery == "" ? whereQuery += " WHERE " + lastPortion : whereQuery += " AND " + lastPortion;

            return startQuery + whereQuery + "ORDER BY Date_Rejected ASC";
        }


        //generates the report using the finalquery
        private static void GenerateReport(string finalQuery, FormGenerator fields, string path)
        {
            try
            {
                var reportinfoDataTable = GetValuesForReport(finalQuery);
                var dataSource = new DataSet1();
                var reportDataSource = new ReportDataSource();
                dataSource.Tables.Add(reportinfoDataTable);

                fields.reportViewer2.LocalReport.ReportPath = path;


                var names = fields.reportViewer2.LocalReport.GetDataSourceNames();
                reportDataSource.Name = names[0];
                reportDataSource.Value = dataSource.Tables[1];
                fields.reportViewer2.LocalReport.DataSources.Clear();
                fields.reportViewer2.LocalReport.DataSources.Add(reportDataSource);
                DisplayReport(fields);
            }
            catch (ArgumentNullException e)
            {
                MessageBox.Show("No rejects matching your query exist.");
            }
        }

        //sets the report displayer settings and refreshes/displays the generated report
        private static void DisplayReport(FormGenerator fields)
        {
            fields.reportViewer2.PrinterSettings.DefaultPageSettings.Margins.Bottom = 0;
            fields.reportViewer2.PrinterSettings.DefaultPageSettings.Margins.Top = 0;
            fields.reportViewer2.PrinterSettings.DefaultPageSettings.Margins.Left = 0;
            fields.reportViewer2.PrinterSettings.DefaultPageSettings.Margins.Right = 0;
            fields.reportViewer2.PrinterSettings.DefaultPageSettings.Landscape = true;
            fields.reportViewer2.SetDisplayMode(DisplayMode.PrintLayout);
            fields.reportViewer2.ZoomMode = ZoomMode.PageWidth;
            fields.reportViewer2.RefreshReport();
            fields.reportViewer2.Refresh();
        }
    }

   
}