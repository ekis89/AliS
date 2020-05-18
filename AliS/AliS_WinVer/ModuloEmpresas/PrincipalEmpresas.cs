using System;
using System.Windows.Forms;
using AliSlib;
using Obj;
using AliSLogica.Controladores;
using System.Data;

namespace AliS_WinVer
{
    public partial class PrincipalEmpresas : Form
    {
        #region PROPIEDADES
        Index Index;

        #endregion

        #region INICIO

        public PrincipalEmpresas(Index Index)
        {
            InitializeComponent();
            this.Index = Index;

            this.Index.Enabled = false;

        }

        private void add_empr_Load(object sender, EventArgs e)
        {

        }
        #endregion

        #region ACCIONES
        //Boton para agregar.
        public void Aceptar_Click(object sender, EventArgs e)
        {
            string nombreEmpresa = nombreInput.Text;
            string cuitEmpresa = string.Format("{0}-{1}-{2}", CUIT1.Text, CUIT2.Text, CUIT3.Text);
            string localidadEmpresa = localidadInput.Text;
            string postalEmpresa = postalInput.Text;
            string direccionEmpresa = direccionInput.Text;
            string telefonoEmpresa = telefonoInput.Text;

            if (nombreEmpresa.Length == 0 || nombreEmpresa == " " || cuitEmpresa.Length == 0 || cuitEmpresa == " " || localidadEmpresa.Length == 0 || localidadEmpresa == " " || postalEmpresa.Length == 0 || postalEmpresa == " " || direccionEmpresa.Length == 0 || direccionEmpresa == " ")
            {
                MessageBox.Show("Asegurese de que todos los campos esten llenos.\nEl teléfono es opcional");
            }
            else
            {
                if (telefonoEmpresa.Length == 0 || telefonoEmpresa == " ")
                {
                    telefonoEmpresa = "---------------";
                }

                try
                {
                    string rta = ControladorEmpresa.InsertarActualizarEmpresa(0, UsuarioSingleton.UppercaseFirst(nombreEmpresa), cuitEmpresa, UsuarioSingleton.UppercaseFirst(localidadEmpresa),
                        Convert.ToInt32(postalEmpresa), UsuarioSingleton.UppercaseFirst(direccionEmpresa), telefonoEmpresa);

                    switch (rta)
                    {
                        case "ok":
                            MessageBox.Show("¡Empresa creada con exito!");

                            Index.Index_Load(null, EventArgs.Empty);
                            this.Close();

                            break;
                        default:
                            MessageBox.Show(rta);
                            break;
                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        //Boton cancelar.
        private void Cancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion

        #region EVENTOS
        private void add_empr_FormClosing(object sender, FormClosingEventArgs e)
        {
            Index.Enabled = true;
            Index.Focus();
        }

        private void textBox7_KeyPress(object sender, KeyPressEventArgs e)
        {
            UsuarioSingleton.SoloNumeros(e);
        }

        private void textBox6_KeyPress(object sender, KeyPressEventArgs e)
        {
            UsuarioSingleton.SoloNumeros(e);
        }

        private void CUIT1_KeyPress(object sender, KeyPressEventArgs e)
        {
            UsuarioSingleton.SoloNumeros(e);
        }

        private void CUIT2_KeyPress(object sender, KeyPressEventArgs e)
        {
            UsuarioSingleton.SoloNumeros(e);
        }

        private void CUIT3_KeyPress(object sender, KeyPressEventArgs e)
        {
            UsuarioSingleton.SoloNumeros(e);
        }

        #endregion

    }
   
}
