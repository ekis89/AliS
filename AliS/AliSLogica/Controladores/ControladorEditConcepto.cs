using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AliSlib;

namespace AliSLogica.Controladores
{
    public class ControladorEditConcepto
    {

        public static void ActualizarConceptoHaber(string nombreEmpresa, string codigoAeditar, string codigoNuevo, string descripcion, string valorFijo, 
            string valorPorcentual, string componentesPorcentaje, string tipo, string modo)
        {
            try
            {
                string cmd = string.Format("UPDATE {0}_Conceptos SET codigo='{1}', descripcion = '{2}', hab_fijo = '{3}', hab_porc = '{4}', tipo = '{5}', modo = '{6}', formula_porc = '{7}' WHERE codigo = '{8}'",
                    nombreEmpresa.Replace(" ",""), codigoNuevo, descripcion, valorFijo, valorPorcentual, tipo, modo, componentesPorcentaje, codigoAeditar);
                Utilidades.alisDB(cmd);

            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public static void ActualizarConceptoDeduccion(string nombreEmpresa, string codigoAeditar, string codigoNuevo, string descripcion, string valorFijo,
            string valorPorcentual, string componentesPorcentaje, string tipo, string modo)
        {
            try
            {
                string cmd = string.Format("UPDATE {0}_Conceptos SET codigo='{1}', descripcion = '{2}', ded_fijo = '{3}', ded_porc = '{4}', tipo = '{5}', modo = '{6}', formula_porc = '{7}' WHERE codigo = '{8}'",
                    nombreEmpresa.Replace(" ", ""), codigoNuevo, descripcion, valorFijo, valorPorcentual, tipo, modo, componentesPorcentaje, codigoAeditar);
                Utilidades.alisDB(cmd);

            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
    }
}
