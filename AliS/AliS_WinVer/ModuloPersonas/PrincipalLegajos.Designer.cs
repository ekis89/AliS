namespace AliS_WinVer
{
    partial class PrincipalLegajos
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PrincipalLegajos));
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.txtConvenio = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.txtNumeroLegajo = new System.Windows.Forms.TextBox();
            this.LegajoLabel = new System.Windows.Forms.Label();
            this.txtBanco = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.dtFechaIngreso = new System.Windows.Forms.DateTimePicker();
            this.cboPuesto = new System.Windows.Forms.ComboBox();
            this.txtApellido = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dgvConceptos = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.txtCuil3 = new System.Windows.Forms.TextBox();
            this.txtCuil1 = new System.Windows.Forms.TextBox();
            this.createLegajo = new System.Windows.Forms.Button();
            this.txtCuil2 = new System.Windows.Forms.TextBox();
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.btnGuardarEdicion = new System.Windows.Forms.Button();
            this.txtBancoEditar = new System.Windows.Forms.TextBox();
            this.lblBancoEditar = new System.Windows.Forms.Label();
            this.dtpFechaIngresoEditar = new System.Windows.Forms.DateTimePicker();
            this.txtCuilEditar = new System.Windows.Forms.TextBox();
            this.txtConvenioEditar = new System.Windows.Forms.TextBox();
            this.lblFechaIngresoEditar = new System.Windows.Forms.Label();
            this.txtApellidoEditar = new System.Windows.Forms.TextBox();
            this.lblConvenioEditar = new System.Windows.Forms.Label();
            this.lblApellidoEditar = new System.Windows.Forms.Label();
            this.txtNombreEditar = new System.Windows.Forms.TextBox();
            this.txtNroLegajoEdit = new System.Windows.Forms.TextBox();
            this.cboPuestoEditar = new System.Windows.Forms.ComboBox();
            this.cboLegajo = new System.Windows.Forms.ComboBox();
            this.lblPuestoEditar = new System.Windows.Forms.Label();
            this.lblLegajo = new System.Windows.Forms.Label();
            this.gbConceptosEditar = new System.Windows.Forms.GroupBox();
            this.dgvConceptosEditar = new System.Windows.Forms.DataGridView();
            this.dataGridViewCheckBoxColumn1 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.lblCUIL = new System.Windows.Forms.Label();
            this.lblNroLegajoEdit = new System.Windows.Forms.Label();
            this.lblNombreEditar = new System.Windows.Forms.Label();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvConceptos)).BeginInit();
            this.tabPage2.SuspendLayout();
            this.gbConceptosEditar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvConceptosEditar)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(14, 5);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(743, 484);
            this.tabControl1.TabIndex = 41;
            this.tabControl1.Selecting += new System.Windows.Forms.TabControlCancelEventHandler(this.tabControl1_Selecting);
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.txtConvenio);
            this.tabPage1.Controls.Add(this.label13);
            this.tabPage1.Controls.Add(this.txtNumeroLegajo);
            this.tabPage1.Controls.Add(this.LegajoLabel);
            this.tabPage1.Controls.Add(this.txtBanco);
            this.tabPage1.Controls.Add(this.label8);
            this.tabPage1.Controls.Add(this.dtFechaIngreso);
            this.tabPage1.Controls.Add(this.cboPuesto);
            this.tabPage1.Controls.Add(this.txtApellido);
            this.tabPage1.Controls.Add(this.label4);
            this.tabPage1.Controls.Add(this.groupBox1);
            this.tabPage1.Controls.Add(this.txtCuil3);
            this.tabPage1.Controls.Add(this.txtCuil1);
            this.tabPage1.Controls.Add(this.createLegajo);
            this.tabPage1.Controls.Add(this.txtCuil2);
            this.tabPage1.Controls.Add(this.txtNombre);
            this.tabPage1.Controls.Add(this.label6);
            this.tabPage1.Controls.Add(this.label3);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(735, 458);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Nuevo legajo";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // txtConvenio
            // 
            this.txtConvenio.Location = new System.Drawing.Point(20, 284);
            this.txtConvenio.MaxLength = 50;
            this.txtConvenio.Name = "txtConvenio";
            this.txtConvenio.Size = new System.Drawing.Size(232, 20);
            this.txtConvenio.TabIndex = 8;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(17, 268);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(55, 13);
            this.label13.TabIndex = 63;
            this.label13.Text = "Convenio:";
            // 
            // txtNumeroLegajo
            // 
            this.txtNumeroLegajo.Location = new System.Drawing.Point(20, 38);
            this.txtNumeroLegajo.MaxLength = 5;
            this.txtNumeroLegajo.Name = "txtNumeroLegajo";
            this.txtNumeroLegajo.Size = new System.Drawing.Size(89, 20);
            this.txtNumeroLegajo.TabIndex = 1;
            this.txtNumeroLegajo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.LegajoNumeroInput_KeyPress);
            // 
            // LegajoLabel
            // 
            this.LegajoLabel.AutoSize = true;
            this.LegajoLabel.Location = new System.Drawing.Point(17, 22);
            this.LegajoLabel.Name = "LegajoLabel";
            this.LegajoLabel.Size = new System.Drawing.Size(97, 13);
            this.LegajoLabel.TabIndex = 62;
            this.LegajoLabel.Text = "Numero de Legajo:";
            // 
            // txtBanco
            // 
            this.txtBanco.Location = new System.Drawing.Point(20, 379);
            this.txtBanco.MaxLength = 50;
            this.txtBanco.Name = "txtBanco";
            this.txtBanco.Size = new System.Drawing.Size(232, 20);
            this.txtBanco.TabIndex = 10;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(17, 363);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(41, 13);
            this.label8.TabIndex = 59;
            this.label8.Text = "Banco:";
            // 
            // dtFechaIngreso
            // 
            this.dtFechaIngreso.CustomFormat = "";
            this.dtFechaIngreso.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtFechaIngreso.Location = new System.Drawing.Point(20, 333);
            this.dtFechaIngreso.Name = "dtFechaIngreso";
            this.dtFechaIngreso.Size = new System.Drawing.Size(232, 20);
            this.dtFechaIngreso.TabIndex = 9;
            // 
            // cboPuesto
            // 
            this.cboPuesto.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboPuesto.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cboPuesto.FormattingEnabled = true;
            this.cboPuesto.Items.AddRange(new object[] {
            "------------------"});
            this.cboPuesto.Location = new System.Drawing.Point(20, 234);
            this.cboPuesto.Name = "cboPuesto";
            this.cboPuesto.Size = new System.Drawing.Size(232, 21);
            this.cboPuesto.TabIndex = 7;
            // 
            // txtApellido
            // 
            this.txtApellido.Location = new System.Drawing.Point(20, 132);
            this.txtApellido.MaxLength = 50;
            this.txtApellido.Name = "txtApellido";
            this.txtApellido.Size = new System.Drawing.Size(232, 20);
            this.txtApellido.TabIndex = 3;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(17, 116);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(47, 13);
            this.label4.TabIndex = 56;
            this.label4.Text = "Apellido:";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dgvConceptos);
            this.groupBox1.Location = new System.Drawing.Point(282, 17);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(432, 389);
            this.groupBox1.TabIndex = 50;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Conceptos a liquidar";
            // 
            // dgvConceptos
            // 
            this.dgvConceptos.AllowUserToAddRows = false;
            this.dgvConceptos.AllowUserToDeleteRows = false;
            this.dgvConceptos.AllowUserToResizeColumns = false;
            this.dgvConceptos.AllowUserToResizeRows = false;
            this.dgvConceptos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvConceptos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1});
            this.dgvConceptos.Location = new System.Drawing.Point(13, 22);
            this.dgvConceptos.Name = "dgvConceptos";
            this.dgvConceptos.RowHeadersVisible = false;
            this.dgvConceptos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvConceptos.Size = new System.Drawing.Size(406, 345);
            this.dgvConceptos.TabIndex = 30;
            this.dgvConceptos.TabStop = false;
            this.dgvConceptos.DoubleClick += new System.EventHandler(this.dgvConceptos_DoubleClick);
            // 
            // Column1
            // 
            this.Column1.HeaderText = "";
            this.Column1.Name = "Column1";
            this.Column1.Width = 35;
            // 
            // txtCuil3
            // 
            this.txtCuil3.Location = new System.Drawing.Point(215, 184);
            this.txtCuil3.MaxLength = 3;
            this.txtCuil3.Name = "txtCuil3";
            this.txtCuil3.Size = new System.Drawing.Size(37, 20);
            this.txtCuil3.TabIndex = 6;
            this.txtCuil3.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cuilInput3_KeyPress);
            // 
            // txtCuil1
            // 
            this.txtCuil1.Location = new System.Drawing.Point(20, 184);
            this.txtCuil1.MaxLength = 3;
            this.txtCuil1.Name = "txtCuil1";
            this.txtCuil1.Size = new System.Drawing.Size(37, 20);
            this.txtCuil1.TabIndex = 4;
            this.txtCuil1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cuilInput1_KeyPress);
            // 
            // createLegajo
            // 
            this.createLegajo.Location = new System.Drawing.Point(630, 412);
            this.createLegajo.Name = "createLegajo";
            this.createLegajo.Size = new System.Drawing.Size(84, 23);
            this.createLegajo.TabIndex = 11;
            this.createLegajo.Text = "Crear Legajo";
            this.createLegajo.UseVisualStyleBackColor = true;
            this.createLegajo.Click += new System.EventHandler(this.createLegajo_Click);
            // 
            // txtCuil2
            // 
            this.txtCuil2.Location = new System.Drawing.Point(63, 184);
            this.txtCuil2.MaxLength = 10;
            this.txtCuil2.Name = "txtCuil2";
            this.txtCuil2.Size = new System.Drawing.Size(146, 20);
            this.txtCuil2.TabIndex = 5;
            this.txtCuil2.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cuilInput2_KeyPress);
            // 
            // txtNombre
            // 
            this.txtNombre.Location = new System.Drawing.Point(20, 85);
            this.txtNombre.MaxLength = 50;
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(232, 20);
            this.txtNombre.TabIndex = 2;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(17, 218);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(43, 13);
            this.label6.TabIndex = 54;
            this.label6.Text = "Puesto:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(17, 317);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(92, 13);
            this.label3.TabIndex = 53;
            this.label3.Text = "Fecha de ingreso:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(17, 168);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(43, 13);
            this.label2.TabIndex = 52;
            this.label2.Text = "C.U.I.L:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(17, 69);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 13);
            this.label1.TabIndex = 51;
            this.label1.Text = "Nombre:";
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.btnGuardarEdicion);
            this.tabPage2.Controls.Add(this.txtBancoEditar);
            this.tabPage2.Controls.Add(this.lblBancoEditar);
            this.tabPage2.Controls.Add(this.dtpFechaIngresoEditar);
            this.tabPage2.Controls.Add(this.txtCuilEditar);
            this.tabPage2.Controls.Add(this.txtConvenioEditar);
            this.tabPage2.Controls.Add(this.lblFechaIngresoEditar);
            this.tabPage2.Controls.Add(this.txtApellidoEditar);
            this.tabPage2.Controls.Add(this.lblConvenioEditar);
            this.tabPage2.Controls.Add(this.lblApellidoEditar);
            this.tabPage2.Controls.Add(this.txtNombreEditar);
            this.tabPage2.Controls.Add(this.txtNroLegajoEdit);
            this.tabPage2.Controls.Add(this.cboPuestoEditar);
            this.tabPage2.Controls.Add(this.cboLegajo);
            this.tabPage2.Controls.Add(this.lblPuestoEditar);
            this.tabPage2.Controls.Add(this.lblLegajo);
            this.tabPage2.Controls.Add(this.gbConceptosEditar);
            this.tabPage2.Controls.Add(this.lblCUIL);
            this.tabPage2.Controls.Add(this.lblNroLegajoEdit);
            this.tabPage2.Controls.Add(this.lblNombreEditar);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(735, 458);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Editar legajo";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // btnGuardarEdicion
            // 
            this.btnGuardarEdicion.Location = new System.Drawing.Point(616, 412);
            this.btnGuardarEdicion.Name = "btnGuardarEdicion";
            this.btnGuardarEdicion.Size = new System.Drawing.Size(98, 23);
            this.btnGuardarEdicion.TabIndex = 18;
            this.btnGuardarEdicion.Text = "Guardar edición";
            this.btnGuardarEdicion.UseVisualStyleBackColor = true;
            this.btnGuardarEdicion.Click += new System.EventHandler(this.btnGuardarEdicion_Click);
            // 
            // txtBancoEditar
            // 
            this.txtBancoEditar.Location = new System.Drawing.Point(20, 411);
            this.txtBancoEditar.MaxLength = 50;
            this.txtBancoEditar.Name = "txtBancoEditar";
            this.txtBancoEditar.Size = new System.Drawing.Size(232, 20);
            this.txtBancoEditar.TabIndex = 17;
            // 
            // lblBancoEditar
            // 
            this.lblBancoEditar.AutoSize = true;
            this.lblBancoEditar.Location = new System.Drawing.Point(19, 395);
            this.lblBancoEditar.Name = "lblBancoEditar";
            this.lblBancoEditar.Size = new System.Drawing.Size(41, 13);
            this.lblBancoEditar.TabIndex = 12;
            this.lblBancoEditar.Text = "Banco:";
            // 
            // dtpFechaIngresoEditar
            // 
            this.dtpFechaIngresoEditar.CustomFormat = "";
            this.dtpFechaIngresoEditar.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpFechaIngresoEditar.Location = new System.Drawing.Point(20, 364);
            this.dtpFechaIngresoEditar.Name = "dtpFechaIngresoEditar";
            this.dtpFechaIngresoEditar.Size = new System.Drawing.Size(232, 20);
            this.dtpFechaIngresoEditar.TabIndex = 16;
            // 
            // txtCuilEditar
            // 
            this.txtCuilEditar.Enabled = false;
            this.txtCuilEditar.Location = new System.Drawing.Point(20, 223);
            this.txtCuilEditar.MaxLength = 50;
            this.txtCuilEditar.Name = "txtCuilEditar";
            this.txtCuilEditar.Size = new System.Drawing.Size(232, 20);
            this.txtCuilEditar.TabIndex = 13;
            // 
            // txtConvenioEditar
            // 
            this.txtConvenioEditar.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.txtConvenioEditar.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.txtConvenioEditar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtConvenioEditar.Location = new System.Drawing.Point(20, 317);
            this.txtConvenioEditar.MaxLength = 50;
            this.txtConvenioEditar.Name = "txtConvenioEditar";
            this.txtConvenioEditar.Size = new System.Drawing.Size(232, 21);
            this.txtConvenioEditar.TabIndex = 15;
            // 
            // lblFechaIngresoEditar
            // 
            this.lblFechaIngresoEditar.AutoSize = true;
            this.lblFechaIngresoEditar.Location = new System.Drawing.Point(18, 348);
            this.lblFechaIngresoEditar.Name = "lblFechaIngresoEditar";
            this.lblFechaIngresoEditar.Size = new System.Drawing.Size(92, 13);
            this.lblFechaIngresoEditar.TabIndex = 10;
            this.lblFechaIngresoEditar.Text = "Fecha de ingreso:";
            // 
            // txtApellidoEditar
            // 
            this.txtApellidoEditar.Location = new System.Drawing.Point(20, 176);
            this.txtApellidoEditar.MaxLength = 50;
            this.txtApellidoEditar.Name = "txtApellidoEditar";
            this.txtApellidoEditar.Size = new System.Drawing.Size(232, 20);
            this.txtApellidoEditar.TabIndex = 12;
            // 
            // lblConvenioEditar
            // 
            this.lblConvenioEditar.AutoSize = true;
            this.lblConvenioEditar.Location = new System.Drawing.Point(17, 301);
            this.lblConvenioEditar.Name = "lblConvenioEditar";
            this.lblConvenioEditar.Size = new System.Drawing.Size(55, 13);
            this.lblConvenioEditar.TabIndex = 14;
            this.lblConvenioEditar.Text = "Convenio:";
            // 
            // lblApellidoEditar
            // 
            this.lblApellidoEditar.AutoSize = true;
            this.lblApellidoEditar.Location = new System.Drawing.Point(17, 160);
            this.lblApellidoEditar.Name = "lblApellidoEditar";
            this.lblApellidoEditar.Size = new System.Drawing.Size(47, 13);
            this.lblApellidoEditar.TabIndex = 11;
            this.lblApellidoEditar.Text = "Apellido:";
            // 
            // txtNombreEditar
            // 
            this.txtNombreEditar.Location = new System.Drawing.Point(20, 129);
            this.txtNombreEditar.MaxLength = 50;
            this.txtNombreEditar.Name = "txtNombreEditar";
            this.txtNombreEditar.Size = new System.Drawing.Size(232, 20);
            this.txtNombreEditar.TabIndex = 10;
            // 
            // txtNroLegajoEdit
            // 
            this.txtNroLegajoEdit.Location = new System.Drawing.Point(20, 82);
            this.txtNroLegajoEdit.MaxLength = 5;
            this.txtNroLegajoEdit.Name = "txtNroLegajoEdit";
            this.txtNroLegajoEdit.Size = new System.Drawing.Size(89, 20);
            this.txtNroLegajoEdit.TabIndex = 9;
            // 
            // cboPuestoEditar
            // 
            this.cboPuestoEditar.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboPuestoEditar.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cboPuestoEditar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboPuestoEditar.FormattingEnabled = true;
            this.cboPuestoEditar.Location = new System.Drawing.Point(20, 270);
            this.cboPuestoEditar.Name = "cboPuestoEditar";
            this.cboPuestoEditar.Size = new System.Drawing.Size(232, 23);
            this.cboPuestoEditar.TabIndex = 7;
            // 
            // cboLegajo
            // 
            this.cboLegajo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboLegajo.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cboLegajo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboLegajo.FormattingEnabled = true;
            this.cboLegajo.Location = new System.Drawing.Point(20, 35);
            this.cboLegajo.Name = "cboLegajo";
            this.cboLegajo.Size = new System.Drawing.Size(200, 23);
            this.cboLegajo.TabIndex = 8;
            this.cboLegajo.SelectedValueChanged += new System.EventHandler(this.cboLegajo_SelectedValueChanged);
            // 
            // lblPuestoEditar
            // 
            this.lblPuestoEditar.AutoSize = true;
            this.lblPuestoEditar.Location = new System.Drawing.Point(17, 254);
            this.lblPuestoEditar.Name = "lblPuestoEditar";
            this.lblPuestoEditar.Size = new System.Drawing.Size(43, 13);
            this.lblPuestoEditar.TabIndex = 6;
            this.lblPuestoEditar.Text = "Puesto:";
            // 
            // lblLegajo
            // 
            this.lblLegajo.AutoSize = true;
            this.lblLegajo.Location = new System.Drawing.Point(17, 19);
            this.lblLegajo.Name = "lblLegajo";
            this.lblLegajo.Size = new System.Drawing.Size(39, 13);
            this.lblLegajo.TabIndex = 5;
            this.lblLegajo.Text = "Legajo";
            // 
            // gbConceptosEditar
            // 
            this.gbConceptosEditar.Controls.Add(this.dgvConceptosEditar);
            this.gbConceptosEditar.Location = new System.Drawing.Point(282, 17);
            this.gbConceptosEditar.Name = "gbConceptosEditar";
            this.gbConceptosEditar.Size = new System.Drawing.Size(432, 389);
            this.gbConceptosEditar.TabIndex = 4;
            this.gbConceptosEditar.TabStop = false;
            this.gbConceptosEditar.Text = "Conceptos a liquidar";
            // 
            // dgvConceptosEditar
            // 
            this.dgvConceptosEditar.AllowUserToAddRows = false;
            this.dgvConceptosEditar.AllowUserToDeleteRows = false;
            this.dgvConceptosEditar.AllowUserToResizeColumns = false;
            this.dgvConceptosEditar.AllowUserToResizeRows = false;
            this.dgvConceptosEditar.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvConceptosEditar.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewCheckBoxColumn1});
            this.dgvConceptosEditar.Location = new System.Drawing.Point(13, 22);
            this.dgvConceptosEditar.Name = "dgvConceptosEditar";
            this.dgvConceptosEditar.RowHeadersVisible = false;
            this.dgvConceptosEditar.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvConceptosEditar.Size = new System.Drawing.Size(406, 345);
            this.dgvConceptosEditar.TabIndex = 31;
            this.dgvConceptosEditar.TabStop = false;
            this.dgvConceptosEditar.DoubleClick += new System.EventHandler(this.dgvConceptos_DoubleClick);
            // 
            // dataGridViewCheckBoxColumn1
            // 
            this.dataGridViewCheckBoxColumn1.HeaderText = "";
            this.dataGridViewCheckBoxColumn1.Name = "dataGridViewCheckBoxColumn1";
            this.dataGridViewCheckBoxColumn1.Width = 35;
            // 
            // lblCUIL
            // 
            this.lblCUIL.AutoSize = true;
            this.lblCUIL.Location = new System.Drawing.Point(17, 207);
            this.lblCUIL.Name = "lblCUIL";
            this.lblCUIL.Size = new System.Drawing.Size(43, 13);
            this.lblCUIL.TabIndex = 4;
            this.lblCUIL.Text = "C.U.I.L:";
            // 
            // lblNroLegajoEdit
            // 
            this.lblNroLegajoEdit.AutoSize = true;
            this.lblNroLegajoEdit.Location = new System.Drawing.Point(17, 66);
            this.lblNroLegajoEdit.Name = "lblNroLegajoEdit";
            this.lblNroLegajoEdit.Size = new System.Drawing.Size(93, 13);
            this.lblNroLegajoEdit.TabIndex = 0;
            this.lblNroLegajoEdit.Text = "Numero de legajo:";
            // 
            // lblNombreEditar
            // 
            this.lblNombreEditar.AutoSize = true;
            this.lblNombreEditar.Location = new System.Drawing.Point(17, 113);
            this.lblNombreEditar.Name = "lblNombreEditar";
            this.lblNombreEditar.Size = new System.Drawing.Size(47, 13);
            this.lblNombreEditar.TabIndex = 2;
            this.lblNombreEditar.Text = "Nombre:";
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "person.png");
            // 
            // PrincipalLegajos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(769, 501);
            this.Controls.Add(this.tabControl1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "PrincipalLegajos";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Legajos";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.add_empl_FormClosing);
            this.Load += new System.EventHandler(this.add_empl_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvConceptos)).EndInit();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.gbConceptosEditar.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvConceptosEditar)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TextBox txtNumeroLegajo;
        private System.Windows.Forms.Label LegajoLabel;
        private System.Windows.Forms.TextBox txtBanco;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.DateTimePicker dtFechaIngreso;
        private System.Windows.Forms.ComboBox cboPuesto;
        private System.Windows.Forms.TextBox txtApellido;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView dgvConceptos;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Column1;
        private System.Windows.Forms.TextBox txtCuil3;
        private System.Windows.Forms.TextBox txtCuil1;
        private System.Windows.Forms.Button createLegajo;
        private System.Windows.Forms.TextBox txtCuil2;
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Label lblLegajo;
        private System.Windows.Forms.TextBox txtConvenio;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.ComboBox cboLegajo;
        private System.Windows.Forms.GroupBox gbConceptosEditar;
        private System.Windows.Forms.TextBox txtConvenioEditar;
        private System.Windows.Forms.Label lblConvenioEditar;
        private System.Windows.Forms.Label lblBancoEditar;
        private System.Windows.Forms.Label lblFechaIngresoEditar;
        private System.Windows.Forms.ComboBox cboPuestoEditar;
        private System.Windows.Forms.Label lblPuestoEditar;
        private System.Windows.Forms.Label lblCUIL;
        private System.Windows.Forms.Label lblNombreEditar;
        private System.Windows.Forms.Label lblNroLegajoEdit;
        private System.Windows.Forms.TextBox txtNroLegajoEdit;
        private System.Windows.Forms.TextBox txtNombreEditar;
        private System.Windows.Forms.TextBox txtApellidoEditar;
        private System.Windows.Forms.Label lblApellidoEditar;
        private System.Windows.Forms.TextBox txtCuilEditar;
        private System.Windows.Forms.DateTimePicker dtpFechaIngresoEditar;
        private System.Windows.Forms.TextBox txtBancoEditar;
        private System.Windows.Forms.Button btnGuardarEdicion;
        private System.Windows.Forms.DataGridView dgvConceptosEditar;
        private System.Windows.Forms.DataGridViewCheckBoxColumn dataGridViewCheckBoxColumn1;
    }
}