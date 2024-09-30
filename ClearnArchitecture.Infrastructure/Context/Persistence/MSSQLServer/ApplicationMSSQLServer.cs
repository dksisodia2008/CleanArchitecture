using ClearnArchitecture.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace ClearnArchitecture.Infrastructure.Context.Persistence.MSSQLServer;

public class ApplicationMSSQLServer : DbContext
    {
        public ApplicationMSSQLServer(DbContextOptions<ApplicationMSSQLServer> options) : base(options)
        {
        }

        public DbSet<Student> Students { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Student>().ToTable("Students");
            modelBuilder.Entity<Student>().HasKey(q=>q.Id);
        }
    }

