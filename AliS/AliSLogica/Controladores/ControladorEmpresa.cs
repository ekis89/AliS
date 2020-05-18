using System;
using AliSDatos.Catalogos;
using System.Data;

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
    }
}
