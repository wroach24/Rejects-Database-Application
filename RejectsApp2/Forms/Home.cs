using System;
using System.Drawing;
using System.Windows.Forms;
using RejectsApp2.Forms;
using static RejectsApp2.Commands;

namespace RejectsApp2
{
    public partial class Home : Form
    {
        public NewReject rejectPage;

        public Home()
        {
            InitializeComponent();
            Cursor.Current = Cursors.AppStarting;
            GetRejectByID("");
            Cursor.Current = Cursors.Default;
        }

        private void Home_Load(object sender, EventArgs e)
        {
        }

        public void NewReject_Click(object sender, EventArgs e)
        {
            rejectPage = new NewReject();
            rejectPage.ShowDialog(this);
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
        }

        private void DeleteReject_Click(object sender, EventArgs e)
        {
            var delRejectInput = new InputBox("delete");
            delRejectInput.ShowDialog(this);
        }

        private void Reports_Click(object sender, EventArgs e)
        {
            var genform2 = new FormGenerator();
            genform2.Show(this);
            genform2.Location = new Point(Location.X + 20, Location.Y + 20);
        }


        private void EditRejectButton_Click(object sender, EventArgs e)
        {
            var editRejectInput = new InputBox("edit");
            editRejectInput.ShowDialog(this);
        }

        private void YokogawaLogo_Click(object sender, EventArgs e)
        {
        }

        private void editFieldsButton_Click(object sender, EventArgs e)
        {
            var editFields = new EditFields();
            editFields.ShowDialog(this);
        }

        private void AdminLogInButton_Click(object sender, EventArgs e)
        {
            var passwordInput = new InputBox("admin");
            passwordInput.ShowDialog(this);
        }
    }
}