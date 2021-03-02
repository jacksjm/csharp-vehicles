using System;

namespace csharp_vehicles
{
    public class Program
    {
        /// <summary>
        /// Start the system
        /// </summary>
        /// <param name="args"></param>
        public static void Main(string[] args)
        {
            int opt = 0;
            Console.WriteLine("Bem vindo a nossa revenda");
            // Always repeat until the user leaves
            do {
                Console.WriteLine("Digite a operação de Menu");
                Console.WriteLine("1 - Cadastrar Cliente");
                Console.WriteLine("2 - Lista de Clientes");
                Console.WriteLine("3 - Cadastrar Veículo Pesado");
                Console.WriteLine("4 - Lista de Veículos Pesados");
                Console.WriteLine("0 - Sair");
                // Get the user option
                opt = Convert.ToInt32(Console.ReadLine());
                switch(opt) {
                    case 0:
                        // Close system
                        break;
                    case 1:
                        View.Customer.CreateCustomer();
                        break;
                    case 2:
                        View.Customer.ListCustomers();
                        break;
                    case 3:
                        View.HeavyVehicle.CreateVehicle();
                        break;
                    case 4:
                        View.HeavyVehicle.ListVehicles();
                        break;
                    default:
                        Console.WriteLine("Operação Inválida.");
                        break;
                }
            } while(opt != 0);
        }

    }
}
