using Model;
using Microsoft.EntityFrameworkCore;

namespace Repository
{
    public class Context : DbContext
    {
        public DbSet<Customer> Customers { get; set; }
        public DbSet<HeavyVehicle> HeavyVehicles { get; set; }
        public DbSet<LightVehicle> LightVehicles { get; set; }
        public DbSet<Rent> Rents { get; set; }
        public DbSet<RentHeavyVehicle> RentsHeavyVehicles { get; set; }
        public DbSet<RentLightVehicle> RentsLightVehicles { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseMySql("Server=localhost;User Id=root;Database=vehiclerent");

    }
}
