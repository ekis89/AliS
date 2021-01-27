using System;
using System.Collections.Generic;
using System.Data;
using System.Xml;
using System.Windows.Forms;
using AliSlib;
using AliSLogica.Controladores;
using AliSLogica.Complementarios;
using System.Linq;
using System.Drawing;
using AliS_WinVer.Clases;
using System.Text;

namespace AliS_WinVer
{
    public partial class GestionLiquidacionConceptos : Form
    {
        public DataTable dtXML;

        private bool saveBtn = false;
        public DataTable dtDgvDetalles;

        private PrincipalLiquidaciones screenReciboBuilder;
        private XmlDocument docXML;

        private bool isSalarioMensual;
        private bool isEditMode;

        private string añoSelected;
        private string mesSelected;
        private string quincenaSelected;

        private Empresa _empresa;
        private Legajo _legajo;

        // SEGUIR DESDE ACA, BORRAR EL NODO DEL MES DEL XML CUANDO SE APRETA EN EL BOTON CANCELAR (en el caso de que sea liquidar y no editar)
        #region INICIO
        public GestionLiquidacionConceptos(PrincipalLiquidaciones screenReciboBuilder, Empresa empresa, Legajo legajo, bool isEditMode)
        {
            InitializeComponent();

            this.screenReciboBuilder = screenReciboBuilder;
            this.docXML = screenReciboBuilder.XMLDocumento;
            this.isSalarioMensual = screenReciboBuilder.isSalarioMensual;

            this._empresa = empresa;
            this._legajo = legajo;

            this.añoSelected = Convert.ToString(screenReciboBuilder.cboAño.SelectedItem);
            this.mesSelected = Convert.ToString(screenReciboBuilder.cboMes.SelectedItem);
            this.quincenaSelected = Convert.ToString(screenReciboBuilder.cboQuincena.SelectedItem);

            this.isEditMode = isEditMode;

            this.dtDgvDetalles = new DataTable();

        }
        public void Liquidar_Load(object sender, EventArgs e)
        {
            try
            {
                if (!isEditMode)
                {
                    IniciarLiquidacion();
                    DibujarTablaLiquidar();

                    ManejoDeRecibo.CalcularTabla(dtDgvDetalles);
                    ManejoDeRecibo.CalcularTotales(dtDgvDetalles, dgvDetalles, lblRemInfo, lblNoRemInfo, lblDeduccionesInfo, lblNetoInfo);

                    ModificarCeldasHaberDeduccion();

                    dgvDetalles.ClearSelection();
                }
                else
                {
                    this.Text = "Editar liquidación";

                    btnAgregar.Visible = false;
                    btnEditar.Visible = false;
                    btnQuitar.Visible = false;

                    herramientasToolStripMenuItem.Visible = false;
                    liquidaciónToolStripMenuItem.Visible = true;

                    dtXML = screenReciboBuilder.dtXML.Copy();

                    dtpFechaDeposito.Value = Convert.ToDateTime(screenReciboBuilder.lblFechaDepositoInfo.Text);
                    dtpFechaLiquidacion.Value = Convert.ToDateTime(screenReciboBuilder.lblFechaLiquidacionInfo.Text);

                    DibujarTablaLiquidar();

                    ManejoDeRecibo.CalcularTabla(dtDgvDetalles);
                    ManejoDeRecibo.CalcularTotales(dtDgvDetalles, dgvDetalles, lblRemInfo, lblNoRemInfo, lblDeduccionesInfo, lblNetoInfo);

                    ModificarCeldasHaberDeduccion();

                    dgvDetalles.ClearSelection();

                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
        #endregion

        #region EVENTOS
        private void Liquidar_FormClosing(object sender, FormClosingEventArgs e)
        {

            if (!saveBtn)
            {
                //if (e.CloseReason == CloseReason.UserClosing)
                //{
                //MessageBox.Show(saveBtn.ToString());
                //}
            }

            if (!isEditMode)
            {
                if (isSalarioMensual)
                {

                }
                else
                {

                }
            }

            screenReciboBuilder.Enabled = true;
            screenReciboBuilder.Focus();
        }
        #endregion

        #region BOTONES
        public void btnAgregar_Click(object sender , EventArgs e)
        {
            
            LiquidacionesPrincipalConceptos liquidacionesPrincipalConceptos = new LiquidacionesPrincipalConceptos(this, _empresa);

            this.Visible = false;
            liquidacionesPrincipalConceptos.Show();
        }
        public void Edit_con_Click(object sender, EventArgs e)
        {
            //PrincipalConceptos con_scrn = new PrincipalConceptos(Index, this, true);

            //this.Visible = false;
            //con_scrn.Show();
        }
        private void btnQuitar_Click(object sender, EventArgs e)
        {
            DataRowView drv = dgvDetalles.CurrentRow.DataBoundItem as DataRowView;
            DataRow dr = drv.Row;

            try
            {
                DataRow row = dtXML.AsEnumerable().Where(x => Convert.ToString(x.Field<object>("codigoConceptoPorEmpresa")) == dr.Field<string>("codigoConceptoPorEmpresa")).First();

                if (Convert.ToString(dr["tipo"]) != "BAS")
                {
                    DialogResult confirm = MessageBox.Show("¿Esta seguro que desea quitar el siguiente concepto?:\n \n" + Convert.ToString(dr["descripcion"]), "Quitar concepto:", MessageBoxButtons.YesNo);

                    if (confirm == DialogResult.Yes)
                    {
                        EliminarConcepto(row, dr);
                    }
                }
                else
                {
                    MessageBox.Show("Los conceptos de tipo \"Básico\" no pueden ser eliminados");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
        private void btnBajar_Click(object sender, EventArgs e)
        {
            bool isSelected = dgvDetalles.SelectedCells[0].OwningRow.Selected;

            if (isSelected)
            {
                // Lo hice asi porque con CurrentRow si bajo mas de una vez no acutaliza el index(queda con el index anterior).
                int rowIndex = dgvDetalles.SelectedCells[0].OwningRow.Index; 
                int SearchedCode = Convert.ToInt32(dgvDetalles.Rows[rowIndex].Cells[12].Value);
                
                DataRow searchRow = dtDgvDetalles.AsEnumerable().Where(x => Convert.ToInt32(x["codigoConceptoPorEmpresa"]) == SearchedCode).First();
                DataRow row = dtDgvDetalles.NewRow();

                row.ItemArray = searchRow.ItemArray.Clone() as object[];

                if (rowIndex < dgvDetalles.Rows.Count - 1)
                {
                    dtDgvDetalles.Rows.RemoveAt(rowIndex);
                    dtDgvDetalles.Rows.InsertAt(row, rowIndex + 1);

                    dgvDetalles.Rows[rowIndex + 1].Selected = true;
                    dgvDetalles.Rows[rowIndex + 1].Cells[9].Value = row[9];
                }

                SetColorTable(dtDgvDetalles, dgvDetalles);
                ModificarCeldasHaberDeduccion();
            }
        }
        private void btnSubir_Click(object sender, EventArgs e)
        {
            bool isSelected = dgvDetalles.SelectedCells[0].OwningRow.Selected;

            if (isSelected)
            {
                // Lo hice asi porque con CurrentRow si bajo mas de una vez no acutaliza el index(queda con el index anterior).
                int rowIndex = dgvDetalles.SelectedCells[0].OwningRow.Index;
                int SearchedCode = Convert.ToInt32(dgvDetalles.Rows[rowIndex].Cells[12].Value);

                DataRow searchRow = dtDgvDetalles.AsEnumerable().Where(x => Convert.ToInt32(x["codigoConceptoPorEmpresa"]) == SearchedCode).First();
                DataRow row = dtDgvDetalles.NewRow();

                row.ItemArray = searchRow.ItemArray.Clone() as object[];

                if (rowIndex > 0)
                {
                    dtDgvDetalles.Rows.RemoveAt(rowIndex);
                    dtDgvDetalles.Rows.InsertAt(row, rowIndex - 1);

                    dgvDetalles.Rows[rowIndex - 1].Selected = true;
                    dgvDetalles.Rows[rowIndex - 1].Cells[9].Value = row[9];
                }

                SetColorTable(dtDgvDetalles, dgvDetalles);
                ModificarCeldasHaberDeduccion();
            }

        }
        private void BtnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                string curFile = _legajo.CurrentUserXmlFolder + añoSelected + ".xml";
                double haberRemunerativo = Convert.ToDouble(lblRemInfo.Text.Replace("$", ""));
                double haberNoRemunerativo = Convert.ToDouble(lblNoRemInfo.Text.Replace("$", ""));
                double haberDeducciones = Convert.ToDouble(lblDeduccionesInfo.Text.Replace("$", ""));
                double saldoNeto = (haberRemunerativo + haberNoRemunerativo) - haberDeducciones;

                string fechaLiquidacion = dtpFechaLiquidacion.Text;
                string fechaDeposito = dtpFechaDeposito.Text;

                DataTable tablaOrdenada = DataGridViewADataTableOrdenada();

                ManejoXML.GuardarXML(screenReciboBuilder.XMLDocumento, tablaOrdenada, _legajo.PuestoRecibo, _legajo.Banco, _legajo.Convenio, fechaLiquidacion, fechaDeposito, mesSelected, curFile, saldoNeto, isSalarioMensual, screenReciboBuilder.cboQuincena.Text, isEditMode);

                saveBtn = true;
                Close();

                ManejoDeRecibo.CalcularTabla(tablaOrdenada);
                ManejoDeRecibo.DrawTabla(tablaOrdenada, screenReciboBuilder.dgvDetallesRecibo, true);
                ManejoDeRecibo.CalcularTotales(tablaOrdenada, screenReciboBuilder.dgvDetallesRecibo, screenReciboBuilder.lblHaberesRemInfo, screenReciboBuilder.lblHaberesNoRemInfo, screenReciboBuilder.lblDeduccionInfo, screenReciboBuilder.lblNetoInfo);

                if (isSalarioMensual)
                {
                    screenReciboBuilder.cboMes_SelectedIndexChanged(null, EventArgs.Empty);
                }
                else
                {
                    screenReciboBuilder.cboQuincena_SelectedIndexChanged(null, EventArgs.Empty);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            //cancelBtn = true;
            screenReciboBuilder.XMLDocumento = docXML;
            Close();
        }
        private void mnubtnCalculadoraSAC_Click(object sender, EventArgs e)
        {
            if (docXML.ChildNodes[0].ChildNodes.Count < 2)
            {
                MessageBox.Show("No se puede iniciar calculadora SAC: archivo XML vacio o corrupto.");
            }
            else
            {
                CalculadoraSAC screenSAC = new CalculadoraSAC(screenReciboBuilder.XMLDocumento, this, isSalarioMensual);
                screenSAC.Show();
            }

        }
        private void mnubtnEliminarLiquidación_Click(object sender, EventArgs e)
        {
            DialogResult confirm = MessageBox.Show("¿Esta seguro que desea eliminar esta liquidación? ", "Quitar concepto:", MessageBoxButtons.YesNo);

            try
            {
                if (confirm == DialogResult.Yes)
                {
                    string curFile = _legajo.CurrentUserXmlFolder + añoSelected + ".xml";

                    ManejoXML.EliminarLiquidacion(screenReciboBuilder.XMLDocumento, curFile, mesSelected, quincenaSelected, isSalarioMensual);

                    if (isSalarioMensual)
                    {
                        screenReciboBuilder.cboMes_SelectedIndexChanged(null, EventArgs.Empty);
                    }
                    else
                    {
                        screenReciboBuilder.cboQuincena_SelectedIndexChanged(null, EventArgs.Empty);
                    }

                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                   
            }

        }
        private void dgvDetalles_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            btnBajar.Enabled = true;
            btnSubir.Enabled = true;
            btnAgregar.Enabled = true;
            btnQuitar.Enabled = true;

        }
        private void dgvDetalles_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var senderGrid = (DataGridView)sender;

            if (senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn &&
                e.RowIndex >= 0)
            {
                ModificarUnidades();
            }

        }
        #endregion

        #region METODOS
        private void IniciarLiquidacion()
        {
            string fechaLiquidacion = ManejoDeRecibo.GenerarFechaLiquidacion(mesSelected, quincenaSelected, añoSelected, isSalarioMensual);

            try
            {
                var confirmResult = MessageBox.Show("¿Desea generar la liquidación en base al recibo de sueldo del mes anterior?", "Generación de liquidación", MessageBoxButtons.YesNo);

                if (confirmResult == DialogResult.Yes)
                {
                    dtXML = ManejoDeRecibo.Liquidar(UsuarioSingleton.Instance.UserFolder, _empresa.codigoEmpresa, _legajo.NumeroLegajo, screenReciboBuilder.XMLDocumento, isSalarioMensual, _empresa.CuitEmpresa, añoSelected, mesSelected, quincenaSelected, _legajo.EmpleadoCUIL, _empresa.NombreEmpresa, false);
                }
                else
                {
                    dtXML = ManejoDeRecibo.Liquidar(UsuarioSingleton.Instance.UserFolder, _empresa.codigoEmpresa, _legajo.NumeroLegajo, screenReciboBuilder.XMLDocumento, isSalarioMensual, _empresa.CuitEmpresa, añoSelected, mesSelected, quincenaSelected, _legajo.EmpleadoCUIL, _empresa.NombreEmpresa, true);
                }

                dtpFechaLiquidacion.Value = DateTime.Parse(fechaLiquidacion);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        public void DibujarTablaLiquidar()
        {

            dgvDetalles.DataSource = new DataTable();
            dgvDetalles.Columns.Clear();

            if (dgvDetalles.Rows.Count > 0)
            {
                dgvDetalles.Rows.Clear();
            }


            DataGridViewButtonColumn dgvbtnUnidades = new DataGridViewButtonColumn();
            dgvbtnUnidades.HeaderText = "Unidades";

            if (dtDgvDetalles.Columns.Count < 1)
            {
                dtDgvDetalles.Columns.Add("codigo", typeof(string));
                dtDgvDetalles.Columns.Add("descripcion", typeof(string));
                dtDgvDetalles.Columns.Add("hab_fijo", typeof(string));
                dtDgvDetalles.Columns.Add("hab_porc", typeof(string));
                dtDgvDetalles.Columns.Add("ded_fijo", typeof(string));
                dtDgvDetalles.Columns.Add("ded_porc", typeof(string));
                dtDgvDetalles.Columns.Add("tipo", typeof(string));
                dtDgvDetalles.Columns.Add("modo", typeof(string));
                dtDgvDetalles.Columns.Add("formula_porc", typeof(string));
                dtDgvDetalles.Columns.Add("unidades", typeof(string));
                dtDgvDetalles.Columns.Add("total", typeof(string));
                dtDgvDetalles.Columns.Add("resultado", typeof(string));
                dtDgvDetalles.Columns.Add("codigoConceptoPorEmpresa", typeof(string));

                dtDgvDetalles.Columns.Add("Haber($)", typeof(string));
                dtDgvDetalles.Columns.Add("Haber(%)", typeof(string));
                dtDgvDetalles.Columns.Add("Deducción($)", typeof(string));
                dtDgvDetalles.Columns.Add("Deducción(%)", typeof(string));

                foreach (DataRow row in dtXML.Rows)
                {
                    DataRow newRow = dtDgvDetalles.NewRow();
                    newRow["codigo"] = row["codigo"];
                    newRow["descripcion"] = row["descripcion"];
                    newRow["hab_fijo"] = row["hab_fijo"];
                    newRow["hab_porc"] = row["hab_porc"];
                    newRow["ded_fijo"] = row["ded_fijo"];
                    newRow["ded_porc"] = row["ded_porc"];
                    newRow["tipo"] = row["tipo"];
                    newRow["modo"] = row["modo"];
                    newRow["formula_porc"] = row["formula_porc"];
                    newRow["unidades"] = row["unidades"];
                    newRow["total"] = row["total"];
                    newRow["resultado"] = row["resultado"];
                    newRow["codigoConceptoPorEmpresa"] = row["codigoConceptoPorEmpresa"];

                    dtDgvDetalles.Rows.Add(newRow);
                }
            }

            dgvDetalles.DataSource = dtDgvDetalles;

            dgvDetalles.Columns[0].HeaderText = "Código";
            dgvDetalles.Columns[1].HeaderText = "Descripción";
            dgvDetalles.Columns[10].HeaderText = "Total";

            dgvDetalles.Columns[13].DisplayIndex = 2;
            dgvDetalles.Columns[14].DisplayIndex = 3;
            dgvDetalles.Columns[15].DisplayIndex = 4;
            dgvDetalles.Columns[16].DisplayIndex = 5;

            dgvDetalles.Columns.RemoveAt(9);

            dgvDetalles.Columns.Insert(9, dgvbtnUnidades);

            foreach (DataRow row in dtDgvDetalles.Rows)
            {
                int index = dtDgvDetalles.Rows.IndexOf(row);

                dgvDetalles.Rows[index].Cells[9].Value = dtDgvDetalles.Rows[index][9];
            }
            dgvDetalles.Columns[2].Visible = false;
            dgvDetalles.Columns[7].Visible = false;
            dgvDetalles.Columns[3].Visible = false;
            dgvDetalles.Columns[7].Visible = false;
            dgvDetalles.Columns[4].Visible = false;
            dgvDetalles.Columns[7].Visible = false;
            dgvDetalles.Columns[5].Visible = false;
            dgvDetalles.Columns[7].Visible = false;
            dgvDetalles.Columns[6].Visible = false;
            dgvDetalles.Columns[7].Visible = false;
            dgvDetalles.Columns[8].Visible = false;
            dgvDetalles.Columns[11].Visible = false;
            dgvDetalles.Columns[12].Visible = false;

            for (int i = 0; i < dgvDetalles.Columns.Count; i++)
            {
                dgvDetalles.Columns[i].SortMode = DataGridViewColumnSortMode.NotSortable;
            }

            SetColorTable(dtDgvDetalles, dgvDetalles);

        }

        //TODO:13/09 Arreglar bug,si cambio de lugar un concepto y despues le cambios las unidades, se rompe. Revisar porque los decimales son 3 y no redondea.
        private void ModificarUnidades()
        {
            string promptValue = Prompt.ShowDialog("Cantidad:", "Modificar unidades:");

            if (promptValue != "")
            {
                int SearchedCode =  Convert.ToInt32(dgvDetalles.CurrentRow.Cells[12].Value);
                int currentRowIndex = dgvDetalles.CurrentRow.Index;

                DataRow row = dtDgvDetalles.AsEnumerable().Where(x => Convert.ToInt32(x["codigoConceptoPorEmpresa"]) == SearchedCode).First();
                row["unidades"] = promptValue;

                dtDgvDetalles.AcceptChanges();

                dtXML = dtDgvDetalles.Copy();

                ManejoDeRecibo.CalcularTabla(dtXML);

                dtDgvDetalles.Columns.Clear();
                dtDgvDetalles.Rows.Clear();

                DibujarTablaLiquidar();

                ManejoDeRecibo.CalcularTotales(dtXML, dgvDetalles, lblRemInfo, lblNoRemInfo, lblDeduccionesInfo, lblNetoInfo);

                ModificarCeldasHaberDeduccion();

                dgvDetalles.Rows[currentRowIndex].Selected = true;
            }
        }

        private void EliminarConcepto(DataRow dtXmlRow, DataRow dgvDtDetallesRow)
        {
            List<string> listaConceptosEnUso = VerificarConceptoEnUso(dtXmlRow);

            listaConceptosEnUso.AddRange(VerificarConceptoEnUso(dtXmlRow));

            listaConceptosEnUso = listaConceptosEnUso.Distinct().ToList();

            if (listaConceptosEnUso.Count > 0)
            {
                StringBuilder sb = new StringBuilder();
                sb.Append("No se puede eliminar concepto porque es parte de la formula de los siguientes conceptos:\n\n");

                for (int i = 0; i < listaConceptosEnUso.Count; i++)
                {
                    sb.Append(String.Format("- {0}\n", listaConceptosEnUso[i]));
                }
                sb.Append("\nPara eliminarlo debe primero eliminar los conceptos listados.");

                MessageBox.Show(Convert.ToString(sb), "Eliminar concepto:  " + Convert.ToString(dtXmlRow["descripcion"]));
                return;
            }

            dtXML.Rows.Remove(dtXmlRow);
            dtXML.AcceptChanges();

            dtDgvDetalles.Rows.Remove(dgvDtDetallesRow);
            dtDgvDetalles.AcceptChanges();

            dgvDetalles.Refresh();

            ManejoDeRecibo.CalcularTabla(dtXML);
            DibujarTablaLiquidar();
            ManejoDeRecibo.CalcularTotales(dtXML, dgvDetalles, lblRemInfo, lblNoRemInfo, lblDeduccionesInfo, lblNetoInfo);
            ModificarCeldasHaberDeduccion();
        }

        private List<string> VerificarConceptoEnUso(DataRow row)
        {
            List<string> listaConceptos = new List<string>();
            string codigo = "";

            foreach (DataRow r in dtXML.Rows)
            {
                switch (Convert.ToString(r["modo"]))
                {
                    case "hab_fijo":
                        codigo = Convert.ToString(row["codigo"]);

                        if (Convert.ToString(r["hab_fijo"]).Contains(String.Format("|{0}|", codigo)))
                        {
                            listaConceptos.Add(Convert.ToString(r["descripcion"]));
                        }
                        break;
                    case "ded_fijo":
                        codigo = Convert.ToString(row["codigo"]);

                        if (Convert.ToString(r["hab_fijo"]).Contains(String.Format("|{0}|", codigo)))
                        {
                            listaConceptos.Add(Convert.ToString(r["descripcion"]));
                        }
                        break;
                    case "hab_porc":
                    case "ded_porc":
                        codigo = Convert.ToString(row["codigoConceptoPorEmpresa"]);

                        if (Convert.ToString(r["formula_porc"]).Contains(String.Format("|{0}|", codigo)))
                        {
                            listaConceptos.Add(Convert.ToString(r["descripcion"]));
                        }
                        break;
                }
            }

            return listaConceptos;
        }

        private DataTable DataGridViewADataTableOrdenada()
        {
            DataTable tablaOrdenada = new DataTable();

            tablaOrdenada.Columns.Add("codigo", typeof(string));
            tablaOrdenada.Columns.Add("descripcion", typeof(string));
            tablaOrdenada.Columns.Add("hab_fijo", typeof(string));
            tablaOrdenada.Columns.Add("hab_porc", typeof(string));
            tablaOrdenada.Columns.Add("ded_fijo", typeof(string));
            tablaOrdenada.Columns.Add("ded_porc", typeof(string));
            tablaOrdenada.Columns.Add("tipo", typeof(string));
            tablaOrdenada.Columns.Add("modo", typeof(string));
            tablaOrdenada.Columns.Add("formula_porc", typeof(string));
            tablaOrdenada.Columns.Add("unidades", typeof(string));
            tablaOrdenada.Columns.Add("total", typeof(string));
            tablaOrdenada.Columns.Add("resultado", typeof(string));
            tablaOrdenada.Columns.Add("codigoConceptoPorEmpresa", typeof(string));

            foreach (DataGridViewRow row in dgvDetalles.Rows)
            {
                tablaOrdenada.Rows.Add(row.Cells[0].Value.ToString(),
                row.Cells[1].Value.ToString(),
                row.Cells[2].Value.ToString(),
                row.Cells[3].Value.ToString(),
                row.Cells[4].Value.ToString(),
                row.Cells[5].Value.ToString(),
                row.Cells[6].Value.ToString(),
                row.Cells[7].Value.ToString(),
                row.Cells[8].Value.ToString(),
                row.Cells[9].Value.ToString(),
                row.Cells[10].Value.ToString(),
                row.Cells[11].Value.ToString(),
                row.Cells[12].Value.ToString());
            }

            return tablaOrdenada;
        }

        public static void SetColorTable(DataTable dtXML, DataGridView dgvDetalles)
        {
            foreach (DataRow row in dtXML.Rows)
            {
                int index = dtXML.Rows.IndexOf(row);
                switch (dgvDetalles.Rows[index].Cells[6].Value.ToString())
                {
                    case "BAS":
                        dgvDetalles.Rows[index].Cells[0].Style.BackColor = Color.LightBlue;
                        break;
                    case "RM":
                        dgvDetalles.Rows[index].Cells[0].Style.BackColor = Color.LightGreen;
                        break;
                    case "NRM":
                        dgvDetalles.Rows[index].Cells[0].Style.BackColor = Color.LightYellow;
                        break;
                    default:
                        dgvDetalles.Rows[index].Cells[0].Style.BackColor = Color.LightPink;
                        break;
                }
            }
        }
        public void ModificarCeldasHaberDeduccion()
        {
            for (int i = 0; i < dtDgvDetalles.Rows.Count; i++)
            {
                switch (dgvDetalles.Rows[i].Cells["modo"].Value)
                {
                    case "hab_fijo":
                        dgvDetalles.Rows[i].Cells[13].Value = dtDgvDetalles.Rows[i]["resultado"];
                        break;
                    case "hab_porc":
                        dgvDetalles.Rows[i].Cells[14].Value = dtDgvDetalles.Rows[i]["hab_porc"];
                        break;
                    case "ded_fijo":
                        dgvDetalles.Rows[i].Cells[15].Value = dtDgvDetalles.Rows[i]["resultado"];
                        break;
                    case "ded_porc":
                        dgvDetalles.Rows[i].Cells[16].Value = dtDgvDetalles.Rows[i]["ded_porc"];
                        break;
                }

            }
        }
        #endregion

    }
}