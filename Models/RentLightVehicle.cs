using System;
using System.Collections.Generic;
using System.Linq;
using Repository;

namespace Model {
    public class RentLightVehicle {
        public int Id { set; get; }
        public int RentId { set; get; }
        public Rent Rent { set; get; }
        public int LightVehicleId { set; get; }
        public LightVehicle LightVehicle { set; get; }

        public RentLightVehicle() {
            
        }
        public RentLightVehicle (
            Rent Rent,
            LightVehicle LightVehicle
        ) {
            Context db = new Context();
            //this.Id = db.RentsLightVehicles.Count;
            this.Rent = Rent;
            this.RentId = Rent.Id;
            this.LightVehicle = LightVehicle;
            this.LightVehicleId = LightVehicle.Id;

            db.RentsLightVehicles.Add(this);
            db.SaveChanges();
        }

        public static IEnumerable<RentLightVehicle> GetVehicles(int RentId) {
            Context db = new Context();
            return from vehicle in db.RentsLightVehicles where vehicle.RentId == RentId select vehicle;
        }

        public static int GetCount(int RentId) {
            return GetVehicles(RentId).Count();
        }
    }
}
