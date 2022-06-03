using System;
using System.Windows.Forms;

namespace RejectsApp2
{
    public partial class NewReject : Form
    {
        private readonly Home home;
        private bool submitFlag;

        public NewReject(Home home)
        {
            InitializeComponent();
            TopLevel = true;
            this.home = home;
        }

        private void NewReject_Load(object sender, EventArgs e) //hides main form on load
        {
            //filling out DropDown menus which are populated from the certain tables in the database
            var command = new Commands();
            var rejectTypes = command.GetValuesForForm("SELECT * FROM Reject_Type");
            var productLines = command.GetValuesForForm("SELECT * FROM Product_Lines");
            var responsible = command.GetValuesForForm("SELECT * FROM Responsible");
            var vendors = command.GetValuesForForm("SELECT * FROM Vendors");
            var technician = command.GetValuesForForm("SELECT * FROM Technician");
            var dispositionCodes = command.GetValuesForForm("SELECT * FROM Disposition_Codes ");
            command.FillOutDropMenu(rejectTypes, RejectTypeDropDown);
            command.FillOutDropMenu(productLines, ProductLineDropDown);
            command.FillOutDropMenu(responsible, ResponsibleDropDown);
            command.FillOutDropMenu(technician, RejectedByDropDown);
            command.FillOutDropMenu(dispositionCodes, DispositionDropDown, 'x');
            command.FillOutDropMenu(vendors, VendorNameDropDown);
            dateDispositionDropDown.Value = DateTime.Now;
            DateRejectedDropDown.Value = DateTime.Now;
            BringToFront();
            home.Hide();
        }

        private void
            NewReject_Closing(object sender,
                FormClosingEventArgs e) //on close of the new reject form verifies that the user wanted to quit and then returns the home page to showing.
        {
            if (e.CloseReason == CloseReason.UserClosing && submitFlag == false)
            {
                e.Cancel = MessageBox.Show("Are you sure you want to exit? Exiting will erase all inputs.",
                    "Exit", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No;
                if (e.Cancel == false)
                    home.Show();
            }
            else
            {
                home.Show();
            }
        }

        private void RejectTypeDropDown_SelectedIndexChanged(object sender, EventArgs e)
        {
            var cmd = new Commands();
            var type = RejectTypeDropDown.SelectedItem.ToString();
            Cursor.Current = Cursors.WaitCursor;
            var newRejectNum = cmd.GenerateRejectNumber(type);
            RejectNumberTextBox.Text = newRejectNum;
            Cursor.Current = Cursors.Default;
        }

        private void SubmitRejectButton_Click(object sender, EventArgs e) //make it so u cannot submit
        {
            var res = false;
            var rejNum = RejectNumberTextBox.Text;
            var cmd = new Commands();
            if (checkRejectSelection() == false) return;
            res = MessageBox.Show("Are you sure you want to submit?",
                "Exit", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No;
            if (res) return;

            if (!cmd.finalRejectNumCheck(rejNum)) //make sure that another user has not taken the ID
            {
                rejNum = cmd.GenerateRejectNumber(RejectTypeDropDown.SelectedItem.ToString());
                MessageBox.Show("Reject_Number switched to: " + rejNum);
                RejectNumberTextBox.Text = rejNum;
            }

            cmd.NewRejectOperation(this);
            submitFlag =
                true; //an edit was performed, signal to Edit_Reject_Closing to only check for confirmation of submission, not closing.
            Close();
        }

        private void PartDescriptionTextBox_TextChanged(object sender, EventArgs e)
        {
        }

        private void QtyReceivedTextBox_TextChanged(object sender, EventArgs e)
        {
        }

        private void QtyReceivedTextBox_Click(object sender, EventArgs e)
        {
            checkRejectSelection();
        }

        private void QtyInspectedTextBox_Click(object sender, EventArgs e)
        {
            checkRejectSelection();
        }

        private void QtyRejectedTextBox_Click(object sender, EventArgs e)
        {
            checkRejectSelection();
        }

        private void UnitCostTextBox_Click(object sender, EventArgs e)
        {
            checkRejectSelection();
        }

        private void button4_Click(object sender, EventArgs e)
        {
        }

        #region checkSelection

        private void PartNumberTextBox_MouseClick(object sender, MouseEventArgs e)
        {
            checkRejectSelection();
        }

        private void SerialNumberTextBox_MouseClick(object sender, MouseEventArgs e)
        {
            checkRejectSelection();
        }

        private void PartDescriptionTextBox_MouseClick(object sender, MouseEventArgs e)
        {
            checkRejectSelection();
        }

        private void LotNumberTextBox_MouseClick(object sender, MouseEventArgs e)
        {
            checkRejectSelection();
        }

        private void PONumberTextBox_MouseClick(object sender, MouseEventArgs e)
        {
            checkRejectSelection();
        }

        private void DiscrepancyTextBox_MouseClick(object sender, MouseEventArgs e)
        {
            checkRejectSelection();
        }

        private void ResponsibleDropDown_MouseClick(object sender, MouseEventArgs e)
        {
            checkRejectSelection();
        }

        private void ProductLineDropDown_MouseClick(object sender, MouseEventArgs e)
        {
            checkRejectSelection();
        }

        private void RejectedByDropDown_MouseClick(object sender, MouseEventArgs e)
        {
            checkRejectSelection();
        }

        private void DispositionDropDown_MouseClick(object sender, MouseEventArgs e)
        {
            checkRejectSelection();
        }

        private void VendorIDTextbox_MouseClick(object sender, MouseEventArgs e)
        {
            checkRejectSelection();
        }

        private void VendorNameDropDown_MouseClick(object sender, MouseEventArgs e)
        {
            checkRejectSelection();
        }

        private void RMANumberTextBox_MouseClick(object sender, MouseEventArgs e)
        {
            checkRejectSelection();
        }

        private void dateDispositionDropDown_MouseDown(object sender, MouseEventArgs e)
        {
            checkRejectSelection();
        }

        private void DateRejectedDropDown_MouseDown(object sender, MouseEventArgs e)
        {
            checkRejectSelection();
        }

        public bool checkRejectSelection()
        {
            var ret = true;
            if (RejectTypeDropDown.SelectedItem == null)
            {
                MessageBox.Show("Select a Reject Type first!");
                ret = false;
            }

            return ret;
        }

        #endregion checkSelection
    }
}