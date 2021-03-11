using System;
using System.Collections.Generic;

namespace Model
{
    public class RentLightVehicle {
        public string Id { set; get; }
        public int RentId { set; get; }
        public Rent Rent { set; get; }
        public int LightVehicleId { set; get; }
        public LightVehicle LightVehicle { set; get; }

        public static readonly List<RentLightVehicle> database = new ();

        public RentLightVehicle(
            Rent Rent,
            LightVehicle LightVehicle
        ) {
            this.Rent = Rent;
            this.RentId = Rent.Id;
            this.LightVehicle = LightVehicle;
            this.LightVehicleId = LightVehicle.Id;

            LightVehicle.Rents.Add(this);
        }
    }
}
