using System;
using System.Collections.Generic;

namespace View {
    /// <summary>
    /// Represents the Customer View
    /// </summary>
    public static class Customer {
        /// <summary>
        /// Generates the Customer creation
        /// </summary>
        public static void CreateCustomer () {
            Console.WriteLine ("Informe o Nome do Cliente: ");
            string Name = Console.ReadLine ();
            Console.WriteLine ("Informe a Data de Nascimento do Cliente: ");
            string Birth = Console.ReadLine ();
            Console.WriteLine ("Informe o CPF do Cliente: ");
            string Identification = Console.ReadLine ();
            Console.WriteLine ("Informe a quantidade de dias de devolução do Cliente: ");
            string ReturnDays = Console.ReadLine ();
            try {
                Controller.Customer.CreateCustomer (Name, Birth, Identification, ReturnDays);
            } catch (Exception e) {
                Console.WriteLine ($"Informações digitadas são incorretas: {e.Message}");
            }
        }
        /// <summary>
        /// Shows the customer's list
        /// </summary>
        public static void ListCustomers () {
            List<Model.Customer> customers = Controller.Customer.ListCustomers ();

            foreach (Model.Customer customer in customers) {
                Console.WriteLine ("---------------------------");
                Console.WriteLine (customer);
            }
        }
    }
}
