using System;
using AliSDatos.Catalogos;
using System.Data;
using System.IO;

namespace AliSLogica.Controladores
{
    public class ControladorEmpresa
    {
        public static string InsertarActualizarEmpresa(int codigoEmpresa, string nombre, string cuit, string localidad, int codigoPostal, string direccion, string telefono)
        {
            try
            {
                DataTable dt = CatalogoEmpresa.InsertarActualizarEmpresa(codigoEmpresa, nombre, cuit, localidad, codigoPostal, direccion, telefono);
                return Convert.ToString(dt.Rows[0][0]);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static DataTable RecuperarEmpresas()
        {
            try
            {
                return CatalogoEmpresa.RecuperarEmpresas();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static int RecuperarCantidadLegajos(int codigoEmpresa)
        {
            try
            {
                DataTable rta = CatalogoEmpresa.RecuperarCantidadLegajos(codigoEmpresa);

                return Convert.ToInt32(rta.Rows[0][0]);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static string EliminarEmpresaPorCodigoEmpresa(int codigoEmpresa, string rutaCarpetaEmpresa)
        {
            try
            {
                DataTable tabla = CatalogoEmpresa.EliminarEmpresaPorCodigoEmpresa(codigoEmpresa);
                string rta = Convert.ToString(tabla.Rows[0][0]);

                if (rta.Equals("ok"))
                {
                    EliminarDirectorio(rutaCarpetaEmpresa);
                }

                return rta;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private static void EliminarDirectorio(string rutaCarpetaEmpresa)
        {
            try
            {
                if (Directory.Exists(rutaCarpetaEmpresa))
                {
                    Directory.Delete(rutaCarpetaEmpresa, true);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static DataTable RecuperarParametrosPorCodigoTipoParametro(int codigoTipoParametro)
        {
            try
            {
                return CatalogoEmpresa.RecuperarParametrosPorCodigoTipoParametro(codigoTipoParametro);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
