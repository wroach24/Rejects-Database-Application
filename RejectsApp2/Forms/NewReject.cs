using System;
using System.Drawing;
using System.Windows.Forms;
using RejectsApp2.Forms;
using static RejectsApp2.NewRejectCommands;

namespace RejectsApp2
{
    public partial class NewReject : Form
    {
        private string[] requiredFields;
        private bool submitFlag;

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
            //setting the dateDisposition to display as empty, setting inital date to now.
            dateDispositionDropDown.Value = DateTime.Now;
            dateDispositionDropDown.CustomFormat = " ";
            dateDispositionDropDown.Format = DateTimePickerFormat.Custom;
            //setting the dateRejected initial time to now
            DateRejectedDropDown.Value = DateTime.Now;
            // setting new reject form to be offset from parent
            Location = new Point(Location.X + 5, Location.Y + 10);
        }

        //on close of the new reject form, verifies that the user wanted to quit.
        private void NewReject_Closing(object sender, FormClosingEventArgs e)
        {
            //submit flag signals that the program is sending the request to close, userinput is still eval'd as true even when program closes itself for some reasno
            if (e.CloseReason == CloseReason.UserClosing && submitFlag == false)
                e.Cancel = MessageBox.Show("Are you sure you want to exit? Exiting will erase all inputs.",
                    "Exit", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No;
        }

        //after selecting reject type generating reject number
        private void RejectTypeDropDown_SelectedIndexChanged(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
           
            var type = RejectTypeDropDown.SelectedItem.ToString(); //determing if R or L 
            var newRejectNum = GenerateRejectNumber(type);
            RejectNumberTextBox.Text = newRejectNum; //setting user display RejectNumber textbox to the generated number
            
            if (newRejectNum != "R") //if L, disable user input, else R so allow
                RejectNumberTextBox.Enabled = false;
            else
                RejectNumberTextBox.Enabled = true;

            Cursor.Current = Cursors.Default;
        }

        
        private void SubmitRejectButton_Click(object sender, EventArgs e) 
        {
            //if rejecttype is not selected, return
            if (checkRejectSelection() == false) return;

            var res = false; //user input result
            var rejNum = RejectNumberTextBox.Text; //getting reject number
            requiredFields = new[] //required inputs
            {
                RejectedByDropDown.Text, PartNumberTextBox.Text, DiscrepancyTextBox.Text, PartDescriptionTextBox.Text, QtyReceivedTextBox.Text
            };

            //checking required forms are filled out
            foreach (var field in requiredFields)
                if (string.IsNullOrEmpty(field))
                {
                    MessageBox.Show(
                        "One or more of the following required forms are empty: Quantity Received, Rejected By, Part Number, Part Description, Discrepancy." +
                        field);
                    return;
                }


            
            //confirming submission
            res = MessageBox.Show("Are you sure you want to submit?",
                "Exit", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No;
            if (res) return;

            //make sure that the line reject number is not already taken(unlikely, but would break things).
            if (!finalRejectNumCheck(rejNum) && rejNum.Substring(0, 1) != "R")
            {
                rejNum = GenerateRejectNumber(RejectTypeDropDown.SelectedItem.ToString());
                MessageBox.Show("Reject_Number switched to: " + rejNum);
                RejectNumberTextBox.Text = rejNum;
            }
            //do not need to auto generate a reject number of 'R' type, as such we need to simply allow the user to enter a new value
            else if (!finalRejectNumCheck(rejNum) && rejNum.Substring(0, 1) == "R")
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

        //once a disposition has been selected, enable the dispositiondate dropdown
        private void DispositionDropDown_SelectedIndexChanged(object sender, EventArgs e)
        {
            dateDispositionDropDown.Enabled = true;
            dateDispositionDropDown.Format = DateTimePickerFormat.Short;
        }

        //displays the print form
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            var temDisplay = new PrintDisplay(this);
            temDisplay.ShowDialog(this);
        }

        private void UnitCostTextBox_TextChanged(object sender, EventArgs e)
        {
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