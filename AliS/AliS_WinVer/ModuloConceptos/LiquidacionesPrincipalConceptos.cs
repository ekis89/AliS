using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using AliS_WinVer.Clases;
using AliSLogica.Complementarios;
using AliSLogica.Controladores;
using System.Linq;

namespace AliS_WinVer
{
    public partial class LiquidacionesPrincipalConceptos : Form
    {
        GestionLiquidacionConceptos Liquidar_scrn;
        Empresa _empresa;

        DataTable tablaListaConceptos;

        public LiquidacionesPrincipalConceptos(GestionLiquidacionConceptos Liquidar_scrn, Empresa empresa)
        {
            InitializeComponent();

            this.Liquidar_scrn = Liquidar_scrn;
            this._empresa = empresa;
        }

        private void recibo_Builder_addConcepto_Load(object sender, EventArgs e)
        {
            CargarGrillaConceptos();
        }

        private void CargarGrillaConceptos()
        {
            tablaListaConceptos = ControladorConcepto.RecuperarConceptosPorCodigoEmpresa(_empresa.codigoEmpresa);

            dataGridView1.DataSource = tablaListaConceptos;

            dataGridView1.Columns[0].Visible = false;

            dataGridView1.Columns[1].Width = 70;
            dataGridView1.Columns[2].Width = 250;
            dataGridView1.Columns[3].Width = 95;
            dataGridView1.Columns[4].Width = 95;
            dataGridView1.Columns[5].Width = 95;
            dataGridView1.Columns[5].HeaderText = "Fijo($)";
            dataGridView1.Columns[6].Width = 95;
            dataGridView1.Columns[6].HeaderText = "Porcentaje(%)";
            dataGridView1.Columns[7].Width = 72;
            dataGridView1.Columns[8].Visible = false;
            dataGridView1.Columns[9].Visible = false;

            for (int i = 2; i < 7; i++)
            {
                dataGridView1.Columns[i].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                if (i >= 2)
                {
                    dataGridView1.Columns[i].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                }
            }

            foreach (DataRow r in Liquidar_scrn.dtDgvDetalles.Rows)
            {
                restart:
                foreach (DataRow row in tablaListaConceptos.Rows)
                {
                    int index = tablaListaConceptos.Rows.IndexOf(row);

                    if (r["codigo"].ToString().Replace("\"", "") == row["codigo"].ToString())
                    {
                        row.Delete();
                        tablaListaConceptos.AcceptChanges();
                        goto restart;
                    }

                    if (String.IsNullOrEmpty(Convert.ToString(row["hab_fijo"])) && String.IsNullOrEmpty(Convert.ToString(row["hab_porc"])) && String.IsNullOrEmpty(Convert.ToString(row["ded_fijo"])) && String.IsNullOrEmpty(Convert.ToString(row["ded_porc"])))
                    {
                        row.Delete();
                        tablaListaConceptos.AcceptChanges();
                        goto restart;
                    }
                }
            }
            tablaListaConceptos.AcceptChanges();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            try
            {
                Label th_rem = Liquidar_scrn.lblRemInfo;
                Label th_norem = Liquidar_scrn.lblNoRemInfo;
                Label tded = Liquidar_scrn.lblDeduccionesInfo;
                Label tneto = Liquidar_scrn.lblNetoInfo;

                DataRowView drv = dataGridView1.CurrentRow.DataBoundItem as DataRowView;
                DataRow dr = drv.Row;

                List<DataRow> listaConceptosFormula = RecuperarConceptosFormula(dr);

                foreach (DataRow row in listaConceptosFormula)
                {
                    DataRow dtDgvDetallesNewRow = Liquidar_scrn.dtDgvDetalles.NewRow();
                    DataRow dtXMLNewRow = Liquidar_scrn.dtXML.NewRow();

                    dtDgvDetallesNewRow["codigo"] = Convert.ToString(row["codigo"]);
                    dtDgvDetallesNewRow["descripcion"] = Convert.ToString(row["descripcion"]);
                    dtDgvDetallesNewRow["hab_fijo"] = Convert.ToString(row["hab_fijo"]);
                    dtDgvDetallesNewRow["hab_porc"] = Convert.ToString(row["hab_porc"]);
                    dtDgvDetallesNewRow["ded_fijo"] = Convert.ToString(row["ded_fijo"]);
                    dtDgvDetallesNewRow["ded_porc"] = Convert.ToString(row["ded_porc"]);
                    dtDgvDetallesNewRow["tipo"] = Convert.ToString(row["tipo"]);
                    dtDgvDetallesNewRow["modo"] = Convert.ToString(row["modo"]);
                    dtDgvDetallesNewRow["formula_porc"] = Convert.ToString(row["formula_porc"]);
                    dtDgvDetallesNewRow["unidades"] = (Convert.ToInt32(row["codigoConceptoPorEmpresa"]) == Convert.ToInt32(dr["codigoConceptoPorEmpresa"])) ? tbxUnidades.Text : "1";
                    dtDgvDetallesNewRow["codigoConceptoPorEmpresa"] = Convert.ToString(row["codigoConceptoPorEmpresa"]);

                    Liquidar_scrn.dtDgvDetalles.Rows.Add(dtDgvDetallesNewRow);

                    dtXMLNewRow["codigo"] = Convert.ToString(row["codigo"]);
                    dtXMLNewRow["descripcion"] = Convert.ToString(row["descripcion"]);
                    dtXMLNewRow["hab_fijo"] = Convert.ToString(row["hab_fijo"]);
                    dtXMLNewRow["hab_porc"] = Convert.ToString(row["hab_porc"]);
                    dtXMLNewRow["ded_fijo"] = Convert.ToString(row["ded_fijo"]);
                    dtXMLNewRow["ded_porc"] = Convert.ToString(row["ded_porc"]);
                    dtXMLNewRow["tipo"] = Convert.ToString(row["tipo"]);
                    dtXMLNewRow["modo"] = Convert.ToString(row["modo"]);
                    dtXMLNewRow["formula_porc"] = Convert.ToString(row["formula_porc"]);
                    dtXMLNewRow["unidades"] = (Convert.ToInt32(row["codigoConceptoPorEmpresa"]) == Convert.ToInt32(dr["codigoConceptoPorEmpresa"])) ? tbxUnidades.Text : "1";
                    dtXMLNewRow["codigoConceptoPorEmpresa"] = Convert.ToString(row["codigoConceptoPorEmpresa"]);

                    Liquidar_scrn.dtXML.Rows.Add(dtXMLNewRow);

                }

                Liquidar_scrn.dtDgvDetalles.AcceptChanges();
                Liquidar_scrn.dtXML.AcceptChanges();

                ManejoDeRecibo.CalcularTabla(Liquidar_scrn.dtDgvDetalles);

                Liquidar_scrn.DibujarTablaLiquidar();

                ManejoDeRecibo.CalcularTotales(Liquidar_scrn.dtDgvDetalles, Liquidar_scrn.dgvDetalles, th_rem, th_norem, tded, tneto);

                Liquidar_scrn.ModificarCeldasHaberDeduccion();

                Close();
            }
            catch (Exception error)
            {
                MessageBox.Show("Error: " + error.Message);
            }
           
        }

        private List<DataRow> RecuperarConceptosFormula(DataRow dr)
        {
            string modo = Convert.ToString(dr["modo"]);
            string[] conceptosString;
            double number = 0;
            string codigo = "";

            List<DataRow> listaConceptos = new List<DataRow>();
            listaConceptos.Add(dr);

            try
            {
                switch (modo)
                {
                    case "hab_fijo":
                        conceptosString = Convert.ToString(dr["hab_fijo"]).Replace("(", "").Replace(")", "").Split('/', '*', '-', '+');

                        for (int i = 0; i < conceptosString.Length; i++)
                        {
                            if (!double.TryParse(conceptosString[i], out number))
                            {
                                codigo = conceptosString[i].Replace("|", "").Trim();

                                DataRow checkRowExist = Liquidar_scrn.dtDgvDetalles.AsEnumerable().Where(x => Convert.ToString(x["codigo"]).Equals(codigo)).FirstOrDefault();

                                if (checkRowExist == null)
                                {
                                    DataRow row = tablaListaConceptos.AsEnumerable().Where(x => Convert.ToString(x["codigo"]).Equals(codigo)).FirstOrDefault();

                                    listaConceptos.Add(row);
                                }

                            }
                        }

                        break;
                    case "ded_fijo":

                        if (true)
                        {
                            conceptosString = Convert.ToString(dr["ded_fijo"]).Replace("(", "").Replace(")", "").Split('/', '*', '-', '+');

                            for (int i = 0; i < conceptosString.Length; i++)
                            {
                                if (double.TryParse(conceptosString[i], out number))
                                {
                                    codigo = conceptosString[i].Replace("|", "").Trim();

                                    DataRow checkRowExist = Liquidar_scrn.dtDgvDetalles.AsEnumerable().Where(x => Convert.ToString(x["codigo"]).Equals(codigo)).FirstOrDefault();

                                    if (checkRowExist == null)
                                    {
                                        DataRow row = tablaListaConceptos.AsEnumerable().Where(x => Convert.ToString(x["codigo"]).Equals(codigo)).FirstOrDefault();

                                        listaConceptos.Add(row);
                                    }

                                }
                            }
                        }

                        break;
                    case "hab_porc": case "ded_porc":
                        if (Convert.ToString(dr["formula_porc"]) != "TotalRemunerativos")
                        {
                            conceptosString = Convert.ToString(dr["formula_porc"]).Replace("|", "").Split('+');

                            for (int i = 0; i < conceptosString.Length; i++)
                            {
                                DataRow checkRowExist = Liquidar_scrn.dtDgvDetalles.AsEnumerable().Where(x => Convert.ToInt32(x["codigoConceptoPorEmpresa"]) == Convert.ToInt32(conceptosString[i])).FirstOrDefault();

                                if (checkRowExist == null)
                                {
                                    DataRow row = tablaListaConceptos.AsEnumerable().Where(x => Convert.ToInt32(x["codigoConceptoPorEmpresa"]) == Convert.ToInt32(conceptosString[i])).FirstOrDefault();

                                    listaConceptos.Add(row);
                                }

                            }

                        }
                        break;
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            return listaConceptos;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void recibo_Builder_addConcepto_FormClosing(object sender, FormClosingEventArgs e)
        {
            Liquidar_scrn.Visible = true;
        }
    }
}
