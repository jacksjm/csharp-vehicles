using System;
using System.Collections.Generic;

namespace Model {
    public class RentHeavyVehicle {
        public string Id { set; get; }
        public int RentId { set; get; }
        public Rent Rent { set; get; }
        public int HeavyVehicleId { set; get; }
        public HeavyVehicle HeavyVehicle { set; get; }

        public static readonly List<RentHeavyVehicle> database = new ();

        public RentHeavyVehicle (
            Rent Rent,
            HeavyVehicle HeavyVehicle
        ) {
            this.Rent = Rent;
            this.RentId = Rent.Id;
            this.HeavyVehicle = HeavyVehicle;
            this.HeavyVehicleId = HeavyVehicle.Id;

            HeavyVehicle.Rents.Add (this);
        }
    }
}
