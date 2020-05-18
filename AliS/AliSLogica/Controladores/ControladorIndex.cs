using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AliSlib;

namespace AliSLogica.Controladores
{
    public static class ControladorIndex
    {

        public static DataSet CargarEmpresas()
        {
            try
            {
                string cmd = string.Format("SELECT nombre , cuit_empresa , direccion , localidad , telefono , codigo_postal FROM Empresas ORDER BY nombre ASC");
                DataSet ds = Utilidades.alisDB(cmd);

                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static void EliminarEmpresa(string empresaFolder, string cuitEmpresa, string nombreEmpresa)
        {
            try
            {
                string cmd;

                if (Directory.Exists(empresaFolder))
                {
                    Directory.Delete(empresaFolder, true);
                }

                cmd = string.Format("EXEC DeleteEmpresa '{0}','{1}'", cuitEmpresa, nombreEmpresa.Replace(" ", ""));
                Utilidades.alisDB(cmd);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static string RecuperarNumeroDeLegajos(string cuitEmpresa)
        {
            try
            {
                string cmd = string.Format("SELECT count(*) FROM Legajos WHERE cuit_empresa = '{0}'", cuitEmpresa /*cuitInfo.Text*/);
                DataSet DataSetLegajos = Utilidades.alisDB(cmd);
                DataTable dt = DataSetLegajos.Tables[0];

                return dt.Rows[0][0].ToString();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

    }
}
