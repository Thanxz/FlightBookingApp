using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.IO;
using System.Xml;

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
            //проверяем, что destination и flightNumber не пустые
            //выбрасываем исключение с помощью throw, если это не так

            if (string.IsNullOrEmpty(destination))
            {
                throw new ArgumentException("Пункт назначения не может быть пустым.");
            }
            if (string.IsNullOrEmpty(flightNumber))
            {
                throw new ArgumentException("Номер рейса не может быть пустым.");
            }

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
        private object temporaryVariable;

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
        
        public void AddBooking (FlightBooking booking) {

            //проверяем, что переданное бронирование не является null,
            //и используем catch, чтобы обработать возможные исключения и вывести сообщение об ошибке.

            try
            {
                if (booking == null)
                {
                    throw new ArgumentNullException(nameof(booking), "Бронирование не может быть пустым");
                }
                this.bookings.Add(booking);
                filteredBookings = bookings;
            }

            catch (ArgumentNullException ex)
            {
                MessageBox.Show($"Ошибка при добавлении бронирования: {ex.Message}");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Неожиданная ошибка: {ex.Message}");
            }

            finally
            {
                temporaryVariable = null; //для очистки временных переменных 
            }
        }

        // Перегруженный метод (очистка всего)
        public void RemoveBooking()
        {
            this.bookings.Clear();
            this.filteredBookings.Clear();
        }

        
        public void RemoveBooking (FlightBooking booking) { 
            this.bookings.Remove(booking);// Перегруженный метод (очистка конкретного)

            //добавляем проверку, существует ли бронирование в списке,
            //и обрабатываем ситуацию, когда оно не найдено
            try
            {
                this.bookings.Remove(booking);
            }
            catch (InvalidOperationException ex)
            {
                MessageBox.Show($"Ошибка удаления бронирования: {ex.Message}");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Неожиданная ошибка: {ex.Message}");
            }
        }
                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                 
        public void ExportToXml()
        {
            XmlSerializer serializer = new XmlSerializer(typeof(List<FlightBooking>));

            using (FileStream fileStream = new FileStream("../../../bookings.xml", FileMode.Create))
            {
                serializer.Serialize(fileStream, bookings);
            }
        }

        public void LoadBookings()
        {
            var filePath = "../../../bookings.xml";
            if (!File.Exists(filePath))
            {
                throw new FileNotFoundException("Файл не найден.", filePath);
            }

            var xmlContent = File.ReadAllText(filePath);
            var xmlDoc = new XmlDocument();
            xmlDoc.LoadXml(xmlContent);

            var flightNodes = xmlDoc.SelectNodes("//FlightBooking");
            if (flightNodes != null)
            {
                foreach (XmlNode flightNode in flightNodes)
                {
                    var destination = flightNode.SelectSingleNode("Destination")?.InnerText;
                    var flightNumber = flightNode.SelectSingleNode("FlightNumber")?.InnerText;

                    var passengerNode = flightNode.SelectSingleNode("Passenger");
                    var passenger = new Passenger(
                        passengerNode?.SelectSingleNode("FirstName")?.InnerText ?? "",
                        passengerNode?.SelectSingleNode("LastName")?.InnerText ?? "",
                        passengerNode?.SelectSingleNode("MiddleName")?.InnerText ?? "",
                        passengerNode?.SelectSingleNode("PassportNumber")?.InnerText ?? "");

                    var departureDateText = flightNode.SelectSingleNode("DepartureDate")?.InnerText;
                    var departureDate = DateTime.TryParse(departureDateText, out var parsedDate)
                        ? parsedDate
                        : throw new FormatException("Некорректный формат даты вылета.");

                    var booking = new FlightBooking(destination, flightNumber, passenger, departureDate);
                    bookings.Add(booking);
                }
            }
        }

        public List<FlightBooking> FilterBookings()
        {
            this.filteredBookings = this.bookings;
            return this.bookings;
        }



        public List<FlightBooking> FilterBookings (string flightNumber, DateTime departureDate)
        {   //если ни одна запись не была найдена, показываем сообщение об ошибке
            try
            {
                var newFilteredBookings = bookings
                    .Where(b => b.FlightNumber.Equals(flightNumber, StringComparison.OrdinalIgnoreCase) &&
                                 b.DepartureDate.Date == departureDate) // фильтрация по номеру рейса и дате
                    .ToList(); // преобразуем результат в список

                if (filteredBookings.Count == 0)
                {
                    MessageBox.Show("Заявки не найдены.");
                }

                filteredBookings = newFilteredBookings;
                return filteredBookings;
            }

            catch (InvalidOperationException ex)
            {
                MessageBox.Show($"Ошибка фильтрации: {ex.Message}");
                return new List<FlightBooking>(); // возвращаем пустой список в случае ошибки
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Неизвестная ошибка: {ex.Message}");
                return new List<FlightBooking>(); // возвращаем пустой список в случае любой другой ошибки
            }

        }
}
}
