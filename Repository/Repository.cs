using System.Collections.Generic;
using Model;

namespace Repository
{
    public class Context 
    {
        public static readonly List<Customer> customers = new ();
        public static readonly List<HeavyVehicle> heavyVehicles = new ();
        public static readonly List<LightVehicle> lightVehicles = new ();
        public static readonly List<Rent> rents = new ();
        public static readonly List<RentHeavyVehicle> rentsHeavyVehicles = new ();
        public static readonly List<RentLightVehicle> rentsLightVehicles = new ();

    }
}
