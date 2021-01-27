using System;
using System.Collections.Generic;
using System.Data;
using System.Xml;
using System.Windows.Forms;
using AliSlib;
using System.Globalization;
using AliSLogica.Controladores;
using AliSLogica.Complementarios;
using AliSDatos.Clases;
using System.Runtime.CompilerServices;
using AliS_WinVer.Clases;

namespace AliS_WinVer
{
    public partial class PrincipalLiquidaciones : Form
    {
        #region VARIABLES
        IFormatProvider myFormatProvider = new CultureInfo("fr").NumberFormat;

        private Form Index;
        public XmlDocument XMLDocumento;

        public  DataTable dtXML = new DataTable();

        public string AñoActual = DateTime.Now.ToString("yyyy");

        public bool isProfileLoaded = false;
        public bool isSalarioMensual = false;

        public Legajo _legajo;
        private Empresa _empresa;

        private string tempBanco;
        private string tempConvenio;

        #endregion

        #region INICIO
        public PrincipalLiquidaciones(SelectorLegajo Index, Empresa empresa, Legajo legajo)
        {
            InitializeComponent();
            this.Index = Index;

            this._empresa = empresa;
            this._legajo = legajo;

            this.Text = "Liquidaciones -  Legajo: " + _legajo.NumeroLegajo + " - " + _legajo.NombreEmpleado;

        }

        private void ReciboBuilder_Load(object sender, EventArgs e)
        {
            tempBanco = "";
            tempConvenio = "";

            CargaPerfil();

        }
        #endregion

        #region BOTONES
        private void btnLiquidar_Click(object sender, EventArgs e)
        {
            this.Enabled = false;
            GestionLiquidacionConceptos screenLiquidar = new GestionLiquidacionConceptos(this, _empresa, _legajo, false);


            screenLiquidar.Show();
        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;

            try
            {
                int añoSelected = Convert.ToInt32(cboAño.Text);
                int mesSelected = Convert.ToInt32(cboMes.Text);

                string titulo = String.Format("Imprimir: {0} - {1} - {2}", UsuarioSingleton.Instance.Meses[mesSelected], _empresa.NombreEmpresa, _legajo.NombreEmpleado);

                string Neto = lblNetoInfo.Text.Replace("$", "");

                string empresaNombre = _empresa.NombreEmpresa;
                string empresaUbicacion = string.Format("{0} - {1} - {2}", _empresa.DireccionEmpresa, _empresa.PostalEmpresa, _empresa.LocalidadEmpresa);
                string mesAnterior;
                string mesActual = string.Format("{0} de {1}", UsuarioSingleton.Instance.Meses[mesSelected].ToUpper(), añoSelected);

                //fecha de deposito(Esta mal el nombre de la variabla pero da pachorra cambiarlo xdxdxd).
                string pagoString = "";
                string[] pagoSplit = lblFechaDepositoInfo.Text.Split('/');

                string fechaLiquidacion = lblFechaLiquidacionInfo.Text;

                string puestoRecibo = lblOcupacionInfo.Text;

                string remunerativo = string.Format("{0:0,0.00}", double.Parse(lblHaberesRemInfo.Text.Replace("$", "")));
                string noRemunerativo = string.Format("{0:0,0.00}", double.Parse(lblHaberesNoRemInfo.Text.Replace("$", "")));
                string deducciones = string.Format("{0:0,0.00}", double.Parse(lblDeduccionInfo.Text.Replace("$", "")));
                string sueldoNeto = string.Format("{0:0,0.00}", double.Parse(lblNetoInfo.Text.Replace("$", "")));

                //Arma el string de la fecha de deposito.
                pagoString = ArmarStringFechaDeposito(pagoString, pagoSplit);

                mesAnterior = CalcularMesAnterior(añoSelected, mesSelected);

                CabeceraRecibo cabeceraRecibo;

                if (isSalarioMensual)
                {
                    cabeceraRecibo = ManejoDeImpresion.GenerarEncabezadoRecibo(_empresa.NombreEmpresa, _empresa.CuitEmpresa,
                        tempConvenio, _empresa.DireccionEmpresa, Convert.ToString(_empresa.PostalEmpresa), _empresa.LocalidadEmpresa,
                        _empresa.TelefonoEmpresa, _legajo.NumeroLegajo, _legajo.NombreEmpleado, _legajo.EmpleadoCUIL,
                        _legajo.FechaIngreso, puestoRecibo, ConversorIntString.enletras(lblNetoInfo.Text.Replace("$", "")), UsuarioSingleton.Instance.Meses, mesSelected, añoSelected, false, "");                    

                }
                else
                {
                    string quincenaLiquidada = cboQuincena.Text == "Primera" ? "Primera" : "Segunda";

                    cabeceraRecibo = ManejoDeImpresion.GenerarEncabezadoRecibo(_empresa.NombreEmpresa, _empresa.CuitEmpresa,
                        tempConvenio, _empresa.DireccionEmpresa, Convert.ToString(_empresa.PostalEmpresa), _empresa.LocalidadEmpresa,
                        _empresa.TelefonoEmpresa, _legajo.NumeroLegajo, _legajo.NombreEmpleado, _legajo.EmpleadoCUIL,
                        _legajo.FechaIngreso, _legajo.PuestoRecibo, ConversorIntString.enletras(lblNetoInfo.Text.Replace("$", "")), UsuarioSingleton.Instance.Meses, mesSelected, añoSelected, true, quincenaLiquidada);                    

                }

                List<AliSDatos.Clases.Concepto> detalleRecibo = ManejoDeImpresion.GenerarDetalle(dtXML);

                PieRecibo pieRecibo = ManejoDeImpresion.GenerarPieRecibo(remunerativo, noRemunerativo, deducciones, sueldoNeto, _empresa.NombreEmpresa,
                    _empresa.DireccionEmpresa, ConversorIntString.enletras(lblNetoInfo.Text.Replace("$", "")), mesActual, mesAnterior, tempBanco, pagoString, fechaLiquidacion);                

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
            finally
            {
                Cursor.Current = Cursors.Default;
            }

        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            this.Enabled = false;
            GestionLiquidacionConceptos screenLiquidar = new GestionLiquidacionConceptos(this, _empresa, _legajo, true);
            //screenLiquidar.MdiParent = this.Index.ParentForm;

            screenLiquidar.Show();
        }

        private void mnubtnRBMini_Click(object sender, EventArgs e)
        {
            ReciboBuilderMini screenRBMini = new ReciboBuilderMini(this, _empresa, _legajo);
            this.Enabled = false;
            this.Visible = false;
            screenRBMini.Show();
        }
        #endregion

        #region EVENTOS
        private void ReciboBuilder_FormClosing(object sender, FormClosingEventArgs e)
        {
            int frmLiquidacionesCount = 0;
            Index.Visible = true;

            foreach (Form frm in Application.OpenForms)
            {
                if (frm.Name == "PrincipalLiquidaciones")
                {
                    frmLiquidacionesCount++;
                }
            }

            if(frmLiquidacionesCount <= 1)
            {
                if (Index.GetType() == typeof(SelectorLegajo))
                    (this.MdiParent as Principal).ActivarBotonesTS();
            }

            this.Dispose();
        }
        #endregion

        #region COMBOS
        public void cboAño_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboAño.SelectedIndex != -1)
            {
                XMLDocumento = ManejoXML.CargarXML(UsuarioSingleton.Instance.UserFolder, _legajo.EmpleadoCUIL,
                    _empresa.NombreEmpresa, cboAño, cboMes, dgvDetallesRecibo, btnLiquidar);

                if (XMLDocumento != null)
                {
                    cboMes.SelectedIndex = 0;
                }
                else
                {
                    ResetearCampos();
                }

            }
        }

        public void cboMes_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboMes.SelectedIndex != -1)
            {
                string rta = ManejoDeRecibo.CargarMes(XMLDocumento, dtXML, dgvDetallesRecibo, cboMes, cboQuincena, btnEditar, btnImprimir, btnLiquidar, lblHaberesRemInfo, lblHaberesNoRemInfo,
                    lblDeduccionInfo, lblNetoInfo, lblFechaLiquidacionInfo, lblFechaDepositoInfo, lblOcupacionInfo, lblTipoSalarioInfo, null, null, ref tempBanco, ref tempConvenio, false, isSalarioMensual);

                switch (rta)
                {
                    case "nuevo":
                        isSalarioMensual = _legajo.TipoSalario.Equals("Mensual") ? true : false;

                        if (isSalarioMensual)
                        {
                            cboQuincena.Enabled = false;
                            cboQuincena.SelectedIndex = -1;
                        }
                        else
                        {
                            cboQuincena.Enabled = true;
                        }

                        btnLiquidar.Enabled = true;

                        break;
                    case "salarioMensual":
                        isSalarioMensual = true;
                        break;
                    case "salarioQuincenal":
                        isSalarioMensual = false;
                        break;
                }
            }
        }

        public void cboQuincena_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (cboQuincena.SelectedIndex != -1)
            {
                ManejoDeRecibo.CargarQuincena(XMLDocumento, dtXML, dgvDetallesRecibo, cboMes, cboQuincena, btnEditar, btnImprimir, btnLiquidar, lblHaberesRemInfo, lblHaberesNoRemInfo,
                    lblDeduccionInfo, lblNetoInfo, lblFechaLiquidacionInfo, lblFechaDepositoInfo, lblOcupacionInfo, lblTipoSalarioInfo, null, null, ref tempBanco, ref tempConvenio, false, isSalarioMensual);

                btnLiquidar.Enabled = _legajo.TipoSalario == "Mensual" ? false : true;
            }
            else
            {
                btnLiquidar.Enabled = false;
            }
            
        }
        #endregion

        #region METODOS
        private void CargaPerfil()
        {

            try
            {
                _legajo.CurrentUserXmlFolder = string.Format("{0}\\{1}\\{2}\\", UsuarioSingleton.Instance.AlisFolder, _empresa.NombreEmpresa, _legajo.EmpleadoCUIL.Replace("-", ""));
                
                UsuarioSingleton.Instance._Legajo = _legajo.Clone() as Legajo;

                groupBox1.Visible = true;
                isProfileLoaded = false;
                cboAño.Enabled = true;

                if (lblCUILInfo.Text != _legajo.EmpleadoCUIL)
                {
                    string ingresoDS = _legajo.FechaIngreso;
                    string[] ingresoArray = ingresoDS.Split('/');
                    int ingresoAño = Convert.ToInt32(ingresoArray[2]);

                    nombre.Text = _legajo.NombreEmpleado;
                    lblCUILInfo.Text = _legajo.EmpleadoCUIL;
                    lblOcupacionInfo.Text = _legajo.PuestoRecibo;
                    lblFechaIngresoInfo.Text = _legajo.FechaIngreso;
                    lblLegajoNumInfo.Text = _legajo.NumeroLegajo;
                    lblTipoSalarioInfo.Text = _legajo.TipoSalario;

                    cboAño.Items.Clear();

                    for (int ing = ingresoAño; ing <= Convert.ToInt32(AñoActual); ing++)
                    {
                        cboAño.Items.Add(ing.ToString());
                    }

                    if (_legajo.TipoSalario.Equals("Mensual"))
                    {
                        isSalarioMensual = true;
                    }
                    else
                    {
                        isSalarioMensual = false;
                    }
                }

                isProfileLoaded = true;

                menuStrip1.Items[1].Enabled = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }

        private void ResetearCampos()
        {
            dtXML.Clear();
            dgvDetallesRecibo.Rows.Clear();
            dgvDetallesRecibo.Columns.Clear();

            lblFechaLiquidacionInfo.Text = "--/--/----";
            lblFechaDepositoInfo.Text = "--/--/----";

            lblHaberesRemInfo.Text = "$00.00";
            lblHaberesNoRemInfo.Text = "$00.00";
            lblDeduccionInfo.Text = "$00.00";
            lblNetoInfo.Text = "$00.00";

            cboAño.SelectedIndex = -1;
            cboMes.SelectedIndex = -1;
            cboMes.Enabled = false;

            btnLiquidar.Visible = false;
            btnEditar.Visible = false;
            btnImprimir.Enabled = false;
        }

        private static string ArmarStringFechaDeposito(string pagoString, string[] pagoSplit)
        {
            for (int i = 0; i < 3; i++)
            {
                if (i == 1)
                {
                    int index = Int16.Parse(pagoSplit[1]);
                    pagoString = pagoString + " de " + UsuarioSingleton.Instance.Meses[index].ToUpper() + " de ";
                }
                else
                {
                    pagoString = pagoString + pagoSplit[i];
                }
            }

            return pagoString;
        }

        private static string CalcularMesAnterior(int añoSelected, int mesSelected)
        {
            string mesAnterior;

            if (UsuarioSingleton.Instance.Meses[mesSelected] == "Enero")
            {
                mesAnterior = string.Format("{0} de {1}", UsuarioSingleton.Instance.Meses[12].ToUpper(), añoSelected - 1);
            }
            else
            {
                mesAnterior = string.Format("{0} de {1}", UsuarioSingleton.Instance.Meses[mesSelected - 1].ToUpper(), añoSelected);
            }

            return mesAnterior;
        }

        #endregion

        private void mnubtnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }

    #region DIALOG MODIFICAR CANTIDADES
    public class Prompt
    {
        public static string ShowDialog(string text, string caption)
        {
            //Crea una "ventana" (formulario).
            Form prompt = new Form()
            {
                Width = 200,
                Height = 150,
                FormBorderStyle = FormBorderStyle.FixedDialog,
                Text = caption,
                MaximizeBox = false,
                MinimizeBox = false,
                StartPosition = FormStartPosition.CenterScreen
            };

            //Crea los controles del formulario.
            Label textLabel = new Label() { Left = 30, Top = 32, Text = text, Width = 55 };
            TextBox textBox = new TextBox() { Left = 85, Top = 30, Width = 50, MaxLength = 4 };
            Button confirmation = new Button() { Text = "Aceptar", Left = 55, Width = 75, Top = 70, DialogResult = DialogResult.OK };
            confirmation.Click += (sender, e) => { prompt.Close(); };
            textBox.KeyPress += (sender, e) => {  UsuarioSingleton.SoloNumeros(e); };
            //Agrega los controles al formulario.
            prompt.Controls.Add(textBox);
            prompt.Controls.Add(confirmation);
            prompt.Controls.Add(textLabel);
            prompt.AcceptButton = confirmation;

            return prompt.ShowDialog() == DialogResult.OK ? textBox.Text : "";
        }
    }
    #endregion
}
