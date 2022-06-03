using System;

namespace RejectsApp2
{
    public class Rejects //assigns variables in constructor
    {
        public Rejects(string Reject_Number, DateTime Date_Rejected, string Part_Number, string Part_Description,
            string Serial_Number,
            string Lot_Number, string PO_Number, int? QTY_Received, int? QTY_Inspected, int? QTY_Rejected,
            string Discrepancy, string Responsible, string Product_Line, string Rejected_By, string VendorID,
            string Vendor_Name,
            string RMA_Number, string Disposition, DateTime Disposition_Date, string Unit_Cost)
        {
            this.Reject_Number = Reject_Number;
            this.Date_Rejected = Date_Rejected;
            this.Part_Number = Part_Number;
            this.Part_Description = Part_Description;
            this.Serial_Number = Serial_Number;
            this.Lot_Number = Lot_Number;
            this.PO_Number = PO_Number;
            this.QTY_Received = QTY_Received;
            this.QTY_Rejected = QTY_Rejected;
            this.QTY_Inspected = QTY_Inspected;
            this.Discrepancy = Discrepancy;
            this.Responsible = Responsible;
            this.Product_Line = Product_Line;
            this.Rejected_By = Rejected_By;
            this.VendorID = VendorID;
            this.Vendor_Name = Vendor_Name;
            this.RMA_Number = RMA_Number;
            this.Disposition = Disposition;
            this.Disposition_Date = Disposition_Date;
            this.Unit_Cost = Unit_Cost;
        }

        #region declarations

        public DateTime Date_Rejected;
        public string Discrepancy;
        public string Disposition;
        public DateTime Disposition_Date;
        public string Lot_Number;
        public string Part_Description;
        public string Part_Number;
        public string PO_Number;
        public string Product_Line;
        public int? QTY_Inspected;
        public int? QTY_Received;
        public int? QTY_Rejected;
        public string Reject_Number;
        public string Rejected_By;
        public string Responsible;
        public string RMA_Number;
        public string Serial_Number;

        public string Unit_Cost;
        public string Vendor_Name;
        public string VendorID;

        #endregion
    }
}