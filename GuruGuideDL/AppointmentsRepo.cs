using GuruGuideModels;

namespace GuruGuideDL
{
        public class AppointmentsRepo : IRepository<Appointments>
    {
        List<Appointments> listofapp = new List<Appointments>();
        public void Add(Appointments p_AppID)
        {
            // List<Appointments> listofapp = GetAll();
            listofapp.Add(p_AppID);
        }
    }
}    