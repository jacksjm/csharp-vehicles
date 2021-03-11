using System;
using System.Collections.Generic;

namespace Model {
    public class LightVehicle : Vehicle {
        public int Id { set; get; }
        public string Color { set; get; }
        public List<RentLightVehicle> Rents { set; get; }

        public static readonly List<LightVehicle> LightVehicles = new ();
        public LightVehicle (
            string Brand,
            string Model,
            int Year,
            double Price,
            string Color
        ) : base (Brand, Model, Year, Price) {
            this.Id = LightVehicles.Count;
            this.Color = Color;
            this.Rents = new ();

            LightVehicles.Add (this);
        }

        public override string ToString () {
            return "Id: " + this.Id + "\n" + base.ToString () + "\nCor: " + this.Color;
        }

        public override bool Equals (object obj) {
            if (obj == null) {
                return false;
            }
            if (obj.GetType () != this.GetType ()) {
                return false;
            }
            LightVehicle heavyVehicle = (LightVehicle) obj;
            return this.GetHashCode () == heavyVehicle.GetHashCode ();
        }

        public override int GetHashCode () {
            return HashCode.Combine (this.Id);
        }

        public static List<LightVehicle> GetLightVehicles () {
            return LightVehicles;
        }

        public static LightVehicle GetLightVehicle(int Id) {
            return LightVehicles[Id];
        }
    }
}
