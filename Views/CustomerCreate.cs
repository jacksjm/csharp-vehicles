/*using System;
using System.Drawing;
using System.Windows.Forms;
using View.Libs;

namespace View {
    public class CustomerCreate : Form {
        private TitleLabel lblTitle;

        private LibLabel lblNome;
        private Label lblDtNasc;
        private Label lblCPF;
        private Label lblDiasDev;
        private Label lblNews;
        private TextBox txtNome;
        private TextBox txtDtNasc;
        private TextBox txtCPF;
        private TextBox txtDiasDev;
        private Button btnCancelar;
        private Button btnConfirmar;
        private ComboBox cbDiasDev;
        private CheckBox checkMail;
        private GroupBox genderGroup;
        private RadioButton choiceFemale;
        private RadioButton choiceMale;
        private RadioButton choiceNotInform;

        public CustomerCreate () {
            this.Text = "Cadastro de Cliente";
            
            lblTitle = new TitleLabel("Cadastro de Cliente", new Point(15,5), new Size(320,20));

            lblNome = new LibLabel ("Nome", new Point (20, 20), new Size (40, 40));

            txtNome = new TextBox ();
            txtNome.Location = new Point (180, 20);
            txtNome.Size = new Size (100, 18);

            lblDtNasc = new LibLabel ("Dt. Nasc.", new Point (20, 80), new Size (60, 40));

            txtDtNasc = new TextBox ();
            txtDtNasc.Location = new Point (180, 80);
            txtDtNasc.Size = new Size (100, 18);

            lblCPF = new Label ();
            lblCPF.Text = "C.P.F.";
            lblCPF.Location = new Point (20, 140);
            lblCPF.Size = new Size (60, 40);

            txtCPF = new TextBox ();
            txtCPF.Location = new Point (180, 140);
            txtCPF.Size = new Size (100, 18);

            lblDiasDev = new Label ();
            lblDiasDev.Text = "Dias Dev.";
            lblDiasDev.Location = new Point (20, 200);
            lblDiasDev.Size = new Size (60, 40);

            cbDiasDev = new ComboBox ();
            cbDiasDev.Location = new Point (180, 200);
            cbDiasDev.Size = new Size (100, 18);
            /*cbDiasDev.Items.Add("5");
            cbDiasDev.Items.Add("10");
            cbDiasDev.Items.Add("15");
            cbDiasDev.Items.Add("20");
            cbDiasDev.Items.AddRange (new string[] { "5", "10", "15", "20" });

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

            lblNews = new Label ();
            lblNews.Text = "Deseja receber newslaters";
            lblNews.Location = new Point (50, 320);
            lblNews.Size = new Size (160, 40);

            btnCancelar = new Button ();
            btnCancelar.Text = "Cancelar";
            btnCancelar.Size = new Size (100, 30);
            btnCancelar.Location = new Point (60, 400);
            btnCancelar.Click += new EventHandler (this.btnConfirmarClick);

            btnConfirmar = new Button ();
            btnConfirmar.Text = "Confirmar";
            btnConfirmar.Size = new Size (100, 30);
            btnConfirmar.Location = new Point (180, 400);
            btnConfirmar.Click += new EventHandler (this.btnConfirmarClick);

            this.Size = new Size (350, 450);
            this.Controls.Add (lblTitle);
            this.Controls.Add (lblNome);
            this.Controls.Add (txtNome);
            this.Controls.Add (lblDtNasc);
            this.Controls.Add (txtDtNasc);
            this.Controls.Add (lblCPF);
            this.Controls.Add (txtCPF);
            this.Controls.Add (lblDiasDev);
            this.Controls.Add (cbDiasDev);
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
                MessageBox.Show ("Sim");
            } else if (resultado == DialogResult.No) {
                MessageBox.Show ("Não");
            } else {
                MessageBox.Show ("Opção Desconhecida");
            }
            this.Close ();
        }
    }
}
*/
