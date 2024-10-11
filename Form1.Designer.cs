namespace FlightBookingApp
{
    partial class Form1
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
            txtDestination = new TextBox();
            txtFlightNumber = new TextBox();
            txtLastName = new TextBox();
            txtFirstName = new TextBox();
            txtMiddleName = new TextBox();
            txtPassportNumber = new TextBox();
            dtpDepartureDate = new DateTimePicker();
            btnAddBooking = new Button();
            btnRemoveBooking = new Button();
            btnFilter = new Button();
            lstBookings = new ListBox();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            label6 = new Label();
            label7 = new Label();
            SuspendLayout();
            // 
            // txtDestination
            // 
            txtDestination.Location = new Point(288, 35);
            txtDestination.Name = "txtDestination";
            txtDestination.Size = new Size(100, 23);
            txtDestination.TabIndex = 1;
            txtDestination.TextChanged += txtDestination_TextChanged;
            // 
            // txtFlightNumber
            // 
            txtFlightNumber.Location = new Point(288, 64);
            txtFlightNumber.Name = "txtFlightNumber";
            txtFlightNumber.Size = new Size(100, 23);
            txtFlightNumber.TabIndex = 3;
            txtFlightNumber.TextChanged += txtFlightNumber_TextChanged;
            // 
            // txtLastName
            // 
            txtLastName.Location = new Point(288, 93);
            txtLastName.Name = "txtLastName";
            txtLastName.Size = new Size(100, 23);
            txtLastName.TabIndex = 4;
            txtLastName.TextChanged += txtLastName_TextChanged;
            // 
            // txtFirstName
            // 
            txtFirstName.Location = new Point(288, 122);
            txtFirstName.Name = "txtFirstName";
            txtFirstName.Size = new Size(100, 23);
            txtFirstName.TabIndex = 5;
            txtFirstName.TextChanged += txtFirstName_TextChanged;
            // 
            // txtMiddleName
            // 
            txtMiddleName.Location = new Point(288, 151);
            txtMiddleName.Name = "txtMiddleName";
            txtMiddleName.Size = new Size(100, 23);
            txtMiddleName.TabIndex = 6;
            txtMiddleName.TextChanged += txtMiddleName_TextChanged;
            // 
            // txtPassportNumber
            // 
            txtPassportNumber.Location = new Point(288, 180);
            txtPassportNumber.Name = "txtPassportNumber";
            txtPassportNumber.Size = new Size(100, 23);
            txtPassportNumber.TabIndex = 12;
            txtPassportNumber.TextChanged += txtPassportNumber_TextChanged;
            // 
            // dtpDepartureDate
            // 
            dtpDepartureDate.Location = new Point(288, 209);
            dtpDepartureDate.Name = "dtpDepartureDate";
            dtpDepartureDate.Size = new Size(200, 23);
            dtpDepartureDate.TabIndex = 13;
            dtpDepartureDate.Value = new DateTime(2024, 10, 11, 18, 40, 41, 579);
            dtpDepartureDate.ValueChanged += dtpDepartureDate_ValueChanged;
            // 
            // btnAddBooking
            // 
            btnAddBooking.Location = new Point(183, 251);
            btnAddBooking.Name = "btnAddBooking";
            btnAddBooking.Size = new Size(127, 23);
            btnAddBooking.TabIndex = 14;
            btnAddBooking.Text = "Добавить заявку";
            btnAddBooking.UseVisualStyleBackColor = true;
            btnAddBooking.Click += btnAddBooking_Click;
            // 
            // btnRemoveBooking
            // 
            btnRemoveBooking.Location = new Point(371, 251);
            btnRemoveBooking.Name = "btnRemoveBooking";
            btnRemoveBooking.Size = new Size(117, 23);
            btnRemoveBooking.TabIndex = 15;
            btnRemoveBooking.Text = "Удалить заявку";
            btnRemoveBooking.UseVisualStyleBackColor = true;
            btnRemoveBooking.Click += btnRemoveBooking_Click;
            // 
            // btnFilter
            // 
            btnFilter.Location = new Point(224, 296);
            btnFilter.Name = "btnFilter";
            btnFilter.Size = new Size(180, 23);
            btnFilter.TabIndex = 16;
            btnFilter.Text = "Фильтровать заявки";
            btnFilter.UseVisualStyleBackColor = true;
            btnFilter.Click += btnFilter_Click;
            // 
            // lstBookings
            // 
            lstBookings.FormattingEnabled = true;
            lstBookings.ItemHeight = 15;
            lstBookings.Location = new Point(509, 35);
            lstBookings.Name = "lstBookings";
            lstBookings.Size = new Size(268, 364);
            lstBookings.TabIndex = 17;
            lstBookings.SelectedIndexChanged += lstBookings_SelectedIndexChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(175, 38);
            label1.Name = "label1";
            label1.Size = new Size(107, 15);
            label1.TabIndex = 0;
            label1.Text = "Пункт назначения";
            label1.Click += label1_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(202, 67);
            label2.Name = "label2";
            label2.Size = new Size(80, 15);
            label2.TabIndex = 2;
            label2.Text = "Номер рейса";
            label2.Click += label2_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(224, 96);
            label3.Name = "label3";
            label3.Size = new Size(58, 15);
            label3.TabIndex = 7;
            label3.Text = "Фамилия";
            label3.Click += label3_Click;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(251, 125);
            label4.Name = "label4";
            label4.Size = new Size(31, 15);
            label4.TabIndex = 8;
            label4.Text = "Имя";
            label4.Click += label4_Click;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(224, 154);
            label5.Name = "label5";
            label5.Size = new Size(58, 15);
            label5.TabIndex = 9;
            label5.Text = "Отчество";
            label5.Click += label5_Click;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(183, 183);
            label6.Name = "label6";
            label6.Size = new Size(99, 15);
            label6.TabIndex = 10;
            label6.Text = "Номер паспорта";
            label6.Click += label6_Click;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(208, 212);
            label7.Name = "label7";
            label7.Size = new Size(74, 15);
            label7.TabIndex = 11;
            label7.Text = "Дата вылета";
            label7.Click += label7_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(lstBookings);
            Controls.Add(btnFilter);
            Controls.Add(btnRemoveBooking);
            Controls.Add(btnAddBooking);
            Controls.Add(dtpDepartureDate);
            Controls.Add(txtPassportNumber);
            Controls.Add(label7);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(txtMiddleName);
            Controls.Add(txtFirstName);
            Controls.Add(txtLastName);
            Controls.Add(txtFlightNumber);
            Controls.Add(label2);
            Controls.Add(txtDestination);
            Controls.Add(label1);
            Name = "Form1";
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private TextBox txtDestination;
        private Label label2;
        private TextBox txtFlightNumber;
        private TextBox txtLastName;
        private TextBox txtFirstName;
        private TextBox txtMiddleName;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label label6;
        private Label label7;
        private TextBox txtPassportNumber;
        private DateTimePicker dtpDepartureDate;
        private Button btnAddBooking;
        private Button btnRemoveBooking;
        private Button btnFilter;
        private ListBox lstBookings;
    }
}
