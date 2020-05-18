using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using AliSlib;

namespace AliSLogica.Controladores
{
    public class ControladorAddLegajos
    {

        public static DataTable RecuperarLegajos(string cuitEmpresa)
        {
            try
            {
                string cmd = string.Format("SELECT n_legajo FROM Legajos WHERE cuit_empresa = '{0}' ORDER BY n_legajo ASC", cuitEmpresa);
                DataSet ds = Utilidades.alisDB(cmd);

                return ds.Tables[0];
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public static void EliminarLegajos(string cuitEmpresa , string numeroLegajo)
        {
            try
            {
                string cmd = string.Format("DELETE FROM Legajos WHERE n_legajo = '{0}' AND cuit_empresa = '{1}'", numeroLegajo, cuitEmpresa);
                Utilidades.alisDB(cmd);
            }
            catch (Exception ex) { 
                throw ex;
            }

        }

        public static void InsertarLegajo(string cuitEmpresa, string empleadoNombre, string empleadoApellido, string empleadoCUIL1, string empleadoCUIL2, string empleadoCUIL3,
                string empleadoOcupacion, string empleadoIngreso, string conceptos, string legajoNumero, string banco, string convenio)
        {
            try
            {
                string cmd = string.Format("INSERT INTO Legajos (cuit_empresa , nombre, cuil, puesto, ingreso, conceptos, n_legajo, banco, convenio) VALUES ('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}')", cuitEmpresa, empleadoNombre + ' ' + empleadoApellido, empleadoCUIL1 + "-" + empleadoCUIL2 + "-" + empleadoCUIL3, empleadoOcupacion, empleadoIngreso, conceptos, legajoNumero, banco, convenio);
                Utilidades.alisDB(cmd);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public static void EditarLegajo(string cuitEmpresa, string empleadoNombre, string empleadoOcupacion, string conceptos, string legajoNumero, 
            string oldNumeroLegajo, string banco, string convenio)
        {
            try
            {
                string cmd = string.Format("UPDATE Legajos SET n_legajo = '{0}', nombre = '{1}', puesto = '{2}', banco = '{3}', convenio = '{4}', conceptos = '{5}' WHERE n_legajo = '{6}' AND cuit_empresa = '{7}'", legajoNumero, empleadoNombre, empleadoOcupacion, banco, convenio, conceptos, oldNumeroLegajo, cuitEmpresa);
                Utilidades.alisDB(cmd);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public static DataTable RecuperarPuestos(string cuitEmpresa)
        {
            try
            {
                string cmd = string.Format("SELECT E.cuit_empresa , P.puesto FROM Empresas E , Puestos P WHERE E.cuit_empresa = p.cuit_empresa AND E.cuit_empresa = '{0}'", cuitEmpresa);
                DataSet ds = Utilidades.alisDB(cmd);

                return ds.Tables[0];
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static DataTable RecuperarConceptos(string nombreEmpresa)
        {
            try
            {
                string cmd = string.Format("SELECT codigo AS 'Código', descripcion AS 'Descripción', tipo AS 'Tipo de concepto' from {0}_Conceptos ORDER BY 'Tipo de concepto' DESC", nombreEmpresa.Replace(" ",""));
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
