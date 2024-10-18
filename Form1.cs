using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace FlightBookingApp
{
    public partial class Form1 : Form
    {
        private List<FlightBooking> bookings;
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
            bookings = new List<FlightBooking>();

        }

        private void btnAddBooking_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtDestination.Text) ||
                string.IsNullOrWhiteSpace(txtFlightNumber.Text) ||
                string.IsNullOrWhiteSpace(txtLastName.Text) ||
                string.IsNullOrWhiteSpace(txtFirstName.Text) ||
                string.IsNullOrWhiteSpace(txtPassportNumber.Text))
            {
                MessageBox.Show("����������, ��������� ��� ������������ ����.");
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
            MessageBox.Show("������ ���������: " + booking.ToString());
        }

        private void btnRemoveBooking_Click(object sender, EventArgs e)
        {
            if (lstBookings.SelectedItem != null)
            {
                var selectedBooking = (FlightBooking)lstBookings.SelectedItem;
                bookings.Remove(selectedBooking);
                UpdateBookingList();
            }
            else
            {
                MessageBox.Show("����������, �������� ������ ��� ��������.");
            }
        }

        private void btnFilter_Click(object sender, EventArgs e)
        {
            var flightNumber = txtFilterFlightNumber.Text.Trim(); // ������� ������ �������
            DateTime departureDate = dtpFilterDate.Value.Date; // �������� ��������� ����

            var filteredBookings = bookings
                .Where(b => b.FlightNumber.Equals(flightNumber, StringComparison.OrdinalIgnoreCase) &&
                             b.DepartureDate.Date == departureDate) // ���������� �� ������ ����� � ����
                .ToList(); // ����������� ��������� � ������

            if (filteredBookings.Count == 0)
            {
                MessageBox.Show("������ �� �������.");
            }

            lstBookings.DataSource = null; // ���������� �������� ������
            lstBookings.DataSource = filteredBookings; // ������������� ����� �������� ������
        }

        private void UpdateBookingList()
        {
            lstBookings.DataSource = null;
            lstBookings.DataSource = bookings; // ���������� ������ ������ �� �����
        }

        private void ClearInputs()
        {
            txtDestination.Clear();
            txtFlightNumber.Clear();
            txtLastName.Clear();
            txtFirstName.Clear();
            txtMiddleName.Clear();
            txtPassportNumber.Clear();
            dtpDepartureDate.Value = DateTime.Now; // ��������� ������� ���� �� ��������� ��� ������ ���� ������
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