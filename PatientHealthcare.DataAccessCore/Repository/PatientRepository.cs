using Microsoft.EntityFrameworkCore;
using PatientHealthcare.DataAccessCore.Entity;
using PatientHealthcare.DataAccessCore.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatientHealthcare.DataAccessCore.Repository
{
    public class PatientRepository : GlobalRepository, IPatientRepository
    {
        public PatientRepository(DataContext dataContext) : base(dataContext)
        {
        }

        public async Task<List<ClinicPatient>> GetPaginatedPatientsAsync(int pageIndex, int pageSize)
        {
            return await this.dataContext.Patients.Skip(pageIndex * pageSize).Take(pageSize).ToListAsync();
        }

        public async Task<int> GetAllPatientsAmount()
        {
            return await this.dataContext.Patients.CountAsync();
        }
    }
}
