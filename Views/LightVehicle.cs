using System;
using System.Collections.Generic;

namespace View {
    public class LightVehicle {
        public static void CreateVehicle () {
            Console.WriteLine ("Informe a Marca do Veículo: ");
            string Brand = Console.ReadLine ();
            Console.WriteLine ("Informe o Modelo do Veículo: ");
            string Model = Console.ReadLine ();
            Console.WriteLine ("Informe o Ano do Veículo: ");
            string Year = Console.ReadLine ();
            Console.WriteLine ("Informe o Preço de Locação do Veículo: ");
            string Price = Console.ReadLine ();
            Console.WriteLine ("Informe a Cor do Veículo: ");
            string Color = Console.ReadLine ();

            Controller.LightVehicle.CreateLightVehicle (Brand, Model, Year, Price, Color);
        }

        public static void ListVehicles () {
            List<Model.LightVehicle> heavyVehicles = Controller.LightVehicle.GetLightVehicles ();

            foreach (Model.LightVehicle vehicle in heavyVehicles) {
                Console.WriteLine ("---------------------------");
                Console.WriteLine (vehicle);
            }
        }
    }
}
