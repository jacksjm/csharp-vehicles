using System;
using System.Collections.Generic;
using System.Linq;
using Repository;
using System.Text.Json.Serialization;

namespace Model {
    public class RentHeavyVehicle {
        public int Id { set; get; }
        public int RentId { set; get; }
        [JsonIgnore]
        public Rent Rent { set; get; }
        public int HeavyVehicleId { set; get; }
        [JsonIgnore]
        public HeavyVehicle HeavyVehicle { set; get; }

        public RentHeavyVehicle() {
            
        }
        public RentHeavyVehicle (
            Rent Rent,
            HeavyVehicle HeavyVehicle
        ) {
            Context db = new Context();
            this.Id = db.RentsHeavyVehicles.Count;
            this.Rent = Rent;
            this.RentId = Rent.Id;
            //this.HeavyVehicle = HeavyVehicle;
            this.HeavyVehicleId = HeavyVehicle.Id;

            db.RentsHeavyVehicles.Add(this);
            db.SaveChanges();
        }

        public static IEnumerable<RentHeavyVehicle> GetVehicles(int RentId) {
            Context db = new Context();
            return from vehicle in db.RentsHeavyVehicles where vehicle.RentId == RentId select vehicle;
        }

        public static double GetTotal(int RentId) {
            double total = 0;
            Context db = new Context();
            IEnumerable<RentHeavyVehicle> vehicles = (
                from vehicle in db.RentsHeavyVehicles 
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
