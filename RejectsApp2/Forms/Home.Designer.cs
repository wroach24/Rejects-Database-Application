
namespace RejectsApp2
{
    partial class Home
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Home));
            this.NewReject = new System.Windows.Forms.Button();
            this.title = new System.Windows.Forms.TextBox();
            this.Reports = new System.Windows.Forms.Button();
            this.DeleteReject = new System.Windows.Forms.Button();
            this.EditRejectButton = new System.Windows.Forms.Button();
            this.excelPrintPreview = new System.Windows.Forms.PrintPreviewDialog();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.editFieldsButton = new System.Windows.Forms.Button();
            this.YokogawaLogo = new System.Windows.Forms.PictureBox();
            this.AdminLogInButton = new System.Windows.Forms.Button();
            this.ManualBackupButton = new System.Windows.Forms.Button();
            this.ChangePasswordButton = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.YokogawaLogo)).BeginInit();
            this.SuspendLayout();
            // 
            // NewReject
            // 
            this.NewReject.BackColor = System.Drawing.Color.GhostWhite;
            this.NewReject.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.NewReject.FlatAppearance.MouseDownBackColor = System.Drawing.Color.DarkBlue;
            this.NewReject.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Lavender;
            this.NewReject.Font = new System.Drawing.Font("SansSerif", 9.749999F);
            this.NewReject.Location = new System.Drawing.Point(318, 169);
            this.NewReject.Name = "NewReject";
            this.NewReject.Size = new System.Drawing.Size(94, 30);
            this.NewReject.TabIndex = 0;
            this.NewReject.Text = "New Reject";
            this.NewReject.UseVisualStyleBackColor = false;
            this.NewReject.Click += new System.EventHandler(this.NewReject_Click);
            // 
            // title
            // 
            this.title.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(54)))), ((int)(((byte)(75)))), ((int)(((byte)(109)))));
            this.title.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.title.Font = new System.Drawing.Font("SansSerif", 20F, System.Drawing.FontStyle.Bold);
            this.title.Location = new System.Drawing.Point(170, 132);
            this.title.Name = "title";
            this.title.ReadOnly = true;
            this.title.Size = new System.Drawing.Size(397, 31);
            this.title.TabIndex = 2;
            this.title.Text = "NON-CONFORMING MATERIALS";
            this.title.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // Reports
            // 
            this.Reports.BackColor = System.Drawing.Color.GhostWhite;
            this.Reports.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.Reports.FlatAppearance.MouseDownBackColor = System.Drawing.Color.DarkBlue;
            this.Reports.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Lavender;
            this.Reports.Font = new System.Drawing.Font("SansSerif", 9.749999F);
            this.Reports.Location = new System.Drawing.Point(318, 241);
            this.Reports.Name = "Reports";
            this.Reports.Size = new System.Drawing.Size(94, 30);
            this.Reports.TabIndex = 3;
            this.Reports.Text = "Reports";
            this.Reports.UseVisualStyleBackColor = false;
            this.Reports.Click += new System.EventHandler(this.Reports_Click);
            // 
            // DeleteReject
            // 
            this.DeleteReject.BackColor = System.Drawing.Color.GhostWhite;
            this.DeleteReject.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.DeleteReject.FlatAppearance.MouseDownBackColor = System.Drawing.Color.DarkBlue;
            this.DeleteReject.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Lavender;
            this.DeleteReject.Font = new System.Drawing.Font("SansSerif", 9.749999F);
            this.DeleteReject.Location = new System.Drawing.Point(52, 3);
            this.DeleteReject.Name = "DeleteReject";
            this.DeleteReject.Size = new System.Drawing.Size(94, 30);
            this.DeleteReject.TabIndex = 4;
            this.DeleteReject.Text = "Delete Reject";
            this.DeleteReject.UseVisualStyleBackColor = false;
            this.DeleteReject.Click += new System.EventHandler(this.DeleteReject_Click);
            // 
            // EditRejectButton
            // 
            this.EditRejectButton.BackColor = System.Drawing.Color.GhostWhite;
            this.EditRejectButton.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.EditRejectButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.DarkBlue;
            this.EditRejectButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Lavender;
            this.EditRejectButton.Font = new System.Drawing.Font("SansSerif", 9.749999F);
            this.EditRejectButton.Location = new System.Drawing.Point(318, 205);
            this.EditRejectButton.Name = "EditRejectButton";
            this.EditRejectButton.Size = new System.Drawing.Size(94, 30);
            this.EditRejectButton.TabIndex = 5;
            this.EditRejectButton.Text = "Edit Reject";
            this.EditRejectButton.UseVisualStyleBackColor = false;
            this.EditRejectButton.Click += new System.EventHandler(this.EditRejectButton_Click);
            // 
            // excelPrintPreview
            // 
            this.excelPrintPreview.AutoScrollMargin = new System.Drawing.Size(0, 0);
            this.excelPrintPreview.AutoScrollMinSize = new System.Drawing.Size(0, 0);
            this.excelPrintPreview.ClientSize = new System.Drawing.Size(400, 300);
            this.excelPrintPreview.Enabled = true;
            this.excelPrintPreview.Icon = ((System.Drawing.Icon)(resources.GetObject("excelPrintPreview.Icon")));
            this.excelPrintPreview.Name = "excelPrintPreview";
            this.excelPrintPreview.Visible = false;
            // 
            // reportViewer1
            // 
            this.reportViewer1.Location = new System.Drawing.Point(0, 0);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.ServerReport.BearerToken = null;
            this.reportViewer1.Size = new System.Drawing.Size(396, 246);
            this.reportViewer1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(315, 274);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(99, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "ADMIN ACCESS";
            this.label1.Visible = false;
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.ChangePasswordButton);
            this.panel1.Controls.Add(this.ManualBackupButton);
            this.panel1.Controls.Add(this.editFieldsButton);
            this.panel1.Controls.Add(this.DeleteReject);
            this.panel1.Location = new System.Drawing.Point(265, 290);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(200, 162);
            this.panel1.TabIndex = 8;
            this.panel1.Visible = false;
            // 
            // editFieldsButton
            // 
            this.editFieldsButton.BackColor = System.Drawing.Color.GhostWhite;
            this.editFieldsButton.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.editFieldsButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.DarkBlue;
            this.editFieldsButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Lavender;
            this.editFieldsButton.Font = new System.Drawing.Font("SansSerif", 9.749999F);
            this.editFieldsButton.Location = new System.Drawing.Point(52, 39);
            this.editFieldsButton.Name = "editFieldsButton";
            this.editFieldsButton.Size = new System.Drawing.Size(94, 30);
            this.editFieldsButton.TabIndex = 5;
            this.editFieldsButton.Text = "Edit Fields";
            this.editFieldsButton.UseVisualStyleBackColor = false;
            this.editFieldsButton.Click += new System.EventHandler(this.editFieldsButton_Click);
            // 
            // YokogawaLogo
            // 
            this.YokogawaLogo.Image = ((System.Drawing.Image)(resources.GetObject("YokogawaLogo.Image")));
            this.YokogawaLogo.Location = new System.Drawing.Point(170, 49);
            this.YokogawaLogo.Name = "YokogawaLogo";
            this.YokogawaLogo.Size = new System.Drawing.Size(401, 77);
            this.YokogawaLogo.TabIndex = 6;
            this.YokogawaLogo.TabStop = false;
            this.YokogawaLogo.Click += new System.EventHandler(this.YokogawaLogo_Click);
            // 
            // AdminLogInButton
            // 
            this.AdminLogInButton.BackColor = System.Drawing.Color.GhostWhite;
            this.AdminLogInButton.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.AdminLogInButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.DarkBlue;
            this.AdminLogInButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Lavender;
            this.AdminLogInButton.Font = new System.Drawing.Font("SansSerif", 9.749999F);
            this.AdminLogInButton.Location = new System.Drawing.Point(591, 402);
            this.AdminLogInButton.Name = "AdminLogInButton";
            this.AdminLogInButton.Size = new System.Drawing.Size(101, 30);
            this.AdminLogInButton.TabIndex = 9;
            this.AdminLogInButton.Text = "Admin Log In";
            this.AdminLogInButton.UseVisualStyleBackColor = false;
            this.AdminLogInButton.Click += new System.EventHandler(this.AdminLogInButton_Click);
            // 
            // ManualBackupButton
            // 
            this.ManualBackupButton.BackColor = System.Drawing.Color.GhostWhite;
            this.ManualBackupButton.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.ManualBackupButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.DarkBlue;
            this.ManualBackupButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Lavender;
            this.ManualBackupButton.Font = new System.Drawing.Font("SansSerif", 9.749999F);
            this.ManualBackupButton.Location = new System.Drawing.Point(52, 75);
            this.ManualBackupButton.Name = "ManualBackupButton";
            this.ManualBackupButton.Size = new System.Drawing.Size(94, 30);
            this.ManualBackupButton.TabIndex = 6;
            this.ManualBackupButton.Text = "Backup DB";
            this.ManualBackupButton.UseVisualStyleBackColor = false;
            this.ManualBackupButton.Click += new System.EventHandler(this.ManualBackupButton_Click);
            // 
            // ChangePasswordButton
            // 
            this.ChangePasswordButton.BackColor = System.Drawing.Color.GhostWhite;
            this.ChangePasswordButton.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.ChangePasswordButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.DarkBlue;
            this.ChangePasswordButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Lavender;
            this.ChangePasswordButton.Font = new System.Drawing.Font("SansSerif", 9.749999F);
            this.ChangePasswordButton.Location = new System.Drawing.Point(52, 111);
            this.ChangePasswordButton.Name = "ChangePasswordButton";
            this.ChangePasswordButton.Size = new System.Drawing.Size(94, 30);
            this.ChangePasswordButton.TabIndex = 7;
            this.ChangePasswordButton.Text = "Change PW";
            this.ChangePasswordButton.UseVisualStyleBackColor = false;
            this.ChangePasswordButton.Click += new System.EventHandler(this.ChangePasswordButton_Click);
            // 
            // Home
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoSize = true;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(54)))), ((int)(((byte)(75)))), ((int)(((byte)(109)))));
            this.ClientSize = new System.Drawing.Size(704, 450);
            this.Controls.Add(this.AdminLogInButton);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.EditRejectButton);
            this.Controls.Add(this.Reports);
            this.Controls.Add(this.title);
            this.Controls.Add(this.YokogawaLogo);
            this.Controls.Add(this.NewReject);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Home";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Yokogawa Rejects";
            this.Load += new System.EventHandler(this.Home_Load);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.YokogawaLogo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        


        #endregion

        private System.Windows.Forms.Button NewReject;
        private System.Windows.Forms.PictureBox YokogawaLogo;
        private System.Windows.Forms.TextBox title;
        private System.Windows.Forms.Button Reports;
        private System.Windows.Forms.Button EditRejectButton;
        private System.Windows.Forms.PrintPreviewDialog excelPrintPreview;
        public Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        public System.Windows.Forms.Button DeleteReject;
        public System.Windows.Forms.Label label1;
        public System.Windows.Forms.Panel panel1;
        public System.Windows.Forms.Button editFieldsButton;
        public System.Windows.Forms.Button AdminLogInButton;
        public System.Windows.Forms.Button ChangePasswordButton;
        public System.Windows.Forms.Button ManualBackupButton;
    }
}

