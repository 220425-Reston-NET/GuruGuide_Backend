using GuruGuideModels;

namespace GuruGuideBL
{
    public interface IAppointmentsBL
    {

        /// <summary>
        /// Add Appointments to the database
        /// </summary>
        /// <param name="p_app">This is the appointments object that will be added to the database</param>
        /// <returns>Gives back the Appointment that gets added to the DB</returns>
        void AddAppointments(Appointments p_app);

    }    

}