using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AliSlib;


namespace AliSLogica.Controladores
{
    public class ControladorNewConcepto
    {

        public static void InsertarConceptoHaber(string nombreEmpresa, string codigo, string descripcion, string valorFijo, string valorPorcentual, string tipo, string modo, string componentesPorcentaje)
        {
            try
            {
                string cmd = string.Format("INSERT INTO {0}_Conceptos (codigo, descripcion, hab_fijo, hab_porc, tipo, modo, formula_porc) VALUES ('{1}','{2}','{3}','{4}','{5}','{6}','{7}')",
                    nombreEmpresa, codigo, descripcion, valorFijo, valorPorcentual, tipo, modo, componentesPorcentaje);
                Utilidades.alisDB(cmd);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static void InsertarConceptoDeduccion(string nombreEmpresa, string codigo, string descripcion, string valorFijo, string valorPorcentual, string tipo, string modo, string componentesPorcentaje)
        {
            try
            {
                string cmd = string.Format("INSERT INTO {0}_Conceptos (codigo, descripcion, ded_fijo, ded_porc, tipo, modo, formula_porc) VALUES ('{1}','{2}','{3}','{4}','{5}','{6}','{7}')",
                    nombreEmpresa, codigo, descripcion, valorFijo, valorPorcentual, tipo, modo, componentesPorcentaje);
                Utilidades.alisDB(cmd);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
