using Microsoft.EntityFrameworkCore;
using SystemInfo.Models;
using SystemInfo.Models.GameModels;


namespace SystemInfo.Context
{
    public class SystemContext: DbContext
    {
        public SystemContext(DbContextOptions<SystemContext> options): base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Farmer>()
                .HasKey(b => b.FarmerId);

            modelBuilder.Entity<Farm>()
                .HasKey(b => b.FarmId);

            modelBuilder.Entity<FarmType>()
                .HasKey(b => b.FarmTypeId);

            modelBuilder.Entity<EnergyLog>()
                .HasKey(b => b.EnergyLogId);

            modelBuilder.Entity<Device>()
                .HasKey(b => b.DeviceId);

            modelBuilder.Entity<DeviceType>()
                .HasKey(b => b.DeviceTypeId);

            modelBuilder.Entity<ContactType>()
                .HasKey(b => b.ContactTypeId);

            modelBuilder.Entity<EnergyMeter>()
                .HasKey(b => b.EnergyMeterId);

            modelBuilder.Entity<Game>()
                .HasKey(b => b.GameId);

            modelBuilder.Entity<Badge>()
                .HasKey(b => b.BadgeId);

            modelBuilder.Entity<User>()
                .HasKey(b => b.UserId);


            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Farmer> Farmers { get; set; }
        public DbSet<FarmType> FarmTypes { get; set; }
        public DbSet<Farm> Farms { get; set; }
        public DbSet<EnergyMeter> EnergyMeters { get; set; }
        public DbSet<EnergyLog> EnergyLogs { get; set; }
        public DbSet<DeviceType> DeviceTypes { get; set; }
        public DbSet<Device> Devices { get; set; }
        public DbSet<ContactType> ContactTypes { get; set; }

        // Game
        public DbSet<Badge> Badges { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Game> Games { get; set; }






    }
}
