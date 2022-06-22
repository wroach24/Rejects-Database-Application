using System;
using System.Data;
using System.Data.SQLite;
using System.Globalization;
using System.Text;
using System.Transactions;
using System.Windows.Forms;
using System.Xml;
using Microsoft.Reporting.WinForms;
using RejectsApp2.Properties;
using static RejectsApp2.Commands;
using static RejectsApp2.CustomReportGenerator;
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
            var tableDt = GetValuesForForm("PRAGMA table_info(rejects) ");
            foreach (DataRow datarow in tableDt.Rows)
            {
                checkedListBox1.Items.Add(datarow.ItemArray[1].ToString());
                comboBox3.Items.Add(datarow.ItemArray[1].ToString());
            }

            FillOutDropMenu(productDt, comboBox1);
            FillOutDropMenu(responsibleDt, comboBox2);
        }


        private void button1_Click(object sender, EventArgs e)
        {
            var orderByString = "";
            var formatOfOrder = "";
            if (checkedListBox1.CheckedItems.Count == 0)
            {
                MessageBox.Show("Report cannot be empty.");
                return;
            }

            if (string.IsNullOrEmpty(comboBox3.Text))
                orderByString = "Date_of_Disposition ";
            else
                orderByString = comboBox3.Text + " ";

            if (comboBox4.Text == "Descending")
                formatOfOrder = "DESC";
            else
                formatOfOrder = "ASC";


            var query =
                "SELECT " + BuildCustomReportQuery(checkedListBox1.CheckedItems) + " FROM rejects ORDER BY " +
                orderByString + formatOfOrder + " LIMIT 1000 "; //ALTER
            var dt = GetValueFromDatabase(query);
            var ds = new DataSet1();
            var rds = new ReportDataSource();

            ds.Tables.Add(dt);

            //changing report to the report path, need to relative path before publishing.
            //reportViewer1.LocalReport.ReportPath =
            //    @"C:\Users\30053901\source\repos\RejectsApp2\RejectsApp2\Report2.rdlc"; //ConnectionSettings.Default.testReportFile;
            LecturaRDLCXML(dt, ConnectionSettings.Default.customReportFile,
                ConnectionSettings.Default.generatedCustomReport);

            reportViewer1.Reset();
            reportViewer1.LocalReport.ReportPath =
                ConnectionSettings.Default.generatedCustomReport;
            var names = reportViewer1.LocalReport.GetDataSourceNames();
            rds.Name = names[0];
            rds.Value = ds.Tables[1]; //assigning the report datasource to the datatable obtained from query

            reportViewer1.LocalReport.DataSources.Add(rds);
            reportViewer1.PrinterSettings.DefaultPageSettings.Margins.Bottom = 0;
            reportViewer1.PrinterSettings.DefaultPageSettings.Margins.Top = 0;
            reportViewer1.PrinterSettings.DefaultPageSettings.Margins.Left = 0;
            reportViewer1.PrinterSettings.DefaultPageSettings.Margins.Right = 0;
            reportViewer1.PrinterSettings.DefaultPageSettings.Landscape = true;
            reportViewer1.SetDisplayMode(DisplayMode.PrintLayout);
            reportViewer1.ZoomMode = ZoomMode.PageWidth;
            reportViewer1.RefreshReport();
            reportViewer1.Refresh();
            reportViewer1.LocalReport.Refresh();
            //maybe have in another method so that these values are properly cleared? if not have the report pop out
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
    }

    public static class GenerateDefinedReport
    {
        private const string startQuery = "SELECT * FROM Rejects";

        private static string GenerateWhereQuery(FormGenerator fields)
        {
            var whereQuery = " WHERE ";
            if (fields.dateTimePicker1.Checked || fields.dateTimePicker2.Checked)
            {
                DateTime? dispositionStartDateUserInput = null;
                DateTime? dispositionEndDateUserInput = null;
                var dateQuery = "";
                //checking if one date, no date, or both date boxes are checked and adjusting input accordingly
                if (fields.dateTimePicker1.Checked)
                    dispositionStartDateUserInput = fields.dateTimePicker1.Value.Date;
                else
                    dispositionStartDateUserInput = DateTime.MinValue;

                if (fields.dateTimePicker2.Checked)
                    dispositionEndDateUserInput = fields.dateTimePicker2.Value.Date;
                else
                    dispositionEndDateUserInput = DateTime.MaxValue;
                dateQuery = "Date_of_Disposition >= '" + dispositionStartDateUserInput.Value
                                .ToString("yyyy/MM/dd HH:mm:ss", CultureInfo.InvariantCulture).Replace("/", "-") +
                            "' AND Date_of_Disposition <= '" + dispositionEndDateUserInput.Value.Date
                                .ToString("yyyy/MM/dd HH:mm:ss", CultureInfo.InvariantCulture).Replace("/", "-") + "' ";
                whereQuery += dateQuery;
            }

            //if the text field isn't empty append the query for finding WHERE product_line equals value specified by the user
            if (!string.IsNullOrEmpty(fields.comboBox1.Text))
            {
                if (whereQuery != " WHERE ")
                    whereQuery += "AND ";

                var productQuery = "Product_Line = '" + fields.comboBox1.Text + "' ";
                whereQuery += productQuery;
            }

            //if the text field isn't empty append the query for finding WHERE responsible equals value specified by the user
            if (!string.IsNullOrEmpty(fields.comboBox2.Text))
            {
                if (whereQuery != " WHERE ")
                    whereQuery += "AND ";

                var responsibleQuery = "Responsible = '" + fields.comboBox2.Text + "' ";
                whereQuery += responsibleQuery;
            }

            //if the text field isn't empty append the query for finding WHERE vendor equals value specified by the user
            if (!string.IsNullOrEmpty(fields.textBox1.Text))
            {
                if (whereQuery != " WHERE ")
                    whereQuery += "AND ";

                var vendorQuery = "Vendor_ID = '" + fields.textBox1.Text + "' ";
                whereQuery += vendorQuery;
            }

            //if the text field isn't empty append the query for finding WHERE partnum equals value specified by the user
            if (!string.IsNullOrEmpty(fields.PartNumTextBox.Text))
            {
                if (whereQuery != " WHERE ")
                    whereQuery += "AND ";

                var productQuery = "Part_Number = '" + fields.PartNumTextBox.Text + "' ";
                whereQuery += productQuery;
            }

            //if all the forms are empty, replace the initial WHERE to nothing
            if (whereQuery == " WHERE ")
                return "";
            return whereQuery;
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
            if (string.IsNullOrEmpty(lastPortion)) ;
                //do nothing
            else if (whereQuery == "")
                whereQuery += " WHERE " + lastPortion;
            
            else
                whereQuery += " AND " + lastPortion;
            

            return startQuery + whereQuery + "ORDER BY Date_of_Disposition ASC";
        }

        private static string AppendQuery(string whereQuery, string lastPortion, string openTag)
        {
            //check if the lastportion of the query is null, check if the query has a where portion and adjust query accordingly.
            if (string.IsNullOrEmpty(lastPortion))
            {
            } //do nothing
            else if (whereQuery == "")
            {
                whereQuery += " WHERE " + lastPortion;
            }
            else
            {
                whereQuery += " AND " + lastPortion;
            }

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

    public static class CustomReportGenerator
    {
        public static DataTable GetValueFromDatabase(string query)
        {
            var connectionString = ConnectionSettings.Default.connString;
            using (var ds = new DataSet())
            {
                using (var da = new SQLiteDataAdapter(query, connectionString))
                {
                    using (var tran = new TransactionScope())
                    {
                        ds.Clear();
                        var dt = new DataTable();
                        da.Fill(dt);

                        tran.Complete();
                        return dt;
                    }
                }
            }
        }

        public static string BuildCustomReportQuery(CheckedListBox.CheckedItemCollection items)
        {
            var sb = new StringBuilder();
            sb.Append("");
            foreach (var item in items)
            {
                sb.Append(item);
                if (items[items.Count - 1] != item) sb.Append(",");
            }

            return sb.ToString();
        }

        public static void LecturaRDLCXML(DataTable datos, string rutaActualRDLC, string rutaNuevaRDLC)
        {
            //Read the report file into a XMLDocument
            var documento = new XmlDocument();
            documento.Load(rutaActualRDLC);

            //Select the node 'ReportItems' that apear when you add a Tablix element empty
            var aNode = documento.DocumentElement.FirstChild.FirstChild;

            //Override that node with your DataTable, the same DataTable you passed to a DataGridView
            aNode.InnerXml = CrearTablaDeReporteXML(datos);
            //Save the new file written
            documento.Save(rutaNuevaRDLC);
        }

        private static string CrearTablaDeReporteXML(DataTable datos)
        {
            var sb = new StringBuilder();
            sb.AppendLine("<Tablix Name='Tablix1'>");

            #region TablixBody

            sb.AppendLine("  <TablixBody>");

            #region Tablixcolumns

            sb.AppendLine("    <TablixColumns>");
            for (var i = 0; i < datos.Columns.Count; i++)
            {
                //Columns

                sb.AppendLine("      <TablixColumn>");
                sb.AppendLine("        <Width>" + 10.75 / (float)datos.Columns.Count + "in</Width>");
                sb.AppendLine("      </TablixColumn>");
            }

            sb.AppendLine("    </TablixColumns>");

            #endregion

            #region TablixRows

            sb.AppendLine("    <TablixRows>");

            #region Row header

            sb.AppendLine("<TablixRow>");
            sb.AppendLine("<Height>0.25in</Height>");
            sb.AppendLine("<TablixCells>");
            var numeroTexto = 1000;
            for (var i = 0; i < datos.Columns.Count; i++)
            {
                sb.AppendLine("<TablixCell>");
                sb.AppendLine("<CellContents>");
                sb.AppendLine(string.Format(
                    "<Textbox Name='Textbox{0}'><CanGrow>true</CanGrow><KeepTogether>true</KeepTogether><Paragraphs><Paragraph><TextRuns><TextRun><Value>{1}</Value><Style><FontSize>8pt</FontSize><FontWeight>Bold</FontWeight></Style></TextRun></TextRuns><Style/></Paragraph></Paragraphs><rd:DefaultName>Textbox1</rd:DefaultName><Style><Border><Color>LightGrey</Color><Style>Solid</Style></Border><BackgroundColor>LightGrey</BackgroundColor><PaddingLeft>2pt</PaddingLeft><PaddingRight>2pt</PaddingRight><PaddingTop>2pt</PaddingTop><PaddingBottom>2pt</PaddingBottom></Style></Textbox>",
                    numeroTexto, datos.Columns[i]));
                sb.AppendLine("</CellContents>");
                sb.AppendLine("</TablixCell>");
                numeroTexto++;
            }

            sb.AppendLine("</TablixCells>");
            sb.AppendLine("</TablixRow>");

            #endregion

            #endregion

            for (var i = 0; i < datos.Rows.Count; i++)
            {
                //Rows
                sb.AppendLine("      <TablixRow>");
                sb.AppendLine("        <Height>0.5in</Height>");
                sb.AppendLine("        <TablixCells>");
                for (var j = 0; j < datos.Columns.Count; j++)
                {
                    sb.AppendLine("          <TablixCell>");
                    sb.AppendLine("            <CellContents>");
                    sb.AppendLine(string.Format(
                        "              <Textbox Name='Textbox{0}'><CanGrow>true</CanGrow><KeepTogether>true</KeepTogether><Paragraphs><Paragraph><TextRuns><TextRun><Value>{1}</Value><Style><FontSize>12pt</FontSize></Style></TextRun></TextRuns><Style/></Paragraph></Paragraphs><rd:DefaultName>Textbox2</rd:DefaultName><Style><Border><Color>LightGrey</Color><Style>Solid</Style></Border><PaddingLeft>2pt</PaddingLeft><PaddingRight>2pt</PaddingRight><PaddingTop>2pt</PaddingTop><PaddingBottom>2pt</PaddingBottom></Style></Textbox>",
                        numeroTexto, datos.Rows[i].ItemArray[j].ToString().Replace("&", "")));
                    sb.AppendLine("            </CellContents>");
                    sb.AppendLine("          </TablixCell>");
                    numeroTexto++;
                }

                sb.AppendLine("        </TablixCells>");
                sb.AppendLine("      </TablixRow>");
            }

            sb.AppendLine("    </TablixRows>");
            sb.AppendLine("  </TablixBody>");

            #endregion

            sb.AppendLine("      <TablixColumnHierarchy>");
            sb.AppendLine("<TablixMembers>");
            for (var i = 0; i < datos.Columns.Count; i++)
                sb.AppendLine("<TablixMember />");
            sb.AppendLine("</TablixMembers>");
            sb.AppendLine("</TablixColumnHierarchy>");
            sb.AppendLine("      <TablixRowHierarchy>");
            sb.AppendLine("<TablixMembers>");
            sb.AppendLine("<TablixMember><KeepWithGroup>After</KeepWithGroup></TablixMember>");
            for (var i = 0; i < datos.Rows.Count; i++)
                sb.AppendLine("<TablixMember />");
            sb.AppendLine("</TablixMembers>");
            sb.AppendLine("</TablixRowHierarchy>");
            sb.AppendLine("      <Top>0.05556in</Top>");
            sb.AppendLine("      <Left>0.11458in</Left>");
            sb.AppendLine("      <Height>1.25in</Height>");
            sb.AppendLine("      <Width>8in</Width>");
            sb.AppendLine("      <Style>");
            sb.AppendLine("        <Border>");
            sb.AppendLine("          <Style>None</Style>");
            sb.AppendLine("        </Border>");
            sb.AppendLine("      </Style>");
            sb.AppendLine("      </Tablix>");
            return sb.ToString();
        }
    }
}