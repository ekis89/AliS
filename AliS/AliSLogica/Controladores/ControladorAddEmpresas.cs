using AliSlib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AliSLogica.Controladores
{
    public class ControladorAddEmpresas
    {

        public static void RegistrarEmpresa(string nombre, string cuit, string localidad, string codigoPostal, string direccion, string telefono)
        {
            string cmd = "";

            try
            {
                cmd = string.Format("INSERT INTO Empresas (cuit_empresa, nombre, localidad, direccion, telefono, codigo_postal) VALUES ('{0}','{1}','{2}','{3}','{4}','{5}')", cuit, nombre, localidad, direccion, telefono, codigoPostal);
                Utilidades.alisDB(cmd);

                cmd = string.Format("IF NOT EXISTS (SELECT * FROM sys.objects WHERE name='{0}_Conceptos') SELECT * INTO {0}_Conceptos FROM Conceptos", nombre.Replace(" ", ""));
                Utilidades.alisDB(cmd);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
    }
}
