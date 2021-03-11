using System;
using System.Collections.Generic;

namespace Model
{
    public class Rent {
        public int Id {set; get;} // Identificador Único (ID)
        public Customer Customer { set; get; } // Cliente
        public DateTime RentDate { set; get; }// Data de Locação

        public static readonly List<Rent> Rents = new ();

        public Rent(
            Customer Customer, 
            DateTime RentDate
        ) {
            this.Customer = Customer;
            this.RentDate = RentDate;

            Rents.Add(this);
        }

        public override string ToString()
        {
            // Data da Locação: 04/03/2021
            // Id: 0 - Nome: João
            return String.Format(
                "Data da Locação: {0:d}\nCliente: {1}", 
                this.RentDate, 
                this.Customer
            );
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
