using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
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
    }

}
