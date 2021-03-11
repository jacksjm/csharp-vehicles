using System;
using System.Collections.Generic;

namespace Model
{
    public class Rent {
        public int Id {set; get;} // Identificador Único (ID)
        public int CustomerId { set; get; } // Identificador Único do Cliente
        public Customer Customer { set; get; } // Cliente
        public DateTime RentDate { set; get; }// Data de Locação

        public List<RentLightVehicle> LightVehicles { set; get; }

        public static readonly List<Rent> Rents = new ();

        public Rent(
            Customer Customer, 
            DateTime RentDate,
            List<LightVehicle> LightVehicles
        ) {
            this.Customer = Customer;
            this.CustomerId = Customer.Id;
            this.RentDate = RentDate;
            this.LightVehicles = new ();

            foreach (LightVehicle vehicle in LightVehicles)
            {
                RentLightVehicle rentLightVehicle = new (this, vehicle);
                this.LightVehicles.Add(rentLightVehicle);
            }
            
            Rents.Add(this);
        }

        public override string ToString()
        {
            // Data da Locação: 04/03/2021
            // Id: 0 - Nome: João
            string Print = String.Format(
                "Data da Locação: {0:d}\nCliente: {1}", 
                this.RentDate, 
                this.Customer
            );
            Print += "\nVeículos Leves Locados: ";
            foreach (RentLightVehicle vehicle in LightVehicles)
            {
                Print += "\n" + vehicle.LightVehicle;
            }

            return Print;
        }

        public override bool Equals(object obj)
        {
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

        public static List<Rent> GetRents() {
            return Rents;
        }

    }
}
