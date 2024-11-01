using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightBookingApp
{

    public struct Passenger
    {
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string PassportNumber { get; set; }

        public Passenger(string firstname, string lastname, string middlename, string passportnumber)
        {
            this.FirstName = firstname;
            this.LastName = lastname;
            this.PassportNumber = passportnumber;
            this.MiddleName = middlename;
        }
    }

    public struct FlightBooking
    {
        public string Destination { get; set; }
        public string FlightNumber { get; set; }
        public Passenger Passenger { get; set; }
        public DateTime DepartureDate { get; set; }

        // Перегрузка оператора ==
        public static bool operator ==(FlightBooking a, FlightBooking b)
        {
            return a.FlightNumber == b.FlightNumber && a.DepartureDate.Date == b.DepartureDate.Date;
        }

        // Перегрузка оператора !=
        public static bool operator !=(FlightBooking a, FlightBooking b)
        {
            return !(a == b);
        }

        // Перегрузка оператора +
        public static FlightBooking operator +(FlightBooking booking, string newDestination)
        {
            booking.Destination = newDestination;
            return booking;
        }

        public override string ToString()
        {
            return $"{FlightNumber} - {Destination} on {DepartureDate.ToShortDateString()}";
        }
                public FlightBooking(string destination, string flightNumber, Passenger passenger, DateTime departureDate)
        {
            Destination = destination;
            FlightNumber = flightNumber;
            Passenger = passenger;
            DepartureDate = departureDate;
        }
    }

    public class BookingManager
    {
        private List<FlightBooking> bookings;
        public List<FlightBooking> filteredBookings;

        public BookingManager(List<FlightBooking>? bookings = null)
        {
            this.bookings = bookings ?? new List<FlightBooking>();
            this.filteredBookings = this.bookings;
        }
        // Перегруженный метод (пустой букинг)
        public FlightBooking AddBooking(DateTime departureDate)
        {
            Passenger passenger = new Passenger("Ivanov", "Ivan", "Ivanovich", "1234567890");
            var newBooking = new FlightBooking("New York", "NY123", passenger, departureDate);
            this.bookings.Add(newBooking);
            return newBooking;
        }
        // Перегруженный метод (заполненный букинг)
        public void AddBooking (FlightBooking booking) {
            this.bookings.Add(booking);
            filteredBookings = bookings;
        }

        // Перегруженный метод (очистка всего)
        public void RemoveBooking()
        {
            this.bookings.Clear();
            this.filteredBookings.Clear();
        }

        // Перегруженный метод (очистка конкретного)
        public void RemoveBooking (FlightBooking booking) { 
            this.bookings.Remove(booking);
        }

        public List<FlightBooking> FilterBookings()
        {
            this.filteredBookings = this.bookings;
            return this.bookings;
        }

        public List<FlightBooking> FilterBookings (string flightNumber, DateTime departureDate)
        {
            var newFilteredBookings = bookings
                .Where(b => b.FlightNumber.Equals(flightNumber, StringComparison.OrdinalIgnoreCase) &&
                             b.DepartureDate.Date == departureDate) // Фильтрация по номеру рейса и дате
                .ToList(); // Преобразуем результат в список

            if (filteredBookings.Count == 0)
            {
                MessageBox.Show("Заявки не найдены.");
            }

            filteredBookings = newFilteredBookings;
            return filteredBookings;
        }
}
}
