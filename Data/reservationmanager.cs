using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiApp1.Data
{
    public class ReservationData
    {
        public string SelectedFlightCode { get; set; }
        public string SelectedAirline { get; set; }
        public string SelectedDay { get; set; }
        public string SelectedTime { get; set; }
        public decimal Cost { get; set; }
        public string Name { get; set; }
        public string Citizenship { get; set; }
        public string ReservationCode { get; set; }
        public string Status { get; set; } // Set default status to "Active"
    }
}
