using System;
using System.Windows.Forms;
using AliSlib;
using AliSLogica.Controladores;

namespace AliS_WinVer
{
    public partial class AñadirConcepto : Form
    {
        #region PROPIEDADES
        PrincipalConceptos screenConceptos;
        EditarConcepto edit;
        #endregion

        #region INICIO
        public AñadirConcepto(PrincipalConceptos screenConceptos)
        {
            InitializeComponent();
            this.screenConceptos = screenConceptos;
        }
        #endregion

        #region BOTONES
        private void btnHaberAdd_Click(object sender, EventArgs e)
        {
            string codigo = tbxHaberCodigo.Text;
            string descripcion = tbxHaberNombre.Text;
            string valorFijo = (optHaberValorFijo.Checked) ? tbxHaberValor.Text : null;
            string valorPorcentual = (optHaberValorFijo.Checked) ? null : tbxHaberPorcentaje.Text;
            int tipoConcepto = 0;
            int modoConcepto = (optHaberValorFijo.Checked) ? 1 : 2;
            string componentesPorcentaje = (optHaberValorFijo.Checked) ? null : tbxHaberComponentes.Text;

            //Chequea si estan todos lo datos necesarios.
            if (tbxHaberCodigo.Text == "" || tbxHaberNombre.Text == "" || optHaberValorFijo.Checked == true && tbxHaberValor.Text == "" || optHaberPorcentaje.Checked == true && tbxHaberPorcentaje.Text == "" || optHaberPorcentaje.Checked == true && tbxHaberComponentes.Text == "" || optBasico.Checked == false && optHaberRem.Checked == false && optHaberNoRem.Checked == false)
            {
                MessageBox.Show("Debe rellenar todos los campos.");
            }
            else
            {
                try
                {
                    //Chequea si es remunerativo.
                    if (optHaberRem.Checked == true)
                    {
                        tipoConcepto = 2;
                    }
                    else if (optHaberNoRem.Checked == true)
                    {
                        tipoConcepto = 3;
                    }
                    else
                    {
                        tipoConcepto = 1;
                    }

                    string rta = ControladorConcepto.InsertarActualizarConcepto(UsuarioSingleton.Instance.codigoEmpresa, 0, codigo, descripcion, valorFijo,
                        valorPorcentual, null, null, tipoConcepto, modoConcepto, componentesPorcentaje);

                    if (rta.Equals("ok"))
                    {
                        this.Close();
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
            
        }

        private void btnDeducAdd_Click(object sender, EventArgs e)
        {
            string codigo = tbxDeducCodigo.Text;
            string descripcion = tbxDeducNombre.Text;
            string valorFijo = (optDeducValorFijo.Checked) ? tbxDeducValor.Text : null;
            string valorPorcentual = (optDeducValorFijo.Checked) ? null : tbxDeducPorcentaje.Text;
            int tipoConcepto = 4;
            int modoConcepto = (optDeducValorFijo.Checked) ? 3 : 4;

            string componentesPorcentaje = (optDeducValorFijo.Checked) ? null : tbxDeducComponentes.Text;

            if (tbxDeducCodigo.Text == "" || tbxDeducNombre.Text == "" || optDeducValorFijo.Checked == true && tbxDeducValor.Text == ""
                || optDeducPorcentaje.Checked == true && tbxDeducPorcentaje.Text == "" || optDeducPorcentaje.Checked == true && tbxDeducComponentes.Text == "")
            {
                MessageBox.Show("Debe rellenar todos los campos.");
            }
            else
            {
                try
                {
                    string rta = ControladorConcepto.InsertarActualizarConcepto(UsuarioSingleton.Instance.codigoEmpresa, 0, codigo, descripcion, null, null, valorFijo,
                        valorPorcentual, tipoConcepto, modoConcepto, componentesPorcentaje);

                    if (rta.Equals("ok"))
                    {
                        this.Close();
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
            
        }
        #endregion

        #region LINK A OTROS SCREENS
        //Screen Componentes.
        private void btnDeducSeleccionar_Click(object sender, EventArgs e)
        {
            SeleccionarComponentesDeduccionPorcentual porcDed = new SeleccionarComponentesDeduccionPorcentual(screenConceptos, this, edit, false);
            porcDed.Show();
        }

        private void btnHaberSelecccionar_Click(object sender, EventArgs e)
        {
            SeleccionarComponentesHaberPorcentual porcHab = new SeleccionarComponentesHaberPorcentual(screenConceptos, this, edit, false);
            porcHab.Show();
        }

        // Screen formula
        private void btnHaberFormula_Click(object sender, EventArgs e)
        {
            CrearFormulaHaberFijo HabForm = new CrearFormulaHaberFijo(screenConceptos, this, edit, false);
            HabForm.Show();
        }
        #endregion

        #region EVENTOS

        // HABERES
        private void optHaberValorFijo_CheckedChanged(object sender, EventArgs e)
        {
            if (optHaberValorFijo.Checked)
            {
                lblHaberValor.Enabled = true;
                tbxHaberValor.Enabled = true;
                tbxDeducValor.Enabled = true;
                btnHaberFormula.Enabled = true;

                lblHaberComponentes.Enabled = false;
                lblHaberPorcentaje.Enabled = false;
                btnHaberSelecccionar.Enabled = false;
                tbxHaberPorcentaje.Enabled = false;
                tbxHaberComponentes.Enabled = false;

                if (optHaberPorcentaje.Checked)
                {
                    optHaberPorcentaje.Checked = false;
                }
            }
        }

        private void optHaberPorcentaje_CheckedChanged(object sender, EventArgs e)
        {
            if (optHaberPorcentaje.Checked)
            {
                lblHaberValor.Enabled = false;
                tbxHaberValor.Enabled = false;
                tbxDeducValor.Enabled = false;
                btnHaberFormula.Enabled = false;

                lblHaberComponentes.Enabled = true;
                lblHaberPorcentaje.Enabled = true;
                btnHaberSelecccionar.Enabled = true;
                tbxHaberPorcentaje.Enabled = true;
                tbxHaberComponentes.Enabled = true;

                if (optHaberValorFijo.Checked)
                {
                    optHaberValorFijo.Checked = false;
                }
            }

        }

        // DEDUCCIONES
        private void optDeducValorFijo_CheckedChanged(object sender, EventArgs e)
        {
            if (optDeducValorFijo.Checked)
            {
                lblDeducValor.Enabled = true;
                tbxDeducValor.Enabled = true;

                lblDeducComponentes.Enabled = false;
                lblDeducPorcentaje.Enabled = false;
                btnDeducSeleccionar.Enabled = false;
                tbxDeducPorcentaje.Enabled = false;

                if (optDeducPorcentaje.Checked)
                {
                    optDeducPorcentaje.Checked = false;
                }
            }
        }

        private void optDeducPorcentaje_CheckedChanged(object sender, EventArgs e)
        {
            if (optDeducPorcentaje.Checked)
            {
                lblDeducValor.Enabled = false;
                tbxDeducValor.Enabled = false;

                lblDeducComponentes.Enabled = true;
                lblDeducPorcentaje.Enabled = true;
                btnDeducSeleccionar.Enabled = true;
                tbxDeducPorcentaje.Enabled = true;

                if (optDeducValorFijo.Checked)
                {
                    optDeducValorFijo.Checked = false;
                }
            }
        }

        private void Con_custom_FormClosing(object sender, FormClosingEventArgs e)
        {
            screenConceptos.conceptos_Load(null, EventArgs.Empty);

            screenConceptos.Visible = true;
        }
        #endregion
    }
}
