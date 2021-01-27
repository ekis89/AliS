using System;

namespace AliS_WinVer
{
    public class Legajo : ICloneable
    {
        public int codigoPersona { get; set; }
        public string NombreEmpleado { get; set; }
        public string EmpleadoCUIL { get; set; }
        public string PuestoRecibo { get; set; }
        public string FechaIngreso { get; set; }
        public string NumeroLegajo { get; set; }
        public string Banco { get; set; }
        public string Convenio { get; set; }
        public string TipoSalario { get; set; }
        public string CurrentUserXmlFolder { get; set; }

        public Legajo(int codigoPersona, string nombre, string cuil, string puesto, string fechaIngreso, string numeroLegajo, string banco, string convenio, string tipoSalario)
        {
            this.codigoPersona = codigoPersona;
            this.NombreEmpleado = nombre;
            this.EmpleadoCUIL = cuil;
            this.PuestoRecibo = puesto;
            this.FechaIngreso = fechaIngreso;
            this.NumeroLegajo = numeroLegajo;
            this.Banco = banco;
            this.Convenio = convenio;
            this.TipoSalario = tipoSalario;
        }

        public override string ToString()
        {
            return String.Format("Legajo: {0} | {1} | CUIL: {2}",NumeroLegajo, NombreEmpleado, EmpleadoCUIL);
        }

        public object Clone()
        {
            return new Legajo(this.codigoPersona, this.NombreEmpleado, this.EmpleadoCUIL, this.PuestoRecibo, this.FechaIngreso, this.NumeroLegajo, this.Banco, this.Convenio, this.TipoSalario);
        }
    }
}
