using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using AliSlib;

namespace AliSLogica.Controladores
{
    public class ControladorAddConcepto
    {
        public static DataTable RecuperarListaConceptos(string nombreEmpresa)
        {
            try
            {
                string cmd = string.Format("SELECT codigo AS 'Código', descripcion AS 'Descripción', hab_fijo AS 'Fijo($)', hab_porc AS 'Porcentaje(%)', ded_fijo, ded_porc, tipo AS 'Tipo de concepto', modo, formula_porc  from {0}_Conceptos ORDER BY 'Tipo de concepto' DESC , 'Código' ASC ", nombreEmpresa.Replace(" ", ""));
                DataSet ds = Utilidades.alisDB(cmd);

                return ds.Tables[0];
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static void EliminarConcepto(string nombreEmpresa, string codigoConcepto)
        {
            try
            {
                string cmd = string.Format("DELETE FROM {0}_Conceptos WHERE codigo = '{1}'", nombreEmpresa, codigoConcepto);
                Utilidades.alisDB(cmd);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
