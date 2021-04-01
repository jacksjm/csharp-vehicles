using System;
using System.Collections.Generic;
using System.Linq;
using Repository;

namespace Model {
    public class Rent {
        public int Id { set; get; } // Identificador Único (ID)
        public int CustomerId { set; get; } // Identificador Único do Cliente
        public virtual Customer Customer { set; get; } // Cliente
        public DateTime RentDate { set; get; } // Data de Locação

        public Rent() {
            
        }
        public Rent (
            Customer Customer,
            DateTime RentDate,
            List<LightVehicle> LightVehicles,
            List<HeavyVehicle> HeavyVehicles
        ) {
            Context db = new Context();
            //this.Id = db.Rents.Count;
            //this.Customer = Customer;
            this.CustomerId = Customer.Id;
            this.RentDate = RentDate;

            db.Rents.Add (this);
            db.SaveChanges();

            Rent rent = GetRents().Last();
            foreach (LightVehicle vehicle in LightVehicles) {
                RentLightVehicle rentLightVehicle = new (rent, vehicle);
            }

            foreach (HeavyVehicle vehicle in HeavyVehicles) {
                RentHeavyVehicle rentHeavyVehicle = new (rent, vehicle);
            }
        }

        public double GetRentValue() {
            double total = 0;

            foreach (RentLightVehicle vehicle in RentLightVehicle.GetVehicles(this.Id)) {
                LightVehicle lightVehicle = LightVehicle.GetLightVehicle(vehicle.LightVehicleId);
                total += lightVehicle.Price;
            }

            total += RentHeavyVehicle.GetTotal(this.Id);
            
            return total;
        }

        public DateTime GetReturnDate() {
            Customer customer = Customer.GetCustomer(this.CustomerId);
            int ReturnDays = customer.ReturnDays;

            return this.RentDate.AddDays(ReturnDays);
        }

        public override string ToString () {
            // Data da Locação: 04/03/2021
            // Id: 0 - Nome: João
            string Print = String.Format (
                "Data da Locação: {0:d} - Data da Devolução: {1:d} - Valor: {2:C}\nCliente: {3}",
                this.RentDate,
                this.GetReturnDate(),
                this.GetRentValue(),
                this.Customer
            );
            Print += "\nVeículos Leves Locados: ";
            if (RentLightVehicle.GetCount(this.Id) > 0) {
                foreach (RentLightVehicle vehicle in RentLightVehicle.GetVehicles(this.Id)) {
                    LightVehicle lightVehicle = LightVehicle.GetLightVehicle(vehicle.LightVehicleId);
                    Print += "\n    " + lightVehicle;
                }
            } else {
                Print += "\n    Nada Consta";
            }

            Print += "\nVeículos Pesados Locados: ";
            if (RentHeavyVehicle.GetCount(this.Id) > 0) {
                foreach (RentHeavyVehicle vehicle in RentHeavyVehicle.GetVehicles(this.Id)) {
                    HeavyVehicle heavyVehicle = HeavyVehicle.GetHeavyVehicle(vehicle.HeavyVehicleId);
                    Print += "\n    " + heavyVehicle;
                }
            } else {
                Print += "\n    Nada Consta";
            }

            return Print;
        }

        public override bool Equals (object obj) {
            if (obj == null) {
                return false;
            }
            if (obj.GetType () != this.GetType ()) {
                return false;
            }
            Rent rent = (Rent) obj;
            return this.GetHashCode () == rent.GetHashCode ();
        }

        public override int GetHashCode () {
            return HashCode.Combine (this.Id);
        }

        public static IEnumerable<Rent> GetRents () {
            Context db = new Context();
            return from rent in db.Rents select rent;
        }

        public static int GetCount(int CustomerId) {
            Context db = new Context();
            return (from rent in db.Rents where rent.CustomerId == CustomerId select rent).Count();
        }

    }
}
