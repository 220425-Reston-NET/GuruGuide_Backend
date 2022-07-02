
using GuruGuideModles;

namespace GuruGuideBL
{
    public interface ICoachesBL
    {
        void AddCoaches(Coaches c_Coaches);

        Coaches SearchCoachesByUserName(string c_CoachesUserName, string c_password);
        Coaches SearchCoachesByAddress(string c_CoachesAddress);

        List<Coaches> GetCoaches();



    }
}