using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Windows.Forms;
using Microsoft.Reporting.WinForms;
using RejectsApp2.Forms;
using RejectsApp2.Properties;

namespace RejectsApp2
{
    public static class Commands
    {
        //generates dictionary for reading/writing to database
        public static Dictionary<string, object> generateArgument(Rejects reject)
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


        //PRE: reject object // POST: updated database, deleted row.
        public static int deleteReject(Rejects reject)
        {
            var query =
                "DELETE FROM rejects WHERE Reject_Number = @RejectNum";
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


        //pre: valid query, dictionary supplied by other method POST: query executed UPDATE/CREATE/DELETE function, returns number of rows altered.
        public static int ExecuteWrite(string query, Dictionary<string, object> args)

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
        public static DataTable ExecuteRead(string query, Dictionary<string, object> args)
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
    }

}