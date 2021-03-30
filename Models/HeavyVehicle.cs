using System;
using System.Collections.Generic;
using System.Linq;
using Repository;

namespace Model {
    public class HeavyVehicle : Vehicle {
        public int Id { set; get; }
        public string Restrictions { set; get; }

        public HeavyVehicle(): base() {

        }
        public HeavyVehicle (
            string Brand,
            string Model,
            int Year,
            double Price,
            string Restrictions
        ) : base (Brand, Model, Year, Price) {
            Context db = new Context();
            //this.Id = db.HeavyVehicles.Count;
            this.Restrictions = Restrictions;

            db.HeavyVehicles.Add (this);
            db.SaveChanges();
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
            Context db = new Context();
            return from heavyVehicle in db.HeavyVehicles select heavyVehicle;
        }

        public static int GetCount() {
            return GetHeavyVehicles().Count();
        }

        public static HeavyVehicle GetHeavyVehicle (int Id) {
            Context db = new Context();
            return (
                from heavyVehicle in db.HeavyVehicles 
                where heavyVehicle.Id == Id 
                select heavyVehicle
            ).First();
        }
    }
}
