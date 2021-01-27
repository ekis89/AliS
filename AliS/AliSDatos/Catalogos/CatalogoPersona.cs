using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using AliSDatos.Complementarios;

namespace AliSDatos.Catalogos
{
    public class CatalogoPersona
    {
        public static DataTable InsertarActualizarPersona(int codigoPersonaPorEmpresa, int codigoEmpresa, int numeroLegajo, string nombre,
            string apellido, string cuil, int codigoPuesto, string convenio, DateTime fechaIngreso, string banco, string conceptos)
        {
            try
            {
                Dictionary<string, object> listaParametros = new Dictionary<string, object>();
                listaParametros.Add("intCodigoPersonaPorEmpresa", codigoPersonaPorEmpresa);
                listaParametros.Add("intCodigoEmpresa", codigoEmpresa);
                listaParametros.Add("intNumeroLegajo", numeroLegajo);
                listaParametros.Add("chvNombre", nombre);
                listaParametros.Add("chvApellido", apellido);
                listaParametros.Add("chvCuil", cuil);
                listaParametros.Add("intCodigoPuesto", codigoPuesto);
                listaParametros.Add("chvConvenio", convenio);
                listaParametros.Add("dtFechaIngreso", fechaIngreso);
                listaParametros.Add("chvBanco", banco);
                listaParametros.Add("chvConceptos", conceptos);

                return ManejoDeDBs.EjecutarConsultaEnProcedimiento("InsertarActualizarPersona", listaParametros);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static DataTable RecuperarPersonasPorEmpresa(int codigoEmpresa)
        {
            try
            {
                Dictionary<string, object> listaParametros = new Dictionary<string, object>();
                listaParametros.Add("intCodigoEmpresa", codigoEmpresa);

                return ManejoDeDBs.EjecutarConsultaEnProcedimiento("RecuperarPersonasPorEmpresa", listaParametros);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
