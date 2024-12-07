using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Windows.Forms;

namespace FlightBookingApp
{
    public partial class Form1 : Form
    {
        private List<FlightBooking> bookings;
        private BookingManager bookingManager;
        private Label labelDestination;
        private Label labelFlightNumber;
        private Label labelFilterDate;
        private Label labelLastName;
        private Label labelFirstName;
        private Label labelMiddleName;
        private Label labelPassportNumber;
        private Label labelDepartureDate;
        private DateTimePicker dtpDepartureDate;
        //private TextBox txtFilterFlightNumber;


        public Form1()
        {
            InitializeComponent();
            bookingManager = new BookingManager();
            txtFlightNumber.KeyPress += txtFlightNumber_KeyPress;
            txtPassportNumber.KeyPress += txtPassportNumber_KeyPress;

        }

        private static void txtFlightNumber_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Разрешаем только цифры 
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != (char)Keys.Back)
            {
                e.Handled = true;
            }
        }

        private static void txtPassportNumber_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Разрешаем только цифры 
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != (char)Keys.Back)
            {
                e.Handled = true;
            }
        }

        private void btnAddBooking_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtDestination.Text) &&
                string.IsNullOrWhiteSpace(txtFlightNumber.Text) &&
                string.IsNullOrWhiteSpace(txtLastName.Text) &&
                string.IsNullOrWhiteSpace(txtFirstName.Text) &&
                string.IsNullOrWhiteSpace(txtPassportNumber.Text))
            {
                var newBooking = bookingManager.AddBooking(dtpDepartureDate.Value.Date);
                UpdateBookingList();
                ClearInputs();
                MessageBox.Show("Заявка добавлена: " + newBooking.ToString());
                return;
            }

            if (string.IsNullOrWhiteSpace(txtDestination.Text) ||
                string.IsNullOrWhiteSpace(txtFlightNumber.Text) ||
                string.IsNullOrWhiteSpace(txtLastName.Text) ||
                string.IsNullOrWhiteSpace(txtFirstName.Text) ||
                string.IsNullOrWhiteSpace(txtPassportNumber.Text))
            {
                MessageBox.Show("Пожалуйста, заполните все обязательные поля.");
                return;
            }

            var booking = new FlightBooking
            {
                Destination = txtDestination.Text,
                FlightNumber = txtFlightNumber.Text,
                Passenger = new Passenger
                {
                    LastName = txtLastName.Text,
                    FirstName = txtFirstName.Text,
                    MiddleName = txtMiddleName.Text,
                    PassportNumber = txtPassportNumber.Text
                },

                DepartureDate = dtpDepartureDate.Value.Date
            };

            bookingManager.AddBooking(booking);
            UpdateBookingList();
            ClearInputs();
            MessageBox.Show("Заявка добавлена: " + booking.ToString());
        }

        private void btnRemoveBooking_Click(object sender, EventArgs e)
        {
            if (lstBookings.SelectedItem != null)
            {
                var selectedBooking = (FlightBooking)lstBookings.SelectedItem;
                bookingManager.RemoveBooking(selectedBooking);
                UpdateBookingList();
            }
            else
            {
                MessageBox.Show("Пожалуйста, выберите заявку для удаления.");
            }
        }

        private void btnFilter_Click(object sender, EventArgs e)
        {
            var flightNumber = txtFilterFlightNumber.Text.Trim(); // Удаляем лишние пробелы
            DateTime departureDate = dtpFilterDate.Value.Date; // Получаем выбранную дату

            lstBookings.DataSource = bookingManager.FilterBookings(flightNumber, departureDate);
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            bookingManager.ExportToXml();
        }

        private void btnImport_Click(object sender, EventArgs e)
        {
            bookingManager.LoadBookings();
            UpdateBookingList();
        }

        private void btnExportJSON_Click(object sender, EventArgs e)
        {
            bookingManager.SaveToJson();
        }

        private void btnImportJSON_Click(object sender, EventArgs e)
        {
            bookingManager.LoadFromJson();
            UpdateBookingList();
            MessageBox.Show("Данные успешно загружены из JSON.");
        }

        private void btnSendMail_Click(object sender, EventArgs e)
        {
            bookingManager.SendEmail(txtEmail.Text);
            UpdateBookingList();
        }

        private void btnReceiveMail_Click(object sender, EventArgs e)
        {
            bookingManager.GetLatestEmailWithJson();
        }

        private void UpdateBookingList()
        {
            lstBookings.DataSource = null;
            lstBookings.DataSource = bookingManager.filteredBookings; // Обновление списка заявок на форме
        }

        private void ClearInputs()
        {
            txtDestination.Clear();
            txtFlightNumber.Clear();
            txtLastName.Clear();
            txtFirstName.Clear();
            txtMiddleName.Clear();
            txtPassportNumber.Clear();
            dtpDepartureDate.Value = DateTime.Now; // Установка текущей даты по умолчанию для выбора даты вылета
        }

        private void dtpDepartureDate_ValueChanged(object sender, EventArgs e)
        {

        }

        private void dtpFilterDate_ValueChanged(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void txtEmail_TextChanged(object sender, EventArgs e)
        {

        }
    }
}