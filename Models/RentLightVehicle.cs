using System;
using System.Collections.Generic;
using System.Linq;
using Repository;

namespace Model {
    public class RentLightVehicle {
        public string Id { set; get; }
        public int RentId { set; get; }
        public Rent Rent { set; get; }
        public int LightVehicleId { set; get; }
        public LightVehicle LightVehicle { set; get; }

        public RentLightVehicle (
            Rent Rent,
            LightVehicle LightVehicle
        ) {
            this.Rent = Rent;
            this.RentId = Rent.Id;
            this.LightVehicle = LightVehicle;
            this.LightVehicleId = LightVehicle.Id;

            Context.rentsLightVehicles.Add(this);
        }

        public static IEnumerable<RentLightVehicle> GetVehicles(int RentId) {
            return from vehicle in Context.rentsLightVehicles where vehicle.RentId == RentId select vehicle;
        }

        public static int GetCount(int RentId) {
            return GetVehicles(RentId).Count();
        }
    }
}
