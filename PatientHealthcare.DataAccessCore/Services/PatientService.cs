namespace PatientHealthcare.DataAccessCore.Services
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using PatientHealthcare.DataAccessCore.Entity;
    using PatientHealthcare.DataAccessCore.Repository.Interfaces;
    using PatientHealthcare.DataAccessCore.Services.Interfaces;

    public class PatientService : IPatientService
    {
        private readonly IPatientRepository patientRepository;

        public PatientService(IPatientRepository patientRepository)
        {
            this.patientRepository = patientRepository;
        }

        public async Task<ClinicPatient> AddPatientAsync(ClinicPatient clinicPatient)
        {
            return await this.patientRepository.AddAsync(clinicPatient);
        }

        public async Task<ClinicPatient> UpdatePatientAsync(ClinicPatient clinicPatient)
        {
            return await this.patientRepository.UpdateAsync(clinicPatient);
        }

        public async Task<List<ClinicPatient>> GetAllPatientsAsync()
        {
            var patients = await this.patientRepository.GetAllEntities<ClinicPatient>();

            return patients.ToList();
        }

        public async Task<int> GetAllPatientsAmount()
        {
            return await this.patientRepository.GetAllPatientsAmount();
        }

        public async Task<List<ClinicPatient>> GetPaginatedPatientsAsync(int pageIndex, int pageSize)
        {
            return await this.patientRepository.GetPaginatedPatientsAsync(pageIndex, pageSize);
        }

        public async Task<bool> RemovePatientAsync(ClinicPatient clinicPatient)
        {
            return await this.patientRepository.RemoveAsync(clinicPatient);
        }

        public async Task<ClinicPatient> GetPatientByIdAsync(string patientId)
        {
            return await this.patientRepository.GetPatientById(patientId);
        }
    }
}
