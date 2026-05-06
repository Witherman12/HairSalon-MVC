namespace HairSalonApp.Models
{
    public class RevenueByServiceReport
    {
        public string ServiceName { get; set; } = string.Empty;
        public int CompletedAppointments { get; set; }
        public decimal Revenue { get; set; }
    }
}
