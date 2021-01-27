using System;
using System.Data;
using System.Windows.Forms;
using AliS_WinVer.Clases;
using AliSlib;
using AliSLogica.Controladores;

namespace AliS_WinVer
{
    public partial class AñadirPuesto : Form
    {
        #region PROPIEDADES
        PrincipalPuestos puestos;
        private Empresa _empresa;
        #endregion

        #region INICIO
        public AñadirPuesto(PrincipalPuestos Puestos, Empresa empresa)
        {
            InitializeComponent();
            this.puestos = Puestos;
            this._empresa = empresa;
        }

        private void AddPuesto_Load(object sender, EventArgs e)
        {
            CargarParametros();
        }

        private void CargarParametros()
        {
            DataTable tablaPuestos = ControladorEmpresa.RecuperarParametrosPorCodigoTipoParametro(1);

            AutoCompleteStringCollection asc = new AutoCompleteStringCollection();

            for (int i = 0; i < tablaPuestos.Rows.Count; i++)
            {
                asc.Add(Convert.ToString(tablaPuestos.Rows[i]["descripcion"]));
            }

            puestoBox.AutoCompleteSource = AutoCompleteSource.CustomSource;
            puestoBox.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            puestoBox.AutoCompleteCustomSource = asc;
        }
        #endregion

        #region BOTONES

        private void button1_Click(object sender, EventArgs e)
        {
            string codigo = txtCodigo.Text;
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

                    string rta = ControladorPuesto.InsertarAcualizarPuesto(_empresa.codigoEmpresa, codigo, 0, puesto, tipoPuesto, basico);

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
