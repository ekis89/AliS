using AliSlib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AliSLogica.Controladores
{
    public class ControladorAddPuesto
    {

        public static void AgregarPuesto(string cuitEmpresa, string puesto, string tipo, string basico)
        {
            try
            {
                string cmd = string.Format("INSERT INTO Puestos (cuit_empresa, puesto, tipo, basico) VALUES ('{0}','{1}','{2}','{3}')", cuitEmpresa, puesto, tipo, basico);
                Utilidades.alisDB(cmd);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
