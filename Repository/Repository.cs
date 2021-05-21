using Model;
using System;
using System.Collections.Generic;
using System.IO;
// using System.Text.Json;
using Fake;

namespace Repository {
    public class Context
    {
        public static DBFake<Customer> Customers
            = new DBFake<Customer>();
        public static DBFake<HeavyVehicle> HeavyVehicles
            = new DBFake<HeavyVehicle>();
        public static DBFake<LightVehicle> LightVehicles
            = new DBFake<LightVehicle>();
        public static DBFake<Rent> Rents
            = new DBFake<Rent>();
        public static DBFake<RentHeavyVehicle> RentsHeavyVehicles
            = new DBFake<RentHeavyVehicle>();
        public static DBFake<RentLightVehicle> RentsLightVehicles
            = new DBFake<RentLightVehicle>();

        public void SaveChanges() {
           
        }

        public Context() {
            
        }

    }
}
