using System;
using System.Windows.Forms;
using AliSlib;
using Obj;
using AliSLogica.Controladores;

namespace AliS_WinVer
{
    public partial class AñadirPuesto : Form
    {
        #region PROPIEDADES
        PrincipalPuestos puestos;
        #endregion

        #region INICIO
        public AñadirPuesto(PrincipalPuestos Puestos)
        {
            InitializeComponent();
            this.puestos = Puestos;
        }

        private void AddPuesto_Load(object sender, EventArgs e)
        {

        }
        #endregion

        #region BOTONES

        private void button1_Click(object sender, EventArgs e)
        {
            string basico = BasiBox.Text.Replace(",", ".");
            string puesto = puestoBox.Text;
            int tipoPuesto = 0;

            if (puestoBox.Text == "" || radioMen.Checked == false && radioQuin.Checked == false || BasiBox.Text == "")
            {
                MessageBox.Show("Debe rellenar los campos faltantes.");
            }
            else
            {
                try
                {

                    foreach (Control control in this.Controls)
                    {
                        if (control is TextBox)
                        {
                            if (control.Text == "" || control.Text == "0")
                            {
                                control.Text = "0";
                            }
                        }
                    }

                    if (radioMen.Checked)
                    {
                        tipoPuesto = 1;
                    }
                    else
                    {
                        tipoPuesto = 2;
                    }

                    string rta = ControladorPuesto.InsertarAcualizarPuesto(UsuarioSingleton.Instance.codigoEmpresa, 0, puesto, tipoPuesto, basico);

                    if (rta.Equals("ok"))
                    {
                        puestos.puestos_Load(null, EventArgs.Empty);

                        puestos.Enabled = true;
                        puestos.Visible = true;
                        puestos.button1.Enabled = true;
                        puestos.button2.Enabled = true;
                        puestos.button3.Enabled = true;

                        this.Close();
                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            puestos.button1.Enabled = true;
            puestos.Enabled = true;
            puestos.Visible = true;
            Close();
        }
        #endregion

        #region EVENTOS
        private void new_puesto_FormClosing(object sender, FormClosingEventArgs e)
        {
            puestos.Enabled = true;
            puestos.Visible = true;
        }
        #endregion
    }
}
