using System;
using System.Data;
using System.Data.SQLite;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using Microsoft.Office.Interop.Excel;
using RejectsApp2.Properties;
using Application = Microsoft.Office.Interop.Excel.Application;
using DataTable = System.Data.DataTable;

namespace RejectsApp2
{
    public class ExcelCreation
    {
        private string excelType;

        public ExcelCreation(string type)
        {
            excelType = type;
        }

        public void SrapDoc()
        {
            var path = ConnectionSettings.Default.notspecexcelString +
                       DateTime.Now.Date.ToShortDateString().Replace('/', '-') + "RejectFormType.xlsx";
            MessageBox.Show(path);
            var conString = ConnectionSettings.Default.connString;
            var query =
                "SELECT Rejects.Reject_Number,Rejects.Date_Rejected,Rejects.Part_Number, Rejects.Part_Description, Rejects.Qty_Rejected,ROUND((Rejects.Unit_cost*1),2),(Rejects.Qty_Rejected * Rejects.Unit_cost), Rejects.Date_of_Disposition FROM Rejects ORDER BY Date_Rejected";


            var rows = new DataTable();
            using
                (var
                 cn = new SQLiteConnection(
                     conString)) //executing query, filling dataset with information for excel sheet
            {
                using (var da = new SQLiteDataAdapter(query, cn))
                {
                    da.Fill(rows);
                }
            }

            Application oXL;
            _Workbook oWB;
            _Worksheet oSheet;

            oXL = new Application();
            oXL.Visible = true;

            oWB = oXL.Workbooks.Add(Missing.Value);

            oSheet = (_Worksheet)oWB.ActiveSheet;
            var colNames = new string[rows.Columns.Count];
            var col = 0;

            foreach (DataColumn dc in rows.Columns)
                if (dc.ColumnName == "ROUND((Rejects.Unit_cost*1),2)")
                    colNames[col++] = "Unit Cost";
                else if (dc.ColumnName == "(Rejects.Qty_Rejected * Rejects.Unit_cost)")
                    colNames[col++] = "Ext. Cost";
                else
                    colNames[col++] = dc.ColumnName;


            var lastColumn = (char)(65 + rows.Columns.Count - 1);

            oSheet.get_Range("A1", lastColumn + "1").Value2 = colNames;
            oSheet.get_Range("A1", lastColumn + "1").Font.Bold = true;
            oSheet.get_Range("A1", lastColumn + "1").Font.Underline = true;
            oSheet.get_Range("A1", lastColumn + "1").Font.Size = 15;
            oSheet.get_Range("A1", lastColumn + "1").VerticalAlignment
                = XlVAlign.xlVAlignCenter;
            var rowData =
                new string[rows.Rows.Count, rows.Columns.Count];

            var rowCnt = 0;
            var redRows = 2;
            foreach (DataRow row in rows.Rows)
            {
                for (col = 0; col < rows.Columns.Count; col++) rowData[rowCnt, col] = row[col].ToString();

                rowCnt++;
            }

            var x = oSheet.get_Range("A2", lastColumn + rowCnt.ToString()).Value2 = rowData;
            oSheet.Columns.AutoFit();
            oSheet.get_Range("C1").EntireColumn.ColumnWidth = 25;
            oSheet.get_Range("D1").EntireColumn.ColumnWidth = 40;
            oSheet.get_Range("H1").EntireColumn.ColumnWidth = 20;
            oXL.Visible = true;
            oXL.UserControl = true;
            oXL.ActiveWindow.DisplayGridlines = false;

            try
            {
                oWB.SaveAs(path,
                    AccessMode: XlSaveAsAccessMode.xlShared);
            }
            catch (COMException)
            {
                MessageBox.Show("File not overwritten");
            }

            //oWB.PrintPreview();
            //oSheet.PrintPreview();
        }
    }
}