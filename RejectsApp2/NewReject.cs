using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Printing;
using System.Windows.Forms;
using static RejectsApp2.Commands;

namespace RejectsApp2
{
    public partial class NewReject : Form
    {
        private readonly Home home;
        private Bitmap reportBitmap;
        private string[] requiredFields;
        private Bitmap resizeBitmap;
        private bool submitFlag;

        public NewReject(Home home)
        {
            InitializeComponent();
            TopLevel = true;
            this.home = home;
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
            home.Hide();
        }

        //on close of the new reject form verifies that the user wanted to quit and then returns the home page to showing.
        private void NewReject_Closing(object sender, FormClosingEventArgs e)
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
            var type = RejectTypeDropDown.SelectedItem.ToString();
            Cursor.Current = Cursors.WaitCursor;
            var newRejectNum = GenerateRejectNumber(type);
            RejectNumberTextBox.Text = newRejectNum;
            Cursor.Current = Cursors.Default;
        }

        private void SubmitRejectButton_Click(object sender, EventArgs e) //make it so u cannot submit
        {
            requiredFields = new[]
            {
                RejectedByDropDown.Text, PartNumberTextBox.Text, DiscrepancyTextBox.Text, PartDescriptionTextBox.Text
            };
            foreach (var field in requiredFields)
                if (string.IsNullOrEmpty(field))
                {
                    MessageBox.Show(
                        "One of the following required forms is empty: Rejected By, Part Number, Part Description, Discrepancy." +
                        field);
                    return;
                }

            var res = false;
            var rejNum = RejectNumberTextBox.Text;
            if (checkRejectSelection() == false) return;
            res = MessageBox.Show("Are you sure you want to submit?",
                "Exit", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No;
            if (res) return;

            if (!finalRejectNumCheck(rejNum)) //make sure that another user has not taken the ID
            {
                rejNum = GenerateRejectNumber(RejectTypeDropDown.SelectedItem.ToString());
                MessageBox.Show("Reject_Number switched to: " + rejNum);
                RejectNumberTextBox.Text = rejNum;
            }

            NewRejectOperation(this);
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

        private void DispositionDropDown_SelectedIndexChanged(object sender, EventArgs e)
        {
            dateDispositionDropDown.Enabled = true;
            dateDispositionDropDown.Format = DateTimePickerFormat.Short;
        }

        private void label2_Click(object sender, EventArgs e)
        {
        }

        private void RejectNumberTextBox_TextChanged(object sender, EventArgs e)
        {
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            var rejectReport = CreateGraphics();
            var s = pictureBox2.Size;
            reportBitmap = new Bitmap(s.Width, s.Height - 35, rejectReport);
            var memoryGraphics = Graphics.FromImage(reportBitmap);
            memoryGraphics.CopyFromScreen(Location.X + 10, Location.Y + 37, 0, 0, s);

            resizeBitmap = new Bitmap(1059, 841);
            var resizeforPrint = Graphics.FromImage(resizeBitmap);
            resizeforPrint.InterpolationMode = InterpolationMode.HighQualityBicubic;
            resizeforPrint.DrawImage(reportBitmap, 0, 0, 1059, 841);

            printPreviewDialog1.Document = printDocument1;
            printDocument1.DefaultPageSettings.Landscape = true;
            MessageBox.Show(printPreviewDialog1.Document.DefaultPageSettings.PaperSize.ToString());
            MessageBox.Show(printDocument1.DefaultPageSettings.PaperSize.ToString());
            printPreviewDialog1.ShowDialog();
        }

        private void printDocument1_PrintPage(object sender, PrintPageEventArgs e)
        {
            e.Graphics.DrawImage(resizeBitmap, 0, 0);
        }

        private void printPreviewDialog1_Load(object sender, EventArgs e)
        {
            printPreviewDialog1.Location = Location;
            printPreviewDialog1.Size = Size;
        }

        private void label8_Click(object sender, EventArgs e)
        {
        }

        private void label19_Click(object sender, EventArgs e)
        {
        }

        private void label20_Click(object sender, EventArgs e)
        {
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

        private void panel2_Paint(object sender, PaintEventArgs e)
        {
        }

        private void pictureBox2_Click(object sender, EventArgs e)
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