using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiApp1.Data
{
    public class AirportManager
    {
        public static List<Airport> GetAirports()
        {
            var airports = new List<Airport>();

            using (var reader = new StreamReader(@"C:\Users\mac_h\source\repos\monkeyV10\mauiassignmentfinal\Data\airports.csv"))
            {
                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine();
                    var values = line.Split(',');

                    airports.Add(new Airport { Shortform = values[0], AirportName = values[1] });
                }
            }

            return airports;
        }

        public static List<string> GetCities()
        {
            var cities = new List<string>();
            var airports = GetAirports();

            foreach (var airport in airports)
            {
                if (!cities.Contains(airport.Shortform))
                {
                    cities.Add(airport.Shortform);
                }
            }

            return cities;
        }
    }
}
