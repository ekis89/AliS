using AliS_WinVer.Clases;
using AliSLogica.Controladores;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace AliS_WinVer
{
    public partial class Principal : Form
    {
        private DataTable TablaEmpresas;
        private bool activarComboEmpresa = false;
        private int lastIndex = -1;

        public Principal()
        {
            InitializeComponent();
        }

        private void ShowNewForm(object sender, EventArgs e)
        {
            PrincipalEmpresas addEmpresa = new PrincipalEmpresas(this);
            addEmpresa.MdiParent = this;

            btnConceptos.Enabled = false;
            btnPuestos.Enabled = false;
            btnLegajos.Enabled = false;
            comboEmpresas.Enabled = false;

            addEmpresa.Show();

        }

        private void ExitToolsStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ToolBarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            toolStrip.Visible = toolBarToolStripMenuItem.Checked;
        }

        private void StatusBarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            statusStrip.Visible = statusBarToolStripMenuItem.Checked;
        }

        private void CascadeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.Cascade);
        }

        private void TileVerticalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileVertical);
        }

        private void TileHorizontalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileHorizontal);
        }

        private void CloseAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form childForm in MdiChildren)
            {
                childForm.Close();
            }
        }

        private void CargarComboEmpresas()
        {
            TablaEmpresas = ControladorEmpresa.RecuperarEmpresas();

            comboEmpresas.ComboBox.DisplayMember = "nombre";
            comboEmpresas.ComboBox.ValueMember = "codigoEmpresa";
            comboEmpresas.ComboBox.DataSource = TablaEmpresas;

            comboEmpresas.SelectedIndex = -1;
        }

        public void Principal_Load(object sender, EventArgs e)
        {
            CargarComboEmpresas();

            if (comboEmpresas.ComboBox.SelectedIndex < 0)
            {
                btnPuestos.Enabled = false;
                btnConceptos.Enabled = false;
                btnLegajos.Enabled = false;
                btnEliminarEmpresa.Enabled = false;
                btnSearch.Enabled = false;
            }

        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (comboEmpresas.SelectedIndex != -1)
            {
                activarComboEmpresa = true;
                btnEliminarEmpresa.Enabled = true;

                if (activarComboEmpresa)
                {
                    int codigoEmpresa = Convert.ToInt32(comboEmpresas.ComboBox.SelectedValue);

                    DataRow row = (from r in TablaEmpresas.AsEnumerable() where r.Field<int>("codigoEmpresa") == codigoEmpresa select r).SingleOrDefault();

                    UsuarioSingleton.Instance._Empresa = new Empresa(Convert.ToInt32(row["codigoEmpresa"]), row["nombre"].ToString(), row["cuit"].ToString(), row["localidad"].ToString(), Convert.ToInt32(row["codigoPostal"]), row["direccion"].ToString(), row["telefono"].ToString());

                    btnConceptos.Enabled = true;
                    btnPuestos.Enabled = true;
                    btnLegajos.Enabled = true;

                    foreach (Form frm in Application.OpenForms)
                    {
                        if (frm.GetType() == typeof(SelectorLegajo))
                        {
                            frm.Close();
                            break;
                        }
                    }

                    btnPuestos.Enabled = true;
                    btnLegajos.Enabled = true;
                    btnConceptos.Enabled = true;

                    SelectorLegajo sl = new SelectorLegajo(UsuarioSingleton.Instance._Empresa);
                    sl.MdiParent = this;
                    sl.Show();

                }

                lastIndex = comboEmpresas.SelectedIndex;
            }
            else
            {
                btnEliminarEmpresa.Enabled = false;
                btnSearch.Enabled = false;
            }

        }

        private void btnPuestos_Click(object sender, EventArgs e)
        {
            foreach (Form frm in Application.OpenForms)
            {
                if (frm.Name == "GestionLiquidacionConceptos")
                {
                    MessageBox.Show("No se pueden gestionar puestos mientras haya liquidaciones en curso.");
                    return;
                }

            }

            PrincipalPuestos screenPuestos = new PrincipalPuestos(this, UsuarioSingleton.Instance._Empresa);
            screenPuestos.MdiParent = this;

            btnConceptos.Enabled = false;
            btnPuestos.Enabled = false;
            btnLegajos.Enabled = false;
            comboEmpresas.Enabled = false;

            screenPuestos.Show();

        }

        private void btnConceptos_Click(object sender, EventArgs e)
        {
            foreach (Form frm in Application.OpenForms)
            {
                if (frm.Name == "GestionLiquidacionConceptos")
                {
                    MessageBox.Show("No se pueden gestionar puestos mientras haya liquidaciones en curso.");
                    return;
                }

            }

            PrincipalConceptos screenConceptos = new PrincipalConceptos(this, null, UsuarioSingleton.Instance._Empresa, false);
            screenConceptos.MdiParent = this;

            btnConceptos.Enabled = false;
            btnPuestos.Enabled = false;
            btnLegajos.Enabled = false;
            comboEmpresas.Enabled = false;

            screenConceptos.Show();
        }

        private void btnLegajos_Click(object sender, EventArgs e)
        {
            foreach (Form frm in Application.OpenForms)
            {
                if (frm.Name == "GestionLiquidacionConceptos")
                {
                    MessageBox.Show("No se pueden gestionar puestos mientras haya liquidaciones en curso.");
                    return;
                }

            }

            PrincipalLegajos screenLegajos = new PrincipalLegajos(this, UsuarioSingleton.Instance._Empresa);
            screenLegajos.MdiParent = this;

            btnConceptos.Enabled = false;
            btnPuestos.Enabled = false;
            btnLegajos.Enabled = false;
            comboEmpresas.Enabled = false;

            screenLegajos.Show();
        }

        public void ActivarBotonesTS()
        {
            btnConceptos.Enabled = true;
            btnPuestos.Enabled = true;
            btnLegajos.Enabled = true;
            btnSearch.Enabled = true;
            comboEmpresas.Enabled = true;
            btnEliminarEmpresa.Enabled = true;
        }

        private void btnEliminarEmpresa_Click(object sender, EventArgs e)
        {
            int codigoEmpresa = comboEmpresas.ComboBox.SelectedIndex < 0 ? 0 :  Convert.ToInt32(comboEmpresas.ComboBox.SelectedValue);

            DataRow empresaRow = codigoEmpresa == 0 ? null : TablaEmpresas.AsEnumerable().Where(x => Convert.ToInt32(x["codigoEmpresa"]) == codigoEmpresa).First();

            if (empresaRow == null)
            {
                btnEliminarEmpresa.Enabled = false;
                return;
            }

            DialogResult confirm = MessageBox.Show("¿Esta seguro que desea borrar la siguiente empresa?:\n \n   Nombre: " + Convert.ToString(empresaRow["nombre"]) + "\n   C.U.I.T: " + Convert.ToString(empresaRow["cuit"]), "Borrar empresa:", MessageBoxButtons.YesNo);

            if (confirm == DialogResult.Yes && comboEmpresas.SelectedIndex != -1)
            {
                foreach (Form frm in this.MdiChildren)
                {
                    frm.Dispose();
                    frm.Close();
                }

                try
                {
                    string rta = "";
                    string rutaCarpetaEmpresa = string.Format("{0}{1}", UsuarioSingleton.Instance.AlisFolder, Convert.ToString(empresaRow["nombre"]));

                    btnConceptos.Enabled = false;
                    btnPuestos.Enabled = false;
                    btnLegajos.Enabled = false;
                    comboEmpresas.Enabled = false;

                    rta = ControladorEmpresa.EliminarEmpresaPorCodigoEmpresa(codigoEmpresa, rutaCarpetaEmpresa);

                    if (rta.Equals("ok"))
                    {
                        comboEmpresas.SelectedIndex = -1;
                        btnEliminarEmpresa.Enabled = false;
                        btnConceptos.Enabled = false;
                        btnPuestos.Enabled = false;
                        btnLegajos.Enabled = false;
                        comboEmpresas.Enabled = true;

                        CargarComboEmpresas();

                        MessageBox.Show("La empresa ha sido eliminada.");
                    }
                    else
                    {
                        MessageBox.Show(rta);
                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

            }
        }

        private void comboEmpresas_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboEmpresas.ComboBox.SelectedIndex != -1)
            {
                btnSearch.Enabled = true;
                btnEliminarEmpresa.Enabled = true;
            }
            else
            {
                btnSearch.Enabled = false;
            }

            btnConceptos.Enabled = false;
            btnPuestos.Enabled = false;
            btnLegajos.Enabled = false;
        }
    }
}
