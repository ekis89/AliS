using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Xml;
using System.Windows.Forms;

namespace AliS_WinVer
{
    public partial class HistorialRecibos : Form
    {
        private XmlDocument customXML = new XmlDocument();

        public HistorialRecibos()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string curFile;
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                curFile = openFileDialog1.FileName;
                try
                {
                    customXML.Load(curFile);
                    MessageBox.Show("yeah! :D");
                }
                catch (Exception error)
                {
                    MessageBox.Show("Error: No es un archivo válido.");
                }
            }
        }
    }
}
