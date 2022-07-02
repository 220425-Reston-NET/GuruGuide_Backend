using GuruGuideModles;
using Microsoft.Data.SqlClient;

namespace GuruGuideDL
{
    public class SQLCoachesRepository : IRepository<Coaches>
    {
        //==============================================
        private string _connectionString;

        
        public SQLCoachesRepository(string c_connectionString)

    {
        this._connectionString = c_connectionString;
    }
    //====================================================
        public void Add(Coaches c_resource)
        {
            string SQLQuary = @"insert into Coaches
                               values (@CUserName, @CPassword, @CFullName, @CAddress, @CCity, @CState, @CTitle, @AreaOfSpecialization, @CGender, @CRace, @Age, @YearsOfExperience, @Pricing, @Qualifications, @Languages )";

            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                con.Open();

                SqlCommand command = new SqlCommand(SQLQuary, con);


                command.Parameters.AddWithValue("@CUserName", c_resource.CUserName);
                command.Parameters.AddWithValue("@CPassword", c_resource.CPassword);
                command.Parameters.AddWithValue("@CFullName", c_resource.CFullName);
                command.Parameters.AddWithValue("@CAddress", c_resource.CAddress);
                command.Parameters.AddWithValue("@CCity", c_resource.CCity);
                command.Parameters.AddWithValue("@CState", c_resource.CState);
                command.Parameters.AddWithValue("@CTitle", c_resource.CTitle);
                command.Parameters.AddWithValue("@AreaOfSpecialization", c_resource.AreaOfSpecialization);
                command.Parameters.AddWithValue("@BusinessPhoneNumber", c_resource.BusinessPhoneNumber);
                command.Parameters.AddWithValue("@CGender", c_resource.CGender);
                command.Parameters.AddWithValue("@CRace", c_resource.CRace);
                command.Parameters.AddWithValue("@Age", c_resource.Age);
                command.Parameters.AddWithValue("@YearsOfExperience", c_resource.YearsOfExperience);
                command.Parameters.AddWithValue("@Pricing", c_resource.Pricing);
                command.Parameters.AddWithValue("@Qualifications", c_resource.Qualifications);
                command.Parameters.AddWithValue("@Langauges", c_resource.Languages);
                command.ExecuteNonQuery();
            }
        }

        public List<Coaches> GetAll()
        {
            string SQLQuary = @"select * from Coaches";

            List<Coaches> listOfCoaches = new List<Coaches>();

            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                con.Open();

                SqlCommand command = new SqlCommand(SQLQuary, con);


                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    listOfCoaches.Add(new Coaches(){
                        CUserName = reader.GetString(1),
                        CFullName = reader.GetString(3),
                        CPassword = reader.GetString(2),
                        CAddress = reader.GetString(5),
                        CCity = reader.GetString(6),
                        CState = reader.GetString(7),
                        CTitle = reader.GetString(8),
                        AreaOfSpecialization = reader.GetString(9),
                        BusinessPhoneNumber = reader.GetInt32(10),
                        CGender = reader.GetString(11),
                        CRace = reader.GetString(12),
                        Age = reader.GetInt32(13),
                        YearsOfExperience = reader.GetInt32(14),
                        Pricing = reader.GetInt32(15),
                        Qualifications = reader.GetString(16),
                        Languages = reader.GetString(17),
                        //ModalityOptions = reader.Getstring(18),
                    });
                }

                return listOfCoaches;
            }
        }

        public Task<List<Coaches>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public void Update(Coaches p_resource)
        {
            throw new NotImplementedException();
        }
    }


}