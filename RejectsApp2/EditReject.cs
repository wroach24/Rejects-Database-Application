using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Printing;
using System.Windows.Forms;
using static RejectsApp2.Commands;

namespace RejectsApp2
{
    public partial class EditReject : Form
    {
        private readonly Home home;
        private bool editFlag;
        private Bitmap reportBitmap;
        private Bitmap resizeBitmap;

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

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            var rejectReport = CreateGraphics();
            var s = Size;
            reportBitmap = new Bitmap(s.Width - 20, s.Height - 35, rejectReport);
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
            printPreviewDialog1.Location = home.Location;
            printPreviewDialog1.Size = Size;
            printPreviewDialog1.BringToFront();
        }

        private void UnitCostTextBox_VisibleChanged(object sender, EventArgs e)
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
    }
}