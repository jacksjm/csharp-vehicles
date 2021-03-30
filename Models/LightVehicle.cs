using System;
using System.Collections.Generic;
using System.Linq;
using Repository;

namespace Model {
    public class LightVehicle : Vehicle {
        public int Id { set; get; }
        public string Color { set; get; }

        public LightVehicle() : base() {

        }
        public LightVehicle (
            string Brand,
            string Model,
            int Year,
            double Price,
            string Color
        ) : base (Brand, Model, Year, Price) {
            Context db = new Context();
            //this.Id = db.LightVehicles.Count;
            this.Color = Color;

            db.LightVehicles.Add (this);
            db.SaveChanges();
        }

        public override string ToString () {
            return "Id: " + this.Id + " - " + base.ToString () + " - Cor: " + this.Color;
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

        public static IEnumerable<LightVehicle> GetLightVehicles () {
            Context db = new Context();
            return from lightVehicle in db.LightVehicles select lightVehicle;
        }

        public static int GetCount() {
            return GetLightVehicles().Count();
        }
        
        public static LightVehicle GetLightVehicle (int Id) {
            Context db = new Context();
            return (
                from lightVehicle in db.LightVehicles
                where lightVehicle.Id == Id
                select lightVehicle
            ).First();
        }
    }
}
