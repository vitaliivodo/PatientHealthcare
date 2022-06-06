using Hl7.Fhir.Model;
using System.ComponentModel.DataAnnotations;

namespace PatientHealthcare.DataAccessCore.Entity
{
    public class ClinicPatient
    {
        [Key]
        public string PatientId { get; set; }

        public string FirstName { get; set; }

        public string SecondName { get; set; }

        public AdministrativeGender? Gender { get; set; }

        public DateTime BirthDate { get; set; }

        public string City { get; set; }

        public string Country { get; set; }

        public string Street { get; set; }

        public string Telephone { get; set; }

        public DateTime? Deceased { get; set; }
    }
}
