using Microsoft.EntityFrameworkCore.Storage;
using PatientHealthcare.DataAccessCore.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatientHealthcare.DataAccessCore.Repository.Interfaces
{
    public interface IGlobalRepository
    {
        Task<IDbContextTransaction> BeginTransactionAsync();

        Task<List<CompleteMigration>> CompletedMigrationListAsync();

        Task<int> SaveCompletedMigrationAsync(string initMigrationId);
    }
}
