using Abp.Localization;
using Microsoft.EntityFrameworkCore;
using Abp.Zero.EntityFrameworkCore;
using FlightApp.Authorization.Roles;
using FlightApp.Authorization.Users;
using FlightApp.Entities;
using FlightApp.MultiTenancy;

namespace FlightApp.EntityFrameworkCore
{
    public class FlightAppDbContext : AbpZeroDbContext<Tenant, Role, User, FlightAppDbContext>
    {
        /* Define a DbSet for each entity of the application */

        public virtual DbSet<Passenger> Passenger { get; set; }
        public virtual DbSet<FlightCode> FlightCode { get; set; }

        public FlightAppDbContext(DbContextOptions<FlightAppDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<ApplicationLanguageText>()
                .Property(p => p.Value)
                .HasMaxLength(100);
        }
    }
}
