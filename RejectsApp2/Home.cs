using System;
using System.Windows.Forms;

namespace RejectsApp2
{
    public partial class Home : Form
    {
        public NewReject rejectPage;

        public Home()
        {
            InitializeComponent();
            var command = new Commands();
            Cursor.Current = Cursors.AppStarting;
            command.GetRejectByID("");
            Cursor.Current = Cursors.Default;
        }

        private void Home_Load(object sender, EventArgs e)
        {
        }

        public void NewReject_Click(object sender, EventArgs e)
        {
            rejectPage = new NewReject(this);
            rejectPage.Location = Location;
            rejectPage.ShowDialog();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
        }

        private void DeleteReject_Click(object sender, EventArgs e)
        {
        }

        private void Reports_Click(object sender, EventArgs e)
        {
        }

        private void EditRejectButton_Click(object sender, EventArgs e)
        {
            var editRejectInput = new InputBox(this);

            editRejectInput.BringToFront();
            editRejectInput.ShowDialog();
        }
    }
}