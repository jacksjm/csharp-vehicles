using System;
using System.Collections.Generic;
using Database;

namespace Model
{
    public class Rent : Database<Rent> {
        public int Id {set; get;} // Identificador Único (ID)
        public Customer Customer { set; get; } // Cliente
        public DateTime RentDate { set; get; }// Data de Locação

        public Rent(
            Customer Customer, 
            DateTime RentDate
        ) {
            this.Id = base.GetNewId();
            this.Customer = Customer;
            this.RentDate = RentDate;

            base.AddItem(this);
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

    }
}
