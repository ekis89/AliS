using AliS_WinVer.Clases;
using System;
using System.Windows.Forms;

namespace AliS_WinVer
{
    class UsuarioSingleton
    {
        private static UsuarioSingleton instance = null;

        public string UserFolder = "";
        public string AlisFolder = "";
        private string currentUserXmlFolder;

        public Legajo _Legajo { get; set; }
        public Empresa _Empresa { get; set; }

        //public int codigoEmpresa { get; set; }
        //public string NombreEmpresa { get; set; }
        //public string CuitEmpresa { get; set; }
        //public string ConvenioEmpresa { get; set; }
        //public string LocalidadEmpresa { get; set; }
        //public int PostalEmpresa { get; set; }
        //public string DireccionEmpresa { get; set; }
        //public string TelefonoEmpresa { get; set; }

        //public int codigoPersona { get; set; }
        //public string NombreEmpleado { get; set; }
        //public string EmpleadoCUIL { get; set; }
        //public string PuestoRecibo { get; set; }
        //public string FechaIngreso { get; set; }
        //public string LegajoNumero { get; set; }
        //public string Banco { get; set; }
        //public string Convenio { get; set; }
        //public string TipoSalario { get; set; }

        //public string CurrentUserXmlFolder
        //{
        //    get { return currentUserXmlFolder; }
        //    set { currentUserXmlFolder = AlisFolder + value; }
        //}

        public string[] Meses = new string[] { "Undefined", "Enero", "Febrero", "Marzo", "Abril", "Mayo", "Junio", "Julio", "Agosto", "Septiembre", "Octubre", "Noviembre", "Diciembre" };

        protected UsuarioSingleton()
        {
            UserFolder = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);
            AlisFolder = UserFolder + "\\documents\\Alis\\";
        }

        public static UsuarioSingleton Instance
        {
            get
            {
                if (instance == null)
                    instance = new UsuarioSingleton();

                return instance;
            }
        }

        #region METODOS
        public static string UppercaseFirst(string s)
        {
            if (string.IsNullOrEmpty(s))
            {
                return string.Empty;
            }
            char[] a = s.ToCharArray();
            a[0] = char.ToUpper(a[0]);
            return new string(a);
        }

        public static void SoloNumeros(KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        public static void SoloNumerosYcoma(KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != ',')
            {
                e.Handled = true;
            }
        }
        #endregion
    }
}
