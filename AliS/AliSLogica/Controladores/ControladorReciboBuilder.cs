using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using AliSlib;

namespace AliSLogica.Controladores
{
    public class ControladorReciboBuilder
    {
        public static DataTable RecuperarLegajos(string cuitEmpresa)
        {
            try
            {
                string cmd = string.Format("SELECT L.nombre, L.cuil, L.puesto, L.ingreso, L.n_legajo, P.tipo, L.banco, L.convenio FROM Empresas E, Legajos L , Puestos P WHERE L.cuit_empresa = '{0}' AND E.cuit_empresa = L.cuit_empresa AND P.cuit_empresa = L.cuit_empresa AND P.puesto = L.puesto ORDER BY L.n_legajo ASC", cuitEmpresa);
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
