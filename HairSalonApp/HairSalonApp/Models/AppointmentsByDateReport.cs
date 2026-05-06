using System;

namespace HairSalonApp.Models
{
    public class AppointmentsByDateReport
    {
        public DateTime AppDate { get; set; }
        public int TotalAppointments { get; set; }
    }
}