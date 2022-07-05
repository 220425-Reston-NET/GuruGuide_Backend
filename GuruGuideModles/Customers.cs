using System.ComponentModel.DataAnnotations;

namespace GuruGuideModles
{
    public class Customers
    {
        public string UserName { get; set; }
        public string Email { get; set; }
        public string FirstName {get; set; }
        public string LastName {get; set;}
        public string Password { get; set; }
        

        public Customers()
        {
            UserName = "default";
            Email = "default";
            FirstName = "default";
            LastName = "default";
            Password = "default";
            
        }

        
    }
}