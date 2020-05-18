using System;
using System.Windows.Forms;
using AliSLogica.Controladores;

namespace AliS_WinVer
{
    public partial class CrearFormulaHaberFijo : Form
    {
        PrincipalConceptos screenConceptos;
        AñadirConcepto screenNewConcepto;
        EditarConcepto screenEditConcepto;
        bool isEditMode;
        
        public CrearFormulaHaberFijo(PrincipalConceptos screenConceptos, AñadirConcepto screenNewConcepto, EditarConcepto screenEditConcepto,  bool isEditMode)
        {
            InitializeComponent();
            this.screenConceptos = screenConceptos;
            this.screenNewConcepto = screenNewConcepto;
            this.screenEditConcepto = screenEditConcepto;
            this.isEditMode = isEditMode;
        }

        private void FormulaHab_Load(object sender, EventArgs e)
        {
            CargarConceptos();
        }


        private void dgvConceptosList_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            string codigo = dgvConceptosList.CurrentRow.Cells[1].Value.ToString();
            tbxFormula.Text += '|'+codigo+'|';
            tbxFormula.Focus();
            tbxFormula.SelectionStart = tbxFormula.Text.Length;
        }

        private void btnSumar_Click(object sender, EventArgs e)
        {
            tbxFormula.Text += " + ";
            tbxFormula.Focus();
            tbxFormula.SelectionStart = tbxFormula.Text.Length;
        }

        private void btnRestar_Click(object sender, EventArgs e)
        {
            tbxFormula.Text += " - ";
            tbxFormula.Focus();
            tbxFormula.SelectionStart = tbxFormula.Text.Length;
        }

        private void btnMultiplicar_Click(object sender, EventArgs e)
        {
            tbxFormula.Text += " * ";
            tbxFormula.Focus();
            tbxFormula.SelectionStart = tbxFormula.Text.Length;
        }

        private void btnDividir_Click(object sender, EventArgs e)
        {
            tbxFormula.Text += " / ";
            tbxFormula.Focus();
            tbxFormula.SelectionStart = tbxFormula.Text.Length;
        }

        private void btnParentesis1_Click(object sender, EventArgs e)
        {
            tbxFormula.Text += "(";
            tbxFormula.Focus();
            tbxFormula.SelectionStart = tbxFormula.Text.Length;
        }

        private void btnParentesis2_Click(object sender, EventArgs e)
        {
            tbxFormula.Text += ")";
            tbxFormula.Focus();
            tbxFormula.SelectionStart = tbxFormula.Text.Length;
        }

        private void btnPunto_Click(object sender, EventArgs e)
        {
            tbxFormula.Text += ".";
            tbxFormula.Focus();
            tbxFormula.SelectionStart = tbxFormula.Text.Length;
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if(isEditMode == true)
            {
                screenEditConcepto.tbxValorFijo.Text = tbxFormula.Text;
                Close();
            }
            else
            {
                screenNewConcepto.tbxHaberValor.Text = tbxFormula.Text;
                Close();
            }

        }

        #region METODOS
        public void CargarConceptos()
        {
            //dgvConceptosList.DataSource = ControladorPorcHabComp.RecuperarConceptos(UsuarioSingleton.Instance.NombreEmpresa);

            dgvConceptosList.DataSource = ControladorConcepto.RecuperarConceptosPorCodigoEmpresa(UsuarioSingleton.Instance.codigoEmpresa);

            dgvConceptosList.Columns[1].Width = 70;
            dgvConceptosList.Columns[2].Width = 200;
            dgvConceptosList.Columns[7].Width = 55;
            for (int i = 0; i <= 9; i++)
            {
                if ((i == 1) || (i == 2) || (i == 7))
                {
                    continue;
                }
                dgvConceptosList.Columns[i].Visible = false;
            }
        }
        #endregion

    }
}
