using System;
using System.Data;
using System.Windows.Forms;
using AliSlib;
using Obj;
using AliSLogica.Controladores;
using AliSLogica.Complementarios;
using System.Text;

namespace AliS_WinVer
{
    public partial class PrincipalConceptos : Form
    {
        #region PROPIEDADES
        private Index Index;
        private GestionLiquidacionConceptos ScreenLiquidar;
        public DataTable tablaConceptos;
        public bool isDeduccion;
        private bool IsModoEditar;

        #endregion

        #region INICIO
        public PrincipalConceptos(Index Index, GestionLiquidacionConceptos Liquidar_scrn, bool isModoEditar)
        {
            InitializeComponent();
            this.Index = Index;
            this.IsModoEditar = isModoEditar;
            this.ScreenLiquidar = Liquidar_scrn;
        }

        public void conceptos_Load(object sender, EventArgs e)
        {
            this.Text = string.Format("{0}: Conceptos", UsuarioSingleton.Instance.NombreEmpresa);

            tablaConceptos = ControladorConcepto.RecuperarConceptosPorCodigoEmpresa(UsuarioSingleton.Instance.codigoEmpresa);

            CargarTablaConceptos();

            if (IsModoEditar)
            {
                AdaptarTablaModoEditar();
            }


        }
        #endregion

        #region BOTONES
        private void button1_Click(object sender, EventArgs e)
        {
            AñadirConcepto añadirConcepto = new AñadirConcepto(this);
            this.Visible = false;
            añadirConcepto.Show();
        }

        //Elimina concepto.
        private void button3_Click(object sender, EventArgs e)
        {
            DataTable rta;
            string nombreEmpresa = UsuarioSingleton.Instance.NombreEmpresa.Replace(" ", "");

            int codigoConceptoPorEmpresa = Convert.ToInt32(dgvConceptos.CurrentRow.Cells[0].Value);
            string codigo = Convert.ToString(dgvConceptos.CurrentRow.Cells[1].Value);
            string descripcion = Convert.ToString(dgvConceptos.CurrentRow.Cells[2].Value);

            string mensaje = String.Format("¿Esta seguro que desea eliminar el siguiente concepto?\n \n Código: {0}\n Descripción: {1}", codigo, descripcion);

            DialogResult result = MessageBox.Show(mensaje, "Eliminar concepto", MessageBoxButtons.YesNo);

            if (result == DialogResult.Yes)
            {

                try
                {

                    rta = ControladorConcepto.EliminarConceptoPorEmpresa(codigoConceptoPorEmpresa);


                    if (rta.Columns[0].ColumnName.Equals("respuesta") && rta.Rows[0][0].Equals("ok"))
                    {
                        MessageBox.Show("¡El concepto fue eliminado con exito!");
                    }
                    else if(rta.Columns[0].ColumnName.Equals("descripcion"))
                    {
                        StringBuilder sb = new StringBuilder();
                        sb.Append("El concepto no se puede eliminar ya que está asociado a la formula de los siguientes conceptos:\n");
                        sb.Append("\n");

                        for (int i = 0; i < rta.Rows.Count; i++ )
                        {
                            sb.Append("- " + Convert.ToString(rta.Rows[i][0]) + "\n");
                        }

                        MessageBox.Show(Convert.ToString(sb));
                    }
                    else
                    {
                        MessageBox.Show(Convert.ToString(rta.Rows[0][0]));
                    }



                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

            }
            /*else if (result == DialogResult.No)
            {

            }*/
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Visible = false;

            EditarConcepto editarConcepto = new EditarConcepto(this, IsModoEditar);
            editarConcepto.Show();
        }
        #endregion

        #region EXCLUSIVO MODO EDITAR

        private void AceptarEditBtn_Click(object sender, EventArgs e)
        {
            string cmd;
            string dtCodigo1;
            string dtCodigo2;
            string modo;
            string fijo;
            string porc;
            string formula;
            string tipo;

            DialogResult confirm = MessageBox.Show("Esto solo afectará a los conceptos modificados en el mes seleccionado.\n¿Desea también actualizar los valores de la lista general de conceptos?", "Confirmar", MessageBoxButtons.YesNo);

            // Modifica el concepto en la DB.
            if (confirm == DialogResult.Yes)
            {
                
                foreach (DataRow row in ScreenLiquidar.dtXML.Rows)
                {
                    int index = ScreenLiquidar.dtXML.Rows.IndexOf(row);

                    dtCodigo1 = (ScreenLiquidar.dtXML.Rows[index][0].ToString()).Replace("\"","");

                    for (int i = 0; i < tablaConceptos.Rows.Count; i++)
                    {
                        dtCodigo2 = tablaConceptos.Rows[i][0].ToString();
                        
                        if (dtCodigo1 == dtCodigo2)
                        {
                            modo = tablaConceptos.Rows[i][7].ToString();
                            tipo = tablaConceptos.Rows[i][6].ToString();

                            switch (modo)
                            {
                                case "hab_fijo":
                                    fijo = tablaConceptos.Rows[i][2].ToString();
                                    cmd = string.Format("UPDATE {0}_Conceptos SET hab_fijo = '{1}', hab_porc = NULL, tipo = '{2}', modo = 'hab_fijo', formula_porc = NULL WHERE codigo = '{3}'", UsuarioSingleton.Instance.NombreEmpresa.Replace(" ",""), fijo, tipo, dtCodigo2);
                                    break;
                                case "hab_porc":
                                    porc = tablaConceptos.Rows[i][3].ToString();
                                    formula = tablaConceptos.Rows[i][8].ToString();

                                    cmd = string.Format("UPDATE {0}_Conceptos SET hab_fijo = NULL, hab_porc = '{1}', tipo = '{2}', modo = 'hab_porc', formula_porc = '{3}' WHERE codigo = '{4}'", UsuarioSingleton.Instance.NombreEmpresa.Replace(" ", ""), porc, tipo, formula, dtCodigo2);
                                    break;
                                case "ded_fijo":
                                    fijo = tablaConceptos.Rows[i][4].ToString();

                                    cmd = string.Format("UPDATE {0}_Conceptos SET ded_fijo = '{1}', ded_porc = NULL, tipo = '{2}', modo = 'ded_fijo', formula_porc = NULL WHERE codigo = '{3}'", UsuarioSingleton.Instance.NombreEmpresa.Replace(" ", ""), fijo, tipo, dtCodigo2);
                                    break;
                                default:
                                    porc = tablaConceptos.Rows[i][5].ToString();
                                    formula = tablaConceptos.Rows[i][8].ToString();

                                    cmd = string.Format("UPDATE {0}_Conceptos SET ded_fijo = NULL, ded_porc = '{1}', tipo = '{2}', modo = 'ded_porc', formula_porc = '{3}' WHERE codigo = '{4}'", UsuarioSingleton.Instance.NombreEmpresa.Replace(" ", ""), porc, tipo, formula, dtCodigo2);
                                    break;
                            }
                            Utilidades.alisDB(cmd);
                            break;
                        }
                    }
                }
            }

            // Modifica la DataTable entrante de Liquidar Screen.
            foreach (DataRow DT1_row in ScreenLiquidar.dtXML.Rows)
            {
                int index = ScreenLiquidar.dtXML.Rows.IndexOf(DT1_row);
                dtCodigo1 = ScreenLiquidar.dtXML.Rows[index][0].ToString();
                for (int i = 0; i < tablaConceptos.Rows.Count; i++)
                {
                    dtCodigo2 = "\"" + tablaConceptos.Rows[i][0].ToString() + "\"";
                    if (dtCodigo1 == dtCodigo2)
                    {
                        modo = tablaConceptos.Rows[i][7].ToString();
                        tipo = tablaConceptos.Rows[i][6].ToString();

                        if (dtCodigo1 == "\"" + "BAS" + "\"")
                        {
                            break;
                        }
                        switch (modo)
                        {
                            case "hab_fijo":
                                fijo = tablaConceptos.Rows[i][2].ToString();
                                ScreenLiquidar.editFormulas.Add(fijo);

                                ScreenLiquidar.dtXML.Rows[index][2] = fijo;
                                ScreenLiquidar.dtXML.Rows[index][3] = "";
                                ScreenLiquidar.dtXML.Rows[index][6] = tipo;
                                ScreenLiquidar.dtXML.Rows[index][7] = modo;
                                ScreenLiquidar.dtXML.Rows[index][8] = "";
                                break;
                            case "hab_porc":
                                porc = tablaConceptos.Rows[i][3].ToString();
                                formula = tablaConceptos.Rows[i][8].ToString();
                                ScreenLiquidar.editFormulas.Add("");

                                ScreenLiquidar.dtXML.Rows[index][2] = "";
                                ScreenLiquidar.dtXML.Rows[index][3] = porc;
                                ScreenLiquidar.dtXML.Rows[index][6] = tipo;
                                ScreenLiquidar.dtXML.Rows[index][7] = modo;
                                ScreenLiquidar.dtXML.Rows[index][8] = formula;
                                break;
                            case "ded_fijo":
                                fijo = tablaConceptos.Rows[i][4].ToString();
                                ScreenLiquidar.editFormulas.Add(fijo);

                                ScreenLiquidar.dtXML.Rows[index][4] = fijo;
                                ScreenLiquidar.dtXML.Rows[index][5] = "";
                                ScreenLiquidar.dtXML.Rows[index][6] = tipo;
                                ScreenLiquidar.dtXML.Rows[index][7] = modo;
                                ScreenLiquidar.dtXML.Rows[index][8] = "";
                                break;
                            default:
                                porc = tablaConceptos.Rows[i][5].ToString();
                                formula = tablaConceptos.Rows[i][8].ToString();
                                ScreenLiquidar.editFormulas.Add("");


                                ScreenLiquidar.dtXML.Rows[index][4] = "";
                                ScreenLiquidar.dtXML.Rows[index][5] = porc;
                                ScreenLiquidar.dtXML.Rows[index][6] = tipo;
                                ScreenLiquidar.dtXML.Rows[index][7] = modo;
                                ScreenLiquidar.dtXML.Rows[index][8] = formula;
                                break;
                        }
                    }
                }
            }
            Close();
        }
        #endregion

        #region METODOS

        private void CargarTablaConceptos()
        {
            dgvConceptos.DataSource = tablaConceptos;

            dgvConceptos.Columns[1].Width = 70;
            dgvConceptos.Columns[2].Width = 250;
            dgvConceptos.Columns[3].Width = 95;
            dgvConceptos.Columns[4].Width = 95;
            dgvConceptos.Columns[5].Width = 95;
            dgvConceptos.Columns[6].Width = 95;
            dgvConceptos.Columns[7].Width = 72;

            dgvConceptos.Columns[1].HeaderText = "Código";
            dgvConceptos.Columns[2].HeaderText = "Descripción";
            dgvConceptos.Columns[3].HeaderText = "Fijo($)";
            dgvConceptos.Columns[4].HeaderText = "Porcentaje(%)";
            dgvConceptos.Columns[5].HeaderText = "Fijo($)";
            dgvConceptos.Columns[6].HeaderText = "Porcentaje(%)";
            dgvConceptos.Columns[7].HeaderText = "Tipo";

            dgvConceptos.Columns[0].Visible = false;
            dgvConceptos.Columns[8].Visible = false;
            dgvConceptos.Columns[9].Visible = false;

            for (int i = 2; i < 7; i++)
            {
                dgvConceptos.Columns[i].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;

                if (i >= 2)
                {
                    dgvConceptos.Columns[i].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                }
            }
        }

        private void AdaptarTablaModoEditar()
        {
            string dgvConceptosCodigo2;

            AceptarEditBtn.Visible = true;

            foreach (DataRow row in tablaConceptos.Rows)
            {
                int index = tablaConceptos.Rows.IndexOf(row);

                dgvConceptos.CurrentCell = null;
                dgvConceptos.Rows[index].Visible = false;

                foreach (DataRow r in ScreenLiquidar.dtXML.Rows)
                {
                    
                    if (Convert.ToString(r["tipo"]).Equals("BAS"))
                    {
                        continue;
                    }

                    if (Convert.ToString(r["codigo"]).Replace("\"","").Equals(row["Código"]))
                    {
                        dgvConceptos.Rows[index].Visible = true;
                        break;
                    }
                }
            }









            //for (int i = 0; i < dgvConceptos.Rows.Count; i++)
            //{
            //    dgvConceptosCodigo1 = dgvConceptos.Rows[i].Cells[0].Value.ToString();
            //    dgvConceptos.CurrentCell = null;
            //    dgvConceptos.Rows[i].Visible = false;

            //    for (int a = 0; a < ScreenLiquidar.dgvDetalles.Rows.Count; a++)
            //    {
            //        dgvConceptosCodigo2 = ScreenLiquidar.dgvDetalles.Rows[a].Cells[0].Value.ToString();
            //        if (dgvConceptosCodigo1 == dgvConceptosCodigo2)
            //        {
            //            dgvConceptos.Rows[i].Visible = true;
            //            break;
            //        }
            //    }
            //}
            // Hace los botones agregar y eliminar invisibles cuando esta en modo edit.
            button1.Visible = false;
            button3.Visible = false;

            button2.Left = 713;
        }

        #endregion

        #region EVENTOS
        private void conceptos_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!IsModoEditar)
            {
                Index.Enabled = true;
                Index.Visible = true;
            }
            else
            {
                ManejoDeRecibo.CalcularTabla(ScreenLiquidar.dtXML);

                ManejoDeRecibo.DrawTabla(ScreenLiquidar.dtXML, ScreenLiquidar.dgvDetalles, true);

                ManejoDeRecibo.CalcularTotales(ScreenLiquidar.dtXML, ScreenLiquidar.dgvDetalles, ScreenLiquidar.lblRemInfo, ScreenLiquidar.lblNoRemInfo, ScreenLiquidar.lblDeduccionesInfo, ScreenLiquidar.lblNetoInfo);

                ScreenLiquidar.Visible = true;
            }
        }
        #endregion
    }
}
