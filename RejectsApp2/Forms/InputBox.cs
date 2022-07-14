using System;
using System.Windows.Forms;
using RejectsApp2.Properties;
using static RejectsApp2.Commands;

namespace RejectsApp2
{
    public partial class InputBox : Form
    {
        private readonly string type;

        public InputBox(string type)
        {
            InitializeComponent();
            this.type = type;
        }

        private void label1_Click(object sender, EventArgs e)
        {
        }

        private void InputBox_Load(object sender, EventArgs e)
        {
            var gatherRejectNums = new FieldItems('x');
            gatherRejectNums.FillRecentRejects(rejectNumComboBox);
            if (type == "delete")
            {
                label1.AutoSize = true;
                label1.Text = "Enter the Reject Number to delete.";
            }
            //if type is admin, set the combo box to not visible and show the simple textbox which has PaswordChar enabled.
            else if (type == "admin")
            {
                label1.AutoSize = true;
                label1.Text = "Enter the admin password.";
                rejectNumComboBox.Visible = false;
                rejectNumComboBox.Enabled = false;
                passwordTextbox.Visible = true;
                passwordTextbox.Enabled = true;
            }
            else if (type == "changePW")
            {
                label1.Hide();
                // changing appearance to fit the function
                newPasswordLabel.Visible = true;
                currentPasswordlabel.Visible = true;
                rejectNumComboBox.Visible = false;
                rejectNumComboBox.Enabled = false;
                passwordTextbox.Visible = true;
                passwordTextbox.Enabled = true;
                newPasswordTextbox.Visible = true;
                newPasswordTextbox.Enabled = true;
            }
        }


        private void cancelButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void SubmitID_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            //if type is admin 
            if (type == "admin")
            {
                Name = "Admin Log In";
                var inputPassword = passwordTextbox.Text;
                //check the password for correctness(not super secure, doesn't have to be for this app's purposes)
                if (inputPassword == passwords.Default.adminPassword)
                {
                    //perform operations after typecasting the owner back to home in order to access modifiers
                    var home = (Home)Owner;
                    home.label1.Visible = true;
                    home.panel1.Visible = true;
                    home.AdminLogInButton.Visible = false;
                }
                else
                {
                    MessageBox.Show("The password was incorrect");
                }

                Cursor.Current = Cursors.Default;
                return;
            }
            if (type == "changePW")
            {
                Name = "Admin Change PW";
                var inputPassword = passwordTextbox.Text;
                var newPassword = newPasswordTextbox.Text;
                //check the password for correctness(not super secure, doesn't have to be for this app's purposes)
                if (inputPassword == passwords.Default.adminPassword)
                {
                    //perform operations after typecasting the owner back to home in order to access modifiers
                    var home = (Home)Owner;
                    home.label1.Visible = true;
                    home.panel1.Visible = true;
                    home.AdminLogInButton.Visible = false;
                    

                    //check 1
                    var res = MessageBox.Show("Are you sure you want to CHANGE PASSWORD? This action is irreversible, make sure you have typed it correctly.",
                        "Exit", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No;
                    if (res) return;
                    Properties.passwords.Default.adminPassword = newPassword;
                    //check 2
                    var res2 = MessageBox.Show("Last confirmation: Are you sure you wish to change the admin password to: "+passwords.Default.adminPassword + " ?",
                        "Exit", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No;
                    if (res2) return;
                    //saves password
                    Properties.passwords.Default.Save();

                }
                else
                {
                    MessageBox.Show("The current password was incorrect");
                }

                Cursor.Current = Cursors.Default;
                return;
            }

            var rejectNum = rejectNumComboBox.Text;
            rejectNum = rejectNum.Replace("l", "L");
            rejectNum = rejectNum.Replace("r", "R");
            var rejectNumInput = GetRejectByID(rejectNum);

            //if type is edit and the input is not empty, perform the edit functions
           if (!string.IsNullOrEmpty(rejectNumInput.Reject_Number))
            {
                if (type == "edit")
                {
                    var editReject = new EditReject(rejectNumInput);
                    editReject.ShowDialog(this);
                }
                //check if the type is delete , perform delete functions
                else if (type == "delete")
                {
                    Name = "Delete Reject";
                    var res = MessageBox.Show("Are you sure you want to DELETE? This action is irreversible.",
                        "Exit", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No;
                    if (res) return;
                    var delReject = deleteReject(rejectNumInput);
                }
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

        private void rejectNumComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void passwordTextbox_TextChanged(object sender, EventArgs e)
        {
        }

        private void InputBox_TextChanged(object sender, EventArgs e)
        {
        }

        private void rejectNumComboBox_TextChanged(object sender, EventArgs e)
        {
        }
    }
}