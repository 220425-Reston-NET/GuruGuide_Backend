
using System.Text.Json;
using GuruGuideModles;

namespace GuruGuideDL
{
    public class CoachesRepository : IRepository<Coaches>
        {
        private string _filepath = "..GuruGuideDL/Data/Coaches.json";


        public void Add(Coaches c_Coaches)
        {
            List<Coaches> listofcoaches = GetAll();
            listofcoaches.Add(c_Coaches);

            string jsonString = JsonSerializer.Serialize(listofcoaches, new JsonSerializerOptions{WriteIndented = true});
            File.WriteAllText(_filepath, jsonString);
        }

        public List<Coaches> GetAll()
        {
            string JsonString = File.ReadAllText(_filepath);
            List<Coaches> listofcoaches = JsonSerializer.Deserialize<List<Coaches>>(JsonString);

            return listofcoaches;
        }

        public Task<List<Coaches>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public void update(Coaches p_resources)
        {
            throw new NotImplementedException();
        }

        public void Update(Coaches p_resource)
        {
            throw new NotImplementedException();
        }

        List<Coaches> IRepository<Coaches>.GetAll()
        {
            throw new NotImplementedException();
        }
    }
}