using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml;

namespace AliSLogica.Complementarios
{
    public class ManejoDeRecibo
    {
        #region Variables (las usa ReciboBuilder)
        private static bool isSalarioMensual = false;
        private static string XMLcurrentFolder;
        private static string EmpresaFolderName;
        private static string[] meses = new string[] { "Undefined", "Enero", "Febrero", "Marzo", "Abril", "Mayo", "Junio", "Julio", "Agosto", "Septiembre", "Octubre", "Noviembre", "Diciembre" };

        private static IFormatProvider myFormatProvider = new CultureInfo("fr").NumberFormat;
        #endregion

        #region RECIBO BUILDER CARGAR RECIBO
        public static string CargarMes(XmlDocument xmlDocumento, DataTable dtXML, DataGridView dgvDetalles, ComboBox cboMes, ComboBox cboQuincena, Button btnEditar, Button btnImprimir, Button btnLiquidar,
           Label lblRemInfo, Label lblNoRemInfo, Label lblDeduccionesInfo, Label lblNetoInfo, Label lblFechaLiquidacionIfo, Label lblFechaDepositoInfo, Label lblOcupacionInfo, Label lblTipoSalarioInfo,
           DateTimePicker dtpFechaLiquidacion, DateTimePicker dtpFechaDeposito, ref string tempBanco, ref string tempConvenio, bool isEditMode, bool isSalarioMensual)
        {
            string mesSelected = cboMes.GetItemText(cboMes.SelectedItem);
            string TipoLiquidacion = "";

            int mesesIndex = int.Parse(mesSelected);

            string rta = "";

            XmlElement root = xmlDocumento.DocumentElement;
            XmlNode CheckNode = root.SelectSingleNode("//Liquidaciones//" + meses[mesesIndex]);
            XmlNodeList nodes = null;

            if (xmlDocumento == null || xmlDocumento.ChildNodes.Count < 1)
            {
                tempBanco = "";
                tempConvenio = "";

                return "nuevo";
            }

            if (CheckNode == null)
            {
                btnEditar.Enabled = false;
                btnEditar.Visible = false;
                btnImprimir.Enabled = false;

                btnLiquidar.Enabled = true;
                btnLiquidar.Visible = true;

                dtXML.Clear();
                dgvDetalles.Rows.Clear();
                dgvDetalles.Columns.Clear();

                lblRemInfo.Text = "$00.00";
                lblNoRemInfo.Text = "$00.00";
                lblDeduccionesInfo.Text = "$00.00";
                lblNetoInfo.Text = "$00.00";
                lblFechaLiquidacionIfo.Text = "--/--/--";
                lblFechaDepositoInfo.Text = "--/--/--";
                lblOcupacionInfo.Text = "- - - - - - - - - - - - - ";
                lblTipoSalarioInfo.Text = "- - - - - - - - - - - - - ";

                if (!isSalarioMensual)
                {
                    cboQuincena.Enabled = true;
                    cboQuincena.SelectedIndex = 0;
                }
                else
                {
                    cboQuincena.Enabled = false;
                    cboQuincena.SelectedIndex = -1;
                }

                tempBanco = "";
                tempConvenio = "";

                return "nuevo";
            }
            else
            {
                TipoLiquidacion = CheckNode.Attributes["Tipo"].Value;

                btnLiquidar.Enabled = false;
                btnLiquidar.Visible = false;

                btnEditar.Enabled = true;
                btnEditar.Visible = true;
                btnImprimir.Enabled = true;

                if (TipoLiquidacion == "mensual")
                {
                    cboQuincena.Enabled = false;
                    cboQuincena.SelectedIndex = -1;

                    lblOcupacionInfo.Text = CheckNode.Attributes["Puesto"].Value.ToString();
                    lblFechaLiquidacionIfo.Text = CheckNode.Attributes["Fecha_de_liquidacion"].Value.ToString();
                    lblFechaDepositoInfo.Text = CheckNode.Attributes["Pago"].Value.ToString();
                    lblTipoSalarioInfo.Text = CheckNode.Attributes["Tipo"].Value.ToString();

                    nodes = root.SelectNodes("//Liquidaciones/" + meses[mesesIndex] + "/Concepto");

                    rta = "salarioMensual";
                }
                else if (TipoLiquidacion == "quincenal")
                {
                    cboQuincena.Enabled = true;
                    cboQuincena.SelectedIndex = 0;

                    return "salarioQuincenal";
                }
            }

            //Data Table CLEAR.
            dtXML.Clear();

            if (dtXML.Columns.Count != 13)
            {
                dtXML.Columns.Add("codigo");
                dtXML.Columns.Add("descripcion");
                dtXML.Columns.Add("hab_fijo");
                dtXML.Columns.Add("hab_porc");
                dtXML.Columns.Add("ded_fijo");
                dtXML.Columns.Add("ded_porc");
                dtXML.Columns.Add("tipo");
                dtXML.Columns.Add("modo");
                dtXML.Columns.Add("formula_porc");
                dtXML.Columns.Add("unidades");
                dtXML.Columns.Add("total");
                dtXML.Columns.Add("resultado");
                dtXML.Columns.Add("codigoConceptoPorEmpresa");
            }

            foreach (XmlNode node in nodes)
            {
                DataRow row = dtXML.NewRow();

                row["codigo"] = (node as XmlElement).GetAttribute("Codigo");
                row["descripcion"] = (node as XmlElement).GetAttribute("Descripcion");
                row["hab_fijo"] = (node as XmlElement).GetAttribute("hab_fijo");
                row["hab_porc"] = (node as XmlElement).GetAttribute("hab_porc");
                row["ded_fijo"] = (node as XmlElement).GetAttribute("ded_fijo");
                row["ded_porc"] = (node as XmlElement).GetAttribute("ded_porc");
                row["tipo"] = (node as XmlElement).GetAttribute("tipo");
                row["modo"] = (node as XmlElement).GetAttribute("modo");
                row["formula_porc"] = (node as XmlElement).GetAttribute("formula_porc");
                row["unidades"] = (node as XmlElement).GetAttribute("unidades");
                row["codigoConceptoPorEmpresa"] = (node as XmlElement).GetAttribute("codigoConceptoPorEmpresa");

                dtXML.Rows.Add(row);
            }


            CalcularTabla(dtXML);

            DrawTabla(dtXML, dgvDetalles, isEditMode);

            CalcularTotales(dtXML, dgvDetalles, lblRemInfo, lblNoRemInfo, lblDeduccionesInfo, lblNetoInfo);

            tempBanco = CheckNode.Attributes["Banco"].Value.ToString();
            tempConvenio = CheckNode.Attributes["Convenio"].Value.ToString();

            return rta;
        }

        public static string CargarQuincena(XmlDocument xmlDocumento, DataTable dtXML, DataGridView dgvDetalles, ComboBox cboMes, ComboBox cboQuincena, Button btnEditar, Button btnImprimir,
            Button btnLiquidar, Label lblRemInfo, Label lblNoRemInfo, Label lblDeduccionesInfo, Label lblNetoInfo, Label lblFechaLiquidacionIfo, Label lblFechaDepositoInfo, Label lblOcupacionInfo,
            Label lblTipoSalarioInfo, DateTimePicker dtpFechaLiquidacion, DateTimePicker dtpFechaDeposito, ref string tempBanco, ref string tempConvenio, bool isEditMode, bool isSalarioMensual)
        {

            string quincenaSelectedString = "";
            string mesSelected = cboMes.GetItemText(cboMes.SelectedItem);
            int quincenaSelected = cboQuincena.SelectedIndex;
            int mesesIndex = Convert.ToInt32(mesSelected);
            XmlNode mesQuincenaInfo = null;
            XmlNode CheckNode = null;
            XmlNodeList nodes = null;

            if (xmlDocumento == null || xmlDocumento.ChildNodes.Count < 1)
            {
                tempBanco = "";
                tempConvenio = "";

                return "";
            }

            XmlElement root = xmlDocumento.DocumentElement;

            mesQuincenaInfo = root.SelectSingleNode("//Liquidaciones//" + meses[mesesIndex]);

            if (quincenaSelected == 0)
            {
                quincenaSelectedString = "//Liquidaciones//" + meses[mesesIndex] + "/Quincena_1";
                CheckNode = root.SelectSingleNode(quincenaSelectedString);
            }
            else if (quincenaSelected == 1)
            {
                quincenaSelectedString = "//Liquidaciones//" + meses[mesesIndex] + "/Quincena_2";
                CheckNode = root.SelectSingleNode(quincenaSelectedString);
            }

            if (CheckNode == null)
            {
                btnEditar.Enabled = false;
                btnEditar.Visible = false;
                btnImprimir.Enabled = false;

                btnLiquidar.Enabled = true;
                btnLiquidar.Visible = true;

                dtXML.Clear();
                dgvDetalles.Rows.Clear();
                dgvDetalles.Columns.Clear();

                lblRemInfo.Text = "$00.00";
                lblNoRemInfo.Text = "$00.00";
                lblDeduccionesInfo.Text = "$00.00";
                lblNetoInfo.Text = "$00.00";
                lblFechaLiquidacionIfo.Text = "--/--/--";
                lblFechaDepositoInfo.Text = "--/--/--";
                lblOcupacionInfo.Text = "- - - - - - - - - - - - - ";
                lblTipoSalarioInfo.Text = "- - - - - - - - - - - - - ";

                tempBanco = "";
                tempConvenio = "";

                return "";
            }
            else
            {
                btnLiquidar.Enabled = false;
                btnLiquidar.Visible = false;

                btnEditar.Enabled = true;
                btnEditar.Visible = true;
                btnImprimir.Enabled = true;

                lblOcupacionInfo.Text = CheckNode.Attributes["Puesto"].Value.ToString(); 
                lblFechaLiquidacionIfo.Text = CheckNode.Attributes["Fecha_de_liquidacion"].Value.ToString();
                lblFechaDepositoInfo.Text = CheckNode.Attributes["Pago"].Value.ToString();
                lblTipoSalarioInfo.Text = root.SelectSingleNode("//Liquidaciones//" + meses[mesesIndex]).Attributes["Tipo"].Value.ToString();

                tempBanco = CheckNode.Attributes["Banco"].Value.ToString();
                tempConvenio = CheckNode.Attributes["Convenio"].Value.ToString();

                nodes = root.SelectNodes(quincenaSelectedString + "/Concepto");
            }

            //Data Table CLEAR.
            dtXML.Clear();

            if (dtXML.Columns.Count != 13)
            {
                dtXML.Columns.Add("codigo");
                dtXML.Columns.Add("descripcion");
                dtXML.Columns.Add("hab_fijo");
                dtXML.Columns.Add("hab_porc");
                dtXML.Columns.Add("ded_fijo");
                dtXML.Columns.Add("ded_porc");
                dtXML.Columns.Add("tipo");
                dtXML.Columns.Add("modo");
                dtXML.Columns.Add("formula_porc");
                dtXML.Columns.Add("unidades");
                dtXML.Columns.Add("total");
                dtXML.Columns.Add("resultado");
                dtXML.Columns.Add("codigoConceptoPorEmpresa");
            }

            foreach (XmlNode node in nodes)
            {
                DataRow row = dtXML.NewRow();

                row["codigo"] = (node as XmlElement).GetAttribute("Codigo");
                row["descripcion"] = (node as XmlElement).GetAttribute("Descripcion");
                row["hab_fijo"] = (node as XmlElement).GetAttribute("hab_fijo");
                row["hab_porc"] = (node as XmlElement).GetAttribute("hab_porc");
                row["ded_fijo"] = (node as XmlElement).GetAttribute("ded_fijo");
                row["ded_porc"] = (node as XmlElement).GetAttribute("ded_porc");
                row["tipo"] = (node as XmlElement).GetAttribute("tipo");
                row["modo"] = (node as XmlElement).GetAttribute("modo");
                row["formula_porc"] = (node as XmlElement).GetAttribute("formula_porc");
                row["unidades"] = (node as XmlElement).GetAttribute("unidades");
                row["codigoConceptoPorEmpresa"] = (node as XmlElement).GetAttribute("codigoConceptoPorEmpresa");

                dtXML.Rows.Add(row);
            }

            CalcularTabla(dtXML);

            DrawTabla(dtXML, dgvDetalles, isEditMode);

            CalcularTotales(dtXML, dgvDetalles, lblRemInfo, lblNoRemInfo, lblDeduccionesInfo, lblNetoInfo);

            tempBanco = CheckNode.Attributes["Banco"].Value.ToString();
            tempConvenio = CheckNode.Attributes["Convenio"].Value.ToString();

            return "";

        }
        #endregion

        #region RECIBO BUILDER LIQUIDAR
        public static DataTable Liquidar(string userFolder, int codigoEmpresa, string numeroLegajo, XmlDocument Documento, bool SalarioMensualCheck, string empresaCUIT, string añoSeleccionado, string mesSeleccionado, string quincenaSeleccionada, string empleadoCUIL, string empresaNombre, bool forzarDesdeDB)
        {
            try
            {
                string cuilSelected = empleadoCUIL.Replace("-", "");

                EmpresaFolderName = empresaNombre;
                isSalarioMensual = SalarioMensualCheck;

                XMLcurrentFolder = string.Format("{0}\\documents\\Alis\\{1}\\{2}\\", userFolder, EmpresaFolderName, cuilSelected);

                string curFile = string.Format("{0}\\{1}.xml", XMLcurrentFolder, añoSeleccionado);

                if (isSalarioMensual)
                {
                    if (quincenaSeleccionada != "")
                    {
                        DataTable rtaError = new DataTable();
                        rtaError.Columns.Add("rta");
                        rtaError.Rows.Add("Error: No se puede liquidar por quincena si el puesto actual esta mensualizado.");

                        return rtaError;
                    }
                    else
                    {
                        return LiquidarModoMensual(Documento, codigoEmpresa, numeroLegajo, Convert.ToInt32(mesSeleccionado), añoSeleccionado, forzarDesdeDB);
                    }
                }
                else
                {
                    return LiquidarModoQuincenal(Documento, codigoEmpresa, numeroLegajo, empleadoCUIL, empresaNombre, empresaCUIT, Convert.ToInt32(mesSeleccionado), quincenaSeleccionada, añoSeleccionado, forzarDesdeDB);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        //TODO: 12/09 : Recodar revisar los metodos LiquidarModoMensual y LiquidarModoQuincena, que mande fruta para poder compilar.

        private static DataTable LiquidarModoMensual(XmlDocument Documento, int codigoEmpresa, string numeroLegajo, int mesesIndex, string añoSelected, bool forzarDesdeDB)
        {
            string curFile = string.Format("{0}\\{1}.xml", XMLcurrentFolder, añoSelected);
            string curFileMinusOne = string.Format("{0}\\{1}.xml", XMLcurrentFolder, int.Parse(añoSelected) - 1);

            XmlElement CurrentRoot = Documento.DocumentElement;
            var CheckNode = CurrentRoot.SelectSingleNode("//Liquidaciones/" + meses[mesesIndex - 1]);

            if (mesesIndex == 1)
            {
                if (File.Exists(curFileMinusOne))
                {
                    XmlDocument añoAnteriorXML = new XmlDocument();
                    añoAnteriorXML.Load(curFileMinusOne);

                    XmlElement root = añoAnteriorXML.DocumentElement;

                    var decemberNode = root.SelectSingleNode("//Liquidaciones/" + meses[12]);

                    if ((decemberNode == null) || (decemberNode.Attributes["Tipo"].Value == "quincenal") || (decemberNode.Attributes["Tipo"].Value != "mensual") || forzarDesdeDB)
                    {
                        return GenerarDesdeBD(codigoEmpresa, numeroLegajo);
                    }
                    else
                    {
                        return GenerarDesdeXML(decemberNode);
                    }
                }
                else
                {
                    return GenerarDesdeBD(codigoEmpresa, numeroLegajo);
                }
            }
            else
            {
                if ((CheckNode == null) || (CheckNode.Attributes["Tipo"].Value == "quincenal") || (CheckNode.Attributes["Tipo"].Value != "mensual") || forzarDesdeDB)
                {
                    return GenerarDesdeBD(codigoEmpresa, numeroLegajo);
                }
                else
                {
                    return GenerarDesdeXML(CheckNode);
                }
            }
        }

        private static DataTable LiquidarModoQuincenal(XmlDocument Documento, int codigoEmpresa, string numeroLegajo, string empleadoCUIL, string empresaNombre, string empresaCUIT, int mesesIndex, string quincenaSelected, string añoSelected, bool forzarDesdeDB)
        {
            string curFile = string.Format("{0}\\{1}.xml", XMLcurrentFolder, añoSelected);
            string curFileMinusOne = string.Format("{0}\\{1}.xml", XMLcurrentFolder, int.Parse(añoSelected) - 1);

            XmlElement CurrentRoot = Documento.DocumentElement;
            var CheckNode = CurrentRoot.SelectSingleNode("//Liquidaciones/" + meses[mesesIndex - 1]);

            if (mesesIndex == 1)
            {
                if (File.Exists(curFileMinusOne))
                {
                    XmlDocument añoAnteriorXML = new XmlDocument();
                    añoAnteriorXML.Load(curFileMinusOne);

                    XmlElement root = añoAnteriorXML.DocumentElement;

                    var decemberNode = root.SelectSingleNode("//Liquidaciones/" + meses[12]);

                    if ((decemberNode == null) || (decemberNode.Attributes["Tipo"].Value == "mensual") || (decemberNode.Attributes["Tipo"].Value != "quincenal") || forzarDesdeDB)
                    {
                        return GenerarDesdeBD(codigoEmpresa, numeroLegajo);
                    }
                    else
                    {
                        return GenerarQuincena(root, codigoEmpresa, numeroLegajo, CurrentRoot, mesesIndex, quincenaSelected, true);
                    }

                }
                else
                {
                    //TODO: Revisar esta nota, no se cuando la puse y no se si resolvi el problema.
                    // SEGUIR DESDE ACA, TIENE QUE FIJARSE SI LA QUINCENA 1 DE ENERO ES NULL, SI NO ES NULL TIENE QUE SACAR LOS DATOS DE AHI, DEBERIA HACER UN METODO CON LO 
                    // QUE ESTA EN EL ELSE DE LA LINEA 633.
                    return GenerarQuincena(null, codigoEmpresa, numeroLegajo, CurrentRoot, mesesIndex, quincenaSelected, true);

                }

            }
            else
            {

                if ((CheckNode == null) || (CheckNode.Attributes["Tipo"].Value == "mensual") || (CheckNode.Attributes["Tipo"].Value != "quincenal"))
                {
                    return GenerarDesdeBD(codigoEmpresa, numeroLegajo);
                }
                else
                {
                    return GenerarQuincena(null, codigoEmpresa, numeroLegajo, CurrentRoot, mesesIndex, quincenaSelected, false);
                }
            }

        }

        private static DataTable GenerarQuincena(XmlElement anoAnteriorRoot, int codigoEmpresa, string numeroLegajo, XmlElement CurrentRoot, int mesesIndex, string quincenaSelected, bool isEnero)
        {
            XmlNode quincenaNode;

            if (isEnero)
            {
                if (quincenaSelected == "Primera")
                {
                    if (anoAnteriorRoot == null)
                    {
                        quincenaNode = null;
                    }
                    else
                    {
                        quincenaNode = anoAnteriorRoot.SelectSingleNode(String.Format("//Liquidaciones/{0}/Quincena_2", meses[12]));
                    }

                }
                else
                {
                    quincenaNode = CurrentRoot.SelectSingleNode(String.Format("//Liquidaciones/{0}/Quincena_1", meses[mesesIndex]));
                }

            }
            else
            {
                if (quincenaSelected == "Primera")
                {
                    quincenaNode = CurrentRoot.SelectSingleNode(String.Format("//Liquidaciones/{0}/Quincena_2", meses[mesesIndex - 1]));
                }
                else
                {
                    quincenaNode = CurrentRoot.SelectSingleNode(String.Format("//Liquidaciones/{0}/Quincena_1", meses[mesesIndex]));
                }
            }

            if (quincenaNode == null)
            {
                return GenerarDesdeBD(codigoEmpresa, numeroLegajo);

            }
            else
            {
                return GenerarDesdeXML(quincenaNode);
            }

        }

        public static string GenerarFechaLiquidacion(string mesSeleccionado, string quincenaSeleccionada, string añoSeleccionado, bool isSalarioMensual)
        {
            string momento;
            int mesMasUno = 0;
            int LastDayInMont = DateTime.DaysInMonth(Convert.ToInt32(añoSeleccionado), Convert.ToInt32(mesSeleccionado));

            DateTime dateTimeValue = new DateTime(Convert.ToInt32(añoSeleccionado), Convert.ToInt32(mesSeleccionado), LastDayInMont);

            if (!isSalarioMensual)
            {
                if (quincenaSeleccionada == "Primera")
                {
                    DateTime dateTimeValueQuincena = new DateTime(Convert.ToInt32(añoSeleccionado), Convert.ToInt32(mesSeleccionado), 19);

                    if (dateTimeValue.ToString("dddd") == "domingo")
                    {
                        DateTime dateTimeString = new DateTime(Convert.ToInt32(añoSeleccionado) + 1, Convert.ToInt32(mesSeleccionado), 20);
                        momento = dateTimeString.ToShortDateString();
                    }
                    else
                    {
                        momento = dateTimeValueQuincena.ToShortDateString();
                    }
                }
                else
                {
                    if (dateTimeValue.ToString("dddd") == "domingo")
                    {
                        if (mesSeleccionado == "12")
                        {
                            DateTime dateTimeString = new DateTime(Convert.ToInt32(añoSeleccionado) + 1, 1, 2);
                            momento = dateTimeString.ToShortDateString();
                        }
                        else
                        {
                            mesMasUno = Convert.ToInt32(mesSeleccionado) + 1;
                            DateTime dateTimeString = new DateTime(Convert.ToInt32(añoSeleccionado), mesMasUno, 1);
                            momento = dateTimeString.ToShortDateString();
                        }
                    }
                    else
                    {
                        DateTime dateTimeString = new DateTime(Convert.ToInt32(añoSeleccionado), Convert.ToInt32(mesSeleccionado), LastDayInMont);
                        momento = dateTimeString.ToShortDateString();
                    }
                }
            }
            else                 //    ----- IF MENSUAL ----- //
            {
                if (dateTimeValue.ToString("dddd") == "domingo")
                {
                    if (mesSeleccionado == "12")
                    {
                        DateTime dateTimeString = new DateTime(Convert.ToInt32(añoSeleccionado) + 1, 1, 2);
                        momento = dateTimeString.ToShortDateString();
                    }
                    else
                    {
                        mesMasUno = Convert.ToInt32(mesSeleccionado) + 1;
                        DateTime dateTimeString = new DateTime(Convert.ToInt32(añoSeleccionado), mesMasUno, 1);
                        momento = dateTimeString.ToShortDateString();
                    }
                }
                else
                {
                    DateTime dateTimeString = new DateTime(Convert.ToInt32(añoSeleccionado), Convert.ToInt32(mesSeleccionado), LastDayInMont);
                    momento = dateTimeString.ToShortDateString();
                }
            }

            return momento;

        }
       
        // TODO: 12/09: Aca tengo que cambiar el hab_fijo de Basico que tiene PUESTO y ponerle el monto en numero
        public static DataTable GenerarDesdeBD(int codigoEmpresa, string numeroLegajo)
        {
            DataTable tablaCodigosConcepto = Controladores.ControladorConcepto.RecuperarListaCodigosConceptosPorCodigoEmpresaYNumeroLegajo(codigoEmpresa, numeroLegajo);

            DataTable tablaConceptos = Controladores.ControladorConcepto.RecuperarConceptosPorListaConceptosCodigoEmpresaYNumeroLegajo(tablaCodigosConcepto, codigoEmpresa, numeroLegajo);

            tablaConceptos.Columns.Add("unidades");
            tablaConceptos.Columns.Add("total");
            tablaConceptos.Columns.Add("resultado");

            DataRow basicoRow = tablaConceptos.Select("tipo Like 'BAS'").FirstOrDefault();
            DataRow newBasicoRow = tablaConceptos.NewRow();
            newBasicoRow.ItemArray = basicoRow.ItemArray.Clone() as object[];

            int indexBasicoRow = tablaConceptos.Rows.IndexOf(basicoRow);

            tablaConceptos.Rows.RemoveAt(indexBasicoRow);
            tablaConceptos.Rows.InsertAt(newBasicoRow, 0);

            foreach (DataRow row in tablaConceptos.Rows)
            {
                row["unidades"] = 1;
                row["total"] = 0;
                row["resultado"] = 0;
            }

            tablaConceptos.AcceptChanges();

            return tablaConceptos;
        }

        private static DataTable GenerarDesdeXML(XmlNode NodoActual)
        {
            DataTable dtTablaConceptos = new DataTable();

            if (dtTablaConceptos.Columns.Count != 13)
            {
                dtTablaConceptos.Columns.Add("codigo");
                dtTablaConceptos.Columns.Add("descripcion");
                dtTablaConceptos.Columns.Add("hab_fijo");
                dtTablaConceptos.Columns.Add("hab_porc");
                dtTablaConceptos.Columns.Add("ded_fijo");
                dtTablaConceptos.Columns.Add("ded_porc");
                dtTablaConceptos.Columns.Add("tipo");
                dtTablaConceptos.Columns.Add("modo");
                dtTablaConceptos.Columns.Add("formula_porc");
                dtTablaConceptos.Columns.Add("unidades");
                dtTablaConceptos.Columns.Add("total");
                dtTablaConceptos.Columns.Add("resultado");
                dtTablaConceptos.Columns.Add("codigoConceptoPorEmpresa");
            }

            foreach (XmlNode node in NodoActual)
            {
                DataRow row = dtTablaConceptos.NewRow();

                row["codigo"] = (node as XmlElement).GetAttribute("Codigo");
                row["descripcion"] = (node as XmlElement).GetAttribute("Descripcion");
                row["hab_fijo"] = (node as XmlElement).GetAttribute("hab_fijo");
                row["hab_porc"] = (node as XmlElement).GetAttribute("hab_porc");
                row["ded_fijo"] = (node as XmlElement).GetAttribute("ded_fijo");
                row["ded_porc"] = (node as XmlElement).GetAttribute("ded_porc");
                row["tipo"] = (node as XmlElement).GetAttribute("tipo");
                row["modo"] = (node as XmlElement).GetAttribute("modo");
                row["formula_porc"] = (node as XmlElement).GetAttribute("formula_porc");
                row["unidades"] = (node as XmlElement).GetAttribute("unidades");
                row["codigoConceptoPorEmpresa"] = (node as XmlElement).GetAttribute("codigoConceptoPorEmpresa");

                dtTablaConceptos.Rows.Add(row);
            }

            return dtTablaConceptos;
        }

        #endregion

        #region RECIBO BUILDER MINI
        public static void CalcularReciboMini(DataTable dtDetalle, Label lblRem, Label lblNoRem, Label lblDeducciones, Label lblNeto, TextBox tbxLinea2)
        {
            double RMtotal = 0;
            double NRMtotal = 0;
            double DEDtotal = 0;
            double NETOtotal = 0;
            string NETOString;

            foreach (DataRow row in dtDetalle.Rows)
            {
                int index = dtDetalle.Rows.IndexOf(row);
                string CheckType = dtDetalle.Rows[index]["Tipo"].ToString();

                switch (CheckType)
                {
                    case "RM":
                        RMtotal += double.Parse(dtDetalle.Rows[index]["Haberes"].ToString());
                        break;
                    case "NRM":
                        NRMtotal += double.Parse(dtDetalle.Rows[index]["Haberes"].ToString());
                        break;
                    case "DED":
                        DEDtotal += double.Parse(dtDetalle.Rows[index]["Deducciones"].ToString());
                        break;
                }
            }

            NETOtotal = RMtotal + NRMtotal - DEDtotal;

            lblRem.Text = RMtotal.ToString();
            lblNoRem.Text = NRMtotal.ToString();
            lblDeducciones.Text = DEDtotal.ToString();
            lblNeto.Text = NETOtotal.ToString();

            if (NETOtotal < 0)
            {
                NETOString = ConversorIntString.enletras(NETOtotal.ToString().Replace("-", ""));
                NETOString = "MENOS " + NETOString;
            }
            else
            {
                NETOString = ConversorIntString.enletras(NETOtotal.ToString());
            }

            tbxLinea2.Text = string.Format("LA CANTIDAD DE PESOS: {0}", NETOString);
        }
        
        #endregion

        #region CALCULAR DETALLE RECIBO
        public static void CalcularTabla(DataTable datable)
        {
            foreach (DataRow row in datable.Rows)
            {
                int indexRow = datable.Rows.IndexOf(row);

                string newforumla = "";
                string modoConcepto = Convert.ToString(row["modo"]);
                string columnaFormula;
                int totalCheck = 0;
                // Chequea si el modo es fijo o porcentaje.
                switch (modoConcepto)
                {
                    case "hab_fijo":
                        columnaFormula = Convert.ToString(row["hab_fijo"]);
                        newforumla = ResolverHaberFijo(datable, indexRow, columnaFormula);
                        break;
                    case "hab_porc":
                        columnaFormula = Convert.ToString(row["formula_porc"]);
                        newforumla = ResolverHaberPorcentual(datable, indexRow, columnaFormula);
                        break;
                    case "ded_fijo":

                        datable.Rows[indexRow]["total"] = Convert.ToDouble(row["ded_fijo"]) * Convert.ToDouble(row["unidades"]);
                        break;
                    case "ded_porc":
                        columnaFormula = Convert.ToString(row["formula_porc"]);

                        if (columnaFormula.Equals("TotalRemunerativos"))
                        {
                            newforumla = CalcularTotalRemunerativos(datable, indexRow);
                        }
                        else
                        {
                            newforumla = ResolverDeduccionPorcentual(datable, indexRow, columnaFormula);
                        }
                        break;
                }

                continue;
            }
        }

        //TODO: Testar si lo que cambie de este método no da errores.
        private static string ResolverHaberFijo(DataTable tabla, int indexOfRow, string formulaRow)
        {
            string formula = formulaRow;
            string formulaToSplit = formulaRow.Replace("(","");
            string[] splitedFormula;

            formulaToSplit = formulaRow.Replace(")", "");
            splitedFormula = formulaToSplit.Split('/', '*', '-', '+');

            for (int i = 0; i < splitedFormula.Length; i++)
            {
                double number;
                bool conversion = double.TryParse(splitedFormula[i], out number);

                if (conversion)
                {
                    continue;
                }
                else
                {
                    string resultadoDeCodigo = EncontrarCodigoHaber(tabla, splitedFormula[i]);
                    formula = formula.Replace(splitedFormula[i], resultadoDeCodigo);
                }
            }

            formula = formula.Replace(",", ".");
            double resultado = Convert.ToDouble(tabla.Compute(formula, "") );

            tabla.Rows[indexOfRow]["resultado"] = Math.Round(resultado, 2);
            tabla.Rows[indexOfRow]["total"] = Math.Round( Convert.ToDouble(tabla.Rows[indexOfRow]["resultado"]) * Convert.ToDouble(tabla.Rows[indexOfRow]["unidades"]), 2 );

            return String.Format("{0}", resultado);// Convert.ToString(resultado, myFormatProvider);
        }

        private static string ResolverHaberPorcentual(DataTable tabla, int indexOfRow, string formulaRow)
        {
            string formula = formulaRow;
            string[] splitedFormula = formulaRow.Split('/', '*', '-', '+');

            for (int i = 0; i < splitedFormula.Length; i++)
            {
                
                //string resultadoDeCodigo = EncontrarCodigoHaber(tabla, splitedFormula[i]);
                string resultadoDeCodigo = EncontrarCodigoHaberPorCodigoConceptoPorEmpresa(tabla, splitedFormula[i]);
                formula = formula.Replace(splitedFormula[i], resultadoDeCodigo);
            }

            formula = formula.Replace(",", ".");
            double resultado = Convert.ToDouble( tabla.Compute(formula + "+0", "") );

            tabla.Rows[indexOfRow]["resultado"] =Math.Round((resultado * Convert.ToDouble(tabla.Rows[indexOfRow]["hab_porc"])) / 100, 2);
            tabla.Rows[indexOfRow]["total"] = Math.Round(Convert.ToDouble(tabla.Rows[indexOfRow]["resultado"]) * Convert.ToDouble(tabla.Rows[indexOfRow]["unidades"]), 2);

            return String.Format("{0}", tabla.Rows[indexOfRow][11]); //Convert.ToString(tabla.Rows[indexOfRow][11], myFormatProvider);
        }

        private static string ResolverDeduccionPorcentual(DataTable tabla, int indexOfRow, string formulaRow)
        {
            string formula = formulaRow;
            string[] splitedFormula = formulaRow.Split('/', '*', '-', '+');

            for (int i = 0; i < splitedFormula.Length; i++)
            {
                string resultadoDeCodigo = EncontrarTotalCodigoParaDeduccion(tabla, splitedFormula[i]);
                formula = formula.Replace(splitedFormula[i], resultadoDeCodigo);
            }

            formula = formula.Replace(",", ".");
            double resultado = Convert.ToDouble( tabla.Compute(formula + "+0", "") );

            tabla.Rows[indexOfRow]["resultado"] = Math.Round((resultado * Convert.ToDouble(tabla.Rows[indexOfRow]["ded_porc"])) / 100, 2);
            tabla.Rows[indexOfRow]["total"] = Math.Round(Convert.ToDouble(tabla.Rows[indexOfRow]["resultado"]) * Convert.ToDouble(tabla.Rows[indexOfRow]["unidades"]), 2);

            return String.Format("{0}", resultado); //Convert.ToString(resultado, myFormatProvider);
        }

        //TODO: 13/09 estoy aca modificando esto, cambie el codigoConcepto por codigoConceptoPorEmpresa en la variable coneptoTabla
        //Ademas Tengo que hacer un metodo nuevo que busque los haberes por codigoConceptoPorEmpresa y no por codigo.
        private static string EncontrarTotalCodigoParaDeduccion(DataTable tabla, string splitedConcepto)
        {

            string concepto = splitedConcepto.Replace("|", "").Trim();
            string conceptoTabla = "";
            int indexOfConcepto = 0;

            for (int i = 0; i < tabla.Rows.Count; i++)
            {
                conceptoTabla = Convert.ToString(tabla.Rows[i]["codigoConceptoPorEmpresa"]).Replace("|", "").Trim();

                if (conceptoTabla.Equals(concepto))
                {
                    if (Convert.ToString(tabla.Rows[i]["total"]).Equals("0"))
                    {
                        EncontrarCodigoHaberPorCodigoConceptoPorEmpresa(tabla, concepto);
                    }
                    indexOfConcepto = i;
                }
            }
            return String.Format("{0}", tabla.Rows[indexOfConcepto]["total"]); //Convert.ToString(tabla.Rows[indexOfConcepto]["total"], myFormatProvider);
        }

        private static string EncontrarCodigoHaber(DataTable tabla, string codigo)
        {
            string formula = "";

            foreach (DataRow row in tabla.Rows)
            {
                int index = tabla.Rows.IndexOf(row);

                if (Convert.ToString(tabla.Rows[index]["codigo"]).Equals(codigo.Replace("|","").Trim()))
                {
                    string modo = Convert.ToString(tabla.Rows[index]["modo"]);
                    string formulaPorcentaje = "";
                    string checkResultado = "";

                    double number;
                    bool conversion;

                    switch (modo)
                    {
                        case "hab_fijo":

                            //agregue hoy 12/01/2020 lineas 910 a 916
                            checkResultado = Convert.ToString(tabla.Rows[index]["resultado"]);

                            if (checkResultado != "")
                            {
                                return checkResultado;
                            }
                            
                            formula = Convert.ToString(tabla.Rows[index]["hab_fijo"]) ;

                            conversion = double.TryParse(formula, out number);

                            if (conversion)
                            {
                                return formula;
                            }
                            else
                            {
                                formula = ResolverHaberFijo(tabla, index, formula);
                            }

                            break;
                        case "hab_porc":

                            //agregue hoy 12/01/2020 lineas 934 a 940
                            checkResultado = Convert.ToString(tabla.Rows[index]["total"]);

                            if (checkResultado != "")
                            {
                                return String.Format("({0}*{1})", checkResultado, tabla.Rows[index]["hab_porc"]);
                            }

                            formulaPorcentaje = Convert.ToString(tabla.Rows[index]["formula_porc"]);

                            conversion = double.TryParse(formula, out number);

                            if (conversion)
                            {
                                formula = String.Format("({0}*{1})", formula, tabla.Rows[index]["hab_porc"]);
                                return formula;
                            }
                            else
                            {
                                formula = ResolverHaberPorcentual(tabla, index, formula);
                                formula = String.Format("({0}*{1})", formula, tabla.Rows[index]["hab_porc"]);
                            }
                            break;
                    }

                }
            }
            formula = formula.Replace(",", ".");
            double resultado = Convert.ToDouble( tabla.Compute(formula, "") );
            return String.Format("{0}", Math.Round(resultado, 2)); //Convert.ToString( Math.Round(resultado, 2), myFormatProvider);
        }

        private static string EncontrarCodigoHaberPorCodigoConceptoPorEmpresa(DataTable tabla, string codigo)
        {
            string formula = "";

            foreach (DataRow row in tabla.Rows)
            {
                int index = tabla.Rows.IndexOf(row);

                if (Convert.ToString(tabla.Rows[index]["codigoConceptoPorEmpresa"]).Equals(codigo.Replace("|", "").Trim()))
                {
                    string modo = Convert.ToString(tabla.Rows[index]["modo"]);
                    string formulaPorcentaje = "";
                    string checkResultado = "";

                    double number;
                    bool conversion;

                    switch (modo)
                    {
                        case "hab_fijo":

                            //agregue hoy 12/01/2020 lineas 910 a 916
                            checkResultado = Convert.ToString(tabla.Rows[index]["resultado"]);

                            if (checkResultado != "")
                            {
                                return checkResultado;
                            }

                            formula = Convert.ToString(tabla.Rows[index]["hab_fijo"]);

                            conversion = double.TryParse(formula, out number);

                            if (conversion)
                            {
                                return formula;
                            }
                            else
                            {
                                formula = ResolverHaberFijo(tabla, index, formula);
                            }

                            break;
                        case "hab_porc":

                            //agregue hoy 12/01/2020 lineas 934 a 940
                            checkResultado = Convert.ToString(tabla.Rows[index]["total"]);

                            if (checkResultado != "")
                            {
                                return String.Format("({0}*{1})", checkResultado, tabla.Rows[index]["hab_porc"]);
                            }

                            formulaPorcentaje = Convert.ToString(tabla.Rows[index]["formula_porc"]);

                            conversion = double.TryParse(formula, out number);

                            if (conversion)
                            {
                                formula = String.Format("({0}*{1})", formula, tabla.Rows[index]["hab_porc"]);
                                return formula;
                            }
                            else
                            {
                                formula = ResolverHaberPorcentual(tabla, index, formula);
                                formula = String.Format("({0}*{1})", formula, tabla.Rows[index]["hab_porc"]);
                            }
                            break;
                    }

                }
            }
            double resultado = Convert.ToDouble( tabla.Compute(formula + "+0", "") );
            return String.Format("{0:0,0.00}", Math.Round(resultado, 2));  //Convert.ToString(Math.Round(resultado, 2), myFormatProvider);
        }

        private static string CalcularTotalRemunerativos(DataTable tabla, int indexOfRow)
        {
            double totalRemunerativos = 0;
            double totalConcepto = 0;

            for (int i = 0; i < tabla.Rows.Count; i++)
            {
                switch (Convert.ToString(tabla.Rows[i]["tipo"]))
                {
                    case "BAS":

                        if (tabla.Rows[i]["total"] != DBNull.Value && !Convert.ToString(tabla.Rows[i]["total"]).Equals("0"))
                        {
                            totalConcepto = Convert.ToDouble(tabla.Rows[i]["total"]);
                        }
                        else
                        {
                            totalConcepto = 0;
                        }

                        if (totalConcepto == 0)
                        {
                            tabla.Rows[i]["total"] = Convert.ToDouble(tabla.Rows[i]["hab_fijo"]) * Convert.ToDouble(tabla.Rows[i]["unidades"]);
                        }

                        totalRemunerativos = totalRemunerativos + Convert.ToDouble(tabla.Rows[i]["total"]);
                        break;
                    case "RM":
                        if (tabla.Rows[i]["total"] != DBNull.Value && !Convert.ToString(tabla.Rows[i]["total"]).Equals("0"))
                        {
                            totalConcepto = Convert.ToDouble(tabla.Rows[i]["total"]); // tabla.Rows[i][10].ToString()

                        }
                        else
                        {   
                            totalConcepto = 0;
                        }

                        if (totalConcepto == 0)
                        {
                            string modo = tabla.Rows[i]["modo"].ToString();
                            string formula = "";

                            switch (modo)
                            {
                                case "hab_fijo":
                                    formula = tabla.Rows[i]["hab_fijo"].ToString();
                                    ResolverHaberFijo(tabla, i, formula);
                                    break;
                                case "hab_porc":
                                    formula = tabla.Rows[i]["formula_porc"].ToString();
                                    ResolverHaberPorcentual(tabla, i, formula);
                                    break;
                            }
                        }

                        totalRemunerativos = totalRemunerativos + Convert.ToDouble(tabla.Rows[i]["total"]);
                        break;
                }
            }

            tabla.Rows[indexOfRow]["resultado"] = Math.Round((Convert.ToDouble(totalRemunerativos) * Convert.ToDouble(tabla.Rows[indexOfRow]["ded_porc"])) / 100, 2);
            tabla.Rows[indexOfRow]["total"] = Math.Round(Convert.ToDouble(tabla.Rows[indexOfRow]["resultado"]) * Convert.ToDouble(tabla.Rows[indexOfRow]["unidades"]), 2);

            return String.Format("{0}", Math.Round(totalRemunerativos, 2)); //Convert.ToString(Math.Round(totalRemunerativos, 2), myFormatProvider);
        }
        #endregion

        #region CALCULAR TOTAL RECIBO
        public static void CalcularTotales(DataTable dtXML, DataGridView dgvDetalles, Label lblRemInfo, Label lblNoRemInfo, Label lblDeduccionesInfo, Label lblNetoInfo)
        {
            double totalRemunerativos = 0;
            double totalNoRemunerativos = 0;
            double totalDeducciones = 0;
            double totalNeto = 0;

            foreach (DataRow row in dtXML.Rows)
            {
                int index = dtXML.Rows.IndexOf(row);

                switch (dtXML.Rows[index][6].ToString())
                {
                    case "BAS":

                        totalRemunerativos += Convert.ToDouble(dtXML.Rows[index]["total"].ToString().Replace("$", ""));
                        break;
                    case "RM":
                        totalRemunerativos += Convert.ToDouble(dtXML.Rows[index]["total"].ToString().Replace("$", ""));
                        break;
                    case "NRM":
                        totalNoRemunerativos += Convert.ToDouble(dtXML.Rows[index]["total"].ToString().Replace("$", ""));
                        break;
                    default:
                        totalDeducciones += Convert.ToDouble(dtXML.Rows[index]["total"].ToString().Replace("$", ""));
                        break;
                }

            }

            Math.Round(totalRemunerativos, 2);
            Math.Round(totalNoRemunerativos, 2);
            Math.Round(totalDeducciones, 2);

            lblRemInfo.Text = String.Format("$ {0:0,0.00}", totalRemunerativos);
            lblNoRemInfo.Text = String.Format("$ {0:0,0.00}", totalNoRemunerativos);
            lblDeduccionesInfo.Text = String.Format("$ {0:0,0.00}", totalDeducciones);
            totalNeto = (totalRemunerativos - totalDeducciones) + totalNoRemunerativos;

            Math.Round(totalNeto, 2);

            lblNetoInfo.Text = String.Format("$ {0:0,0.00}", totalNeto);
        }
        #endregion

        #region DIBUJAR TABLA
        public static void DrawTabla(DataTable dtXML, DataGridView dgvDetalles, bool isEditMode)
        {
            dgvDetalles.Rows.Clear();
            dgvDetalles.Columns.Clear();

            DataGridViewButtonColumn dgvbtnUnidades = new DataGridViewButtonColumn();
            dgvbtnUnidades.HeaderText = "Unidades";

            dgvDetalles.Columns.Add("Código", "Código");
            dgvDetalles.Columns.Add("Descripción", "Descripción");
            dgvDetalles.Columns.Add("Base", "Base");
            dgvDetalles.Columns.Add(dgvbtnUnidades);
            dgvDetalles.Columns.Add("Haberes", "Haberes");
            dgvDetalles.Columns.Add("Deducciones", "Deducciones");
            dgvDetalles.Columns.Add("tipo", "tipo");
            dgvDetalles.Columns[0].Width = 80;
            dgvDetalles.Columns[1].Width = 155;
            dgvDetalles.Columns[2].Width = 85;
            dgvDetalles.Columns[3].Width = 62;
            dgvDetalles.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvDetalles.Columns[4].Width = 95;
            dgvDetalles.Columns[5].Width = 95;
            dgvDetalles.Columns[6].Visible = false;

            if (!isEditMode)
            {
                dgvDetalles.Columns[0].Visible = false;
                dgvDetalles.Columns[2].Visible = false;
                dgvDetalles.Columns[3].Visible = false;
                dgvDetalles.Columns[1].Width = 272;
                dgvDetalles.Columns[4].Width = 150;
                dgvDetalles.Columns[5].Width = 150;
            }

            foreach (DataGridViewColumn column in dgvDetalles.Columns)
            {
                column.SortMode = DataGridViewColumnSortMode.NotSortable;
                dgvDetalles.Columns[column.Index].HeaderCell.Style.Font = new Font("Tahoma", 9.75F, FontStyle.Bold);
            }

            foreach (DataRow row in dtXML.Rows)
            {
                int index = dtXML.Rows.IndexOf(row);

                string modoConcepto = dtXML.Rows[index][7].ToString();
                string codigo = dtXML.Rows[index][0].ToString().Replace("\"", "");
                string descripcion = dtXML.Rows[index][1].ToString();
                string valorBase;
                string unidades = dtXML.Rows[index][9].ToString();
                string haberes;
                string deducciones;
                string tipo;


                switch (modoConcepto)
                {
                    case "hab_fijo":
                        valorBase = "$" + dtXML.Rows[index][2].ToString();
                        haberes = "$" + dtXML.Rows[index][10].ToString();
                        deducciones = "";
                        break;
                    case "hab_porc":
                        valorBase = dtXML.Rows[index][3].ToString() + "%";
                        haberes = "$" + dtXML.Rows[index][10].ToString();
                        deducciones = "";
                        break;
                    case "ded_fijo":
                        valorBase = "$" + dtXML.Rows[index][4].ToString();
                        haberes = "";
                        deducciones = "$" + dtXML.Rows[index][10].ToString();
                        break;
                    default:
                        valorBase = dtXML.Rows[index][5].ToString() + "%";
                        haberes = "";
                        deducciones = "$" + dtXML.Rows[index][10].ToString();
                        break;
                }
                tipo = dtXML.Rows[index][6].ToString();
                dgvDetalles.Rows.Add(codigo, descripcion, valorBase, unidades, haberes, deducciones, tipo);
            }
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
        #endregion
    }

}


