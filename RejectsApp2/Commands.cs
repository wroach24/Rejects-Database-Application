using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Windows.Forms;
using RejectsApp2.Properties;

namespace RejectsApp2
{
    public class
        Commands //seperate into different classes, command class too general(?) //contains (mostly) general SQL commands used to interface with the database
    {
        public int AddReject(Rejects reject)
        {
            const string query =
                "INSERT INTO Rejects (Reject_Number, Part_Number, Vendor_ID, Vendor_Name, RMA_Number, Date_of_Disposition, Qty_Received, Qty_Inspected, Qty_Rejected, Unit_cost, Lot_Number, Responsible, Product_Line,Disposition,PO_Number,Discrepancy,Date_Rejected,Part_Description,Serial_Number,Rejected_By) " +
                "VALUES (@RejectNum,@PartNum,@VendorID,@VendorName,@RMAnum,@Date_of_Disposition,@QtyReceived,@QtyInspected,@QtyRejected,@UnitCost,@LotNum,@Responsible,@Product_Line,@Disposition,@PONum,@Discrepancy,@DateRejected,@PartDescription,@SerialNum,@RejectedBy)";
            //only parameter necessary is RejectNum
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

            return ExecuteWrite(query, args);
        }

        public int
            deleteReject(
                Rejects reject) //PRE: reject object // POST: updated database based upon the reject object which is derived from user input in NewReject.cs
        {
            var query =
                "DELETE FROM rejects WHERE Reject_Number = @RejectNum";

            //here we are setting the parameter values that will be actually
            //replaced in the query in Execute method
            var args = new Dictionary<string, object>
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
                { "@DateRejected", reject.Date_Rejected.Date },
                { "@PartDescription", reject.Part_Description },
                { "@SerialNum", reject.Serial_Number }
            };

            return ExecuteWrite(query, args);
        }

        public int
            EditReject(Rejects reject) //PRE: reject object // POST: updated database based upon the reject object which is derived from user input in NewReject.cs
        {
            const string query =
                "UPDATE rejects SET Unit_cost = @UnitCost, Vendor_ID = @VendorID, Vendor_Name = @VendorName, RMA_Number = @RMAnum, Date_of_Disposition = @Date_of_Disposition, Responsible = @Responsible, Product_Line = @Product_Line, Rejected_By = @RejectedBy, Disposition = @Disposition, Qty_Received = @QtyReceived, Qty_Inspected = @QtyInspected, Qty_Rejected = @QtyRejected, Lot_Number = @LotNum, PO_Number = @PONum, Discrepancy = @Discrepancy,  Part_Number = @PartNum, Serial_Number = @SerialNum, Date_Rejected = @DateRejected, Part_Description = @PartDescription  WHERE  Reject_Number = @RejectNum";

            //here we are setting the parameter values that will be actually
            //replaced in the query in Execute method
            var args = new Dictionary<string, object>
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
                { "@DateRejected", reject.Date_Rejected.Date },
                { "@PartDescription", reject.Part_Description },
                { "@SerialNum", reject.Serial_Number }
            };

            return ExecuteWrite(query, args);
        }

        public Rejects EditRejectOperation(EditReject editRejectForm)
        {
            var command = new Commands();
            Cursor.Current = Cursors.WaitCursor;
            int? qtyInspNull = null;
            int? qtyRejNull = null;
            int? qtyRecNull = null;
            var disp = "";
            if (int.TryParse(editRejectForm.QtyInspectedTextBox.Text, out var qtyInsp))
                qtyInspNull = qtyInsp;
            if (int.TryParse(editRejectForm.QtyReceivedTextBox.Text, out var qtyRec))
                qtyRecNull = qtyRec;
            if (int.TryParse(editRejectForm.QtyRejectedTextBox.Text, out var qtyRej))
                qtyRejNull = qtyRej;
            if (editRejectForm.DispositionDropDown.Text.Length > 1)
                disp = editRejectForm.DispositionDropDown.Text.Substring(0, 2);

            var reject = new Rejects(editRejectForm.RejectNumberTextBox.Text,
                editRejectForm.DateRejectedDropDown.Value.Date,
                editRejectForm.PartNumberTextBox.Text, editRejectForm.PartDescriptionTextBox.Text,
                editRejectForm.SerialNumberTextBox.Text, editRejectForm.LotNumberTextBox.Text,
                editRejectForm.PONumberTextBox.Text, qtyRecNull, qtyRecNull, qtyRejNull,
                editRejectForm.DiscrepancyTextBox.Text, editRejectForm.ResponsibleDropDown.Text,
                editRejectForm.ProductLineDropDown.Text, editRejectForm.RejectedByDropDown.Text,
                editRejectForm.VendorIDTextbox.Text, editRejectForm.VendorNameDropDown.Text,
                editRejectForm.RMANumberTextBox.Text, disp, editRejectForm.dateDispositionDropDown.Value.Date,
                editRejectForm.UnitCostTextBox.Text);

            command.EditReject(reject);
            Cursor.Current = Cursors.Default;

            return reject;
        }

        public bool finalRejectNumCheck(string val)
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

        public string GenerateRejectNumber(string type)
        {
            var query = "";
            var val = "";
            long result;
            var recType = ' ';

            if (type == "Line")
            {
                query =
                    "SELECT * FROM Rejects WHERE (SUBSTRING(Reject_Number, 1,1) = 'L') ORDER BY CAST(SUBSTRING(Reject_Number, 2, LENGTH(Reject_Number) - 1) AS INT) DESC LIMIT 1";
                recType = 'L';
            }
            else if
                (type == "Receiving") //previous program generation is messed up, figure out how to fix/copy their generation in order to avoid repeats.
            {
                query =
                    "SELECT * FROM Rejects WHERE (SUBSTRING(TRIM(Reject_Number), 1,1) = 'R') ORDER BY CAST(SUBSTRING(Reject_Number, 2, LENGTH(Reject_Number) - 1) AS INT) DESC LIMIT 1";
                recType = 'R';
            }
            else
            {
                MessageBox.Show("Generating Reject Number failed: Reject type incompatible.");
            }

            try
            {
                using (var connection = new SQLiteConnection(ConnectionSettings.Default.connString))
                {
                    connection.Open();
                    var command = new SQLiteCommand(query, connection);
                    var reader = command.ExecuteReader();

                    while (reader.Read()) val = reader["Reject_Number"].ToString().Trim();

                    connection.Close();
                }

                val = val.Substring(1, val.Length - 1);
                var val2 = val.Replace("-", "");
                result = long.Parse(val2);
                result++;
                val = recType + "" + result;

                return val;
            }
            catch
            {
                MessageBox.Show("Something went wrong generating a reject number of type: " + recType);
                throw;
            }
        }

        public Rejects
            GetRejectByID(
                string id) //pre: string corresponding to a database Reject_Number post: Rejects object composed of the column values associated with the corresponding row to the parameter id.
        {
            #region variableDeclaration

            var path = ConnectionSettings.Default.connString;
            var query = "SELECT * FROM rejects WHERE Reject_Number = '" + id + "' LIMIT 1";
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
            var DateOfDisp = DateTime.Parse("01/10/1000");
            var UnitCost = "";

            #endregion variableDeclaration

            try
            {
                using (var con = new SQLiteConnection(path))
                {
                    con.Open();
                    var rejsortCommand = new SQLiteCommand(query, con); //running the query
                    var rejReader = rejsortCommand.ExecuteReader();

                    while (rejReader.Read()) //Reads values from database before creating reject object
                    {
                        rejNum = rejReader["Reject_Number"].ToString();
                        PartNum = rejReader["Part_Number"].ToString();
                        PartDesc = rejReader["Part_Description"].ToString();
                        SerialNum = rejReader["Serial_Number"].ToString();
                        LotNum = rejReader["Lot_Number"].ToString();
                        PONum = rejReader["PO_Number"].ToString();
                        Disrepancy = rejReader["Discrepancy"].ToString();
                        Responsible = rejReader["Responsible"].ToString();
                        Product_Line = rejReader["Product_Line"].ToString();
                        Rejected_By = rejReader["Rejected_By"].ToString();
                        VendorID = rejReader["Vendor_ID"].ToString();
                        Vendor_Name = rejReader["Vendor_Name"].ToString();
                        RMA_Number = rejReader["RMA_Number"].ToString();
                        Disposition = rejReader["Disposition"].ToString();
                        UnitCost = rejReader["Unit_cost"].ToString();

                        int.TryParse(rejReader["Qty_Received"].ToString(), out QtyRec);
                        int.TryParse(rejReader["Qty_Inspected"].ToString(), out QtyIns);
                        int.TryParse(rejReader["QTY_Rejected"].ToString(), out QtyRej);
                        DateTime.TryParse(rejReader["Date_Of_Disposition"].ToString(), out DateOfDisp);
                        DateTime.TryParse(rejReader["Date_Rejected"].ToString(), out rejected);
                    }

                    con.Close();
                }
            }
            catch
            {
                MessageBox.Show("Something went wrong with obtaining RejectNumber");
                throw;
            }

            var newReject = new Rejects(rejNum, rejected, PartNum, PartDesc, SerialNum, LotNum, PONum, QtyRec, QtyIns,
                QtyRej, Disrepancy, Responsible, Product_Line, Rejected_By, VendorID, Vendor_Name, RMA_Number,
                Disposition, DateOfDisp, UnitCost);

            return newReject;
        }

        public DataTable
            GetValuesForForm(string q) //pre:Reject_Num string post:retuns //need to fix the initilization of reject
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

            //var reject = new Rejects(dt.Rows[0][0], dt.Rows[0][1], dt.Rows[0][2], dt.Rows[0][3], dt.Rows[0][4], dt.Rows[0][5], dt.Rows[0][6], Convert.ToInt32(dt.Rows[0][7)], Convert.ToInt32(dt.Rows[0][8)], dt.Rows[0][9], dt.Rows[0][10], dt.Rows[0][11], dt.Rows[0][12], dt.Rows[0][14], dt.Rows[0][15], dt.Rows[0][16], Convert.ToInt32(dt.Rows[0][17)], Convert.ToInt32(dt.Rows[0][18)], dt.Rows[0].Field<DateTime>(19], dt.Rows[0].Field<float>(20], dt.Rows[0][21));

            return dt;
        }

        public DataTable
            GetValuesForReport(string q) //pre:Reject_Num string post:retuns //need to fix the initilization of reject
        {
            var query = q;
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
            var DateOfDisp = DateTime.Parse("01/10/1000");
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

            var dt = ExecuteRead(query, args);

            if (dt == null || dt.Rows.Count == 0) return null;

            //var reject = new Rejects(dt.Rows[0][0], dt.Rows[0][1], dt.Rows[0][2], dt.Rows[0][3], dt.Rows[0][4], dt.Rows[0][5], dt.Rows[0][6], Convert.ToInt32(dt.Rows[0][7)], Convert.ToInt32(dt.Rows[0][8)], dt.Rows[0][9], dt.Rows[0][10], dt.Rows[0][11], dt.Rows[0][12], dt.Rows[0][14], dt.Rows[0][15], dt.Rows[0][16], Convert.ToInt32(dt.Rows[0][17)], Convert.ToInt32(dt.Rows[0][18)], dt.Rows[0].Field<DateTime>(19], dt.Rows[0].Field<float>(20], dt.Rows[0][21));

            return dt;
        }

        public Rejects NewRejectOperation(NewReject newRejectForm)
        {
            var command = new Commands();
            Cursor.Current = Cursors.WaitCursor;
            int? qtyInspNull = null;
            int? qtyRejNull = null;
            int? qtyRecNull = null;
            var disp = "";
            if (int.TryParse(newRejectForm.QtyInspectedTextBox.Text, out var qtyInsp))
                qtyInspNull = qtyInsp;
            if (int.TryParse(newRejectForm.QtyReceivedTextBox.Text, out var qtyRec))
                qtyRecNull = qtyRec;
            if (int.TryParse(newRejectForm.QtyRejectedTextBox.Text, out var qtyRej))
                qtyRejNull = qtyRej;
            if (newRejectForm.DispositionDropDown.Text.Length > 1)
                disp = newRejectForm.DispositionDropDown.Text.Substring(0, 2);

            var reject = new Rejects(newRejectForm.RejectNumberTextBox.Text,
                newRejectForm.DateRejectedDropDown.Value.Date,
                newRejectForm.PartNumberTextBox.Text, newRejectForm.PartDescriptionTextBox.Text,
                newRejectForm.SerialNumberTextBox.Text, newRejectForm.LotNumberTextBox.Text,
                newRejectForm.PONumberTextBox.Text, qtyRecNull, qtyInspNull, qtyRejNull,
                newRejectForm.DiscrepancyTextBox.Text, newRejectForm.ResponsibleDropDown.Text,
                newRejectForm.ProductLineDropDown.Text, newRejectForm.RejectedByDropDown.Text,
                newRejectForm.VendorIDTextbox.Text, newRejectForm.VendorNameDropDown.Text,
                newRejectForm.RMANumberTextBox.Text, disp, newRejectForm.dateDispositionDropDown.Value.Date,
                newRejectForm.UnitCostTextBox.Text);

            command.AddReject(reject);

            Cursor.Current = Cursors.Default;

            return reject;
        }

        private static int
            ExecuteWrite(string query,
                Dictionary<string, object> args)
            //pre: valid query, dictionary supplied by other method POST: query executed UPDATE/CREATE/DELETE function, returns number of rows altered.
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

        private DataTable ExecuteRead(string query,
            Dictionary<string, object> args) //PRE: valid query, args supplied by other method POST:returns datatable filled with the results read from the query
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


        public void FillOutDropMenu(DataTable dt, ComboBox DropDown)
        {
            foreach (DataRow dataRow in dt.Rows)
            foreach (var item in dataRow.ItemArray)
                DropDown.Items.Add(item);
            DropDown.SelectedItem = null;
        }

        public void
            FillOutDropMenu(DataTable dt, ComboBox DropDown,
                char dispositionFlag) //modified fillout for disposition dropdown
        {
            foreach (DataRow dataRow in dt.Rows)
                for (var i = 0; i < dataRow.ItemArray.Length; i += 2)
                    DropDown.Items.Add(dataRow.ItemArray[i] + " : " + dataRow.ItemArray[i + 1]);
            DropDown.SelectedItem = null;
        }

        public void FillOutEditForm(Rejects reject, EditReject editReject)
        {
            if (reject.Reject_Number.Substring(0, 1) == "L")
                editReject.RejectTypeDropDown.SelectedIndex = editReject.RejectTypeDropDown.FindStringExact("Line");
            else if (reject.Reject_Number.Substring(0, 1) == "R")
                editReject.RejectTypeDropDown.SelectedIndex =
                    editReject.RejectTypeDropDown.FindStringExact("Receiving");

            foreach (var x in editReject.DispositionDropDown.Items)
                if (reject.Disposition.Trim() == x.ToString().Substring(0, 1).Trim())
                {
                    editReject.DispositionDropDown.SelectedIndex =
                        editReject.DispositionDropDown.FindStringExact(x.ToString());

                    break;
                }

            //large set of assignment, unsure of how to reduce.
            editReject.RejectNumberTextBox.Text = reject.Reject_Number;
            editReject.PartNumberTextBox.Text = reject.Part_Number;
            editReject.SerialNumberTextBox.Text = reject.Serial_Number;
            editReject.DateRejectedDropDown.Value = reject.Date_Rejected;
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
            editReject.VendorNameDropDown.SelectedIndex =
                editReject.VendorNameDropDown.FindStringExact(reject.Vendor_Name);
            editReject.RejectedByDropDown.SelectedIndex =
                editReject.RejectedByDropDown.FindStringExact(reject.Rejected_By);
            editReject.RMANumberTextBox.Text = reject.RMA_Number;
            editReject.UnitCostTextBox.Text = reject.Unit_Cost;
            if (reject.Disposition_Date > editReject.dateDispositionDropDown.MinDate)
                editReject.dateDispositionDropDown.Value = reject.Disposition_Date;
        }
    }
}