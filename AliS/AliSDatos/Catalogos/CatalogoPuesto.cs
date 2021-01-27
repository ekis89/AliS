using System;
using AliSDatos.Complementarios;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace AliSDatos.Catalogos
{
    public class CatalogoPuesto
    {
        public static DataTable RecuperarPuestosPorEmpresa(int codigoEmpresa)
        {
            try
            {
                Dictionary<string, object> listaParametros = new Dictionary<string, object>();
                listaParametros.Add("intCodigoEmpresa",codigoEmpresa);

                return ManejoDeDBs.EjecutarConsultaEnProcedimiento("RecuperarPuestosPorEmpresa", listaParametros);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static DataTable RecuperarPuestoPorEmpresaYLegajo(int codigoEmpresa, string numeroLegajo)
        {
            try
            {
                Dictionary<string, object> listaParametros = new Dictionary<string, object>();
                listaParametros.Add("intCodigoEmpresa", codigoEmpresa);
                listaParametros.Add("intNumeroLegajo", numeroLegajo);

                return ManejoDeDBs.EjecutarConsultaEnProcedimiento("RecuperarPuestoPorEmpresaYLegajo", listaParametros);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static DataTable InsertarAcualizarPuesto(int codigoEmpresa, string codigo, int codigoPuesto, string descripcion, int tipoPuesto, string montoBasico)
        {
            try
            {
                Dictionary<string, object> listaParametros = new Dictionary<string, object>();
                listaParametros.Add("chvCodigo", codigo);
                listaParametros.Add("intCodigoEmpresa", codigoEmpresa);
                listaParametros.Add("intCodigoPuesto", codigoPuesto);
                listaParametros.Add("chvDescripcion", descripcion);
                listaParametros.Add("intCodigoTipoPuesto", tipoPuesto);
                listaParametros.Add("chvMontoBasico", montoBasico);

                return ManejoDeDBs.EjecutarConsultaEnProcedimiento("InsertarActualizarPuesto", listaParametros);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static DataTable EliminarPuestoPorCodigo(int codigoPuesto)
        {
            try
            {
                Dictionary<string, object> listaParametros = new Dictionary<string, object>();
                listaParametros.Add("intCodigoPuesto", codigoPuesto);

                return ManejoDeDBs.EjecutarConsultaEnProcedimiento("EliminarPuestoPorCodigo", listaParametros);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
