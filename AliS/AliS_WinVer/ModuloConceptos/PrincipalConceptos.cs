using System;
using System.Data;
using System.Windows.Forms;
using AliSlib;
using AliSLogica.Controladores;
using AliSLogica.Complementarios;
using System.Text;
using AliS_WinVer.Clases;
using System.Collections.Generic;

namespace AliS_WinVer
{
    public partial class PrincipalConceptos : Form
    {
        #region PROPIEDADES
        private Form Index;
        private GestionLiquidacionConceptos ScreenLiquidar;
        public DataTable tablaConceptos;
        public bool isDeduccion;
        private bool IsModoEditar;

        private Empresa _empresa;

        #endregion

        #region INICIO
        public PrincipalConceptos(Principal Index, GestionLiquidacionConceptos Liquidar_scrn, Empresa empresa, bool isModoEditar)
        {
            InitializeComponent();
            this.Index = Index;
            this.IsModoEditar = isModoEditar;
            this.ScreenLiquidar = Liquidar_scrn;
            this._empresa = empresa;
        }

        public void conceptos_Load(object sender, EventArgs e)
        {
            this.Text = string.Format("{0}: Conceptos", _empresa.NombreEmpresa);

            tablaConceptos = ControladorConcepto.RecuperarConceptosPorCodigoEmpresa(_empresa.codigoEmpresa);

            CargarTablaConceptos();

        }
        #endregion

        #region BOTONES
        private void button1_Click(object sender, EventArgs e)
        {
            AñadirConcepto añadirConcepto = new AñadirConcepto(this, _empresa);
            this.Visible = false;
            añadirConcepto.Show();
        }

        //Elimina concepto.
        private void button3_Click(object sender, EventArgs e)
        {
            string verificarConcepto;
            string nombreEmpresa = _empresa.NombreEmpresa.Replace(" ", "");

            int codigoConceptoPorEmpresa = Convert.ToInt32(dgvConceptos.CurrentRow.Cells[0].Value);
            string codigo = Convert.ToString(dgvConceptos.CurrentRow.Cells[1].Value);
            string descripcion = Convert.ToString(dgvConceptos.CurrentRow.Cells[2].Value);

            string mensaje = String.Format("¿Esta seguro que desea eliminar el siguiente concepto?\n \n Código: {0}\n Descripción: {1}", codigo, descripcion);

            DialogResult result = MessageBox.Show(mensaje, "Eliminar concepto", MessageBoxButtons.YesNo);

            if (result == DialogResult.Yes)
            {

                try
                {
                    verificarConcepto = VerificarConceptoAsigando(codigoConceptoPorEmpresa, codigo);

                    if (verificarConcepto == "ok")
                    {
                        ControladorConcepto.EliminarConceptoPorEmpresa(codigoConceptoPorEmpresa);

                        this.conceptos_Load(null, EventArgs.Empty);
                    }
                    else
                    {
                        MessageBox.Show(verificarConcepto);
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
            this.Visible = false;

            EditarConcepto editarConcepto = new EditarConcepto(this, _empresa, IsModoEditar);
            editarConcepto.Show();
        }
        #endregion

        #region METODOS
        private string VerificarConceptoAsigando(int codigoConceptoPorEmpresa, string codigo)
        {
            List<string> listaConceptos = new List<string>();
            List<string> listaLegajos = new List<string>();
            StringBuilder sb = new StringBuilder();

            try
            {
                DataTable tablaLegajos = ControladorPersona.RecuperarPersonasPorEmpresa(_empresa.codigoEmpresa);
                DataTable tablaConceptos = ControladorConcepto.RecuperarConceptosPorCodigoEmpresa(_empresa.codigoEmpresa);

                foreach (DataRow row in tablaConceptos.Rows)
                {
                    if(Convert.ToString(row["hab_fijo"]).Contains("|" + codigo + "|") || Convert.ToString(row["ded_fijo"]).Contains("|" + codigo + "|") || Convert.ToString(row["formula_porc"]).Contains("|" + codigoConceptoPorEmpresa + "|"))
                    {
                        listaConceptos.Add(String.Format("Cod: {0} - {1}", Convert.ToString(row["codigo"]), Convert.ToString(row["descripcion"])));
                    }
                }

                foreach (DataRow row in tablaLegajos.Rows)
                {
                    if (Convert.ToString(row["conceptos"]).Contains("|" + codigoConceptoPorEmpresa + "|"))
                    {
                        listaLegajos.Add(String.Format("Nro: {0} - {1} {2}", Convert.ToString(row["numeroLegajo"]), Convert.ToString(row["nombre"]), Convert.ToString(row["apellido"])));
                    }
                }

                if( (listaConceptos.Count > 0) || (listaLegajos.Count > 0))
                {
                    sb.Append("El concepto no se puede eliminar ya que está asociado a la formula de otro concepto o asociado a un legajo:\n");

                    for (int i = 0; i < listaConceptos.Count; i++)
                    {
                        if (i == 0) sb.Append("\n*** CONCEPTOS: \n");

                        sb.Append("- " + listaConceptos[i] + "\n");
                    }

                    for (int i = 0; i < listaLegajos.Count; i++)
                    {
                        if (i == 0) sb.Append("\n*** LEGAJOS: \n");

                        sb.Append("- " + listaLegajos[i] + "\n");
                    }

                    return sb.ToString();
                }
                else
                {
                    return "ok";
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        private void CargarTablaConceptos()
        {
            dgvConceptos.DataSource = tablaConceptos;

            dgvConceptos.Columns[1].Width = 70;
            dgvConceptos.Columns[2].Width = 250;
            dgvConceptos.Columns[3].Width = 95;
            dgvConceptos.Columns[4].Width = 95;
            dgvConceptos.Columns[5].Width = 95;
            dgvConceptos.Columns[6].Width = 95;
            dgvConceptos.Columns[7].Width = 72;

            dgvConceptos.Columns[1].HeaderText = "Código";
            dgvConceptos.Columns[2].HeaderText = "Descripción";
            dgvConceptos.Columns[3].HeaderText = "Fijo($)";
            dgvConceptos.Columns[4].HeaderText = "Porcentaje(%)";
            dgvConceptos.Columns[5].HeaderText = "Fijo($)";
            dgvConceptos.Columns[6].HeaderText = "Porcentaje(%)";
            dgvConceptos.Columns[7].HeaderText = "Tipo";

            dgvConceptos.Columns[0].Visible = false;
            dgvConceptos.Columns[8].Visible = false;
            dgvConceptos.Columns[9].Visible = false;

            for (int i = 2; i < 7; i++)
            {
                dgvConceptos.Columns[i].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;

                if (i >= 2)
                {
                    dgvConceptos.Columns[i].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                }
            }
        }

        #endregion

        #region EVENTOS
        private void conceptos_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!IsModoEditar)
            {
                Index.Enabled = true;
                Index.Visible = true;

                if (Index.GetType() == typeof(Principal))
                    (this.MdiParent as Principal).ActivarBotonesTS();
            }
            else
            {
                ManejoDeRecibo.CalcularTabla(ScreenLiquidar.dtXML);

                ManejoDeRecibo.DrawTabla(ScreenLiquidar.dtXML, ScreenLiquidar.dgvDetalles, true);

                ManejoDeRecibo.CalcularTotales(ScreenLiquidar.dtXML, ScreenLiquidar.dgvDetalles, ScreenLiquidar.lblRemInfo, ScreenLiquidar.lblNoRemInfo, ScreenLiquidar.lblDeduccionesInfo, ScreenLiquidar.lblNetoInfo);

                ScreenLiquidar.Visible = true;
            }
        }
        #endregion
    }
}

//TODO:: Cuando elimino un concepto no esta verificando que no este usando como formula en otro concepto, revisar procedure [EliminarConceptoPorEmpresa], Hecho pero revisar con mas ganas el lunes xD
