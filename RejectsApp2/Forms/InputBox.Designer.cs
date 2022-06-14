
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
            this.numberTextBox = new System.Windows.Forms.TextBox();
            this.SubmitID = new System.Windows.Forms.Button();
            this.cancelButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.75F);
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(228, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "Enter the Reject Number you wish to edit";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // numberTextBox
            // 
            this.numberTextBox.Location = new System.Drawing.Point(47, 43);
            this.numberTextBox.MaxLength = 30;
            this.numberTextBox.Name = "numberTextBox";
            this.numberTextBox.Size = new System.Drawing.Size(148, 20);
            this.numberTextBox.TabIndex = 1;
            this.numberTextBox.TextChanged += new System.EventHandler(this.numberTextBox_TextChanged);
            // 
            // SubmitID
            // 
            this.SubmitID.BackColor = System.Drawing.Color.GhostWhite;
            this.SubmitID.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.SubmitID.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.SubmitID.FlatAppearance.MouseDownBackColor = System.Drawing.Color.DarkBlue;
            this.SubmitID.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Lavender;
            this.SubmitID.Font = new System.Drawing.Font("SansSerif", 9.749999F);
            this.SubmitID.Location = new System.Drawing.Point(47, 80);
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
            this.cancelButton.Location = new System.Drawing.Point(129, 80);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(66, 23);
            this.cancelButton.TabIndex = 3;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.UseVisualStyleBackColor = false;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // InputBox
            // 
            this.AcceptButton = this.SubmitID;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(250, 115);
            this.ControlBox = false;
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.SubmitID);
            this.Controls.Add(this.numberTextBox);
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
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox numberTextBox;
        private System.Windows.Forms.Button SubmitID;
        private System.Windows.Forms.Button cancelButton;
    }
}