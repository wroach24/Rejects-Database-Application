using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Printing;
using System.Windows.Forms;
using RejectsApp2.Forms;
using static RejectsApp2.EditRejectCommands;

namespace RejectsApp2
{
    public partial class EditReject : Form
    {
        private readonly Home home;
        private bool editFlag;
   

        public EditReject(Home home)
        {
            InitializeComponent();

            this.home = home;
        }

        private void EditReject_Load(object sender, EventArgs e) //hides main form on load
        {
            //initializes a field instance which fills out the form, given the dropdowns
            var fieldInstance = new FieldItems();
            fieldInstance.FillMenus(RejectTypeDropDown, ProductLineDropDown, ResponsibleDropDown, VendorNameDropDown);
            fieldInstance.FillDispositionMenu(DispositionDropDown);
            home.Hide();
            //check if the disposition is filled out yet
            if (string.IsNullOrEmpty(DispositionDropDown.Text))
            {
                dateDispositionDropDown.Enabled = false;
                dateDispositionDropDown.CustomFormat = " ";
                dateDispositionDropDown.Format = DateTimePickerFormat.Custom;
            }
           
        }

        //on close of the new reject form verifies that the user wanted to quit and then returns the home page to showing.
        private void EditReject_Closing(object sender,
            FormClosingEventArgs e)
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
            EditRejectOperation(this);
            editFlag = true; //an edit was performed, signal to Edit_Reject_Closing to only check for confirmation of submission, not closing.
            Close();
        }

        private void DispositionDropDown_SelectedIndexChanged(object sender, EventArgs e)
        {
            dateDispositionDropDown.Enabled = true;
            dateDispositionDropDown.Format = DateTimePickerFormat.Short;
        }

        //printing, clean up once receiving confirmation from Gary
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            PrintDisplay temDisplay = new PrintDisplay(this);
            temDisplay.Show();
        }

        private void UnitCostTextBox_TextChanged(object sender, EventArgs e)
        {
            //determines whether the user is inputing the text or the code itself- helps avoid collisions between old unsupported format entries in the database and newer ones
            if (!UnitCostTextBox.Focused) return;
            var periodCount = 0;
            var index = 0;

            //prevent invalid inputs for the unit cost text box.
            foreach (var num in UnitCostTextBox.Text)
            {
                //if the char is a num and the period count is under 0, continue
                if (char.IsDigit(num) && periodCount <= 1)
                {
                }
                //if the digit is not a num, but is a period instead, increase the period count
                else if (num == '.')
                {
                    periodCount++;
                }
                //alert the user they don't need to input the dollar sign
                else if (num == '$')
                {
                    MessageBox.Show("Do not enter the dollar sign.");
                    UnitCostTextBox.Text = UnitCostTextBox.Text.Remove(index);
                }
                else
                {
                    MessageBox.Show("Only numbers and decimals allowed.");
                    UnitCostTextBox.Text = UnitCostTextBox.Text.Remove(index);
                }

                if (periodCount > 1)
                {
                    MessageBox.Show("There are too many decimals.");
                    UnitCostTextBox.Text = UnitCostTextBox.Text.Remove(index);
                }

                index++;
            }
        }
    }
}