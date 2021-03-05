using System;
using System.Collections.Generic;

namespace Model {
    public class LightVehicle : Vehicle<LightVehicle> {
        public int Id { set; get; }
        public string Color { set; get; }

        public LightVehicle (
            string Brand,
            string Model,
            int Year,
            double Price,
            string Color
        ) : base (Brand, Model, Year, Price) {
            this.Id = base.GetNewId();
            this.Color = Color;

            base.AddItem (this);
        }

        public override string ToString () {
            return base.ToString () + "\nCor: " + this.Color;
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
    }
}
