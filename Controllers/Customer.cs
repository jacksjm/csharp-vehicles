using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Controller {
    /// <summary>
    /// Represents the Customer Business Rules
    /// </summary>
    public static class Customer {
        /// <summary>
        /// Handles and saves customer information
        /// </summary>
        /// <throw>Exception - Regex C.P.F.</throw>
        /// <throw>Exception - Regex Date</throw>
        /// <param name="Name">Customer's name</param>
        /// <param name="Birth">Customer's birth</param>
        /// <param name="Identification">Customer's identification</param>
        /// <param name="ReturnDays">Customer's return days</param>
        public static Model.Customer CreateCustomer (
            string Name,
            string StringBirth,
            string Identification,
            string ReturnDays
        ) {
            // Checks if the Identification is in the pattern 999.999.999-99
            Regex rgx = new ("^\\d{3}\\.\\d{3}\\.\\d{3}-\\d{2}$");
            if (!rgx.IsMatch (Identification)) {
                throw new Exception ("C.P.F. Inválido");
            }

            DateTime Birth;

            try {
                Birth = Convert.ToDateTime (StringBirth);
            } catch {
                throw new Exception ("Data de Nascimento Inválida");
            }

            // Create new customer
            return new Model.Customer (
                Name,
                Birth,
                Identification,
                Convert.ToInt32 (ReturnDays)
            );
            /*List<Model.Customer> customers = Model.Customer.GetCustomers();
            foreach (Model.Customer item in customers)
            {
                if (item.Equals(customer)) {
                    throw new Exception("ID Inválido. Digite novamente.");
                }
            }
            Model.Customer.AddCustomer(customer);*/
        }

        /// <summary>
        /// Gets the customer's lits
        /// </summary>
        /// <returns>Returns the customer list collection</returns>
        public static IEnumerable<Model.Customer> ListCustomers () {
            return Model.Customer.GetCustomers ();
        }

        public static Model.Customer GetCustomer (string StringId) {
            int Id = Convert.ToInt32(StringId);
            Model.Customer LastCustomer = Model.Customer.GetLast();

            if (Id < 0 || LastCustomer.Id < Id) {
                throw new Exception ("Id informado é inválido.");
            }

            return Model.Customer.GetCustomer (Id);
        }

        public static Model.Customer UpdateCustomer(
            Model.Customer customer,
            string opcao,
            string value
        ) {
            int field = Convert.ToInt32(opcao);
            switch(field) {
                case 1:
                    return Model.Customer.UpdateCustomer(customer, field, value);
                case 2:
                    // Checks if the Identification is in the pattern 999.999.999-99
                    Regex rgx = new ("^\\d{3}\\.\\d{3}\\.\\d{3}-\\d{2}$");
                    if (!rgx.IsMatch (value)) {
                        throw new Exception ("C.P.F. Inválido");
                    }
                    return Model.Customer.UpdateCustomer(customer, field, value);
                default:
                    throw new Exception("Operacao inválida");
            }
        }

        public static void DeleteCustomer (string StringId) {
            int Id = Convert.ToInt32(StringId);
            try {
                Model.Customer.DeleteCustomer (Id);
            } catch {
                Console.WriteLine("Exclusão não permitida ou ID Inválido");
            }
            
        }
    }
}
