using GuruGuideDL;
using GuruGuideModles;

namespace GuruGuideBL
{
    public class CustomersBL : ICustomersBL
    {
        private IRepository<Customers> _CustomersRepo;
        public CustomersBL(IRepository<Customers> c_CustomersRepo)
        {
            _CustomersRepo = c_CustomersRepo;
        }
        public void AddCustomer(Customers c_Customers)
        {
             Customers foundedCustomer = SearchCustomerByEmail(c_Customers.Email);
            if (foundedCustomer == null)
           {
               _CustomersRepo.Add(c_Customers);
           }
           else
           {
               throw new Exception("Customer name already exist");
           }
        }

        public List<Customers> GetAllCustomers()
        {
           return _CustomersRepo.GetAll();
        }

        public Customers SearchCustomerByEmail(string c_CustomersEmail)
        {
             List<Customers> currentListOfCustomers = _CustomersRepo.GetAll();
           
           foreach (Customers customersobj in currentListOfCustomers)
           {
               if (customersobj.Email == c_CustomersEmail)
               {
                   return customersobj;
               }
            
                
                
            }
                 return null;
        }
    }
}