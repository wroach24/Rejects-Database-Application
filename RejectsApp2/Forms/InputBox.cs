using System;
using System.Windows.Forms;
using static RejectsApp2.Commands;
using static RejectsApp2.EditRejectCommands;

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

            //if type is edit and the input is not empty, perform the edit functions
            if (!string.IsNullOrEmpty(rejectNumInput.Reject_Number) && type == "edit")
            {
                var editReject = new EditReject(prnt);
                editReject.Show();
                FillOutEditForm(rejectNumInput, editReject);
            }
            //check if the type is delete , perform delete functions
            else if (!string.IsNullOrEmpty(rejectNumInput.Reject_Number) &&
                     type == "delete")
            {
                Name = "Delete Reject";
                var res = MessageBox.Show("Are you sure you want to DELETE? This action is irreversible.",
                    "Exit", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No;
                if (res) return;
                var delReject = deleteReject(rejectNumInput);
            }
            //if empty, inform user
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