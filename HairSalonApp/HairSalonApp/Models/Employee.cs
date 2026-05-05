namespace HairSalonApp.Models
{
    public class Employee
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Specialty { get; set; }
        public string Phone { get; set; }
        public string FullName
        {
            //Helper property to return employee's full name
            get { return FirstName + " " + LastName; }
        }
    }
}