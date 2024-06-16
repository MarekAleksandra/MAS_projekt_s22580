using MAS_projekt_s22580.Context.Configurations;
using Microsoft.EntityFrameworkCore;
using MAS_projekt_s22580.Models.Clients;
using MAS_projekt_s22580.Models;
using MAS_projekt_s22580.Models.Guitars;
using MAS_projekt_s22580.Models.Employees;

namespace MAS_projekt_s22580.Context
{
    public class DatabaseContext : DbContext
    {
        public DbSet<Person> Persons { get; set; }
        public DbSet<BasicClient> Clients { get; set; }
        public DbSet<GuitarType> GuitarTypes { get; set; } 
        public DbSet<ClientVip> VIPs { get; set; }
        public DbSet<ClientStandard> Standards { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<GuitarExemplar> GuitarExemplars { get; set; }
        public DbSet<ElectricGuitar> ElectricGuitars { get; set; }
        public DbSet<AcousticGuitar> AcousticGuitars { get; set; }
        public DbSet<BassGuitar> BassGuitars { get; set; }

        public DatabaseContext() { }
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<GuitarType>().ToTable("GuitarTypes");
            modelBuilder.Entity<BasicClient>().ToTable("Clients");

            modelBuilder.ApplyConfiguration(new BassGuitarConfiguration());
            modelBuilder.ApplyConfiguration(new AcousticGuitarConfiguration());
            modelBuilder.ApplyConfiguration(new ElectricGuitarConfiguration());
            modelBuilder.ApplyConfiguration(new ClientConfiguration());
            modelBuilder.ApplyConfiguration(new VipClientConfiguration());
            modelBuilder.ApplyConfiguration(new StandardClientConfiguration());
            modelBuilder.ApplyConfiguration(new PhoneNumberConfiguration());
            modelBuilder.ApplyConfiguration(new EmployeeConfiguration());
            modelBuilder.ApplyConfiguration(new GuitarTypeConfiguration());
            modelBuilder.ApplyConfiguration(new GuitarExemplarConfiguration());
            modelBuilder.ApplyConfiguration(new OrderConfiguration());
            modelBuilder.ApplyConfiguration(new PersonConfiguration());
            modelBuilder.ApplyConfiguration(new SellerConfiguration());
            modelBuilder.ApplyConfiguration(new SpecialistConfiguration());


                base.OnModelCreating(modelBuilder);
        }
    }

}
