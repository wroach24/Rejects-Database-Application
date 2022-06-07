using System;
using System.Windows.Forms;
using static RejectsApp2.Commands;

namespace RejectsApp2
{
    public partial class InputBox : Form
    {
        private readonly string type;
        public Home prnt;

        public InputBox(Home home, string type)
        {
            InitializeComponent();
            prnt = home;
            this.type = type;
        }

        private void label1_Click(object sender, EventArgs e)
        {
        }

        private void InputBox_Load(object sender, EventArgs e)
        {
            if (type == "delete")
            {
                label1.AutoSize = true;
                label1.Text = "Enter the Reject Number to delete.";
            }
        }

        private void numberTextBox_TextChanged(object sender, EventArgs e)
        {
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void SubmitID_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;

            var rejectNumInput = GetRejectByID(numberTextBox.Text);

            if (!string.IsNullOrEmpty(rejectNumInput.Reject_Number) && type == "edit")
            {
                var editReject = new EditReject(prnt);
                editReject.Show();
                FillOutEditForm(rejectNumInput, editReject);
            }
            else if (!string.IsNullOrEmpty(rejectNumInput.Reject_Number) &&
                     type == "delete") //add confirmatino for delete
            {
                var delReject = deleteReject(rejectNumInput);
            }
            else if (string.IsNullOrEmpty(rejectNumInput.Reject_Number))
            {
                MessageBox.Show("Invalid Reject Number. Make sure you're including the letter.");
            }
            else
            {
                MessageBox.Show("Something went wrong submitting ID.");
            }

            Close();
            Cursor.Current = Cursors.Default;
        }
    }
}