using System;
using System.Collections.Generic;
using System.Linq;
using Repository;

namespace Model {
    public class RentHeavyVehicle {
        public int Id { set; get; }
        public int RentId { set; get; }
        public Rent Rent { set; get; }
        public int HeavyVehicleId { set; get; }
        public HeavyVehicle HeavyVehicle { set; get; }

        public RentHeavyVehicle() {
            
        }
        public RentHeavyVehicle (
            Rent Rent,
            HeavyVehicle HeavyVehicle
        ) {
            this.Id = Context.RentsHeavyVehicles.Count;
            this.Rent = Rent;
            this.RentId = Rent.Id;
            //this.HeavyVehicle = HeavyVehicle;
            this.HeavyVehicleId = HeavyVehicle.Id;

            Context.RentsHeavyVehicles.Add(this);
        }

        public static IEnumerable<RentHeavyVehicle> GetVehicles(int RentId) {
            return from vehicle in Context.RentsHeavyVehicles where vehicle.RentId == RentId select vehicle;
        }

        public static double GetTotal(int RentId) {
            double total = 0;
            IEnumerable<RentHeavyVehicle> vehicles = (
                from vehicle in Context.RentsHeavyVehicles 
                where vehicle.RentId == RentId 
                select vehicle
            );

            foreach (RentHeavyVehicle item in vehicles)
            {
                HeavyVehicle vehicle = HeavyVehicle.GetHeavyVehicle(item.HeavyVehicleId);
                total += vehicle.Price;
            }

            return total;
        }

        public static int GetCount(int RentId) {
            return GetVehicles(RentId).Count();
        }

    }
}
