using System;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Printing;
using System.Windows.Forms;
using Microsoft.Reporting.WinForms;
using RejectsApp2.Forms;
using static RejectsApp2.NewRejectCommands;
using static RejectsApp2.Commands;

namespace RejectsApp2
{
    public partial class NewReject : Form
    {
     
        private string[] requiredFields;
        private bool submitFlag = false;

        public NewReject()
        {
            InitializeComponent();
            TopLevel = true;
        }

        private void NewReject_Load(object sender, EventArgs e) //hides main form on load
        {
            //initializes a field instance which fills out the form, given the dropdowns
            var fieldInstance = new FieldItems();
            fieldInstance.FillMenus(RejectTypeDropDown, ProductLineDropDown, ResponsibleDropDown, VendorNameDropDown);
            fieldInstance.FillDispositionMenu(DispositionDropDown);
            //setting the dateDisposition to empty to start as well as setting the date value if enabled
            dateDispositionDropDown.Value = DateTime.Now;
            dateDispositionDropDown.CustomFormat = " ";
            dateDispositionDropDown.Format = DateTimePickerFormat.Custom;
            //setting the dateRejected time
            DateRejectedDropDown.Value = DateTime.Now;
            //bringing to front
            BringToFront();
            //hiding initial form
    
        }

        //on close of the new reject form verifies that the user wanted to quit and then returns the home page to showing.
        private void NewReject_Closing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing && submitFlag == false)
            {
                e.Cancel = MessageBox.Show("Are you sure you want to exit? Exiting will erase all inputs.",
                    "Exit", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No;
            }
        }

        private void RejectTypeDropDown_SelectedIndexChanged(object sender, EventArgs e)
        {
            var type = RejectTypeDropDown.SelectedItem.ToString();
            Cursor.Current = Cursors.WaitCursor;
            var newRejectNum = GenerateRejectNumber(type);
            RejectNumberTextBox.Text = newRejectNum;
            if (newRejectNum != "R")
                RejectNumberTextBox.Enabled = false;
            else
                RejectNumberTextBox.Enabled = true;
            Cursor.Current = Cursors.Default;
        }

        private void SubmitRejectButton_Click(object sender, EventArgs e) //make it so u cannot submit
        {
            var res = false; //user input rsult
            var rejNum = RejectNumberTextBox.Text; //getting reject number
            requiredFields = new[]
            {
                RejectedByDropDown.Text, PartNumberTextBox.Text, DiscrepancyTextBox.Text, PartDescriptionTextBox.Text
            };

            //a required form is not filled out
            foreach (var field in requiredFields)
                if (string.IsNullOrEmpty(field))
                {
                    MessageBox.Show(
                        "One of the following required forms is empty: Rejected By, Part Number, Part Description, Discrepancy." +
                        field);
                    return;
                }


            if (checkRejectSelection() == false) return;
            res = MessageBox.Show("Are you sure you want to submit?",
                "Exit", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No;
            if (res) return;

            //make sure that the line reject number is not already taken(unlikely, but would break things).
            if (!finalRejectNumCheck(rejNum) && rejNum.ToString().Substring(0,1) != "R") 
            {
                rejNum = GenerateRejectNumber(RejectTypeDropDown.SelectedItem.ToString());
                MessageBox.Show("Reject_Number switched to: " + rejNum);
                RejectNumberTextBox.Text = rejNum;
            }
            //do not need to auto generate a reject number of 'R' type, as such we need to simply allow the user to enter a new value
            else if (!finalRejectNumCheck(rejNum) && rejNum.ToString().Substring(0, 1) == "R")
            {
                MessageBox.Show("The reject number " + rejNum + " is already taken.");
                return;
            }

            NewRejectOperation(this);
            //a submission was made- signal to close without prompting user to confirm.
            submitFlag = true; 
            Close();
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

        private void DispositionDropDown_SelectedIndexChanged(object sender, EventArgs e)
        {
            dateDispositionDropDown.Enabled = true;
            dateDispositionDropDown.Format = DateTimePickerFormat.Short;
        }


        private void pictureBox1_Click(object sender, EventArgs e)
        {
            PrintDisplay temDisplay = new PrintDisplay(this);
            temDisplay.Show();

        }

        private void UnitCostTextBox_TextChanged(object sender, EventArgs e)
        {
            var periodCount = 0;
            var index = 0;

            foreach (var num in UnitCostTextBox.Text)
            {
                if (char.IsDigit(num) && periodCount <= 1)
                {
                }
                else if (num == '.')
                {
                    periodCount++;
                }
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