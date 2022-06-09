using Microsoft.AspNetCore.Mvc;
using PatientHealthcare.BusinessCore.Helper;
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

        [HttpGet]
        [Route("GetAllPatientsAmount")]
        public async Task<IActionResult> GetAllPatientsAmountAsync()
        {
            try
            {
                var amount = await this.patientService.GetAllPatientsAmount();

                if (!Equals(amount, null))
                {
                    return this.Ok(amount);
                }
                else
                {
                    return this.BadRequest("Something wrong to get amount of patients.");
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpPost]
        [Route("GetPaginatedPatients")]
        public async Task<IActionResult> GetPagedPatientsAsync([FromBody] PageRequestHelper pageRequestHelper)
        {
            try
            {
                var patients = await this.patientService.GetPaginatedPatientsAsync(pageRequestHelper.PageIndex, pageRequestHelper.PageSize);

                if (!Equals(patients, null))
                {
                    return this.Ok(patients);
                }
                else
                {
                    return this.BadRequest("Something wrong to get paged patients.");
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
