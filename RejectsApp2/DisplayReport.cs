using System;
using System.Data;
using System.Data.SQLite;
using System.Text;
using System.Transactions;
using System.Windows.Forms;
using System.Xml;
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


        private void reportViewer1_LoadAsync(object sender, EventArgs e)
        {
            var query =
                "SELECT * FROM rejects WHERE Date_of_Disposition >= '2022-03-10' ORDER BY Date_of_Disposition "; //ALTER
            var dt = GetValueFromDatabase(query);
            var ds = new DataSet1();
            var rds = new ReportDataSource();

            ds.Tables.Add(dt);

            //changing report to the report path, need to relative path before publishing.
            //reportViewer1.LocalReport.ReportPath =
            //    @"C:\Users\30053901\source\repos\RejectsApp2\RejectsApp2\Report2.rdlc"; //ConnectionSettings.Default.testReportFile;
            LecturaRDLCXML(dt, @"C:\Users\30053901\source\repos\RejectsApp2\RejectsApp2\Report2.rdlc",
                @"C:\Users\30053901\source\repos\RejectsApp2\RejectsApp2\Report3.rdlc");

            reportViewer1.LocalReport.ReportPath =
                @"C:\Users\30053901\source\repos\RejectsApp2\RejectsApp2\Report3.rdlc";
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
            //reportViewer1.LocalReport.DataSources.Clear();
            //reportViewer1.LocalReport.DataSources.Add(rds);
            //reportViewer1.PrinterSettings.DefaultPageSettings.Margins.Bottom = 0;
            //reportViewer1.PrinterSettings.DefaultPageSettings.Margins.Top = 0;
            //reportViewer1.PrinterSettings.DefaultPageSettings.Margins.Left = 0;
            //reportViewer1.PrinterSettings.DefaultPageSettings.Margins.Right = 0;
            //reportViewer1.LocalReport.SetParameters(new ReportParameter("rejectNumColumVisible", "false"));
            //reportViewer1.SetDisplayMode(DisplayMode.PrintLayout);
            //reportViewer1.ZoomMode = ZoomMode.PageWidth;
            //reportViewer1.RefreshReport();
        }

        public DataTable GetValueFromDatabase(string query)
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


        private void DisplayReport_FormClosing(object sender, FormClosingEventArgs e)
        {
            home.Show();
        }

        private void LecturaRDLCXML(DataTable datos, string rutaActualRDLC, string rutaNuevaRDLC)
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

        private string CrearTablaDeReporteXML(DataTable datos)
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
                sb.AppendLine("        <Width>" + 10.5 / (float)datos.Columns.Count + "in</Width>");
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
                        "              <Textbox Name='Textbox{0}'><CanGrow>true</CanGrow><KeepTogether>true</KeepTogether><Paragraphs><Paragraph><TextRuns><TextRun><Value>{1}</Value><Style><FontSize>8pt</FontSize></Style></TextRun></TextRuns><Style/></Paragraph></Paragraphs><rd:DefaultName>Textbox2</rd:DefaultName><Style><Border><Color>LightGrey</Color><Style>Solid</Style></Border><PaddingLeft>2pt</PaddingLeft><PaddingRight>2pt</PaddingRight><PaddingTop>2pt</PaddingTop><PaddingBottom>2pt</PaddingBottom></Style></Textbox>",
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