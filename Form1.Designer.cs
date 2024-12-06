

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
            txtFilterFlightNumber = new TextBox();
            txtEmail = new TextBox();
            dtpDepartureDate = new DateTimePicker();
            btnAddBooking = new Button();
            btnRemoveBooking = new Button();
            btnFilter = new Button();
            lstBookings = new ListBox();
            labelDestination = new Label();
            labelFlightNumber = new Label();
            labelLastName = new Label();
            labelFirstName = new Label();
            labelMiddleName = new Label();
            labelPassportNumber = new Label();
            labelDepartureDate = new Label();
            labelFilterFlightNumber = new Label();
            labelFilterDate = new Label();
            dtpFilterDate = new DateTimePicker();
            btnExport = new Button();
            btnImport = new Button();
            btnExportJSON = new Button();
            btnImportJSON = new Button();
            btnSendMail = new Button();
            SuspendLayout();
            // 
            // txtDestination
            // 
            txtDestination.BackColor = SystemColors.Window;
            txtDestination.Location = new Point(150, 30);
            txtDestination.Name = "txtDestination";
            txtDestination.Size = new Size(200, 23);
            txtDestination.TabIndex = 0;
            // 
            // txtFlightNumber
            // 
            txtFlightNumber.Location = new Point(150, 70);
            txtFlightNumber.Name = "txtFlightNumber";
            txtFlightNumber.Size = new Size(200, 23);
            txtFlightNumber.TabIndex = 1;
            // 
            // txtLastName
            // 
            txtLastName.Location = new Point(150, 110);
            txtLastName.Name = "txtLastName";
            txtLastName.Size = new Size(200, 23);
            txtLastName.TabIndex = 2;
            // 
            // txtFirstName
            // 
            txtFirstName.Location = new Point(150, 150);
            txtFirstName.Name = "txtFirstName";
            txtFirstName.Size = new Size(200, 23);
            txtFirstName.TabIndex = 3;
            // 
            // txtMiddleName
            // 
            txtMiddleName.Location = new Point(150, 190);
            txtMiddleName.Name = "txtMiddleName";
            txtMiddleName.Size = new Size(200, 23);
            txtMiddleName.TabIndex = 4;
            // 
            // txtPassportNumber
            // 
            txtPassportNumber.Location = new Point(150, 230);
            txtPassportNumber.Name = "txtPassportNumber";
            txtPassportNumber.Size = new Size(200, 23);
            txtPassportNumber.TabIndex = 5;
            // 
            // txtFilterFlightNumber
            // 
            txtFilterFlightNumber.Location = new Point(560, 361);
            txtFilterFlightNumber.Name = "txtFilterFlightNumber";
            txtFilterFlightNumber.Size = new Size(145, 23);
            txtFilterFlightNumber.TabIndex = 9;
            // 
            // txtEmail
            // 
            txtEmail.Location = new Point(350, 460);
            txtEmail.Name = "txtEmail";
            txtEmail.PlaceholderText = "Введите email";
            txtEmail.Size = new Size(200, 23);
            txtEmail.TabIndex = 9;
            txtEmail.TextChanged += txtEmail_TextChanged;
            // 
            // dtpDepartureDate
            // 
            dtpDepartureDate.Location = new Point(150, 270);
            dtpDepartureDate.Name = "dtpDepartureDate";
            dtpDepartureDate.Size = new Size(200, 23);
            dtpDepartureDate.TabIndex = 6;
            dtpDepartureDate.ValueChanged += dtpDepartureDate_ValueChanged;
            // 
            // btnAddBooking
            // 
            btnAddBooking.Location = new Point(250, 315);
            btnAddBooking.Name = "btnAddBooking";
            btnAddBooking.Size = new Size(100, 42);
            btnAddBooking.TabIndex = 8;
            btnAddBooking.Text = "Добавить заявку";
            btnAddBooking.UseVisualStyleBackColor = true;
            btnAddBooking.Click += btnAddBooking_Click;
            // 
            // btnRemoveBooking
            // 
            btnRemoveBooking.Location = new Point(144, 321);
            btnRemoveBooking.Name = "btnRemoveBooking";
            btnRemoveBooking.Size = new Size(100, 36);
            btnRemoveBooking.TabIndex = 9;
            btnRemoveBooking.Text = "Удалить заявку";
            btnRemoveBooking.UseVisualStyleBackColor = true;
            btnRemoveBooking.Click += btnRemoveBooking_Click;
            // 
            // btnFilter
            // 
            btnFilter.Location = new Point(553, 410);
            btnFilter.Name = "btnFilter";
            btnFilter.Size = new Size(152, 36);
            btnFilter.TabIndex = 10;
            btnFilter.Text = "Фильтровать заявки";
            btnFilter.UseVisualStyleBackColor = true;
            btnFilter.Click += btnFilter_Click;
            // 
            // lstBookings
            // 
            lstBookings.FormattingEnabled = true;
            lstBookings.ItemHeight = 15;
            lstBookings.Location = new Point(396, 30);
            lstBookings.Name = "lstBookings";
            lstBookings.Size = new Size(300, 289);
            lstBookings.TabIndex = 11;
            // 
            // labelDestination
            // 
            labelDestination.AutoSize = true;
            labelDestination.Location = new Point(12, 33);
            labelDestination.Name = "labelDestination";
            labelDestination.Size = new Size(107, 15);
            labelDestination.TabIndex = 0;
            labelDestination.Text = "Пункт назначения";
            // 
            // labelFlightNumber
            // 
            labelFlightNumber.AutoSize = true;
            labelFlightNumber.Location = new Point(12, 73);
            labelFlightNumber.Name = "labelFlightNumber";
            labelFlightNumber.Size = new Size(80, 15);
            labelFlightNumber.TabIndex = 2;
            labelFlightNumber.Text = "Номер рейса";
            // 
            // labelLastName
            // 
            labelLastName.AutoSize = true;
            labelLastName.Location = new Point(12, 113);
            labelLastName.Name = "labelLastName";
            labelLastName.Size = new Size(58, 15);
            labelLastName.TabIndex = 3;
            labelLastName.Text = "Фамилия";
            // 
            // labelFirstName
            // 
            labelFirstName.AutoSize = true;
            labelFirstName.Location = new Point(12, 153);
            labelFirstName.Name = "labelFirstName";
            labelFirstName.Size = new Size(31, 15);
            labelFirstName.TabIndex = 4;
            labelFirstName.Text = "Имя";
            // 
            // labelMiddleName
            // 
            labelMiddleName.AutoSize = true;
            labelMiddleName.Location = new Point(12, 193);
            labelMiddleName.Name = "labelMiddleName";
            labelMiddleName.Size = new Size(58, 15);
            labelMiddleName.TabIndex = 5;
            labelMiddleName.Text = "Отчество";
            // 
            // labelPassportNumber
            // 
            labelPassportNumber.AutoSize = true;
            labelPassportNumber.Location = new Point(12, 233);
            labelPassportNumber.Name = "labelPassportNumber";
            labelPassportNumber.Size = new Size(99, 15);
            labelPassportNumber.TabIndex = 6;
            labelPassportNumber.Text = "Номер паспорта";
            // 
            // labelDepartureDate
            // 
            labelDepartureDate.AutoSize = true;
            labelDepartureDate.Location = new Point(12, 270);
            labelDepartureDate.Name = "labelDepartureDate";
            labelDepartureDate.Size = new Size(74, 15);
            labelDepartureDate.TabIndex = 7;
            labelDepartureDate.Text = "Дата вылета";
            // 
            // labelFilterFlightNumber
            // 
            labelFilterFlightNumber.AutoSize = true;
            labelFilterFlightNumber.Location = new Point(560, 332);
            labelFilterFlightNumber.Name = "labelFilterFlightNumber";
            labelFilterFlightNumber.Size = new Size(145, 15);
            labelFilterFlightNumber.TabIndex = 8;
            labelFilterFlightNumber.Text = "Фильтр по номеру рейса";
            // 
            // labelFilterDate
            // 
            labelFilterDate.AutoSize = true;
            labelFilterDate.Location = new Point(426, 332);
            labelFilterDate.Name = "labelFilterDate";
            labelFilterDate.Size = new Size(91, 15);
            labelFilterDate.TabIndex = 10;
            labelFilterDate.Text = "Фильтр по дате";
            // 
            // dtpFilterDate
            // 
            dtpFilterDate.Location = new Point(396, 361);
            dtpFilterDate.Name = "dtpFilterDate";
            dtpFilterDate.Size = new Size(145, 23);
            dtpFilterDate.TabIndex = 11;
            dtpFilterDate.ValueChanged += dtpFilterDate_ValueChanged;
            // 
            // btnExport
            // 
            btnExport.Location = new Point(450, 410);
            btnExport.Name = "btnExport";
            btnExport.Size = new Size(100, 36);
            btnExport.TabIndex = 10;
            btnExport.Text = "Экспорт XML";
            btnExport.UseVisualStyleBackColor = true;
            btnExport.Click += btnExport_Click;
            // 
            // btnImport
            // 
            btnImport.Location = new Point(350, 410);
            btnImport.Name = "btnImport";
            btnImport.Size = new Size(100, 36);
            btnImport.TabIndex = 10;
            btnImport.Text = "Импорт XML";
            btnImport.UseVisualStyleBackColor = true;
            btnImport.Click += btnImport_Click;
            // 
            // btnExportJSON
            // 
            btnExportJSON.Location = new Point(200, 410);
            btnExportJSON.Name = "btnExportJSON";
            btnExportJSON.Size = new Size(100, 36);
            btnExportJSON.TabIndex = 10;
            btnExportJSON.Text = "Экспорт JSON";
            btnExportJSON.UseVisualStyleBackColor = true;
            btnExportJSON.Click += btnExportJSON_Click;
            // 
            // btnImportJSON
            // 
            btnImportJSON.Location = new Point(100, 410);
            btnImportJSON.Name = "btnImportJSON";
            btnImportJSON.Size = new Size(100, 36);
            btnImportJSON.TabIndex = 10;
            btnImportJSON.Text = "Импорт JSON";
            btnImportJSON.UseVisualStyleBackColor = true;
            btnImportJSON.Click += btnImportJSON_Click;
            // 
            // btnSendMail
            // 
            btnSendMail.Location = new Point(553, 452);
            btnSendMail.Name = "btnSendMail";
            btnSendMail.Size = new Size(152, 36);
            btnSendMail.TabIndex = 10;
            btnSendMail.Text = "Отправить письмо";
            btnSendMail.UseVisualStyleBackColor = true;
            btnSendMail.Click += btnSendMail_Click;
            // 
            // Form1
            // 
            BackColor = SystemColors.ActiveCaption;
            ClientSize = new Size(740, 500);
            Controls.Add(txtDestination);
            Controls.Add(labelDestination);
            Controls.Add(txtFlightNumber);
            Controls.Add(labelFlightNumber);
            Controls.Add(txtLastName);
            Controls.Add(labelLastName);
            Controls.Add(txtFirstName);
            Controls.Add(labelFirstName);
            Controls.Add(txtMiddleName);
            Controls.Add(labelMiddleName);
            Controls.Add(txtPassportNumber);
            Controls.Add(labelPassportNumber);
            Controls.Add(dtpDepartureDate);
            Controls.Add(labelDepartureDate);
            Controls.Add(btnAddBooking);
            Controls.Add(btnRemoveBooking);
            Controls.Add(btnFilter);
            Controls.Add(lstBookings);
            Controls.Add(labelFilterFlightNumber);
            Controls.Add(txtFilterFlightNumber);
            Controls.Add(labelFilterDate);
            Controls.Add(dtpFilterDate);
            Controls.Add(btnExport);
            Controls.Add(btnImportJSON);
            Controls.Add(btnExportJSON);
            Controls.Add(btnImport);
            Controls.Add(btnSendMail);
            Controls.Add(txtEmail);
            Name = "Form1";
            Text = "Заявки на авиабилеты";
            Load += Form1_Load;
            ResumeLayout(false);
            PerformLayout();
        }





        #endregion

        private Label label1;
        private TextBox txtDestination;
        private TextBox txtFlightNumber;
        private TextBox txtLastName;
        private TextBox txtFirstName;
        private TextBox txtMiddleName;
        private TextBox txtFilterFlightNumber;
        private TextBox txtEmail;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label label6;
        private Label label7;
        private Label labelFilterFlightNumber;
        private TextBox txtPassportNumber;
        private Button btnAddBooking;
        private Button btnRemoveBooking;
        private Button btnFilter;
        private Button btnExport;
        private Button btnImport;
        private Button btnExportJSON;
        private Button btnImportJSON;
        private Button btnSendMail;
        private ListBox lstBookings;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private DateTimePicker dtpFilterDate;
    }
}
