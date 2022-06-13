using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Windows.Forms;
using RejectsApp2.Properties;

namespace RejectsApp2
{
    public static class Commands
    {
        //generates dictionary for reading/writing to database
        public static Dictionary<string,object> generateArgument(Rejects reject)
        {
            var args = new Dictionary<string, dynamic>
            {
                { "@RejectNum", reject.Reject_Number },
                { "@PartNum", reject.Part_Number },
                { "@VendorID", reject.VendorID },
                { "@VendorName", reject.Vendor_Name },
                { "@RMAnum", reject.RMA_Number },
                { "@Date_of_Disposition", reject.Disposition_Date },
                { "@QtyReceived", reject.QTY_Received },
                { "@QtyInspected", reject.QTY_Inspected },
                { "@QtyRejected", reject.QTY_Rejected },
                { "@UnitCost", reject.Unit_Cost },
                { "@LotNum", reject.Lot_Number },
                { "@Responsible", reject.Responsible },
                { "@Product_Line", reject.Product_Line },
                { "@RejectedBy", reject.Rejected_By },
                { "@Disposition", reject.Disposition },
                { "@PONum", reject.PO_Number },
                { "@Discrepancy", reject.Discrepancy },
                { "@DateRejected", reject.Date_Rejected },
                { "@PartDescription", reject.Part_Description },
                { "@SerialNum", reject.Serial_Number }
            };
            return args;
        }
        //generates dictionary for reading to specific variables for loading report
        public static Dictionary<string, object> generateArgument()
        {
            var rejNum = "";
            var rejected = DateTime.Parse("01/10/1000");
            var PartNum = "";
            var PartDesc = "";
            var SerialNum = "";
            var LotNum = "";
            var PONum = "";
            var QtyRec = 0;
            var QtyIns = 0;
            var QtyRej = 0;
            var Disrepancy = "";
            var Responsible = "";
            var Product_Line = "";
            var Rejected_By = "";
            var VendorID = "";
            var Vendor_Name = "";
            var RMA_Number = "";
            var Disposition = "";
            DateTime? DateOfDisp = DateTime.Parse("01/10/1000");
            var UnitCost = "";
            var args = new Dictionary<string, object>
            {
                { "@Reject_Number", rejNum },
                { "@PartNum", PartNum },
                { "@Vendor_ID", VendorID },
                { "@Vendor_Name", Vendor_Name },
                { "@RMA_Number", RMA_Number },
                { "@Date_of_Disposition", DateOfDisp },
                { "@QtyReceived", QtyRec },
                { "@QtyInspected", QtyIns },
                { "@QtyRejected", QtyRej },
                { "@UnitCost", UnitCost },
                { "@LotNum", LotNum },
                { "@Responsible", Responsible },
                { "@Product_Line", Product_Line },
                { "@RejectedBy", Rejected_By },
                { "@Disposition", Disposition },
                { "@PO_Number", PONum },
                { "@Discrepancy", Disrepancy },
                { "@DateRejected", rejected },
                { "@PartDescription", PartDesc },
                { "@SerialNum", SerialNum }
            };
            return args;
        }
        //PRE: reject object // POST: updated database from reject object values, new row.
        public static int AddReject(Rejects reject)
        {
            const string query =
                "INSERT INTO Rejects (Reject_Number, Part_Number, Vendor_ID, Vendor_Name, RMA_Number, Date_of_Disposition, Qty_Received, Qty_Inspected, Qty_Rejected, Unit_cost, Lot_Number, Responsible, Product_Line,Disposition,PO_Number,Discrepancy,Date_Rejected,Part_Description,Serial_Number,Rejected_By) " +
                "VALUES (@RejectNum,@PartNum,@VendorID,@VendorName,@RMAnum,@Date_of_Disposition,@QtyReceived,@QtyInspected,@QtyRejected,@UnitCost,@LotNum,@Responsible,@Product_Line,@Disposition,@PONum,@Discrepancy,@DateRejected,@PartDescription,@SerialNum,@RejectedBy)";

           

            return ExecuteWrite(query, generateArgument(reject));
        }

        //PRE: reject object // POST: updated database, deleted row.
        public static int deleteReject(Rejects reject)
        {
            var query =
                "DELETE FROM rejects WHERE Reject_Number = @RejectNum";
            return ExecuteWrite(query, generateArgument(reject));
        }

        //PRE: reject object // POST: updated database based upon the reject object which is derived from user input in the edit reject form
        public static int EditReject(Rejects reject)
        {
            const string query =
                "UPDATE rejects SET Unit_cost = @UnitCost, Vendor_ID = @VendorID, Vendor_Name = @VendorName, RMA_Number = @RMAnum, Date_of_Disposition = @Date_of_Disposition, Responsible = @Responsible, Product_Line = @Product_Line, Rejected_By = @RejectedBy, Disposition = @Disposition, Qty_Received = @QtyReceived, Qty_Inspected = @QtyInspected, Qty_Rejected = @QtyRejected, Lot_Number = @LotNum, PO_Number = @PONum, Discrepancy = @Discrepancy,  Part_Number = @PartNum, Serial_Number = @SerialNum, Date_Rejected = @DateRejected, Part_Description = @PartDescription  WHERE  Reject_Number = @RejectNum";

            return ExecuteWrite(query, generateArgument(reject));
        }

        //checks if the text is an integer, else returns null
        public static int? checkIntText(string input)
        {
            var result = 0;
            int.TryParse(input, out result);
            if (result == 0)
                return null;
            return result;
        }

        //Performs the edit reject operation, ensuring the values are correct, nulls are assigned to non-nullable types and then creates Rejects object.
        public static Rejects EditRejectOperation(EditReject editRejectForm)
        {
            Cursor.Current = Cursors.WaitCursor;
            var qtyInspNull = checkIntText(editRejectForm.QtyInspectedTextBox.Text);
            var qtyRejNull = checkIntText(editRejectForm.QtyRejectedTextBox.Text);
            var qtyRecNull = checkIntText(editRejectForm.QtyReceivedTextBox.Text);

            DateTime? dispDate = null;
            var disp = "";
            if (!string.IsNullOrEmpty(editRejectForm.DispositionDropDown.Text))
                disp = editRejectForm.DispositionDropDown.Text.Substring(4);
            //if disposition has been selected, submit date value
            if (editRejectForm.dateDispositionDropDown.Enabled)
                dispDate = editRejectForm.dateDispositionDropDown.Value.Date;

            var reject = new Rejects(editRejectForm.RejectNumberTextBox.Text,
                editRejectForm.DateRejectedDropDown.Value.Date,
                editRejectForm.PartNumberTextBox.Text, editRejectForm.PartDescriptionTextBox.Text,
                editRejectForm.SerialNumberTextBox.Text, editRejectForm.LotNumberTextBox.Text,
                editRejectForm.PONumberTextBox.Text, qtyRecNull, qtyInspNull, qtyRejNull,
                editRejectForm.DiscrepancyTextBox.Text, editRejectForm.ResponsibleDropDown.Text,
                editRejectForm.ProductLineDropDown.Text, editRejectForm.RejectedByDropDown.Text,
                editRejectForm.VendorIDTextbox.Text, editRejectForm.VendorNameDropDown.Text,
                editRejectForm.RMANumberTextBox.Text, disp, dispDate,
                editRejectForm.UnitCostTextBox.Text);

            EditReject(reject);
            Cursor.Current = Cursors.Default;

            return reject;
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

        //pre: string corresponding to a database Reject_Number post: Rejects object composed of the column values associated with the corresponding row to the Reject_Number id.
        public static Rejects GetRejectByID(string id)
        {

            var path = ConnectionSettings.Default.connString;
            var query = "SELECT * FROM rejects WHERE Reject_Number = '" + id + "' LIMIT 1";
            var newReject = new Rejects();

            try
            {
                using (var con = new SQLiteConnection(path))
                {
                    con.Open();
                    var rejsortCommand = new SQLiteCommand(query, con); //running the query
                    var rejReader = rejsortCommand.ExecuteReader();

                    while (rejReader.Read()) //Reads values from database before creating reject object
                    {
                        var rejNum = rejReader["Reject_Number"].ToString();
                        var PartNum = rejReader["Part_Number"].ToString();
                        var PartDesc = rejReader["Part_Description"].ToString();
                        var SerialNum = rejReader["Serial_Number"].ToString();
                        var LotNum = rejReader["Lot_Number"].ToString();
                        var PONum = rejReader["PO_Number"].ToString();
                        var Disrepancy = rejReader["Discrepancy"].ToString();
                        var Responsible = rejReader["Responsible"].ToString();
                        var Product_Line = rejReader["Product_Line"].ToString();
                        var Rejected_By = rejReader["Rejected_By"].ToString();
                        var VendorID = rejReader["Vendor_ID"].ToString();
                        var Vendor_Name = rejReader["Vendor_Name"].ToString();
                        var RMA_Number = rejReader["RMA_Number"].ToString();
                        var Disposition = rejReader["Disposition"].ToString();
                        var UnitCost = rejReader["Unit_cost"].ToString();
                        int.TryParse(rejReader["Qty_Received"].ToString(), out var QtyRec);
                        int.TryParse(rejReader["Qty_Inspected"].ToString(), out var QtyIns);
                        int.TryParse(rejReader["QTY_Rejected"].ToString(), out var QtyRej);
                        DateTime.TryParse(rejReader["Date_Of_Disposition"].ToString(), out var DateOfDisp);
                        DateTime.TryParse(rejReader["Date_Rejected"].ToString(), out var rejected);

                        //instantiate new rejects object
                        newReject = new Rejects(rejNum, rejected, PartNum, PartDesc, SerialNum, LotNum, PONum, QtyRec,
                            QtyIns,
                            QtyRej, Disrepancy, Responsible, Product_Line, Rejected_By, VendorID, Vendor_Name,
                            RMA_Number,
                            Disposition, DateOfDisp, UnitCost);
                    }

                    con.Close();
                }
            }
            catch
            {
                MessageBox.Show("Something went wrong with obtaining the details of the specified reject number.");
                throw;
            }


            return newReject;
        }

        //pre:query post: returns the values from the database that will fill out specific fields such as the differing vendors, etc.
        public static DataTable GetValuesForForm(string q)
        {
            var query = q;
            var val = "";
            var disp = "";
            var args = new Dictionary<string, object>
            {
                { "@Field1", val },
                { "@Field2", disp }
            };

            var dt = ExecuteRead(query, args);

            if (dt == null || dt.Rows.Count == 0) return null;

            return dt;
        }


        //pre:query string post:datatable returning query results
        public static DataTable GetValuesForReport(string q)
        {
            var query = q;
            var dt = ExecuteRead(query, generateArgument());

            if (dt == null || dt.Rows.Count == 0) return null;

            return dt;
        }

        public static Rejects NewRejectOperation(NewReject newRejectForm)
        {
            DateTime? dispDate = null;
            string disp = null;
            var qtyInspNull = checkIntText(newRejectForm.QtyInspectedTextBox.Text);
            var qtyRejNull = checkIntText(newRejectForm.QtyRejectedTextBox.Text);
            var qtyRecNull = checkIntText(newRejectForm.QtyReceivedTextBox.Text);
            //if disposition has not been selected, as such date is null (necessary for not assigning date until disposition is assigned)
            if (newRejectForm.dateDispositionDropDown.Enabled)
                dispDate = newRejectForm.dateDispositionDropDown.Value.Date;

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

        //pre: valid query, dictionary supplied by other method POST: query executed UPDATE/CREATE/DELETE function, returns number of rows altered.
        private static int ExecuteWrite(string query,
            Dictionary<string, object> args)

        {
            if (string.IsNullOrEmpty(query.Trim()))
                return 0;
            //setup the connection to the database
            var path = ConnectionSettings.Default.connString;
            try
            {
                using (var con = new SQLiteConnection(path))
                {
                    int numberOfRowsAffected;
                    con.Open();

                    //open a new command
                    using (var cmd = new SQLiteCommand(query, con))
                    {
                        //set the arguments given in the query
                        foreach (var pair in args) cmd.Parameters.AddWithValue(pair.Key, pair.Value);
                        //execute the query and get the number of row affected
                        numberOfRowsAffected = cmd.ExecuteNonQuery();
                    }

                    con.Close();
                    return numberOfRowsAffected;
                }
            }
            catch
            {
                MessageBox.Show("Something went wrong executing the following SQL Write operation: " + query);
                throw;
            }
        }

        //PRE: valid query, args supplied by other method POST:returns datatable filled with the results read from the query
        private static DataTable ExecuteRead(string query, Dictionary<string, object> args)
        {
            if (string.IsNullOrEmpty(query.Trim()))
                return null;

            //setup the connection to the database
            var path = ConnectionSettings.Default.connString;
            try
            {
                using (var con = new SQLiteConnection(path))
                {
                    con.Open();

                    using (var cmd = new SQLiteCommand(query, con))
                    {
                        foreach (var entry in args) cmd.Parameters.AddWithValue(entry.Key, entry.Value);

                        var da = new SQLiteDataAdapter(cmd);

                        var dt = new DataTable();
                        da.Fill(dt);

                        da.Dispose();

                        con.Close();
                        return dt;
                    }
                }
            }
            catch
            {
                MessageBox.Show("Something went wrong executing the following SQL Read operation: " + query);
                throw;
            }
        }


        //fills out normal drop menus from the databsae, utilizes a datatable filled from a query previously.
        public static void FillOutDropMenu(DataTable dt, ComboBox DropDown)
        {
            foreach (DataRow dataRow in dt.Rows)
            foreach (var item in dataRow.ItemArray)
                DropDown.Items.Add(item);
            DropDown.SelectedItem = null;
        }

        //fills out the disposition drop menu from the databsae, utilizes a datatable filled from a query previously.
        public static void FillOutDropMenu(DataTable dt, ComboBox DropDown, char dispositionFlag)
        {
            foreach (DataRow dataRow in dt.Rows)
                for (var i = 0; i < dataRow.ItemArray.Length; i += 2)
                    DropDown.Items.Add(dataRow.ItemArray[i] + " : " + dataRow.ItemArray[i + 1]);
            DropDown.SelectedItem = null;
        }


        //Fills out the edit form, utilizes if statements to assign null to traditional non-nullable types, text is just assigned directly.
        public static void FillOutEditForm(Rejects reject, EditReject editReject)
        {
            if (reject.Reject_Number.Substring(0, 1) == "L")
                editReject.RejectTypeDropDown.SelectedIndex = editReject.RejectTypeDropDown.FindStringExact("Line");
            else if (reject.Reject_Number.Substring(0, 1) == "R")
                editReject.RejectTypeDropDown.SelectedIndex =
                    editReject.RejectTypeDropDown.FindStringExact("Receiving");

            foreach (var x in editReject.DispositionDropDown.Items)
                if (reject.Disposition == x.ToString().Substring(4).Trim())
                {
                    editReject.DispositionDropDown.SelectedIndex =
                        editReject.DispositionDropDown.FindStringExact(x.ToString());

                    break;
                }

            //large set of assignment, unsure of how to reduce.
            editReject.RejectNumberTextBox.Text = reject.Reject_Number;
            editReject.PartNumberTextBox.Text = reject.Part_Number;
            editReject.SerialNumberTextBox.Text = reject.Serial_Number;
            editReject.PartDescriptionTextBox.Text = reject.Part_Description;
            editReject.LotNumberTextBox.Text = reject.Lot_Number;
            editReject.PONumberTextBox.Text = reject.PO_Number;
            editReject.QtyInspectedTextBox.Text = reject.QTY_Inspected.ToString();
            editReject.QtyReceivedTextBox.Text = reject.QTY_Received.ToString();
            editReject.QtyRejectedTextBox.Text = reject.QTY_Rejected.ToString();
            editReject.DiscrepancyTextBox.Text = reject.Discrepancy;
            editReject.ResponsibleDropDown.SelectedIndex =
                editReject.ResponsibleDropDown.FindStringExact(reject.Responsible);
            editReject.VendorIDTextbox.Text = reject.VendorID;
            editReject.ProductLineDropDown.SelectedIndex =
                editReject.ProductLineDropDown.FindStringExact(reject.Product_Line);
            editReject.VendorNameDropDown.Text = reject.Vendor_Name;
            editReject.RejectedByDropDown.Text = reject.Rejected_By;
            editReject.RMANumberTextBox.Text = reject.RMA_Number;
            editReject.UnitCostTextBox.Text = reject.Unit_Cost;
            if (reject.Disposition_Date > editReject.dateDispositionDropDown.MinDate)
                editReject.dateDispositionDropDown.Value = reject.Disposition_Date.Value.Date;
            editReject.DateRejectedDropDown.Value = reject.Date_Rejected.Date;
        }
    }
}