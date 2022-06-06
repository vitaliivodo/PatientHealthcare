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
        Task<TEntity> AddAsync<TEntity>(TEntity entity)
            where TEntity : class;

        Task<TEntity> UpdateAsync<TEntity>(TEntity entity)
            where TEntity : class;

        Task<bool> RemoveAsync<TEntity>(TEntity entity)
            where TEntity : class;

        Task<ICollection<TEntity>> GetAllEntities<TEntity>()
            where TEntity : class;

        Task<IDbContextTransaction> BeginTransactionAsync();

        Task<List<CompleteMigration>> CompletedMigrationListAsync();

        Task<int> SaveCompletedMigrationAsync(string initMigrationId);
    }
}
