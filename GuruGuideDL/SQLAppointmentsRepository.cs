using GuruGuideModels;
using Microsoft.Data.SqlClient;

namespace GuruGuideDL
{
     public class SQLAppointmentsRepository : IRepository<Appointments>
    {
        private string _connectionString;
        
        public SQLAppointmentsRepository(string p_connectionString)
        {
            this._connectionString = p_connectionString;

        }
        public void Add(Appointments p_app)
        {
             string SQLQuery = @"insert into Appointments
                                values (@Appointment_Type, @First_Name, @Last_Name, @AppEmail, @PhoneNumber, @DateTime)";

            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                con.Open();

                SqlCommand command = new SqlCommand(SQLQuery, con);

                //We fill in the parameters we added earlier
                //We dynamically change information using AddWithValue and Parameters to avoid the risk of SQL Injection attack
                command.Parameters.AddWithValue("@Appointment_Type", p_app.AppointmentType);
                command.Parameters.AddWithValue("@First_Name", p_app.FirstName);
                command.Parameters.AddWithValue("@Last_Name", p_app.LastName);
                command.Parameters.AddWithValue("@AppEmail", p_app.Email);
                command.Parameters.AddWithValue("@PhoneNumber", p_app.PhoneNumber);
                command.Parameters.AddWithValue("@DateTime", p_app.Datetime.ToString("yyyy-MM-dd HH:mm:ss"));

                //Execute sql statement that is nonquery meaning it will not give any information back (unlike a select statement)
                command.ExecuteNonQuery();
            }
        }

        public List<Appointments> GetAll()
        {
            throw new NotImplementedException();
        }

        public void Update(Appointments p_resource)
        {
            throw new NotImplementedException();
        }
    }
}