using System;
using System.Collections.Generic;

namespace Model {
    /// <summary>
    /// Represents the Customer abstraction
    /// </summary>
    public class Customer {
        public int Id { set; get; } // Identificador Único (ID)
        public string Name { set; get; } // Nome
        public DateTime Birth { set; get; } // Data de Nascimento
        public string Identification { set; get; } // C.P.F.
        public int ReturnDays { set; get; } // Dias para Devolução

        // Generates a List to use a Fake Database
        private static readonly List<Customer> customers = new ();

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
            this.Id = customers.Count;
            this.Name = Name;
            this.Birth = Birth;
            this.Identification = Identification;
            this.ReturnDays = ReturnDays;

            customers.Add (this);
        }

        /// <summary>
        /// The value that represents the customer's text
        /// </summary>
        /// <returns>Customer's text</returns>
        public override string ToString () {
            return String.Format(
                "Id: {0} - Nome: {1} - Data de Nascimento: {2:d}",
                this.Id,
                this.Name,
                this.Birth
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
        public static List<Customer> GetCustomers () {
            return customers;
        }

        /// <summary>
        /// Inserts a new customer on Fake Database
        /// </summary>
        /// <param name="customer">The customer's object</param>
        public static void AddCustomer (Customer customer) {
            customers.Add (customer);
        }

        public static Customer GetCustomer(int Id) {
            return customers[Id];
        }
    }
}
