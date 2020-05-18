using System;
using System.Collections.Generic;
using System.Data;
using AliSDatos.Complementarios;
using System.Linq;
using System.Text;

namespace AliSDatos.Catalogos
{
    public class CatalogoEmpresa
    {

        public static DataTable InsertarActualizarEmpresa(int codigoEmpresa, string nombre, string cuit, string localidad, int codigoPostal, string direccion, string telefono)
        {
            try
            {
                Dictionary<string, object> listaParametros = new Dictionary<string, object>();
                listaParametros.Add("intCodigoEmpresa",codigoEmpresa);
                listaParametros.Add("chvNombre", nombre);
                listaParametros.Add("chvCuit", cuit);
                listaParametros.Add("chvLocalidad", localidad);
                listaParametros.Add("intCodigoPostal", codigoPostal);
                listaParametros.Add("chvDireccion", direccion);
                listaParametros.Add("chvTelefono", telefono);

                return ManejoDeDBs.EjecutarConsultaEnProcedimiento("InsertarAcualizarEmpresa", listaParametros);
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
                Dictionary<string, object> listaParametros = new Dictionary<string, object>();

                return ManejoDeDBs.EjecutarConsultaEnProcedimiento("RecuperarEmpresas", listaParametros);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static DataTable RecuperarCantidadLegajos(int codigoEmpresa)
        {
            try
            {
                Dictionary<string, object> listaParametros = new Dictionary<string, object>();
                listaParametros.Add("intCodigoEmpresa", codigoEmpresa);

                return ManejoDeDBs.EjecutarConsultaEnProcedimiento("RecuperarCantidadLegajos", listaParametros);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        
    }
}
