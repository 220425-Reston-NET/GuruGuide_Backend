using GuruGuideModles;
using Microsoft.Data.SqlClient;

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
                                values (@UserName, @FirstName, @LastName, @Password, @Email)";
            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                con.Open();

                SqlCommand command = new SqlCommand(SQLQuary, con);

                command.Parameters.AddWithValue("@UserName", g_resource.UserName);
                command.Parameters.AddWithValue("@Email", g_resource.Email);
                command.Parameters.AddWithValue("@FirstName", g_resource.FirstName);
                command.Parameters.AddWithValue("@LastName", g_resource.LastName);
                command.Parameters.AddWithValue("@Password", g_resource.Password);

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
                        FirstName = reader.GetString(2),
                        LastName = reader.GetString(3),
                        Password = reader.GetString(4),
                        Email = reader.GetString(5)
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