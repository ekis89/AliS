using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AliS_WinVer.Clases
{
    public class Empresa : ICloneable
    {
        public int codigoEmpresa { get; set; }
        public string NombreEmpresa { get; set; }
        public string CuitEmpresa { get; set; }
        public string ConvenioEmpresa { get; set; }
        public string LocalidadEmpresa { get; set; }
        public int PostalEmpresa { get; set; }
        public string DireccionEmpresa { get; set; }
        public string TelefonoEmpresa { get; set; }

        public Empresa(int codigoEmpresa, string nombre, string cuit, string localidad, int postal, string direccion, string telefono, string convenio = "")
        {
            this.codigoEmpresa = codigoEmpresa;
            this.NombreEmpresa = nombre;
            this.CuitEmpresa = cuit;
            this.LocalidadEmpresa = localidad;
            this.PostalEmpresa = postal;
            this.DireccionEmpresa = direccion;
            this.TelefonoEmpresa = telefono;
            this.ConvenioEmpresa = convenio;
        }

        public object Clone()
        {
            return new Empresa(codigoEmpresa, this.NombreEmpresa, this.CuitEmpresa, this.LocalidadEmpresa, this.PostalEmpresa, this.DireccionEmpresa, this.TelefonoEmpresa, this.ConvenioEmpresa);
        }
    }
}
