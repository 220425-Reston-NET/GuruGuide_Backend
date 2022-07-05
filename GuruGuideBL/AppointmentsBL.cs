using GuruGuideDL;
using GuruGuideModels;

namespace GuruGuideBL
{
     public class AppointmentsBL : IAppointmentsBL
    {

        //===============Dependancy Injection=====================

        private IRepository<Appointments> _AppRepo;
        public AppointmentsBL (IRepository<Appointments> p_AppRepo)
        {
            _AppRepo = p_AppRepo;
        }
        //======================================================

        public void AddAppointments(Appointments p_app)
        {
            _AppRepo.Add(p_app);
        }
    }

}