using System;
using System.Data;
using System.Windows.Forms;
using Obj;

namespace AliS_WinVer
{
    public partial class Calculator : Form
    {
        ReciboBuilderMini FRC;
        public Calculator(ReciboBuilderMini FRC)
        {
            InitializeComponent();
            this.FRC = FRC;
        }

        private void Calculator_Load(object sender, EventArgs e)
        {
            dgvConceptosList.DataSource = FRC.dtDetalle;
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

        private void dgvConceptosList_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            string Check = dgvConceptosList.CurrentRow.Cells[4].Value.ToString();

            if(Check == "RM" || Check == "NRM")
            {
                tbxFormula.Text += dgvConceptosList.CurrentRow.Cells[2].Value.ToString();
            }
            else
            {
                tbxFormula.Text += dgvConceptosList.CurrentRow.Cells[3].Value.ToString();
            }
            tbxFormula.Focus();
            tbxFormula.SelectionStart = tbxFormula.Text.Length;
        }

        private void btnCalcular_Click(object sender, EventArgs e)
        {
            try
            {
                string formula = tbxFormula.Text;
                string result = new DataTable().Compute(formula.Replace(",","."), null).ToString();

                FRC.tbxValor.Text = result;
                
                Close();

            }
            catch(Exception error)
            {
                MessageBox.Show("Error: Problema al evaluar la expresión.");
                throw error;
            }
        }

        private void tbxFormula_KeyPress(object sender, KeyPressEventArgs e)
        {
            UsuarioSingleton.SoloNumerosYcoma(e);
        }

        private void Calculator_FormClosing(object sender, FormClosingEventArgs e)
        {
            FRC.Enabled = true;
        }
    }
}
