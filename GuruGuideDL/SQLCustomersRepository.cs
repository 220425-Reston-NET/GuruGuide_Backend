using System.Data.SqlClient;
using GuruGuideModles;

namespace GuruGuideDL
{
    public class SQLCustomersRepository : IRepository<Customers>
    {
        private string _connectionString;
        public SQLCustomersRepository(string g_connectionString)
        {
            this._connectionString = g_connectionString;
        }
        public void Add(Customers g_resource)
        {
            string SQLQuary = @"insert into Customers
                                values (@CustUserName, @CustEmail, @CustFirstName, @CustLastName, @CustPassword)";
            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                con.Open();

                SqlCommand command = new SqlCommand(SQLQuary, con);

                command.Parameters.AddWithValue("@CustUserName", g_resource.UserName);
                command.Parameters.AddWithValue("@CustEmail", g_resource.Email);
                command.Parameters.AddWithValue("@CustFirstName", g_resource.FirstName);
                command.Parameters.AddWithValue("@CustLastName", g_resource.LastName);
                command.Parameters.AddWithValue("@CustPassword", g_resource.Password);

                command.ExecuteNonQuery();
            }
        }

        public List<Customers> GetAll()
        {
            string SQLQuary = @"select * from Customers";

            List<Customers> listOfCustomers = new List<Customers>();

            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                con.Open();

                SqlCommand command = new SqlCommand(SQLQuary, con);


                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    listOfCustomers.Add(new Customers(){
                        
                        UserName = reader.GetString(1),
                        Email = reader.GetString(2),
                        FirstName = reader.GetString(3),
                        LastName = reader.GetString(4),
                        Password = reader.GetString(5)
                    });
                }

                return listOfCustomers;
            }
        }

        public void Update(Customers g_resource)
        {
            throw new NotImplementedException();
        }
    }
}