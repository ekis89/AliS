using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using AliSlib;

namespace AliSLogica.Complementarios
{
    public class ManejoDeRecibo
    {
        #region PROPIEDADES (las usa ReciboBuilder)
        private static bool isSalarioMensual = false;
        private static string XMLcurrentFolder;
        private static string EmpresaFolderName;
        private static string[] meses = new string[] { "Undefined", "Enero", "Febrero", "Marzo", "Abril", "Mayo", "Junio", "Julio", "Agosto", "Septiembre", "Octubre", "Noviembre", "Diciembre" };

        //private static string añoSelected;
        //private static string mesSelected;
        //private static string quincenaSelected;
        #endregion

        #region RECIBO BUILDER CARGAR RECIBO
        public static void CargarMes(XmlDocument xmlDocumento, DataTable dtXML, DataGridView dgvDetalles, ComboBox cboMes, ComboBox cboQuincena, Button btnEditar, Button btnImprimir, Button btnLiquidar,
           Label lblRemInfo, Label lblNoRemInfo, Label lblDeduccionesInfo, Label lblNetoInfo, Label lblFechaLiquidacionIfo, Label lblFechaDepositoInfo, Label lblOcupacionInfo, Label lblTipoSalarioInfo,
           DateTimePicker dtpFechaLiquidacion, DateTimePicker dtpFechaDeposito, bool isEditMode, bool isSalarioMensual)
        {
            string mesSelected = cboMes.GetItemText(cboMes.SelectedItem);
            string puesto = "";
            string TipoLiquidacion = "";
            string fechaLiquidacion = "";
            string fechaDeposito = "";
            int mesesIndex = int.Parse(mesSelected);

            XmlElement root = xmlDocumento.DocumentElement;
            XmlNode CheckNode = root.SelectSingleNode("//Liquidaciones//" + meses[mesesIndex]);
            XmlNodeList nodes = null;

            if (xmlDocumento == null || xmlDocumento.ChildNodes.Count < 1)
            {
                return;
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

                return;
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

                    puesto = CheckNode.Attributes["Puesto"].Value.ToString();
                    fechaLiquidacion = CheckNode.Attributes["Fecha_de_liquidacion"].Value.ToString();
                    fechaDeposito = CheckNode.Attributes["Pago"].Value.ToString();

                    lblOcupacionInfo.Text = puesto;
                    lblFechaLiquidacionIfo.Text = fechaLiquidacion;
                    lblFechaDepositoInfo.Text = fechaDeposito;
                    lblTipoSalarioInfo.Text = CheckNode.Attributes["Tipo"].Value.ToString();

                    nodes = root.SelectNodes("//Liquidaciones/" + meses[mesesIndex] + "/Concepto");

                }
                else if (TipoLiquidacion == "quincenal")
                {
                    cboQuincena.Enabled = true;
                    cboQuincena.SelectedIndex = 0;
                    return;
                }
            }

            //Data Table CLEAR.
            dtXML.Clear();

            if (dtXML.Columns.Count != 12)
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
            }

            foreach (XmlNode node in nodes)
            {
                dtXML.Rows.Add(node["Codigo"].InnerText.ToString(),
                            node["Descripcion"].InnerText.ToString(),
                            node["hab_fijo"].InnerText.ToString(),
                            node["hab_porc"].InnerText.ToString(),
                            node["ded_fijo"].InnerText.ToString(),
                            node["ded_porc"].InnerText.ToString(),
                            node["tipo"].InnerText.ToString(),
                            node["modo"].InnerText.ToString(),
                            node["formula_porc"].InnerText.ToString(),
                            node["unidades"].InnerText.ToString()
                            );
            }


            CalcularTabla(dtXML);

            DrawTabla(dtXML, dgvDetalles, isEditMode);

            CalcularTotales(dtXML, dgvDetalles, lblRemInfo, lblNoRemInfo, lblDeduccionesInfo, lblNetoInfo);
        }

        public static void CargarQuincena(XmlDocument xmlDocumento, DataTable dtXML, DataGridView dgvDetalles, ComboBox cboMes, ComboBox cboQuincena, Button btnEditar, Button btnImprimir,
            Button btnLiquidar, Label lblRemInfo, Label lblNoRemInfo, Label lblDeduccionesInfo, Label lblNetoInfo, Label lblFechaLiquidacionIfo, Label lblFechaDepositoInfo, Label lblOcupacionInfo,
            Label lblTipoSalarioInfo, DateTimePicker dtpFechaLiquidacion, DateTimePicker dtpFechaDeposito, bool isEditMode, bool isSalarioMensual)
        {
            string puesto = "";
            string fechaLiquidacion = "";
            string fechaDeposito = "";
            string quincenaSelectedString = "";
            string mesSelected = cboMes.GetItemText(cboMes.SelectedItem);
            int quincenaSelected = cboQuincena.SelectedIndex;
            int mesesIndex = int.Parse(mesSelected);
            XmlNode mesQuincenaInfo = null;
            XmlNode CheckNode = null;
            XmlNodeList nodes = null;

            if (xmlDocumento == null || xmlDocumento.ChildNodes.Count < 1)
            {
                return;
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

                return;
            }
            else
            {
                btnLiquidar.Enabled = false;
                btnLiquidar.Visible = false;

                btnEditar.Enabled = true;
                btnEditar.Visible = true;
                btnImprimir.Enabled = true;

                puesto = CheckNode.Attributes["Puesto"].Value.ToString();
                fechaLiquidacion = CheckNode.Attributes["Fecha_de_liquidacion"].Value.ToString();
                fechaDeposito = CheckNode.Attributes["Pago"].Value.ToString();

                lblOcupacionInfo.Text = puesto;
                lblFechaLiquidacionIfo.Text = fechaLiquidacion;
                lblFechaDepositoInfo.Text = fechaDeposito;
                lblTipoSalarioInfo.Text = root.SelectSingleNode("//Liquidaciones//" + meses[mesesIndex]).Attributes["Tipo"].Value.ToString();

                nodes = root.SelectNodes(quincenaSelectedString + "/Concepto");
            }

            //Data Table CLEAR.
            dtXML.Clear();

            if (dtXML.Columns.Count != 12)
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
            }

            foreach (XmlNode node in nodes)
            {
                dtXML.Rows.Add(node["Codigo"].InnerText.ToString(),
                            node["Descripcion"].InnerText.ToString(),
                            node["hab_fijo"].InnerText.ToString(),
                            node["hab_porc"].InnerText.ToString(),
                            node["ded_fijo"].InnerText.ToString(),
                            node["ded_porc"].InnerText.ToString(),
                            node["tipo"].InnerText.ToString(),
                            node["modo"].InnerText.ToString(),
                            node["formula_porc"].InnerText.ToString(),
                            node["unidades"].InnerText.ToString()
                            );
            }

            CalcularTabla(dtXML);

            DrawTabla(dtXML, dgvDetalles, isEditMode);

            CalcularTotales(dtXML, dgvDetalles, lblRemInfo, lblNoRemInfo, lblDeduccionesInfo, lblNetoInfo);

        }
        #endregion

        #region RECIBO BUILDER LIQUIDAR
        public static DataTable Liquidar(string userFolder, XmlDocument Documento, bool SalarioMensualCheck, string puesto_ARG, string empresaCUIT, ComboBox cboAño, ComboBox cboMes, ComboBox cboQuincena, string empleadoCUIL, string empresaNombre)
        {
            string cuilSelected = empleadoCUIL.Replace("-", "");
            string puestoRecibo = puesto_ARG;
            string basico = RecuperarSueldoBasico(empresaCUIT, puestoRecibo).Rows[0][0].ToString();

            var añoSelected = cboAño.GetItemText(cboAño.SelectedItem);
            var mesSelected = cboMes.GetItemText(cboMes.SelectedItem);
            var quincenaSelected = cboQuincena.GetItemText(cboQuincena.SelectedItem);

            EmpresaFolderName = empresaNombre;
            isSalarioMensual = SalarioMensualCheck;

            XMLcurrentFolder = string.Format("{0}\\documents\\Alis\\{1}\\{2}\\", userFolder, EmpresaFolderName, cuilSelected);

            string curFile = string.Format("{0}\\{1}.xml", XMLcurrentFolder, añoSelected);

            if (isSalarioMensual)
            {
                if (cboQuincena.Enabled)
                {
                    MessageBox.Show("Error: No se puede liquidar por quincena si el puesto actual esta mensualizado.");
                    return null;
                }
                else
                {
                    return LiquidarModoMensual(Documento, empleadoCUIL, empresaNombre, empresaCUIT, Convert.ToInt32(mesSelected), añoSelected, basico, puestoRecibo);
                }
            }
            else
            {
                return LiquidarModoQuincenal(Documento, empleadoCUIL, empresaNombre, empresaCUIT, Convert.ToInt32(mesSelected), quincenaSelected, añoSelected, basico, puestoRecibo);
            }

        }

        private static DataTable LiquidarModoMensual(XmlDocument Documento, string empleadoCUIL, string empresaNombre, string empresaCUIT, int mesesIndex, string añoSelected, string basico, string puesto)
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

                    if ((decemberNode == null) || (decemberNode.Attributes["Tipo"].Value == "quincenal") || (decemberNode.Attributes["Tipo"].Value != "mensual"))
                    {
                        return GenerarDesdeBD(empleadoCUIL, empresaNombre, empresaCUIT, basico);
                    }
                    else
                    {
                        return GenerarDesdeXML(decemberNode);
                    }
                }
                else
                {
                    return GenerarDesdeBD(empleadoCUIL, empresaNombre, empresaCUIT, basico);
                }
            }
            else
            {
                if ((CheckNode == null) || (CheckNode.Attributes["Tipo"].Value == "quincenal") || (CheckNode.Attributes["Tipo"].Value != "mensual"))
                {
                    return GenerarDesdeBD(empleadoCUIL, empresaNombre, empresaCUIT, basico);
                }
                else
                {
                    return GenerarDesdeXML(CheckNode);
                }
            }
        }

        private static DataTable LiquidarModoQuincenal(XmlDocument Documento, string empleadoCUIL, string empresaNombre, string empresaCUIT, int mesesIndex, string quincenaSelected, string añoSelected, string basico, string puesto)
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

                    if ((decemberNode == null) || (decemberNode.Attributes["Tipo"].Value == "mensual") || (decemberNode.Attributes["Tipo"].Value != "quincenal"))
                    {
                        return GenerarDesdeBD(empleadoCUIL, empresaNombre, empresaCUIT, basico);
                    }
                    else
                    {
                        return GenerarQuincena(root, CurrentRoot, mesesIndex, quincenaSelected, true, empleadoCUIL, empresaNombre, empresaCUIT, basico);
                    }

                }
                else
                {
                    // SEGUIR DESDE ACA, TIENE QUE FIJARSE SI LA QUINCENA 1 DE ENERO ES NULL, SI NO ES NULL TIENE QUE SACAR LOS DATOS DE AHI, DEBERIA HACER UN METODO CON LO 
                    // QUE ESTA EN EL ELSE DE LA LINEA 633.
                    return GenerarQuincena(null, CurrentRoot, mesesIndex, quincenaSelected, true, empleadoCUIL, empresaNombre, empresaCUIT, basico);

                }

            }
            else
            {

                if ((CheckNode == null) || (CheckNode.Attributes["Tipo"].Value == "mensual") || (CheckNode.Attributes["Tipo"].Value != "quincenal"))
                {
                    return GenerarDesdeBD(empleadoCUIL, empresaNombre, empresaCUIT, basico);
                }
                else
                {
                    return GenerarQuincena(null, CurrentRoot, mesesIndex, quincenaSelected, false, empleadoCUIL, empresaNombre, empresaCUIT, basico);
                }
            }

        }

        private static DataTable GenerarQuincena(XmlElement anoAnteriorRoot, XmlElement CurrentRoot, int mesesIndex, string quincenaSelected, bool isEnero, string empleadoCUIL, string empresaNombre, string empresaCUIT,
            string basico)
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
                return GenerarDesdeBD(empleadoCUIL, empresaNombre, empresaCUIT, basico);

            }
            else
            {
                return GenerarDesdeXML(quincenaNode);
            }

        }

        public static string SetLiquidacionFecha(ComboBox cboAño, ComboBox cboMes, ComboBox cboQuincena, bool isSalarioMensual)
        {
            string momento;
            string mesSelected = cboMes.GetItemText(cboMes.SelectedItem);
            string quincenaSelected = cboQuincena.GetItemText(cboQuincena.SelectedItem);
            int mesMasUno = 0;
            int añoSelected = Int32.Parse(cboAño.GetItemText(cboAño.SelectedItem));
            int LastDayInMont = DateTime.DaysInMonth(añoSelected, int.Parse(mesSelected));

            DateTime dateTimeValue = new DateTime(añoSelected, int.Parse(mesSelected), LastDayInMont);

            if (!isSalarioMensual)
            {
                if (quincenaSelected == "Primera")
                {
                    DateTime dateTimeValueQuincena = new DateTime(añoSelected, int.Parse(mesSelected), 19);

                    if (dateTimeValue.ToString("dddd") == "domingo")
                    {
                        DateTime dateTimeString = new DateTime(añoSelected + 1, int.Parse(mesSelected), 20);
                        momento = dateTimeString.ToShortDateString();
                        //dtpFechaLiquidacion.Value = dateTimeString;
                    }
                    else
                    {
                        momento = dateTimeValueQuincena.ToShortDateString();
                        //dtpFechaLiquidacion.Value = dateTimeValueQuincena;
                    }
                }
                else
                {
                    if (dateTimeValue.ToString("dddd") == "domingo")
                    {
                        if (mesSelected.ToString() == "12")
                        {
                            DateTime dateTimeString = new DateTime(añoSelected + 1, 1, 2);
                            momento = dateTimeString.ToShortDateString();
                            //dtpFechaLiquidacion.Value = dateTimeString;
                        }
                        else
                        {
                            mesMasUno = Int16.Parse(mesSelected.ToString()) + 1;
                            DateTime dateTimeString = new DateTime(añoSelected, mesMasUno, 1);
                            momento = dateTimeString.ToShortDateString();
                            //dtpFechaLiquidacion.Value = dateTimeString;
                        }

                    }
                    else
                    {
                        DateTime dateTimeString = new DateTime(añoSelected, Int16.Parse(mesSelected), LastDayInMont);
                        momento = dateTimeString.ToShortDateString();
                        //dtpFechaLiquidacion.Value = dateTimeString;
                    }
                }
            }
            else                 //    ----- IF MENSUAL ----- //
            {
                if (dateTimeValue.ToString("dddd") == "domingo")
                {
                    if (mesSelected.ToString() == "12")
                    {
                        DateTime dateTimeString = new DateTime(añoSelected + 1, 1, 2);
                        momento = dateTimeString.ToShortDateString();
                    }
                    else
                    {
                        mesMasUno = Int16.Parse(mesSelected.ToString()) + 1;
                        DateTime dateTimeString = new DateTime(añoSelected, mesMasUno, 1);
                        momento = dateTimeString.ToShortDateString();
                    }
                }
                else
                {
                    DateTime dateTimeString = new DateTime(añoSelected, Int16.Parse(mesSelected), LastDayInMont);
                    momento = dateTimeString.ToShortDateString();
                }
            }

            return momento;

        }

        public static DataTable GenerarDesdeBD(string empleadoCUIL, string empresaNombre, string empresaCUIT, string basico)
        {
            string cmd;
            DataSet dsLegajos;
            DataSet dsConceptos;
            DataTable dtLegajoConceptos;
            DataTable dtTablaConceptos;
            DataTable dtConceptosFinal = new DataTable();
            DataRow BasicoRow;
            string conceptos = "";
            string[] splitedConceptos;

            cmd = string.Format("SELECT conceptos FROM Legajos WHERE cuit_empresa = '{0}' AND cuil = '{1}' ", empresaCUIT, empleadoCUIL);
            dsLegajos = Utilidades.alisDB(cmd);

            cmd = string.Format("SELECT codigo, descripcion, hab_fijo, hab_porc, ded_fijo, ded_porc, tipo, modo, formula_porc FROM {0}_Conceptos", empresaNombre.Replace(" ", ""));
            dsConceptos = Utilidades.alisDB(cmd);

            dtLegajoConceptos = dsLegajos.Tables[0];
            dtTablaConceptos = dsConceptos.Tables[0];

            conceptos = dtLegajoConceptos.Rows[0][0].ToString();

            splitedConceptos = conceptos.Split(';');

            dtConceptosFinal.Columns.Add("codigo", typeof(string));
            dtConceptosFinal.Columns.Add("descripcion", typeof(string));
            dtConceptosFinal.Columns.Add("hab_fijo", typeof(string));
            dtConceptosFinal.Columns.Add("hab_porc", typeof(string));
            dtConceptosFinal.Columns.Add("ded_fijo", typeof(string));
            dtConceptosFinal.Columns.Add("ded_porc", typeof(string));
            dtConceptosFinal.Columns.Add("tipo", typeof(string));
            dtConceptosFinal.Columns.Add("modo", typeof(string));
            dtConceptosFinal.Columns.Add("formula_porc", typeof(string));
            dtConceptosFinal.Columns.Add("unidades", typeof(string));
            dtConceptosFinal.Columns.Add("total", typeof(string));
            dtConceptosFinal.Columns.Add("resultado", typeof(string));

            BasicoRow = dtConceptosFinal.NewRow();
            //Escribe 
            for (int i = 0; i < splitedConceptos.Length; i++)
            {
                DataRow[] Rows = dtTablaConceptos.Select("codigo Like '" + splitedConceptos[i] + "'");
                DataRow Row = Rows[0];

                if (Row["tipo"].ToString() == "BAS")
                {
                    string oldHabFijo = Row["hab_fijo"].ToString();
                    Row["hab_fijo"] = oldHabFijo.Replace("PUESTO", basico);
                    BasicoRow[0] = '\"' + Row[0].ToString() + '\"';
                    BasicoRow[1] = Row[1];
                    BasicoRow[2] = Row[2];
                    BasicoRow[3] = Row[3];
                    BasicoRow[4] = Row[4];
                    BasicoRow[5] = Row[5];
                    BasicoRow[6] = Row[6];
                    BasicoRow[7] = Row[7];

                    continue;
                }

                Row["codigo"] = '\"' + Row["codigo"].ToString() + '\"';

                dtConceptosFinal.ImportRow(Row);
                dtConceptosFinal.Rows[i][9] = "1";
            }
            dtConceptosFinal.DefaultView.Sort = "tipo DESC";
            dtConceptosFinal.Rows.InsertAt(BasicoRow, 0);
            dtConceptosFinal.Rows[0][9] = "1";

            return dtConceptosFinal;
        }

        private static DataTable GenerarDesdeXML(XmlNode NodoActual)
        {
            DataTable dtTablaConceptos = new DataTable();
            //var nodes = añoAnteriorXML.SelectNodes("//Liquidaciones/" + meses[mesIndex] + "/Concepto");

            dtTablaConceptos.Columns.Add("codigo", typeof(string));
            dtTablaConceptos.Columns.Add("descripcion", typeof(string));
            dtTablaConceptos.Columns.Add("hab_fijo", typeof(string));
            dtTablaConceptos.Columns.Add("hab_porc", typeof(string));
            dtTablaConceptos.Columns.Add("ded_fijo", typeof(string));
            dtTablaConceptos.Columns.Add("ded_porc", typeof(string));
            dtTablaConceptos.Columns.Add("tipo", typeof(string));
            dtTablaConceptos.Columns.Add("modo", typeof(string));
            dtTablaConceptos.Columns.Add("formula_porc", typeof(string));
            dtTablaConceptos.Columns.Add("unidades", typeof(string));
            dtTablaConceptos.Columns.Add("total", typeof(string));
            dtTablaConceptos.Columns.Add("resultado", typeof(string));

            foreach (XmlNode node in NodoActual)
            {
                dtTablaConceptos.Rows.Add(node["Codigo"].InnerText.ToString(),
                    node["Descripcion"].InnerText.ToString(),
                    node["hab_fijo"].InnerText.ToString(),
                    node["hab_porc"].InnerText.ToString(),
                    node["ded_fijo"].InnerText.ToString(),
                    node["ded_porc"].InnerText.ToString(),
                    node["tipo"].InnerText.ToString(),
                    node["modo"].InnerText.ToString(),
                    node["formula_porc"].InnerText.ToString(),
                    node["unidades"].InnerText.ToString()
                );
            }

            return dtTablaConceptos;
        }

        private static DataTable RecuperarSueldoBasico(string empresaCUIT, string puestoRecibo)
        {
            string cmd = string.Format("SELECT basico FROM Puestos WHERE puesto = '{0}' AND cuit_empresa = '{1}'", puestoRecibo, empresaCUIT);
            DataSet ds = Utilidades.alisDB(cmd);
            return ds.Tables[0];
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
                string CheckType = dtDetalle.Rows[index][4].ToString();

                switch (CheckType)
                {
                    case "RM":
                        RMtotal += double.Parse(dtDetalle.Rows[index][2].ToString());
                        break;
                    case "NRM":
                        NRMtotal += double.Parse(dtDetalle.Rows[index][2].ToString());
                        break;
                    case "DED":
                        DEDtotal += double.Parse(dtDetalle.Rows[index][3].ToString());
                        break;
                }
            }

            NETOtotal = RMtotal + NRMtotal - DEDtotal;

            lblRem.Text = RMtotal.ToString();
            lblNoRem.Text = NRMtotal.ToString();
            lblDeducciones.Text = DEDtotal.ToString();
            lblNeto.Text = NETOtotal.ToString();

            NETOString = ConversorIntString.enletras(NETOtotal.ToString());

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
                string modoConcepto = Convert.ToString(row["modo"]);//datable.Rows[indexRow][7].ToString();
                string columnaFormula;
                int totalCheck = 0;
                // Chequea si el modo es fijo o porcentaje.
                switch (modoConcepto)
                {
                    case "hab_fijo":
                        columnaFormula = Convert.ToString(row["hab_fijo"]); //datable.Rows[indexRow][2].ToString();
                        newforumla = ResolverHaberFijo(datable, indexRow, columnaFormula);
                        break;
                    case "hab_porc":
                        columnaFormula = Convert.ToString(row["formula_porc"]); //datable.Rows[indexRow][8].ToString();
                        newforumla = ResolverHaberPorcentual(datable, indexRow, columnaFormula);
                        break;
                    case "ded_fijo":
                        //datable.Rows[indexRow][10] = Convert.ToDouble(datable.Rows[indexRow][4].ToString()) * Convert.ToDouble(datable.Rows[indexRow][9].ToString());
                        datable.Rows[indexRow]["total"] = Convert.ToDouble(row["ded_fijo"]) * Convert.ToDouble(row["unidades"]);
                        break;
                    case "ded_porc":
                        columnaFormula = Convert.ToString(row["formula_porc"]); //datable.Rows[indexRow][8].ToString();

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

        private static string ResolverHaberFijo(DataTable tabla, int indexOfRow, string formulaRow)
        {
            string formula = formulaRow;
            string[] splitedFormula = formulaRow.Split('/', '*', '-', '+');

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
            object resultado = tabla.Compute(formula, "");

            //tabla.Rows[indexOfRow]["hab_fijo"] = Convert.ToString(resultado);// --esto cambié 12/01/2020
            tabla.Rows[indexOfRow]["resultado"] = resultado;
            //tabla.Rows[indexOfRow]["total"] = Convert.ToDouble(tabla.Rows[indexOfRow]["hab_fijo"]) * Convert.ToDouble(tabla.Rows[indexOfRow]["unidades"]);
            tabla.Rows[indexOfRow]["total"] = Convert.ToDouble(tabla.Rows[indexOfRow]["resultado"]) * Convert.ToDouble(tabla.Rows[indexOfRow]["unidades"]);

            return resultado.ToString();
        }

        private static string ResolverHaberPorcentual(DataTable tabla, int indexOfRow, string formulaRow)
        {
            string formula = formulaRow;
            string[] splitedFormula = formulaRow.Split('/', '*', '-', '+');

            for (int i = 0; i < splitedFormula.Length; i++)
            {
                string resultadoDeCodigo = EncontrarCodigoHaber(tabla, splitedFormula[i]);
                formula = formula.Replace(splitedFormula[i], resultadoDeCodigo);
            }

            formula = formula.Replace(",", ".");
            object resultado = tabla.Compute(formula, "");

            //tabla.Rows[indexOfRow][8] = resultado.ToString(); --esto cambié 12/01/2020
            tabla.Rows[indexOfRow]["resultado"] = (Convert.ToDouble(tabla.Rows[indexOfRow]["formula_porc"]) * Convert.ToDouble(tabla.Rows[indexOfRow]["hab_porc"])) / 100;
            tabla.Rows[indexOfRow]["total"] = Convert.ToDouble(tabla.Rows[indexOfRow]["resultado"]) * Convert.ToDouble(tabla.Rows[indexOfRow]["unidades"]);

            return tabla.Rows[indexOfRow][11].ToString();
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
            object resultado = tabla.Compute(formula, "");

            //tabla.Rows[indexOfRow][8] = resultado.ToString(); --esto cambié 12/01/2020
            tabla.Rows[indexOfRow]["resultado"] = (Convert.ToDouble(tabla.Rows[indexOfRow]["formula_porc"]) * Convert.ToDouble(tabla.Rows[indexOfRow]["ded_porc"])) / 100;
            tabla.Rows[indexOfRow]["total"] = Convert.ToDouble(tabla.Rows[indexOfRow]["resultado"]) * Convert.ToDouble(tabla.Rows[indexOfRow]["unidades"]);

            return resultado.ToString();
        }

        private static string EncontrarTotalCodigoParaDeduccion(DataTable tabla, string splitedConcepto)
        {

            string concepto = splitedConcepto.Replace("\"", "").Trim();
            string conceptoTabla = "";
            int indexOfConcepto = 0;

            for (int i = 0; i < tabla.Rows.Count; i++)
            {
                conceptoTabla = Convert.ToString(tabla.Rows[i]["codigo"]).Replace("\"", "").Trim();

                if (conceptoTabla.Equals(concepto))
                {
                    if (Convert.ToString(tabla.Rows[i]["total"]).Equals(""))
                    {
                        EncontrarCodigoHaber(tabla, concepto);
                    }
                    indexOfConcepto = i;
                }
            }
            return Convert.ToString(tabla.Rows[indexOfConcepto]["total"]);
        }

        private static string EncontrarCodigoHaber(DataTable tabla, string codigo)
        {
            string formula = "";

            foreach (DataRow row in tabla.Rows)
            {
                int index = tabla.Rows.IndexOf(row);

                if (Convert.ToString(tabla.Rows[index]["codigo"]).Equals(codigo))
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

                    //switch (modo)
                    //{
                    //    case "hab_fijo":

                    //        //agregue hoy 12/01/2020 lineas 910 a 916
                    //        checkResultado = Convert.ToString(tabla.Rows[index]["total"]);

                    //        if (checkResultado == "")
                    //        {
                    //            return checkResultado;
                    //        }

                    //        formula = Convert.ToString(tabla.Rows[index]["hab_fijo"]);

                    //        conversion = double.TryParse(formula, out number);

                    //        if (conversion)
                    //        {
                    //            return formula;
                    //        }
                    //        else
                    //        {
                    //            formula = ResolverHaberFijo(tabla, index, formula);
                    //        }

                    //        break;
                    //    case "hab_porc":

                    //        //agregue hoy 12/01/2020 lineas 934 a 940
                    //        checkResultado = Convert.ToString(tabla.Rows[index]["total"]);

                    //        if (checkResultado == "")
                    //        {
                    //            return String.Format("({0}*{1})", checkResultado, tabla.Rows[index]["hab_porc"]);
                    //        }

                    //        formulaPorcentaje = Convert.ToString(tabla.Rows[index]["formula_porc"]);

                    //        conversion = double.TryParse(formula, out number);

                    //        if (conversion)
                    //        {
                    //            formula = String.Format("({0}*{1})", formula, tabla.Rows[index]["hab_porc"]);
                    //            return formula;
                    //        }
                    //        else
                    //        {
                    //            formula = ResolverHaberPorcentual(tabla, index, formula);
                    //            formula = String.Format("({0}*{1})", formula, tabla.Rows[index]["hab_porc"]);
                    //        }
                    //        break;
                    //}


                }
            }
            object resultado = tabla.Compute(formula, "");
            return Convert.ToString(resultado);
        }

        private static string CalcularTotalRemunerativos(DataTable tabla, int indexOfRow)
        {
            double? totalRemunerativos = 0;
            double? totalConcepto = 0;

            for (int i = 0; i < tabla.Rows.Count; i++)
            {
                switch (Convert.ToString(tabla.Rows[i]["tipo"]))
                {
                    case "BAS":

                        if (!Convert.ToString(tabla.Rows[i]["total"]).Equals(""))
                        {
                            totalConcepto = Convert.ToDouble(tabla.Rows[i]["total"]);
                        }

                        if (totalConcepto == 0)
                        {
                            tabla.Rows[i]["total"] = Convert.ToDouble(tabla.Rows[i]["hab_fijo"]) * Convert.ToDouble(tabla.Rows[i]["unidades"]);
                        }

                        totalRemunerativos = totalRemunerativos + Convert.ToDouble(tabla.Rows[i]["total"]);
                        break;
                    case "RM":
                        if (!Convert.ToString(tabla.Rows[i]["total"]).Equals(""))
                        {
                            totalConcepto = Convert.ToDouble(tabla.Rows[i]["total"].ToString()); // tabla.Rows[i][10].ToString()

                        }
                        else
                        {
                            // 25-03-2020 - SEGUIR DESDES ACA, HAY QUE CALCULAR LA FORMULA EN CASO DE QUE NO TENGA UN VALOR EN LA COLUMNA DE RESULTADO (parece resuelto pero hay que revisar mejor.)
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

            //tabla.Rows[indexOfRow][8] = totalRemunerativos.ToString(); --esto cambié 12/01/2020
            //tabla.Rows[indexOfRow][11] = (Convert.ToDouble(tabla.Rows[indexOfRow][8]) * Convert.ToDouble(tabla.Rows[indexOfRow][5])) / 100; --esto cambié 12/01/2020
            tabla.Rows[indexOfRow]["resultado"] = (Convert.ToDouble(totalRemunerativos) * Convert.ToDouble(tabla.Rows[indexOfRow]["ded_porc"])) / 100;
            tabla.Rows[indexOfRow]["total"] = Convert.ToDouble(tabla.Rows[indexOfRow]["resultado"]) * Convert.ToDouble(tabla.Rows[indexOfRow]["unidades"]);

            return Convert.ToString(totalRemunerativos);
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

                        totalRemunerativos += Convert.ToDouble(dtXML.Rows[index][10].ToString().Replace("$", ""));
                        break;
                    case "RM":
                        totalRemunerativos += Convert.ToDouble(dtXML.Rows[index][10].ToString().Replace("$", ""));
                        break;
                    case "NRM":
                        totalNoRemunerativos += Convert.ToDouble(dtXML.Rows[index][10].ToString().Replace("$", ""));
                        break;
                    default:
                        totalDeducciones += Convert.ToDouble(dtXML.Rows[index][10].ToString().Replace("$", ""));
                        break;
                }

            }

            Math.Round(totalRemunerativos, 2);
            Math.Round(totalNoRemunerativos, 2);
            Math.Round(totalDeducciones, 2);

            lblRemInfo.Text = "$" + totalRemunerativos.ToString();
            lblNoRemInfo.Text = "$" + totalNoRemunerativos.ToString();
            lblDeduccionesInfo.Text = "$" + totalDeducciones.ToString();
            totalNeto = (totalRemunerativos - totalDeducciones) + totalNoRemunerativos;

            Math.Round(totalNeto, 2);

            lblNetoInfo.Text = "$" + totalNeto.ToString();
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


