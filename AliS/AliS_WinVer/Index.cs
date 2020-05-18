using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using System.Linq;
using System.IO;
using AliSlib;
using AliSLogica;
using AliSLogica.Controladores;

namespace AliS_WinVer
{
    public partial class Index : Form
    {
        #region PROPIEDADES
        DataTable TablaEmpresas;
        GestionLiquidacionConceptos screenLiquidar;

        bool activarComboEmpresa = false;
        #endregion

        #region INICIO

        public Index()
        {
            InitializeComponent();
        }



        public void Index_Load(object sender, EventArgs e)
        {
            TablaEmpresas = ControladorEmpresa.RecuperarEmpresas();

            comboEmpresas.DisplayMember = "nombre";
            comboEmpresas.ValueMember = "codigoEmpresa";
            comboEmpresas.DataSource = TablaEmpresas;

            comboEmpresas.SelectedIndex = -1;

        }

        #endregion

        #region AGREGAR ELIMINAR EMPRESA

        private void nuevaEmpresaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PrincipalEmpresas addEmpresa = new PrincipalEmpresas(this);
            addEmpresa.Show();
        }

        private void deleteEmpresaButton_Click(object sender, EventArgs e)
        {
            DialogResult confirm = MessageBox.Show("¿Esta seguro que desea borrar la siguiente empresa?:\n \n   Nombre: " + UsuarioSingleton.Instance.NombreEmpresa + "\n   C.U.I.T: " + UsuarioSingleton.Instance.CuitEmpresa, "Borrar empresa:", MessageBoxButtons.YesNo);

            if (confirm == DialogResult.Yes)
            {
                try
                {
                    string empresaFolder = string.Format("{0}/{1}", UsuarioSingleton.Instance.AlisFolder, UsuarioSingleton.Instance.NombreEmpresa);

                    ControladorIndex.EliminarEmpresa(empresaFolder, UsuarioSingleton.Instance.CuitEmpresa, UsuarioSingleton.Instance.NombreEmpresa);

                    MessageBox.Show("La empresa ha sido eliminada.");

                    Index_Load(null, EventArgs.Empty);

                    //if (treeViewEmpresas.Nodes.Count < 1)
                    //{
                        liquidacionesButton.Enabled = false;
                        //empresaNombreInfo.Enabled = false;
                        //empresaNombreInfo.Text = "No hay empresas";
                        groupBox1.Enabled = false;
                        groupBox2.Enabled = false;
                        cantidadLabel.Enabled = false;

                        cuitInfo.Text = "- - - - - - - - - -";
                        cuitInfo.Enabled = false;
                        localidadInfo.Text = "- - - - - - - - - -";
                        localidadInfo.Enabled = false;
                        direccionInfo.Text = "- - - - - - - - - -";
                        direccionInfo.Enabled = false;
                        telefonoInfo.Text = "- - - - - - - - - -";
                        telefonoInfo.Enabled = false;
                        postalInfo.Text = "- - - - - - - - - -";
                        postalInfo.Enabled = false;

                        leg_number.Enabled = false;
                        deleteEmpresaButton.Enabled = false;
                    //}
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

            }
        }
        #endregion

        #region BOTONES EMPRESA SELECCIONADA
        //Abre screen puestos.
        private void puestosButton_Click(object sender, EventArgs e)
        {
            PrincipalPuestos screenPuestos = new PrincipalPuestos(this);

            this.Enabled = false;
            this.Visible = false;

            screenPuestos.Show();

        }

        //Abre screen legajos.
        private void legajosButton_Click(object sender, EventArgs e)
        {
            int TVindex = 0;
            PrincipalLegajos screenLegajos = new PrincipalLegajos(this, TVindex);

            this.Enabled = false;
            this.Visible = false;

            screenLegajos.Show();
        }

        //Abre screen conceptos.
        private void conceptosButton_Click(object sender, EventArgs e)
        {
            PrincipalConceptos screenConceptos = new PrincipalConceptos(this, screenLiquidar, false);

            this.Enabled = false;
            this.Visible = false;

            screenConceptos.Show();
        }

        //Abre el editor de recibos.
        private void liquidacionesButton_Click(object sender, EventArgs e)
        {
            PrincipalLiquidaciones ScreenEmpl = new PrincipalLiquidaciones(this);
            this.Visible = false;
            ScreenEmpl.Show();
        }
        #endregion

        #region SVG
        //Dibuja una linea en el medio de la ventana para separar el dataGridView de la INFO.
        private void Index_Paint(object sender, PaintEventArgs e)
        {
            //Graphics l = e.Graphics;

            //Pen p = new Pen(Color.LightGray, 1);
            //l.DrawLine(p, 250, 30, 250, 445);
            //l.Dispose();
        }

        #endregion

        #region EVENTOS
        private void comboEmpresas_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (comboEmpresas.SelectedIndex != -1)
            {
                if (activarComboEmpresa)
                {
                    int codigoEmpresa = Convert.ToInt32(comboEmpresas.SelectedValue);
                    int cantidadLegajos = ControladorEmpresa.RecuperarCantidadLegajos(codigoEmpresa);

                    DataRow row = (from r in TablaEmpresas.AsEnumerable() where r.Field<int>("codigoEmpresa") == codigoEmpresa select r).SingleOrDefault();

                    UsuarioSingleton.Instance.codigoEmpresa = Convert.ToInt32(row["codigoEmpresa"]);
                    UsuarioSingleton.Instance.NombreEmpresa = row["nombre"].ToString();
                    UsuarioSingleton.Instance.CuitEmpresa = row["cuit"].ToString();
                    UsuarioSingleton.Instance.LocalidadEmpresa = row["localidad"].ToString();
                    UsuarioSingleton.Instance.DireccionEmpresa = row["direccion"].ToString();
                    UsuarioSingleton.Instance.TelefonoEmpresa = row["telefono"].ToString();
                    UsuarioSingleton.Instance.PostalEmpresa = Convert.ToInt32(row["codigoPostal"]);

                    if (cantidadLegajos > 0)
                        liquidacionesButton.Enabled = true;
                    else
                        liquidacionesButton.Enabled = false;

                    groupBox1.Enabled = true;
                    groupBox2.Enabled = true;
                    cantidadLabel.Enabled = true;
                    leg_number.Enabled = true;
                    deleteEmpresaButton.Enabled = true;

                    label2.Enabled = true;
                    label4.Enabled = true;
                    label5.Enabled = true;
                    label6.Enabled = true;
                    label14.Enabled = true;

                    cuitInfo.Enabled = true;
                    localidadInfo.Enabled = true;
                    direccionInfo.Enabled = true;
                    telefonoInfo.Enabled = true;
                    postalInfo.Enabled = true;

                    cuitInfo.Text = UsuarioSingleton.Instance.CuitEmpresa;
                    localidadInfo.Text = UsuarioSingleton.Instance.LocalidadEmpresa;
                    direccionInfo.Text = UsuarioSingleton.Instance.DireccionEmpresa;
                    telefonoInfo.Text = UsuarioSingleton.Instance.TelefonoEmpresa;
                    postalInfo.Text = Convert.ToString(UsuarioSingleton.Instance.PostalEmpresa);
                    leg_number.Text = Convert.ToString(cantidadLegajos);
                }
            }
            else
            {
                liquidacionesButton.Enabled = false;
                groupBox1.Enabled = false;
                groupBox2.Enabled = false;
                cantidadLabel.Enabled = false;
                leg_number.Enabled = false;
                deleteEmpresaButton.Enabled = false;

                cuitInfo.Text = "- - - - - - - - - -";
                localidadInfo.Text = "- - - - - - - - - -";
                direccionInfo.Text = "- - - - - - - - - -";
                telefonoInfo.Text = "- - - - - - - - - -";
                postalInfo.Text = "- - - - - - - - - -";
            }

            activarComboEmpresa = true;
        }

        private void backupToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Coming soon");
        }

        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion
    }
}
