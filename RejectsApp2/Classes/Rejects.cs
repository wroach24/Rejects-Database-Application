using System;

namespace RejectsApp2
{
    public class Rejects //assigns variables in constructor
    {
        #region declarations
        public DateTime Date_Rejected { get; }
        public string Discrepancy { get; }
        public string Disposition { get; }
        public DateTime? Disposition_Date { get; }
        public string Lot_Number { get; }
        public string Part_Description { get; }
        public string Part_Number { get; }
        public string PO_Number { get; }
        public string Product_Line { get; }
        public int? QTY_Inspected { get; }
        public int? QTY_Received { get; }
        public int? QTY_Rejected { get; }
        public string Reject_Number { get; }
        public string Rejected_By { get; }
        public string Responsible { get; }
        public string RMA_Number { get; }
        public string Serial_Number { get; }

        public string Unit_Cost { get; }
        public string Vendor_Name { get; }
        public string VendorID { get; }

        #endregion declarations
        public Rejects(string Reject_Number, DateTime Date_Rejected, string Part_Number, string Part_Description,
            string Serial_Number, string Lot_Number, string PO_Number, int? QTY_Received, int? QTY_Inspected,
            int? QTY_Rejected,
            string Discrepancy, string Responsible, string Product_Line, string Rejected_By, string VendorID,
            string Vendor_Name, string RMA_Number, string Disposition, DateTime? Disposition_Date, string Unit_Cost)
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

        public Rejects()
        {
        }

        
    }
}