using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace AliSLogica.Complementarios
{
    public class ManejoDirectiorios
    {
        public static void CrearDirectorioEmpleado(string alisFolder, string empresaNombre, string empresaCUIT, string empleadoNombre, string empleadoApellido, string empleadoCUIL1, string empleadoCUIL2, string empleadoCUIL3, string empleadoOcupacion, string empleadoIngreso, string conceptos, string legajoNumero, string banco, string convenio)
        {
            try
            {
                string empleadoFolder = (alisFolder + empresaNombre + "\\" + empleadoCUIL1 + empleadoCUIL2 + empleadoCUIL3 + "\\");

                if (!Directory.Exists(empleadoFolder))
                {
                    Directory.CreateDirectory(empleadoFolder);
                }
            }
            catch (IOException ex)
            {
                throw ex;
            }

        }

        public static void EliminarDirectorio(string directorio)
        {
            try
            {
                Directory.Delete(directorio, true);
            }
            catch (IOException ex)
            {
                throw ex;
            }
        }
    }
}
