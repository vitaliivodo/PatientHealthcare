using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.Storage;
using PatientHealthcare.DataAccessCore.Entity;
using PatientHealthcare.DataAccessCore.Repository.Interfaces;
using PatientHealthcare.Infrastructure.Initialize.Interfaces;

namespace PatientHealthcare.Infrastructure.Initialize
{
    public class ApplicationInitializer : IApplicationInitializer
    {
        private readonly IGlobalRepository repository;

        public ApplicationInitializer(IGlobalRepository globalRepository)
        {
            this.repository = globalRepository;
        }

        public async Task<int> Initialize()
        {
            using (IDbContextTransaction transaction = await this.repository.BeginTransactionAsync())
            {
                int updatedRowsCount = 0;

                try
                {
                    List<CompleteMigration> completeMigrations = await this.repository.CompletedMigrationListAsync();

                    string initMigrationId = "C983E85C-7FBE-4D45-97DB-41D3A12DB88F";

                    if (completeMigrations.All(cm => cm.CompleteMigrationId != initMigrationId))
                    {
                        ////IdentityResult identityResult = await this.CreateInitialApplicationRoles();

                        //if (identityResult.Succeeded)
                        //{
                        //    //identityResult = await this.CreateDefaultAdministrator();
                        //}

                        //if (!identityResult.Succeeded)
                        //{
                        //    throw new Exception(identityResult.Errors.FirstOrDefault()?.Description);
                        //}

                        //updatedRowsCount = await this.repository.SaveCompletedMigrationAsync(initMigrationId);
                    }

                    transaction.Commit();

                    return updatedRowsCount;
                }
                catch
                {
                    transaction.Rollback();
                    throw;
                }
            }
        }
    }
}
