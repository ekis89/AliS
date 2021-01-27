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
using AliSlib;
using AliSLogica.Controladores;

namespace AliS_WinVer
{
    public partial class PrincipalPuestos : Form
    {
        private DataTable tablaPuestos;
        private Form Index;

        private Empresa _empresa;

        #region INICIO
        public PrincipalPuestos(Principal Index, Empresa empresa)
        {
            InitializeComponent();
            this.Index = Index;
            this._empresa = empresa;
        }

        //Carga la tabla de puestos.
        public void puestos_Load(object sender, EventArgs e)
        {
            this.Text = string.Format("{0}: Puestos", _empresa.NombreEmpresa);
            CargarPuestos();
        }
        #endregion

        #region BOTONES
        private void button1_Click(object sender, EventArgs e)
        {
            AñadirPuesto addPuesto = new AñadirPuesto(this, _empresa);

            this.Enabled = false;
            this.Visible = false;
            button1.Enabled = false;
            button2.Enabled = false;
            button3.Enabled = false;

            addPuesto.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string promptValue = EditPuesto.ShowDialog("Basico($):", "Modificar puesto:");
            int codigoPuesto = Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value);

            if (promptValue != "")
            {
                try
                {
                    string rta = ControladorPuesto.InsertarAcualizarPuesto(_empresa.codigoEmpresa, "", codigoPuesto,"",0, promptValue);

                    if (rta.Equals("ok")){
                        MessageBox.Show("¡El puesto ha sido actualizado!");

                        puestos_Load(null, EventArgs.Empty);
                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string descripcion = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            int codigoPuesto = Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value);
            //int index = dataGridView1.CurrentRow.Index;

            DialogResult confirm = MessageBox.Show("¿Esta seguro que desea eliminar el siguiente puesto?\n \n   " + descripcion, "Eliminar puesto:", MessageBoxButtons.YesNo);
            
            if (confirm == DialogResult.Yes)
            {

                try
                {

                    string rta = ControladorPuesto.EliminarPuestoPorCodigo(codigoPuesto);

                    if (rta.Equals("ok"))
                    {
                        CargarPuestos();

                        if (dataGridView1.Rows.Count < 1)
                        {
                            button2.Enabled = false;
                            button3.Enabled = false;
                        }

                        MessageBox.Show("¡El puesto ha sido eliminado!");
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

        #region EVENTOS
        private void dataGridView1_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            button2.Enabled = true;
            button3.Enabled = true;
        }

        private void puestos_FormClosing(object sender, FormClosingEventArgs e)
        {
            Index.Enabled = true;
            Index.Visible = true;

            if (Index.GetType() == typeof(Principal))
                (this.MdiParent as Principal).ActivarBotonesTS();
        }
        #endregion

        #region METODOS
        private void CargarPuestos()
        {
            tablaPuestos = ControladorPuesto.RecuperarPuestosPorEmpresa(_empresa.codigoEmpresa);

            // Modifica los tamaños de las celdas del dataGrid.
            dataGridView1.DataSource = tablaPuestos;
            dataGridView1.Columns[0].Visible = false;
            dataGridView1.Columns[1].Width = 106;
            dataGridView1.Columns[2].Width = 150;

            dataGridView1.ClearSelection();

            button2.Enabled = false;
            button3.Enabled = false;
        }
        #endregion
    }

    #region OTROS
    public class EditPuesto
    {
        public static string ShowDialog(string text, string caption)
        {
            //Crea una "ventana" (formulario).
            Form prompt = new Form()
            {
                Width = 250,
                Height = 150,
                FormBorderStyle = FormBorderStyle.FixedDialog,
                Text = caption,
                MaximizeBox = false,
                MinimizeBox = false,
                StartPosition = FormStartPosition.CenterScreen
            };

            //Crea los controles del formulario.
            Label textLabel = new Label() { Left = 30, Top = 32, Text = text, Width = 55 };
            TextBox textBox = new TextBox() { Left = 85, Top = 30, Width = 100, MaxLength = 20 };
            Button confirmation = new Button() { Text = "Aceptar", Left = 80, Width = 75, Top = 70, DialogResult = DialogResult.OK };
            confirmation.Click += (sender, e) => { prompt.Close(); };
            textBox.KeyPress += (sender, e) => { only_num(e); };
            //Agrega los controles al formulario.
            prompt.Controls.Add(textBox);
            prompt.Controls.Add(confirmation);
            prompt.Controls.Add(textLabel);
            prompt.AcceptButton = confirmation;

            return prompt.ShowDialog() == DialogResult.OK ? textBox.Text : "";
        }

        private static void only_num(KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '.' && e.KeyChar != ',')
            {
                e.Handled = true;
            }
        }
    }
    #endregion
}
