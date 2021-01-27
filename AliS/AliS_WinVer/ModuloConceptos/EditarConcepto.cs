using System;
using System.Data;
using System.Windows.Forms;
using AliS_WinVer.Clases;
using AliSlib;
using AliSLogica.Controladores;

namespace AliS_WinVer
{
    public partial class EditarConcepto : Form
    {
        #region PROPIEDADES
        PrincipalConceptos screenConceptos;

        string OldCodigoConcepto;
        string OldDescripcionConcepto;
        string TipoConcepto;

        bool isEdit;

        private Empresa _empresa;

        #endregion

        #region INICIO
        public EditarConcepto(PrincipalConceptos screenConceptos, Empresa empresa, bool isEdit)
        {
            InitializeComponent();
            this.screenConceptos = screenConceptos;

            this.OldCodigoConcepto = Convert.ToString(screenConceptos.dgvConceptos.CurrentRow.Cells[1].Value);
            this.OldDescripcionConcepto = Convert.ToString(screenConceptos.dgvConceptos.CurrentRow.Cells[2].Value);
            this.TipoConcepto = Convert.ToString(screenConceptos.dgvConceptos.CurrentRow.Cells[7].Value);
            this.isEdit = isEdit;

            this._empresa = empresa;
        }

        private void EditConcepto_Load(object sender, EventArgs e)
        {
            

            tbxCodigo.Text = OldCodigoConcepto;
            tbxNombre.Text = OldDescripcionConcepto;

            switch (TipoConcepto)
            {
                case "BAS":
                    label13.Enabled = false;
                    tbxCodigo.Enabled = false;
                    groupBox1.Enabled = false;
                    groupBox2.Enabled = false;
                    lblTipoConcepto.Enabled = false;
                    optRemunerativo.Enabled = false;
                    optNoRemunerativo.Enabled = false;
                    break;
                case "RM":
                    if (Convert.ToString(screenConceptos.dgvConceptos.CurrentRow.Cells[8].Value).Equals("hab_fijo"))
                    {
                        tbxValorFijo.Text = Convert.ToString(screenConceptos.dgvConceptos.CurrentRow.Cells[3].Value);
                    }
                    else
                    {

                        optPorcentaje.Checked = true;
                        tbxPorcentaje.Text = Convert.ToString(screenConceptos.dgvConceptos.CurrentRow.Cells[4].Value);
                        tbxComponentes.Text = ConvertirFormulaCodigoACodigoString();
                    }

                    optRemunerativo.Checked = true;
                    break;
                case "NRM":
                    if (Convert.ToString(screenConceptos.dgvConceptos.CurrentRow.Cells[8].Value).Equals("hab_fijo"))
                    {
                        tbxValorFijo.Text = Convert.ToString(screenConceptos.dgvConceptos.CurrentRow.Cells[3].Value);
                    }
                    else
                    {
                        optPorcentaje.Checked = true;
                        tbxPorcentaje.Text = Convert.ToString(screenConceptos.dgvConceptos.CurrentRow.Cells[4].Value);
                        tbxComponentes.Text = ConvertirFormulaCodigoACodigoString();
                    }
                    optNoRemunerativo.Checked = true;
                    break;
                case "DED":
                    btnFormula.Visible = false;
                    lblTipoConcepto.Visible = false;
                    optRemunerativo.Visible = false;
                    optNoRemunerativo.Visible = false;

                    if (screenConceptos.dgvConceptos.CurrentRow.Cells[8].Value.ToString() == "ded_fijo")
                    {
                        tbxValorFijo.Text = screenConceptos.dgvConceptos.CurrentRow.Cells[5].Value.ToString();
                    }
                    else
                    {
                        tbxPorcentaje.Text = screenConceptos.dgvConceptos.CurrentRow.Cells[6].Value.ToString();
                        tbxComponentes.Text = ConvertirFormulaCodigoACodigoString();
                        optPorcentaje.Checked = true;
                    }
                    break;
            }

            if (isEdit == true)
            {
                tbxCodigo.Enabled = false;
                tbxNombre.Enabled = false;
            }

        }


        #endregion

        #region BOTONES
        private void btnSeleccionar_Click(object sender, EventArgs e)
        {
            if (TipoConcepto.Equals("DED"))
            {
                SeleccionarComponentesDeduccionPorcentual screenDeduccionComponentes = new SeleccionarComponentesDeduccionPorcentual(screenConceptos, null, this, _empresa, true);
                screenDeduccionComponentes.Show();

            }
            else
            {
                SeleccionarComponentesHaberPorcentual screenHaberesComponentes = new SeleccionarComponentesHaberPorcentual(screenConceptos, null, this, _empresa, true);
                screenHaberesComponentes.Show();
            }
        }

        private void btnFormula_Click(object sender, EventArgs e)
        {
            CrearFormulaHaberFijo edit_form = new CrearFormulaHaberFijo(screenConceptos, null, this, _empresa, true);
            edit_form.Show();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            string rta = "";
            int codigoConceptoPorEmpresa = Convert.ToInt32(screenConceptos.dgvConceptos.CurrentRow.Cells[0].Value);
            string codigoConcepto = tbxCodigo.Text;
            string descripcionConcepto = tbxNombre.Text;
            string valorFijo = (optValorFijo.Checked) ? tbxValorFijo.Text : null;
            string valorPorcentual = (optValorFijo.Checked) ? null : tbxPorcentaje.Text; 
            string componentesPorcentaje = (optValorFijo.Checked) ? null : ConvertirCodigoStringAFormulaCodigo();

            int codigoTipoConcepto = 0;
            int codigoModoConcepto = 0;

            try
            {
                switch (TipoConcepto)
                {
                    case "BAS":
                        codigoTipoConcepto = 1;
                        codigoModoConcepto = 1;
                        valorFijo = Convert.ToString(screenConceptos.dgvConceptos.CurrentRow.Cells[3].Value);

                        rta = ControladorConcepto.InsertarActualizarConcepto(_empresa.codigoEmpresa, codigoConceptoPorEmpresa, codigoConcepto,
                            descripcionConcepto, valorFijo, valorPorcentual, null, null, codigoTipoConcepto, codigoModoConcepto, componentesPorcentaje);
                        break;
                    case "RM":
                        codigoTipoConcepto = 2;
                        codigoModoConcepto = (optValorFijo.Checked) ? 1 : 2;

                        rta = ControladorConcepto.InsertarActualizarConcepto(_empresa.codigoEmpresa, codigoConceptoPorEmpresa, codigoConcepto,
                            descripcionConcepto,valorFijo, valorPorcentual, null, null, codigoTipoConcepto, codigoModoConcepto, componentesPorcentaje);

                        break;
                    case "NRM":
                        codigoTipoConcepto = 3;
                        codigoModoConcepto = (optValorFijo.Checked) ? 1 : 2;

                        rta = ControladorConcepto.InsertarActualizarConcepto(_empresa.codigoEmpresa, codigoConceptoPorEmpresa, codigoConcepto,
                            descripcionConcepto, valorFijo, valorPorcentual, null, null, codigoTipoConcepto, codigoModoConcepto, componentesPorcentaje);
                        break;
                    case "DED":
                        codigoTipoConcepto = 4;
                        codigoModoConcepto = (optValorFijo.Checked) ? 3 : 4;

                        rta = ControladorConcepto.InsertarActualizarConcepto(_empresa.codigoEmpresa, codigoConceptoPorEmpresa, codigoConcepto,
                            descripcionConcepto, null, null, valorFijo, valorPorcentual, codigoTipoConcepto, codigoModoConcepto, componentesPorcentaje);
                        break;
                }

                if (rta.Equals("ok"))
                {
                    this.Close();
                    screenConceptos.conceptos_Load(null, EventArgs.Empty);
                }
                else
                {
                    MessageBox.Show(rta);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion

        #region EVENTOS
        private void optValorFijo_CheckedChanged(object sender, EventArgs e)
        {
            if (optValorFijo.Checked)
            {
                lblValor.Enabled = true;
                tbxValorFijo.Enabled = true;
                btnFormula.Enabled = true;

                lblComponentes.Enabled = false;
                lblPorcentaje.Enabled = false;
                btnSeleccionar.Enabled = false;
                tbxPorcentaje.Enabled = false;
                tbxComponentes.Enabled = false;

                if (optPorcentaje.Checked)
                {
                    optPorcentaje.Checked = false;
                }
            }
        }

        private void optPorcentaje_CheckedChanged(object sender, EventArgs e)
        {
            if (optPorcentaje.Checked)
            {
                lblValor.Enabled = false;
                tbxValorFijo.Enabled = false;
                btnFormula.Enabled = false;

                lblComponentes.Enabled = true;
                lblPorcentaje.Enabled = true;
                btnSeleccionar.Enabled = true;
                tbxPorcentaje.Enabled = true;
                tbxComponentes.Enabled = true;

                if (optValorFijo.Checked)
                {
                    optValorFijo.Checked = false;
                }
            }

        }

        private void EditConcepto_FormClosing(object sender, FormClosingEventArgs e)
        {
            screenConceptos.isDeduccion = false;
            screenConceptos.Visible = true;

        }


        #endregion

        #region METODOS
        private string ConvertirFormulaCodigoACodigoString()
        {
            string formulaPorcentaje = Convert.ToString(screenConceptos.dgvConceptos.CurrentRow.Cells[9].Value);
            string[] formulaPorcentajeSplited = formulaPorcentaje.Split('+');
            string codigoConceptoGrilla;

            for (int i = 0; i < formulaPorcentajeSplited.Length; i++)
            {
                for (int a = 0; a < screenConceptos.dgvConceptos.Rows.Count; a++)
                {
                    codigoConceptoGrilla = Convert.ToString(screenConceptos.dgvConceptos.Rows[a].Cells[0].Value);


                    if (formulaPorcentajeSplited[i].Trim() == String.Format("|{0}|", codigoConceptoGrilla))
                    {
                        formulaPorcentaje = formulaPorcentaje.Replace(formulaPorcentajeSplited[i], String.Format(" |{0}| ", Convert.ToString(screenConceptos.dgvConceptos.Rows[a].Cells[1].Value) ));
                    }
                }

            }

            return formulaPorcentaje;
        }

        private string ConvertirCodigoStringAFormulaCodigo()
        {
            string formulaPorcentaje = tbxComponentes.Text;
            string[] formulaPorcentajeSplited = formulaPorcentaje.Split('+');
            string codigoConceptoGrilla;

            for (int i = 0; i < formulaPorcentajeSplited.Length; i++)
            {
                for (int a = 0; a < screenConceptos.dgvConceptos.Rows.Count; a++)
                {
                    codigoConceptoGrilla = Convert.ToString(screenConceptos.dgvConceptos.Rows[a].Cells[1].Value);


                    if (formulaPorcentajeSplited[i].Trim() == String.Format("|{0}|", codigoConceptoGrilla))
                    {
                        formulaPorcentaje = formulaPorcentaje.Replace(formulaPorcentajeSplited[i], String.Format(" |{0}| ", Convert.ToString(screenConceptos.dgvConceptos.Rows[a].Cells[0].Value)));
                    }
                }

            }

            return formulaPorcentaje;
        }
        #endregion
    }
}
