using System;
using System.Data;
using System.Windows.Forms;
using AliSlib;
using AliSLogica.Complementarios;
using Obj;

namespace AliS_WinVer
{
    public partial class LiquidacionesPrincipalConceptos : Form
    {
        GestionLiquidacionConceptos Liquidar_scrn;
        DataSet DS;
        string empresaNombre;
        string cmd;

        public LiquidacionesPrincipalConceptos(GestionLiquidacionConceptos Liquidar_scrn, string empresaNombre)
        {
            InitializeComponent();

            this.Liquidar_scrn = Liquidar_scrn;
            this.empresaNombre = empresaNombre;
        }

        private void recibo_Builder_addConcepto_Load(object sender, EventArgs e)
        {
            CargarGrillaConceptos();
        }

        private void CargarGrillaConceptos()
        {
            DataTable tablaListaConceptos;

            cmd = cmd = string.Format("SELECT codigo AS 'Código', descripcion AS 'Descripción', hab_fijo AS 'Fijo($)', hab_porc AS 'Porcentaje(%)', ded_fijo, ded_porc, tipo AS 'Tipo de concepto', modo, formula_porc  from {0}_Conceptos ORDER BY 'Tipo de concepto' DESC , 'Código' ASC ", empresaNombre.Replace(" ", ""));
            DS = Utilidades.alisDB(cmd);

            tablaListaConceptos = DS.Tables[0];

            foreach (DataRow r in Liquidar_scrn.dtDgvDetalles.Rows)
            {
                foreach (DataRow row in tablaListaConceptos.Rows)
                {
                    if (r["codigo"].ToString().Replace("\"", "") == row["Código"].ToString())
                    {
                        row.Delete();
                        tablaListaConceptos.AcceptChanges();
                        break;
                    }
                }

            }

            dataGridView1.DataSource = tablaListaConceptos;
            dataGridView1.Columns[0].Width = 70;
            dataGridView1.Columns[1].Width = 250;
            dataGridView1.Columns[2].Width = 95;
            dataGridView1.Columns[3].Width = 95;
            dataGridView1.Columns[4].Width = 95;
            dataGridView1.Columns[4].HeaderText = "Fijo($)";
            dataGridView1.Columns[5].Width = 95;
            dataGridView1.Columns[5].HeaderText = "Porcentaje(%)";
            dataGridView1.Columns[6].Width = 72;
            dataGridView1.Columns[7].Visible = false;
            dataGridView1.Columns[8].Visible = false;

            for (int i = 2; i < 7; i++)
            {
                dataGridView1.Columns[i].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                if (i >= 2)
                {
                    dataGridView1.Columns[i].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                DataRow NewRow = Liquidar_scrn.dtDgvDetalles.NewRow();
                Label th_rem = Liquidar_scrn.lblRemInfo;
                Label th_norem = Liquidar_scrn.lblNoRemInfo;
                Label tded = Liquidar_scrn.lblDeduccionesInfo;
                Label tneto = Liquidar_scrn.lblNetoInfo;


                for (int i = 0; i <= 11; i++)
                {
                    string currentCol;

                    if (i <= 8)
                    {
                        currentCol = dataGridView1.CurrentRow.Cells[i].Value.ToString();

                        if (i == 0)
                        {
                            currentCol = '"' + currentCol + '"';
                        }

                        NewRow[i] = currentCol;
                    }
                    //MessageBox.Show(currentCol);
                    if (i == 9)
                    {
                        NewRow[i] = unidBox.Text;
                    }
                }

                Liquidar_scrn.dtDgvDetalles.Rows.Add(NewRow);

                //int lastIndex = Liquidar_scrn.dtDgvDetalles.Rows.Count - 1;

                //DataView dv = new DataView(Liquidar_scrn.dtDgvDetalles);
                //dv.Sort = "tipo DESC";
                //Liquidar_scrn.dtDgvDetalles = dv.ToTable();

                //DataRow row = Liquidar_scrn.dtDgvDetalles.NewRow();

                //row[0] = Liquidar_scrn.dtDgvDetalles.Rows[lastIndex][0];
                //row[1] = Liquidar_scrn.dtDgvDetalles.Rows[lastIndex][1];
                //row[2] = Liquidar_scrn.dtDgvDetalles.Rows[lastIndex][2];
                //row[3] = Liquidar_scrn.dtDgvDetalles.Rows[lastIndex][3];
                //row[4] = Liquidar_scrn.dtDgvDetalles.Rows[lastIndex][4];
                //row[5] = Liquidar_scrn.dtDgvDetalles.Rows[lastIndex][5];
                //row[6] = Liquidar_scrn.dtDgvDetalles.Rows[lastIndex][6];
                //row[7] = Liquidar_scrn.dtDgvDetalles.Rows[lastIndex][7];
                //row[8] = Liquidar_scrn.dtDgvDetalles.Rows[lastIndex][8];
                //row[9] = Liquidar_scrn.dtDgvDetalles.Rows[lastIndex][9];
                //row[10] = Liquidar_scrn.dtDgvDetalles.Rows[lastIndex][10];
                //row[11] = Liquidar_scrn.dtDgvDetalles.Rows[lastIndex][11];

                //Liquidar_scrn.dtDgvDetalles.Rows.RemoveAt(lastIndex);

                //Liquidar_scrn.dtDgvDetalles.Rows.InsertAt(row,0);

                ManejoDeRecibo.CalcularTabla(Liquidar_scrn.dtDgvDetalles);

                //ReciboTools.CalcularTabla(Liquidar_scrn.dtDgvDetalles);

                //ReciboTools.DrawTabla(Liquidar_scrn.dtDgvDetalles, Liquidar_scrn.dgvDetalles, true);

                Liquidar_scrn.DibujarTablaLiquidar();

                //Liquidar_scrn.dgvDetalles.Sort(Liquidar_scrn.dgvDetalles.Columns[6], ListSortDirection.Descending);

                //ReciboTools.CalcularTotales(Liquidar_scrn.dtDgvDetalles, Liquidar_scrn.dgvDetalles, th_rem, th_norem, tded, tneto);

                Close();
            }
            catch (Exception error)
            {
                MessageBox.Show("Error: " + error.Message);
            }
           
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
