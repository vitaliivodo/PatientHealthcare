using PatientHealthcare.DataAccessCore.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatientHealthcare.DataAccessCore.Services.Interfaces
{
    public interface IPatientService
    {
        Task<ClinicPatient> AddPatientAsync(ClinicPatient clinicPatient);

        Task<List<ClinicPatient>> GetAllPatientsAsync();

        Task<int> GetAllPatientsAmount();

        Task<List<ClinicPatient>> GetPaginatedPatientsAsync(int pageIndex, int pageSize);

        Task<ClinicPatient> GetPatientByIdAsync(string patientId);

        Task<ClinicPatient> UpdatePatientAsync(ClinicPatient clinicPatient);

        Task<bool> RemovePatientAsync(ClinicPatient clinicPatient);
    }
}
