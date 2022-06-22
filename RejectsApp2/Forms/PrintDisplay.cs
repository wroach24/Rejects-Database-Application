using System;
using System.Data;
using System.Windows.Forms;
using Microsoft.Reporting.WinForms;
using RejectsApp2.Properties;

namespace RejectsApp2.Forms
{
    public partial class PrintDisplay : Form
    {
        private readonly EditReject editrejectForm;
        private NewReject newRejectForm;

        public PrintDisplay(NewReject newRejectForm)
        {
            InitializeComponent();
            this.newRejectForm = newRejectForm;
            reportViewer3.Reset();
            reportViewer3.Name = "ReportViewer";
            reportViewer3.TabIndex = 0;
            reportViewer3.Visible = true;
            var rpdSource = GenerateEmptyDataTableForReport();
            DisplayPrintReport(reportViewer3, rpdSource, this, newRejectForm);
            CenterToScreen();
        }

        public PrintDisplay(EditReject editRejectForm)
        {
            InitializeComponent();
            editrejectForm = editRejectForm;
            reportViewer3.Reset();
            reportViewer3.Name = "ReportViewer";
            reportViewer3.TabIndex = 0;
            reportViewer3.Visible = true;
            var rpdSource = GenerateEmptyDataTableForReport();
            DisplayPrintReport(reportViewer3, rpdSource, this, editrejectForm);
            CenterToScreen();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
        }

        //returns a temporary datatable to assign as the report's data, even though it will not be used since report will nto display otherwise
        public static ReportDataSource GenerateEmptyDataTableForReport()
        {
            var dt = new DataTable();
            dt.Columns.Add("x");
            var temp = dt.NewRow();
            temp["x"] = "temp";
            dt.Rows.Add(temp);
            var ds = new DataSet1();
            var rds = new ReportDataSource();
            ds.Tables.Add(dt);

            rds.Name = "DataSet1";
            rds.Value = ds.Tables[1];

            return rds;
        }

        //displays the print report with the below settings
        public static void DisplayPrintReport(ReportViewer reportViewer1, ReportDataSource rpdSource,
            PrintDisplay displayForm, NewReject newRejectForm)
        {
            reportViewer1.LocalReport.ReportPath = ConnectionSettings.Default.PrintReport;
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

        //displays the print report with the below settings
        public static void DisplayPrintReport(ReportViewer reportViewer1, ReportDataSource rpdSource,
            PrintDisplay displayForm, EditReject editRejectForm)
        {
            reportViewer1.LocalReport.ReportPath = ConnectionSettings.Default.PrintReport;
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

        //sets the parameters necessary to fill out the print form
        public static void SetPrintReportParameters(ReportViewer reportViewer1, NewReject newRejectForm)
        {
            var reportParams = new ReportParameterCollection();
            reportParams.Add(new ReportParameter("RejectTypeParameter", newRejectForm.RejectTypeDropDown.Text));
            reportParams.Add(new ReportParameter("RejectNumber", newRejectForm.RejectNumberTextBox.Text));
            reportParams.Add(new ReportParameter("PartNumber", newRejectForm.PartNumberTextBox.Text));
            reportParams.Add(new ReportParameter("SerialNumber", newRejectForm.SerialNumberTextBox.Text));
            reportParams.Add(new ReportParameter("DateRejected",
                newRejectForm.DateRejectedDropDown.Value.Date.ToShortDateString()));
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

        //sets the parameters necessary to fill out the print form
        public static void SetPrintReportParameters(ReportViewer reportViewer1, EditReject editRejectForm)
        {
            var reportParams = new ReportParameterCollection();
            reportParams.Add(new ReportParameter("RejectTypeParameter", editRejectForm.RejectTypeDropDown.Text));
            reportParams.Add(new ReportParameter("RejectNumber", editRejectForm.RejectNumberTextBox.Text));
            reportParams.Add(new ReportParameter("PartNumber", editRejectForm.PartNumberTextBox.Text));
            reportParams.Add(new ReportParameter("SerialNumber", editRejectForm.SerialNumberTextBox.Text));
            reportParams.Add(new ReportParameter("DateRejected",
                editRejectForm.DateRejectedDropDown.Value.Date.ToShortDateString()));
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