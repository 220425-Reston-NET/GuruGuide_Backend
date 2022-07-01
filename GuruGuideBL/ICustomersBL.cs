using GuruGuideModles;

namespace GuruGuideBL
{
  /// <summary>
  /// Business layer responsible for further validation or process of data obtained from the database or the user
  /// what kind of process? that all depends on the type of functionality you will be doing
  /// </summary>
    public interface ICustomersBL
    {
        /// <summary>
        /// Add customer to the database
        /// </summary>
        /// <param name="c_Cust"></param>
        /// <returns>Gives back the customer that gets added to the DB</returns>
       void AddCustomer(Customers c_Customers);

     
       Customers SearchCustomerByEmail(string c_CustomersEmail);
       List<Customers> GetAllCustomers();
    }

}