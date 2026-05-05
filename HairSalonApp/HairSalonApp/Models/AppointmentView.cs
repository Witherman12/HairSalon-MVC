using System;

namespace HairSalonApp.Models
{
    public class AppointmentView
    {
        public int Id { get; set; }
        public DateTime AppDate { get; set; }
        public TimeSpan AppTime { get; set; }
        public string Status { get; set; }
        public int CustomerId { get; set; }
        public string CustomerName { get; set; }
        public string CustomerPhone { get; set; }
        public int EmployeeId { get; set; }
        public string EmployeeName { get; set; }
        public int ServiceId { get; set; }
        public string ServiceName { get; set; }
        public decimal Price { get; set; }
        public int DurationMinutes { get; set; }
    }
}