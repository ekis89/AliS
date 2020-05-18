using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using System.IO;
using AliSlib;
using Obj;
using Recibo;

namespace AliS_WinVer
{
    public partial class ReciboBuilderMini : Form
    {
        public DataTable dtDetalle = new DataTable();
        DataSet DS;
        PrincipalLiquidaciones screenReciboBuilder;
        NumConverter converter = new NumConverter();
        ReciboBuilderMiniTools RBMinitools = new ReciboBuilderMiniTools();
        public string thisYear = DateTime.Now.ToString("yyyy");
        public string empresaCUIT;
        public string empresaNombre;
        public string numeroLegajo;
        public string empleadoNombre;
        public string empleadoCUIL;
        public string empleadoIngreso;

        public string[] meses = new string[] { "Undefined", "Enero", "Febrero", "Marzo", "Abril", "Mayo", "Junio", "Julio", "Agosto", "Septiembre", "Octubre", "Noviembre", "Diciembre" };
        public string initPath;
        int antiBug = 0;

        string empresaDireccion;
        string empresaPostal;
        string empresaLocalidad;
        string empresaTelefono;

        public ReciboBuilderMini(PrincipalLiquidaciones screenReciboBuilder)
        {
            InitializeComponent();
            this.screenReciboBuilder = screenReciboBuilder;
            this.numeroLegajo = UsuarioSingleton.Instance.LegajoNumero;
            this.empleadoNombre = screenReciboBuilder.nombre.Text;
            this.empleadoCUIL = screenReciboBuilder.lblCUILInfo.Text;
            this.empresaCUIT = UsuarioSingleton.Instance.CuitEmpresa;
            this.empresaNombre = UsuarioSingleton.Instance.NombreEmpresa;
            this.empleadoIngreso = screenReciboBuilder.lblFechaIngresoInfo.Text;

            this.initPath = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) + "\\documents\\Alis\\" + empresaNombre + "\\" + empleadoCUIL.Replace("-","");
        }

        private void ReciboBuilderMini_Load(object sender, EventArgs e)
        {
            string linea1;
            string linea2 = string.Format("LA CANTIDAD DE PESOS: ----------");
            string linea3 = string.Format("Correspondiente a los haberes de:  {0} de {1} según liquidación precedente de la que", meses[1].ToUpper(), thisYear);
            string linea4 = string.Format(" recibo duplicado y tomo conocimiento que los aportes jubilatorios del mes de DICIEMBRE de {0},", int.Parse(thisYear)- 1);
            string cmd = string.Format("SELECT direccion , codigo_postal, localidad, telefono FROM Empresas WHERE cuit_empresa = '{0}'",empresaCUIT);
            string[] FechaDepositoSplit = dtpFechaDeposito.Text.Split('/');
            string banco;
            int mesSplit = int.Parse(FechaDepositoSplit[1]);

            DS = Utilidades.alisDB(cmd);

            empresaDireccion = DS.Tables[0].Rows[0][0].ToString();
            empresaPostal = DS.Tables[0].Rows[0][1].ToString();
            empresaLocalidad = DS.Tables[0].Rows[0][2].ToString();
            empresaTelefono = DS.Tables[0].Rows[0][3].ToString();

            linea1 = string.Format(" Recibí de: {0} - con domicilio en {1} - {2} - {3}", UsuarioSingleton.Instance.NombreEmpresa.ToUpper(),empresaDireccion, empresaPostal, empresaLocalidad);

            cmd = string.Format("SELECT banco FROM Legajos WHERE cuit_empresa = '{0}' AND cuil = '{1}'", empresaCUIT, empleadoCUIL);
            DS = Utilidades.alisDB(cmd);

            banco = DS.Tables[0].Rows[0][0].ToString();

            for (int i=1950;i <= int.Parse(thisYear);i++)
            {
                cboAño.Items.Add(i.ToString());
            }
            cboMes.SelectedIndex = cboMes.FindStringExact("1");
            cboQuincena.SelectedIndex = cboQuincena.FindStringExact("No especificar");
            cboAño.SelectedIndex =  cboAño.FindStringExact(thisYear);

            tbxLinea1.Text = linea1;
            tbxLinea2.Text = linea2;
            tbxLinea3.Text = linea3;
            tbxLinea4.Text = linea4;
            tbxLinea5.Text = string.Format(" fueron depositados en {0} el {1} de {2} de {3} .", banco.ToUpper(), FechaDepositoSplit[0], meses[mesSplit].ToUpper(), FechaDepositoSplit[2]);

            dtDetalle.Columns.Add("Codigo");
            dtDetalle.Columns.Add("Descripcion");
            dtDetalle.Columns.Add("Haberes");
            dtDetalle.Columns.Add("Deducciones");
            dtDetalle.Columns.Add("Tipo");

            dgvDetalle.DataSource = dtDetalle;
            dgvDetalle.Columns[0].Width = 85;
            dgvDetalle.Columns[1].Width = 150;
            dgvDetalle.Columns[2].Width = 120;
            dgvDetalle.Columns[3].Width = 120;
            dgvDetalle.Columns[4].Width = 40;
        }

        private void btnAgregarr_Click(object sender, EventArgs e)
        {
            DataRow ConceptoRow = dtDetalle.NewRow();
            string codigo = tbxCodigo.Text;
            string descripcion = tbxDescripcion.Text;
            string valor = tbxValor.Text;
            string tipo;
            double valueDouble = double.Parse(valor);

            ConceptoRow["Codigo"] = "\""+codigo.ToUpper()+"\"";
            ConceptoRow["Descripcion"] = descripcion;

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
            optHabRem.Checked = false;
            optHabNoRem.Checked = false;
            optDeduccion.Checked = false;

            RBMinitools.CalcularRecibo(dtDetalle, lblRem, lblNoRem, lblDeducciones, lblNeto, tbxLinea2);

            if (dgvDetalle.Rows.Count > 0)
            {
                btnGuardar.Enabled = true;
                btnBorrar.Enabled = true;
                btnImprimir.Enabled = true;
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

            RBMinitools.CalcularRecibo(dtDetalle, lblRem, lblNoRem, lblDeducciones, lblNeto, tbxLinea2);

            if (dgvDetalle.Rows.Count < 1)
            {
                btnGuardar.Enabled = false;
                btnBorrar.Enabled = false;
                btnImprimir.Enabled = false;
            }
        }

        private void btnCalculadora_Click(object sender, EventArgs e)
        {
            Calculator frmCalculadora = new Calculator(this);
            this.Enabled = false;
            frmCalculadora.Show();
        }

        private void value_KeyPress(object sender, KeyPressEventArgs e)
        {
            Tools.only_numAndComa(e);
        }

        private void ReciboBuilderMini_FormClosing(object sender, FormClosingEventArgs e)
        {
            screenReciboBuilder.Enabled = true;
            screenReciboBuilder.Visible = true;
        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            //string remunerativo = lblRem.Text;
            //string noRemunerativo = lblNoRem.Text;
            //string deducciones = lblDeducciones.Text;
            //string Neto = lblNeto.Text;
            //var mesSelected = cboMes.GetItemText(cboMes.SelectedItem);
            //var quincenaSelected = cboQuincena.GetItemText(cboQuincena.SelectedItem);

            //List<Header> EncabezadoList = new List<Header>();
            //List<Footer> pieList = new List<Footer>();
            //string Empresa_nombre = empresaNombre;
            //string Empresa_Ubicacion = string.Format("{0} - {1} - {2}", empresaDireccion, empresaPostal, empresaLocalidad);

            //var Año_selected = cboAño.GetItemText(cboAño.SelectedItem);

            ////ENCABEZADO.
            //Header header = new Header();
            //header.Empleado_LegajoNum = string.Format("Nº {0}", numeroLegajo);
            //header.Empresa_Nombre = Empresa_nombre.ToUpper();
            //header.Empresa_Cuit = string.Format("CUIT: {0}", empresaCUIT);
            //header.Empresa_Convenio = string.Format("CONVENIO:     {0}", tbxConvenio.Text.ToUpper());
            //header.Empresa_Ubicacion = string.Format("{0} - {1} - {2}", empresaDireccion, empresaPostal, empresaLocalidad);
            //header.Empresa_Telefono =empresaTelefono;

            //header.Empleado_Nombre = empleadoNombre;
            //header.Empleado_Cuil = string.Format("CUIL: {0}", empleadoCUIL);
            //header.Empleado_Puesto = string.Format("OCUPAC. Y CATEG.:     {0}", tbxPuesto.Text.ToUpper());
            //header.Empleado_Ingreso = string.Format("F.INGRESO:{0}", empleadoIngreso);
            //header.NetoString = converter.enletras(Neto);

            //switch (quincenaSelected)
            //{
            //    case "No especificar":
            //        header.periodo = string.Format("PERIODO LIQUIDADO:   {0} de {1}", meses[Int32.Parse(mesSelected)].ToUpper(), Año_selected);
            //        break;
            //    case "Primera":
            //        header.periodo = string.Format("PERIODO LIQUIDADO:   {0} de {1} (Quincena 1)", meses[Int32.Parse(mesSelected)].ToUpper(), Año_selected);
            //        break;
            //    case "Segunda":
            //        header.periodo = string.Format("PERIODO LIQUIDADO:   {0} de {1} (Quincena 2)", meses[Int32.Parse(mesSelected)].ToUpper(), Año_selected);
            //        break;
            //}
            //EncabezadoList.Add(header);

            ////DETALLE.
            //foreach (DataGridViewRow row in dgvDetalle.Rows)
            //{
            //    Concepto conceptoItem = new Concepto();
            //    int index = dgvDetalle.Rows.IndexOf(row);
            //    string haberList;
            //    string deduccionList;
            //    string haberRow = dgvDetalle.Rows[index].Cells[2].Value.ToString().Replace("$", "");
            //    string deduccionRow = dgvDetalle.Rows[index].Cells[3].Value.ToString().Replace("$", "");


            //    if (haberRow.Length != 0 || haberRow != "")
            //    {
            //        haberList = string.Format("{0:0,0.00}", double.Parse(haberRow));
            //    }
            //    else
            //    {
            //        haberList = "";
            //    }

            //    if (deduccionRow.Length != 0 || deduccionRow != "")
            //    {
            //        deduccionList = string.Format("{0:0,0.00}", double.Parse(deduccionRow));
            //    }
            //    else
            //    {
            //        deduccionList = "";
            //    }

            //    conceptoItem.Descripcion = dgvDetalle.Rows[index].Cells[1].Value.ToString();
            //    conceptoItem.Haberes = haberList;
            //    conceptoItem.Deducciones = deduccionList;

            //    header.Detalle.Add(conceptoItem);
            //}

            ////PIE DE PAGINA.
            //Footer pie = new Footer();
            //pie.TotalRem = remunerativo;
            //pie.TotalNorem = noRemunerativo;
            //pie.TotalDed = "- " + deducciones;
            //pie.TotalNeto = "$ " + Neto;
            ////pie.TotalNeto =  tneto.Text.Replace("$","");
            //pie.footerText = string.Format("{0} \n {1} \n {2} \n{3}\n{4} \n Rosario.      {5}   ", tbxLinea1.Text, tbxLinea2.Text, tbxLinea3.Text, tbxLinea4.Text, tbxLinea5.Text, dtpFechaLiquidacion.Text);

            //pieList.Add(pie);

            //ReciboPrinter print = new ReciboPrinter(null, this);

            //print.EncabezadoList.Add(header);
            //print.ConcepList = header.Detalle;
            //print.FooterList.Add(pie);

            //this.Visible = false;
            //print.Show();

        }

        private void cboAño_SelectedIndexChanged(object sender, EventArgs e)
        {
            int mesBoxValue = int.Parse(cboMes.Text);
            tbxLinea3.Text = string.Format("Correspondiente a los haberes de:  {0} de {1} según liquidación precedente de la que", meses[mesBoxValue].ToUpper(), cboAño.Text);
            string añoText = cboAño.Text;

            if (mesBoxValue == 1)
            {
                tbxLinea4.Text = string.Format(" recibo duplicado y tomo conocimiento que los aportes jubilatorios del mes de {0} de {1},", meses[12].ToUpper(), int.Parse(añoText) - 1);
            }
            else
            {
                tbxLinea4.Text = string.Format(" recibo duplicado y tomo conocimiento que los aportes jubilatorios del mes de {0} de {1},", meses[mesBoxValue - 1].ToUpper(), cboAño.Text);
            }

        }

        private void cboMes_SelectedIndexChanged(object sender, EventArgs e)
        {
            int mesBoxValue = int.Parse(cboMes.Text);
            string añoText = cboAño.Text;

            tbxLinea3.Text = string.Format("Correspondiente a los haberes de:  {0} de {1} según liquidación precedente de la que", meses[mesBoxValue].ToUpper(), cboAño.Text);

            if (antiBug == 0)
            {
                añoText = thisYear;
                antiBug++;
            }

            if (mesBoxValue == 1)
            {
                tbxLinea4.Text = string.Format(" recibo duplicado y tomo conocimiento que los aportes jubilatorios del mes de {0} de {1},", meses[12].ToUpper(), int.Parse(añoText) - 1);
            }
            else
            {
                tbxLinea4.Text = string.Format(" recibo duplicado y tomo conocimiento que los aportes jubilatorios del mes de {0} de {1},", meses[mesBoxValue - 1].ToUpper(), cboAño.Text);
            }
            
        }

        private void dtpFechaDeposito_ValueChanged(object sender, EventArgs e)
        {
            string[] PagoPickerSplit = dtpFechaDeposito.Text.Split('/');
            int mesSplit = int.Parse(PagoPickerSplit[1]);

            tbxLinea5.Text = string.Format(" fueron depositados en ---------- el {0} de {1} de {2} .", PagoPickerSplit[0], meses[mesSplit].ToUpper(), PagoPickerSplit[2]);
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            string saveFolder;
            string periodo = "";
            string footerText = string.Format("{0} \n {1} \n {2} \n{3}\n{4} \n Rosario.      {5}   ", tbxLinea1.Text, tbxLinea2.Text, tbxLinea3.Text, tbxLinea4.Text, tbxLinea5.Text, dtpFechaLiquidacion.Text);
            var mesSelected = cboMes.GetItemText(cboMes.SelectedItem);
            var quincenaSelected = cboQuincena.GetItemText(cboQuincena.SelectedItem);
            var añoSelected = cboAño.GetItemText(cboAño.SelectedItem);

            if (!Directory.Exists(initPath + "\\Otras liquidaciones"))
            {
                Directory.CreateDirectory(initPath + "\\Otras liquidaciones");
            }

            saveFileDialog1.InitialDirectory = Path.GetFullPath(initPath + "\\Otras liquidaciones");

            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                saveFolder = saveFileDialog1.FileName;

                switch (quincenaSelected)
                {
                    case "No especificar":
                        periodo = string.Format("{0} de {1}", meses[Int32.Parse(mesSelected)].ToUpper(), añoSelected);
                        break;
                    case "Primera":
                        periodo = string.Format("{0} de {1} (Quincena 1)", meses[Int32.Parse(mesSelected)].ToUpper(), añoSelected);
                        break;
                    case "Segunda":
                        periodo = string.Format("{0} de {1} (Quincena 2)", meses[Int32.Parse(mesSelected)].ToUpper(), añoSelected);
                        break;
                }

                RBMinitools.saveXML(dgvDetalle, saveFolder, numeroLegajo, empleadoNombre, tbxPuesto.Text.ToUpper(), empleadoIngreso, tbxConvenio.Text.ToUpper(), periodo, footerText);
                MessageBox.Show("Liquidacion guardada con éxito.");
            }
        }

    }
}
