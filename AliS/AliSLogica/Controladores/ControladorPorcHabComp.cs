using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using AliSlib;

namespace AliSLogica.Controladores
{
    public class ControladorPorcHabComp
    {

        public static DataTable RecuperarConceptos(string empresaNombre)
        {
            try
            {
                string cmd = string.Format("SELECT codigo, descripcion, hab_fijo, hab_porc, ded_fijo, ded_porc, tipo, modo, formula_porc FROM {0}_Conceptos WHERE tipo != 'DED' ORDER BY tipo DESC", empresaNombre);
                DataSet ds = Utilidades.alisDB(cmd);

                return ds.Tables[0];
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
