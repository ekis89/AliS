using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using System.IO;
using AliSlib;
using AliSDatos.Clases;
using AliSLogica.Complementarios;
using System.Xml;
using AliS_WinVer.Clases;

namespace AliS_WinVer
{
    public partial class ReciboBuilderMini : Form
    {
        public DataTable dtDetalle = new DataTable();
        private XmlDocument customXML = new XmlDocument();

        PrincipalLiquidaciones screenReciboBuilder;
        private Empresa _empresa;
        private Legajo _legajo;

        private string CURRENT_YEAR = DateTime.Now.ToString("yyyy");

        private string INIT_PATH = "";
        
        private int antiBug = 0;

        private string currentFilePath;

        private bool hasChanges = false;

        #region INICIO
        public ReciboBuilderMini(PrincipalLiquidaciones screenReciboBuilder, Empresa empresa, Legajo legajo)
        {
            InitializeComponent();
            this.screenReciboBuilder = screenReciboBuilder;

            this._empresa = empresa;
            this._legajo = legajo;

            this.INIT_PATH = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) + "\\documents\\Alis\\" + _empresa.NombreEmpresa + "\\" + _legajo.EmpleadoCUIL.Replace("-", "");
        }

        private void ReciboBuilderMini_Load(object sender, EventArgs e)
        {
            string linea1;
            string linea2 = string.Format("LA CANTIDAD DE PESOS: ----------");
            string linea3 = string.Format("Correspondiente a los haberes de:  {0} de {1} según liquidación precedente de la que", UsuarioSingleton.Instance.Meses[1].ToUpper(), CURRENT_YEAR);
            string linea4 = string.Format(" recibo duplicado y tomo conocimiento que los aportes jubilatorios del mes de DICIEMBRE de {0},", Convert.ToInt32(CURRENT_YEAR) - 1);

            string[] FechaDepositoSplit = dtpFechaDeposito.Text.Split('/');
            string banco;
            int mesSplit = Convert.ToInt32(FechaDepositoSplit[1]);
            
            linea1 = string.Format(" Recibí de: {0} - con domicilio en {1} - {2} - {3}", _empresa.NombreEmpresa.ToUpper(), _empresa.DireccionEmpresa, Convert.ToString(_empresa.PostalEmpresa), _empresa.LocalidadEmpresa);

            banco = _legajo.Banco;

            for (int i=1950;i <= int.Parse(CURRENT_YEAR);i++)
            {
                cboAño.Items.Add(i.ToString());
            }
            cboMes.SelectedIndex = 0;
            cboQuincena.SelectedIndex = 0;
            cboAño.SelectedIndex =  cboAño.FindStringExact(CURRENT_YEAR);

            tbxLinea1.Text = linea1;
            tbxLinea2.Text = linea2;
            tbxLinea3.Text = linea3;
            tbxLinea4.Text = linea4;
            tbxLinea5.Text = string.Format(" fueron depositados en {0} el {1} de {2} de {3} .", banco.ToUpper(), FechaDepositoSplit[0], UsuarioSingleton.Instance.Meses[mesSplit].ToUpper(), FechaDepositoSplit[2]);

            dtDetalle.Columns.Add("Codigo");
            dtDetalle.Columns.Add("Descripcion");
            dtDetalle.Columns.Add("Haberes");
            dtDetalle.Columns.Add("Deducciones");
            dtDetalle.Columns.Add("Porcentaje");
            dtDetalle.Columns.Add("Tipo");

            dgvDetalle.DataSource = dtDetalle;
            dgvDetalle.Columns[0].Width = 85;
            dgvDetalle.Columns[1].Width = 150;
            dgvDetalle.Columns[2].Width = 120;
            dgvDetalle.Columns[3].Width = 120;
            dgvDetalle.Columns[4].Width = 40;
        }
        #endregion

        #region BOTONES
        private void btnAgregarr_Click(object sender, EventArgs e)
        {
            DataRow ConceptoRow = dtDetalle.NewRow();
            string codigo = tbxCodigo.Text;
            string descripcion = tbxDescripcion.Text;
            string valor = tbxValor.Text;
            string porcentaje = tbxPorcentaje.Text;
            string tipo;
            double valueDouble = double.Parse(valor);

            ConceptoRow["Codigo"] = "\""+codigo.ToUpper()+"\"";
            ConceptoRow["Descripcion"] = descripcion;
            ConceptoRow["Porcentaje"] = porcentaje;

            if (codigo == " " || codigo.Length == 0 || descripcion == " " || descripcion.Length == 0 || valor == " " || valor.Length == 0)
            {
                MessageBox.Show("Error: Asegurese de que todos los campos esten llenos.");
                return;
            }
            else
            {
                if (optHabRem.Checked)
                {
                    tipo = "RM";
                    ConceptoRow["Haberes"] = Math.Round(valueDouble, 2).ToString();
                }
                else if (optHabNoRem.Checked)
                {
                    tipo = "NRM";
                    ConceptoRow["Haberes"] = Math.Round(valueDouble, 2).ToString();
                }
                else if (optDeduccion.Checked)
                {
                    tipo = "DED";
                    ConceptoRow["Deducciones"] = Math.Round(valueDouble, 2).ToString();
                }
                else
                {
                    MessageBox.Show("Error: Debe seleccionar el tipo de concepto.");
                    return;
                }
            }

            ConceptoRow["Tipo"] = tipo;
            dtDetalle.Rows.Add(ConceptoRow);

            dgvDetalle.Refresh();
            dtDetalle.DefaultView.Sort = "Tipo DESC";

            tbxCodigo.Clear();
            tbxDescripcion.Clear();
            tbxValor.Clear();
            tbxPorcentaje.Clear();
            optHabRem.Checked = false;
            optHabNoRem.Checked = false;
            optDeduccion.Checked = false;

            ManejoDeRecibo.CalcularReciboMini(dtDetalle, lblRem, lblNoRem, lblDeducciones, lblNeto, tbxLinea2);

            if (dgvDetalle.Rows.Count > 0)
            {
                btnGuardarMenu.Enabled = true;
                btnGuardarComoMenu.Enabled = true;
                btnBorrar.Enabled = true;
                btnImprimirMenu.Enabled = true;
            }
            else
            {
                btnGuardarMenu.Enabled = false;
                btnGuardarComoMenu.Enabled = false;
                btnBorrar.Enabled = false;
                btnImprimirMenu.Enabled = false;
            }
        }

        private void btnBorrarr_Click(object sender, EventArgs e)
        {
            string codigo = dgvDetalle.CurrentRow.Cells[0].Value.ToString();
            DataRow[] rows;
            rows = dtDetalle.Select("Codigo='"+codigo+"'");
            foreach (DataRow r in rows)
            {
                r.Delete();
            }
            dgvDetalle.Refresh();

            ManejoDeRecibo.CalcularReciboMini(dtDetalle, lblRem, lblNoRem, lblDeducciones, lblNeto, tbxLinea2);

            if (dgvDetalle.Rows.Count < 1)
            {
                btnGuardarMenu.Enabled = false;
                btnGuardarComoMenu.Enabled = false;
                btnBorrar.Enabled = false;
                btnImprimirMenu.Enabled = false;
            }
        }

        private void btnCalculadora_Click(object sender, EventArgs e)
        {
            Calculator frmCalculadora = new Calculator(this);
            this.Enabled = false;
            frmCalculadora.Show();
        }

        private void btnImprimirMenu_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;

            try
            {
                string remunerativo = lblRem.Text;
                string noRemunerativo = lblNoRem.Text;
                string deducciones = lblDeducciones.Text.Replace("-","");
                string Neto = lblNeto.Text;
                string netoString = "";

                string convenio = tbxConvenio.Text;
                string puesto = tbxPuesto.Text;

                var añoSelected = Convert.ToInt32(cboAño.GetItemText(cboAño.SelectedItem));
                var mesSelected = Convert.ToInt32(cboMes.GetItemText(cboMes.SelectedItem));
                var quincenaSelected = cboQuincena.GetItemText(cboQuincena.SelectedItem);

                string titulo = "Imprimir: Recibo manual.";

                CabeceraRecibo cabeceraRecibo;

                string footerText = string.Format("{0} \n {1} \n {2} \n{3}\n{4} \n Rosario.      {5}   ", tbxLinea1.Text, tbxLinea2.Text, tbxLinea3.Text, tbxLinea4.Text, tbxLinea5.Text, dtpFechaLiquidacion.Text);

                if (Convert.ToDouble(Neto) < 0)
                {
                    netoString = ConversorIntString.enletras(Neto.ToString().Replace("-", ""));
                    netoString = "MENOS " + netoString;
                }
                else
                {
                    netoString = ConversorIntString.enletras(Neto.ToString());
                }

                if (quincenaSelected == "No especificar")
                {
                    cabeceraRecibo = ManejoDeImpresion.GenerarEncabezadoRecibo(_empresa.NombreEmpresa, _empresa.CuitEmpresa,
                        convenio, _empresa.DireccionEmpresa, Convert.ToString(_empresa.PostalEmpresa), _empresa.LocalidadEmpresa,
                        _empresa.TelefonoEmpresa, _legajo.NumeroLegajo, _legajo.NombreEmpleado, _legajo.EmpleadoCUIL,
                        _legajo.FechaIngreso, puesto, netoString, UsuarioSingleton.Instance.Meses, mesSelected, añoSelected, false, "");
                }
                else
                {
                    cabeceraRecibo = ManejoDeImpresion.GenerarEncabezadoRecibo(_empresa.NombreEmpresa, _empresa.CuitEmpresa,
                        _legajo.Convenio, _empresa.DireccionEmpresa, Convert.ToString(_empresa.PostalEmpresa), _empresa.LocalidadEmpresa,
                        _empresa.TelefonoEmpresa, _legajo.NumeroLegajo, _legajo.NombreEmpleado, _legajo.EmpleadoCUIL,
                        _legajo.FechaIngreso, _legajo.PuestoRecibo, netoString, UsuarioSingleton.Instance.Meses, mesSelected, añoSelected, true, quincenaSelected);
                }

                List<AliSDatos.Clases.Concepto> detalleRecibo = ManejoDeImpresion.GenerarDetalleMINI(dtDetalle);

                PieRecibo pieRecibo = ManejoDeImpresion.GenerarPieReciboMINI(remunerativo, noRemunerativo, deducciones, Neto, footerText);

                ImprimirRecibo print = new ImprimirRecibo(this, titulo);

                print.EncabezadoList.Add(cabeceraRecibo);
                print.ConcepList = detalleRecibo;
                print.FooterList.Add(pieRecibo);

                print.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnGuardarMenu_Click(object sender, EventArgs e)
        {
            string footerText = string.Format("{0} \n {1} \n {2} \n{3}\n{4} \n Rosario.      {5}   ", tbxLinea1.Text, tbxLinea2.Text, tbxLinea3.Text, tbxLinea4.Text, tbxLinea5.Text, dtpFechaLiquidacion.Text);
            var mesSelected = cboMes.GetItemText(cboMes.SelectedItem);
            var quincenaSelected = cboQuincena.GetItemText(cboQuincena.SelectedItem);
            var añoSelected = cboAño.GetItemText(cboAño.SelectedItem);

            if (!String.IsNullOrEmpty(currentFilePath))
            {
                GuardarXml(footerText, mesSelected, quincenaSelected, añoSelected);
            }
            else
            {
                GuardarXmlComo(footerText, mesSelected, quincenaSelected, añoSelected);
            }

        }

        private void btnAbrirMenu_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                currentFilePath = openFileDialog1.FileName;

                try
                {
                    customXML = ManejoXML.CargarXmlReciboBuilderMINI(currentFilePath);

                    var root = customXML.SelectSingleNode("//A_liq");

                    foreach (XmlNode node in root.ChildNodes)
                    {
                        switch (node.Name)
                        {
                            case "A_liq_año":
                                cboAño.SelectedItem = node.InnerText.ToString();
                                break;
                            case "A_liq_mes":
                                cboMes.SelectedItem = node.InnerText.ToString();
                                break;
                            case "A_liq_quincena":
                                cboQuincena.SelectedItem = node.InnerText.ToString();
                                break;
                            case "A_liq_Puesto":
                                tbxPuesto.Text = node.InnerText.ToString();
                                break;
                            case "A_liq_Convenio":
                                tbxConvenio.Text = node.InnerText.ToString();
                                break;
                            case "A_liq_Detalles":
                                RecuperarConceptosXml(node);
                                break;
                        }
                    }

                    ManejoDeRecibo.CalcularReciboMini(dtDetalle, lblRem, lblNoRem, lblDeducciones, lblNeto, tbxLinea2);

                    btnImprimirMenu.Enabled = true;
                    btnBorrar.Enabled = true;
                    btnGuardarComoMenu.Enabled = true;

                    openFileDialog1.Dispose();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void btnGuardarComoMenu_Click(object sender, EventArgs e)
        {
            string footerText = string.Format("{0} \n {1} \n {2} \n{3}\n{4} \n Rosario.      {5}   ", tbxLinea1.Text, tbxLinea2.Text, tbxLinea3.Text, tbxLinea4.Text, tbxLinea5.Text, dtpFechaLiquidacion.Text);
            var mesSelected = cboMes.GetItemText(cboMes.SelectedItem);
            var quincenaSelected = cboQuincena.GetItemText(cboQuincena.SelectedItem);
            var añoSelected = cboAño.GetItemText(cboAño.SelectedItem);

            GuardarXmlComo(footerText, mesSelected, quincenaSelected, añoSelected);
        }

        private void btnCerrarMenu_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnNuevoMenu_Click(object sender, EventArgs e)
        {
            string[] FechaDepositoSplit = dtpFechaDeposito.Text.Split('/');
            int mesSplit = Convert.ToInt32(FechaDepositoSplit[1]);

            customXML = new XmlDocument();

            dtDetalle.Rows.Clear();

            cboMes.SelectedIndex = 0;
            cboQuincena.SelectedIndex = 0;
            cboAño.SelectedIndex = cboAño.FindStringExact(CURRENT_YEAR);

            tbxConvenio.Text = "";
            tbxPuesto.Text = "";

            lblRem.Text = "------";
            lblNoRem.Text = "------";
            lblDeducciones.Text = "------";
            lblNeto.Text = "------";

            dtpFechaDeposito.Value = DateTime.Now;
            dtpFechaLiquidacion.Value = DateTime.Now;

            tbxLinea2.Text = string.Format("LA CANTIDAD DE PESOS: ----------");
            tbxLinea3.Text = string.Format("Correspondiente a los haberes de:  {0} de {1} según liquidación precedente de la que", UsuarioSingleton.Instance.Meses[1].ToUpper(), CURRENT_YEAR);
            tbxLinea4.Text = string.Format(" recibo duplicado y tomo conocimiento que los aportes jubilatorios del mes de DICIEMBRE de {0},", Convert.ToInt32(CURRENT_YEAR) - 1);
            tbxLinea5.Text = string.Format(" fueron depositados en {0} el {1} de {2} de {3} .", _legajo.Banco.ToUpper(), FechaDepositoSplit[0], UsuarioSingleton.Instance.Meses[mesSplit].ToUpper(), FechaDepositoSplit[2]);

            btnGuardarMenu.Enabled = false;
            btnGuardarComoMenu.Enabled = false;
            btnImprimirMenu.Enabled = false;
        }
        #endregion

        #region METODOS
        private void GuardarXml(string footerText, string mesSelected, string quincenaSelected, string añoSelected)
        {
            string periodo = "";
            this.Text = this.Text + " - Guardando...";

            try
            {
                if (!Directory.Exists(INIT_PATH + "\\Otras liquidaciones"))
                {
                    Directory.CreateDirectory(INIT_PATH + "\\Otras liquidaciones");
                }

                switch (quincenaSelected)
                {
                    case "No especificar":
                        periodo = string.Format("{0} de {1}", UsuarioSingleton.Instance.Meses[Convert.ToInt32(mesSelected)].ToUpper(), añoSelected);
                        break;
                    case "Primera":
                        periodo = string.Format("{0} de {1} (Quincena 1)", UsuarioSingleton.Instance.Meses[Convert.ToInt32(mesSelected)].ToUpper(), añoSelected);
                        break;
                    case "Segunda":
                        periodo = string.Format("{0} de {1} (Quincena 2)", UsuarioSingleton.Instance.Meses[Convert.ToInt32(mesSelected)].ToUpper(), añoSelected);
                        break;
                }

                ManejoXML.GuardarXmlReciboBuilderMini(dgvDetalle, añoSelected, mesSelected, quincenaSelected, currentFilePath, _legajo.NumeroLegajo, _legajo.NombreEmpleado, tbxPuesto.Text.ToUpper(), _legajo.FechaIngreso, tbxConvenio.Text.ToUpper(), periodo, footerText);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                this.Text = this.Text.Replace(" - Guardando...", "");
            }
        }

        private void GuardarXmlComo(string footerText, string mesSelected, string quincenaSelected, string añoSelected)
        {
            string saveFolder;
            string periodo = "";
            this.Text = this.Text + " - Guardando...";

            try
            {
                if (!Directory.Exists(INIT_PATH + "\\Otras liquidaciones"))
                {
                    Directory.CreateDirectory(INIT_PATH + "\\Otras liquidaciones");
                }

                saveFileDialog1.InitialDirectory = Path.GetFullPath(INIT_PATH + "\\Otras liquidaciones");

                if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    saveFolder = saveFileDialog1.FileName;

                    switch (quincenaSelected)
                    {
                        case "No especificar":
                            periodo = string.Format("{0} de {1}", UsuarioSingleton.Instance.Meses[Convert.ToInt32(mesSelected)].ToUpper(), añoSelected);
                            break;
                        case "Primera":
                            periodo = string.Format("{0} de {1} (Quincena 1)", UsuarioSingleton.Instance.Meses[Convert.ToInt32(mesSelected)].ToUpper(), añoSelected);
                            break;
                        case "Segunda":
                            periodo = string.Format("{0} de {1} (Quincena 2)", UsuarioSingleton.Instance.Meses[Convert.ToInt32(mesSelected)].ToUpper(), añoSelected);
                            break;
                    }

                    ManejoXML.GuardarXmlReciboBuilderMini(dgvDetalle, añoSelected, mesSelected, quincenaSelected, saveFolder, _legajo.NumeroLegajo, _legajo.NombreEmpleado, tbxPuesto.Text.ToUpper(), _legajo.FechaIngreso, tbxConvenio.Text.ToUpper(), periodo, footerText);

                    saveFileDialog1.Dispose();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                this.Text = this.Text.Replace(" - Guardando...", "");
            }
        }

        private void RecuperarConceptosXml(XmlNode node)
        {
            try
            {
                foreach (XmlNode n in node.ChildNodes)
                {
                    DataRow row = dtDetalle.NewRow();

                    row["Codigo"] = n["Codigo"].InnerText.ToString();
                    row["Descripcion"] = n["Descripcion"].InnerText.ToString();
                    row["Tipo"] = n["Tipo"].InnerText.ToString();

                    if ((n["Tipo"].InnerText.ToString()) == "RM" || (n["Tipo"].InnerText.ToString() == "NRM"))
                        row["Haberes"] = n["Valor"].InnerText.ToString();
                    else
                        row["Deducciones"] = n["Valor"].InnerText.ToString();

                    dtDetalle.Rows.Add(row);
                }


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
        #endregion

        #region EVENTOS
        private void cboAño_SelectedIndexChanged(object sender, EventArgs e)
        {
            int mesBoxValue = int.Parse(cboMes.Text);
            tbxLinea3.Text = string.Format("Correspondiente a los haberes de:  {0} de {1} según liquidación precedente de la que", UsuarioSingleton.Instance.Meses[mesBoxValue].ToUpper(), cboAño.Text);
            string añoText = cboAño.Text;

            if (mesBoxValue == 1)
            {
                tbxLinea4.Text = string.Format(" recibo duplicado y tomo conocimiento que los aportes jubilatorios del mes de {0} de {1},", UsuarioSingleton.Instance.Meses[12].ToUpper(), int.Parse(añoText) - 1);
            }
            else
            {
                tbxLinea4.Text = string.Format(" recibo duplicado y tomo conocimiento que los aportes jubilatorios del mes de {0} de {1},", UsuarioSingleton.Instance.Meses[mesBoxValue - 1].ToUpper(), cboAño.Text);
            }

        }

        private void cboMes_SelectedIndexChanged(object sender, EventArgs e)
        {
            int mesBoxValue = int.Parse(cboMes.Text);
            string añoText = cboAño.Text;

            tbxLinea3.Text = string.Format("Correspondiente a los haberes de:  {0} de {1} según liquidación precedente de la que", UsuarioSingleton.Instance.Meses[mesBoxValue].ToUpper(), cboAño.Text);

            if (antiBug == 0)
            {
                añoText = CURRENT_YEAR;
                antiBug++;
            }

            if (mesBoxValue == 1)
            {
                tbxLinea4.Text = string.Format(" recibo duplicado y tomo conocimiento que los aportes jubilatorios del mes de {0} de {1},", UsuarioSingleton.Instance.Meses[12].ToUpper(), int.Parse(añoText) - 1);
            }
            else
            {
                tbxLinea4.Text = string.Format(" recibo duplicado y tomo conocimiento que los aportes jubilatorios del mes de {0} de {1},", UsuarioSingleton.Instance.Meses[mesBoxValue - 1].ToUpper(), cboAño.Text);
            }

        }

        private void dtpFechaDeposito_ValueChanged(object sender, EventArgs e)
        {
            string[] PagoPickerSplit = dtpFechaDeposito.Text.Split('/');
            int mesSplit = int.Parse(PagoPickerSplit[1]);

            tbxLinea5.Text = string.Format(" fueron depositados en ---------- el {0} de {1} de {2} .", PagoPickerSplit[0], UsuarioSingleton.Instance.Meses[mesSplit].ToUpper(), PagoPickerSplit[2]);
        }

        private void value_KeyPress(object sender, KeyPressEventArgs e)
        {
            UsuarioSingleton.SoloNumerosYcoma(e);
        }

        private void ReciboBuilderMini_FormClosing(object sender, FormClosingEventArgs e)
        {
            screenReciboBuilder.Enabled = true;
            screenReciboBuilder.Visible = true;
        }

        #endregion

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            UsuarioSingleton.SoloNumerosYcoma(e);
        }
    }
}
