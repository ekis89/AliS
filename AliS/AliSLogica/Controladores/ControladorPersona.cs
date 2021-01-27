using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using AliSDatos.Catalogos;

namespace AliSLogica.Controladores
{
    public class ControladorPersona
    {
        public static string InsertarActualizarPersona(int codigoPersonaPorEmpresa, int codigoEmpresa, int numeroLegajo, string nombre,
            string apellido, string cuil, int codigoPuesto, string convenio, DateTime fechaIngreso, string banco, string conceptos)
        {
            try
            {
                DataTable tabla = CatalogoPersona.InsertarActualizarPersona(codigoPersonaPorEmpresa, codigoEmpresa, numeroLegajo, nombre,
                    apellido, cuil, codigoPuesto, convenio, fechaIngreso, banco, conceptos);

                return Convert.ToString(tabla.Rows[0][0]);
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
                return CatalogoPersona.RecuperarPersonasPorEmpresa(codigoEmpresa);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }

}
