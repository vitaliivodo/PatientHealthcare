using PatientHealthcare.DataAccessCore.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatientHealthcare.DataAccessCore.Repository.Interfaces
{
    public interface IPatientRepository : IGlobalRepository
    {
        Task<List<ClinicPatient>> GetPaginatedPatientsAsync(int pageIndex, int pageSize);

        Task<int> GetAllPatientsAmount();

        Task<ClinicPatient> GetPatientById(string patientId);
    }
}
