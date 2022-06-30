using System.ComponentModel.DataAnnotations;

namespace GuruGuideModles
{
    public class Customers
    {
        public string FullName { get; set; }
        public string Email { get; set; }
        public string Address {get; set; }
        public string City {get; set;}
        public string State { get; set; }
        public string PhoneNumber {get; set;}
        public string Gender {get; set;}
        public string Ethnicity {get; set; }
        private int _Age;

         public int Age
        {
            get { return _Age;}
            set
            {
                if (value > 0)
                {
                    _Age = value;
                }
                else
                {
                    throw new ValidationException("Customers Age needs to be above 0.");
                }
            }
        }
    

        public string Username {get; set; }
        public string Password {get; set; }

        public Customers()
        {
            FullName = "default";
            Email = "default";
            Address = "default";
            City = "default";
            State = "default";
            PhoneNumber = "default";
            Gender = "default";
            Ethnicity = "default";
            Age = 0;
            Username = "default";
            Password = "default";
        }

        
    }
}