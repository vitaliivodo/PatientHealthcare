using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using PatientHealthcare.DataAccessCore.Entity;
using PatientHealthcare.DataAccessCore.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatientHealthcare.DataAccessCore.Repository
{
    public class GlobalRepository : IGlobalRepository
    {
        private readonly DataContext dataContext;

        public GlobalRepository(DataContext dataContext)
        {
            this.dataContext = dataContext;
        }

        public async Task<IDbContextTransaction> BeginTransactionAsync()
        {
            return await this.dataContext.Database.BeginTransactionAsync(default(CancellationToken));
        }

        public async Task<List<CompleteMigration>> CompletedMigrationListAsync()
        {
            return await this.dataContext.CompleteMigrations.ToListAsync();
        }

        public async Task<int> SaveCompletedMigrationAsync(string initMigrationId)
        {
            try
            {
                await this.dataContext.CompleteMigrations.AddAsync(new CompleteMigration { CompleteMigrationId = initMigrationId });

                await this.dataContext.SaveChangesAsync();

                return this.dataContext.ChangeTracker.Entries().Count();
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
