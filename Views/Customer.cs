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

        public static void UpdateCustomer() {
            Model.Customer customer;
            try {
                Console.WriteLine ("Informe o ID do Cliente: ");
                string Id = Console.ReadLine();
                customer = Controller.Customer.GetCustomer(Id);
            } catch (Exception e) {
                Console.WriteLine(e.Message);
                return;
            }
            Console.WriteLine ("Informe o Campo para Alteração: (1-Nome;2-C.P.F.)");
            string field = Console.ReadLine();

            Console.WriteLine ("Informe o Valor para Alteração:");
            string value = Console.ReadLine();

            try {
                Controller.Customer.UpdateCustomer(customer,field,value);
            } catch (Exception e) {
                Console.WriteLine(e.Message);
            }

        }

        public static void DeleteCustomer() {
            try {
                Console.WriteLine ("Informe o ID do Cliente: ");
                string Id = Console.ReadLine();
                Controller.Customer.DeleteCustomer(Id);
            } catch (Exception e) {
                Console.WriteLine(e.Message);
            }
        }
        /// <summary>
        /// Shows the customer's list
        /// </summary>
        public static void ListCustomers () {            
            foreach (Model.Customer customer in Controller.Customer.ListCustomers ()) {
                Console.WriteLine ("---------------------------");
                Console.WriteLine (customer);
            }
            Console.WriteLine ("---------------------------\n");
        }
    }
}
