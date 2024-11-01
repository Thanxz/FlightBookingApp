//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Windows.Forms;

//namespace FlightBookingApp
//{   

//    // ����� ��� �������� ���������� � ���������!!
//    public class Passenger
//    {
//        public string LastName { get; set; }
//        public string FirstName { get; set; }
//        public string MiddleName { get; set; }
//        public string PassportNumber { get; set; }

//        public Passenger(string lastName, string firstName, string middleName, string passportNumber)
//        {
//            LastName = lastName;
//            FirstName = firstName;
//            MiddleName = middleName;
//            PassportNumber = passportNumber;
//        }

//        public override string ToString()
//        {
//            return $"{FirstName} {LastName}";
//        }
//    }

//    // ����� ��� �������� ���������� � ������������!!
//    public class FlightBooking
//    {
//        public override bool Equals(object? obj)
//        {
//            if (obj is FlightBooking other)
//            {
//                return this.FlightNumber == other.FlightNumber && this.DepartureDate.Date == other.DepartureDate.Date;
//            }
//            return false;
//        }

//        public override int GetHashCode()
//        {
//            return HashCode.Combine(FlightNumber, DepartureDate);
//        }

//        public string Destination { get; set; }
//        public string FlightNumber { get; set; }
//        public Passenger Passenger { get; set; }
//        public DateTime DepartureDate { get; set; }

//        // �����������
//        public FlightBooking(string destination, string flightNumber, Passenger passenger, DateTime departureDate)
//        {
//            Destination = destination;
//            FlightNumber = flightNumber;
//            Passenger = passenger;
//            DepartureDate = departureDate;
//        }

//        // ������������� ������
//        public void UpdateDetails(string? newDestination = null, string? newFlightNumber = null)
//        {
//            if (newDestination != null)
//                Destination = newDestination;
//            if (newFlightNumber != null)
//                FlightNumber = newFlightNumber;
//        }

//        // ���������� ��������� +
//        public static FlightBooking operator +(FlightBooking booking, string newDestination)
//        {
//            booking.UpdateDetails(newDestination);
//            return booking;
//        }

//        // ���������� ��������� ==
//        public static bool operator ==(FlightBooking a, FlightBooking b)
//        {
//            return a.FlightNumber == b.FlightNumber && a.DepartureDate.Date == b.DepartureDate.Date;
//        }

//        // ���������� ��������� !=
//        public static bool operator !=(FlightBooking a, FlightBooking b)
//        {
//            return !(a == b);
//        }

//        public override string ToString()
//        {
//            return $"{FlightNumber} - {Destination} on {DepartureDate.ToShortDateString()}";
//        }
//    }

//    // ����� ��� ���������� �������
//    public class FlightManager
//    {
//        public void RemoveBooking(FlightBooking booking)
//        {
//            bookings.Remove(booking);
//        }

//        private List<FlightBooking> bookings;

//        public FlightManager()
//        {
//            bookings = new List<FlightBooking>();
//        }

//        // ����� ��� ���������� ������������
//        public void AddBooking(FlightBooking booking)
//        {
//            bookings.Add(booking);
//        }

//        // ����� ��� ���������� ������������
//        public List<FlightBooking> FilterBookings(string flightNumber, DateTime departureDate)
//        {
//            return bookings.Where(b => b.FlightNumber.Equals(flightNumber, StringComparison.OrdinalIgnoreCase) &&
//                                       b.DepartureDate.Date == departureDate).ToList();
//        }

//        // ����� ��� ��������� ���� ������������
//        public List<FlightBooking> GetAllBookings()
//        {
//            return bookings;
//        }
//    }

//    // �������� ����� ����������
//    public partial class Form1 : Form
//    {
//        private FlightManager flightManager;
//        private List<FlightBooking> bookings;
//        private Label labelDestination;
//        private Label labelFlightNumber;
//        private Label labelFilterDate;
//        private Label labelLastName;
//        private Label labelFirstName;
//        private Label labelMiddleName;
//        private Label labelPassportNumber;
//        private Label labelDepartureDate;
//        private DateTimePicker dtpDepartureDate;
//        //private MaskedTextBox txtDestination;
//        //private MaskedTextBox txtLastName;
//        //private MaskedTextBox txtFirstName;
//        //private MaskedTextBox txtMiddleName;
//        //private TextBox? txtFilterFlightNumber; // Nullable ����� ���������� ����� ��������� �������� null 
//        public Form1()
//        {
//            InitializeComponent();
//            flightManager = new FlightManager();

//        }

//        private void btnAddBooking_Click(object sender, EventArgs e)
//        {
//            if (string.IsNullOrWhiteSpace(txtDestination.Text) ||
//                string.IsNullOrWhiteSpace(txtFlightNumber.Text) ||
//                string.IsNullOrWhiteSpace(txtLastName.Text) ||
//                string.IsNullOrWhiteSpace(txtFirstName.Text) ||
//                string.IsNullOrWhiteSpace(txtPassportNumber.Text))
//            {
//                MessageBox.Show("����������, ��������� ��� ������������ ����.");
//                return;
//            }

//            var passenger = new Passenger(txtLastName.Text, txtFirstName.Text, txtMiddleName.Text, txtPassportNumber.Text);
//            var booking = new FlightBooking(txtDestination.Text, txtFlightNumber.Text, passenger, dtpDepartureDate.Value.Date);

//            flightManager.AddBooking(booking);
//            UpdateBookingList();
//            ClearInputs();
//            MessageBox.Show("������ ���������: " + booking.ToString());
//        }

//        private void btnRemoveBooking_Click(object sender, EventArgs e)
//        {
//            if (lstBookings.SelectedItem != null)
//            {
//                var selectedBooking = (FlightBooking)lstBookings.SelectedItem;
//                flightManager.RemoveBooking(selectedBooking); // ���������, ��� ���� ����� ���������� � ������ FlightManager
//                UpdateBookingList();
//            }
//            else
//            {
//                MessageBox.Show("����������, �������� ������ ��� ��������.");
//            }
//        }

//        private void btnFilter_Click(object sender, EventArgs e)
//        {
//            var flightNumber = txtFilterFlightNumber.Text.Trim(); // ������� ������ �������
//            DateTime departureDate = dtpFilterDate.Value.Date; // �������� ��������� ����

//            var filteredBookings = flightManager.FilterBookings(flightNumber, departureDate);

//            if (filteredBookings.Count == 0)
//            {
//                MessageBox.Show("������ �� �������.");
//            }

//            lstBookings.DataSource = null; // ���������� �������� ������
//            lstBookings.DataSource = filteredBookings; // ������������� ����� �������� ������
//        }

//        private void UpdateBookingList()
//        {
//            lstBookings.DataSource = null;
//            lstBookings.DataSource = flightManager.GetAllBookings(); // ����� ��� ��������� ���� ������������ 
//        }

//        private void ClearInputs()
//        {
//            txtDestination.Clear();
//            txtFlightNumber.Clear();
//            txtLastName.Clear();
//            txtFirstName.Clear();
//            txtMiddleName.Clear();
//            txtPassportNumber.Clear();
//            dtpDepartureDate.Value = DateTime.Now;
//        }

//        private void dtpFilterDate_ValueChanged(object sender, EventArgs e)
//        {

//        }

//        private void dtpDepartureDate_ValueChanged(object sender, EventArgs e)
//        {

//        }

//        private void Form1_Load(object sender, EventArgs e)
//        {

//        }

//    }
//}


/*using System;
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
}*/



using System;
using System.Collections.Generic;
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
                MessageBox.Show("������ ���������: " + newBooking.ToString());
                return;
            }

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

            bookingManager.AddBooking(booking);
            UpdateBookingList();
            ClearInputs();
            MessageBox.Show("������ ���������: " + booking.ToString());
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
                MessageBox.Show("����������, �������� ������ ��� ��������.");
            }
        }

        private void btnFilter_Click(object sender, EventArgs e)
        {
            var flightNumber = txtFilterFlightNumber.Text.Trim(); // ������� ������ �������
            DateTime departureDate = dtpFilterDate.Value.Date; // �������� ��������� ����

            lstBookings.DataSource = bookingManager.FilterBookings(flightNumber, departureDate);
        }

        private void UpdateBookingList()
        {
            lstBookings.DataSource = null;
            lstBookings.DataSource = bookingManager.filteredBookings; // ���������� ������ ������ �� �����
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
}