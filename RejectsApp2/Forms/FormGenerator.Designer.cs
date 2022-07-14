
namespace RejectsApp2
{
    partial class FormGenerator
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
            this.components = new System.ComponentModel.Container();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.reportLayoutGroupBox = new System.Windows.Forms.GroupBox();
            this.DisplayAllButton = new System.Windows.Forms.Button();
            this.PartHistoryButton = new System.Windows.Forms.Button();
            this.OpenItemsButton = new System.Windows.Forms.Button();
            this.ProductLineButton = new System.Windows.Forms.Button();
            this.receivinginspectionButton = new System.Windows.Forms.Button();
            this.scrapReportButton = new System.Windows.Forms.Button();
            this.reportViewer2 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.selectionCriteriaGroupBox = new System.Windows.Forms.GroupBox();
            this.label7 = new System.Windows.Forms.Label();
            this.PartNumTextBox = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.dateRangeGroupBox = new System.Windows.Forms.GroupBox();
            this.EndDateLabel = new System.Windows.Forms.Label();
            this.StartDateLabel = new System.Windows.Forms.Label();
            this.dateTimePicker2 = new System.Windows.Forms.DateTimePicker();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.DateTooltip = new System.Windows.Forms.ToolTip(this.components);
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.reportLayoutGroupBox.SuspendLayout();
            this.selectionCriteriaGroupBox.SuspendLayout();
            this.dateRangeGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.HotTrack = true;
            this.tabControl1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.tabControl1.ItemSize = new System.Drawing.Size(70, 25);
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1005, 697);
            this.tabControl1.SizeMode = System.Windows.Forms.TabSizeMode.FillToRight;
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.tabPage1.Controls.Add(this.reportLayoutGroupBox);
            this.tabPage1.Controls.Add(this.reportViewer2);
            this.tabPage1.Controls.Add(this.selectionCriteriaGroupBox);
            this.tabPage1.Controls.Add(this.dateRangeGroupBox);
            this.tabPage1.Location = new System.Drawing.Point(4, 29);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(997, 664);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Reports";
            this.tabPage1.Click += new System.EventHandler(this.tabPage1_Click);
            // 
            // reportLayoutGroupBox
            // 
            this.reportLayoutGroupBox.Controls.Add(this.DisplayAllButton);
            this.reportLayoutGroupBox.Controls.Add(this.PartHistoryButton);
            this.reportLayoutGroupBox.Controls.Add(this.OpenItemsButton);
            this.reportLayoutGroupBox.Controls.Add(this.ProductLineButton);
            this.reportLayoutGroupBox.Controls.Add(this.receivinginspectionButton);
            this.reportLayoutGroupBox.Controls.Add(this.scrapReportButton);
            this.reportLayoutGroupBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.reportLayoutGroupBox.ForeColor = System.Drawing.SystemColors.ControlText;
            this.reportLayoutGroupBox.Location = new System.Drawing.Point(617, 6);
            this.reportLayoutGroupBox.Name = "reportLayoutGroupBox";
            this.reportLayoutGroupBox.Size = new System.Drawing.Size(373, 114);
            this.reportLayoutGroupBox.TabIndex = 3;
            this.reportLayoutGroupBox.TabStop = false;
            this.reportLayoutGroupBox.Text = "Report Type";
            // 
            // DisplayAllButton
            // 
            this.DisplayAllButton.Location = new System.Drawing.Point(248, 27);
            this.DisplayAllButton.Name = "DisplayAllButton";
            this.DisplayAllButton.Size = new System.Drawing.Size(112, 27);
            this.DisplayAllButton.TabIndex = 5;
            this.DisplayAllButton.Text = "All Info";
            this.DateTooltip.SetToolTip(this.DisplayAllButton, "Large reports may take a minute to load. ");
            this.DisplayAllButton.UseVisualStyleBackColor = true;
            this.DisplayAllButton.Click += new System.EventHandler(this.DisplayAllButton_Click);
            // 
            // PartHistoryButton
            // 
            this.PartHistoryButton.Location = new System.Drawing.Point(131, 63);
            this.PartHistoryButton.Name = "PartHistoryButton";
            this.PartHistoryButton.Size = new System.Drawing.Size(111, 26);
            this.PartHistoryButton.TabIndex = 4;
            this.PartHistoryButton.Text = "Part History";
            this.DateTooltip.SetToolTip(this.PartHistoryButton, "Large reports may take a minute to load. ");
            this.PartHistoryButton.UseVisualStyleBackColor = true;
            this.PartHistoryButton.Click += new System.EventHandler(this.button6_Click);
            // 
            // OpenItemsButton
            // 
            this.OpenItemsButton.Location = new System.Drawing.Point(6, 63);
            this.OpenItemsButton.Name = "OpenItemsButton";
            this.OpenItemsButton.Size = new System.Drawing.Size(119, 26);
            this.OpenItemsButton.TabIndex = 3;
            this.OpenItemsButton.Text = "Open Items";
            this.DateTooltip.SetToolTip(this.OpenItemsButton, "Large reports may take a minute to load. ");
            this.OpenItemsButton.UseVisualStyleBackColor = true;
            this.OpenItemsButton.Click += new System.EventHandler(this.button5_Click);
            // 
            // ProductLineButton
            // 
            this.ProductLineButton.Location = new System.Drawing.Point(248, 62);
            this.ProductLineButton.Name = "ProductLineButton";
            this.ProductLineButton.Size = new System.Drawing.Size(112, 27);
            this.ProductLineButton.TabIndex = 2;
            this.ProductLineButton.Text = "Product Line";
            this.DateTooltip.SetToolTip(this.ProductLineButton, "Large reports may take a minute to load. ");
            this.ProductLineButton.UseVisualStyleBackColor = true;
            this.ProductLineButton.Click += new System.EventHandler(this.button4_Click);
            // 
            // receivinginspectionButton
            // 
            this.receivinginspectionButton.Location = new System.Drawing.Point(130, 27);
            this.receivinginspectionButton.Name = "receivinginspectionButton";
            this.receivinginspectionButton.Size = new System.Drawing.Size(112, 27);
            this.receivinginspectionButton.TabIndex = 1;
            this.receivinginspectionButton.Text = "Rec. Inspection\r\n";
            this.DateTooltip.SetToolTip(this.receivinginspectionButton, "Large reports may take a minute to load. ");
            this.receivinginspectionButton.UseVisualStyleBackColor = true;
            this.receivinginspectionButton.Click += new System.EventHandler(this.button3_Click);
            // 
            // scrapReportButton
            // 
            this.scrapReportButton.Location = new System.Drawing.Point(6, 27);
            this.scrapReportButton.Name = "scrapReportButton";
            this.scrapReportButton.Size = new System.Drawing.Size(119, 27);
            this.scrapReportButton.TabIndex = 0;
            this.scrapReportButton.Text = "Scrap Report";
            this.DateTooltip.SetToolTip(this.scrapReportButton, "Large reports may take a minute to load. ");
            this.scrapReportButton.UseVisualStyleBackColor = true;
            this.scrapReportButton.Click += new System.EventHandler(this.button2_Click);
            // 
            // reportViewer2
            // 
            this.reportViewer2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.reportViewer2.Location = new System.Drawing.Point(0, 126);
            this.reportViewer2.Name = "reportViewer2";
            this.reportViewer2.ServerReport.BearerToken = null;
            this.reportViewer2.Size = new System.Drawing.Size(997, 538);
            this.reportViewer2.TabIndex = 2;
            this.DateTooltip.SetToolTip(this.reportViewer2, "Select one of the report types above to generate a report.");
            this.reportViewer2.WaitControlDisplayAfter = 200;
            this.reportViewer2.Load += new System.EventHandler(this.reportViewer2_Load);
            // 
            // selectionCriteriaGroupBox
            // 
            this.selectionCriteriaGroupBox.Controls.Add(this.label7);
            this.selectionCriteriaGroupBox.Controls.Add(this.PartNumTextBox);
            this.selectionCriteriaGroupBox.Controls.Add(this.label6);
            this.selectionCriteriaGroupBox.Controls.Add(this.label5);
            this.selectionCriteriaGroupBox.Controls.Add(this.label4);
            this.selectionCriteriaGroupBox.Controls.Add(this.textBox1);
            this.selectionCriteriaGroupBox.Controls.Add(this.comboBox2);
            this.selectionCriteriaGroupBox.Controls.Add(this.comboBox1);
            this.selectionCriteriaGroupBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.selectionCriteriaGroupBox.ForeColor = System.Drawing.SystemColors.ControlText;
            this.selectionCriteriaGroupBox.Location = new System.Drawing.Point(219, 6);
            this.selectionCriteriaGroupBox.Name = "selectionCriteriaGroupBox";
            this.selectionCriteriaGroupBox.Size = new System.Drawing.Size(341, 114);
            this.selectionCriteriaGroupBox.TabIndex = 1;
            this.selectionCriteriaGroupBox.TabStop = false;
            this.selectionCriteriaGroupBox.Text = "Selection Criteria";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label7.Location = new System.Drawing.Point(169, 63);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(66, 13);
            this.label7.TabIndex = 9;
            this.label7.Text = "Part Number";
            // 
            // PartNumTextBox
            // 
            this.PartNumTextBox.Location = new System.Drawing.Point(172, 81);
            this.PartNumTextBox.Name = "PartNumTextBox";
            this.PartNumTextBox.Size = new System.Drawing.Size(160, 21);
            this.PartNumTextBox.TabIndex = 8;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label6.Location = new System.Drawing.Point(169, 17);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(55, 13);
            this.label6.TabIndex = 7;
            this.label6.Text = "Vendor ID";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label5.Location = new System.Drawing.Point(6, 63);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(65, 13);
            this.label5.TabIndex = 6;
            this.label5.Text = "Responsible";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label4.Location = new System.Drawing.Point(6, 17);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(67, 13);
            this.label4.TabIndex = 5;
            this.label4.Text = "Product Line";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(172, 33);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(160, 21);
            this.textBox1.TabIndex = 2;
            // 
            // comboBox2
            // 
            this.comboBox2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.Items.AddRange(new object[] {
            ""});
            this.comboBox2.Location = new System.Drawing.Point(6, 79);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(160, 23);
            this.comboBox2.TabIndex = 1;
            // 
            // comboBox1
            // 
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            ""});
            this.comboBox1.Location = new System.Drawing.Point(6, 33);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(160, 23);
            this.comboBox1.TabIndex = 0;
            // 
            // dateRangeGroupBox
            // 
            this.dateRangeGroupBox.Controls.Add(this.EndDateLabel);
            this.dateRangeGroupBox.Controls.Add(this.StartDateLabel);
            this.dateRangeGroupBox.Controls.Add(this.dateTimePicker2);
            this.dateRangeGroupBox.Controls.Add(this.dateTimePicker1);
            this.dateRangeGroupBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateRangeGroupBox.ForeColor = System.Drawing.SystemColors.ControlText;
            this.dateRangeGroupBox.Location = new System.Drawing.Point(8, 6);
            this.dateRangeGroupBox.Name = "dateRangeGroupBox";
            this.dateRangeGroupBox.Size = new System.Drawing.Size(170, 114);
            this.dateRangeGroupBox.TabIndex = 0;
            this.dateRangeGroupBox.TabStop = false;
            this.dateRangeGroupBox.Text = "Date Range";
            // 
            // EndDateLabel
            // 
            this.EndDateLabel.AutoSize = true;
            this.EndDateLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.EndDateLabel.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.EndDateLabel.Location = new System.Drawing.Point(20, 57);
            this.EndDateLabel.Name = "EndDateLabel";
            this.EndDateLabel.Size = new System.Drawing.Size(52, 13);
            this.EndDateLabel.TabIndex = 5;
            this.EndDateLabel.Text = "End Date";
            // 
            // StartDateLabel
            // 
            this.StartDateLabel.AutoSize = true;
            this.StartDateLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.StartDateLabel.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.StartDateLabel.Location = new System.Drawing.Point(20, 17);
            this.StartDateLabel.Name = "StartDateLabel";
            this.StartDateLabel.Size = new System.Drawing.Size(52, 13);
            this.StartDateLabel.TabIndex = 4;
            this.StartDateLabel.Text = "StartDate";
            // 
            // dateTimePicker2
            // 
            this.dateTimePicker2.Checked = false;
            this.dateTimePicker2.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePicker2.Location = new System.Drawing.Point(23, 73);
            this.dateTimePicker2.Name = "dateTimePicker2";
            this.dateTimePicker2.ShowCheckBox = true;
            this.dateTimePicker2.Size = new System.Drawing.Size(122, 21);
            this.dateTimePicker2.TabIndex = 1;
            this.DateTooltip.SetToolTip(this.dateTimePicker2, "Checking and unchecking the box enables/disables sorting by date.");
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Checked = false;
            this.dateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePicker1.Location = new System.Drawing.Point(23, 33);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.ShowCheckBox = true;
            this.dateTimePicker1.Size = new System.Drawing.Size(122, 21);
            this.dateTimePicker1.TabIndex = 0;
            this.DateTooltip.SetToolTip(this.dateTimePicker1, "Checking and unchecking the box enables/disables sorting by date.");
            // 
            // FormGenerator
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(54)))), ((int)(((byte)(75)))), ((int)(((byte)(109)))));
            this.ClientSize = new System.Drawing.Size(1008, 693);
            this.Controls.Add(this.tabControl1);
            this.Name = "FormGenerator";
            this.Text = "FormGenerator";
            this.Load += new System.EventHandler(this.FormGenerator_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.reportLayoutGroupBox.ResumeLayout(false);
            this.selectionCriteriaGroupBox.ResumeLayout(false);
            this.selectionCriteriaGroupBox.PerformLayout();
            this.dateRangeGroupBox.ResumeLayout(false);
            this.dateRangeGroupBox.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.GroupBox selectionCriteriaGroupBox;
        private System.Windows.Forms.GroupBox dateRangeGroupBox;
        private System.Windows.Forms.GroupBox reportLayoutGroupBox;
        private System.Windows.Forms.Button PartHistoryButton;
        private System.Windows.Forms.Button OpenItemsButton;
        private System.Windows.Forms.Button ProductLineButton;
        private System.Windows.Forms.Button receivinginspectionButton;
        private System.Windows.Forms.Button scrapReportButton;
        public System.Windows.Forms.DateTimePicker dateTimePicker2;
        public System.Windows.Forms.DateTimePicker dateTimePicker1;
        public System.Windows.Forms.ComboBox comboBox1;
        public System.Windows.Forms.TextBox textBox1;
        public System.Windows.Forms.ComboBox comboBox2;
        public Microsoft.Reporting.WinForms.ReportViewer reportViewer2;
        private System.Windows.Forms.Label EndDateLabel;
        private System.Windows.Forms.Label StartDateLabel;
        private System.Windows.Forms.ToolTip DateTooltip;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label7;
        public System.Windows.Forms.TextBox PartNumTextBox;
        private System.Windows.Forms.Button DisplayAllButton;
    }
}