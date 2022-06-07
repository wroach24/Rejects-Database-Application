using System;
using System.Windows.Forms;

namespace RejectsApp2
{
    public partial class EditReject : Form
    {
        private readonly Home home;
        private bool editFlag;

        public EditReject(Home home)
        {
            InitializeComponent();
            TopLevel = true;
            this.home = home;
        }

        private void EditReject_Load(object sender, EventArgs e) //hides main form on load
        {
            //filling out DropDown menus which are populated from the certain tables in the database
            var command = new Commands();
            var rejectTypes = command.GetValuesForForm("SELECT * FROM Reject_Type");
            var productLines = command.GetValuesForForm("SELECT * FROM Product_Lines");
            var responsible = command.GetValuesForForm("SELECT * FROM Responsible");
            var vendors = command.GetValuesForForm("SELECT * FROM Vendors");
            var dispositionCodes = command.GetValuesForForm("SELECT * FROM Disposition_Codes ");
            command.FillOutDropMenu(rejectTypes, RejectTypeDropDown);
            command.FillOutDropMenu(productLines, ProductLineDropDown);
            command.FillOutDropMenu(responsible, ResponsibleDropDown);
            command.FillOutDropMenu(dispositionCodes, DispositionDropDown, 'x');
            command.FillOutDropMenu(vendors, VendorNameDropDown);
            BringToFront();
            home.Hide();
            if (string.IsNullOrEmpty(DispositionDropDown.Text))
            {
                dateDispositionDropDown.Enabled = false;
                dateDispositionDropDown.CustomFormat = " ";
                dateDispositionDropDown.Format = DateTimePickerFormat.Custom;
            }
        }

        private void
            EditReject_Closing(object sender,
                FormClosingEventArgs e) //on close of the new reject form verifies that the user wanted to quit and then returns the home page to showing.
        {
            if (e.CloseReason == CloseReason.UserClosing && editFlag == false)
            {
                e.Cancel = MessageBox.Show("Are you sure you want to exit? Exiting will erase all inputs.",
                    "Exit", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No;
                if (e.Cancel == false) home.Show();
            }
            else
            {
                home.Show();
            }
        }

        private void RejectTypeDropDown_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void SubmitRejectButton_Click(object sender, EventArgs e) //make it so u cannot submit
        {
            var res = MessageBox.Show("Are you sure you want to submit?",
                "Exit", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No;
            if (res) return;

            var edit = new Commands();
            edit.EditRejectOperation(this);
            editFlag = true; //an edit was performed, signal to Edit_Reject_Closing to only check for confirmation of submission, not closing.
            Close();
        }

        private void label2_Click(object sender, EventArgs e)
        {
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
        }

        private void UnitCostTextBox_Click(object sender, EventArgs e)
        {
        }

        private void dateDispositionDropDown_ValueChanged(object sender, EventArgs e)
        {
        }

        private void DispositionDropDown_SelectedIndexChanged(object sender, EventArgs e)
        {
            dateDispositionDropDown.Enabled = true;
            dateDispositionDropDown.Format = DateTimePickerFormat.Short;
        }
    }
}