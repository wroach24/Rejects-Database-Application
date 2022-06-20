
namespace RejectsApp2
{
    partial class EditReject
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
            this.button2 = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.RejectTypeDropDown = new System.Windows.Forms.ComboBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.DateRejectedDropDown = new System.Windows.Forms.DateTimePicker();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.PONumberTextBox = new System.Windows.Forms.TextBox();
            this.LotNumberTextBox = new System.Windows.Forms.TextBox();
            this.PartDescriptionTextBox = new System.Windows.Forms.TextBox();
            this.SerialNumberTextBox = new System.Windows.Forms.TextBox();
            this.PartNumberTextBox = new System.Windows.Forms.TextBox();
            this.RejectNumberTextBox = new System.Windows.Forms.TextBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.VendorNameDropDown = new System.Windows.Forms.ComboBox();
            this.DispositionDropDown = new System.Windows.Forms.ComboBox();
            this.RejectedByDropDown = new System.Windows.Forms.ComboBox();
            this.ProductLineDropDown = new System.Windows.Forms.ComboBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.dateDispositionDropDown = new System.Windows.Forms.DateTimePicker();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.RMANumberTextBox = new System.Windows.Forms.TextBox();
            this.VendorIDTextbox = new System.Windows.Forms.TextBox();
            this.ResponsibleDropDown = new System.Windows.Forms.ComboBox();
            this.DiscrepancyTextBox = new System.Windows.Forms.RichTextBox();
            this.label18 = new System.Windows.Forms.Label();
            this.SubmitRejectButton = new System.Windows.Forms.Button();
            this.QtyReceivedTextBox = new System.Windows.Forms.TextBox();
            this.QtyInspectedTextBox = new System.Windows.Forms.TextBox();
            this.UnitCostTextBox = new System.Windows.Forms.TextBox();
            this.QtyRejectedTextBox = new System.Windows.Forms.TextBox();
            this.label19 = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.label22 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(0, 0);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 23;
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(54)))), ((int)(((byte)(75)))), ((int)(((byte)(109)))));
            this.label2.Font = new System.Drawing.Font("Malgun Gothic", 25.25F, System.Drawing.FontStyle.Bold);
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.label2.Location = new System.Drawing.Point(0, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(697, 55);
            this.label2.TabIndex = 4;
            this.label2.Text = "Non-conforming Material Record";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // RejectTypeDropDown
            // 
            this.RejectTypeDropDown.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.RejectTypeDropDown.Enabled = false;
            this.RejectTypeDropDown.FormattingEnabled = true;
            this.RejectTypeDropDown.Location = new System.Drawing.Point(7, 22);
            this.RejectTypeDropDown.Name = "RejectTypeDropDown";
            this.RejectTypeDropDown.Size = new System.Drawing.Size(121, 21);
            this.RejectTypeDropDown.TabIndex = 0;
            this.RejectTypeDropDown.SelectedIndexChanged += new System.EventHandler(this.RejectTypeDropDown_SelectedIndexChanged);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(54)))), ((int)(((byte)(75)))), ((int)(((byte)(109)))));
            this.panel1.Controls.Add(this.label9);
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.DateRejectedDropDown);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.PONumberTextBox);
            this.panel1.Controls.Add(this.LotNumberTextBox);
            this.panel1.Controls.Add(this.PartDescriptionTextBox);
            this.panel1.Controls.Add(this.SerialNumberTextBox);
            this.panel1.Controls.Add(this.PartNumberTextBox);
            this.panel1.Controls.Add(this.RejectNumberTextBox);
            this.panel1.Controls.Add(this.RejectTypeDropDown);
            this.panel1.Location = new System.Drawing.Point(0, 58);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(689, 129);
            this.panel1.TabIndex = 9;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.label9.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.label9.Location = new System.Drawing.Point(586, 57);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(82, 19);
            this.label9.TabIndex = 20;
            this.label9.Text = "PO Number";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.label8.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.label8.Location = new System.Drawing.Point(518, 57);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(63, 19);
            this.label8.TabIndex = 19;
            this.label8.Text = "Lot Num";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.label7.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.label7.Location = new System.Drawing.Point(279, 57);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(107, 19);
            this.label7.TabIndex = 18;
            this.label7.Text = "Part Description";
            // 
            // DateRejectedDropDown
            // 
            this.DateRejectedDropDown.CustomFormat = "";
            this.DateRejectedDropDown.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.DateRejectedDropDown.Location = new System.Drawing.Point(147, 79);
            this.DateRejectedDropDown.Name = "DateRejectedDropDown";
            this.DateRejectedDropDown.Size = new System.Drawing.Size(113, 20);
            this.DateRejectedDropDown.TabIndex = 4;
            this.DateRejectedDropDown.Value = new System.DateTime(2022, 5, 24, 11, 59, 12, 0);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.label6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.label6.Location = new System.Drawing.Point(147, 57);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(93, 19);
            this.label6.TabIndex = 17;
            this.label6.Text = "Date Rejected";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.label5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.label5.Location = new System.Drawing.Point(522, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(95, 19);
            this.label5.TabIndex = 12;
            this.label5.Text = "Serial Number";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.label4.Location = new System.Drawing.Point(272, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(88, 19);
            this.label4.TabIndex = 16;
            this.label4.Text = "Part Number";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.label1.Location = new System.Drawing.Point(7, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 19);
            this.label1.TabIndex = 10;
            this.label1.Text = "Reject Type";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.label3.Location = new System.Drawing.Point(147, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(99, 19);
            this.label3.TabIndex = 11;
            this.label3.Text = "Reject Number";
            // 
            // PONumberTextBox
            // 
            this.PONumberTextBox.Location = new System.Drawing.Point(586, 79);
            this.PONumberTextBox.MaxLength = 20;
            this.PONumberTextBox.Name = "PONumberTextBox";
            this.PONumberTextBox.Size = new System.Drawing.Size(103, 20);
            this.PONumberTextBox.TabIndex = 7;
            // 
            // LotNumberTextBox
            // 
            this.LotNumberTextBox.Location = new System.Drawing.Point(522, 79);
            this.LotNumberTextBox.MaxLength = 10;
            this.LotNumberTextBox.Name = "LotNumberTextBox";
            this.LotNumberTextBox.Size = new System.Drawing.Size(58, 20);
            this.LotNumberTextBox.TabIndex = 6;
            // 
            // PartDescriptionTextBox
            // 
            this.PartDescriptionTextBox.Location = new System.Drawing.Point(272, 79);
            this.PartDescriptionTextBox.MaxLength = 60;
            this.PartDescriptionTextBox.Name = "PartDescriptionTextBox";
            this.PartDescriptionTextBox.Size = new System.Drawing.Size(244, 20);
            this.PartDescriptionTextBox.TabIndex = 5;
            // 
            // SerialNumberTextBox
            // 
            this.SerialNumberTextBox.Location = new System.Drawing.Point(522, 22);
            this.SerialNumberTextBox.MaxLength = 60;
            this.SerialNumberTextBox.Name = "SerialNumberTextBox";
            this.SerialNumberTextBox.Size = new System.Drawing.Size(167, 20);
            this.SerialNumberTextBox.TabIndex = 3;
            // 
            // PartNumberTextBox
            // 
            this.PartNumberTextBox.Location = new System.Drawing.Point(272, 22);
            this.PartNumberTextBox.MaxLength = 100;
            this.PartNumberTextBox.Name = "PartNumberTextBox";
            this.PartNumberTextBox.Size = new System.Drawing.Size(244, 20);
            this.PartNumberTextBox.TabIndex = 2;
            // 
            // RejectNumberTextBox
            // 
            this.RejectNumberTextBox.Location = new System.Drawing.Point(147, 22);
            this.RejectNumberTextBox.MaxLength = 60;
            this.RejectNumberTextBox.Name = "RejectNumberTextBox";
            this.RejectNumberTextBox.ReadOnly = true;
            this.RejectNumberTextBox.Size = new System.Drawing.Size(113, 20);
            this.RejectNumberTextBox.TabIndex = 1;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(54)))), ((int)(((byte)(75)))), ((int)(((byte)(109)))));
            this.panel2.Controls.Add(this.VendorNameDropDown);
            this.panel2.Controls.Add(this.DispositionDropDown);
            this.panel2.Controls.Add(this.RejectedByDropDown);
            this.panel2.Controls.Add(this.ProductLineDropDown);
            this.panel2.Controls.Add(this.label10);
            this.panel2.Controls.Add(this.label11);
            this.panel2.Controls.Add(this.label12);
            this.panel2.Controls.Add(this.dateDispositionDropDown);
            this.panel2.Controls.Add(this.label13);
            this.panel2.Controls.Add(this.label14);
            this.panel2.Controls.Add(this.label15);
            this.panel2.Controls.Add(this.label16);
            this.panel2.Controls.Add(this.label17);
            this.panel2.Controls.Add(this.RMANumberTextBox);
            this.panel2.Controls.Add(this.VendorIDTextbox);
            this.panel2.Controls.Add(this.ResponsibleDropDown);
            this.panel2.Location = new System.Drawing.Point(0, 284);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(689, 112);
            this.panel2.TabIndex = 10;
            // 
            // VendorNameDropDown
            // 
            this.VendorNameDropDown.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.VendorNameDropDown.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.VendorNameDropDown.FormattingEnabled = true;
            this.VendorNameDropDown.IntegralHeight = false;
            this.VendorNameDropDown.Location = new System.Drawing.Point(171, 70);
            this.VendorNameDropDown.Name = "VendorNameDropDown";
            this.VendorNameDropDown.Size = new System.Drawing.Size(243, 21);
            this.VendorNameDropDown.Sorted = true;
            this.VendorNameDropDown.TabIndex = 18;
            // 
            // DispositionDropDown
            // 
            this.DispositionDropDown.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.DispositionDropDown.FormattingEnabled = true;
            this.DispositionDropDown.Location = new System.Drawing.Point(499, 22);
            this.DispositionDropDown.Name = "DispositionDropDown";
            this.DispositionDropDown.Size = new System.Drawing.Size(190, 21);
            this.DispositionDropDown.TabIndex = 16;
            this.DispositionDropDown.SelectedIndexChanged += new System.EventHandler(this.DispositionDropDown_SelectedIndexChanged);
            // 
            // RejectedByDropDown
            // 
            this.RejectedByDropDown.DropDownStyle = System.Windows.Forms.ComboBoxStyle.Simple;
            this.RejectedByDropDown.FormattingEnabled = true;
            this.RejectedByDropDown.Location = new System.Drawing.Point(335, 22);
            this.RejectedByDropDown.Name = "RejectedByDropDown";
            this.RejectedByDropDown.Size = new System.Drawing.Size(139, 21);
            this.RejectedByDropDown.Sorted = true;
            this.RejectedByDropDown.TabIndex = 15;
            // 
            // ProductLineDropDown
            // 
            this.ProductLineDropDown.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ProductLineDropDown.FormattingEnabled = true;
            this.ProductLineDropDown.Location = new System.Drawing.Point(171, 22);
            this.ProductLineDropDown.Name = "ProductLineDropDown";
            this.ProductLineDropDown.Size = new System.Drawing.Size(139, 21);
            this.ProductLineDropDown.Sorted = true;
            this.ProductLineDropDown.TabIndex = 14;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.label10.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.label10.Location = new System.Drawing.Point(563, 48);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(126, 19);
            this.label10.TabIndex = 20;
            this.label10.Text = "Date of Disposition";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.label11.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.label11.Location = new System.Drawing.Point(430, 48);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(93, 19);
            this.label11.TabIndex = 19;
            this.label11.Text = "RMA Number";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.label12.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.label12.Location = new System.Drawing.Point(171, 48);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(93, 19);
            this.label12.TabIndex = 18;
            this.label12.Text = "Vendor Name";
            // 
            // dateDispositionDropDown
            // 
            this.dateDispositionDropDown.CustomFormat = "";
            this.dateDispositionDropDown.Enabled = false;
            this.dateDispositionDropDown.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateDispositionDropDown.Location = new System.Drawing.Point(563, 70);
            this.dateDispositionDropDown.Name = "dateDispositionDropDown";
            this.dateDispositionDropDown.Size = new System.Drawing.Size(126, 20);
            this.dateDispositionDropDown.TabIndex = 20;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.label13.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.label13.Location = new System.Drawing.Point(7, 48);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(71, 19);
            this.label13.TabIndex = 17;
            this.label13.Text = "Vendor ID";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.label14.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.label14.Location = new System.Drawing.Point(499, 0);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(77, 19);
            this.label14.TabIndex = 12;
            this.label14.Text = "Disposition";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.label15.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.label15.Location = new System.Drawing.Point(335, 0);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(79, 19);
            this.label15.TabIndex = 16;
            this.label15.Text = "Rejected By";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.label16.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.label16.Location = new System.Drawing.Point(7, 0);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(81, 19);
            this.label16.TabIndex = 10;
            this.label16.Text = "Responsible";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.label17.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.label17.Location = new System.Drawing.Point(171, 0);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(86, 19);
            this.label17.TabIndex = 11;
            this.label17.Text = "Product Line";
            // 
            // RMANumberTextBox
            // 
            this.RMANumberTextBox.Location = new System.Drawing.Point(434, 70);
            this.RMANumberTextBox.MaxLength = 20;
            this.RMANumberTextBox.Name = "RMANumberTextBox";
            this.RMANumberTextBox.Size = new System.Drawing.Size(118, 20);
            this.RMANumberTextBox.TabIndex = 19;
            // 
            // VendorIDTextbox
            // 
            this.VendorIDTextbox.Location = new System.Drawing.Point(7, 70);
            this.VendorIDTextbox.MaxLength = 20;
            this.VendorIDTextbox.Name = "VendorIDTextbox";
            this.VendorIDTextbox.Size = new System.Drawing.Size(139, 20);
            this.VendorIDTextbox.TabIndex = 17;
            // 
            // ResponsibleDropDown
            // 
            this.ResponsibleDropDown.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ResponsibleDropDown.FormattingEnabled = true;
            this.ResponsibleDropDown.Location = new System.Drawing.Point(7, 22);
            this.ResponsibleDropDown.Name = "ResponsibleDropDown";
            this.ResponsibleDropDown.Size = new System.Drawing.Size(139, 21);
            this.ResponsibleDropDown.Sorted = true;
            this.ResponsibleDropDown.TabIndex = 13;
            // 
            // DiscrepancyTextBox
            // 
            this.DiscrepancyTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.DiscrepancyTextBox.Location = new System.Drawing.Point(7, 210);
            this.DiscrepancyTextBox.Name = "DiscrepancyTextBox";
            this.DiscrepancyTextBox.Size = new System.Drawing.Size(509, 68);
            this.DiscrepancyTextBox.TabIndex = 8;
            this.DiscrepancyTextBox.Text = "";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.label18.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.label18.Location = new System.Drawing.Point(7, 188);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(82, 19);
            this.label18.TabIndex = 12;
            this.label18.Text = "Discrepancy";
            // 
            // SubmitRejectButton
            // 
            this.SubmitRejectButton.BackColor = System.Drawing.Color.Gray;
            this.SubmitRejectButton.Font = new System.Drawing.Font("Tahoma", 15F, System.Drawing.FontStyle.Bold);
            this.SubmitRejectButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.SubmitRejectButton.Location = new System.Drawing.Point(447, 402);
            this.SubmitRejectButton.Name = "SubmitRejectButton";
            this.SubmitRejectButton.Size = new System.Drawing.Size(242, 42);
            this.SubmitRejectButton.TabIndex = 13;
            this.SubmitRejectButton.Text = "Submit Edit";
            this.SubmitRejectButton.UseVisualStyleBackColor = false;
            this.SubmitRejectButton.Click += new System.EventHandler(this.SubmitRejectButton_Click);
            // 
            // QtyReceivedTextBox
            // 
            this.QtyReceivedTextBox.Location = new System.Drawing.Point(522, 210);
            this.QtyReceivedTextBox.MaxLength = 15;
            this.QtyReceivedTextBox.Name = "QtyReceivedTextBox";
            this.QtyReceivedTextBox.Size = new System.Drawing.Size(85, 20);
            this.QtyReceivedTextBox.TabIndex = 9;
            // 
            // QtyInspectedTextBox
            // 
            this.QtyInspectedTextBox.Location = new System.Drawing.Point(613, 210);
            this.QtyInspectedTextBox.MaxLength = 15;
            this.QtyInspectedTextBox.Name = "QtyInspectedTextBox";
            this.QtyInspectedTextBox.Size = new System.Drawing.Size(76, 20);
            this.QtyInspectedTextBox.TabIndex = 10;
            // 
            // UnitCostTextBox
            // 
            this.UnitCostTextBox.Location = new System.Drawing.Point(613, 255);
            this.UnitCostTextBox.MaxLength = 15;
            this.UnitCostTextBox.Name = "UnitCostTextBox";
            this.UnitCostTextBox.Size = new System.Drawing.Size(76, 20);
            this.UnitCostTextBox.TabIndex = 12;
            this.UnitCostTextBox.TextChanged += new System.EventHandler(this.UnitCostTextBox_TextChanged);
            // 
            // QtyRejectedTextBox
            // 
            this.QtyRejectedTextBox.Location = new System.Drawing.Point(522, 255);
            this.QtyRejectedTextBox.MaxLength = 15;
            this.QtyRejectedTextBox.Name = "QtyRejectedTextBox";
            this.QtyRejectedTextBox.Size = new System.Drawing.Size(85, 20);
            this.QtyRejectedTextBox.TabIndex = 11;
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.label19.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.label19.Location = new System.Drawing.Point(518, 188);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(84, 17);
            this.label19.TabIndex = 19;
            this.label19.Text = "Qty Received";
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.label20.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.label20.Location = new System.Drawing.Point(609, 188);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(88, 17);
            this.label20.TabIndex = 20;
            this.label20.Text = "Qty Inspected";
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.label21.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.label21.Location = new System.Drawing.Point(611, 236);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(67, 19);
            this.label21.TabIndex = 22;
            this.label21.Text = "Unit Cost";
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.label22.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.label22.Location = new System.Drawing.Point(518, 236);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(87, 19);
            this.label22.TabIndex = 21;
            this.label22.Text = "Qty Rejected";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::RejectsApp2.Properties.Resources._6659021;
            this.pictureBox1.Location = new System.Drawing.Point(616, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(73, 55);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 24;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // EditReject
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.AutoSize = true;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(54)))), ((int)(((byte)(75)))), ((int)(((byte)(109)))));
            this.ClientSize = new System.Drawing.Size(698, 445);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.label21);
            this.Controls.Add(this.label22);
            this.Controls.Add(this.label20);
            this.Controls.Add(this.label19);
            this.Controls.Add(this.QtyRejectedTextBox);
            this.Controls.Add(this.UnitCostTextBox);
            this.Controls.Add(this.QtyInspectedTextBox);
            this.Controls.Add(this.QtyReceivedTextBox);
            this.Controls.Add(this.SubmitRejectButton);
            this.Controls.Add(this.label18);
            this.Controls.Add(this.DiscrepancyTextBox);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.panel1);
            this.MaximizeBox = false;
            this.Name = "EditReject";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "NewReject";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.EditReject_Closing);
            this.Load += new System.EventHandler(this.EditReject_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button2;
        
        
        private System.Windows.Forms.Label label2;
        public System.Windows.Forms.ComboBox RejectTypeDropDown;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Button SubmitRejectButton;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.Label label22;
        public System.Windows.Forms.Panel panel1;
        public System.Windows.Forms.TextBox LotNumberTextBox;
        public System.Windows.Forms.TextBox PartDescriptionTextBox;
        public System.Windows.Forms.TextBox SerialNumberTextBox;
        public System.Windows.Forms.TextBox PartNumberTextBox;
        public System.Windows.Forms.TextBox RejectNumberTextBox;
        public System.Windows.Forms.RichTextBox DiscrepancyTextBox;
        public System.Windows.Forms.TextBox QtyReceivedTextBox;
        public System.Windows.Forms.DateTimePicker DateRejectedDropDown;
        public System.Windows.Forms.TextBox PONumberTextBox;
        public System.Windows.Forms.Panel panel2;
        public System.Windows.Forms.ComboBox DispositionDropDown;
        public System.Windows.Forms.ComboBox RejectedByDropDown;
        public System.Windows.Forms.ComboBox ProductLineDropDown;
        public System.Windows.Forms.TextBox RMANumberTextBox;
        public System.Windows.Forms.TextBox VendorIDTextbox;
        public System.Windows.Forms.ComboBox ResponsibleDropDown;
        public System.Windows.Forms.ComboBox VendorNameDropDown;
        public System.Windows.Forms.TextBox QtyInspectedTextBox;
        public System.Windows.Forms.TextBox UnitCostTextBox;
        public System.Windows.Forms.TextBox QtyRejectedTextBox;
        public System.Windows.Forms.DateTimePicker dateDispositionDropDown;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}