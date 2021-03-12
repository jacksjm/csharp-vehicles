using System;
using System.Collections.Generic;

namespace Model {
    public class Rent {
        public int Id { set; get; } // Identificador Único (ID)
        public int CustomerId { set; get; } // Identificador Único do Cliente
        public Customer Customer { set; get; } // Cliente
        public DateTime RentDate { set; get; } // Data de Locação

        public List<RentLightVehicle> LightVehicles { set; get; }
        public List<RentHeavyVehicle> HeavyVehicles { set; get; }

        public static readonly List<Rent> Rents = new ();

        public Rent (
            Customer Customer,
            DateTime RentDate,
            List<LightVehicle> LightVehicles,
            List<HeavyVehicle> HeavyVehicles
        ) {
            this.Customer = Customer;
            this.CustomerId = Customer.Id;
            this.RentDate = RentDate;
            this.LightVehicles = new ();
            this.HeavyVehicles = new ();

            Customer.Rents.Add(this);
            
            foreach (LightVehicle vehicle in LightVehicles) {
                RentLightVehicle rentLightVehicle = new (this, vehicle);
                this.LightVehicles.Add (rentLightVehicle);
            }

            foreach (HeavyVehicle vehicle in HeavyVehicles) {
                RentHeavyVehicle rentHeavyVehicle = new (this, vehicle);
                this.HeavyVehicles.Add (rentHeavyVehicle);
            }

            Rents.Add (this);
        }

        public double GetRentValue() {
            double total = 0;

            foreach (RentLightVehicle vehicle in LightVehicles) {
                total += vehicle.LightVehicle.Price;
            }

            foreach (RentHeavyVehicle vehicle in HeavyVehicles) {
                total += vehicle.HeavyVehicle.Price;
            }
            
            return total;
        }

        public DateTime GetReturnDate() {
            int ReturnDays = this.Customer.ReturnDays;

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
            if (LightVehicles.Count > 0) {
                foreach (RentLightVehicle vehicle in LightVehicles) {
                    Print += "\n    " + vehicle.LightVehicle;
                }
            } else {
                Print += "\n    Nada Consta";
            }

            Print += "\nVeículos Pesados Locados: ";
            if (HeavyVehicles.Count > 0) {
                foreach (RentHeavyVehicle vehicle in HeavyVehicles) {
                    Print += "\n    " + vehicle.HeavyVehicle;
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

        public static List<Rent> GetRents () {
            return Rents;
        }

    }
}
