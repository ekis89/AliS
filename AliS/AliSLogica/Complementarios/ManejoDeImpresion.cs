using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using System.Linq;
using System.Text;
using AliSDatos.Clases;

namespace AliSLogica.Complementarios
{
    public class ManejoDeImpresion
    {

        public static CabeceraRecibo GenerarEncabezadoRecibo(string empresaNombre, string empresaCuit, string empresaConvenio, string empresaDireccion,
            string empresaPostal, string empresaLocalidad, string empresaTelefono, string legajoNumero, string empleadoNombre, string empleadoCuil,
            string empleadoIngreso, string empleadoPuesto, string salarioNetoEnLetras, string[] mesesSingleton, int mesSeleccionado, int añoActual, bool isQuincenaEnabled, string quincenaLiquidada)
        {
            //List<CabeceraRecibo> listaCabeceraRecibo = new List<CabeceraRecibo>();

            CabeceraRecibo header = new CabeceraRecibo();
            header.EmpleadoLegajoNum = string.Format("Nº {0}", Convert.ToInt32(legajoNumero).ToString("000"));
            header.EmpresaNombre = empresaNombre.ToUpper();
            header.EmpresaCuit = string.Format("CUIT: {0}", empresaCuit);
            header.EmpresaConvenio = string.Format("CONVENIO:     {0}", empresaConvenio);
            header.EmpresaUbicacion = string.Format("{0} - {1} - {2}", empresaDireccion, empresaPostal, empresaLocalidad);
            header.EmpresaTelefono = empresaTelefono;

            header.EmpleadoNombre = empleadoNombre;
            header.EmpleadoCuil = string.Format("CUIL: {0}", empleadoCuil);
            header.EmpleadoPuesto = string.Format("OCUPAC. Y CATEG.:     {0}", empleadoPuesto.ToUpper());
            header.EmpleadoIngreso = string.Format("F.INGRESO:{0}", empleadoIngreso);
            header.NetoString = salarioNetoEnLetras;

            header.Periodo = string.Format("PERIODO LIQUIDADO:   {0} de {1}", mesesSingleton[mesSeleccionado].ToUpper(), añoActual);

            if (isQuincenaEnabled)
            {
                if (quincenaLiquidada.Equals("Primera"))
                {
                    header.Periodo = string.Format("PERIODO LIQUIDADO:   {0} de {1} (Quincena 1)", mesesSingleton[mesSeleccionado].ToUpper(), añoActual);
                }
                else if (quincenaLiquidada.Equals("Segunda"))
                {
                    header.Periodo = string.Format("PERIODO LIQUIDADO:   {0} de {1} (Quincena 2)", mesesSingleton[mesSeleccionado].ToUpper(), añoActual);
                }
            }

            //listaCabeceraRecibo.Add(header);

            return header;
        }

        public static List<Concepto>GenerarDetalle(DataTable dt)
        {
            List<Concepto> listaConceptos = new List<Concepto>();

            foreach (DataRow row in dt.Rows)
            {
                Concepto conceptoItem = new Concepto();

                string haberList;
                string deduccionList;
                string haberRow = (Convert.ToString(row["tipo"]) == "RM" || Convert.ToString(row["tipo"]) == "NRM" || Convert.ToString(row["tipo"]) == "BAS") ? Convert.ToString(row["total"]).Replace("$", "") : "";
                string deduccionRow = (Convert.ToString(row["tipo"]) == "DED" ) ? Convert.ToString(row["total"]).Replace("$", "") : "";
                string porcentajeRow = "";

                if (Convert.ToString(row["modo"]) == "hab_porc")
                    porcentajeRow = Convert.ToString(row["hab_porc"]) + "%";
                else if (Convert.ToString(row["modo"]) == "ded_porc")
                    porcentajeRow = Convert.ToString(row["ded_porc"]) + "%";


                if (haberRow.Length != 0 || haberRow != "")
                {
                    haberList = string.Format("{0:0,0.00}", double.Parse(haberRow));
                }
                else
                {
                    haberList = "";
                }

                if (deduccionRow.Length != 0 || deduccionRow != "")
                {
                    deduccionList = string.Format("{0:0,0.00}", double.Parse(deduccionRow));
                }
                else
                {
                    deduccionList = "";
                }

                conceptoItem.Descripcion = Convert.ToString(row["descripcion"]);
                conceptoItem.Haberes = haberList;
                conceptoItem.Deducciones = deduccionList;
                conceptoItem.Tipo = Convert.ToString(row["tipo"]);
                conceptoItem.Porcentaje = porcentajeRow;

                listaConceptos.Add(conceptoItem);
            }

            return listaConceptos;
        }

        public static List<Concepto> GenerarDetalleMINI(DataTable dtDetalle)
        {
            List<Concepto> listaConceptos = new List<Concepto>();

            foreach (DataRow row in dtDetalle.Rows)
            {
                Concepto conceptoItem = new Concepto();
                //int index = dgvDetallesRecibo.Rows.IndexOf(row);
                string haberList;
                string deduccionList;
                //string haberRow = dgvDetallesRecibo.Rows[index].Cells[2].Value.ToString().Replace("$", "");
                string haberRow = Convert.ToString(row["Haberes"]).Replace("$", "");
                //string deduccionRow = dgvDetallesRecibo.Rows[index].Cells[3].Value.ToString().Replace("$", "");
                string deduccionRow = Convert.ToString(row["Deducciones"]).Replace("$", "");
                string porcentajeRow = String.IsNullOrEmpty(Convert.ToString(row["Porcentaje"])) ? "" : Convert.ToString(row["Porcentaje"]) + "%";


                if (haberRow.Length != 0 || haberRow != "")
                {
                    haberList = string.Format("{0:0,0.00}", double.Parse(haberRow));
                }
                else
                {
                    haberList = "";
                }

                if (deduccionRow.Length != 0 || deduccionRow != "")
                {
                    deduccionList = string.Format("{0:0,0.00}", double.Parse(deduccionRow));
                }
                else
                {
                    deduccionList = "";
                }

                conceptoItem.Descripcion = Convert.ToString(row["Descripcion"]);
                conceptoItem.Haberes = haberList;
                conceptoItem.Deducciones = deduccionList;
                conceptoItem.Tipo = Convert.ToString(row["Tipo"]);
                conceptoItem.Porcentaje = porcentajeRow;

                listaConceptos.Add(conceptoItem);
            }

            return listaConceptos;
        }

        public static PieRecibo GenerarPieRecibo(string remunerativo, string noRemunerativo, string deducciones, string sueldoNeto, string empresaNombre,
            string empresaUbicacion, string netoString, string mesActual, string mesAnterior, string banco, string pagoString, string FechaLiquidacion)
        {
            PieRecibo pieRecibo = new PieRecibo();

            pieRecibo.TotalRemunerativo = remunerativo;
            pieRecibo.TotalNoRemunerativo = noRemunerativo;
            pieRecibo.TotalDeduccion = deducciones;
            pieRecibo.TotalNeto = "$ " + sueldoNeto;
            //pie.TotalNeto =  tneto.Text.Replace("$","");
            pieRecibo.FooterText = string.Format(" Recibí de: {0} - con domicilio en {1} \n LA CANTIDAD DE PESOS: {2} \n Correspondiente a los haberes de:  {3} según liquidación precedente de la que \n recibo duplicado y tomo conocimiento que los aportes jubilatorios del mes de {4},\n fueron depositados en {5} el {6}. \n Rosario.      {7}   ", empresaNombre.ToUpper(), empresaUbicacion, netoString, mesActual, mesAnterior, banco.ToUpper(), pagoString, FechaLiquidacion);

            return pieRecibo;
        }

        public static PieRecibo GenerarPieReciboMINI(string remunerativo, string noRemunerativo, string deducciones, string sueldoNeto, string footerText)
        {
            PieRecibo pieRecibo = new PieRecibo();

            pieRecibo.TotalRemunerativo = remunerativo;
            pieRecibo.TotalNoRemunerativo = noRemunerativo;
            pieRecibo.TotalDeduccion = deducciones;
            pieRecibo.TotalNeto = "$ " + sueldoNeto;

            pieRecibo.FooterText = footerText;

            return pieRecibo;
        }
    }
}
