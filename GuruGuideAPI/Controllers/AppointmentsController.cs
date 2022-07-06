using GuruGuideBL;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GuruGuideModels;
using Microsoft.Data.SqlClient;

namespace GuruGuideAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AppointmentsController : ControllerBase
    {
         //=================Dependency Injection=============

        private IAppointmentsBL _AppBL;

        public AppointmentsController(IAppointmentsBL AppBL)
        {
            _AppBL = AppBL;
        }

        //=================================================

        [HttpPost("AddAppointments")]
        public IActionResult AddAppointments([FromBody] Appointments p_app)
        {
                _AppBL.AddAppointments(p_app);
               
                return Created("Appointments was created!", p_app);
           try
            {
               
            
            }
            catch (SqlException)
            {
                return Conflict();
            }
        }
    }

}