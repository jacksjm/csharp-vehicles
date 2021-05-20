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
            this.Id = Context.RentsLightVehicles.Count;
            this.Rent = Rent;
            this.RentId = Rent.Id;
            //this.LightVehicle = LightVehicle;
            this.LightVehicleId = LightVehicle.Id;

            Context.RentsLightVehicles.Add(this);
        }

        public static IEnumerable<RentLightVehicle> GetVehicles(int RentId) {
            return from vehicle in Context.RentsLightVehicles where vehicle
                .RentId == RentId select vehicle;
        }

        public static int GetCount(int RentId) {
            return GetVehicles(RentId).Count();
        }

        public static double GetTotal(int RentId) {
            double total = 0;
            IEnumerable<RentLightVehicle> vehicles = (
                from vehicle in Context.RentsLightVehicles 
                where vehicle.RentId == RentId 
                select vehicle
            );

            foreach (RentLightVehicle item in vehicles)
            {
                LightVehicle vehicle = LightVehicle
                    .GetLightVehicle(item.LightVehicleId);
                total += vehicle.Price;
            }

            return total;
        }
    }
}
