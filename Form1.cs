using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace FlightBookingApp
{
    public partial class Form1 : Form
    {
        private List<FlightBooking> bookings;

        public Form1()
        {
            InitializeComponent();
            bookings = new List<FlightBooking>();
        }

        private void btnAddBooking_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Обработчик события вызван!"); // Для отладки

            // Проверка на заполнение обязательных полей
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

            bookings.Add(booking);
            UpdateBookingList();
            ClearInputs();
        }
        private void btnRemoveBooking_Click(object sender, EventArgs e)
        {
            if (lstBookings.SelectedItem != null) // Проверка на наличие выбранного элемента
            {
                var selectedBooking = (FlightBooking)lstBookings.SelectedItem;
                bookings.Remove(selectedBooking);
                UpdateBookingList();
            }
            else
            {
                MessageBox.Show("Пожалуйста, выберите заявку для удаления.");
            }
        }
        private void UpdateBookingList()
        {
            lstBookings.DataSource = null;
            lstBookings.DataSource = bookings;
        }

        private void ClearInputs()
        {
            txtDestination.Clear();
            txtFlightNumber.Clear();
            txtLastName.Clear();
            txtFirstName.Clear();
            txtMiddleName.Clear();
            txtPassportNumber.Clear();
            dtpDepartureDate.Value = DateTime.Now;
        }

        private void lstBookings_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnFilter_Click(object sender, EventArgs e)
        {
            
        }

        private void label6_Click(object sender, EventArgs e)
        {
            string flightNumber = txtFlightNumber.Text;
            DateTime departureDate = dtpDepartureDate.Value.Date;

            var filteredBookings = bookings
                .Where(b => b.FlightNumber == flightNumber && b.DepartureDate == departureDate)
                .ToList();

            lstBookings.DataSource = filteredBookings;
        }

        private void txtPassportNumber_TextChanged(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void dtpDepartureDate_ValueChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void txtDestination_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void txtFlightNumber_TextChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void txtLastName_TextChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void txtFirstName_TextChanged(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void txtMiddleName_TextChanged(object sender, EventArgs e)
        {

        }
    }

    public struct Passenger
    {
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string PassportNumber { get; set; }
    }

    public struct FlightBooking
    {
        public string Destination { get; set; }
        public string FlightNumber { get; set; }
        public Passenger Passenger { get; set; }
        public DateTime DepartureDate { get; set; }

        public override string ToString()
        {
            return $"{FlightNumber} - {Destination} on {DepartureDate.ToShortDateString()}";
        }
    }
}