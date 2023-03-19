using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiApp1.Data
{
    public class Reservation
    {
        public string GenerateReservationCode()
        {
            const string letters = "ABCDEFGHIJKLMNOPQRSTUVWXYZ"; // Define the set of letters to use
            const string digits = "0123456789"; // Define the set of digits to use
            var random = new Random();
            var reservationCode = $"{letters[random.Next(letters.Length)]}{random.Next(10)}{random.Next(10)}{random.Next(10)}{random.Next(10)}";

            return reservationCode;


        }

        public void SaveReservationData(string selectedFlightCode, string selectedAirline, string selectedDay, string selectedTime, decimal cost, string name, string citizenship, string reservationCode)
        {
            // Create a ReservationData object with the provided data
            var reservationData = new ReservationData
            {
                SelectedFlightCode = selectedFlightCode,
                SelectedAirline = selectedAirline,
                SelectedDay = selectedDay,
                SelectedTime = selectedTime,
                Cost = cost,
                Name = name,
                Citizenship = citizenship,
                ReservationCode = reservationCode

            };

            // Write the ReservationData object to binary file
            var path = @"C:\Users\mac_h\source\repos\monkeyV10\mauiassignmentfinal\bin\reservations.bin";
            using (var stream = new FileStream(path, FileMode.Append))
            using (var writer = new BinaryWriter(stream))
            {
                writer.Write(reservationData.SelectedFlightCode);
                writer.Write(reservationData.SelectedAirline);
                writer.Write(reservationData.SelectedDay);
                writer.Write(reservationData.SelectedTime);
                writer.Write(reservationData.Cost);
                writer.Write(reservationData.Name);
                writer.Write(reservationData.Citizenship);
                writer.Write(reservationData.ReservationCode);
                writer.Write('\n'); // Use newline character to separate the records
            }
        }

        public List<ReservationData> GetReservationData()
        {
            var reservationDataList = new List<ReservationData>();
            var path = @"C:\Users\mac_h\source\repos\monkeyV10\mauiassignmentfinal\bin\reservations.bin";
            using (var stream = new FileStream(path, FileMode.OpenOrCreate))
            using (var reader = new BinaryReader(stream))
            {
                while (stream.Position < stream.Length) // Read until end of file
                {
                    var reservationData = new ReservationData
                    {
                        SelectedFlightCode = reader.ReadString(),
                        SelectedAirline = reader.ReadString(),
                        SelectedDay = reader.ReadString(),
                        SelectedTime = reader.ReadString(),
                        Cost = reader.ReadDecimal(),
                        Name = reader.ReadString(),
                        Citizenship = reader.ReadString(),
                        ReservationCode = reader.ReadString(),
                    };

                    // Read the newline character to move to the next record
                    reader.ReadChar();

                    reservationDataList.Add(reservationData);
                }
            }

            return reservationDataList;
        }
    }

    

}


