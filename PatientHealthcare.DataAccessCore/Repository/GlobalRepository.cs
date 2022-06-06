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

        public virtual async Task<TEntity> AddAsync<TEntity>(TEntity entity)
            where TEntity : class
        {
            entity = entity ?? throw new ArgumentNullException(nameof(entity));

            await this.dataContext.Set<TEntity>().AddAsync(entity);

            try
            {
                await this.dataContext.SaveChangesAsync();

                return entity;
            }
            catch (Exception)
            {
                throw;
            }

        }

        public virtual async Task<TEntity> UpdateAsync<TEntity>(TEntity entity)
            where TEntity : class
        {
            entity = entity ?? throw new ArgumentNullException(nameof(entity));

            this.dataContext.Update(entity);

            try
            {
                await this.dataContext.SaveChangesAsync();

                return entity;
            }
            catch (DbUpdateException ex)
            {
                ex.Entries[0].Reload();
                throw;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public virtual async Task<bool> RemoveAsync<TEntity>(TEntity entity)
            where TEntity : class
        {
            entity = entity ?? throw new ArgumentNullException(nameof(entity));

            this.dataContext.Remove(entity);

            try
            {
                return await this.dataContext.SaveChangesAsync() > 0;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public virtual async Task<ICollection<TEntity>> GetAllEntities<TEntity>()
            where TEntity : class
        {
            return await this.dataContext.Set<TEntity>().ToListAsync();
        }

        #region Migrations

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

        #endregion
    }
}
