using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Reporting.WinForms;
using RejectsApp2.Properties;
using static RejectsApp2.Commands;

namespace RejectsApp2.Forms
{
    public partial class PrintDisplay : Form
    {
        private NewReject newRejectForm;
        private EditReject editrejectForm;
        public PrintDisplay(NewReject newRejectForm)
        {
            InitializeComponent();
            this.newRejectForm = newRejectForm;
            reportViewer3.Reset();
            this.reportViewer3.Name = "ReportViewer";
            this.reportViewer3.TabIndex = 0;
            this.reportViewer3.Visible = true;
            ReportDataSource rpdSource = GenerateEmptyDataTableForReport();
            DisplayPrintReport(reportViewer3, rpdSource, this, newRejectForm);
            CenterToScreen();
        }
        public PrintDisplay(EditReject editRejectForm)
        {
            InitializeComponent();
            this.editrejectForm = editRejectForm;
            reportViewer3.Reset();
            this.reportViewer3.Name = "ReportViewer";
            this.reportViewer3.TabIndex = 0;
            this.reportViewer3.Visible = true;
            ReportDataSource rpdSource = GenerateEmptyDataTableForReport();
            DisplayPrintReport(reportViewer3, rpdSource, this, editrejectForm);
            CenterToScreen();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            

        }
        public static ReportDataSource GenerateEmptyDataTableForReport()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("x");
            DataRow temp = dt.NewRow();
            temp["x"] = "temp";
            dt.Rows.Add(temp);
            var ds = new DataSet1();
            var rds = new ReportDataSource();
            ds.Tables.Add(dt);

            rds.Name = "DataSet1";
            rds.Value = ds.Tables[1];

            return rds;
        }

        public static void DisplayPrintReport(ReportViewer reportViewer1, ReportDataSource rpdSource, PrintDisplay displayForm, NewReject newRejectForm)
        {
            reportViewer1.LocalReport.ReportPath = ConnectionSettings.Default.PrintReport;
            var names = reportViewer1.LocalReport.GetDataSourceNames();
            reportViewer1.LocalReport.DataSources.Add(rpdSource);
            SetPrintReportParameters(reportViewer1, newRejectForm);


            reportViewer1.PrinterSettings.DefaultPageSettings.Margins.Bottom = 0;
            reportViewer1.PrinterSettings.DefaultPageSettings.Margins.Top = 0;
            reportViewer1.PrinterSettings.DefaultPageSettings.Margins.Left = 0;
            reportViewer1.PrinterSettings.DefaultPageSettings.Margins.Right = 0;
            reportViewer1.PrinterSettings.DefaultPageSettings.Landscape = false;
            reportViewer1.SetDisplayMode(DisplayMode.PrintLayout);
            reportViewer1.ZoomMode = ZoomMode.PageWidth;
            reportViewer1.RefreshReport();
            reportViewer1.Show();

        }
        public static void DisplayPrintReport(ReportViewer reportViewer1, ReportDataSource rpdSource, PrintDisplay displayForm, EditReject editRejectForm)
        {
            reportViewer1.LocalReport.ReportPath = ConnectionSettings.Default.PrintReport;
            var names = reportViewer1.LocalReport.GetDataSourceNames();
            reportViewer1.LocalReport.DataSources.Add(rpdSource);
            SetPrintReportParameters(reportViewer1, editRejectForm);


            reportViewer1.PrinterSettings.DefaultPageSettings.Margins.Bottom = 0;
            reportViewer1.PrinterSettings.DefaultPageSettings.Margins.Top = 0;
            reportViewer1.PrinterSettings.DefaultPageSettings.Margins.Left = 0;
            reportViewer1.PrinterSettings.DefaultPageSettings.Margins.Right = 0;
            reportViewer1.PrinterSettings.DefaultPageSettings.Landscape = false;
            reportViewer1.SetDisplayMode(DisplayMode.PrintLayout);
            reportViewer1.ZoomMode = ZoomMode.PageWidth;
            reportViewer1.RefreshReport();
            reportViewer1.Show();

        }

        public static void SetPrintReportParameters(ReportViewer reportViewer1, NewReject newRejectForm)
        {
            ReportParameterCollection reportParams = new ReportParameterCollection();
            reportParams.Add(new ReportParameter("RejectTypeParameter", newRejectForm.RejectTypeDropDown.Text));
            reportParams.Add(new ReportParameter("RejectNumber", newRejectForm.RejectNumberTextBox.Text));
            reportParams.Add(new ReportParameter("PartNumber", newRejectForm.PartNumberTextBox.Text));
            reportParams.Add(new ReportParameter("SerialNumber", newRejectForm.SerialNumberTextBox.Text));
            reportParams.Add(new ReportParameter("DateRejected", newRejectForm.DateRejectedDropDown.Value.Date.ToShortDateString()));
            reportParams.Add(new ReportParameter("PartDescription", newRejectForm.PartDescriptionTextBox.Text));
            reportParams.Add(new ReportParameter("LotNum", newRejectForm.LotNumberTextBox.Text));
            reportParams.Add(new ReportParameter("PONum", newRejectForm.PONumberTextBox.Text));
            reportParams.Add(new ReportParameter("Discrepancy", newRejectForm.DiscrepancyTextBox.Text));
            reportParams.Add(new ReportParameter("QtyRec", newRejectForm.QtyReceivedTextBox.Text));
            reportParams.Add(new ReportParameter("QtyIns", newRejectForm.QtyInspectedTextBox.Text));
            reportParams.Add(new ReportParameter("QtyRej", newRejectForm.QtyRejectedTextBox.Text));
            reportParams.Add(new ReportParameter("UnitCost", newRejectForm.UnitCostTextBox.Text));
            reportParams.Add(new ReportParameter("Responsible", newRejectForm.ResponsibleDropDown.Text));
            reportParams.Add(new ReportParameter("ProductLine", newRejectForm.ProductLineDropDown.Text));
            reportParams.Add(new ReportParameter("RejBy", newRejectForm.RejectedByDropDown.Text));
            reportParams.Add(new ReportParameter("Disposition", newRejectForm.DispositionDropDown.Text));
            reportParams.Add(new ReportParameter("VendorID", newRejectForm.VendorIDTextbox.Text));
            reportParams.Add(new ReportParameter("VendorName", newRejectForm.VendorNameDropDown.Text));
            reportParams.Add(new ReportParameter("RMANumber", newRejectForm.RMANumberTextBox.Text));
            reportParams.Add(new ReportParameter("DateofDisp", newRejectForm.dateDispositionDropDown.Text));
            reportViewer1.LocalReport.SetParameters(reportParams);
        }
        public static void SetPrintReportParameters(ReportViewer reportViewer1, EditReject editRejectForm)
        {
            ReportParameterCollection reportParams = new ReportParameterCollection();
            reportParams.Add(new ReportParameter("RejectTypeParameter", editRejectForm.RejectTypeDropDown.Text));
            reportParams.Add(new ReportParameter("RejectNumber", editRejectForm.RejectNumberTextBox.Text));
            reportParams.Add(new ReportParameter("PartNumber", editRejectForm.PartNumberTextBox.Text));
            reportParams.Add(new ReportParameter("SerialNumber", editRejectForm.SerialNumberTextBox.Text));
            reportParams.Add(new ReportParameter("DateRejected", editRejectForm.DateRejectedDropDown.Value.Date.ToShortDateString()));
            reportParams.Add(new ReportParameter("PartDescription", editRejectForm.PartDescriptionTextBox.Text));
            reportParams.Add(new ReportParameter("LotNum", editRejectForm.LotNumberTextBox.Text));
            reportParams.Add(new ReportParameter("PONum", editRejectForm.PONumberTextBox.Text));
            reportParams.Add(new ReportParameter("Discrepancy", editRejectForm.DiscrepancyTextBox.Text));
            reportParams.Add(new ReportParameter("QtyRec", editRejectForm.QtyReceivedTextBox.Text));
            reportParams.Add(new ReportParameter("QtyIns", editRejectForm.QtyInspectedTextBox.Text));
            reportParams.Add(new ReportParameter("QtyRej", editRejectForm.QtyRejectedTextBox.Text));
            reportParams.Add(new ReportParameter("UnitCost", editRejectForm.UnitCostTextBox.Text));
            reportParams.Add(new ReportParameter("Responsible", editRejectForm.ResponsibleDropDown.Text));
            reportParams.Add(new ReportParameter("ProductLine", editRejectForm.ProductLineDropDown.Text));
            reportParams.Add(new ReportParameter("RejBy", editRejectForm.RejectedByDropDown.Text));
            reportParams.Add(new ReportParameter("Disposition", editRejectForm.DispositionDropDown.Text));
            reportParams.Add(new ReportParameter("VendorID", editRejectForm.VendorIDTextbox.Text));
            reportParams.Add(new ReportParameter("VendorName", editRejectForm.VendorNameDropDown.Text));
            reportParams.Add(new ReportParameter("RMANumber", editRejectForm.RMANumberTextBox.Text));
            reportParams.Add(new ReportParameter("DateofDisp", editRejectForm.dateDispositionDropDown.Text));
            reportViewer1.LocalReport.SetParameters(reportParams);
        }
    }
}
