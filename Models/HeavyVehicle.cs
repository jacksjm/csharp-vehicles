using System;
using System.Collections.Generic;
using System.Linq;
using Repository;

namespace Model {
    public class HeavyVehicle : Vehicle {
        public int Id { set; get; }
        public string Restrictions { set; get; }

        public HeavyVehicle (
            string Brand,
            string Model,
            int Year,
            double Price,
            string Restrictions
        ) : base (Brand, Model, Year, Price) {
            this.Id = Context.heavyVehicles.Count;
            this.Restrictions = Restrictions;

            Context.heavyVehicles.Add (this);
        }

        public override string ToString () {
            return "Id: " + this.Id + " - " + base.ToString () + " - Restrições: " + this.Restrictions;
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

        public static IEnumerable<HeavyVehicle> GetHeavyVehicles () {
            return from heavyVehicle in Context.heavyVehicles select heavyVehicle;
        }

        public static int GetCount() {
            return GetHeavyVehicles().Count();
        }

        public static HeavyVehicle GetHeavyVehicle (int Id) {
            return (
                from heavyVehicle in Context.heavyVehicles 
                where heavyVehicle.Id == Id 
                select heavyVehicle
            ).First();
        }
    }
}
