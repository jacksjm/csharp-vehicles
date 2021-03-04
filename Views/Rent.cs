using System;
using System.Collections.Generic;

namespace View {
    public class Rent {
        public static void CreateRent() {
            Console.WriteLine ("Informe o Id do Cliente: ");
            string IdCustomer = Console.ReadLine ();
            Console.WriteLine ("Informe a Data da Locação: ");
            string RentDate = Console.ReadLine ();

            try {
                Controller.Rent.CreateRent(IdCustomer, RentDate);
            } catch (Exception e) {
                Console.WriteLine ($"Informações digitadas são incorretas: {e.Message}");
            }
        }

        public static void ListRents() {
            List<Model.Rent> Rents = Controller.Rent.GetRents();

            foreach (Model.Rent Rent in Rents)
            {
                Console.WriteLine ("---------------------------");
                Console.WriteLine (Rent);
            }
        }
    }
}
