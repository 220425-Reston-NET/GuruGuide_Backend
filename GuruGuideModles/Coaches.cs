namespace GuruGuideModles
{
    public class Coaches
    {
        public string CTitle {get; set;}
        public string CFullName {get; set;}
        public string CUserName { get; set; }
        public string CEmail { get; set;}
        public string CPassword { get; set; }
        public string AreaOfSpecialization {get; set;}
        public int BusinessPhoneNumber {get; set;}
        public string CAddress { get; set; }
        public string CCity {get; set;}
        public string CState {get; set; }
        public string CGender {get; set;}
        public string CRace {get; set;}
        public int Age {get; set;}
        public int YearsOfExperience {get; set;}
        public Decimal Pricing {get; set;}
        public string Qualifications {get; set;}
        public string Languages {get; set;}
        public string ModalityOptions {get; set;}


        public Coaches()
        {
            CTitle ="default";
            CFullName = "default";
            CUserName = "default";
            CEmail = "default";
            CPassword = "default";
            AreaOfSpecialization = "default";
            BusinessPhoneNumber = 0;
            CAddress = "default";
            CCity = "default";
            CState = "default";
            CGender =  "default";
            CRace = "default";
            Age = 0;
            YearsOfExperience = 0;
            Pricing =  0;
            Qualifications = "default";
            Languages = "default";
            ModalityOptions = "default";
        }

    }
}