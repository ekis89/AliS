using System.Collections.Generic;

namespace AliSDatos.Clases
{
    class ReciboDeSueldo
    {
    }

    public class Concepto
    {
        public string Descripcion { get; set; }
        public string Haberes { get; set; }
        public string Deducciones { get; set; }
    }

    public class CabeceraRecibo
    {
        //datos de la empresa.
        public string EmpresaNombre { get; set; }
        public string EmpresaConvenio { get; set; }
        public string EmpresaCuit { get; set; }
        public string EmpresaUbicacion { get; set; }
        public string EmpresaTelefono { get; set; }
        //datos del empleado.
        public string EmpleadoLegajoNum { get; set; }
        public string EmpleadoNombre { get; set; }
        public string EmpleadoCuil { get; set; }
        public string EmpleadoPuesto { get; set; }
        public string EmpleadoIngreso { get; set; }

        public string Periodo { get; set; }

        public string NetoString { get; set; }

        public List<Concepto> Detalle = new List<Concepto>();
    }

    public class PieRecibo
    {
        //periodo liquidado
        public string Periodo { get; set; }

        //Donde se hace el deposito.
        public string Banco { get; set; }

        //Totales
        public string TotalRemunerativo { get; set; }
        public string TotalNoRemunerativo { get; set; }
        public string TotalDeduccion { get; set; }
        public string TotalNeto { get; set; }
        //Texto del final del recibo.
        public string FooterText { get; set; }
    }
}
