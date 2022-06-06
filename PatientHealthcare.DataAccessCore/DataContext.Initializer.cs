using Hl7.Fhir.Model;
using Hl7.Fhir.Serialization;
using Microsoft.EntityFrameworkCore;
using PatientHealthcare.DataAccessCore.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace PatientHealthcare.DataAccessCore
{
    public partial class DataContext
    {
        public async Task<int> Initialize()
        {
            int updatedRowsCount = 0;
            List<CompleteMigration> completeMigrations = await this.CompleteMigrations.ToListAsync();

            using (var dbContextTransaction = await this.Database.BeginTransactionAsync(default(CancellationToken)))
            {
                try
                {
                    updatedRowsCount += await this.AddPatientsMigration(completeMigrations);

                    dbContextTransaction.Commit();
                    return updatedRowsCount;
                }
                catch
                {
                    dbContextTransaction.Rollback();
                    throw;
                }
            }
        }

        private async Task<int> AddPatientsMigration(List<CompleteMigration> completeMigrations)
        {
            string addPatientsMigrationId = "26F5644A-0355-4ED9-A9F7-53B23D7B288J";

            int entries = 0;

            if (!completeMigrations.Any(cm => cm.CompleteMigrationId == addPatientsMigrationId))
            {
                List<ClinicPatient> patients = this.GetPatientsFromJsonAsync();

                await this.Patients.AddRangeAsync(patients);

                entries = patients.Count;

                await this.SaveChangesAsync();

                this.CompleteMigrations.Add(new CompleteMigration { CompleteMigrationId = addPatientsMigrationId });

                return await this.SaveChangesAsync();
            }

            return entries;
        }

        private List<ClinicPatient> GetPatientsFromJsonAsync()
        {
            string[] files = Directory.GetFiles(@"C:\Users\vitalii.vodopian\source\repos\vitaliivodo\PatientHealthcare\seeds", "*.json");

            List<ClinicPatient> patients = new List<ClinicPatient>();

            foreach (var file in files)
            {
                using (StreamReader r = new StreamReader(file))
                {
                    string json = r.ReadToEnd();
                    var bundleOptions = new JsonSerializerOptions().ForFhir(typeof(Bundle).Assembly);
                    var patientOptions = new JsonSerializerOptions().ForFhir(typeof(Patient).Assembly);

                    var bundle = JsonSerializer.Deserialize<Bundle>(json, bundleOptions);

                    var patient = JsonSerializer.Deserialize<Patient>(bundle.Entry[0].Resource.ToJson(), patientOptions);

                    ClinicPatient clinicPatient = new ClinicPatient
                    {
                        PatientId = patient.Id,
                        FirstName = patient.Name.First().GivenElement.First().ToString(),
                        SecondName = patient.Name.First().Family,
                        Gender = patient.Gender,
                        BirthDate = DateTime.Parse(patient.BirthDate),
                        City = patient.Address.First().City,
                        Country = patient.Address.First().Country,
                        Street = patient.Address.First().LineElement.First().Value,
                        Telephone = patient.Telecom.First().Value,
                        Deceased = patient?.Deceased == null ? null : DateTime.Parse(patient.Deceased.First().Value.ToString())
                    };

                    patients.Add(clinicPatient);
                }
            }

            return patients;
        }
    }
}
