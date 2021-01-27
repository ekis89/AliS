
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using System.IO;
using AliSlib;
using AliSLogica.Controladores;
using AliSLogica.Complementarios;
using System.Drawing;
using System.Text;
using AliS_WinVer.Clases;

namespace AliS_WinVer
{
    public partial class PrincipalLegajos : Form
    {
        #region PROPIEDADES
        private Form Index;
        private DataTable tablaPersonas;

        private Empresa _empresa;
        #endregion

        #region INICIO
        public PrincipalLegajos(Principal Index, Empresa empresa)
        {
            InitializeComponent();

            this.Index = Index;
            this._empresa = empresa;
        }

        private void add_empl_Load(object sender, EventArgs e)
        {
            this.Text = string.Format("{0}: Legajos", _empresa.NombreEmpresa);

            CargarCombos();
            CargarGrillas();
            CargarParametros();

        }

        private void CargarParametros()
        {
            try
            {
                DataTable tablaBancos = ControladorEmpresa.RecuperarParametrosPorCodigoTipoParametro(3);
                DataTable tablaConvenios = ControladorEmpresa.RecuperarParametrosPorCodigoTipoParametro(2);

                AutoCompleteStringCollection asc = new AutoCompleteStringCollection();
                AutoCompleteStringCollection asc2 = new AutoCompleteStringCollection();

                for (int i = 0; i < tablaBancos.Rows.Count; i++)
                {
                    asc.Add(Convert.ToString(tablaBancos.Rows[i]["descripcion"]));
                }

                for (int i = 0; i < tablaConvenios.Rows.Count; i++)
                {
                    asc2.Add(Convert.ToString(tablaConvenios.Rows[i]["descripcion"]));
                }

                txtBanco.AutoCompleteSource = AutoCompleteSource.CustomSource;
                txtBanco.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                txtBanco.AutoCompleteCustomSource = asc;

                txtConvenio.AutoCompleteSource = AutoCompleteSource.CustomSource;
                txtConvenio.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                txtConvenio.AutoCompleteCustomSource = asc2;


                txtBancoEditar.AutoCompleteSource = AutoCompleteSource.CustomSource;
                txtBancoEditar.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                txtBancoEditar.AutoCompleteCustomSource = asc;

                txtConvenioEditar.AutoCompleteSource = AutoCompleteSource.CustomSource;
                txtConvenioEditar.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                txtConvenioEditar.AutoCompleteCustomSource = asc2;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void CargarGrillas()
        {
            DataTable tablaConceptos = ControladorConcepto.RecuperarConceptosPorCodigoEmpresa(_empresa.codigoEmpresa);
            DataView dv = new DataView(tablaConceptos);
            dv.RowFilter = "NOT [hab_fijo] = '' OR NOT [hab_porc] = '' OR NOT [ded_fijo] = '' OR NOT [ded_porc] = ''";

            dgvConceptos.DataSource = dv;
            dgvConceptos.Columns[0].Width = 30;
            dgvConceptos.Columns[1].Visible = false;
            dgvConceptos.Columns[2].Width = 70;
            dgvConceptos.Columns[2].ReadOnly = true;
            dgvConceptos.Columns[3].Width = 220;
            dgvConceptos.Columns[3].ReadOnly = true;
            dgvConceptos.Columns[4].Visible = false;
            dgvConceptos.Columns[5].Visible = false;
            dgvConceptos.Columns[6].Visible = false;
            dgvConceptos.Columns[7].Visible = false;
            dgvConceptos.Columns[8].Width = 65;
            dgvConceptos.Columns[8].ReadOnly = true;
            dgvConceptos.Columns[9].Visible = false;
            dgvConceptos.Columns[10].Visible = false;

            dgvConceptosEditar.DataSource = dv;
            dgvConceptosEditar.Columns[0].Width = 30;
            dgvConceptosEditar.Columns[1].Visible = false;
            dgvConceptosEditar.Columns[2].Width = 70;
            dgvConceptosEditar.Columns[2].ReadOnly = true;
            dgvConceptosEditar.Columns[3].Width = 220;
            dgvConceptosEditar.Columns[3].ReadOnly = true;
            dgvConceptosEditar.Columns[4].Visible = false;
            dgvConceptosEditar.Columns[5].Visible = false;
            dgvConceptosEditar.Columns[6].Visible = false;
            dgvConceptosEditar.Columns[7].Visible = false;
            dgvConceptosEditar.Columns[8].Width = 65;
            dgvConceptosEditar.Columns[8].ReadOnly = true;
            dgvConceptosEditar.Columns[9].Visible = false;
            dgvConceptosEditar.Columns[10].Visible = false;

        }
        #endregion

        private void CargarCombos()
        {
            DataTable tablaPuestos = ControladorPuesto.RecuperarPuestosPorEmpresa(_empresa.codigoEmpresa);
            tablaPuestos.Columns.Add("codigoYDescripcion");

            foreach (DataRow row in tablaPuestos.Rows)
            {
                row["codigoYDescripcion"] = Convert.ToString(row["codigo"]) + " - " + Convert.ToString(row["descripcion"]);
            }

            tablaPuestos.AcceptChanges();

            cboPuesto.DisplayMember = "codigoYDescripcion";
            cboPuesto.ValueMember = "codigoPuesto";
            cboPuesto.DataSource = tablaPuestos;

            cboPuesto.SelectedIndex = -1;

            cboPuestoEditar.DisplayMember = "codigoYDescripcion";
            cboPuestoEditar.ValueMember = "codigoPuesto";
            cboPuestoEditar.DataSource = tablaPuestos;

            cboPuestoEditar.SelectedIndex = -1;
        }
 
        #region BOTONES
        private void createLegajo_Click(object sender, EventArgs e)
        {
            int numeroLegajo = (String.IsNullOrEmpty(txtNumeroLegajo.Text)) ? 0 : Convert.ToInt32(txtNumeroLegajo.Text);
            string nombre = (String.IsNullOrEmpty(txtNombre.Text)) ? null : txtNombre.Text;
            string apellido = (String.IsNullOrEmpty(txtApellido.Text)) ? null : txtApellido.Text;

            string cuil1 = (String.IsNullOrEmpty(txtCuil1.Text)) ? "" : txtCuil1.Text;
            string cuil2 = (String.IsNullOrEmpty(txtCuil2.Text)) ? "" : txtCuil2.Text;
            string cuil3 = (String.IsNullOrEmpty(txtCuil3.Text)) ? "" : txtCuil3.Text;
            string cuil = String.Format("{0}-{1}-{2}", cuil1, cuil2, cuil3);

            int codigoPuesto = Convert.ToInt32(cboPuesto.SelectedValue);
            string convenio = (String.IsNullOrEmpty(txtConvenio.Text)) ? null : txtConvenio.Text;
            DateTime fechaIngreso = dtFechaIngreso.Value;
            string banco = (String.IsNullOrEmpty(txtBanco.Text)) ? null : txtBanco.Text;

            string conceptos = "";

            if ((numeroLegajo < 1) || (nombre == null) || (apellido == null) || (cuil1 == "") || (cuil2 == "") || (cuil2 == "") || (convenio == null)
                || (banco == null) || codigoPuesto == 0)
            {
                MessageBox.Show("Faltan rellenar campos.");
                return;
            }

            conceptos = CrearListaConceptosAsignados(dgvConceptos);

            switch (conceptos)
            {
                case "NoSeleccionoConceptos":
                    MessageBox.Show("Debe elegir al menos un concepto de la lista de conceptos.");
                    return;
                case "NoSeleccionoBasico":
                    MessageBox.Show("Debe elegir al menos un concepto del tipo \"básico\" de la lista de conceptos.");
                    return;

                case "MasDeUnBasico":
                    MessageBox.Show("No puede haber mas de un concepto del tipo \"básico\" seleccionado.");
                    return;
            }

            try
            {
                string rta = ControladorPersona.InsertarActualizarPersona(0, _empresa.codigoEmpresa, numeroLegajo, nombre, apellido, cuil,
                    codigoPuesto, convenio, fechaIngreso, banco, conceptos);

                if (rta.Equals("ok"))
                {
                    txtNumeroLegajo.Text = "";
                    txtNombre.Text = "";
                    txtApellido.Text = "";

                    txtCuil1.Text = "";
                    txtCuil2.Text = "";
                    txtCuil3.Text = "";

                    cboPuesto.SelectedIndex = -1;
                    txtConvenio.Text = "";
                    dtFechaIngreso.Value = DateTime.Today;
                    txtBanco.Text = "";

                    for (int i = 0; i < dgvConceptos.RowCount; i++)
                    {
                        dgvConceptos.Rows[i].Cells[0].Value = false;
                    }

                    CargarLegajos();
                    CargarParametros();

                    foreach (Form frm in Application.OpenForms)
                    {
                        if (frm.Name == "SelectorLegajo")
                        {
                            (frm as SelectorLegajo).CargarLegajos();
                            break;
                        }

                    }

                    MessageBox.Show("¡Legajo creado con éxito!");
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

        private void btnGuardarEdicion_Click(object sender, EventArgs e)
        {
            int currentIndex = cboLegajo.SelectedIndex;
            int codigoPersonaPorEmpresa = Convert.ToInt32(cboLegajo.SelectedValue);
            int numeroLegajo = (String.IsNullOrEmpty(txtNroLegajoEdit.Text)) ? 0 : Convert.ToInt32(txtNroLegajoEdit.Text);
            string nombre = (String.IsNullOrEmpty(txtNombreEditar.Text)) ? null : txtNombreEditar.Text;
            string apellido = (String.IsNullOrEmpty(txtApellidoEditar.Text)) ? null : txtApellidoEditar.Text;

            string cuil = txtCuilEditar.Text;

            int codigoPuesto = Convert.ToInt32(cboPuestoEditar.SelectedValue);
            string convenio = (String.IsNullOrEmpty(txtConvenioEditar.Text)) ? null : txtConvenioEditar.Text;
            DateTime fechaIngreso = dtpFechaIngresoEditar.Value;
            string banco = (String.IsNullOrEmpty(txtBancoEditar.Text)) ? null : txtBancoEditar.Text;

            string conceptos = "";

            if ((numeroLegajo < 1) || (nombre == null) || (apellido == null) || (convenio == null) || (banco == null) || codigoPuesto == 0)
            {
                MessageBox.Show("Faltan rellenar campos.");
                return;
            }

            conceptos = CrearListaConceptosAsignados(dgvConceptosEditar);

            switch (conceptos)
            {
                case "NoSeleccionoConceptos":
                    MessageBox.Show("Debe elegir al menos un concepto de la lista de conceptos.");
                    return;
                case "NoSeleccionoBasico":
                    MessageBox.Show("Debe elegir al menos un concepto del tipo \"básico\" de la lista de conceptos.");
                    return;

                case "MasDeUnBasico":
                    MessageBox.Show("No puede haber mas de un concepto del tipo \"básico\" seleccionado.");
                    return;
            }

            try
            {
                string rta = ControladorPersona.InsertarActualizarPersona(codigoPersonaPorEmpresa, _empresa.codigoEmpresa, numeroLegajo, nombre, apellido, cuil,
                    codigoPuesto, convenio, fechaIngreso, banco, conceptos);

                if (rta.Equals("ok"))
                {
                    CargarLegajos();
                    CargarParametros();

                    cboLegajo.SelectedIndex = currentIndex;

                    foreach (Form frm in Application.OpenForms)
                    {
                        if (frm.Name== "SelectorLegajo")
                        {
                            (frm as SelectorLegajo).CargarLegajos();
                            break;
                        }

                    }

                    MessageBox.Show("¡Legajo editado con éxito!");
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
        #endregion

        #region METODOS
        private void LimpiarCamposCrearLegajos()
        {
            txtNumeroLegajo.Clear();
            txtNombre.Clear();
            txtApellido.Clear();
            txtCuil1.Clear();
            txtCuil2.Clear();
            txtCuil3.Clear();
            cboPuesto.SelectedIndex = 0;
            txtConvenio.Clear();
            txtBanco.Clear();
        }

        private void CargarLegajos()
        {
            tablaPersonas = ControladorPersona.RecuperarPersonasPorEmpresa(_empresa.codigoEmpresa);

            cboLegajo.DisplayMember = "descripcion";
            cboLegajo.ValueMember = "codigoPersonaPorEmpresa";
            cboLegajo.DataSource = tablaPersonas;

            cboLegajo.SelectedIndex = -1;
        }

        private string CrearListaConceptosAsignados(DataGridView dgv)
        {
            DataTable tablaConceptos = (dgv.DataSource as DataView).Table;

            DataRow rowConcepto;
            List<string> listaConceptos = new List<string>();
            string formula = "";
            string[] formulaSplit;
            string conceptos = "";
            int basicosSeleccionados = 0;

            for (int i = 0; i < dgv.RowCount; i++)
            {
                if (Convert.ToBoolean(dgv.Rows[i].Cells[0].Value))
                {
                    if (Convert.ToString(dgv.Rows[i].Cells[8].Value).Equals("BAS"))
                        basicosSeleccionados++;

                    if (basicosSeleccionados > 1)
                    {
                        conceptos = "MasDeUnBasico";
                        break;
                    }

                    listaConceptos.Add(String.Format("|{0}|", Convert.ToString(dgv.Rows[i].Cells[1].Value)));

                    switch (Convert.ToString(dgv.Rows[i].Cells[9].Value ))
                    {
                        case "hab_fijo":
                            if (!String.IsNullOrEmpty(Convert.ToString(dgv.Rows[i].Cells[4].Value)))
                            {
                                bool conversion = false;
                                double number = 0;

                                formula = Convert.ToString(dgv.Rows[i].Cells[4].Value).Replace("(", "");
                                formula = formula.Replace(")", "");

                                formulaSplit = formula.Split('/', '*', '-', '+');

                                for (int formulaIndex = 0; formulaIndex < formulaSplit.Length; formulaIndex++)
                                {
                                    conversion = double.TryParse(formulaSplit[formulaIndex], out number);

                                    if (conversion || formulaSplit[formulaIndex].Equals("|PUESTO|"))
                                    {
                                        continue;
                                    }
                                    else
                                    {
                                        if (!listaConceptos.Any(x => x.Contains(formulaSplit[formulaIndex])))
                                        {

                                            rowConcepto = (from r in tablaConceptos.AsEnumerable() where r.Field<string>("codigo") == formulaSplit[formulaIndex].Replace("|", "").Trim() select r).SingleOrDefault();

                                            if ((rowConcepto != null) && (Convert.ToInt32(rowConcepto["codigoConceptoPorEmpresa"]) > 0) )
                                            {
                                                listaConceptos.Add(String.Format("|{0}|", Convert.ToInt32(rowConcepto["codigoConceptoPorEmpresa"])));
                                            }
                                            
                                        }
                                    }
                                }
                            }
                            break;
                        case "ded_fijo":
                            if (!String.IsNullOrEmpty(Convert.ToString(dgv.Rows[i].Cells[6].Value)))
                            {
                                bool conversion = false;
                                double number = 0;

                                formula = Convert.ToString(dgv.Rows[i].Cells[6].Value).Replace("(", "");
                                formula = formula.Replace(")", "");

                                formulaSplit = formula.Split('/', '*', '-', '+');

                                for (int formulaIndex = 0; formulaIndex < formulaSplit.Length; formulaIndex++)
                                {
                                    conversion = double.TryParse(formulaSplit[formulaIndex], out number);

                                    if (conversion)
                                    {
                                        continue;
                                    }
                                    else
                                    {
                                        if (!listaConceptos.Any(x => x.Contains(formulaSplit[formulaIndex])))
                                        {
                                            rowConcepto = (from r in tablaConceptos.AsEnumerable() where r.Field<string>("codigo") == formulaSplit[formulaIndex].Replace("|", "").Trim() select r).SingleOrDefault();

                                            if ((rowConcepto != null) && (Convert.ToInt32(rowConcepto["codigoConceptoPorEmpresa"]) > 0))
                                            {
                                                listaConceptos.Add(String.Format("|{0}|", Convert.ToInt32(rowConcepto["codigoConceptoPorEmpresa"])));
                                            }
                                        }
                                    }
                                }
                            }
                            break;
                        default:
                            if (!String.IsNullOrEmpty(Convert.ToString(dgv.Rows[i].Cells[10].Value)))
                            {
                                formula = Convert.ToString(dgv.Rows[i].Cells[10].Value);
                                formulaSplit = formula.Split('+');

                                if (formula.Equals("TotalRemunerativos"))
                                {
                                    continue;
                                }
                                else
                                {
                                    for (int formulaIndex = 0; formulaIndex < formulaSplit.Length; formulaIndex++)
                                    {
                                        if (!listaConceptos.Any(x => x.Contains(formulaSplit[formulaIndex])))
                                        {
                                            //rowConcepto = (from r in tablaConceptos.AsEnumerable() where r.Field<int>("codigoConceptoPorEmpresa") == Convert.ToInt32(formulaSplit[formulaIndex].Replace("|", " ")) select r).SingleOrDefault();

                                            rowConcepto = tablaConceptos.AsEnumerable().Where(x => Convert.ToInt32(x["codigoConceptoPorEmpresa"]) == Convert.ToInt32(formulaSplit[formulaIndex].Replace("|", " "))).FirstOrDefault();

                                            if ((rowConcepto != null) && (Convert.ToInt32(rowConcepto["codigoConceptoPorEmpresa"]) > 0))
                                            {
                                                listaConceptos.Add(String.Format("|{0}|", Convert.ToInt32(rowConcepto["codigoConceptoPorEmpresa"])));
                                            }
                                        }
                                    }
                                }
                            }
                            break;
                    }
                }
            }

            listaConceptos = listaConceptos.Distinct().ToList();

            if (basicosSeleccionados < 1)
            {
                return "NoSeleccionoBasico";
            }

            if (listaConceptos.Count < 1)
            {
                return "NoSeleccionoConceptos";
            }

            for (int i = 0; i < listaConceptos.Count; i++)
            {
                conceptos += listaConceptos[i] + ";";
            }

            conceptos = conceptos.Substring(0, conceptos.Length - 1);

            return conceptos;
        }

        private string ConvertirCodigoStringAFormulaCodigo(string formula, DataGridView grilla)
        {
            string formulaPorcentaje = formula;
            string[] formulaPorcentajeSplited = formulaPorcentaje.Split('+');
            string codigoConceptoGrilla;

            for (int i = 0; i < formulaPorcentajeSplited.Length; i++)
            {
                for (int a = 0; a < grilla.Rows.Count; a++)
                {
                    codigoConceptoGrilla = Convert.ToString(grilla.Rows[a].Cells[1].Value);


                    if (formulaPorcentajeSplited[i].Trim() == String.Format("|{0}|", codigoConceptoGrilla))
                    {
                        formulaPorcentaje = formulaPorcentaje.Replace(formulaPorcentajeSplited[i], String.Format(" |{0}| ", Convert.ToString(grilla.Rows[a].Cells[0].Value)));
                    }
                }
            }

            return formulaPorcentaje;
        }

        private void VerificarConceptoAsigando(int codigoConceptoPorEmpresa)
        {
            try
            {
                DataTable tablaLegajos = ControladorPersona.RecuperarPersonasPorEmpresa(_empresa.codigoEmpresa);
                DataTable tablaConceptos = ControladorConcepto.RecuperarConceptosPorCodigoEmpresa(_empresa.codigoEmpresa);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        #endregion

        #region EVENTOS
        private void tabControl1_Selecting(object sender, TabControlCancelEventArgs e)
        {
            if (tabControl1.SelectedIndex == 1)
            {
                CargarLegajos();
            }
        }

        private void add_empl_FormClosing(object sender, FormClosingEventArgs e)
        {
            Index.Enabled = true;
            Index.Visible = true;

            if(Index.GetType() == typeof(Principal))
                (this.MdiParent as Principal).ActivarBotonesTS();
              
        }

        private void LegajoNumeroInput_KeyPress(object sender, KeyPressEventArgs e)
        {
            UsuarioSingleton.SoloNumeros(e);
        }

        private void editLegajoNumeroInput_KeyPress(object sender, KeyPressEventArgs e)
        {
            UsuarioSingleton.SoloNumeros(e);
        }

        //textbox cuil.
        private void cuilInput1_KeyPress(object sender, KeyPressEventArgs e)
        {
            UsuarioSingleton.SoloNumeros(e);
        }

        private void cuilInput2_KeyPress(object sender, KeyPressEventArgs e)
        {
            UsuarioSingleton.SoloNumeros(e);
        }

        private void cuilInput3_KeyPress(object sender, KeyPressEventArgs e)
        {
            UsuarioSingleton.SoloNumeros(e);
        }


        #endregion

        private void dgvConceptos_DoubleClick(object sender, EventArgs e)
        {
            string modoConcepto = Convert.ToString(dgvConceptos.CurrentRow.Cells[9].Value);
            StringBuilder sb = new StringBuilder();
            string porcentaje = "";
            string formula = "";
            string[] formulaSplit;
            int codigoConcepto = 0;

            switch (modoConcepto) {
                case "hab_fijo":
                    formula = Convert.ToString(dgvConceptos.CurrentRow.Cells[4].Value);

                    formula = (String.IsNullOrEmpty(formula)) ? "Fórmula sin asignar" : formula;

                    MessageBox.Show(formula, "Fórmula:");
                    break;
                case "ded_fijo":
                    formula = Convert.ToString(dgvConceptos.CurrentRow.Cells[6].Value);

                    formula = (String.IsNullOrEmpty(formula)) ? "Fórmula sin asignar" : formula;

                    MessageBox.Show(formula, "Fórmula:");
                    break;
                case "hab_porc":
                    porcentaje = Convert.ToString(dgvConceptos.CurrentRow.Cells[5].Value);
                    formula = Convert.ToString(dgvConceptos.CurrentRow.Cells[10].Value);

                    sb.Append(String.Format("Porcentaje: {0}% \n\n", porcentaje));
                    sb.Append(String.Format("Aplica a:\n", porcentaje));

                    if (formula.Equals("TotalRemunerativos"))
                    {
                        sb.Append("- Total haberes remunerativos.");
                    }
                    else
                    {
                        formulaSplit = formula.Split('+');

                        for (int i = 0; i < formulaSplit.Length; i++)
                        {
                            for (int a = 0; a < dgvConceptos.Rows.Count; a++)
                            {
                                codigoConcepto = Convert.ToInt32(dgvConceptos.Rows[a].Cells[1].Value);

                                if (codigoConcepto == Convert.ToInt32(formulaSplit[i].Replace("|","")))
                                {
                                    sb.Append(String.Format("- {0}\n", Convert.ToString(dgvConceptos.Rows[a].Cells[3].Value)));
                                }
                            }
                        }
                    }

                    MessageBox.Show(Convert.ToString(sb), "Fórmula:");

                    break;
                case "ded_porc":
                    porcentaje = Convert.ToString(dgvConceptos.CurrentRow.Cells[7].Value);
                    formula = Convert.ToString(dgvConceptos.CurrentRow.Cells[10].Value);

                    sb.Append(String.Format("Porcentaje: {0}% \n\n", porcentaje));
                    sb.Append(String.Format("Aplica a:\n", porcentaje));

                    if (formula.Equals("TotalRemunerativos"))
                    {
                        sb.Append("- Total haberes remunerativos.");
                    }
                    else
                    {
                        formulaSplit = formula.Split('+');

                        for (int i = 0; i < formulaSplit.Length; i++)
                        {
                            for (int a = 0; a < dgvConceptos.Rows.Count; a++)
                            {
                                codigoConcepto = Convert.ToInt32(dgvConceptos.Rows[a].Cells[1].Value);

                                if(codigoConcepto == Convert.ToInt32(formulaSplit[i].Replace("|", "")))
                                {
                                    sb.Append(String.Format("- {0}\n", Convert.ToString(dgvConceptos.Rows[a].Cells[3].Value)));
                                }
                            }
                        }
                    }

                    MessageBox.Show(Convert.ToString(sb), "Fórmula:");

                    break;
            }
        }

        private void cboLegajo_SelectedValueChanged(object sender, EventArgs e)
        {
            if(cboLegajo.SelectedIndex > -1)
            {
                List<string> listaConceptos;
                int codigoPersonaPorEmpresa = Convert.ToInt32(cboLegajo.SelectedValue);
                DataRow legajoSeleccionado = (from r in tablaPersonas.AsEnumerable() where r.Field<int>("codigoPersonaPorEmpresa") == codigoPersonaPorEmpresa select r).SingleOrDefault();

                listaConceptos = Convert.ToString(legajoSeleccionado["conceptos"]).Split(';').ToList();

                txtNroLegajoEdit.Text = Convert.ToString(legajoSeleccionado["numeroLegajo"]);
                txtNombreEditar.Text = Convert.ToString(legajoSeleccionado["nombre"]);
                txtApellidoEditar.Text = Convert.ToString(legajoSeleccionado["apellido"]);

                txtCuilEditar.Text = Convert.ToString(legajoSeleccionado["cuil"]);

                cboPuestoEditar.SelectedValue = Convert.ToInt32(legajoSeleccionado["codigoPuesto"]);
                txtConvenioEditar.Text = Convert.ToString(legajoSeleccionado["convenio"]);
                dtpFechaIngresoEditar.Value = Convert.ToDateTime(legajoSeleccionado["fechaIngreso"]);
                txtBancoEditar.Text = Convert.ToString(legajoSeleccionado["banco"]);

                for (int i = 0; i < listaConceptos.Count; i++)
                {
                    for (int a = 0; a < dgvConceptosEditar.Rows.Count; a++)
                    {
                        if (listaConceptos[i] == "|" + Convert.ToString(dgvConceptosEditar.Rows[a].Cells[1].Value) + "|")
                        {
                            dgvConceptosEditar.Rows[a].Cells[0].Value = true;
                            break;
                        }
                        else
                        {
                            if (!listaConceptos.Contains("|" + Convert.ToString(dgvConceptosEditar.Rows[a].Cells[1].Value) + "|"))
                            {
                                dgvConceptosEditar.Rows[a].Cells[0].Value = false;
                            }
                        }
                    }
                }
            }
            else
            {
                txtNroLegajoEdit.Text = "";
                txtNombreEditar.Text = "";
                txtApellidoEditar.Text = "";

                txtCuilEditar.Text = "";

                cboPuestoEditar.SelectedIndex = -1;
                txtConvenioEditar.Text = "";
                //dtpFechaIngresoEditar.Value =;
                txtBancoEditar.Text = "";

                for (int i = 0;i < dgvConceptosEditar.Rows.Count; i++)
                {
                    dgvConceptosEditar.Rows[i].Cells[0].Value = false;
                }
            }
        }
    }
}

//TODO:: 07/11/2020 Cuando edito legajo y destildo un concepto que es parte de la formula de otro concepto tengo que hacer que salga un messageBox que diga que no se puede destildar.
