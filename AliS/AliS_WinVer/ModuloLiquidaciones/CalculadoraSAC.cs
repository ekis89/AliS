using System;
using System.Data;
using System.Linq;
using System.Xml;
using System.Windows.Forms;
using Obj;

namespace AliS_WinVer
{
    public partial class CalculadoraSAC : Form
    {
        XmlDocument Docs;
        GestionLiquidacionConceptos screenLiquidar;
        
        bool isSalarioMensual = false;


        public CalculadoraSAC(XmlDocument Docs, GestionLiquidacionConceptos screenLiquidar, bool isSalarioMensual)
        {
            InitializeComponent();

            this.Docs = Docs;
            this.isSalarioMensual = isSalarioMensual;
            this.screenLiquidar = screenLiquidar;
        }

        private void Aguinaldos_Load(object sender, EventArgs e)
        {
            tbxCode.Text = "SAC";
            tbxDescripcion.Text = "Sueldo anual complementario";

            optSAC.Checked = true;
        }

        // Activa calculo de aguinaldo normal.
        private void optSAC_CheckedChanged(object sender, EventArgs e)
        {

            if (optSAC.Checked)
            {
                lblMesTitle.Enabled = true;
                lblMesMayor.Enabled = true;
                lblBrutoTitle.Enabled = true;
                lblSalarioBruto.Enabled = true;
                lblAbonarTitle.Enabled = true;
                lblAbonar.Enabled = true;
                lblSemestreSelectTitle.Enabled = true;
                cboSemestreSelect.Enabled = true;
                cboSemestreSelect.SelectedIndex = cboSemestreSelect.FindStringExact("1");

                lblMesTitleProp.Enabled = false;
                lblMesMayorProp.Enabled = false;
                lblMesMayorProp.Text = "";
                lblBrutoTitleProp.Enabled = false;
                lblSalarioBrutoProp.Enabled = false;
                lblSalarioBrutoProp.Text = "";
                lblDiasSemestreTitle.Enabled = false;
                tbxDiaSemestreProp.Enabled = false;
                tbxDiaSemestreProp.Text = "";
                lblDiasTrabajadosTitle.Enabled = false;
                tbxDiasTrabajadosProp.Enabled = false;
                tbxDiasTrabajadosProp.Text = "";
                lblAbonarTitleProp.Enabled = false;
                lblAbonarProp.Enabled = false;
                lblAbonarProp.Text = "";
                lblSemestreSelectTitleProp.Enabled = false;
                cboSemestreSelectProp.Enabled = false;

                if (optSACProp.Checked)
                {
                    optSACProp.Checked = false;
                }
            }
        }

        // Activa calculo de aguinaldo proporcional.
        private void optSACProp_CheckedChanged(object sender, EventArgs e)
        {

            if (optSACProp.Checked)
            {
                lblMesTitleProp.Enabled = true;
                lblMesMayorProp.Enabled = true;
                lblBrutoTitleProp.Enabled = true;
                lblSalarioBrutoProp.Enabled = true;
                lblDiasSemestreTitle.Enabled = true;
                tbxDiaSemestreProp.Enabled = true;
                lblDiasTrabajadosTitle.Enabled = true;
                tbxDiasTrabajadosProp.Enabled = true;
                lblAbonarTitleProp.Enabled = true;
                lblAbonarProp.Enabled = true;
                lblSemestreSelectTitleProp.Enabled = true;
                cboSemestreSelectProp.Enabled = true;
                cboSemestreSelectProp.SelectedIndex = cboSemestreSelectProp.FindStringExact("1");

                lblMesTitle.Enabled = false;
                lblMesMayor.Enabled = false;
                lblMesMayor.Text = "";
                lblBrutoTitle.Enabled = false;
                lblSalarioBruto.Enabled = false;
                lblSalarioBruto.Text = "";
                lblAbonarTitle.Enabled = false;
                lblAbonar.Enabled = false;
                lblAbonar.Text = "";
                lblSemestreSelectTitle.Enabled = false;
                cboSemestreSelect.Enabled = false;


                if (optSAC.Checked)
                {
                    optSAC.Checked = false;
                }
            }
        }

        // Calcula aguinaldo normal
        private void cboSemestreSelect_SelectedIndexChanged(object sender, EventArgs e)
        {
            string semestre = cboSemestreSelect.Text;
            var coso = Docs.SelectSingleNode("//SAC/SAC_semestre_" + semestre);
            double[] saldos = new double[6];
            string[] mes = new string[6];
            int index = 0;
            double resultado = 0;
            double Q1 = 0;
            double Q2 = 0;

            try
            {
                if (optSAC.Checked)
                {

                    if (isSalarioMensual)
                    {
                        foreach (XmlNode node in coso)
                        {
                            saldos[index] = double.Parse(node.Attributes["Bruto"].Value);
                            mes[index] = node.Name;
                            index++;
                        }

                        double maxValue = saldos.Max();
                        int maxIndex = Array.IndexOf(saldos, maxValue);

                        lblSalarioBruto.Text = maxValue.ToString();
                        lblMesMayor.Text = mes[maxIndex];
                        resultado = resultado = Math.Round((maxValue / 2), 2);
                        lblAbonar.Text = resultado.ToString();
                    }
                    else
                    {
                        foreach (XmlNode node in coso)
                        {
                            Q1 = double.Parse(node.Attributes["Q1_Bruto"].Value);
                            Q2 = double.Parse(node.Attributes["Q2_Bruto"].Value);
                            saldos[index] = Q1 + Q2;
                            mes[index] = node.Name;
                            index++;
                        }

                        double maxValue = saldos.Max();
                        int maxIndex = Array.IndexOf(saldos, maxValue);

                        lblSalarioBruto.Text = maxValue.ToString();
                        lblMesMayor.Text = mes[maxIndex];
                        resultado = resultado = Math.Round((maxValue / 2), 2);
                        lblAbonar.Text = resultado.ToString();
                    }
                }
            }
            catch(Exception err)
            {
                MessageBox.Show(err.ToString());
                this.Close();
            }
           
        }

        // Calcula aguinaldo normal proporcional.
        private void cboSemestreSelectProp_SelectedIndexChanged(object sender, EventArgs e)
        {
            string semestre = cboSemestreSelectProp.Text;
            var coso = Docs.SelectSingleNode("//SAC/SAC_semestre_" + semestre);
            double[] saldos = new double[6];
            string[] mes = new string[6];
            int index = 0;
            double maxValue = 0;
            int maxIndex = 0;
            double diasTrabajados = 0;
            double diasSemestre = 0;
            double resultado = 0;
            double Q1 = 0;
            double Q2 = 0;

            if (optSACProp.Checked)
            {
                if (isSalarioMensual)
                {
                    tbxDiasTrabajadosProp.Text = "0";

                    if (cboSemestreSelectProp.Text == "1")
                    {
                        tbxDiaSemestreProp.Text = "182";
                    }
                    else if (cboSemestreSelectProp.Text == "2")
                    {
                        tbxDiaSemestreProp.Text = "183";
                    }

                    foreach (XmlNode node in coso)
                    {
                        saldos[index] = double.Parse(node.Attributes["Bruto"].Value);
                        mes[index] = node.Name;
                        index++;
                    }

                    maxValue = saldos.Max();
                    maxIndex = Array.IndexOf(saldos, maxValue);
                    diasTrabajados = double.Parse(tbxDiasTrabajadosProp.Text);
                    diasSemestre = double.Parse(tbxDiaSemestreProp.Text);

                    lblSalarioBrutoProp.Text = maxValue.ToString();
                    lblMesMayorProp.Text = mes[maxIndex];

                    resultado = Math.Round((maxValue / 2) * (diasTrabajados / diasSemestre), 2);
                    lblAbonarProp.Text = resultado.ToString();
                }
                else
                {
                    tbxDiasTrabajadosProp.Text = "0";

                    if (cboSemestreSelectProp.Text == "1")
                    {
                        tbxDiaSemestreProp.Text = "182";
                    }
                    else if (cboSemestreSelectProp.Text == "2")
                    {
                        tbxDiaSemestreProp.Text = "183";
                    }

                    foreach (XmlNode node in coso)
                    {
                        Q1 = double.Parse(node.Attributes["Q1_Bruto"].Value);
                        Q2 = double.Parse(node.Attributes["Q2_Bruto"].Value);
                        saldos[index] = Q1 + Q2;
                        mes[index] = node.Name;
                        index++;
                    }

                    maxValue = saldos.Max();
                    maxIndex = Array.IndexOf(saldos, maxValue);
                    diasTrabajados = double.Parse(tbxDiasTrabajadosProp.Text);
                    diasSemestre = double.Parse(tbxDiaSemestreProp.Text);

                    lblSalarioBrutoProp.Text = maxValue.ToString();
                    lblMesMayorProp.Text = mes[maxIndex];

                    resultado = Math.Round((maxValue / 2) * (diasTrabajados / diasSemestre), 2);
                    lblAbonarProp.Text = resultado.ToString();
                }

            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }

        //Agrega el SAC a la lista.
        private void btnAceptar_Click(object sender, EventArgs e)
        {
            DataTable XML_dt = screenLiquidar.dtXML;
            DataGridView DGV = screenLiquidar.dgvDetalles;

            DataRow row = XML_dt.NewRow();

            string code = string.Format("\"{0}\"", tbxCode.Text);
            string desc = tbxDescripcion.Text;
            string value;

            if (optSAC.Checked)
            {
                value = lblAbonar.Text;
            }
            else
            {
                value = lblAbonarProp.Text;
            }

            row[0] = code;
            row[1] = desc;
            row[2] = value;
            row[6] = "RM";
            row[7] = "hab_fijo";
            row[9] = "1";
            row[10] = value;
            row[11] = value;

            XML_dt.Rows.InsertAt(row, 1);

            ReciboTools.CalcularTabla(XML_dt);

            ReciboTools.DrawTabla(XML_dt, DGV, true);

            ReciboTools.CalcularTotales(XML_dt, DGV, screenLiquidar.lblRemInfo, screenLiquidar.lblNoRemInfo, screenLiquidar.lblDeduccionesInfo, screenLiquidar.lblNetoInfo);

            Close();

        }

        private void tbxDiasTrabajadosProp_KeyPress(object sender, KeyPressEventArgs e)
        {
            Tools.only_num(e);
        }

        private void tbxDiasTrabajadosProp_KeyUp(object sender, KeyEventArgs e)
        {
            modificarDias();
        }

        private void tbxDiaSemestreProp_KeyPress(object sender, KeyPressEventArgs e)
        {
            Tools.only_num(e);
        }

        private void tbxDiaSemestreProp_KeyUp(object sender, KeyEventArgs e)
        {
            modificarDias();
        }

        //Hace calculo proporcional segun lo que este escrito en los textBox.
        private void modificarDias()
        {
            double maxValue = double.Parse(lblSalarioBrutoProp.Text);
            double diasTrabajados = 0;
            double diasSemestre = 0;

            if (tbxDiaSemestreProp.Text.Length == 0 || tbxDiaSemestreProp.Text == " ")
            {
                diasSemestre = 0;
            }
            else
            {
                diasSemestre = double.Parse(tbxDiaSemestreProp.Text);
            }

            if (tbxDiasTrabajadosProp.Text.Length == 0 || tbxDiasTrabajadosProp.Text == " ")
            {
                diasTrabajados = 0;
            }
            else
            {
                diasTrabajados = double.Parse(tbxDiasTrabajadosProp.Text);
            }

            double resultado = Math.Round((maxValue / 2) * (diasTrabajados / diasSemestre), 2);
            lblAbonarProp.Text = resultado.ToString();
        }
    }
}
