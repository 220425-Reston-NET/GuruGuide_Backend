namespace GuruGuideModles
{
    public class Coaches
    {
        public string CTitle {get; set;}
        public string CFullName {get; set;}
        public string CEmail { get; set;}
        public string AreaOfSpecialization {get; set;}
        public string BusinessPhoneNumber {get; set;}
        public string CCity {get; set;}

        public string CState {get; set; }
        public string CGender {get; set;}
        public string CRace {get; set;}
        public string Age {get; set;}
        public string YearsOfExperience {get; set;}
        public string Pricing {get; set;}
        public string Qualiifications {get; set;}
        public string Languages {get; set;}
        public string ModalityOptions {get; set;}


        public Coaches()
        {
            CTitle ="default";
            CFullName = "default";
            CEmail = "default";
            AreaOfSpecialization = "default";
            BusinessPhoneNumber = "default";
            CCity = "default";
            CState = "default";
            CGender =  "default";
            CRace = "default";
            Age = "21";
            YearsOfExperience = "default";
            Pricing =  "default";
            Qualiifications = "default";
            Languages = "default";
            ModalityOptions = "default";
        }

    }
}