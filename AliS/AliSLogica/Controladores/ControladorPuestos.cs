using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using AliSlib;

namespace AliSLogica.Controladores
{
    public class ControladorPuestos
    {
        public static DataTable CargarPuestos(string cuitEmpresa)
        {
            try
            {
                string cmd = string.Format("SELECT P.cuit_empresa ,P.puesto AS 'Puesto', P.tipo as 'Tipo', P.basico AS 'Basico ($)' FROM Empresas E, Puestos P WHERE P.cuit_empresa = '{0}' AND E.cuit_empresa = P.cuit_empresa ORDER BY puesto ASC ", cuitEmpresa);
                DataSet ds = Utilidades.alisDB(cmd);

                return ds.Tables[0];
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public static void EditarPuesto(string promptValue, string cuitEmpresa, string value)
        {
            try
            {
                string cmd = string.Format("UPDATE Puestos SET basico = '{0}' WHERE cuit_empresa = '{1}' AND puesto = '{2}'", promptValue, cuitEmpresa, value);
                Utilidades.alisDB(cmd);

            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public static void EliminarPuesto(string cuitEmpresa, string value)
        {
            try
            {
                string cmd = string.Format("DELETE FROM Puestos WHERE cuit_empresa = '{0}' AND puesto = '{1}'", cuitEmpresa, value);
                Utilidades.alisDB(cmd);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
    }
}
