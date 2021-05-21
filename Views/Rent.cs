using System;
using System.Collections.Generic;

namespace Views {
    public class Rent {
        public static void CreateRent () {
            int opt;
            int optLight;
            int optHeavy;
            List<Model.LightVehicle> LV = new List<Model.LightVehicle>();
            List<Model.HeavyVehicle> HV = new List<Model.HeavyVehicle>();
            Console.WriteLine ("Informe o Id do Cliente: ");
            string IdCustomer = Console.ReadLine ();
            Console.WriteLine ("Informe a Data da Locação: ");
            string RentDate = Console.ReadLine ();

            Console.WriteLine ("Foram locados veículos leves? [1] Sim");
            opt = Convert.ToInt32 (Console.ReadLine ());
            if (opt == 1) {
                do {
                    Console.WriteLine ("Informe o Id do Veículo Leve: ");
                    try {
                        int IdVehicle = Convert.ToInt32 (Console.ReadLine ());
                        Model.LightVehicle vehicle = Controller.LightVehicle
                            .GetLightVehicle (IdVehicle);
                        LV.Add (vehicle);
                    } catch (Exception e) {
                        Console.WriteLine (e.Message);
                    }
                    Console.WriteLine (
                        "Deseja informar outro veículo? [1] Sim"
                    );
                    optLight = Convert.ToInt32 (Console.ReadLine ());
                } while (optLight == 1);
            }
            Console.WriteLine ("Foram locados veículos pesados? [1] Sim");
            opt = Convert.ToInt32 (Console.ReadLine ());
            if (opt == 1) {
                do {
                    Console.WriteLine ("Informe o Id do Veículo Pesado: ");
                    try {
                        int IdVehicle = Convert.ToInt32 (Console.ReadLine ());
                        Model.HeavyVehicle vehicle = Controller.HeavyVehicle
                            .GetHeavyVehicle (IdVehicle);
                        HV.Add (vehicle);
                    } catch (Exception e) {
                        Console.WriteLine (e.Message);
                    }
                    Console.WriteLine (
                        "Deseja informar outro veículo? [1] Sim"
                    );
                    optHeavy = Convert.ToInt32 (Console.ReadLine ());
                } while (optHeavy == 1);
            }

            try {
                Controller.Rent.CreateRent (
                    IdCustomer,
                    RentDate,
                    LV,
                    HV
                );
            } catch (Exception e) {
                Console.WriteLine (
                    $"Informações digitadas são incorretas: {e.Message}"
                );
            }
        }

        public static void ListRents () {
            foreach (Model.Rent Rent in Controller.Rent.GetRents ()) {
                Console.WriteLine ("---------------------------");
                Console.WriteLine (Rent);
            }
            Console.WriteLine ("---------------------------\n");
        }
    }
}
