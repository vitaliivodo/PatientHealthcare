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
    }
}
