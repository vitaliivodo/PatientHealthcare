namespace PatientHealthcare.DataAccessCore
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore;
    using PatientHealthcare.DataAccessCore.Entity;

    public partial class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> contextOptions) : base(contextOptions)
        {
        }

        #region DbSet

        public virtual DbSet<CompleteMigration> CompleteMigrations { get; set; }

        public virtual DbSet<ClinicPatient> Patients { get; set; }

        #endregion

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
        }
    }
}
