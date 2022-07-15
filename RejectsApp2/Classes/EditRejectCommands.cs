using System;
using System.Windows.Forms;
using static RejectsApp2.Commands;

namespace RejectsApp2
{
    internal static class EditRejectCommands
    {
        //Performs the edit reject operation, ensuring the values are correct, nulls are assigned to non-nullable types and then creates Rejects object.
        public static Rejects EditRejectOperation(EditReject editRejectForm)
        {
            Cursor.Current = Cursors.WaitCursor;
            var qtyInspNull = CheckIntText(editRejectForm.QtyInspectedTextBox.Text);
            var qtyRejNull = CheckIntText(editRejectForm.QtyRejectedTextBox.Text);
            var qtyRecNull = CheckIntText(editRejectForm.QtyReceivedTextBox.Text);

            DateTime? dispDate = null;
            string disp = null;
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

        //PRE: reject object // POST: updated database based upon the reject object which is derived from user input in the edit reject form
        public static int EditReject(Rejects reject)
        {
            const string query =
                "UPDATE rejects SET Unit_cost = @UnitCost, Vendor_ID = @VendorID, Vendor_Name = @VendorName, RMA_Number = @RMAnum, Date_of_Disposition = @Date_of_Disposition, Responsible = @Responsible, Product_Line = @Product_Line, Rejected_By = @RejectedBy, Disposition = @Disposition, Qty_Received = @QtyReceived, Qty_Inspected = @QtyInspected, Qty_Rejected = @QtyRejected, Lot_Number = @LotNum, PO_Number = @PONum, Discrepancy = @Discrepancy,  Part_Number = @PartNum, Serial_Number = @SerialNum, Date_Rejected = @DateRejected, Part_Description = @PartDescription  WHERE  Reject_Number = @RejectNum";

            return ExecuteWrite(query, GenerateArgument(reject));
        }

        //Fills out the edit form, utilizes if statements to assign null to traditional non-nullable types, text is just assigned directly.
        public static void FillOutEditForm(Rejects reject, EditReject editReject)
        {
            
            if (reject.Reject_Number.Substring(0, 1) == "L" )
                editReject.RejectTypeDropDown.SelectedIndex = editReject.RejectTypeDropDown.FindStringExact("Line");
            else if (reject.Reject_Number.Substring(0, 1) == "R" )
                editReject.RejectTypeDropDown.SelectedIndex =
                    editReject.RejectTypeDropDown.FindStringExact("Receiving");

            //iterats through the objects in the disposition drop down and matches them to the database entry
            foreach (var x in editReject.DispositionDropDown.Items)
                if (reject.Disposition.Trim() == x.ToString().Substring(4).Trim() || reject.Disposition.Trim() == x.ToString().Substring(5).Trim())
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