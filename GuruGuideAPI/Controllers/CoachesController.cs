using GuruGuideBL;
using GuruGuideModles;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;

namespace GuruGuideAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CoachesController : ControllerBase
    {
    
        //==============Dependency Injection==============
        private ICoachesBL _coachesBL;
        
        public CoachesController(ICoachesBL c_coachesBL)
        {
            _coachesBL = c_coachesBL;
           
        }
        //================================================

        //Data annotation to indicate what type of HTTP verb it is
        //this is an action of a controller
        //It needs what HTTP verb it is associated with
        [HttpGet("GetAllCoaches")]
        public IActionResult GetAllCoaches()
        {
            try
            {
                List<Coaches> listOfCurrentCoaches = _coachesBL.GetCoaches();
                // Followed by "OK()"
                return Ok(listOfCurrentCoaches);
            }
            catch (SqlException)
            {
                return NotFound("No Coaches Exist");
            }

        }

        [HttpPost("AddCoaches")]
        public IActionResult AddCoaches ([FromBody] Coaches c_coaches)
        {
            try
            {
                _coachesBL.AddCoaches(c_coaches);

                return Created("Coaches was created!", c_coaches);
            }
            catch (SqlException)
            {
                return Conflict();
            }
        }

        [HttpGet("SearchCoachesByName")]
        public IActionResult SearchCoaches([FromQuery] string CUserName, string CPassword)
        {
            try
            {
                return Ok(_coachesBL.SearchCoachesByUserName(CUserName, CPassword));
            }
            catch (SqlException)
            {
                return Conflict();
            }
        }
    }
    
}