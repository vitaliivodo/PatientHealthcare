using Microsoft.AspNetCore.Mvc;
using PatientHealthcare.BusinessCore.Model;
using PatientHealthcare.DataAccessCore.Services.Interfaces;

namespace PatientHealthcare.Controllers
{
    [Route("api/patient")]
    public class PatientController : Controller
    {
        private readonly IPatientService patientService;

        public PatientController(IPatientService patientService)
        {
            this.patientService = patientService;
        }

        [HttpPost]
        [Route("AddPatient")]
        public async Task<IActionResult> AddPatientAsync([FromBody] ClinicPatientModel patientModel)
        {
            // Todo mapper
            return null;
        }

        [HttpGet]
        [Route("GetAllPatients")]
        public async Task<IActionResult> GetAllPatientsAsync()
        {
            try
            {
                var patients = await this.patientService.GetAllPatientsAsync();

                if (!Equals(patients, null))
                {
                    return this.Ok(patients);
                }
                else
                {
                    return this.BadRequest("Something wrong to get all patients.");
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpPost]
        [Route("UpdatePatient")]
        public async Task<IActionResult> UpdatePatientAsync([FromBody] ClinicPatientModel patientModel)
        {
            // Todo mapper
            return null;
        }

        [HttpDelete]
        [Route("RemovePatient")]
        public async Task<IActionResult> RemovePatientAsync([FromBody] ClinicPatientModel patientModel)
        {
            return null;
            // Todo mapper
        }
    }
}
