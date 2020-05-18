using System;
using AliSDatos.Catalogos;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace AliSLogica.Controladores
{
    public class ControladorConcepto
    {
        public static DataTable RecuperarConceptosPorCodigoEmpresa(int codigoEmpresa)
        {
            try
            {
                return CatalogoConcepto.RecuperarConceptosPorCodigoEmpresa(codigoEmpresa);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static string InsertarActualizarConcepto(int codigoEmpresa, int codigoConceptoPorEmpresa, string codigo, string descripcion, string habFijo,
    string habPorc, string dedFijo, string dedPorc, int codigoTipoConcepto, int codigoModoConcepto, string formulaPorc)
        {
            try
            {

                DataTable rta = CatalogoConcepto.InsertarActualizarConcepto(codigoEmpresa, codigoConceptoPorEmpresa, codigo, descripcion, habFijo,
                      habPorc, dedFijo, dedPorc, codigoTipoConcepto, codigoModoConcepto, formulaPorc);

                return Convert.ToString(rta.Rows[0][0]);
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
                return CatalogoConcepto.EliminarConceptoPorEmpresa(codigoConceptoPorEmpresa);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
