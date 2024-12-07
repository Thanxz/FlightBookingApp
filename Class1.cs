using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.IO;
using System.Xml;
using System.Text.Json.Serialization;
using System.Text.Json;
using System.Net.Mail;
using System.Net;
using MailKit;
using MimeKit;
using MailKit.Net.Imap;

namespace FlightBookingApp
{
    public struct Passenger
    {
        [JsonPropertyName("last_name")]
        public string LastName { get; set; }

        [JsonPropertyName("first_name")]
        public string FirstName { get; set; }

        [JsonPropertyName("middle_name")]
        public string MiddleName { get; set; }

        [JsonPropertyName("passport_number")]
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
        [JsonPropertyName("destination")]
        public string Destination { get; set; }

        [JsonPropertyName("flight_number")]
        public string FlightNumber { get; set; }

        [JsonPropertyName("passenger")]
        public Passenger Passenger { get; set; }

        [JsonPropertyName("departure_date")]
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

        public void SaveToJson()
        {
            var filePath = "../../../bookings.json";
            var options = new JsonSerializerOptions
            {
                WriteIndented = true
            };

            string json = JsonSerializer.Serialize(bookings, options);
            File.WriteAllText(filePath, json);
            MessageBox.Show("Данные успешно сохранены в JSON.");
        }

        public void LoadFromJson()
        {
            var filePath = "../../../bookings.json";
            if (!File.Exists(filePath))
            {
                throw new FileNotFoundException("Файл не найден.", filePath);
            }

            string json = File.ReadAllText(filePath);
            bookings.AddRange(JsonSerializer.Deserialize<List<FlightBooking>>(json));

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

        public void SendEmail(string emailAddress)
        {
            if (File.Exists("../../../bookings.json"))
            {
                try
                {
                    // Коннект
                    var smtpClient = new SmtpClient("smtp.gmail.com")
                    {
                        Port = 587,
                        Credentials = new NetworkCredential("wallet.test.mail@gmail.com", ""),
                        EnableSsl = true
                    };

                    // Письмо
                    var mailMessage = new MailMessage
                    {
                        From = new MailAddress("wallet.test.mail@gmail.com"),
                        Subject = "Данные бронирования в формате JSON"
                    };

                    mailMessage.To.Add(emailAddress);

                    // Прикрепляем файл
                    mailMessage.Attachments.Add(new Attachment("../../../bookings.json"));

                    // Отправка письма
                    smtpClient.Send(mailMessage);
                    MessageBox.Show("Письмо отправлено на: " + emailAddress);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Произошла ошибка при отправке письма: " + ex.Message);
                }
            }
            else
            {
                MessageBox.Show("JSON файл не найден. Сначала выполните экспорт в JSON.");
            }
        }
        public void GetLatestEmailWithJson()
        {
            try
            {
                using (var client = new ImapClient())
                {
                    // Подключение к IMAP серверу Gmail
                    client.Connect("imap.gmail.com", 993, true);

                    // Аутентификация
                    client.Authenticate("wallet.test.mail@gmail.com", "");

                    // Переход в папку "Входящие"
                    var inbox = client.Inbox;
                    inbox.Open(FolderAccess.ReadOnly);

                    // Получаем последнее сообщение
                    var message = inbox.GetMessage(inbox.Count - 1);

                    // Проверяем вложения
                    foreach (var attachment in message.Attachments)
                    {
                        if (attachment is MimePart part)
                        {
                            // Сохраняем временный файл
                            var tempPath = Path.Combine(Path.GetTempPath(), part.FileName);
                            using (var stream = File.Create(tempPath))
                            {
                                part.Content.DecodeTo(stream);
                            }

                            // Читаем содержимое JSON
                            string jsonContent = File.ReadAllText(tempPath);
                            var formattedJson = JsonSerializer.Serialize(
                                JsonSerializer.Deserialize<object>(jsonContent),
                                new JsonSerializerOptions { WriteIndented = true });

                            // Отображаем JSON
                            MessageBox.Show("Полученный JSON:\n" + formattedJson);

                            // Удаляем временный файл
                            File.Delete(tempPath);
                            return;
                        }
                    }

                    MessageBox.Show("Последнее письмо не содержит JSON вложений.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Произошла ошибка при получении письма: " + ex.Message);
            }
        }

    }
}
