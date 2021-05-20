using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Threading;
using System.Windows.Forms;
using Views.Libs;

namespace Views {
    public class CustomerCreate : LibForm {
        private Model.Customer customer;
        private LibLabel lblNome;
        private LibLabel lblDtNasc;
        private LinkLabel lblCPF;
        private LibLabel lblDiasDev;
        private LibLabel lblNews;
        private LibTextBox txtNome;
        private LibTextBox txtDtNasc;
        private MaskText txtCPF;
        private LibButton btnCancelar;
        private LibButton btnConfirmar;
        private Numeric nmDiasDev;
        private CheckBox checkMail;
        private GroupBox genderGroup;
        private RadioButton choiceFemale;
        private RadioButton choiceMale;
        private RadioButton choiceNotInform;

        public CustomerCreate (string id = "") {
            this.Text = "Cadastro de Cliente";
            if (!id.Trim ().Equals ("")) {
                try {
                    this.customer = Controller.Customer.GetCustomer (id);
                } catch (Exception error) {
                    throw error;
                }

                this.Load += new EventHandler (this.loadForm);
            }

            lblNome = new LibLabel ("Nome", 20, 20, 40, 20);
            txtNome = new LibTextBox (180, 20);

            lblDtNasc = new LibLabel ("Dt. Nasc.", 20, 80, 60, 20);
            txtDtNasc = new LibTextBox (180, 80);

            lblCPF = new LinkLabel ();
            lblCPF.Text = "C.P.F.";
            lblCPF.Location = new Point (20, 140);
            lblCPF.Size = new Size (60, 40);
            lblCPF.LinkClicked += new LinkLabelLinkClickedEventHandler (
                this.helpLink
            );

            txtCPF = new MaskText (180, 140, 100, 18, "000.000.000-00");

            lblDiasDev = new LibLabel ("Dias Dev.", 20, 200, 60, 40);
            nmDiasDev = new Numeric (180, 200, 5, 20);

            genderGroup = new GroupBox ();
            genderGroup.Text = "Sexo";
            genderGroup.Location = new Point (20, 240);
            genderGroup.Size = new Size (300, 60);

            choiceFemale = new RadioButton ();
            choiceFemale.Text = "Feminino";
            choiceFemale.Location = new Point (20, 20);
            choiceFemale.Size = new Size (75, 18);

            choiceMale = new RadioButton ();
            choiceMale.Text = "Masculino";
            choiceMale.Location = new Point (100, 20);
            choiceMale.Size = new Size (75, 18);

            choiceNotInform = new RadioButton ();
            choiceNotInform.Text = "Não informado";
            choiceNotInform.Location = new Point (185, 20);
            choiceNotInform.Size = new Size (110, 18);

            genderGroup.Controls.Add (choiceFemale);
            genderGroup.Controls.Add (choiceMale);
            genderGroup.Controls.Add (choiceNotInform);

            checkMail = new CheckBox ();
            checkMail.Location = new Point (20, 320);
            lblNews = new LibLabel (
                "Deseja receber newslaters",
                50,
                320,
                160,
                40
            );

            btnCancelar = new LibButton (
                "Cancelar",
                60,
                380,
                100,
                Click : this.btnConfirmarClick
            );
            btnConfirmar = new LibButton (
                "Confirmar",
                180,
                380,
                100,
                Click : this.btnConfirmarClick
            );

            this.Size = new Size (350, 450);
            this.Controls.Add (lblNome);
            this.Controls.Add (txtNome);
            this.Controls.Add (lblDtNasc);
            this.Controls.Add (txtDtNasc);
            this.Controls.Add (lblCPF);
            this.Controls.Add (txtCPF);
            this.Controls.Add (lblDiasDev);
            this.Controls.Add (nmDiasDev);
            this.Controls.Add (lblNews);
            this.Controls.Add (checkMail);
            this.Controls.Add (genderGroup);
            this.Controls.Add (btnCancelar);
            this.Controls.Add (btnConfirmar);
        }

        private void btnConfirmarClick (object sender, EventArgs e) {
            DialogResult resultado = MessageBox.Show (
                "Confirmado!",
                "Confirmar Cadastro",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (resultado == DialogResult.Yes) {
                try {
                    Controller.Customer.CreateCustomer (
                        this.txtNome.Text,
                        this.txtDtNasc.Text,
                        this.txtCPF.Text,
                        this.nmDiasDev.Value
                    );
                } catch (Exception error) {
                    MessageBox.Show (
                        error.Message,
                        "Error",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error
                    );
                }

            }
            this.Close ();
        }

        private void helpLink (object sender, LinkLabelLinkClickedEventArgs e) {
            this.lblCPF.LinkVisited = true;
        }

        private void loadForm (object sender, EventArgs e) {
            this.txtNome.Text = this.customer.Name;
            this.txtDtNasc.Text = this.customer.Birth.ToString ();
            this.txtCPF.Text = this.customer.Identification;
            this.nmDiasDev.Value = this.customer.ReturnDays;
        }
    }

    public class CustomerList : LibForm {
        private LibListView listView;
        private LibButton btnCancelar;

        public CustomerList () {
            List<Model.Customer> customers = Controller.Customer
                .ArrayCustomers ();
            LibColumn[] columns = new LibColumn[] {
                new LibColumn ("Id", HorizontalAlignment.Left),
                new LibColumn ("Nome", HorizontalAlignment.Left),
                new LibColumn ("Dt. Nasc.", HorizontalAlignment.Left),
                new LibColumn ("C.P.F.", HorizontalAlignment.Left),
                new LibColumn ("Dias Dev.", HorizontalAlignment.Left)
            };
            listView = new LibListView (25, 25, 400, 350, columns);
            foreach (Model.Customer customer in customers) {
                ListViewItem item = new ListViewItem (customer.Id.ToString ());
                item.SubItems.Add (customer.Name);
                item.SubItems.Add (String.Format ("{0:d}", customer.Birth));
                item.SubItems.Add (customer.Identification);
                item.SubItems.Add (customer.ReturnDays.ToString ());
                listView.Items.Add (item);
            }
            btnCancelar = new LibButton (
                "Cancelar",
                180,
                380,
                100,
                Click : this.btnCancelarClick
            );

            this.Size = new Size (450, 450);
            this.Controls.Add (listView);
            this.Controls.Add (btnCancelar);
        }

        private void btnCancelarClick (object sender, EventArgs e) {
            this.Close ();
        }
    }
}
