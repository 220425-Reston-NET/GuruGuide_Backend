using System.Text.Json;
using GuruGuideModles;

namespace GuruGuideDL
{
    public class CoachesRepository : IRepository<Coaches>
    {
        private string _filepath = "../GuruGuideDL/Data/Coaches.json";
        public void Add(Coaches g_coaches)
        {
            List<Coaches> listofcoaches = GetAll();
            listofcoaches.Add(g_coaches);

            string jsonString = JsonSerializer.Serialize(listofcoaches, new JsonSerializerOptions{WriteIndented = true});
            File.WriteAllText(_filepath, jsonString);
        }

        public List<Coaches> GetAll()
        {
            string jsonString = File.ReadAllText(_filepath);
            List<Coaches> listOfCoaches = JsonSerializer.Deserialize<List<Coaches>>(jsonString);

            return listOfCoaches;
        }

        public void Update(Coaches g_Coaches)
        {
             
            List<Coaches> listOfCoaches = GetAll();

            
            foreach (Coaches coachObj in listOfCoaches)
            {
                
                if (coachObj.CFullName == g_Coaches.CFullName)
                {
                    
                    coachObj.ModalityOptions = g_Coaches.ModalityOptions;
                }
            }

        
            string jsonString = JsonSerializer.Serialize(listOfCoaches, new JsonSerializerOptions{WriteIndented = true});
            File.WriteAllText(_filepath, jsonString);   
        }
    }
}