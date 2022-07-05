using System;

namespace GuruGuideModels
{
    public class Appointments
    {
        public int AppointmentID { get; set; }
        public string AppointmentType { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public long PhoneNumber { get; set; }
        public DateTime Datetime { get; set; }

        

        public Appointments(int DateTime)
        {
            AppointmentID = 0;
            AppointmentType = "Default";
            FirstName = "Default";
            LastName = "Default";
            Email = "Default";
            PhoneNumber = 5678765458;
        }

        public Appointments()
        {
            this.Datetime = new DateTime ();
        }
    }
}