
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using System.IO;
using Obj;
using AliSlib;
using AliSLogica.Controladores;
using AliSLogica.Complementarios;

namespace AliS_WinVer
{
    public partial class PrincipalLegajos : Form
    {
        #region PROPIEDADES
        private Index Index;

        private string oldNumeroLegajo;

        private int treeViewEmpresasIndex;
        private bool preventTabChange = false;

        private List<string> CacheEdit = new List<string>();
        private List<bool> CacheEditDGV = new List<bool>();

        #endregion

        #region INICIO
        public PrincipalLegajos(Index Index, int TVindex)
        {
            InitializeComponent();

            this.Index = Index;
            this.treeViewEmpresasIndex = TVindex;
        }

        private void add_empl_Load(object sender, EventArgs e)
        {
            this.Text = string.Format("{0}: Legajos", UsuarioSingleton.Instance.NombreEmpresa);

            // Rellena el comboBox con los puestos de trabajo disponibles.
            DataTable tablaPuestos = ControladorAddLegajos.RecuperarPuestos(UsuarioSingleton.Instance.CuitEmpresa);

            DataRow toInsert = tablaPuestos.NewRow();
            tablaPuestos.Rows.InsertAt(toInsert, 0);

            tablaPuestos.Rows[0]["puesto"] = "-- Selecciones un puesto --";

            puestoSelect.DataSource = tablaPuestos;
            puestoSelect.ValueMember = "puesto";

            // Carga la lista de conceptos para liquidar.
            DataTable tablaConceptos = ControladorAddLegajos.RecuperarConceptos(UsuarioSingleton.Instance.NombreEmpresa);

            // Modifica los tamaños de las celdas del dataGrid.
            dataGridView1.DataSource = tablaConceptos;
            dataGridView1.Columns[0].Width = 30;
            dataGridView1.Columns[1].Width = 70;
            dataGridView1.Columns[1].ReadOnly = true;
            dataGridView1.Columns[2].Width = 220;
            dataGridView1.Columns[2].ReadOnly = true;
            dataGridView1.Columns[3].Width = 65;
            dataGridView1.Columns[3].ReadOnly = true;

            conceptosDGV.DataSource = tablaConceptos;
            conceptosDGV.Columns[0].Width = 30;
            conceptosDGV.Columns[1].Width = 70;
            conceptosDGV.Columns[1].ReadOnly = true;
            conceptosDGV.Columns[2].Width = 220;
            conceptosDGV.Columns[2].ReadOnly = true;
            conceptosDGV.Columns[3].Width = 65;
            conceptosDGV.Columns[3].ReadOnly = true;
        }
        #endregion

        #region TREEVIEW
        private void treeViewLegajos_AfterSelect(object sender, TreeViewEventArgs e)
        {
            string legajo = treeViewLegajos.SelectedNode.Text.Substring(3);
            string puesto;
            string txt = treeViewLegajos.SelectedNode.Text;
            string conceptosList;
            string[] conceptosSplit;

            string cmd = string.Format("SELECT n_legajo, nombre, cuil, puesto, ingreso, banco, convenio, conceptos FROM Legajos WHERE n_legajo = '{0}' AND cuit_empresa = '{1}'", legajo, UsuarioSingleton.Instance.CuitEmpresa);
            DataSet DS4 = Utilidades.alisDB(cmd);
            
            if (txt != UsuarioSingleton.Instance.NombreEmpresa)
            {
                puesto = DS4.Tables[0].Rows[0][3].ToString();

                editLegajoLabel.Text = DS4.Tables[0].Rows[0][0].ToString();
                editNombreLabel.Text = DS4.Tables[0].Rows[0][1].ToString();
                editCuilLabel.Text = DS4.Tables[0].Rows[0][2].ToString();
                editPuestoLabel.Text = puesto;
                editFechaLabel.Text = DS4.Tables[0].Rows[0][4].ToString();
                editBancoLabel.Text = DS4.Tables[0].Rows[0][5].ToString();
                editConvenioLabel.Text = DS4.Tables[0].Rows[0][6].ToString();
                conceptosList = DS4.Tables[0].Rows[0][7].ToString();
                conceptosSplit = conceptosList.Split(';');

                cmd = string.Format("SELECT puesto FROM Puestos WHERE cuit_empresa = '{0}'", UsuarioSingleton.Instance.CuitEmpresa);
                DS4 = Utilidades.alisDB(cmd);

                editPuestoSelect.DataSource = DS4.Tables[0];
                editPuestoSelect.ValueMember = "puesto";

                editPuestoSelect.SelectedIndex = editPuestoSelect.FindStringExact(puesto);

                editLegajoButton.Enabled = true;
                deleteLegajoButton.Enabled = true;

                conceptosDGV.Enabled = true;

                foreach (DataGridViewRow row in conceptosDGV.Rows)
                {
                    int index = conceptosDGV.Rows.IndexOf(row);
                    conceptosDGV.Rows[index].Cells[0].Value = false;
                }

                CacheEditDGV.Clear();

                for (int i = 0; i < conceptosSplit.Length; i++)
                {
                    foreach (DataGridViewRow row in conceptosDGV.Rows)
                    {
                        int index = conceptosDGV.Rows.IndexOf(row);

                        if (conceptosDGV.Rows[index].Cells[1].Value.ToString() == conceptosSplit[i])
                        {
                            conceptosDGV.Rows[index].Cells[0].Value = true;
                            break;
                        }
                    }
                }

                foreach (DataGridViewRow row in conceptosDGV.Rows)
                {
                    int index = conceptosDGV.Rows.IndexOf(row);
                    CacheEditDGV.Add(Convert.ToBoolean(conceptosDGV.Rows[index].Cells[0].Value));
                }
            }

        }

        #endregion

        #region BOTONES

        private void editLegajoButton_Click(object sender, EventArgs e)
        {
            HabilitarEdicionLegajo();
        }

        private void cancelEdit_Click(object sender, EventArgs e)
        {
            DeshabilitarEdicionLegajo();
        }

        //EDITA LOS LEGAJOS DE LA BASE DE DATOS.
        private void saveEdit_Click(object sender, EventArgs e)
        {
            string numeroLegajo = editLegajoNumeroInput.Text;
            string nombre = editNombre.Text;
            string puesto = editPuestoSelect.Text;
            string banco = editBanco.Text;
            string convenio = editConvenio.Text;
            string conceptos = "";
            bool DGVchanges = false;

            for (int i = 0; i < conceptosDGV.RowCount; i++)
            {
                if(Convert.ToBoolean(conceptosDGV.Rows[i].Cells[0].Value) != CacheEditDGV[i])
                {
                    DGVchanges = true;
                    break;
                }
            }

            if (CacheEdit[0] == numeroLegajo && CacheEdit[1] == nombre && CacheEdit[2] == puesto && CacheEdit[3] == banco && CacheEdit[4] == convenio && !DGVchanges)
            {
                //MessageBox.Show("nada cambio");
            }
            else
            {
                if (numeroLegajo.Length == 0 || numeroLegajo == " " || nombre.Length == 0 || nombre == " " || banco.Length == 0 || banco == " " || convenio.Length == 0 || convenio == " " || dataGridView1.Rows.Count < 1)
                {
                    MessageBox.Show("Error: Asegurese de que todos los campos esten llenos.");
                }
                else
                {
                    try
                    {
                        try
                        {
                            for (int i = 0; i < conceptosDGV.RowCount; i++)
                            {
                                if (Convert.ToBoolean(conceptosDGV.Rows[i].Cells[0].Value))
                                {
                                    conceptos += conceptosDGV.Rows[i].Cells[1].Value.ToString() + ";";
                                }
                            }
                            conceptos = conceptos.Substring(0, conceptos.Length - 1);
                        }
                        catch (Exception error)
                        {
                            MessageBox.Show("error: Debe elegir al menos un concepto de la lista de conceptos.");
                            throw error;
                        }

                        ControladorAddLegajos.EditarLegajo(UsuarioSingleton.Instance.CuitEmpresa, nombre, puesto, conceptos, numeroLegajo, oldNumeroLegajo, banco, convenio);

                        treeViewLegajos.Nodes.Clear();
                        add_empl_Load(null, EventArgs.Empty);

                        treeViewLegajos.Enabled = true;

                        editLegajoButton.Enabled = true;
                        editLegajoButton.Visible = true;

                        deleteLegajoButton.Enabled = true;
                        deleteLegajoButton.Visible = true;

                        saveEdit.Visible = false;
                        cancelEdit.Visible = false;

                        editNombre.ReadOnly = true;
                        editLegajoNumeroInput.ReadOnly = true;
                        editBanco.ReadOnly = true;
                        editConvenio.ReadOnly = true;

                        CargarLegajos();

                        MessageBox.Show("El legajo ha sido actualizado.");

                        editNombre.Visible = false;
                        editLegajoNumeroInput.Visible = false;
                        editBanco.Visible = false;
                        editConvenio.Visible = false;

                        editPuestoSelect.Enabled = false;
                        editPuestoSelect.Visible = false;

                        editLegajoLabel.Visible = true;
                        editNombreLabel.Visible = true;
                        editPuestoLabel.Visible = true;
                        editBancoLabel.Visible = true;
                        editConvenioLabel.Visible = true;

                        TreeNode[] tns = treeViewLegajos.Nodes
                            .Cast<TreeNode>()
                            .Where(r => r.Text == "Nº " + editLegajoNumeroInput.Text)
                            .ToArray();

                        if (tns.Length > 0)
                        {
                            treeViewLegajos.SelectedNode = tns[0];
                            treeViewLegajos.Focus();
                        }
                        conceptosDGV.Columns[0].ReadOnly = true;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                    
                }
            }
            preventTabChange = false;

        }

        //BORRA LOS LEGAJOS DE LA BASE DE DATOS.
        private void deleteLegajoButton_Click(object sender, EventArgs e)
        {
            string numeroLegajo = editLegajoLabel.Text;
            string nombre = editNombre.Text;

            string folder = string.Format("{0}/{1}/{2}", UsuarioSingleton.Instance.AlisFolder, UsuarioSingleton.Instance.NombreEmpresa,
                            editCuilLabel.Text.Replace("-", ""));

            DialogResult confirm = MessageBox.Show("¿Esta seguro que desea eliminar el siguiente legajo?\n \n   " + "Legajo: Nº "+numeroLegajo+"\n   Nombre: "+ nombre, "Eliminar legajo:", MessageBoxButtons.YesNo);

            if (confirm == DialogResult.Yes)
            {
                try
                {
                    ControladorAddLegajos.EliminarLegajos(UsuarioSingleton.Instance.CuitEmpresa, numeroLegajo);
                    ManejoDirectiorios.EliminarDirectorio(folder);

                    MessageBox.Show("¡El legajo ha sido eliminado!");
                    LimpiarCamposEditarLegajos();
                    CargarLegajos();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void createLegajo_Click(object sender, EventArgs e)
        {
            string numeroLegajo = LegajoNumeroInput.Text;
            string nombreEmpleado = UsuarioSingleton.UppercaseFirst(nombreInput.Text);
            string apellidoEmpleado = UsuarioSingleton.UppercaseFirst(apellidoInput.Text);
            string cuil1 = cuilInput1.Text;
            string cuil2 = cuilInput2.Text;
            string cuil3 = cuilInput3.Text;
            string ocupacionEmpleado = UsuarioSingleton.UppercaseFirst(puestoSelect.Text);
            string ingresoEmpleado = ingresoPicker.Text;
            string convenioEmpleado = convenioInput.Text;
            string bancoEmpleado = bancoInput.Text;
            string conceptosEmpleado = "";

            if (numeroLegajo.Length == 0 || numeroLegajo== " " || nombreEmpleado.Length == 0 || nombreEmpleado == " " || apellidoEmpleado.Length == 0 || apellidoEmpleado == " " || cuil1.Length == 0 || cuil1 == " " || cuil2.Length == 0 || cuil2 == " " || cuil3.Length == 0 || cuil3 == " " || ocupacionEmpleado.Length == 0 || ocupacionEmpleado == " " || ingresoEmpleado.Length == 0 || ingresoEmpleado == " " || convenioEmpleado.Length == 0  || convenioEmpleado == " " || bancoEmpleado.Length == 0 || bancoEmpleado == " " || puestoSelect.Text == "-- Selecciones un puesto --")
            {
                MessageBox.Show("Error: Debe rellenar todos los campos.");
            }
            else
            {
                try
                {
                    try
                    {
                        for (int i = 0; i < dataGridView1.RowCount; i++)
                        {
                            if (Convert.ToBoolean(dataGridView1.Rows[i].Cells[0].Value))
                            {
                                conceptosEmpleado += dataGridView1.Rows[i].Cells[1].Value.ToString() + ";";
                            }
                        }
                        conceptosEmpleado = conceptosEmpleado.Substring(0, conceptosEmpleado.Length - 1);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("error: Debe elegir al menos un concepto de la lista de conceptos.");
                        return;
                    }

                    ControladorAddLegajos.InsertarLegajo(UsuarioSingleton.Instance.CuitEmpresa, nombreEmpleado, apellidoEmpleado,
                        cuil1, cuil2, cuil3, ocupacionEmpleado, ingresoEmpleado, conceptosEmpleado, numeroLegajo, bancoEmpleado, convenioEmpleado);

                    ManejoDirectiorios.CrearDirectorioEmpleado(UsuarioSingleton.Instance.AlisFolder, UsuarioSingleton.Instance.NombreEmpresa, UsuarioSingleton.Instance.CuitEmpresa,
                        nombreEmpleado, apellidoEmpleado, cuil1, cuil2, cuil3, ocupacionEmpleado, ingresoEmpleado, conceptosEmpleado, numeroLegajo,
                        bancoEmpleado, convenioEmpleado);

                    LimpiarCamposCrearLegajos();

                    foreach (DataGridViewRow row in dataGridView1.Rows)
                    {
                        int index = dataGridView1.Rows.IndexOf(row);
                        dataGridView1.Rows[index].Cells[0].Value = false;
                    }

                    MessageBox.Show("¡Legajo creado con éxito!");

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

            }
        }

        #endregion

        #region METODOS

        private void HabilitarEdicionLegajo()
        {
            preventTabChange = true;

            conceptosDGV.Columns[0].ReadOnly = false;

            treeViewLegajos.Enabled = false;

            editLegajoLabel.Visible = false;
            editNombreLabel.Visible = false;
            editPuestoLabel.Visible = false;
            editBancoLabel.Visible = false;
            editConvenioLabel.Visible = false;

            editLegajoNumeroInput.Visible = true;
            editNombre.Visible = true;

            editFechaLabel.Visible = true;
            editBanco.Visible = true;
            editConvenio.Visible = true;
            editPuestoSelect.Visible = true;

            saveEdit.Enabled = true;
            saveEdit.Visible = true;
            cancelEdit.Enabled = true;
            cancelEdit.Visible = true;

            editNombre.Text = editNombreLabel.Text;
            editNombre.ReadOnly = false;
            editNombre.BorderStyle = BorderStyle.Fixed3D;

            editLegajoNumeroInput.Text = editLegajoLabel.Text;
            editLegajoNumeroInput.ReadOnly = false;
            editLegajoNumeroInput.BorderStyle = BorderStyle.Fixed3D;

            editBanco.Text = editBancoLabel.Text;
            editBanco.ReadOnly = false;
            editBanco.BorderStyle = BorderStyle.Fixed3D;

            editConvenio.Text = editConvenioLabel.Text;
            editConvenio.ReadOnly = false;
            editConvenio.BorderStyle = BorderStyle.Fixed3D;

            editPuestoSelect.Enabled = true;
            oldNumeroLegajo = editLegajoNumeroInput.Text;

            // Limpia la lista que se usa de cache.
            CacheEdit.Clear();
            // Llena la lista que se usa de cache.
            CacheEdit.Add(editLegajoNumeroInput.Text);
            CacheEdit.Add(editNombre.Text);
            CacheEdit.Add(editPuestoSelect.Text);
            CacheEdit.Add(editBanco.Text);
            CacheEdit.Add(editConvenio.Text);

            deleteLegajoButton.Enabled = false;
            deleteLegajoButton.Visible = false;

            editLegajoButton.Enabled = false;
            editLegajoButton.Visible = false;
        }

        private void DeshabilitarEdicionLegajo()
        {
            editLegajoLabel.Visible = true;
            editNombreLabel.Visible = true;
            editPuestoLabel.Visible = true;
            editBancoLabel.Visible = true;
            editConvenioLabel.Visible = true;

            editLegajoNumeroInput.Visible = false;
            editNombre.Visible = false;

            editBanco.Visible = false;
            editConvenio.Visible = false;
            editPuestoSelect.Visible = false;

            deleteLegajoButton.Enabled = true;
            deleteLegajoButton.Visible = true;

            editLegajoButton.Enabled = true;
            editLegajoButton.Visible = true;

            saveEdit.Enabled = false;
            saveEdit.Visible = false;

            cancelEdit.Enabled = false;
            cancelEdit.Visible = false;

            editNombre.ReadOnly = true;
            editNombre.BorderStyle = BorderStyle.None;

            editLegajoNumeroInput.ReadOnly = true;
            editLegajoNumeroInput.BorderStyle = BorderStyle.None;

            editBanco.ReadOnly = true;
            editBanco.BorderStyle = BorderStyle.None;

            editConvenio.ReadOnly = true;
            editConvenio.BorderStyle = BorderStyle.None;

            editPuestoSelect.Enabled = false;
            treeViewLegajos.Enabled = true;

            foreach (DataGridViewRow row in conceptosDGV.Rows)
            {
                int index = conceptosDGV.Rows.IndexOf(row);

                conceptosDGV.Rows[index].Cells[0].Value = CacheEditDGV[index];
            }

            conceptosDGV.Columns[0].ReadOnly = true;

            TreeNode[] tns = treeViewLegajos.Nodes
                .Cast<TreeNode>()
                .Where(r => r.Text == "Nº " + editLegajoNumeroInput.Text)
                .ToArray();

            if (tns.Length > 0)
            {
                treeViewLegajos.SelectedNode = tns[0];
                treeViewLegajos.Focus();
            }

            preventTabChange = false;
        }

        private void LimpiarCamposCrearLegajos()
        {
            LegajoNumeroInput.Clear();
            nombreInput.Clear();
            apellidoInput.Clear();
            cuilInput1.Clear();
            cuilInput2.Clear();
            cuilInput3.Clear();
            puestoSelect.SelectedIndex = 0;
            convenioInput.Clear();
            bancoInput.Clear();
        }

        private void LimpiarCamposEditarLegajos()
        {
            editLegajoNumeroInput.Clear();
            editNombre.Clear();
            editConvenio.Clear();
            editBanco.Clear();
            editPuestoSelect.Text = "";

            treeViewLegajos.Nodes.Clear();

        }

        private void CargarLegajos()
        {
            if (tabControl1.SelectedIndex == 1)
            {
                DataTable tablaLegajos = ControladorAddLegajos.RecuperarLegajos(UsuarioSingleton.Instance.CuitEmpresa);

                treeViewLegajos.Nodes.Clear();

                //Carga lista de  legajos para modificar/borrar.
                foreach (DataRow dr in tablaLegajos.Rows)
                {
                    treeViewLegajos.Nodes.Add("Nº " + dr["n_legajo"].ToString());
                }
            }
        }

        #endregion

        #region EVENTOS
        private void tabControl1_Selecting(object sender, TabControlCancelEventArgs e)
        {
            CargarLegajos();

            if (tabControl1.SelectedIndex == 0 && preventTabChange)
            {
                tabControl1.SelectedIndex = 1;
            }
        }

        private void add_empl_FormClosing(object sender, FormClosingEventArgs e)
        {
            Index.Enabled = true;
            Index.Visible = true;

            Index.Index_Load(null, EventArgs.Empty);
        }

        private void LegajoNumeroInput_KeyPress(object sender, KeyPressEventArgs e)
        {
            UsuarioSingleton.SoloNumeros(e);
        }

        private void editLegajoNumeroInput_KeyPress(object sender, KeyPressEventArgs e)
        {
            UsuarioSingleton.SoloNumeros(e);
        }

        //textbox cuil.
        private void cuilInput1_KeyPress(object sender, KeyPressEventArgs e)
        {
            UsuarioSingleton.SoloNumeros(e);
        }

        private void cuilInput2_KeyPress(object sender, KeyPressEventArgs e)
        {
            UsuarioSingleton.SoloNumeros(e);
        }

        private void cuilInput3_KeyPress(object sender, KeyPressEventArgs e)
        {
            UsuarioSingleton.SoloNumeros(e);
        }


        #endregion

    }
}
