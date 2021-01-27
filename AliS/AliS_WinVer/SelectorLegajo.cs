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
    public partial class SelectorLegajo : Form
    {
        private Empresa _empresa;
        private List<Legajo> _listaLegajo = new List<Legajo>();

        public SelectorLegajo(Empresa empresa)
        {
            InitializeComponent();

            this.Text = String.Format("{0} | Cuit: {1} | {2} - {3} - {4} | Tel: {5}", UsuarioSingleton.Instance._Empresa.NombreEmpresa, UsuarioSingleton.Instance._Empresa.CuitEmpresa, UsuarioSingleton.Instance._Empresa.DireccionEmpresa, UsuarioSingleton.Instance._Empresa.LocalidadEmpresa, UsuarioSingleton.Instance._Empresa.PostalEmpresa, UsuarioSingleton.Instance._Empresa.TelefonoEmpresa);

            this._empresa = empresa;
        }

        private void SelectorLegajo_Load(object sender, EventArgs e)
        {
            CargarLegajos();

            if (dgvLegajos.Rows.Count < 1)
                btnLiquidaciones.Enabled = false;
        }

        public void CargarLegajos()
        {
            DataTable tablaLegajos = ControladorPersona.RecuperarPersonasPorEmpresa(UsuarioSingleton.Instance._Empresa.codigoEmpresa);

            DataTable tablaFinal = new DataTable();
            tablaFinal.Columns.Add("numeroLegajo");
            tablaFinal.Columns.Add("nombre");
            tablaFinal.Columns.Add("cuil");
            tablaFinal.Columns.Add("fechaIngreso");
            tablaFinal.Columns.Add("codigoDescripcionPuesto");
            tablaFinal.Columns.Add("puesto");
            tablaFinal.Columns.Add("convenio");
            tablaFinal.Columns.Add("banco");

            _listaLegajo.Clear();

            foreach (DataRow row in tablaLegajos.Rows)
            {
                Legajo l = new Legajo(Convert.ToInt32(row["codigoPersonaPorEmpresa"]), Convert.ToString(row["nombre"]) + " " + Convert.ToString(row["apellido"]), Convert.ToString(row["cuil"]), Convert.ToString(row["descripcionPuesto"]), Convert.ToDateTime(row["fechaIngreso"]).ToString("dd/MM/yyyy"), Convert.ToString(row["numeroLegajo"]), Convert.ToString(row["banco"]), Convert.ToString(row["convenio"]), Convert.ToString(row["tipoPuesto"]));

                _listaLegajo.Add(l);

                DataRow r = tablaFinal.NewRow();
                r["numeroLegajo"] = l.NumeroLegajo; ;
                r["nombre"] = l.NombreEmpleado;
                r["cuil"] = l.EmpleadoCUIL;
                r["fechaIngreso"] = l.FechaIngreso;
                r["codigoDescripcionPuesto"] = Convert.ToString(row["codigoDescripcionPuesto"]);
                r["puesto"] = l.PuestoRecibo;
                r["convenio"] = l.Convenio;
                r["banco"] = l.Banco;

                tablaFinal.Rows.Add(r);
            }

            dgvLegajos.DataSource = tablaFinal;
            dgvLegajos.Columns[0].Width = 60;
            dgvLegajos.Columns[0].HeaderText = "Nro. Legajo";
            dgvLegajos.Columns[1].HeaderText = "Nombre y Apellido";
            dgvLegajos.Columns[2].HeaderText = "Cuil";
            dgvLegajos.Columns[3].HeaderText = "Fecha de Ingreso";
            dgvLegajos.Columns[4].HeaderText = "cod. Puesto";
            dgvLegajos.Columns[5].HeaderText = "Puesto";
            dgvLegajos.Columns[6].HeaderText = "Convenio";
            dgvLegajos.Columns[7].HeaderText = "Banco";

        }

        private void btnLiquidaciones_Click(object sender, EventArgs e)
        {
            string numeroLegajo = Convert.ToString(dgvLegajos.CurrentRow.Cells[0].Value);

            Legajo l = _listaLegajo.AsEnumerable().Where(x => x.NumeroLegajo == numeroLegajo).First();

            foreach (Form frm in Application.OpenForms)
            {
                if (frm.Name == "PrincipalLiquidaciones")
                {
                    int codigoPersona = (frm as PrincipalLiquidaciones)._legajo.codigoPersona;

                    if (codigoPersona == l.codigoPersona)
                        return;
                }

            }

            PrincipalLiquidaciones ScreenEmpl = new PrincipalLiquidaciones(this, _empresa, l);
            ScreenEmpl.MdiParent = this.MdiParent;
            ScreenEmpl.Show();

            (this.MdiParent as Principal).comboEmpresas.Enabled = false;
            (this.MdiParent as Principal).btnSearch.Enabled = false;
            (this.MdiParent as Principal).btnEliminarEmpresa.Enabled = false;


        }

        private void SelectorLegajo_Enter(object sender, EventArgs e)
        {
            (this.MdiParent as Principal).comboEmpresas.ComboBox.SelectedValue = _empresa.codigoEmpresa;
            UsuarioSingleton.Instance._Empresa = _empresa.Clone() as Empresa;
        }

        private void SelectorLegajo_FormClosing(object sender, FormClosingEventArgs e)
        {

            foreach (Form frm in Application.OpenForms)
            {
                if (frm.GetType() == typeof(PrincipalLiquidaciones))
                {
                    MessageBox.Show("No se puede cerrar mientras haya liquidaciones gestionandose.");
                    e.Cancel = true;
                    return;
                }

            }

            (this.MdiParent as Principal).comboEmpresas.Enabled = true;
            (this.MdiParent as Principal).btnConceptos.Enabled = false;
            (this.MdiParent as Principal).btnLegajos.Enabled = false;
            (this.MdiParent as Principal).btnPuestos.Enabled = false;
            (this.MdiParent as Principal).btnSearch.Enabled = true;
        }

        private void dgvLegajos_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            btnLiquidaciones.Enabled = true;
        }
    }
}
