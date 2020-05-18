using System;
using System.Collections.Generic;
using System.Data;
using System.Xml;
using System.Windows.Forms;
using AliSlib;
using Obj;
using AliSLogica.Controladores;
using AliSLogica.Complementarios;

namespace AliS_WinVer
{
    public partial class GestionLiquidacionConceptos : Form
    {
        private Index Index;

        public List<string> editFormulas = new List<string>();
        public DataSet DS;
        public DataTable dtXML;

        private string[] meses = new string[] { "Undefined", "Enero", "Febrero", "Marzo", "Abril", "Mayo", "Junio", "Julio", "Agosto", "Septiembre", "Octubre", "Noviembre", "Diciembre" };

        private bool cancelBtn = false;
        private bool saveBtn = false;
        private XmlNode mesNode;
        private int rowIndex;
        public DataTable dtDgvDetalles = new DataTable();

        private PrincipalLiquidaciones screenReciboBuilder;
        private XmlDocument docXML;
        private bool isEditMode;
        private bool isSalarioMensual;

        private ComboBox cboAño;
        private ComboBox cboMes;
        private ComboBox cboQuincena;

        private string añoSelected;
        private string mesSelected;

        private string userFolder;
        private string XMLcurrentFolder;
        private string curFile;

        public string empresaNombre;
        private string empresaCUIT;
        private string legajoNumero;
        private string cuil;


        // SEGUIR DESDE ACA, BORRAR EL NODO DEL MES DEL XML CUANDO SE APRETA EN EL BOTON CANCELAR (en el caso de que sea liquidar y no editar)
        public GestionLiquidacionConceptos(PrincipalLiquidaciones screenReciboBuilder, bool isEditMode)
        {
            InitializeComponent();

            this.screenReciboBuilder = screenReciboBuilder;
            this.docXML = screenReciboBuilder.XMLDocumento;
            this.isEditMode = isEditMode;
            this.isSalarioMensual = screenReciboBuilder.isSalarioMensual;

            this.empresaNombre = UsuarioSingleton.Instance.NombreEmpresa;
            this.empresaCUIT = UsuarioSingleton.Instance.CuitEmpresa;
            this.legajoNumero = UsuarioSingleton.Instance.LegajoNumero;
            this.cuil = UsuarioSingleton.Instance.EmpleadoCUIL;

            this.cboAño = screenReciboBuilder.cboAño;
            this.cboMes =  screenReciboBuilder.cboMes;
            this.cboQuincena = screenReciboBuilder.cboQuincena;

            this.añoSelected = cboAño.GetItemText(cboAño.SelectedItem);
            this.mesSelected = cboMes.GetItemText(cboMes.SelectedItem);

            this.userFolder = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);
            this.XMLcurrentFolder = string.Format("{0}\\documents\\Alis\\{1}\\{2}\\", userFolder, empresaNombre, cuil.Replace("-", ""));
            this.curFile = string.Format("{0}\\{1}.xml", XMLcurrentFolder, añoSelected);

        }

        public void Liquidar_Load(object sender, EventArgs e)
        {
            if (!isEditMode)
            {
                IniciarLiquidacion();
                DibujarTablaLiquidar();

                ManejoDeRecibo.CalcularTabla(dtDgvDetalles);
                ManejoDeRecibo.CalcularTotales(dtDgvDetalles, dgvDetalles, lblRemInfo, lblNoRemInfo, lblDeduccionesInfo, lblNetoInfo);

                ModificarCeldasHaberDeduccion();
            }
            else
            {
                dtXML = screenReciboBuilder.dtXML.Copy();
                dtpFechaDeposito.Value = Convert.ToDateTime(screenReciboBuilder.lblFechaDepositoInfo.Text);
                dtpFechaLiquidacion.Value = Convert.ToDateTime(screenReciboBuilder.lblFechaLiquidacionInfo.Text);

                DibujarTablaLiquidar();

                ManejoDeRecibo.CalcularTabla(dtDgvDetalles);
                ManejoDeRecibo.CalcularTotales(dtDgvDetalles, dgvDetalles, lblRemInfo, lblNoRemInfo, lblDeduccionesInfo, lblNetoInfo);

                ModificarCeldasHaberDeduccion();
            }

        }

        private void ModificarCeldasHaberDeduccion()
        {
            for (int i = 0; i < dtDgvDetalles.Rows.Count; i++)
            {
                switch (dgvDetalles.Rows[i].Cells[7].Value)
                {
                    case "hab_fijo":
                        dgvDetalles.Rows[i].Cells[12].Value = dtDgvDetalles.Rows[i][11];
                        break;
                    case "hab_porc":
                        dgvDetalles.Rows[i].Cells[13].Value = dtDgvDetalles.Rows[i][11];
                        break;
                    case "ded_fijo":
                        dgvDetalles.Rows[i].Cells[14].Value = dtDgvDetalles.Rows[i][11];
                        break;
                    case "ded_porc":
                        dgvDetalles.Rows[i].Cells[15].Value = dtDgvDetalles.Rows[i][11];
                        break;
                }
                
            }
        }


        // Modifica la unidades.
        private void dgvDetalles_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var senderGrid = (DataGridView)sender;

            if (senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn &&
                e.RowIndex >= 0)
                ModificarUnidades();
        }

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
        }

        private void Save_Click(object sender, EventArgs e)
        {
            double haberRemunerativo = double.Parse(lblRemInfo.Text.Replace("$", ""));
            double haberNoRemunerativo = double.Parse(lblNoRemInfo.Text.Replace("$", ""));
            double total = haberRemunerativo + haberNoRemunerativo;

            DataTable tablaOrdenada = DataGridViewADataTableOrdenada();

            XMLBuilder.XMLsaver(screenReciboBuilder.XMLDocumento, tablaOrdenada, mesSelected, curFile, dtpFechaLiquidacion, dtpFechaDeposito, isSalarioMensual, screenReciboBuilder.cboQuincena.Text, total.ToString(), screenReciboBuilder.lblLegajoNumInfo.Text, UsuarioSingleton.Instance.CuitEmpresa, isEditMode);

            saveBtn = true;
            Close();

            ManejoDeRecibo.CalcularTabla(tablaOrdenada);
            ManejoDeRecibo.DrawTabla(tablaOrdenada, screenReciboBuilder.dgvDetallesRecibo, true);
            ManejoDeRecibo.CalcularTotales(tablaOrdenada, screenReciboBuilder.dgvDetallesRecibo, screenReciboBuilder.lblHaberesRemInfo, screenReciboBuilder.lblHaberesNoRemInfo, screenReciboBuilder.lblDeduccionInfo, screenReciboBuilder.lblNetoInfo);

            screenReciboBuilder.dgvDetallesRecibo.Columns[0].Visible = false;
            screenReciboBuilder.dgvDetallesRecibo.Columns[2].Visible = false;
            screenReciboBuilder.dgvDetallesRecibo.Columns[3].Visible = false;

            screenReciboBuilder.dgvDetallesRecibo.Columns[1].Width = 272;
            screenReciboBuilder.dgvDetallesRecibo.Columns[4].Width = 150;
            screenReciboBuilder.dgvDetallesRecibo.Columns[5].Width = 150;

            screenReciboBuilder.lblFechaLiquidacionInfo.Text = dtpFechaLiquidacion.Value.ToString("dd/MM/yyyy");
            screenReciboBuilder.lblFechaDepositoInfo.Text = dtpFechaDeposito.Value.ToString("dd/MM/yyyy");

            if (!isEditMode)
            {
                screenReciboBuilder.btnLiquidar.Visible = false;
                screenReciboBuilder.btnEditar.Visible = true;
                screenReciboBuilder.btnImprimir.Enabled = true;
                screenReciboBuilder.btnEditar.Enabled = true;
            }
        }

        #region BOTONES
        //AÑARDIR CONCEPTOS
        public void Add_con_Click(object sender , EventArgs e)
        {
            
            LiquidacionesPrincipalConceptos liquidacionesPrincipalConceptos = new LiquidacionesPrincipalConceptos(this, empresaNombre);

            this.Visible = false;
            liquidacionesPrincipalConceptos.Show();
        }

        //EDITAR CONCEPTOS
        public void Edit_con_Click(object sender, EventArgs e)
        {
            PrincipalConceptos con_scrn = new PrincipalConceptos(Index, this, true);

            this.Visible = false;
            con_scrn.Show();
        }

        //ELIMINAR CONCEPTOS
        private void Del_con_Click(object sender, EventArgs e)
        {
            string codigo = dgvDetalles.CurrentRow.Cells[0].Value.ToString();
            string descripcion = dgvDetalles.CurrentRow.Cells[1].Value.ToString();
            DataRow[] Row = dtXML.Select("codigo Like '" + codigo + "'");

            string tipo = Row[0].ItemArray[6].ToString();

            if (tipo != "BAS")
            {
                DialogResult confirm = MessageBox.Show("¿Esta seguro que desea quitar el siguiente concepto?:\n \n" + descripcion, "Quitar concepto:", MessageBoxButtons.YesNo);

                if (confirm == DialogResult.Yes)
                {
                    EliminarConcepto(Row);
                }
            }
            else
            {
                MessageBox.Show("Los conceptos de tipo \"Básico\" no pueden ser eliminados");
            }
        }

        private void btnBajar_Click(object sender, EventArgs e)
        {
            rowIndex = dgvDetalles.SelectedCells[0].OwningRow.Index;
            DataRow row = dtDgvDetalles.NewRow();

            row[0] = dtDgvDetalles.Rows[rowIndex][0];
            row[1] = dtDgvDetalles.Rows[rowIndex][1];
            row[2] = dtDgvDetalles.Rows[rowIndex][2];
            row[3] = dtDgvDetalles.Rows[rowIndex][3];
            row[4] = dtDgvDetalles.Rows[rowIndex][4];
            row[5] = dtDgvDetalles.Rows[rowIndex][5];
            row[6] = dtDgvDetalles.Rows[rowIndex][6];
            row[7] = dtDgvDetalles.Rows[rowIndex][7];
            row[8] = dtDgvDetalles.Rows[rowIndex][8];
            row[9] = dtDgvDetalles.Rows[rowIndex][9];
            row[10] = dtDgvDetalles.Rows[rowIndex][10];
            row[11] = dtDgvDetalles.Rows[rowIndex][11];

            if (rowIndex < dgvDetalles.Rows.Count - 1)
            {
                dtDgvDetalles.Rows.RemoveAt(rowIndex);
                dtDgvDetalles.Rows.InsertAt(row, rowIndex + 1);

                dgvDetalles.Rows[rowIndex + 1].Selected = true;
                dgvDetalles.Rows[rowIndex + 1].Cells[9].Value = row[9];
            }

            ReciboTools.SetColorTable(dtDgvDetalles, dgvDetalles);
            ModificarCeldasHaberDeduccion();
        }

        private void btnSubir_Click(object sender, EventArgs e)
        {
            rowIndex = dgvDetalles.SelectedCells[0].OwningRow.Index;
            DataRow row = dtDgvDetalles.NewRow();

            row[0] = dtDgvDetalles.Rows[rowIndex][0];
            row[1] = dtDgvDetalles.Rows[rowIndex][1];
            row[2] = dtDgvDetalles.Rows[rowIndex][2];
            row[3] = dtDgvDetalles.Rows[rowIndex][3];
            row[4] = dtDgvDetalles.Rows[rowIndex][4];
            row[5] = dtDgvDetalles.Rows[rowIndex][5];
            row[6] = dtDgvDetalles.Rows[rowIndex][6];
            row[7] = dtDgvDetalles.Rows[rowIndex][7];
            row[8] = dtDgvDetalles.Rows[rowIndex][8];
            row[9] = dtDgvDetalles.Rows[rowIndex][9];
            row[10] = dtDgvDetalles.Rows[rowIndex][10];
            row[11] = dtDgvDetalles.Rows[rowIndex][11];


            if (rowIndex > 0)
            {
                dtDgvDetalles.Rows.RemoveAt(rowIndex);
                dtDgvDetalles.Rows.InsertAt(row, rowIndex - 1);

                dgvDetalles.Rows[rowIndex - 1].Selected = true;
                dgvDetalles.Rows[rowIndex - 1].Cells[9].Value = row[9];
            }

            ReciboTools.SetColorTable(dtDgvDetalles, dgvDetalles);
            ModificarCeldasHaberDeduccion();

        }

        private void Cancel_Click(object sender, EventArgs e)
        {
            cancelBtn = true;
            screenReciboBuilder.XMLDocumento = docXML;
            Close();
        }

        private void mnubtnCalculadoraSAC_Click(object sender, EventArgs e)
        {
            if (docXML.ChildNodes.Count < 2)
            {
                MessageBox.Show("No se puede iniciar calculadora SAC: archivo XML vacio o corrupto.");
            }
            else
            {
                CalculadoraSAC screenSAC = new CalculadoraSAC(screenReciboBuilder.XMLDocumento, this, isSalarioMensual);
                screenSAC.Show();
            }

        }
        #endregion

        #region METODOS
        private void IniciarLiquidacion()
        {
            string puesto = "";
            string fechaLiquidacion = ManejoDeRecibo.SetLiquidacionFecha(cboAño, cboMes, cboQuincena, isSalarioMensual);
            DataTable tablaPuesto = ControladorLiquidar.RecuperarPuesto(UsuarioSingleton.Instance.LegajoNumero, UsuarioSingleton.Instance.CuitEmpresa);

            puesto = tablaPuesto.Rows[0][0].ToString();

            dtXML = ManejoDeRecibo.Liquidar(UsuarioSingleton.Instance.UserFolder, screenReciboBuilder.XMLDocumento, isSalarioMensual, puesto, empresaCUIT,
                cboAño, cboMes, cboQuincena, cuil, empresaNombre);

            dtpFechaLiquidacion.Value = DateTime.Parse(fechaLiquidacion);
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

                dtDgvDetalles.Columns.Add("Haber($)", typeof(string));
                dtDgvDetalles.Columns.Add("Haber(%)", typeof(string));
                dtDgvDetalles.Columns.Add("Deducción($)", typeof(string));
                dtDgvDetalles.Columns.Add("Deducción(%)", typeof(string));

                foreach (DataRow row in dtXML.Rows)
                {
                    dtDgvDetalles.Rows.Add(row.ItemArray);
                }
            }

            dgvDetalles.DataSource = dtDgvDetalles;

            dgvDetalles.Columns[0].HeaderText = "Código";
            dgvDetalles.Columns[1].HeaderText = "Descripción";
            dgvDetalles.Columns[10].HeaderText = "Total";

            dgvDetalles.Columns[12].DisplayIndex = 2;
            dgvDetalles.Columns[13].DisplayIndex = 3;
            dgvDetalles.Columns[14].DisplayIndex = 4;
            dgvDetalles.Columns[15].DisplayIndex = 5;

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

            for (int i = 0; i < dgvDetalles.Columns.Count; i++)
            {
                dgvDetalles.Columns[i].SortMode = DataGridViewColumnSortMode.NotSortable;
            }

            ReciboTools.SetColorTable(dtDgvDetalles, dgvDetalles);

        }

        private void ModificarUnidades()
        {
            string promptValue = Prompt.ShowDialog("Cantidad:", "Modificar unidades:");

            if (promptValue != "")
            {
                string SearchedCode = '"' + dgvDetalles.CurrentRow.Cells[0].Value.ToString() + '"';

                foreach (DataRow SearchedRow in dtXML.Rows)
                {
                    int index = dtXML.Rows.IndexOf(SearchedRow);
                    string CurrentRow = '"' + dtXML.Rows[index][0].ToString() + '"';


                    if (CurrentRow == SearchedCode)
                    {
                        dtXML.Rows[index][9] = promptValue;
                        break;
                    }
                }

                ManejoDeRecibo.CalcularTabla(dtXML);

                dtDgvDetalles.Columns.Clear();
                dtDgvDetalles.Rows.Clear();

                DibujarTablaLiquidar();

                ManejoDeRecibo.CalcularTotales(dtXML, dgvDetalles, lblRemInfo, lblNoRemInfo, lblDeduccionesInfo, lblNetoInfo);

                ModificarCeldasHaberDeduccion();
            }
        }

        private void EliminarConcepto(DataRow[] Rows)
        {
            DataRow row = Rows[0];
            int index = 0;

            index = dtXML.Rows.IndexOf(row);
            dtXML.Rows[index].Delete();

            dgvDetalles.Rows.Clear();
            dgvDetalles.Columns.Clear();

            ManejoDeRecibo.CalcularTabla(dtXML);
            ManejoDeRecibo.DrawTabla(dtXML, dgvDetalles, true);
            ManejoDeRecibo.CalcularTotales(dtXML, dgvDetalles, lblRemInfo, lblNoRemInfo, lblDeduccionesInfo, lblNetoInfo);
            ModificarCeldasHaberDeduccion();
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
                row.Cells[11].Value.ToString());
            }

            return tablaOrdenada;
        }
        #endregion
    }
}
