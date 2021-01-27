using System;
using System.Drawing;
using System.Windows.Forms;
using AliS_WinVer.Clases;
using AliSLogica.Controladores;

namespace AliS_WinVer
{
    public partial class SeleccionarComponentesDeduccionPorcentual : Form
    {
        PrincipalConceptos screenConceptos;
        AñadirConcepto screenNewConcepto;
        EditarConcepto screenEditConcepto;
        bool isEditMode;


        private Empresa _empresa;

        public SeleccionarComponentesDeduccionPorcentual(PrincipalConceptos screenConceptos, AñadirConcepto screenNewConcepto, EditarConcepto screenEditConcepto, Empresa empresa, bool isEditMode)
        {
            InitializeComponent();
            this.screenConceptos = screenConceptos;
            this.screenNewConcepto = screenNewConcepto;
            this.screenEditConcepto = screenEditConcepto;
            this.isEditMode = isEditMode;
            this._empresa = empresa;
        }

        private void PorcDedComp_Load(object sender, EventArgs e)
        {
            CargarConceptos();
            CargarPorcentajePreseteado();
        }

        private void CargarPorcentajePreseteado()
        {
            if (screenNewConcepto != null && screenNewConcepto.tbxDeducPorcentaje.Text != "")
            {
                tbxPorcentaje.Text = screenNewConcepto.tbxDeducPorcentaje.Text;
            }

            if (screenEditConcepto != null && screenEditConcepto.tbxPorcentaje.Text != "")
            {
                tbxPorcentaje.Text = screenEditConcepto.tbxPorcentaje.Text;
            }
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            string sliceComp ="";
            string componentes ="";

            if (chkAplicaEnRem.Checked == true)
            {
                sliceComp = "TotalRemunerativos";
            }
            else
            {
                for (int i = 0; i < dgvConceptosList.RowCount; i++)
                {
                    if (Convert.ToBoolean(dgvConceptosList.Rows[i].Cells[0].Value))
                    {
                        componentes += '|' + dgvConceptosList.Rows[i].Cells[2].Value.ToString() + '|' + " + ";
                    }
                }
                if (!String.IsNullOrEmpty(componentes))
                {
                    sliceComp = componentes.Substring(0, componentes.Length - 2);

                }
            }

            if (isEditMode)
            {
                screenEditConcepto.tbxComponentes.Text = sliceComp;
                screenEditConcepto.tbxPorcentaje.Text = tbxPorcentaje.Text;
            }
            else
            {
                screenNewConcepto.tbxDeducComponentes.Text = sliceComp;
                screenNewConcepto.tbxDeducPorcentaje.Text = tbxPorcentaje.Text;
            }

            Close();
        }

        private void chkAplicaEnRem_CheckedChanged(object sender, EventArgs e)
        {
            if(chkAplicaEnRem.Checked == true)
            {
                dgvConceptosList.Enabled = false;

                for(int i = 0; i < dgvConceptosList.RowCount; i++)
                {
                    dgvConceptosList.Rows[i].DefaultCellStyle.BackColor = Color.LightGray;
                    if (Convert.ToBoolean(dgvConceptosList.Rows[i].Cells[0].Value))
                    {
                        dgvConceptosList.Rows[i].Cells[0].Value = false;
                    }
                }
            }
            else
            {
                dgvConceptosList.Enabled = true;

                for (int i = 0; i < dgvConceptosList.RowCount; i++)
                {
                    dgvConceptosList.Rows[i].DefaultCellStyle.BackColor = Color.White;
                }
            }
            
        }

        #region METODOS
        public void CargarConceptos()
        {
            try
            {
                dgvConceptosList.DataSource = ControladorConcepto.RecuperarConceptosPorCodigoEmpresa(_empresa.codigoEmpresa);

                dgvConceptosList.Columns[0].Width = 30;
                dgvConceptosList.Columns[2].Width = 55;
                dgvConceptosList.Columns[3].Width = 200;
                dgvConceptosList.Columns[8].Width = 55;

                for (int i = 0; i <= 10; i++)
                {
                    if ((i == 0) || (i == 2) || (i == 3) || (i == 8))
                    {
                        continue;
                    }
                    dgvConceptosList.Columns[i].Visible = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
        #endregion
    }
}
