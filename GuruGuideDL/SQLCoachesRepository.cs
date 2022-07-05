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
                               values (@CUserName, @CFullName, @CPassword, @CAddress, @CCity, @CState, @CTitle, @AreaOfSpecialization, @CGender, @CRace, @Age, @YearsOfExperience, @Qualifications, @Languages, @ModalityOptions, @Pricing)";

            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                con.Open();

                SqlCommand command = new SqlCommand(SQLQuary, con);


                command.Parameters.AddWithValue("@CUserName", c_resource.CUserName);
                command.Parameters.AddWithValue("@CFullName", c_resource.CFullName);
                command.Parameters.AddWithValue("@CPassword", c_resource.CPassword);
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
                command.Parameters.AddWithValue("@Qualifications", c_resource.Qualifications);
                command.Parameters.AddWithValue("@Langauges", c_resource.Languages);
                command.Parameters.AddWithValue("@ModalityOptions", c_resource.ModalityOptions);
                command.Parameters.AddWithValue("@Pricing", c_resource.Pricing);
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
                        CFullName = reader.GetString(2),
                        CPassword = reader.GetString(3),
                        CAddress = reader.GetString(4),
                        CCity = reader.GetString(5),
                        CState = reader.GetString(6),
                        CTitle = reader.GetString(7),
                        AreaOfSpecialization = reader.GetString(8),
                        BusinessPhoneNumber = reader.GetInt32(9),
                        CGender = reader.GetString(10),
                        CRace = reader.GetString(11),
                        Age = reader.GetInt32(12),
                        YearsOfExperience = reader.GetInt32(13),
                        Qualifications = reader.GetString(14),
                        Languages = reader.GetString(15),
                        ModalityOptions = reader.GetString(16),
                        Pricing = reader.GetDecimal(17),
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