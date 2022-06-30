using GuruGuideModles;

namespace GuruGuideDL
{
    public class CoachesRepository : IRepository<Coaches>
    {
        private string _filepath = "../GuruGuideDL/Data/Coaches.json";
        public void Add(Coaches g_resource)
        {
            throw new NotImplementedException();
        }

        public List<Coaches> GetAll()
        {
            throw new NotImplementedException();
        }

        public void Update(Coaches g_resource)
        {
            throw new NotImplementedException();
        }
    }
}