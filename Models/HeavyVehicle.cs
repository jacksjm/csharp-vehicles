using System;
using System.Collections.Generic;

namespace Model {
    public class HeavyVehicle : Vehicle<HeavyVehicle> {
        public int Id { set; get; }
        public string Restrictions { set; get; }

        public HeavyVehicle (
            string Brand,
            string Model,
            int Year,
            double Price,
            string Restrictions
        ) : base (Brand, Model, Year, Price) {
            this.Id = base.GetNewId();
            this.Restrictions = Restrictions;

            base.AddItem (this);
        }

        public override string ToString () {
            return base.ToString () + "\nRestrições: " + this.Restrictions;
        }

        public override bool Equals (object obj) {
            if (obj == null) {
                return false;
            }
            if (obj.GetType () != this.GetType ()) {
                return false;
            }
            HeavyVehicle heavyVehicle = (HeavyVehicle) obj;
            return this.GetHashCode () == heavyVehicle.GetHashCode ();
        }

        public override int GetHashCode () {
            return HashCode.Combine (this.Id);
        }
    }
}
