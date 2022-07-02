using System;

namespace GuruGuideModles
{
    public class Appointments
    {
        public int appID { get; set; }
        public string CustFullName { get; set; }
        public long CustNumber { get; set; }
        public DateTime DateTime { get; set; }
        public string ServiceName { get; set; }

        DateTime dt = new DateTime(2018, 7, 23, 08, 20, 10);
        

        public Appointments()
        {
            appID = 0;
            CustFullName = "Default";
            CustNumber = 9999999999;
            ServiceName = "Default";
        }
    }
}