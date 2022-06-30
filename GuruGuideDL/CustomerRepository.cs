using System.Text.Json;
using GuruGuideModles;

namespace GuruGuideDL
{
    public class CustomerRepository : IRepository<Customers>
    {
        private string _filepath = "..GuruGuideDL/Data/Customers.json";

        public void Add(Customers g_Customers)
        {
            List<Customers> listofcustomers = GetAll();
            listofcustomers.Add(g_Customers);

            string jsonString = JsonSerializer.Serialize(listofcustomers, new JsonSerializerOptions{WriteIndented =true});
            File.WriteAllText(_filepath, jsonString);
        }

        public List<Customers> GetAll()
        {
             string JsonString = File.ReadAllText(_filepath);
            List<Customers> ListofCustomers = JsonSerializer.Deserialize<List<Customers>>(JsonString);

            return ListofCustomers;

        }

        public void Update(Customers g_resource)
        {
            throw new NotImplementedException();
        }
    }
}