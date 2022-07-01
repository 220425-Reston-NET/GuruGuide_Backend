using System.Data.SqlClient;
using GuruGuideBL;
using GuruGuideModles;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GuruGuideAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        //=====================================================
        private ICustomersBL _CustomersBL;
        public CustomersController(ICustomersBL c_CustomersBL)
        {
            _CustomersBL = c_CustomersBL;
        }
        //======================================================

        [HttpGet("GetAllCustomers")]
        public IActionResult GetAllMethod()
        {
            try
            {
                List<Customers> listOfCurrentCustomers = _CustomersBL.GetAllCustomers();
                return Ok(listOfCurrentCustomers);
            }
            catch (SqlException)
            {
                return NotFound("No Customers Exist");
            }
        }


        [HttpPost("AddCustomers")]
        public IActionResult AddCustomer([FromBody] Customers c_customers)
        {
            try
            {
                _CustomersBL.AddCustomer(c_customers);

                return Created("Customer was created!", c_customers);
            }
            catch (SqlException)
            {
                return Conflict();
            }
        }

         [HttpGet("SearchCustomerByName")]
    public IActionResult SearchCustomerByName ([FromQuery] string customerEmail)
    {
        try
        {
            return Ok(_CustomersBL.SearchCustomerByEmail(customerEmail));
        }
        catch (SqlException)
        {
             return Conflict();
        }
    }

    }
}
