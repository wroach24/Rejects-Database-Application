using System;
using System.Data.SQLite;
using System.Windows.Forms;
using RejectsApp2.Properties;
using static RejectsApp2.Commands;

namespace RejectsApp2
{
    internal static class NewRejectCommands
    {
        //PRE: reject object // POST: updated database from reject object values, new row.
        public static int AddReject(Rejects reject)
        {
            const string query =
                "INSERT INTO Rejects (Reject_Number, Part_Number, Vendor_ID, Vendor_Name, RMA_Number, Date_of_Disposition, Qty_Received, Qty_Inspected, Qty_Rejected, Unit_cost, Lot_Number, Responsible, Product_Line,Disposition,PO_Number,Discrepancy,Date_Rejected,Part_Description,Serial_Number,Rejected_By) " +
                "VALUES (@RejectNum,@PartNum,@VendorID,@VendorName,@RMAnum,@Date_of_Disposition,@QtyReceived,@QtyInspected,@QtyRejected,@UnitCost,@LotNum,@Responsible,@Product_Line,@Disposition,@PONum,@Discrepancy,@DateRejected,@PartDescription,@SerialNum,@RejectedBy)";


            return ExecuteWrite(query, GenerateArgument(reject));
        }

        //generates the new reject number is a line reject, else simply fills in R and allows user to input
        public static string GenerateRejectNumber(string type)
        {
            var query =
                "SELECT * FROM Rejects WHERE (SUBSTRING(Reject_Number, 1,1) = 'L') ORDER BY CAST(SUBSTRING(Reject_Number, 2, LENGTH(Reject_Number) - 1) AS INT) DESC LIMIT 1";
            var val = "";

            try
            {
                if (type == "Line")
                {
                    using (var connection = new SQLiteConnection(ConnectionSettings.Default.connString))
                    {
                        connection.Open();
                        var command = new SQLiteCommand(query, connection);
                        var reader = command.ExecuteReader();
                        while (reader.Read())
                            val = reader["Reject_Number"].ToString().Trim();
                        connection.Close();
                    }
                    //getting the value and excluding the prefix
                    val = val.Substring(1, val.Length - 1);
                    var result = long.Parse(val);
                    result++;
                    val = type.Trim().Substring(0, 1) + "" + result;
                    return val;
                }

                return type.Trim().Substring(0, 1);
            }
            catch
            {
                MessageBox.Show("Something went wrong generating a reject number of type: " + type);
                throw;
            }
        }

        //checks if the reject number being input from the newreject form is already taken, meant to (hopefully) prevent any errors where two writes are performed at the
        //same time and input the same reject num for different rejects
        //PRE: Reject_Number value, POST: bool corresponding TRUE to reject number is not present and FALSE to the reject number is present.
        public static bool finalRejectNumCheck(string val)
        {
            var query = "SELECT Reject_Number FROM Rejects WHERE Reject_Number = '" + val + "'";
            var output = "";
            try
            {
                using (var connection = new SQLiteConnection(ConnectionSettings.Default.connString))
                {
                    connection.Open();
                    var command = new SQLiteCommand(query, connection);
                    var reader = command.ExecuteReader();

                    while (reader.Read()) output = reader["Reject_Number"].ToString().Trim();

                    connection.Close();
                }

                if (string.IsNullOrEmpty(output))
                    return true;
                return false;
            }
            catch
            {
                MessageBox.Show("Something went wrong confirming the Reject Number was not taken.");
                throw;
            }
        }

        public static Rejects NewRejectOperation(NewReject newRejectForm)
        {
            DateTime? dispDate = null;
            string disp = null;
            var qtyInspNull = CheckIntText((newRejectForm.QtyInspectedTextBox.Text));
            var qtyRejNull = CheckIntText(newRejectForm.QtyRejectedTextBox.Text);
            var qtyRecNull = CheckIntText(newRejectForm.QtyReceivedTextBox.Text);
            //if disposition has been selected, then set date value
            if (newRejectForm.dateDispositionDropDown.Enabled)
                dispDate = newRejectForm.dateDispositionDropDown.Value.Date;
            if (!string.IsNullOrEmpty(newRejectForm.DispositionDropDown.Text))
                disp = newRejectForm.DispositionDropDown.Text.Substring(4);
            var reject = new Rejects(newRejectForm.RejectNumberTextBox.Text,
                newRejectForm.DateRejectedDropDown.Value.Date,
                newRejectForm.PartNumberTextBox.Text, newRejectForm.PartDescriptionTextBox.Text,
                newRejectForm.SerialNumberTextBox.Text, newRejectForm.LotNumberTextBox.Text,
                newRejectForm.PONumberTextBox.Text, qtyRecNull, qtyInspNull, qtyRejNull,
                newRejectForm.DiscrepancyTextBox.Text, newRejectForm.ResponsibleDropDown.Text,
                newRejectForm.ProductLineDropDown.Text, newRejectForm.RejectedByDropDown.Text,
                newRejectForm.VendorIDTextbox.Text, newRejectForm.VendorNameDropDown.Text,
                newRejectForm.RMANumberTextBox.Text, disp, dispDate,
                newRejectForm.UnitCostTextBox.Text);

            AddReject(reject);
            return reject;
        }
    }
}