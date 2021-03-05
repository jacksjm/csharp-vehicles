using System;
using Database;
using System.Collections.Generic;

namespace Model {
    /// <summary>
    /// Represents the Customer abstraction
    /// </summary>
    public class Customer : Database<Customer> {
        private int Id; // Identificador Único (ID)
        private string Name; // Nome
        private string Birth; // Data de Nascimento
        private string Identification; // C.P.F.
        private int ReturnDays; // Dias para Devolução

        /// <summary>
        /// Constructor to Customer object
        /// </summary>
        /// <param name="Name">The Customer's name</param>
        /// <param name="Birth">The Customer's birthday</param>
        /// <param name="Identification">The Customer's individual identification, like brazilian C.P.F.</param>
        /// <param name="ReturnDays">The number of return days the customer has</param>
        public Customer (
            string Name,
            string Birth,
            string Identification,
            int ReturnDays
        ) {
            this.Id = base.GetNewId();
            this.Name = Name;
            this.Birth = Birth;
            this.Identification = Identification;
            this.ReturnDays = ReturnDays;

            base.AddItem (this);
        }

        /// <summary>
        /// The ID Set's
        /// </summary>
        /// <param name="Id">ID value</param>
        public void SetId (int Id) {
            this.Id = Id;
        }
        /// <summary>
        /// The Name Set's
        /// </summary>
        /// <param name="Name">Name value</param>
        public void SetName (string Name) {
            this.Name = Name;
        }
        /// <summary>
        /// The Birth Set's
        /// </summary>
        /// <param name="Birth">Birth value</param>
        public void SetBirth (string Birth) {
            this.Birth = Birth;
        }
        /// <summary>
        /// The Identification Set's
        /// </summary>
        /// <param name="Identification">Identification value</param>
        public void SetIdentification (string Identification) {
            this.Identification = Identification;
        }
        /// <summary>
        /// The Return Days Set's
        /// </summary>
        /// <param name="ReturnDays"></param>
        public void SetReturnDays (int ReturnDays) {
            this.ReturnDays = ReturnDays;
        }

        /// <summary>
        /// The ID Get's
        /// </summary>
        /// <returns>Unique Identification of Customer</returns>
        public int GetId () {
            return this.Id;
        }
        /// <summary>
        /// The Name Get's
        /// </summary>
        /// <returns>Customer Name value</returns>
        public string GetName () {
            return this.Name;
        }
        /// <summary>
        /// The Birth Get's
        /// </summary>
        /// <returns>Customer Birth value</returns>
        public string GetBirth () {
            return this.Birth;
        }
        /// <summary>
        /// The Identification Get's
        /// </summary>
        /// <returns>Customer Identification value</returns>
        public string GetIdentification () {
            return this.Identification;
        }
        /// <summary>
        /// The Return Days Get's
        /// </summary>
        /// <returns>Customer Return Days value</returns>
        public int GetReturnDays () {
            return this.ReturnDays;
        }

        /// <summary>
        /// The value that represents the customer's text
        /// </summary>
        /// <returns>Customer's text</returns>
        public override string ToString () {
            return $"Id: {this.GetId()} - Nome: {this.GetName()}";
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
                hash = (hash * 16777619) ^ this.GetId ().GetHashCode ();
                return hash;
            }
        }
    }
}
