using System;
using System.Windows.Forms;
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
            rejectPage = new NewReject(this);
            rejectPage.ShowDialog();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
        }

        private void DeleteReject_Click(object sender, EventArgs e)
        {
            var delRejectInput = new InputBox(this, "delete");
            delRejectInput.BringToFront();
            delRejectInput.ShowDialog();
        }

        private void Reports_Click(object sender, EventArgs e)
        {
            //var xd = new ExcelCreation("hhe");
            //xd.SrapDoc();
            var genForm = new DisplayReport(this);
            genForm.StartPosition = StartPosition;
            genForm.Show();
        }

        private void EditRejectButton_Click(object sender, EventArgs e)
        {
            var editRejectInput = new InputBox(this, "edit");

            editRejectInput.BringToFront();
            editRejectInput.ShowDialog();
        }

        private void YokogawaLogo_Click(object sender, EventArgs e)
        {
        }
    }
}