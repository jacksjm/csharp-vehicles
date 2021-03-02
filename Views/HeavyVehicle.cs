using System;
using System.Collections.Generic;

namespace View
{
    public class HeavyVehicle
    {
        public static void CreateVehicle()
        {
            Console.WriteLine("Informe a Marca do Veículo: ");
            string Brand = Console.ReadLine();
            Console.WriteLine("Informe o Modelo do Veículo: ");
            string Model = Console.ReadLine();
            Console.WriteLine("Informe o Ano do Veículo: ");
            string Year = Console.ReadLine();
            Console.WriteLine("Informe o Preço de Locação do Veículo: ");
            string Price = Console.ReadLine();
            Console.WriteLine("Informe o Restrições do Veículo: ");
            string Restrictions = Console.ReadLine();

            Controller.HeavyVehicle.CreateHeavyVehicle(Brand, Model, Year, Price, Restrictions);
        }

        public static void ListVehicles()
        {
            List<Model.HeavyVehicle> heavyVehicles = Controller.HeavyVehicle.GetHeavyVehicles();

            foreach (Model.HeavyVehicle vehicle in heavyVehicles)
            {
                Console.WriteLine("---------------------------");
                Console.WriteLine(vehicle);
            }
        }
    }
}