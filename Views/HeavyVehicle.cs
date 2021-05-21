using System;
using System.Collections.Generic;

namespace Views {
    public class HeavyVehicle {
        public static void CreateVehicle () {
            Console.WriteLine ("Informe a Marca do Veículo: ");
            string Brand = Console.ReadLine ();
            Console.WriteLine ("Informe o Modelo do Veículo: ");
            string Model = Console.ReadLine ();
            Console.WriteLine ("Informe o Ano do Veículo: ");
            string Year = Console.ReadLine ();
            Console.WriteLine ("Informe o Preço de Locação do Veículo: ");
            string Price = Console.ReadLine ();
            Console.WriteLine ("Informe o Restrições do Veículo: ");
            string Restrictions = Console.ReadLine ();

            Controller.HeavyVehicle
                .CreateHeavyVehicle (Brand, Model, Year, Price, Restrictions);
        }

        public static void ListVehicles () {
            foreach (Model.HeavyVehicle vehicle in Controller.HeavyVehicle
                .GetHeavyVehicles ()) 
            {
                Console.WriteLine ("---------------------------");
                Console.WriteLine (vehicle);
            }
            Console.WriteLine ("---------------------------\n");
        }
    }
}
