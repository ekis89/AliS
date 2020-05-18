using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using AliSlib;

namespace AliSLogica.Complementarios
{
    public class ManejoXML
    {
        private static string[] meses = new string[] { "Undefined", "Enero", "Febrero", "Marzo", "Abril", "Mayo", "Junio", "Julio", "Agosto", "Septiembre", "Octubre", "Noviembre", "Diciembre" };

        #region XML RECIBO BUILDER
        public static XmlDocument CargarXML(string userFolder, string empleadoCUIL, string empresaNombre, ComboBox cboAño, ComboBox cboMes, DataGridView dgvDetalles, Button btnLiquidar, Button btnGuardar)
        {
            XmlDocument XMLDocumento = new XmlDocument();

            string EmpresaFolderName = empresaNombre;
            string cuilSelected = empleadoCUIL.Replace("-", "");
            var añoSelected = cboAño.GetItemText(cboAño.SelectedItem);
            string XMLcurrentFolder = string.Format("{0}\\documents\\Alis\\{1}\\{2}", userFolder, EmpresaFolderName, cuilSelected);
            string curFile = string.Format("{0}\\{1}.xml", XMLcurrentFolder, añoSelected);

            try
            {
                if (!File.Exists(curFile))
                {
                    DialogResult confirm = MessageBox.Show(string.Format("El año seleccionado ({0}) no existe.¿Desea generarlo?", añoSelected), "Generar año:", MessageBoxButtons.YesNo);

                    if (confirm == DialogResult.Yes)
                    {
                        GenerarXmlAñoActual(cboMes, dgvDetalles, btnLiquidar, btnGuardar, XMLDocumento, añoSelected);

                        return XMLDocumento;
                    }
                    else
                    {
                        return null;
                    }

                }
                else
                {
                    XMLDocumento.Load(curFile);
                    cboMes.Enabled = true;

                    return XMLDocumento;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static void GuardarXML(XmlDocument Docs, DataTable dtXML, string mesSelected, string curFile, DateTimePicker dtpFechaLiquidacion, DateTimePicker dtpFechaDeposito, bool isSalarioMensual, string quincena, string bruto, string numeroLegajo, string cuit, bool isEditMode)
        {
            XmlElement CurrentRoot = Docs.DocumentElement;

            string semestreCheck = "";
            // **********************  20/01  Acordate de hacer un if ACA que vea si es mensual o quincenal.  *****************

            if (!isSalarioMensual)
            {
                XmlNode SacNode;

                if (int.Parse(mesSelected) > 0 && int.Parse(mesSelected) < 7)
                {
                    semestreCheck = "SAC_semestre_1";
                }
                else if (int.Parse(mesSelected) > 6 && int.Parse(mesSelected) < 13)
                {
                    semestreCheck = "SAC_semestre_2";
                }

                SacNode = CurrentRoot.SelectSingleNode("//SAC/" + semestreCheck + "/" + meses[Int16.Parse(mesSelected)]);

                if (quincena == "Primera")
                {
                    SacNode.Attributes["Q1_Bruto"].Value = bruto;
                }
                else if (quincena == "Segunda")
                {
                    SacNode.Attributes["Q2_Bruto"].Value = bruto;
                }

                GuardarXmlQuincenal(isEditMode, quincena, Docs, dtXML, mesSelected, numeroLegajo, cuit, dtpFechaLiquidacion, dtpFechaDeposito);
            }
            else
            {
                XmlNode SacNode;

                if (int.Parse(mesSelected) > 0 && int.Parse(mesSelected) < 7)
                {
                    semestreCheck = "SAC_semestre_1";
                }
                else if (int.Parse(mesSelected) > 6 && int.Parse(mesSelected) < 13)
                {
                    semestreCheck = "SAC_semestre_2";
                }

                SacNode = CurrentRoot.SelectSingleNode("//SAC/" + semestreCheck + "/" + meses[Int16.Parse(mesSelected)]);
                SacNode.Attributes["Bruto"].Value = bruto;

                GuardarXmlMensual(isEditMode, Docs, dtXML, mesSelected, numeroLegajo, cuit, dtpFechaLiquidacion, dtpFechaDeposito);
            }

            Docs.Save(curFile);

        }

        #region METODOS

        private static void GuardarXmlMensual(bool isEditMode, XmlDocument XML, DataTable dt, string mesSelected, string numeroLegajo, string cuit, DateTimePicker dtpFechaLiquidacion, DateTimePicker dtpFechaDeposito)
        {
            string cmd = "";
            string puesto = "";

            DataSet DS;

            if (isEditMode)
            {
                puesto = "Puesto desde XML";
            }
            else
            {
                cmd = string.Format("SELECT P.puesto FROM Legajos L , Puestos P WHERE L.n_legajo = '{0}' AND L.cuit_empresa = '{1}' AND P.cuit_empresa = L.cuit_empresa", numeroLegajo, cuit);
                DS = Utilidades.alisDB(cmd);

                puesto = DS.Tables[0].Rows[0][0].ToString();
            }

            try
            {
                XmlElement CurrentRoot = XML.DocumentElement;

                var CurrentNode = CurrentRoot.SelectSingleNode("//Liquidaciones");

                XmlElement liquidacionMes = XML.CreateElement(meses[int.Parse(mesSelected)]);

                liquidacionMes.SetAttribute("Fecha_de_liquidacion", dtpFechaLiquidacion.Text);
                liquidacionMes.SetAttribute("Pago", dtpFechaDeposito.Text);
                liquidacionMes.SetAttribute("Puesto", puesto);
                liquidacionMes.SetAttribute("Tipo", "mensual");

                XmlElement concepto_xml;
                XmlElement cod_xml;
                XmlElement desc_xml;
                XmlElement fijo_hab;
                XmlElement porc_hab;
                XmlElement fijo_ded;
                XmlElement porc_ded;
                XmlElement tipo_ded;
                XmlElement modo_ded;
                XmlElement formula_ded;
                XmlElement unidad;
                string code;
                string desc;
                string hab_fijo;
                string hab_porc;
                string ded_fijo;
                string ded_porc;
                string tipo;
                string modo;
                string formula;
                string unid;

                foreach (DataRow row in dt.Rows)
                {
                    int index = dt.Rows.IndexOf(row);

                    code = dt.Rows[index][0].ToString();
                    desc = dt.Rows[index][1].ToString();
                    hab_fijo = dt.Rows[index][2].ToString();
                    hab_porc = dt.Rows[index][3].ToString();
                    ded_fijo = dt.Rows[index][4].ToString();
                    ded_porc = dt.Rows[index][5].ToString();
                    tipo = dt.Rows[index][6].ToString();
                    modo = dt.Rows[index][7].ToString();
                    formula = dt.Rows[index][8].ToString();
                    unid = dt.Rows[index][9].ToString();

                    if (tipo.Equals("BAS"))
                    {
                        liquidacionMes.SetAttribute("basico", hab_fijo);
                    }

                    concepto_xml = XML.CreateElement("Concepto");
                    liquidacionMes.AppendChild(concepto_xml);

                    cod_xml = XML.CreateElement("Codigo");
                    concepto_xml.AppendChild(cod_xml);
                    cod_xml.AppendChild(XML.CreateTextNode(code));

                    desc_xml = XML.CreateElement("Descripcion");
                    concepto_xml.AppendChild(desc_xml);
                    desc_xml.AppendChild(XML.CreateTextNode(desc));

                    fijo_hab = XML.CreateElement("hab_fijo");
                    concepto_xml.AppendChild(fijo_hab);
                    fijo_hab.AppendChild(XML.CreateTextNode(hab_fijo));

                    porc_hab = XML.CreateElement("hab_porc");
                    concepto_xml.AppendChild(porc_hab);
                    porc_hab.AppendChild(XML.CreateTextNode(hab_porc));

                    fijo_ded = XML.CreateElement("ded_fijo");
                    concepto_xml.AppendChild(fijo_ded);
                    fijo_ded.AppendChild(XML.CreateTextNode(ded_fijo));

                    porc_ded = XML.CreateElement("ded_porc");
                    concepto_xml.AppendChild(porc_ded);
                    porc_ded.AppendChild(XML.CreateTextNode(ded_porc));

                    tipo_ded = XML.CreateElement("tipo");
                    concepto_xml.AppendChild(tipo_ded);
                    tipo_ded.AppendChild(XML.CreateTextNode(tipo));

                    modo_ded = XML.CreateElement("modo");
                    concepto_xml.AppendChild(modo_ded);
                    modo_ded.AppendChild(XML.CreateTextNode(modo));

                    formula_ded = XML.CreateElement("formula_porc");
                    concepto_xml.AppendChild(formula_ded);
                    formula_ded.AppendChild(XML.CreateTextNode(formula));

                    unidad = XML.CreateElement("unidades");
                    concepto_xml.AppendChild(unidad);
                    unidad.AppendChild(XML.CreateTextNode(unid));
                }

                CurrentNode.AppendChild(liquidacionMes);

            }
            catch (Exception e)
            {
                throw e;
            }

        }

        private static void GuardarXmlQuincenal(bool isEditMode, string quincena, XmlDocument XML, DataTable dt, string mesSelected, string numeroLegajo, string cuit, DateTimePicker dtpFechaLiquidacion, DateTimePicker dtpFechaDeposito)
        {
            string cmd = "";
            string puesto = "";

            DataSet DS;

            if (isEditMode)
            {
                puesto = "Puesto desde XML";
            }
            else
            {
                cmd = string.Format("SELECT P.puesto FROM Legajos L , Puestos P WHERE L.n_legajo = '{0}' AND L.cuit_empresa = '{1}' AND P.cuit_empresa = L.cuit_empresa", numeroLegajo, cuit);
                DS = Utilidades.alisDB(cmd);

                puesto = DS.Tables[0].Rows[0][0].ToString();
            }

            try
            {
                XmlElement CurrentRoot = XML.DocumentElement;

                var CurrentNode = CurrentRoot.SelectSingleNode("//Liquidaciones");
                var currentMonthNode = CurrentRoot.SelectSingleNode(String.Format("//Liquidaciones/{0}", meses[int.Parse(mesSelected)]));
                XmlElement liquidacionMes = null;

                if (currentMonthNode == null)
                {
                    liquidacionMes = XML.CreateElement(meses[int.Parse(mesSelected)]);
                    liquidacionMes.SetAttribute("Tipo", "quincenal");

                    CurrentNode.AppendChild(liquidacionMes);
                }


                XmlElement liquidacionQuincena;

                if (quincena == "Primera")
                {
                    liquidacionQuincena = XML.CreateElement("Quincena_1");
                }
                else
                {
                    liquidacionQuincena = XML.CreateElement("Quincena_2");
                }

                liquidacionQuincena.SetAttribute("Fecha_de_liquidacion", dtpFechaLiquidacion.Text);
                liquidacionQuincena.SetAttribute("Pago", dtpFechaDeposito.Text);
                liquidacionQuincena.SetAttribute("Puesto", puesto);

                XmlElement concepto_xml;
                XmlElement cod_xml;
                XmlElement desc_xml;
                XmlElement fijo_hab;
                XmlElement porc_hab;
                XmlElement fijo_ded;
                XmlElement porc_ded;
                XmlElement tipo_ded;
                XmlElement modo_ded;
                XmlElement formula_ded;
                XmlElement unidad;
                string code;
                string desc;
                string hab_fijo;
                string hab_porc;
                string ded_fijo;
                string ded_porc;
                string tipo;
                string modo;
                string formula;
                string unid;

                foreach (DataRow row in dt.Rows)
                {
                    int index = dt.Rows.IndexOf(row);

                    code = dt.Rows[index][0].ToString();
                    desc = dt.Rows[index][1].ToString();
                    hab_fijo = dt.Rows[index][2].ToString();
                    hab_porc = dt.Rows[index][3].ToString();
                    ded_fijo = dt.Rows[index][4].ToString();
                    ded_porc = dt.Rows[index][5].ToString();
                    tipo = dt.Rows[index][6].ToString();
                    modo = dt.Rows[index][7].ToString();
                    formula = dt.Rows[index][8].ToString();
                    unid = dt.Rows[index][9].ToString();

                    if (tipo.Equals("BAS"))
                    {
                        liquidacionQuincena.SetAttribute("basico", hab_fijo);
                    }

                    concepto_xml = XML.CreateElement("Concepto");
                    liquidacionQuincena.AppendChild(concepto_xml);

                    cod_xml = XML.CreateElement("Codigo");
                    concepto_xml.AppendChild(cod_xml);
                    cod_xml.AppendChild(XML.CreateTextNode(code));

                    desc_xml = XML.CreateElement("Descripcion");
                    concepto_xml.AppendChild(desc_xml);
                    desc_xml.AppendChild(XML.CreateTextNode(desc));

                    fijo_hab = XML.CreateElement("hab_fijo");
                    concepto_xml.AppendChild(fijo_hab);
                    fijo_hab.AppendChild(XML.CreateTextNode(hab_fijo));

                    porc_hab = XML.CreateElement("hab_porc");
                    concepto_xml.AppendChild(porc_hab);
                    porc_hab.AppendChild(XML.CreateTextNode(hab_porc));

                    fijo_ded = XML.CreateElement("ded_fijo");
                    concepto_xml.AppendChild(fijo_ded);
                    fijo_ded.AppendChild(XML.CreateTextNode(ded_fijo));

                    porc_ded = XML.CreateElement("ded_porc");
                    concepto_xml.AppendChild(porc_ded);
                    porc_ded.AppendChild(XML.CreateTextNode(ded_porc));

                    tipo_ded = XML.CreateElement("tipo");
                    concepto_xml.AppendChild(tipo_ded);
                    tipo_ded.AppendChild(XML.CreateTextNode(tipo));

                    modo_ded = XML.CreateElement("modo");
                    concepto_xml.AppendChild(modo_ded);
                    modo_ded.AppendChild(XML.CreateTextNode(modo));

                    formula_ded = XML.CreateElement("formula_porc");
                    concepto_xml.AppendChild(formula_ded);
                    formula_ded.AppendChild(XML.CreateTextNode(formula));

                    unidad = XML.CreateElement("unidades");
                    concepto_xml.AppendChild(unidad);
                    unidad.AppendChild(XML.CreateTextNode(unid));
                }

                if (currentMonthNode == null)
                {
                    liquidacionMes.AppendChild(liquidacionQuincena);
                }
                else
                {
                    currentMonthNode.AppendChild(liquidacionQuincena);
                }

            }
            catch (Exception e)
            {
                throw e;
            }
        }

        private static void GenerarXmlAñoActual(ComboBox cboMes, DataGridView dgvDetalles, Button btnLiquidar, Button btnGuardar, XmlDocument XMLDocumento, string añoSelected)
        {
            XmlElement raiz = XMLDocumento.CreateElement("AÑO-" + añoSelected);
            XMLDocumento.AppendChild(raiz);

            XmlElement Liquidacion_node = XMLDocumento.CreateElement("Liquidaciones");
            raiz.AppendChild(Liquidacion_node);

            XmlElement SAC = XMLDocumento.CreateElement("SAC");
            raiz.AppendChild(SAC);

            XmlElement semestre_1 = XMLDocumento.CreateElement("SAC_semestre_1");
            SAC.AppendChild(semestre_1);

            XmlElement semestre_2 = XMLDocumento.CreateElement("SAC_semestre_2");
            SAC.AppendChild(semestre_2);

            XmlElement month;

            // Escribe meses en SAC_semesetre1
            for (int i = 1; i < 7; i++)
            {
                month = XMLDocumento.CreateElement(meses[i]);
                month.SetAttribute("Bruto", "0");
                month.SetAttribute("Q1_Bruto", "0");
                month.SetAttribute("Q2_Bruto", "0");

                semestre_1.AppendChild(month);
            }
            // Escribe meses en SAC_semesetre2
            for (int i = 7; i < 13; i++)
            {
                month = XMLDocumento.CreateElement(meses[i]);
                month.SetAttribute("Bruto", "0");
                month.SetAttribute("Q1_Bruto", "0");
                month.SetAttribute("Q2_Bruto", "0");

                semestre_2.AppendChild(month);
            }

            dgvDetalles.Rows.Clear();
            btnLiquidar.Enabled = true;
            btnLiquidar.Visible = true;
            cboMes.Enabled = true;

            btnGuardar.Enabled = false;
        }
        #endregion

        #endregion

        #region RECIBO BUILDER MINI
        public void GuardarXmlReciboBuilderMini(DataGridView DGV, string curFile, string legajoNumero, string empleadoNombre, string empleadoOcupacion, string empleadoIngreso, string empleadoConvenio, string periodoLiquidado, string footer)
        {
            //Crea Archivo XML
            XmlDocument doc = new XmlDocument();

            //Crea pestaña ReciboManual.
            XmlElement raiz = doc.CreateElement("A_liq");
            doc.AppendChild(raiz);

            //Legajo
            XmlElement emp_leg = doc.CreateElement("A_liq_Legajo");
            raiz.AppendChild(emp_leg);
            emp_leg.AppendChild(doc.CreateTextNode(legajoNumero));

            //nombre
            XmlElement emp_name = doc.CreateElement("A_liq_Nombre");
            raiz.AppendChild(emp_name);
            emp_name.AppendChild(doc.CreateTextNode(empleadoNombre));

            // ocupacion/categoria
            XmlElement emp_ocup = doc.CreateElement("A_liq_Puesto");
            raiz.AppendChild(emp_ocup);
            emp_ocup.AppendChild(doc.CreateTextNode(empleadoOcupacion));

            //ingreso
            XmlElement emp_ing = doc.CreateElement("A_liq_Ingreso");
            raiz.AppendChild(emp_ing);
            emp_ing.AppendChild(doc.CreateTextNode(empleadoIngreso));

            //convenio
            XmlElement emp_conv = doc.CreateElement("A_liq_Convenio");
            raiz.AppendChild(emp_conv);
            emp_conv.AppendChild(doc.CreateTextNode(empleadoConvenio));

            //periodo
            XmlElement periodo = doc.CreateElement("A_liq_Periodo");
            raiz.AppendChild(periodo);
            periodo.AppendChild(doc.CreateTextNode(periodoLiquidado));

            //pie de pagina
            XmlElement pie = doc.CreateElement("A_liq_PieDePagina");
            raiz.AppendChild(pie);
            pie.AppendChild(doc.CreateTextNode(footer));

            //Crea pestaña Detalles.
            XmlElement detalles = doc.CreateElement("A_liq_Detalles");
            raiz.AppendChild(detalles);

            foreach (DataGridViewRow row in DGV.Rows)
            {
                int index = DGV.Rows.IndexOf(row);

                string description = DGV.Rows[index].Cells[1].Value.ToString();
                string value = DGV.Rows[index].Cells[2].Value.ToString();
                string checkType = DGV.Rows[index].Cells[4].Value.ToString();


                if (checkType == "DED")
                {
                    value = DGV.Rows[index].Cells[3].Value.ToString();
                }

                XmlElement concepto = doc.CreateElement("Concepto");
                detalles.AppendChild(concepto);

                XmlElement desc = doc.CreateElement("Descripcion");
                concepto.AppendChild(desc);
                desc.AppendChild(doc.CreateTextNode(description));

                XmlElement val = doc.CreateElement("Valor");
                concepto.AppendChild(val);
                val.AppendChild(doc.CreateTextNode(value));

                XmlElement type = doc.CreateElement("Tipo");
                concepto.AppendChild(type);
                type.AppendChild(doc.CreateTextNode(checkType));

            }

            doc.Save(curFile);
        }
        #endregion
    }
}
