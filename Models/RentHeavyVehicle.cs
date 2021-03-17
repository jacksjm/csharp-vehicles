using System;
using System.Collections.Generic;
using System.Linq;
using Repository;

namespace Model {
    public class RentHeavyVehicle {
        public string Id { set; get; }
        public int RentId { set; get; }
        public Rent Rent { set; get; }
        public int HeavyVehicleId { set; get; }
        public HeavyVehicle HeavyVehicle { set; get; }

        public RentHeavyVehicle (
            Rent Rent,
            HeavyVehicle HeavyVehicle
        ) {
            this.Rent = Rent;
            this.RentId = Rent.Id;
            this.HeavyVehicle = HeavyVehicle;
            this.HeavyVehicleId = HeavyVehicle.Id;

            Context.rentsHeavyVehicles.Add(this);
        }

        public static IEnumerable<RentHeavyVehicle> GetVehicles(int RentId) {
            return from vehicle in Context.rentsHeavyVehicles where vehicle.RentId == RentId select vehicle;
        }

        public static double GetTotal(int RentId) {
            return (
                from vehicle in Context.rentsHeavyVehicles 
                where vehicle.RentId == RentId 
                select vehicle.HeavyVehicle.Price
            ).Sum();
        }

        public static int GetCount(int RentId) {
            return GetVehicles(RentId).Count();
        }

    }
}
