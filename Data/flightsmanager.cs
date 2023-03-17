using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiApp1.Data
{
    public class Flightmanager
    {
        public static List<Flight123> GetFlights()
        {
            var flights = new List<Flight123>();

            using (var reader = new StreamReader(@"C:\Users\mac_h\source\repos\mauiassignmentfinal\Data\flights.csv"))

            {
                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine();
                    var values = line.Split(',');

                    var flight = new Flight123
                    {
                        Flightline = line,
                        FlightCodes = values[0],
                        Airline = values[1],
                        FromCity = values[2],
                        ToCity = values[3],
                        Day = values[4],
                        Time = values[5],
                        Seat = int.Parse(values[6]),
                        Cost = decimal.Parse(values[7])
                    };
                    flights.Add(flight);
                }
            }

            return flights;
        }

    }
}

