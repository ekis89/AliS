using System;
using System.Collections.Generic;
using System.Data;
using System.Xml;
using System.Windows.Forms;
using AliSlib;
using Recibo;
using Obj;
using System.Globalization;
using AliSLogica.Controladores;
using AliSLogica.Complementarios;
using AliSDatos.Clases;

namespace AliS_WinVer
{
    public partial class PrincipalLiquidaciones : Form
    {
        #region VARIABLES
        IFormatProvider myFormatProvider = new CultureInfo("fr").NumberFormat;

        private Index Index;
        public XmlDocument XMLDocumento;

        private DataTable tablaLegajos;
        public  DataTable dtXML = new DataTable();
        
        public List<string> edit_formulas = new List<string>();         //Guarda formulas de haberes o deducciones fijas.

        public string AñoActual = DateTime.Now.ToString("yyyy");

        public string mesCheck;

        public bool isProfileLoaded = false;
        public bool isSalarioMensual = false;

        #endregion

        #region INICIO
        public PrincipalLiquidaciones(Index Index)
        {
            InitializeComponent();
            this.Index = Index;
            this.Text = "A.li.S: Liquidador de sueldo - " + UsuarioSingleton.Instance.NombreEmpresa;
        }

        private void ReciboBuilder_Load(object sender, EventArgs e)
        {
            tablaLegajos = ControladorReciboBuilder.RecuperarLegajos(UsuarioSingleton.Instance.CuitEmpresa);

            foreach (DataRow dr in tablaLegajos.Rows)
            {
                treLegajosList.Nodes.Add("Nº "+ dr["n_legajo"].ToString() + " - " + dr["nombre"].ToString());
            }

        }
        #endregion

        #region BOTONES
        private void btnLiquidar_Click(object sender, EventArgs e)
        {
            this.Enabled = false;
            GestionLiquidacionConceptos screenLiquidar = new GestionLiquidacionConceptos(this, false);
            screenLiquidar.Show();
        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            int añoSelected = Convert.ToInt32(cboAño.Text);
            int mesSelected = Convert.ToInt32(cboMes.Text);

            string Neto = lblNetoInfo.Text.Replace("$", "");

            string empresaNombre = UsuarioSingleton.Instance.NombreEmpresa;
            string empresaUbicacion = string.Format("{0} - {1} - {2}", UsuarioSingleton.Instance.DireccionEmpresa, UsuarioSingleton.Instance.PostalEmpresa, UsuarioSingleton.Instance.LocalidadEmpresa);
            string mesAnterior;
            string mesActual = string.Format("{0} de {1}", UsuarioSingleton.Instance.Meses[mesSelected].ToUpper(), añoSelected);

            //fecha de deposito(Esta mal el nombre de la variabla pero da pachorra cambiarlo xdxdxd).
            string pagoString = "";
            string[] pagoSplit = lblFechaDepositoInfo.Text.Split('/');

            string fechaLiquidacion = lblFechaLiquidacionInfo.Text;

            string remunerativo = string.Format("{0:0,0.00}", double.Parse(lblHaberesRemInfo.Text.Replace("$", "")));
            string noRemunerativo = string.Format("{0:0,0.00}", double.Parse(lblHaberesNoRemInfo.Text.Replace("$", "")));
            string deducciones = string.Format("{0:0,0.00}", double.Parse(lblDeduccionInfo.Text.Replace("$", "")));
            string sueldoNeto = string.Format("{0:0,0.00}", double.Parse(lblNetoInfo.Text.Replace("$", "")));

            //Arma el string de la fecha de deposito.
            pagoString = ArmarStringFechaDeposito(pagoString, pagoSplit);

            mesAnterior = CalcularMesAnterior(añoSelected, mesSelected);

            CabeceraRecibo cabeceraRecibo = ManejoDeImpresion.GenerarEncabezadoRecibo(UsuarioSingleton.Instance.NombreEmpresa, UsuarioSingleton.Instance.CuitEmpresa,
                UsuarioSingleton.Instance.Convenio, UsuarioSingleton.Instance.DireccionEmpresa,Convert.ToString(UsuarioSingleton.Instance.PostalEmpresa), UsuarioSingleton.Instance.LocalidadEmpresa,
                UsuarioSingleton.Instance.TelefonoEmpresa, UsuarioSingleton.Instance.LegajoNumero, UsuarioSingleton.Instance.NombreEmpleado, UsuarioSingleton.Instance.EmpleadoCUIL,
                UsuarioSingleton.Instance.FechaIngreso, UsuarioSingleton.Instance.PuestoRecibo, ConversorIntString.enletras(lblNetoInfo.Text.Replace("$", "")), UsuarioSingleton.Instance.Meses, mesSelected, añoSelected, false, "");

            List<AliSDatos.Clases.Concepto> detalleRecibo = ManejoDeImpresion.GenerarDetalle(dgvDetallesRecibo);

            PieRecibo pieRecibo = ManejoDeImpresion.GenerarPieRecibo(remunerativo, noRemunerativo, deducciones, sueldoNeto, UsuarioSingleton.Instance.NombreEmpresa,
                UsuarioSingleton.Instance.DireccionEmpresa, cabeceraRecibo.NetoString, mesActual, mesAnterior, UsuarioSingleton.Instance.Banco, pagoString, fechaLiquidacion);

            ImprimirRecibo print = new ImprimirRecibo(this, null);

            print.EncabezadoList.Add(cabeceraRecibo);
            print.ConcepList = detalleRecibo;
            print.FooterList.Add(pieRecibo);

            this.Visible = false;
            print.Show();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            this.Enabled = false;
            GestionLiquidacionConceptos screenLiquidar = new GestionLiquidacionConceptos(this, true);
            screenLiquidar.Show();
        }

        private void btnAbrir_Click(object sender, EventArgs e)
        {
            CargaPerfil();
        }

        private void mnubtnRBMini_Click(object sender, EventArgs e)
        {
            ReciboBuilderMini screenRBMini = new ReciboBuilderMini(this);
            this.Enabled = false;
            this.Visible = false;
            screenRBMini.Show();
        }
        #endregion

        #region EVENTOS
        private void treLegajosList_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            CargaPerfil();
        }

        private void ReciboBuilder_FormClosing(object sender, FormClosingEventArgs e)
        {
            Index.Visible = true;
            this.Dispose();
        }
        private void treLegajosList_AfterSelect(object sender, TreeViewEventArgs e)
        {
            btnAbrir.Enabled = true;
        }
        #endregion

        #region COMBOS
        private void cboAño_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboAño.SelectedIndex != -1)
            {
                XMLDocumento = ManejoXML.CargarXML(UsuarioSingleton.Instance.UserFolder, UsuarioSingleton.Instance.EmpleadoCUIL,
                    UsuarioSingleton.Instance.NombreEmpresa, cboAño, cboMes, dgvDetallesRecibo, btnLiquidar, btnGuardar);

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

        private void cboMes_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboMes.SelectedIndex != -1)
            {
                ManejoDeRecibo.CargarMes(XMLDocumento, dtXML, dgvDetallesRecibo, cboMes, cboQuincena, btnEditar, btnImprimir, btnLiquidar, lblHaberesRemInfo, lblHaberesNoRemInfo,
                    lblDeduccionInfo, lblNetoInfo, lblFechaLiquidacionInfo, lblFechaDepositoInfo, lblOcupacionInfo, lblTipoSalarioInfo, null, null, false, isSalarioMensual);
            }
        }

        private void cboQuincena_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (cboQuincena.SelectedIndex != -1)
            {
                ManejoDeRecibo.CargarQuincena(XMLDocumento, dtXML, dgvDetallesRecibo, cboMes, cboQuincena, btnEditar, btnImprimir, btnLiquidar, lblHaberesRemInfo, lblHaberesNoRemInfo,
                    lblDeduccionInfo, lblNetoInfo, lblFechaLiquidacionInfo, lblFechaDepositoInfo, lblOcupacionInfo, lblTipoSalarioInfo, null, null, false, isSalarioMensual);
            }
            
        }
        #endregion

        #region METODOS
        private void CargaPerfil()
        {
            int treeviewIndex = 0;

            try
            {
                treeviewIndex = treLegajosList.SelectedNode.Index;

                UsuarioSingleton.Instance.NombreEmpleado = tablaLegajos.Rows[treeviewIndex][0].ToString();
                UsuarioSingleton.Instance.EmpleadoCUIL = tablaLegajos.Rows[treeviewIndex][1].ToString();
                UsuarioSingleton.Instance.PuestoRecibo = tablaLegajos.Rows[treeviewIndex][2].ToString();
                UsuarioSingleton.Instance.FechaIngreso = tablaLegajos.Rows[treeviewIndex][3].ToString();
                UsuarioSingleton.Instance.LegajoNumero = tablaLegajos.Rows[treeviewIndex][4].ToString();
                UsuarioSingleton.Instance.TipoSalario = tablaLegajos.Rows[treeviewIndex][5].ToString();
                UsuarioSingleton.Instance.Banco = tablaLegajos.Rows[treeviewIndex][6].ToString();
                UsuarioSingleton.Instance.Convenio = tablaLegajos.Rows[treeviewIndex][7].ToString();

                groupBox1.Visible = true;
                isProfileLoaded = false;
                cboAño.Enabled = true;

                if (lblCUILInfo.Text != UsuarioSingleton.Instance.EmpleadoCUIL)
                {
                    string ingresoDS = UsuarioSingleton.Instance.FechaIngreso;
                    string[] ingresoArray = ingresoDS.Split('/');
                    int ingresoAño = Convert.ToInt32(ingresoArray[2]);

                    nombre.Text = UsuarioSingleton.Instance.NombreEmpleado;
                    lblCUILInfo.Text = UsuarioSingleton.Instance.EmpleadoCUIL;
                    lblOcupacionInfo.Text = UsuarioSingleton.Instance.PuestoRecibo;
                    lblFechaIngresoInfo.Text = UsuarioSingleton.Instance.FechaIngreso;
                    lblLegajoNumInfo.Text = UsuarioSingleton.Instance.LegajoNumero;
                    lblTipoSalarioInfo.Text = UsuarioSingleton.Instance.TipoSalario;

                    cboAño.Items.Clear();

                    for (int ing = ingresoAño; ing <= Convert.ToInt32(AñoActual); ing++)
                    {
                        cboAño.Items.Add(ing.ToString());
                    }

                    if (UsuarioSingleton.Instance.TipoSalario.Equals("Mensual"))
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
            btnGuardar.Enabled = false;
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

        private void calculadorDeAguinaldoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            HistorialRecibos hist_scrn = new HistorialRecibos();

            hist_scrn.Show();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            //XMLDocumento.Save(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) + "/coso.xml");
        }

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
