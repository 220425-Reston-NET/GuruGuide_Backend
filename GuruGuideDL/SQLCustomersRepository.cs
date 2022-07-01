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

                command.Parameters.AddWithValue("@custName", c_resource.Name);
                command.Parameters.AddWithValue("@custEmail", c_resource.Email);
                command.Parameters.AddWithValue("@custAddress", c_resource.Address);
                command.Parameters.AddWithValue("@custPhonenumber", c_resource.Phonenumber);

                command.ExecuteNonQuery();
            }
        }

        public List<Customers> GetAll()
        {
            throw new NotImplementedException();
        }

        public void Update(Customers g_resource)
        {
            throw new NotImplementedException();
        }
    }
}