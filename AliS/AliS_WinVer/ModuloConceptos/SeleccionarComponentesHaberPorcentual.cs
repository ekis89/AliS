using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AliS_WinVer.Clases;
using AliSLogica.Controladores;

namespace AliS_WinVer
{
    public partial class SeleccionarComponentesHaberPorcentual : Form
    {
        PrincipalConceptos screenConceptos;
        AñadirConcepto screenNewConcepto;
        EditarConcepto screenEditConcepto;
        bool isEditMode;

        private Empresa _empresa;

        public SeleccionarComponentesHaberPorcentual(PrincipalConceptos screenConceptos, AñadirConcepto screenNewConcepto, EditarConcepto screenEditConcepto, Empresa empresa, bool isEditMode)
        {
            InitializeComponent();
            this.screenConceptos = screenConceptos;
            this.screenNewConcepto = screenNewConcepto;
            this.screenEditConcepto = screenEditConcepto;
            this.isEditMode = isEditMode;
            this._empresa = empresa;
        }

        private void PorcHabComp_Load(object sender, EventArgs e)
        {
            CargarConceptos();
            CargarPorcentajePreseteado();

            //if (screenConceptos.dgvConceptos.CurrentRow.Cells[6].Value.ToString() == "DED" && isEditMode == true)
            //{
            //    this.Text = "Deducciones: Porcentaje(%) - Componentes ";
            //}

        }

        private void CargarPorcentajePreseteado()
        {
            if (screenNewConcepto != null && screenNewConcepto.tbxHaberPorcentaje.Text != "")
            {
                tbxPorcentaje.Text = screenNewConcepto.tbxHaberPorcentaje.Text;
            }

            if (screenEditConcepto != null && screenEditConcepto.tbxPorcentaje.Text != "")
            {
                tbxPorcentaje.Text = screenEditConcepto.tbxPorcentaje.Text;
            }
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            string componentes = "";
            for(int i = 0; i < dgvConceptosList.RowCount; i++)
            {
                if(Convert.ToBoolean(dgvConceptosList.Rows[i].Cells[0].Value))
                {
                   componentes += '|'+dgvConceptosList.Rows[i].Cells[2].Value.ToString()+'|' + " + ";
                }
            }
            string sliceComp = componentes.Substring(0, componentes.Length - 2);

            if(isEditMode == true)
            {
                screenEditConcepto.tbxComponentes.Text = sliceComp;
                screenEditConcepto.tbxPorcentaje.Text = tbxPorcentaje.Text;
                Close();
            }
            else
            {
                screenNewConcepto.tbxHaberComponentes.Text = sliceComp;
                screenNewConcepto.tbxHaberPorcentaje.Text = tbxPorcentaje.Text;
                Close();
            }

        }

        public void CargarConceptos()
        {
            try
            {
                dgvConceptosList.DataSource = ControladorConcepto.RecuperarConceptosPorCodigoEmpresa(_empresa.codigoEmpresa);

                dgvConceptosList.Columns[0].Width = 30;
                dgvConceptosList.Columns[2].Width = 55;
                dgvConceptosList.Columns[3].Width = 200;
                dgvConceptosList.Columns[8].Width = 45;

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
    }
}
