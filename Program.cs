using System;
using System.Drawing;
using System.Windows.Forms;
using Views;
using Views.Libs;

namespace csharp_vehicles {
    public class Program {
        /// <summary>
        /// Start the system
        /// </summary>
        /// <param name="args"></param>
        public static void Main () {
            Views.Import.DBImport ();
            Application.EnableVisualStyles ();
            Application.Run (new Menu ());
        }
        /*public static void Main () {
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
        }*/

        public class Menu : LibForm {
            LibLabel lblTitle;
            LibButton btnCreateCustomer;
            LibButton btnListCustomer;

            LibButton btnUpdateCustomer;

            LibButton btnRemoveCustomer;
            LibButton btnCreateLightVehicle;
            LibButton btnListLightVehicle;

            LibButton btnUpdateLightVehicle;

            LibButton btnRemoveLightVehicle;
            LibButton btnCreateHeavyVehicle;
            LibButton btnListHeavyVehicle;

            LibButton btnUpdateHeavyVehicle;

            LibButton btnRemoveHeavyVehicle;
            LibButton btnCreateRent;
            LibButton btnListRent;

            LibButton btnUpdateRent;

            LibButton btnRemoveRent;
            public Menu () {
                lblTitle = new LibLabel("Revenda", 130, 20);

                btnCreateCustomer = new LibButton (
                    "Cadastrar Cliente", 
                    70, 
                    60, 
                    Click: this.btnCreateCustomerClick
                );

                btnListCustomer = new LibButton (
                    "Listar Cliente", 
                    70, 
                    100,
                    Click: this.btnListCustomerClick
                );

                btnUpdateCustomer = new LibButton (
                    "Alterar Cliente", 
                    70, 
                    140,
                    Click: this.btnUpdateCustomerClick
                );

                btnRemoveCustomer = new LibButton (
                    "Remover Cliente", 
                    70, 
                    180,
                    Click: this.btnRemoveCustomerClick
                );

                btnCreateLightVehicle = new LibButton (
                    "Criar Veículo Leve", 
                    70, 
                    220,
                    Click: this.btnCreateCustomerClick
                );

                btnListLightVehicle = new LibButton (
                    "Listar Veículo Leve", 
                    70, 
                    260,
                    Click: this.btnCreateCustomerClick
                );

                btnUpdateLightVehicle = new LibButton (
                    "Alterar Veículo Leve", 
                    70, 
                    300,
                    Click: this.btnCreateCustomerClick
                );

                btnRemoveLightVehicle = new LibButton (
                    "Remover Veículo Leve", 
                    70, 
                    340,
                    Click: this.btnCreateCustomerClick
                );

                btnCreateHeavyVehicle = new LibButton (
                    "Criar Veículo Pesado", 
                    70, 
                    380,
                    Click: this.btnCreateCustomerClick
                );

                btnListHeavyVehicle = new LibButton (
                    "Listar Veículo Pesado", 
                    70, 
                    420,
                    Click: this.btnCreateCustomerClick
                );

                btnUpdateHeavyVehicle = new LibButton (
                    "Alterar Veículo Pesado", 
                    70, 
                    460,
                    Click: this.btnCreateCustomerClick
                );

                btnRemoveHeavyVehicle = new LibButton (
                    "Remover Veículo Pesado", 
                    70, 
                    500,
                    Click: this.btnCreateCustomerClick
                );

                btnCreateRent = new LibButton (
                    "Criar Locação", 
                    70, 
                    540,
                    Click: this.btnCreateCustomerClick
                );

                btnListRent = new LibButton (
                    "Listar Locação", 
                    70, 
                    580,
                    Click: this.btnCreateCustomerClick
                );

                btnUpdateRent = new LibButton (
                    "Alterar Locação", 
                    70, 
                    620,
                    Click: this.btnCreateCustomerClick
                );

                btnRemoveRent = new LibButton (
                    "Remover Locação", 
                    70, 
                    660,
                    Click: this.btnCreateCustomerClick
                );

                this.Controls.Add (lblTitle);

                this.Controls.Add (btnCreateCustomer);
                this.Controls.Add (btnListCustomer);
                this.Controls.Add (btnUpdateCustomer);
                this.Controls.Add (btnRemoveCustomer);

                this.Controls.Add (btnCreateLightVehicle);
                this.Controls.Add (btnListLightVehicle);
                this.Controls.Add (btnUpdateLightVehicle);
                this.Controls.Add (btnRemoveLightVehicle);

                this.Controls.Add (btnCreateHeavyVehicle);
                this.Controls.Add (btnListHeavyVehicle);
                this.Controls.Add (btnUpdateHeavyVehicle);
                this.Controls.Add (btnRemoveHeavyVehicle);

                this.Controls.Add (btnCreateRent);
                this.Controls.Add (btnListRent);
                this.Controls.Add (btnUpdateRent);
                this.Controls.Add (btnRemoveRent);
                this.Size = new Size (320, 800);
            }

            private void btnCreateCustomerClick (object sender, EventArgs e) {
                CustomerCreate customerCreate = new CustomerCreate ();
                customerCreate.Show ();
            }

            private void btnUpdateCustomerClick (object sender, EventArgs e) {
                string id = "";
                new InputBox(
                    "Alterar o Cliente",
                    "Informe o ID do Cliente",
                    ref id
                );
                try {
                    CustomerCreate customerUpdate = new CustomerCreate (id);
                    customerUpdate.Show ();
                } catch (Exception error) {
                    MessageBox.Show(
                        error.Message,
                        "Error",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error
                    );
                }
            }

            private void btnRemoveCustomerClick (object sender, EventArgs e) {
                string id = "";
                new InputBox(
                    "Remover o Cliente",
                    "Informe o ID do Cliente",
                    ref id
                );

                try {
                    Controller.Customer.DeleteCustomer(id);
                } catch (Exception error) {
                    MessageBox.Show(
                        error.Message,
                        "Error",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error
                    );
                }
                
            }

            private void btnListCustomerClick (object sender, EventArgs e) {
                CustomerList customerList = new CustomerList ();
                customerList.Show ();
            }

        }
    }
}
