using System;
using System.Collections.Generic;
using System.Linq;
using Repository;

namespace Model {
    public class Rent {
        public int Id { set; get; } // Identificador Único (ID)
        public int CustomerId { set; get; } // Identificador Único do Cliente
        public Customer Customer { set; get; } // Cliente
        public DateTime RentDate { set; get; } // Data de Locação

        public Rent() {
            
        }
        public Rent (
            Customer Customer,
            DateTime RentDate,
            List<LightVehicle> LightVehicles,
            List<HeavyVehicle> HeavyVehicles
        ) {
            this.Id = Context.Rents.Count;
            this.Customer = Customer;
            this.CustomerId = Customer.Id;
            this.RentDate = RentDate;
            
            Context.Rents.Add (this);

            foreach (LightVehicle vehicle in LightVehicles) {
                new RentLightVehicle(this, vehicle);
            }

            foreach (HeavyVehicle vehicle in HeavyVehicles) {
                new RentHeavyVehicle(this, vehicle);
            }
        }

        public double GetRentValue() {
            double total = 0;
            total += RentLightVehicle.GetTotal(this.Id);
            total += RentHeavyVehicle.GetTotal(this.Id);
            
            return total;
        }

        public DateTime GetReturnDate() {
            Customer customer = Customer.GetCustomer(this.CustomerId);

            return this.RentDate.AddDays(customer.ReturnDays);
        }

        public override string ToString () {
            // Data da Locação: 04/03/2021
            // Id: 0 - Nome: João
            string Print = String.Format (
                "Data da Locação: {0:d} - Data da Devolução: "
                    + "{1:d} - Valor: {2:C}\nCliente: {3}",
                this.RentDate,
                this.GetReturnDate(),
                this.GetRentValue(),
                this.Customer
            );
            Print += "\nVeículos Leves Locados: ";
            if (RentLightVehicle.GetCount(this.Id) > 0) {
                foreach (RentLightVehicle item in RentLightVehicle
                    .GetVehicles(this.Id)) 
                {
                    LightVehicle vehicle = LightVehicle
                        .GetLightVehicle(item.LightVehicleId);
                    Print += "\n    " + vehicle;
                }
            } else {
                Print += "\n    Nada Consta";
            }

            Print += "\nVeículos Pesados Locados: ";
            if (RentHeavyVehicle.GetCount(this.Id) > 0) {
                foreach (RentHeavyVehicle item in RentHeavyVehicle
                    .GetVehicles(this.Id)) 
                {
                    HeavyVehicle vehicle = HeavyVehicle
                        .GetHeavyVehicle(item.HeavyVehicleId);
                    Print += "\n    " + vehicle;
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
            return from rent in Context.Rents select rent;
        }

        public static int GetCount(int CustomerId) {
            return (from rent in Context.Rents where rent
                .CustomerId == CustomerId select rent).Count();
        }

    }
}
