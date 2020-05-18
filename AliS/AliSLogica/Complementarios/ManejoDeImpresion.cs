using System;
using System.Collections.Generic;
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
            header.EmpleadoLegajoNum = string.Format("Nº {0}", legajoNumero);
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

        public static List<Concepto>GenerarDetalle(DataGridView dgvDetallesRecibo)
        {
            //CabeceraRecibo cabeceraRecibo = new CabeceraRecibo();

            List<Concepto> listaConceptos = new List<Concepto>();

            foreach (DataGridViewRow row in dgvDetallesRecibo.Rows)
            {
                Concepto conceptoItem = new Concepto();
                int index = dgvDetallesRecibo.Rows.IndexOf(row);
                string haberList;
                string deduccionList;
                string haberRow = dgvDetallesRecibo.Rows[index].Cells[4].Value.ToString().Replace("$", "");
                string deduccionRow = dgvDetallesRecibo.Rows[index].Cells[5].Value.ToString().Replace("$", "");


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

                conceptoItem.Descripcion = dgvDetallesRecibo.Rows[index].Cells[1].Value.ToString();
                conceptoItem.Haberes = haberList;
                conceptoItem.Deducciones = deduccionList;

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
            pieRecibo.TotalDeduccion = "- " + deducciones;
            pieRecibo.TotalNeto = "$ " + sueldoNeto;
            //pie.TotalNeto =  tneto.Text.Replace("$","");
            pieRecibo.FooterText = string.Format(" Recibí de: {0} - con domicilio en {1} \n LA CANTIDAD DE PESOS: {2} \n Correspondiente a los haberes de:  {3} según liquidación precedente de la que \n recibo duplicado y tomo conocimiento que los aportes jubilatorios del mes de {4},\n fueron depositados en {5} el {6}. \n Rosario.      {7}   ", empresaNombre.ToUpper(), empresaUbicacion, netoString, mesActual, mesAnterior, banco.ToUpper(), pagoString, FechaLiquidacion);

            return pieRecibo;

        }
    }
}
