using System;

namespace csharp_vehicles {
    public class Program {
        /// <summary>
        /// Start the system
        /// </summary>
        /// <param name="args"></param>
        public static void Main () {
            int opt;
            Console.WriteLine ("======= Bem vindo a nossa revenda =======");
            // Always repeat until the user leaves
            do {
                Console.WriteLine ("+--------------------------------+");
                Console.WriteLine ("| Digite a operação de Menu      |");
                Console.WriteLine ("| 1  - Cadastrar Cliente         |");
                Console.WriteLine ("| 2  - Lista de Clientes         |");
                Console.WriteLine ("| 3  - Alterar Cliente           |");
                Console.WriteLine ("| 4  - Excluir Cliente           |");
                Console.WriteLine ("| 5  - Cadastrar Veículo Pesado  |");
                Console.WriteLine ("| 6  - Lista de Veículos Pesados |");
                Console.WriteLine ("| 7  - Cadastrar Veículo Leve    |");
                Console.WriteLine ("| 8  - Lista de Veículos Leves   |");
                Console.WriteLine ("| 9  - Cadastrar Locação         |");
                Console.WriteLine ("| 10 - Lista de Locações         |");
                Console.WriteLine ("| 11 - Importar Informações      |");
                Console.WriteLine ("| 0  - Sair                      |");
                Console.WriteLine ("+--------------------------------+");
                // Get the user option
                opt = Convert.ToInt32 (Console.ReadLine ());
                switch (opt) {
                    case 0:
                        Console.WriteLine ("======= Até a próxima! =======");
                        // Close system
                        break;
                    case 1:
                        View.Customer.CreateCustomer ();
                        break;
                    case 2:
                        View.Customer.ListCustomers ();
                        break;
                    case 3:
                        View.Customer.UpdateCustomer ();
                        break;
                    case 4:
                        View.Customer.DeleteCustomer ();
                        break;
                    case 5:
                        View.HeavyVehicle.CreateVehicle ();
                        break;
                    case 6:
                        View.HeavyVehicle.ListVehicles ();
                        break;
                    case 7:
                        View.LightVehicle.CreateVehicle ();
                        break;
                    case 8:
                        View.LightVehicle.ListVehicles ();
                        break;
                    case 9:
                        View.Rent.CreateRent ();
                        break;
                    case 10:
                        View.Rent.ListRents ();
                        break;
                    case 11:
                        View.Import.DBImport ();
                        break;
                    default:
                        Console.WriteLine ("Operação Inválida.");
                        break;
                }
            } while (opt != 0);
        }

    }
}
