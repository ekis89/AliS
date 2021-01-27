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

        //12/09 utlimo commit xD : ya me traje una tabla con la lista de codigoConcepto, ahora tengo que usar esa tabla para traer las descripciones
        // de esos conceptos
        public static DataTable RecuperarListaCodigosConceptosPorCodigoEmpresaYNumeroLegajo(int codigoEmpresa, string numeroLegajo)
        {
            try
            {
                string[] listaConceptos;
                int listaConceptosCount;

                DataTable tabla = CatalogoConcepto.RecuperarListaCodigosConceptosPorCodigoEmpresaYNumeroLegajo(codigoEmpresa, numeroLegajo);

                DataTable listaConceptosTabla = new DataTable();
                listaConceptosTabla.Columns.Add("codigoConcepto");


                if (tabla.Rows.Count > 0)
                {
                    listaConceptos = Convert.ToString(tabla.Rows[0]["conceptos"]).Replace("|", "").Split(';');
                    listaConceptosCount = listaConceptos.Length;

                    for (int i = 0; i < listaConceptosCount; i++)
                    {
                        DataRow row = listaConceptosTabla.NewRow();

                        row["codigoConcepto"] = listaConceptos[i];

                        listaConceptosTabla.Rows.Add(row);
                    }
                }

                return listaConceptosTabla;
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
                return CatalogoConcepto.RecuperarConceptosPorListaConceptosCodigoEmpresaYNumeroLegajo(tblCodigosConceptos, codigoEmpresa, numeroLegajo);
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
