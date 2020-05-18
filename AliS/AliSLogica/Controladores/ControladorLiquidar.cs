using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using AliSlib;

namespace AliSLogica.Controladores
{
    public class ControladorLiquidar
    {
        public static DataTable RecuperarPuesto(string numeroLegajo, string cuitEmpresa)
        {
            try
            {
                DataSet DS;
                string cmd = string.Format("SELECT puesto FROM Legajos WHERE n_legajo = '{0}' AND cuit_empresa = '{1}'", numeroLegajo, cuitEmpresa);

                DS = Utilidades.alisDB(cmd);

                return DS.Tables[0];
            }
            catch (Exception ex)
            {
                throw ex;
            }  
        }
    }
}
