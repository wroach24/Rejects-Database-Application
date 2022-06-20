
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
            this.YokogawaLogo = new System.Windows.Forms.PictureBox();
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
            this.Reports.Location = new System.Drawing.Point(318, 277);
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
            this.DeleteReject.Location = new System.Drawing.Point(318, 241);
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
            this.reportViewer1.Size = new System.Drawing.Size(396, 246);
            this.reportViewer1.TabIndex = 0;
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
            // Home
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoSize = true;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(54)))), ((int)(((byte)(75)))), ((int)(((byte)(109)))));
            this.ClientSize = new System.Drawing.Size(704, 450);
            this.Controls.Add(this.EditRejectButton);
            this.Controls.Add(this.DeleteReject);
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
            ((System.ComponentModel.ISupportInitialize)(this.YokogawaLogo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        


        #endregion

        private System.Windows.Forms.Button NewReject;
        private System.Windows.Forms.PictureBox YokogawaLogo;
        private System.Windows.Forms.TextBox title;
        private System.Windows.Forms.Button Reports;
        private System.Windows.Forms.Button DeleteReject;
        private System.Windows.Forms.Button EditRejectButton;
        private System.Windows.Forms.PrintPreviewDialog excelPrintPreview;
        public Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
    }
}

