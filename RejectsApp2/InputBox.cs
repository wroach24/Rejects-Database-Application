using System;
using System.Windows.Forms;

namespace RejectsApp2
{
    public partial class InputBox : Form
    {
        public Home prnt;

        public InputBox(Home home)
        {
            InitializeComponent();
            prnt = home;
        }

        private void label1_Click(object sender, EventArgs e)
        {
        }

        private void InputBox_Load(object sender, EventArgs e)
        {
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
            var command = new Commands();
            var testReject = command.GetRejectByID(numberTextBox.Text);
            if (!string.IsNullOrEmpty(testReject.Reject_Number))
            {
                var editReject = new EditReject(prnt);
                editReject.Show();
                command.FillOutEditForm(testReject, editReject);
            }
            else
            {
                MessageBox.Show("Invalid Reject Number. Make sure you're including the letter.");
            }

            Close();
            Cursor.Current = Cursors.Default;
        }
    }
}