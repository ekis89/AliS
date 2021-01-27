using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Microsoft.Reporting.WinForms;
using AliSDatos.Clases;

namespace AliS_WinVer
{
    public partial class ImprimirRecibo : Form
    {
        PrincipalLiquidaciones screenReciboBuilder;
        ReciboBuilderMini screenRBMini;
        public List<CabeceraRecibo> EncabezadoList = new List<CabeceraRecibo>();
        public List<AliSDatos.Clases.Concepto> ConcepList = new List<AliSDatos.Clases.Concepto>();
        public List<PieRecibo> FooterList = new List<PieRecibo>();

        private string _titulo;

        public ImprimirRecibo(PrincipalLiquidaciones screenReciboBuilder, string titulo = "")
        {
            InitializeComponent();
            this.screenReciboBuilder = screenReciboBuilder;
            this._titulo = titulo;

        }

        public ImprimirRecibo(ReciboBuilderMini screenRBMini, string titulo = "")
        {
            InitializeComponent();
            this.screenRBMini = screenRBMini;
            this._titulo = titulo;

        }

        private void ReciboPrinter_Load(object sender, EventArgs e)
        {
            this.Text = _titulo;

            reportViewer1.SetDisplayMode(DisplayMode.PrintLayout);
            reportViewer1.LocalReport.DataSources.Clear();

            reportViewer1.LocalReport.DataSources.Add(new ReportDataSource("Cabecera", EncabezadoList));
            reportViewer1.LocalReport.DataSources.Add(new ReportDataSource("Detalle", ConcepList));
            reportViewer1.LocalReport.DataSources.Add(new ReportDataSource("Pie", FooterList));

            this.reportViewer1.RefreshReport();
        }

        private void ReciboPrinter_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (screenReciboBuilder != null)
            {
                screenReciboBuilder.Visible = true;
            }
            if (screenRBMini != null)
            {
                screenRBMini.Visible = true;
            }
        }
    }
}
