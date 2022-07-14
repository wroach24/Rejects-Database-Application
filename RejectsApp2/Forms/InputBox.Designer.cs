
namespace RejectsApp2
{
    partial class InputBox
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.SubmitID = new System.Windows.Forms.Button();
            this.cancelButton = new System.Windows.Forms.Button();
            this.rejectNumComboBox = new System.Windows.Forms.ComboBox();
            this.passwordTextbox = new System.Windows.Forms.TextBox();
            this.newPasswordTextbox = new System.Windows.Forms.TextBox();
            this.newPasswordLabel = new System.Windows.Forms.Label();
            this.currentPasswordlabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.75F);
            this.label1.Location = new System.Drawing.Point(12, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(228, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "Enter the Reject Number you wish to edit";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // SubmitID
            // 
            this.SubmitID.BackColor = System.Drawing.Color.GhostWhite;
            this.SubmitID.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.SubmitID.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.SubmitID.FlatAppearance.MouseDownBackColor = System.Drawing.Color.DarkBlue;
            this.SubmitID.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Lavender;
            this.SubmitID.Font = new System.Drawing.Font("SansSerif", 9.749999F);
            this.SubmitID.Location = new System.Drawing.Point(49, 89);
            this.SubmitID.Name = "SubmitID";
            this.SubmitID.Size = new System.Drawing.Size(64, 23);
            this.SubmitID.TabIndex = 2;
            this.SubmitID.Text = "Submit";
            this.SubmitID.UseVisualStyleBackColor = false;
            this.SubmitID.Click += new System.EventHandler(this.SubmitID_Click);
            // 
            // cancelButton
            // 
            this.cancelButton.BackColor = System.Drawing.Color.GhostWhite;
            this.cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelButton.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.cancelButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.DarkBlue;
            this.cancelButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Lavender;
            this.cancelButton.Font = new System.Drawing.Font("SansSerif", 9.749999F);
            this.cancelButton.Location = new System.Drawing.Point(128, 89);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(66, 23);
            this.cancelButton.TabIndex = 3;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.UseVisualStyleBackColor = false;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // rejectNumComboBox
            // 
            this.rejectNumComboBox.DropDownHeight = 75;
            this.rejectNumComboBox.FormattingEnabled = true;
            this.rejectNumComboBox.IntegralHeight = false;
            this.rejectNumComboBox.Location = new System.Drawing.Point(61, 39);
            this.rejectNumComboBox.Name = "rejectNumComboBox";
            this.rejectNumComboBox.Size = new System.Drawing.Size(121, 21);
            this.rejectNumComboBox.TabIndex = 4;
            this.rejectNumComboBox.SelectedIndexChanged += new System.EventHandler(this.rejectNumComboBox_SelectedIndexChanged);
            this.rejectNumComboBox.TextChanged += new System.EventHandler(this.rejectNumComboBox_TextChanged);
            // 
            // passwordTextbox
            // 
            this.passwordTextbox.Enabled = false;
            this.passwordTextbox.Location = new System.Drawing.Point(61, 30);
            this.passwordTextbox.Name = "passwordTextbox";
            this.passwordTextbox.PasswordChar = '*';
            this.passwordTextbox.Size = new System.Drawing.Size(121, 20);
            this.passwordTextbox.TabIndex = 5;
            this.passwordTextbox.Visible = false;
            this.passwordTextbox.TextChanged += new System.EventHandler(this.passwordTextbox_TextChanged);
            // 
            // newPasswordTextbox
            // 
            this.newPasswordTextbox.Enabled = false;
            this.newPasswordTextbox.Location = new System.Drawing.Point(61, 66);
            this.newPasswordTextbox.Name = "newPasswordTextbox";
            this.newPasswordTextbox.Size = new System.Drawing.Size(121, 20);
            this.newPasswordTextbox.TabIndex = 6;
            this.newPasswordTextbox.Visible = false;
            // 
            // newPasswordLabel
            // 
            this.newPasswordLabel.AutoSize = true;
            this.newPasswordLabel.Location = new System.Drawing.Point(58, 53);
            this.newPasswordLabel.Name = "newPasswordLabel";
            this.newPasswordLabel.Size = new System.Drawing.Size(78, 13);
            this.newPasswordLabel.TabIndex = 7;
            this.newPasswordLabel.Text = "New Password";
            this.newPasswordLabel.Visible = false;
            // 
            // currentPasswordlabel
            // 
            this.currentPasswordlabel.AutoSize = true;
            this.currentPasswordlabel.Location = new System.Drawing.Point(58, 15);
            this.currentPasswordlabel.Name = "currentPasswordlabel";
            this.currentPasswordlabel.Size = new System.Drawing.Size(90, 13);
            this.currentPasswordlabel.TabIndex = 8;
            this.currentPasswordlabel.Text = "Current Password";
            this.currentPasswordlabel.Visible = false;
            // 
            // InputBox
            // 
            this.AcceptButton = this.SubmitID;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(250, 115);
            this.ControlBox = false;
            this.Controls.Add(this.currentPasswordlabel);
            this.Controls.Add(this.newPasswordLabel);
            this.Controls.Add(this.newPasswordTextbox);
            this.Controls.Add(this.passwordTextbox);
            this.Controls.Add(this.rejectNumComboBox);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.SubmitID);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(400, 300);
            this.MinimizeBox = false;
            this.Name = "InputBox";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Edit Reject";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.InputBox_Load);
            this.TextChanged += new System.EventHandler(this.InputBox_TextChanged);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button SubmitID;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.ComboBox rejectNumComboBox;
        private System.Windows.Forms.TextBox passwordTextbox;
        private System.Windows.Forms.TextBox newPasswordTextbox;
        private System.Windows.Forms.Label newPasswordLabel;
        private System.Windows.Forms.Label currentPasswordlabel;
    }
}