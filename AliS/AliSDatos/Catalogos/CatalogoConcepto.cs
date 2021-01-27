using System;
using AliSDatos.Complementarios;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace AliSDatos.Catalogos
{
    public class CatalogoConcepto
    {
        public static DataTable RecuperarConceptosPorCodigoEmpresa(int codigoEmpresa)
        {
            try
            {
                Dictionary<string, object> listaParametros = new Dictionary<string, object>();
                listaParametros.Add("intCodigoEmpresa", codigoEmpresa);

                return ManejoDeDBs.EjecutarConsultaEnProcedimiento("RecuperarConceptosPorCodigoEmpresa", listaParametros);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static DataTable RecuperarListaCodigosConceptosPorCodigoEmpresaYNumeroLegajo(int codigoEmpresa, string numeroLegajo)
        {
            try
            {
                Dictionary<string, object> listaParametros = new Dictionary<string, object>();
                listaParametros.Add("intCodigoEmpresa", codigoEmpresa);
                listaParametros.Add("chvNumeroLegajo", numeroLegajo);

                return ManejoDeDBs.EjecutarConsultaEnProcedimiento("RecuperarListaCodigosConceptosPorCodigoEmpresaYNumeroLegajo", listaParametros);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static DataTable RecuperarConceptosPorListaConceptosCodigoEmpresaYNumeroLegajo(DataTable tblCodigosConceptos, int codigoEmpresa, string numeroLegajo)
        {
            try
            {
                Dictionary<string, object> listaParametros = new Dictionary<string, object>();
                listaParametros.Add("tblCodigosConcepto", tblCodigosConceptos);
                listaParametros.Add("intCodigoEmpresa", codigoEmpresa);
                listaParametros.Add("chvNumeroLegajo", numeroLegajo);

                return ManejoDeDBs.EjecutarConsultaEnProcedimiento("RecuperarConceptosPorListaConceptosCodigoEmpresaYNumeroLegajo", listaParametros);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static DataTable InsertarActualizarConcepto(int codigoEmpresa, int codigoConceptoPorEmpresa, string codigo, string descripcion, string habFijo,
            string habPorc, string dedFijo, string dedPorc, int codigoTipoConcepto, int codigoModoConcepto, string formulaPorc)
        {
            try
            {
                Dictionary<string, object> listaParametros = new Dictionary<string, object>();
                listaParametros.Add("intCodigoConceptoPorEmpresa", codigoConceptoPorEmpresa);
                listaParametros.Add("intCodigoEmpresa", codigoEmpresa);
                listaParametros.Add("chvCodigo", codigo);
                listaParametros.Add("chvDescripcion", descripcion);
                listaParametros.Add("chvHabFijo", habFijo == null ? (object)DBNull.Value : habFijo);
                listaParametros.Add("chvHabPorc", habPorc == null ? (object)DBNull.Value : habPorc);
                listaParametros.Add("chvDedFijo", dedFijo == null ? (object)DBNull.Value : dedFijo);
                listaParametros.Add("chvDedPorc", dedPorc == null ? (object)DBNull.Value : dedPorc);
                listaParametros.Add("intCodigoTipoConcepto", codigoTipoConcepto);
                listaParametros.Add("intCodigoModoConcepto", codigoModoConcepto);
                listaParametros.Add("chvFormulaPorc", formulaPorc == null ? (object)DBNull.Value : formulaPorc);

                return ManejoDeDBs.EjecutarConsultaEnProcedimiento("InsertarActualizarConcepto", listaParametros);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static DataTable EliminarConceptoPorEmpresa(int codigoConceptoPorEmpresa)
        {
            try
            {
                Dictionary<string, object> listaParametros = new Dictionary<string, object>();
                listaParametros.Add("intCodigoConceptoPorEmpresa", codigoConceptoPorEmpresa);

                return ManejoDeDBs.EjecutarConsultaEnProcedimiento("EliminarConceptoPorEmpresa", listaParametros);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
