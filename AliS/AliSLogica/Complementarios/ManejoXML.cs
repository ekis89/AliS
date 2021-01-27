using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using AliSLogica.Controladores;

namespace AliSLogica.Complementarios
{
    public class ManejoXML
    {
        private static string[] meses = new string[] { "Undefined", "Enero", "Febrero", "Marzo", "Abril", "Mayo", "Junio", "Julio", "Agosto", "Septiembre", "Octubre", "Noviembre", "Diciembre" };

        #region XML RECIBO BUILDER
        public static XmlDocument CargarXML(string userFolder, string empleadoCUIL, string empresaNombre, ComboBox cboAño, ComboBox cboMes, DataGridView dgvDetalles, Button btnLiquidar)
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
                        GenerarXmlAñoActual(cboMes, dgvDetalles, btnLiquidar, XMLDocumento, añoSelected);

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

        public static void GuardarXML(XmlDocument Docs, DataTable dtXML, string puestoActual, string bancoActual, string convenioActual, string fechaLiquidacion, string fechaDeposito, string mesSelected, string curFile, double saldoNeto, bool isSalarioMensual, string quincena, bool isEditMode)
        {
            try
            {
                XmlElement CurrentRoot = Docs.DocumentElement;

                string semestreCheck = "";
                string netoString = Convert.ToString(saldoNeto);

                if (!File.Exists(curFile))
                {
                    Directory.CreateDirectory(curFile.Substring(0, curFile.Length - 8));
                }

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
                        SacNode.Attributes["Q1_Neto"].Value = netoString;
                    }
                    else if (quincena == "Segunda")
                    {
                        SacNode.Attributes["Q2_Neto"].Value = netoString;
                    }

                    GuardarXmlQuincenal(Docs, dtXML, puestoActual, bancoActual, convenioActual, mesSelected, quincena, fechaLiquidacion, fechaDeposito, isEditMode);
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
                    SacNode.Attributes["Neto"].Value = netoString;

                    GuardarXmlMensual(Docs, dtXML, puestoActual, bancoActual, convenioActual, mesSelected, fechaLiquidacion, fechaDeposito, isEditMode);
                }

                Docs.Save(curFile);
            }
            catch (Exception ex)
            {

                throw ex;
            }
            

        }

        public static void EliminarLiquidacion(XmlDocument XML, string curFile, string mesSelected, string quincenaSelected, bool isSalarioMensual)
        {
            try
            {
                int mesSelectedInt = Convert.ToInt32(mesSelected);
                string mesActual = meses[mesSelectedInt];

                var root = XML.DocumentElement;
                XmlNodeList nodeList = root.SelectSingleNode("//Liquidaciones").ChildNodes;

                foreach (XmlNode node in nodeList)
                {
                    if (isSalarioMensual)
                    {
                        if (node.Name.Equals(mesActual))
                        {
                            node.ParentNode.RemoveChild(node);
                        }
                    }
                    else
                    {
                        if (node.Name.Equals(mesActual))
                        {
                            foreach (XmlNode quincenaNode in node.ChildNodes)
                            {
                                if (quincenaNode.Name.Equals("Quincena_1") && quincenaSelected == "Primera")
                                {
                                    node.RemoveChild(quincenaNode);
                                }
                                else if (quincenaNode.Name.Equals("Quincena_2") && quincenaSelected != "Primera")
                                {
                                    node.RemoveChild(quincenaNode);
                                }
                            }

                            if (node.ChildNodes.Count < 1)
                                node.ParentNode.RemoveChild(node);
                        }
 
                    }

                }

                LimpiarSac(root, mesActual, mesSelectedInt, quincenaSelected, isSalarioMensual);

                XML.Save(curFile);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        #region METODOS

        private static void GuardarXmlMensual(XmlDocument XML, DataTable dt, string puestoActual, string bancoActual, string convenioActual, string mesSelected, string fechaLiquidacion, string fechaDeposito, bool isEditMode)
        {
            string puesto = "";
            string banco = "";
            string convenio = "";

            try
            {
                XmlElement CurrentRoot = XML.DocumentElement;
                XmlElement liquidacionMes;

                var CurrentNode = CurrentRoot.SelectSingleNode("//Liquidaciones");

                XmlNodeList listaConceptos = CurrentNode.SelectNodes(meses[Convert.ToInt32(mesSelected)] + "/Concepto");

                if (listaConceptos.Count > 0)
                {
                    liquidacionMes = CurrentNode.SelectSingleNode(meses[Convert.ToInt32(mesSelected)]) as XmlElement;

                    puesto = liquidacionMes.GetAttribute("Puesto");
                    banco = liquidacionMes.GetAttribute("Banco");
                    convenio = liquidacionMes.GetAttribute("Convenio");

                    liquidacionMes.RemoveAll();
                }
                else
                {
                    liquidacionMes = XML.CreateElement(meses[Convert.ToInt32(mesSelected)]);

                    puesto = puestoActual;
                    banco = bancoActual;
                    convenio = convenioActual;
                }

                liquidacionMes.SetAttribute("Fecha_de_liquidacion", fechaLiquidacion);
                liquidacionMes.SetAttribute("Pago", fechaDeposito);
                liquidacionMes.SetAttribute("Puesto", puesto);
                liquidacionMes.SetAttribute("Tipo", "mensual");
                liquidacionMes.SetAttribute("Puesto", puesto);
                liquidacionMes.SetAttribute("Banco", banco);
                liquidacionMes.SetAttribute("Convenio", convenio);

                XmlElement concepto_xml;

                string codeCEmp;
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
                    codeCEmp = Convert.ToString(row["codigoConceptoPorEmpresa"]);
                    code = Convert.ToString(row["codigo"]);
                    desc = Convert.ToString(row["descripcion"]);
                    hab_fijo = Convert.ToString(row["hab_fijo"]);
                    hab_porc = Convert.ToString(row["hab_porc"]);
                    ded_fijo = Convert.ToString(row["ded_fijo"]);
                    ded_porc = Convert.ToString(row["ded_porc"]);
                    tipo = Convert.ToString(row["tipo"]);
                    modo = Convert.ToString(row["modo"]);
                    formula = Convert.ToString(row["formula_porc"]);
                    unid = Convert.ToString(row["unidades"]);

                    if (tipo.Equals("BAS"))
                    {
                        liquidacionMes.SetAttribute("basico", hab_fijo);
                    }

                    concepto_xml = XML.CreateElement("Concepto");
                    liquidacionMes.AppendChild(concepto_xml);

                    concepto_xml.SetAttribute("codigoConceptoPorEmpresa", codeCEmp);
                    concepto_xml.SetAttribute("Codigo", code);
                    concepto_xml.SetAttribute("Descripcion", desc);
                    concepto_xml.SetAttribute("hab_fijo", hab_fijo);
                    concepto_xml.SetAttribute("hab_porc", hab_porc);
                    concepto_xml.SetAttribute("ded_fijo", ded_fijo);
                    concepto_xml.SetAttribute("ded_porc", ded_porc);
                    concepto_xml.SetAttribute("tipo", tipo);
                    concepto_xml.SetAttribute("modo", modo);
                    concepto_xml.SetAttribute("formula_porc", formula);
                    concepto_xml.SetAttribute("unidades", unid);

                }

                CurrentNode.AppendChild(liquidacionMes);

            }
            catch (Exception e)
            {
                throw e;
            }

        }

        //TODO:: 14/11/2020: Al editar reemplaza el puesto y no deberia(mensual arreglado quincenal no). Al editar quincenal en vuelve a crae un nodo de quincena nuevo lo que hace que explote el programa al tener nodo quincena repetido.
        private static void GuardarXmlQuincenal(XmlDocument XML, DataTable dt, string puestoActual, string bancoActual, string convenioActual, string mesSelected, string quincena, string fechaLiquidacion, string fechaDeposito, bool isEditMode)
        {
            string puesto = "";
            string banco = "";
            string convenio = "";

            try
            {
                XmlElement CurrentRoot = XML.DocumentElement;

                var CurrentNode = CurrentRoot.SelectSingleNode("//Liquidaciones");
                var currentMonthNode = CurrentRoot.SelectSingleNode(String.Format("//Liquidaciones/{0}", meses[Convert.ToInt32(mesSelected)]));
                XmlElement liquidacionMes = null;
                XmlNodeList listaConceptos = null;

                if (currentMonthNode == null)
                {
                    liquidacionMes = XML.CreateElement(meses[Convert.ToInt32(mesSelected)]);
                    liquidacionMes.SetAttribute("Tipo", "quincenal");

                    CurrentNode.AppendChild(liquidacionMes);
                }
                else
                {
                    liquidacionMes = CurrentNode.SelectSingleNode(String.Format("//{0}", meses[Convert.ToInt32(mesSelected)])) as XmlElement;

                    listaConceptos = quincena == "Primera" ? currentMonthNode.SelectNodes("//Quincena_1/Concepto") : currentMonthNode.SelectNodes("//Quincena_2/Concepto");
                }

                XmlElement liquidacionQuincena;

                if (listaConceptos != null && listaConceptos.Count > 0)
                {
                    liquidacionQuincena = quincena == "Primera" ? liquidacionMes.SelectSingleNode("//Quincena_1") as XmlElement : liquidacionMes.SelectSingleNode("//Quincena_2") as XmlElement;

                    puesto = liquidacionQuincena.GetAttribute("Puesto");
                    banco = liquidacionQuincena.GetAttribute("Banco");
                    convenio = liquidacionQuincena.GetAttribute("Convenio");

                    liquidacionQuincena.RemoveAll();
                }
                else
                {
                    liquidacionQuincena = quincena == "Primera" ? XML.CreateElement("Quincena_1") : XML.CreateElement("Quincena_2");

                    puesto = puestoActual;
                    banco = bancoActual;
                    convenio = convenioActual;
                }

                liquidacionQuincena.SetAttribute("Fecha_de_liquidacion", fechaLiquidacion);
                liquidacionQuincena.SetAttribute("Pago", fechaDeposito);
                liquidacionQuincena.SetAttribute("Puesto", puesto);
                liquidacionQuincena.SetAttribute("Banco", banco);
                liquidacionQuincena.SetAttribute("Convenio", convenio);

                XmlElement concepto_xml;

                string codeCEmp;
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
                    codeCEmp = Convert.ToString(row["codigoConceptoPorEmpresa"]);
                    code = Convert.ToString(row["codigo"]);
                    desc = Convert.ToString(row["descripcion"]);
                    hab_fijo = Convert.ToString(row["hab_fijo"]);
                    hab_porc = Convert.ToString(row["hab_porc"]);
                    ded_fijo = Convert.ToString(row["ded_fijo"]);
                    ded_porc = Convert.ToString(row["ded_porc"]);
                    tipo = Convert.ToString(row["tipo"]);
                    modo = Convert.ToString(row["modo"]);
                    formula = Convert.ToString(row["formula_porc"]);
                    unid = Convert.ToString(row["unidades"]);

                    if (tipo.Equals("BAS"))
                    {
                        liquidacionQuincena.SetAttribute("basico", hab_fijo);
                    }

                    concepto_xml = XML.CreateElement("Concepto");
                    liquidacionQuincena.AppendChild(concepto_xml);

                    concepto_xml.SetAttribute("codigoConceptoPorEmpresa", codeCEmp);
                    concepto_xml.SetAttribute("Codigo", code);
                    concepto_xml.SetAttribute("Descripcion", desc);
                    concepto_xml.SetAttribute("hab_fijo", hab_fijo);
                    concepto_xml.SetAttribute("hab_porc", hab_porc);
                    concepto_xml.SetAttribute("ded_fijo", ded_fijo);
                    concepto_xml.SetAttribute("ded_porc", ded_porc);
                    concepto_xml.SetAttribute("tipo", tipo);
                    concepto_xml.SetAttribute("modo", modo);
                    concepto_xml.SetAttribute("formula_porc", formula);
                    concepto_xml.SetAttribute("unidades", unid);

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

        private static void GenerarXmlAñoActual(ComboBox cboMes, DataGridView dgvDetalles, Button btnLiquidar, XmlDocument XMLDocumento, string añoSelected)
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
                month.SetAttribute("Neto", "0");
                month.SetAttribute("Q1_Neto", "0");
                month.SetAttribute("Q2_Neto", "0");

                semestre_1.AppendChild(month);
            }
            // Escribe meses en SAC_semesetre2
            for (int i = 7; i < 13; i++)
            {
                month = XMLDocumento.CreateElement(meses[i]);
                month.SetAttribute("Neto", "0");
                month.SetAttribute("Q1_Neto", "0");
                month.SetAttribute("Q2_Neto", "0");

                semestre_2.AppendChild(month);
            }

            dgvDetalles.Rows.Clear();
            btnLiquidar.Enabled = true;
            btnLiquidar.Visible = true;
            cboMes.Enabled = true;

        }

        private static void LimpiarSac(XmlElement root, string mesActual, int mesSelectedInt, string quincenaSelected, bool isSalarioMensual)
        {
            if ((mesSelectedInt >= 1) && (mesSelectedInt <= 6) && isSalarioMensual)
            {
                XmlNode SacNode = root.SelectSingleNode("//SAC/SAC_semestre_1/" + mesActual);
                SacNode.Attributes["Neto"].Value = "0";
            }
            else if ((mesSelectedInt >= 7) && (mesSelectedInt <= 12) && isSalarioMensual)
            {
                XmlNode SacNode = root.SelectSingleNode("//SAC/SAC_semestre_2/" + mesActual);
                SacNode.Attributes["Neto"].Value = "0";
            }
            else if ((mesSelectedInt >= 1) && (mesSelectedInt <= 6) && !isSalarioMensual)
            {
                if (quincenaSelected == "Primera")
                {
                    XmlNode SacNode = root.SelectSingleNode("//SAC/SAC_semestre_1/" + mesActual);
                    SacNode.Attributes["Q1_Neto"].Value = "0";
                }
                else
                {
                    XmlNode SacNode = root.SelectSingleNode("//SAC/SAC_semestre_1/" + mesActual);
                    SacNode.Attributes["Q2_Neto"].Value = "0";
                }
            }
            else if ((mesSelectedInt >= 7) && (mesSelectedInt <= 12) && !isSalarioMensual)
            {
                if (quincenaSelected == "Primera")
                {
                    XmlNode SacNode = root.SelectSingleNode("//SAC/SAC_semestre_2/" + mesActual);
                    SacNode.Attributes["Q1_Neto"].Value = "0";
                }
                else
                {
                    XmlNode SacNode = root.SelectSingleNode("//SAC/SAC_semestre_2/" + mesActual);
                    SacNode.Attributes["Q2_Neto"].Value = "0";
                }
            }
        }
        #endregion

        #endregion

        #region RECIBO BUILDER MINI
        public static void GuardarXmlReciboBuilderMini(DataGridView DGV, string añoSelected, string mesSelected, string quincenaSelected, string curFile, string legajoNumero, string empleadoNombre, string empleadoOcupacion, string empleadoIngreso, string empleadoConvenio, string periodoLiquidado, string footer)
        {
            //Crea Archivo XML
            XmlDocument doc = new XmlDocument();

            //Crea pestaña ReciboManual.
            XmlElement raiz = doc.CreateElement("A_liq");
            doc.AppendChild(raiz);

            XmlElement año = doc.CreateElement("A_liq_año");
            raiz.AppendChild(año);
            año.AppendChild(doc.CreateTextNode(añoSelected));

            XmlElement mes = doc.CreateElement("A_liq_mes");
            raiz.AppendChild(mes);
            mes.AppendChild(doc.CreateTextNode(mesSelected));

            XmlElement quincena = doc.CreateElement("A_liq_quincena");
            raiz.AppendChild(quincena);
            quincena.AppendChild(doc.CreateTextNode(quincenaSelected));

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

                string codigo = DGV.Rows[index].Cells[0].Value.ToString();
                string description = DGV.Rows[index].Cells[1].Value.ToString();
                string value = DGV.Rows[index].Cells[2].Value.ToString();
                string checkType = DGV.Rows[index].Cells[4].Value.ToString();


                if (checkType == "DED")
                {
                    value = DGV.Rows[index].Cells[3].Value.ToString();
                }

                XmlElement concepto = doc.CreateElement("Concepto");
                detalles.AppendChild(concepto);

                XmlElement codigoConcepto = doc.CreateElement("Codigo");
                concepto.AppendChild(codigoConcepto);
                codigoConcepto.AppendChild(doc.CreateTextNode(codigo));

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
        
        public static XmlDocument CargarXmlReciboBuilderMINI(string curfile)
        {
            try
            {
                XmlDocument xml = new XmlDocument();
                xml.Load(curfile);

                var root = xml.SelectSingleNode("//A_liq");

                if (root == null)
                {
                    throw new Exception("Error: No es un archivo válido.");
                }

                return xml;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        
        #endregion
    }
}
