using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace AliSDatos.Complementarios
{
    public class ManejoDeDBs
    {
        public static DataTable EjecutarConsultaEnProcedimiento(string nombreProcedimiento, Dictionary<string, object> listaParametros)
        {
            DataTable tablaConsulta = new DataTable();
            SqlConnection conexionSQL = new SqlConnection("Data Source=.;Initial Catalog=AliS-Sueldos;Integrated Security=True");
            conexionSQL.Open();
            try
            {
                SqlDataAdapter adaptador = new SqlDataAdapter(nombreProcedimiento, conexionSQL);

                adaptador.SelectCommand.CommandType = CommandType.StoredProcedure;

                foreach (KeyValuePair<string, object> parametro in listaParametros)
                {
                    adaptador.SelectCommand.Parameters.AddWithValue("@" + parametro.Key, parametro.Value);
                }

                adaptador.SelectCommand.CommandTimeout = 120000000;

                adaptador.Fill(tablaConsulta);
                return tablaConsulta;
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                conexionSQL.Close();
                conexionSQL.Dispose();
            }
        }
    }
}
