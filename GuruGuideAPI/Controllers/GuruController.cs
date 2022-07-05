using GuruCoaches.GuruModels;
using GuruCoaches.GuruModels.GuruContext;
using GuruCoaches.HelperModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GuruCoaches.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class GuruController : ControllerBase
    {
        private readonly GuruContext _context;
        public GuruController( GuruContext context)
        {
            _context = context;
        }

        private async Task<bool> IsEmailExistsAsync(string email) 
        {
            var result = await _context.Coachs.Where(w => w.Email == email).ToListAsync();
            if (result.Any())
                return false;
            return true;
        }

        [HttpPost]
        public async Task<IActionResult> AddCoach([FromBody]SignupCoach coach)
        {
            try
            {

                if (!await IsEmailExistsAsync(coach.Email))
                    return BadRequest("'"+ coach.Email + "' email already exists");

                string pswdMsg = PasswordValidator.ValidatePswd(coach.Password);
                if (pswdMsg != "strong")
                    return BadRequest(pswdMsg);

                Coach c = new Coach
                {
                    Email = coach.Email,
                    Password = coach.Password,  
                    City = coach.City,
                    State = coach.State,
                    Dob = coach.Dob,
                    FirstName = coach.FirstName,
                    LastName = coach.LastName,
                    Gender = coach.Gender,
                    Pricing = coach.Pricing,
                    RaceorEthnicity = coach.RaceorEthnicity,
                    YearofExperience = coach.YearofExperience,
                    IsActive = true,
                    AccountCreateDateTime = DateTime.Now
                };

                await _context.Coachs.AddAsync(c);
                await _context.SaveChangesAsync();
                int coachId = c.CoachId;
                foreach (var item in coach.demographics)
                {
                    var dmgrphs = new CoachDemographics
                    {
                        Fk_CoachId = coachId,
                        Fk_DmgrphyId = item
                    };
                    await _context.CoachDemographics.AddAsync(dmgrphs);
                    await _context.SaveChangesAsync();
                }
                //Adding Languages
                foreach (var item in coach.languages)
                {
                    var data = new CoachLanguages
                    {
                        Fk_CoachId = coachId,
                        Fk_LangId = item
                    };
                    await _context.CoachLanguages.AddAsync(data);
                    await _context.SaveChangesAsync();
                }

                //Adding Modalilties
                foreach (var item in coach.modilities)
                {
                    var data = new CoachModalities
                    {
                        Fk_CoachId = coachId,
                        Fk_MdltyId = item
                    };
                    await _context.CoachModalities.AddAsync(data);
                    await _context.SaveChangesAsync();
                }
                //Adding Qualifications
                foreach (var item in coach.qualifications)
                {
                    var data = new CoachQualifications
                    {
                        Fk_CoachId = coachId,
                        Fk_QlfctnId = item
                    };
                    await _context.CoachQualifications.AddAsync(data);
                    await _context.SaveChangesAsync();
                }

                //Adding Specializations
                foreach (var item in coach.specializations)
                {
                    var data = new CoachSpecializations
                    {
                        Fk_CoachId = coachId,
                        Fk_SpclztnId = item
                    };
                    await _context.CoachSpecializations.AddAsync(data);
                    await _context.SaveChangesAsync();
                }

                return Ok("You are successfully registered");
            }
            catch(Exception ex)
            {
                return BadRequest(ex);
            }
        }//Add coach Method



        [HttpPost]
        public async Task<IActionResult> Login([FromBody]Login log)
        {
            try
            {
                var result = await _context.Coachs
                                            .Where(w => w.Email == log.Email)
                                            .Include(i => i.coachDemographics)
                                            .ThenInclude(t => t.demographic)
                                            .Include(i => i.coachLanguages)
                                            .ThenInclude(t => t.language)
                                            .Include(i => i.coachModalities)
                                            .ThenInclude(t => t.modality)
                                            .Include(i => i.coachQualifications)
                                            .ThenInclude(t => t.qualification)
                                            .Include(i => i.coachSpecializations)
                                            .ThenInclude(t => t.specialization)
                                            .FirstOrDefaultAsync();
                if (result == null)
                    return NotFound("Invalid Email Address");
                if (result.Password != log.Password)
                    return NotFound("Invalid Password");
                if (!result.IsActive)
                    return NotFound("Your Account is Blocked");

                return Ok(result);
            }
            catch(Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetSpecializations()
        {
            try
            {
                var lst = await _context.Specializations.Select(s => new {id =  s.SpclId, name = s.SpecializationName }).ToListAsync();
                if (lst.Count > 0)
                    return Ok(lst);
                return NotFound("No Data Found");
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet]
        public async Task<IActionResult> GetQualifications()
        {
            try
            {
                var lst = await _context.Qualifications.Select(s => new {id = s.QId, name = s.QName }).ToListAsync();
                if (lst.Count > 0)
                    return Ok(lst);
                return NotFound("No Data Found");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet]
        public async Task<IActionResult> GetLanguages()
        {
            try
            {
                var lst = await _context.Languages.Select(s => new {id  = s.LangId, name = s.LangName }).ToListAsync();
                if (lst.Count > 0)
                    return Ok(lst);
                return NotFound("No Data Found");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet]
        public async Task<IActionResult> GetModalities()
        {
            try
            {
                var lst = await _context.Modalities.Select(s => new { id = s.ModalityId, name = s.ModalityType }).ToListAsync();
                if(lst.Count > 0)
                    return Ok(lst);
                return NotFound("No Data Found");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetDemographics()
        {
            try
            {
                var lst = await _context.Demographics.Select(s => new { id = s.DId, name = s.DName }).ToListAsync();
                if (lst.Count > 0)
                    return Ok(lst);
                return NotFound("No Data Found");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
         
    } 
}
