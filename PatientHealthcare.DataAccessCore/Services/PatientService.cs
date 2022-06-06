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

        public async Task<bool> RemovePatientAsync(ClinicPatient clinicPatient)
        {
            return await this.patientRepository.RemoveAsync(clinicPatient);
        }
    }
}
