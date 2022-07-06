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
                               values (@CTitle, @CFullName, @CUserName, @CEmail, @CPassword, @CAddress, @CCity, @CState, @AreaOfSpecialization,
                                     @CGender, @CRace, @Age, @YearsOfExperience, @Qualifications, @Languages, @ModalityOptions, @Pricing, @BusinessPhoneNumber)";

            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                con.Open();

                SqlCommand command = new SqlCommand(SQLQuary, con);


                command.Parameters.AddWithValue("@CTitle", c_resource.CTitle);
                command.Parameters.AddWithValue("@CFullName", c_resource.CFullName);
                command.Parameters.AddWithValue("@CUserName", c_resource.CUserName);
                command.Parameters.AddWithValue("@CEmail", c_resource.CEmail);
                command.Parameters.AddWithValue("@CPassword", c_resource.CPassword);
                command.Parameters.AddWithValue("@CAddress", c_resource.CAddress);
                command.Parameters.AddWithValue("@CCity", c_resource.CCity);
                command.Parameters.AddWithValue("@CState", c_resource.CState);
                command.Parameters.AddWithValue("@AreaOfSpecialization", c_resource.AreaOfSpecialization);
                command.Parameters.AddWithValue("@CGender", c_resource.CGender);
                command.Parameters.AddWithValue("@CRace", c_resource.CRace);
                command.Parameters.AddWithValue("@Age", c_resource.Age);
                command.Parameters.AddWithValue("@YearsOfExperience", c_resource.YearsOfExperience);
                command.Parameters.AddWithValue("@Qualifications", c_resource.Qualifications);
                command.Parameters.AddWithValue("@Languages", c_resource.Languages);
                command.Parameters.AddWithValue("@ModalityOptions", c_resource.ModalityOptions);
                command.Parameters.AddWithValue("@Pricing", c_resource.Pricing);
                command.Parameters.AddWithValue("@BusinessPhoneNumber", c_resource.BusinessPhoneNumber);

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
                        
                        CTitle = reader.GetString(1),
                        CFullName = reader.GetString(2),
                        CUserName = reader.GetString(3),
                        CEmail = reader.GetString(4),
                        CPassword = reader.GetString(5),
                        CAddress = reader.GetString(6),
                        CCity = reader.GetString(7),
                        CState = reader.GetString(8),
                        AreaOfSpecialization = reader.GetString(9),
                        CGender = reader.GetString(10),
                        CRace = reader.GetString(11),
                        Age = reader.GetInt32(12),
                        YearsOfExperience = reader.GetInt32(13),
                        Qualifications = reader.GetString(14),
                        Languages = reader.GetString(15),
                        ModalityOptions = reader.GetString(16),
                        Pricing = reader.GetDecimal(17),
                        BusinessPhoneNumber = reader.GetInt64(18),
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