namespace Controlprocesos.Model {
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class CP : DbContext {
        public CP() : base("name=CP") { }

        public virtual DbSet<Client> Clients { get; set; }
        public virtual DbSet<ODP> ODPs { get; set; }
        public virtual DbSet<ODPProcess> ODPProcesses { get; set; }
        public virtual DbSet<Process> Processes { get; set; }
        public virtual DbSet<vwUser> vwUsers { get; set; }
        public virtual DbSet<sysdiagram> sysdiagrams { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder) {

            #region Client
            modelBuilder.Entity<Client>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<Client>()
                .Property(e => e.Phone)
                .IsUnicode(false);

            modelBuilder.Entity<Client>()
                .Property(e => e.Email)
                .IsUnicode(false);

            modelBuilder.Entity<Client>()
                .Property(e => e.Notes)
                .IsUnicode(false);

            modelBuilder.Entity<Client>()
                .HasMany(e => e.ODPs)
                .WithRequired(e => e.Client)
                .WillCascadeOnDelete(false);
            #endregion
            #region ODP
            modelBuilder.Entity<ODP>()
                .Property(e => e.NODP)
                .IsUnicode(false);

            modelBuilder.Entity<ODP>()
                .Property(e => e.Title)
                .IsUnicode(false);

            modelBuilder.Entity<ODP>()
                .Property(e => e.Notes)
                .IsUnicode(false);

            modelBuilder.Entity<ODP>()
                .HasMany(e => e.ODPProcesses)
                .WithRequired(e => e.ODP)
                .WillCascadeOnDelete(false);
            #endregion
            #region ODPProcess
            modelBuilder.Entity<ODPProcess>()
                .Property(e => e.Notes)
                .IsUnicode(false);
            #endregion
            #region Process
            modelBuilder.Entity<Process>()
                .Property(e => e.Title)
                .IsUnicode(false);

            modelBuilder.Entity<Process>()
                .Property(e => e.Description)
                .IsUnicode(false);

            modelBuilder.Entity<Process>()
                .Property(e => e.Notes)
                .IsUnicode(false);

            modelBuilder.Entity<Process>()
                .HasMany(e => e.ODPProcesses)
                .WithRequired(e => e.Process)
                .WillCascadeOnDelete(false);
            #endregion

        }
    }
}
