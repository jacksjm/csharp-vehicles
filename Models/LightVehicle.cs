using System;
using System.Collections.Generic;
using System.Linq;
using Repository;

namespace Model {
    public class LightVehicle : Vehicle {
        public int Id { set; get; }
        public string Color { set; get; }

        public LightVehicle (
            string Brand,
            string Model,
            int Year,
            double Price,
            string Color
        ) : base (Brand, Model, Year, Price) {
            this.Id = Context.lightVehicles.Count;
            this.Color = Color;

            Context.lightVehicles.Add (this);
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
            return from lightVehicle in Context.lightVehicles select lightVehicle;
        }

        public static int GetCount() {
            return GetLightVehicles().Count();
        }
        
        public static LightVehicle GetLightVehicle (int Id) {
            return (
                from lightVehicle in Context.lightVehicles
                where lightVehicle.Id == Id
                select lightVehicle
            ).First();
        }
    }
}
