
namespace RejectsApp2.Forms
{
    partial class EditFields
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
            this.OriginalBox = new System.Windows.Forms.ListBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.InputBox = new System.Windows.Forms.TextBox();
            this.revisionTypeBox = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.FieldTypeBox = new System.Windows.Forms.ComboBox();
            this.SubmitChangeButton = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // OriginalBox
            // 
            this.OriginalBox.Cursor = System.Windows.Forms.Cursors.Hand;
            this.OriginalBox.FormattingEnabled = true;
            this.OriginalBox.Location = new System.Drawing.Point(3, 100);
            this.OriginalBox.Name = "OriginalBox";
            this.OriginalBox.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple;
            this.OriginalBox.Size = new System.Drawing.Size(337, 238);
            this.OriginalBox.Sorted = true;
            this.OriginalBox.TabIndex = 0;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label6.Location = new System.Drawing.Point(177, 4);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(162, 13);
            this.label6.TabIndex = 11;
            this.label6.Text = "Input Value(only used for adding)";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label4.Location = new System.Drawing.Point(3, 4);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(75, 13);
            this.label4.TabIndex = 10;
            this.label4.Text = "Revision Type";
            // 
            // InputBox
            // 
            this.InputBox.Location = new System.Drawing.Point(180, 20);
            this.InputBox.Name = "InputBox";
            this.InputBox.Size = new System.Drawing.Size(160, 20);
            this.InputBox.TabIndex = 9;
            // 
            // revisionTypeBox
            // 
            this.revisionTypeBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.revisionTypeBox.FormattingEnabled = true;
            this.revisionTypeBox.Items.AddRange(new object[] {
            "Add",
            "Delete"});
            this.revisionTypeBox.Location = new System.Drawing.Point(3, 20);
            this.revisionTypeBox.Name = "revisionTypeBox";
            this.revisionTypeBox.Size = new System.Drawing.Size(160, 21);
            this.revisionTypeBox.TabIndex = 8;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label1.Location = new System.Drawing.Point(3, 44);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(62, 13);
            this.label1.TabIndex = 13;
            this.label1.Text = "Field to Edit";
            // 
            // FieldTypeBox
            // 
            this.FieldTypeBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.FieldTypeBox.FormattingEnabled = true;
            this.FieldTypeBox.Items.AddRange(new object[] {
            "Product_Lines",
            "Vendors",
            "Responsible"});
            this.FieldTypeBox.Location = new System.Drawing.Point(3, 60);
            this.FieldTypeBox.Name = "FieldTypeBox";
            this.FieldTypeBox.Size = new System.Drawing.Size(160, 21);
            this.FieldTypeBox.TabIndex = 12;
            this.FieldTypeBox.SelectedIndexChanged += new System.EventHandler(this.FieldTypeBox_SelectedIndexChanged);
            // 
            // SubmitChangeButton
            // 
            this.SubmitChangeButton.Location = new System.Drawing.Point(124, 344);
            this.SubmitChangeButton.Name = "SubmitChangeButton";
            this.SubmitChangeButton.Size = new System.Drawing.Size(103, 29);
            this.SubmitChangeButton.TabIndex = 15;
            this.SubmitChangeButton.Text = "Submit Change";
            this.SubmitChangeButton.UseVisualStyleBackColor = true;
            this.SubmitChangeButton.Click += new System.EventHandler(this.SubmitChangeButton_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label3.Location = new System.Drawing.Point(3, 84);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(128, 13);
            this.label3.TabIndex = 17;
            this.label3.Text = "Field Items(click to select)";
            // 
            // EditFields
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(350, 377);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.SubmitChangeButton);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.FieldTypeBox);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.InputBox);
            this.Controls.Add(this.revisionTypeBox);
            this.Controls.Add(this.OriginalBox);
            this.Name = "EditFields";
            this.Text = "Edit Fields";
            this.Load += new System.EventHandler(this.EditFields_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox OriginalBox;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label4;
        public System.Windows.Forms.TextBox InputBox;
        public System.Windows.Forms.ComboBox revisionTypeBox;
        private System.Windows.Forms.Label label1;
        public System.Windows.Forms.ComboBox FieldTypeBox;
        private System.Windows.Forms.Button SubmitChangeButton;
        private System.Windows.Forms.Label label3;
    }
}