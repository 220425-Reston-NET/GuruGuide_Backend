
using GuruGuideModles;

namespace GuruGuideBL
{
    /// <summary>
    /// Business layer responsible for further validation or process of data obtained from the database or the user
    /// what kind of process? that all depends on the type of functionality you will be doing
    /// </summary>
    public interface ICoachesBL
    {
        void AddCoaches(Coaches c_Coaches);

        Coaches SearchCoachesByUserName(string c_CoachesUserName, string c_password);
        Coaches SearchCoachesByAddress(string c_CoachesCAddress);
        Coaches SearchCoachesByState(string c_CoachesState);
        Coaches SearchCoachesBySpecialization(string c_CoachesAreaOfSpecialization);

        List<Coaches> GetCoaches();
    }
}