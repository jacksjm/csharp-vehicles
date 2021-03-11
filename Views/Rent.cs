using System;
using System.Collections.Generic;

namespace View {
    public class Rent {
        public static void CreateRent() {
            List<Model.LightVehicle> LightVehicles = new ();
            Console.WriteLine ("Informe o Id do Cliente: ");
            string IdCustomer = Console.ReadLine ();
            Console.WriteLine ("Informe a Data da Locação: ");
            string RentDate = Console.ReadLine ();

            int opt;
            do {
                Console.WriteLine ("Informe o Id do Veículo Leve: ");
                try {
                    int IdVehicle = Convert.ToInt32(Console.ReadLine ());
                    Model.LightVehicle vehicle = Controller.LightVehicle.GetLightVehicle(IdVehicle);
                    LightVehicles.Add(vehicle);
                } catch (Exception e) {
                    Console.WriteLine(e.Message);
                }
                Console.WriteLine ("Deseja informar outro veículo? [1] Sim");
                opt = Convert.ToInt32(Console.ReadLine());
            } while(opt == 1);

            try {
                Controller.Rent.CreateRent(IdCustomer, RentDate, LightVehicles);
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
