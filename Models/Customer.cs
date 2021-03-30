using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Repository;

namespace Model {
    /// <summary>
    /// Represents the Customer abstraction
    /// </summary>
    public class Customer {
        public int Id { set; get; } // Identificador Único (ID)
        [Required]
        public string Name { set; get; } // Nome
        public DateTime Birth { set; get; } // Data de Nascimento
        public string Identification { set; get; } // C.P.F.
        public int ReturnDays { set; get; } // Dias para Devolução

        public Customer() {
            
        }
        /// <summary>
        /// Constructor to Customer object
        /// </summary>
        /// <param name="Name">The Customer's name</param>
        /// <param name="Birth">The Customer's birthday</param>
        /// <param name="Identification">The Customer's individual identification, like brazilian C.P.F.</param>
        /// <param name="ReturnDays">The number of return days the customer has</param>
        public Customer (
            string Name,
            DateTime Birth,
            string Identification,
            int ReturnDays
        ) {
            Context db = new Context();
            //this.Id = db.Customers.Count;
            this.Name = Name;
            this.Birth = Birth;
            this.Identification = Identification;
            this.ReturnDays = ReturnDays;

            db.Customers.Add (this);
            db.SaveChanges();
        }

        /// <summary>
        /// The value that represents the customer's text
        /// </summary>
        /// <returns>Customer's text</returns>
        public override string ToString () {
            return String.Format(
                "Id: {0} - Nome: {1} - Data de Nascimento: {2:d} - Dias p/ Devolução: {3} - Qtd. Locações {4}",
                this.Id,
                this.Name,
                this.Birth,
                this.ReturnDays,
                Rent.GetCount(this.Id)
            );
        }

        /// <summary>
        /// The value that represents customer equality
        /// </summary>
        /// <param name="obj">Any object to compare</param>
        /// <returns>If the values is equals</returns>
        public override bool Equals (object obj) {
            if (obj == null) {
                return false;
            }
            if (obj.GetType () != this.GetType ()) {
                return false;
            }
            Customer customer = (Customer) obj;
            return this.GetHashCode () == customer.GetHashCode ();
        }

        /// <summary>
        /// Generate the object hash code
        /// </summary>
        /// <returns>Hash Code</returns>
        public override int GetHashCode () {
            unchecked // Overflow is fine, just wrap
            {
                int hash = (int) 2166136261;
                // Suitable nullity checks etc, of course :)
                hash = (hash * 16777619) ^ this.Id.GetHashCode ();
                return hash;
            }
        }

        /// <summary>
        /// Returns the fake database informations
        /// </summary>
        /// <returns>Returns the customer list collection</returns>
        public static IEnumerable<Customer> GetCustomers () {
            Context db = new Context();
            return from customer in db.Customers select customer;
        }

        public static int GetCount () {
            return GetCustomers().Count();
        }

        /// <summary>
        /// Inserts a new customer on Fake Database
        /// </summary>
        /// <param name="customer">The customer's object</param>
        public static void AddCustomer (Customer customer) {
            Context db = new Context();
            db.Customers.Add (customer);
        }

        public static Customer GetCustomer(int Id) {
            // Context db = new Context();

            // SELECT * FROM customer;
            // from customer in Context.Customers select customer;

            // "SELECT * FROM customer WHERE id = '" + Id + "'";
            Context db = new Context();
            IEnumerable<Customer> query = from customer in db.Customers where customer.Id == Id select customer;

            return query.First();
            
            // return Context.Customers[Id];
        }
    }
}
