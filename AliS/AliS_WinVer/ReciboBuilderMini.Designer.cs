namespace AliS_WinVer
{
    partial class ReciboBuilderMini
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ReciboBuilderMini));
            this.dgvDetalle = new System.Windows.Forms.DataGridView();
            this.tbxCodigo = new System.Windows.Forms.TextBox();
            this.tbxDescripcion = new System.Windows.Forms.TextBox();
            this.lblCodigo = new System.Windows.Forms.Label();
            this.lblDescripcion = new System.Windows.Forms.Label();
            this.lblValor = new System.Windows.Forms.Label();
            this.tbxValor = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tbxPorcentaje = new System.Windows.Forms.TextBox();
            this.btnCalculadora = new System.Windows.Forms.Button();
            this.btnAgregar = new System.Windows.Forms.Button();
            this.optDeduccion = new System.Windows.Forms.RadioButton();
            this.optHabNoRem = new System.Windows.Forms.RadioButton();
            this.optHabRem = new System.Windows.Forms.RadioButton();
            this.lblTipo = new System.Windows.Forms.Label();
            this.lblDetalle = new System.Windows.Forms.Label();
            this.btnBorrar = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.lblLinea5 = new System.Windows.Forms.Label();
            this.tbxLinea5 = new System.Windows.Forms.TextBox();
            this.lblLinea4 = new System.Windows.Forms.Label();
            this.tbxLinea4 = new System.Windows.Forms.TextBox();
            this.lblLinea3 = new System.Windows.Forms.Label();
            this.tbxLinea3 = new System.Windows.Forms.TextBox();
            this.lblLinea2 = new System.Windows.Forms.Label();
            this.tbxLinea2 = new System.Windows.Forms.TextBox();
            this.lblLinea1 = new System.Windows.Forms.Label();
            this.tbxLinea1 = new System.Windows.Forms.TextBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.tbxConvenio = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.cboAño = new System.Windows.Forms.ComboBox();
            this.lblAño = new System.Windows.Forms.Label();
            this.cboQuincena = new System.Windows.Forms.ComboBox();
            this.lblQuincena = new System.Windows.Forms.Label();
            this.cboMes = new System.Windows.Forms.ComboBox();
            this.lblMes = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.tbxPuesto = new System.Windows.Forms.TextBox();
            this.lblRemTitle = new System.Windows.Forms.Label();
            this.lblRem = new System.Windows.Forms.Label();
            this.lblNoRem = new System.Windows.Forms.Label();
            this.lblNoRemTitle = new System.Windows.Forms.Label();
            this.lblDeducciones = new System.Windows.Forms.Label();
            this.lblDeduccionesTitle = new System.Windows.Forms.Label();
            this.lblNeto = new System.Windows.Forms.Label();
            this.lblNetoTitle = new System.Windows.Forms.Label();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.dtpFechaLiquidacion = new System.Windows.Forms.DateTimePicker();
            this.dtpFechaDeposito = new System.Windows.Forms.DateTimePicker();
            this.lblFechaDeposito = new System.Windows.Forms.Label();
            this.lblFechaLiquidacion = new System.Windows.Forms.Label();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.archivoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.btnNuevoMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.btnAbrirMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.btnGuardarMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.btnGuardarComoMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.btnImprimirMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.btnCerrarMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetalle)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvDetalle
            // 
            this.dgvDetalle.AllowUserToAddRows = false;
            this.dgvDetalle.AllowUserToDeleteRows = false;
            this.dgvDetalle.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDetalle.Location = new System.Drawing.Point(20, 334);
            this.dgvDetalle.Name = "dgvDetalle";
            this.dgvDetalle.ReadOnly = true;
            this.dgvDetalle.RowHeadersVisible = false;
            this.dgvDetalle.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvDetalle.Size = new System.Drawing.Size(518, 151);
            this.dgvDetalle.TabIndex = 17;
            this.dgvDetalle.TabStop = false;
            // 
            // tbxCodigo
            // 
            this.tbxCodigo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.tbxCodigo.Location = new System.Drawing.Point(26, 41);
            this.tbxCodigo.MaxLength = 8;
            this.tbxCodigo.Name = "tbxCodigo";
            this.tbxCodigo.Size = new System.Drawing.Size(60, 20);
            this.tbxCodigo.TabIndex = 7;
            // 
            // tbxDescripcion
            // 
            this.tbxDescripcion.Location = new System.Drawing.Point(92, 41);
            this.tbxDescripcion.MaxLength = 50;
            this.tbxDescripcion.Name = "tbxDescripcion";
            this.tbxDescripcion.Size = new System.Drawing.Size(168, 20);
            this.tbxDescripcion.TabIndex = 8;
            // 
            // lblCodigo
            // 
            this.lblCodigo.AutoSize = true;
            this.lblCodigo.Location = new System.Drawing.Point(26, 25);
            this.lblCodigo.Name = "lblCodigo";
            this.lblCodigo.Size = new System.Drawing.Size(40, 13);
            this.lblCodigo.TabIndex = 3;
            this.lblCodigo.Text = "Código";
            // 
            // lblDescripcion
            // 
            this.lblDescripcion.AutoSize = true;
            this.lblDescripcion.Location = new System.Drawing.Point(89, 25);
            this.lblDescripcion.Name = "lblDescripcion";
            this.lblDescripcion.Size = new System.Drawing.Size(63, 13);
            this.lblDescripcion.TabIndex = 4;
            this.lblDescripcion.Text = "Descripción";
            // 
            // lblValor
            // 
            this.lblValor.AutoSize = true;
            this.lblValor.Location = new System.Drawing.Point(343, 25);
            this.lblValor.Name = "lblValor";
            this.lblValor.Size = new System.Drawing.Size(31, 13);
            this.lblValor.TabIndex = 6;
            this.lblValor.Text = "Valor";
            // 
            // tbxValor
            // 
            this.tbxValor.Location = new System.Drawing.Point(346, 41);
            this.tbxValor.MaxLength = 20;
            this.tbxValor.Name = "tbxValor";
            this.tbxValor.Size = new System.Drawing.Size(101, 20);
            this.tbxValor.TabIndex = 9;
            this.tbxValor.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.value_KeyPress);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.tbxPorcentaje);
            this.groupBox1.Controls.Add(this.btnCalculadora);
            this.groupBox1.Controls.Add(this.btnAgregar);
            this.groupBox1.Controls.Add(this.optDeduccion);
            this.groupBox1.Controls.Add(this.optHabNoRem);
            this.groupBox1.Controls.Add(this.optHabRem);
            this.groupBox1.Controls.Add(this.lblTipo);
            this.groupBox1.Controls.Add(this.lblCodigo);
            this.groupBox1.Controls.Add(this.lblValor);
            this.groupBox1.Controls.Add(this.tbxCodigo);
            this.groupBox1.Controls.Add(this.tbxValor);
            this.groupBox1.Controls.Add(this.tbxDescripcion);
            this.groupBox1.Controls.Add(this.lblDescripcion);
            this.groupBox1.Location = new System.Drawing.Point(20, 142);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(518, 142);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Concepto";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(266, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(15, 13);
            this.label1.TabIndex = 16;
            this.label1.Text = "%";
            // 
            // tbxPorcentaje
            // 
            this.tbxPorcentaje.Location = new System.Drawing.Point(266, 41);
            this.tbxPorcentaje.Name = "tbxPorcentaje";
            this.tbxPorcentaje.Size = new System.Drawing.Size(74, 20);
            this.tbxPorcentaje.TabIndex = 9;
            this.tbxPorcentaje.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox1_KeyPress);
            // 
            // btnCalculadora
            // 
            this.btnCalculadora.Location = new System.Drawing.Point(453, 41);
            this.btnCalculadora.Name = "btnCalculadora";
            this.btnCalculadora.Size = new System.Drawing.Size(39, 22);
            this.btnCalculadora.TabIndex = 10;
            this.btnCalculadora.Text = "Cal";
            this.btnCalculadora.UseVisualStyleBackColor = true;
            this.btnCalculadora.Click += new System.EventHandler(this.btnCalculadora_Click);
            // 
            // btnAgregar
            // 
            this.btnAgregar.Image = ((System.Drawing.Image)(resources.GetObject("btnAgregar.Image")));
            this.btnAgregar.Location = new System.Drawing.Point(489, 113);
            this.btnAgregar.Name = "btnAgregar";
            this.btnAgregar.Size = new System.Drawing.Size(23, 23);
            this.btnAgregar.TabIndex = 14;
            this.btnAgregar.UseVisualStyleBackColor = true;
            this.btnAgregar.Click += new System.EventHandler(this.btnAgregarr_Click);
            // 
            // optDeduccion
            // 
            this.optDeduccion.AutoSize = true;
            this.optDeduccion.Location = new System.Drawing.Point(395, 78);
            this.optDeduccion.Name = "optDeduccion";
            this.optDeduccion.Size = new System.Drawing.Size(77, 17);
            this.optDeduccion.TabIndex = 13;
            this.optDeduccion.TabStop = true;
            this.optDeduccion.Text = "Deducción";
            this.optDeduccion.UseVisualStyleBackColor = true;
            // 
            // optHabNoRem
            // 
            this.optHabNoRem.AutoSize = true;
            this.optHabNoRem.Location = new System.Drawing.Point(242, 78);
            this.optHabNoRem.Name = "optHabNoRem";
            this.optHabNoRem.Size = new System.Drawing.Size(127, 17);
            this.optHabNoRem.TabIndex = 12;
            this.optHabNoRem.TabStop = true;
            this.optHabNoRem.Text = "Hab. no remunerativo";
            this.optHabNoRem.UseVisualStyleBackColor = true;
            // 
            // optHabRem
            // 
            this.optHabRem.AutoSize = true;
            this.optHabRem.Location = new System.Drawing.Point(110, 78);
            this.optHabRem.Name = "optHabRem";
            this.optHabRem.Size = new System.Drawing.Size(112, 17);
            this.optHabRem.TabIndex = 11;
            this.optHabRem.TabStop = true;
            this.optHabRem.Text = "Hab. remunerativo";
            this.optHabRem.UseVisualStyleBackColor = true;
            // 
            // lblTipo
            // 
            this.lblTipo.AutoSize = true;
            this.lblTipo.Location = new System.Drawing.Point(47, 80);
            this.lblTipo.Name = "lblTipo";
            this.lblTipo.Size = new System.Drawing.Size(31, 13);
            this.lblTipo.TabIndex = 7;
            this.lblTipo.Text = "Tipo:";
            // 
            // lblDetalle
            // 
            this.lblDetalle.AutoSize = true;
            this.lblDetalle.Location = new System.Drawing.Point(17, 314);
            this.lblDetalle.Name = "lblDetalle";
            this.lblDetalle.Size = new System.Drawing.Size(40, 13);
            this.lblDetalle.TabIndex = 8;
            this.lblDetalle.Text = "Detalle";
            // 
            // btnBorrar
            // 
            this.btnBorrar.Enabled = false;
            this.btnBorrar.Image = ((System.Drawing.Image)(resources.GetObject("btnBorrar.Image")));
            this.btnBorrar.Location = new System.Drawing.Point(515, 491);
            this.btnBorrar.Name = "btnBorrar";
            this.btnBorrar.Size = new System.Drawing.Size(23, 23);
            this.btnBorrar.TabIndex = 18;
            this.btnBorrar.UseVisualStyleBackColor = true;
            this.btnBorrar.Click += new System.EventHandler(this.btnBorrarr_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.lblLinea5);
            this.groupBox2.Controls.Add(this.tbxLinea5);
            this.groupBox2.Controls.Add(this.lblLinea4);
            this.groupBox2.Controls.Add(this.tbxLinea4);
            this.groupBox2.Controls.Add(this.lblLinea3);
            this.groupBox2.Controls.Add(this.tbxLinea3);
            this.groupBox2.Controls.Add(this.lblLinea2);
            this.groupBox2.Controls.Add(this.tbxLinea2);
            this.groupBox2.Controls.Add(this.lblLinea1);
            this.groupBox2.Controls.Add(this.tbxLinea1);
            this.groupBox2.Location = new System.Drawing.Point(20, 578);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(518, 221);
            this.groupBox2.TabIndex = 27;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Pie del recibo";
            // 
            // lblLinea5
            // 
            this.lblLinea5.AutoSize = true;
            this.lblLinea5.Location = new System.Drawing.Point(10, 183);
            this.lblLinea5.Name = "lblLinea5";
            this.lblLinea5.Size = new System.Drawing.Size(45, 13);
            this.lblLinea5.TabIndex = 9;
            this.lblLinea5.Text = "Linea 5:";
            // 
            // tbxLinea5
            // 
            this.tbxLinea5.Location = new System.Drawing.Point(61, 180);
            this.tbxLinea5.MaxLength = 140;
            this.tbxLinea5.Name = "tbxLinea5";
            this.tbxLinea5.Size = new System.Drawing.Size(422, 20);
            this.tbxLinea5.TabIndex = 23;
            // 
            // lblLinea4
            // 
            this.lblLinea4.AutoSize = true;
            this.lblLinea4.Location = new System.Drawing.Point(10, 142);
            this.lblLinea4.Name = "lblLinea4";
            this.lblLinea4.Size = new System.Drawing.Size(45, 13);
            this.lblLinea4.TabIndex = 7;
            this.lblLinea4.Text = "Linea 4:";
            // 
            // tbxLinea4
            // 
            this.tbxLinea4.Location = new System.Drawing.Point(61, 139);
            this.tbxLinea4.MaxLength = 140;
            this.tbxLinea4.Name = "tbxLinea4";
            this.tbxLinea4.Size = new System.Drawing.Size(422, 20);
            this.tbxLinea4.TabIndex = 22;
            // 
            // lblLinea3
            // 
            this.lblLinea3.AutoSize = true;
            this.lblLinea3.Location = new System.Drawing.Point(10, 106);
            this.lblLinea3.Name = "lblLinea3";
            this.lblLinea3.Size = new System.Drawing.Size(45, 13);
            this.lblLinea3.TabIndex = 5;
            this.lblLinea3.Text = "Linea 3:";
            // 
            // tbxLinea3
            // 
            this.tbxLinea3.Location = new System.Drawing.Point(61, 103);
            this.tbxLinea3.MaxLength = 140;
            this.tbxLinea3.Name = "tbxLinea3";
            this.tbxLinea3.Size = new System.Drawing.Size(422, 20);
            this.tbxLinea3.TabIndex = 21;
            // 
            // lblLinea2
            // 
            this.lblLinea2.AutoSize = true;
            this.lblLinea2.Location = new System.Drawing.Point(10, 70);
            this.lblLinea2.Name = "lblLinea2";
            this.lblLinea2.Size = new System.Drawing.Size(45, 13);
            this.lblLinea2.TabIndex = 3;
            this.lblLinea2.Text = "Linea 2:";
            // 
            // tbxLinea2
            // 
            this.tbxLinea2.Location = new System.Drawing.Point(61, 67);
            this.tbxLinea2.MaxLength = 140;
            this.tbxLinea2.Name = "tbxLinea2";
            this.tbxLinea2.Size = new System.Drawing.Size(422, 20);
            this.tbxLinea2.TabIndex = 20;
            // 
            // lblLinea1
            // 
            this.lblLinea1.AutoSize = true;
            this.lblLinea1.Location = new System.Drawing.Point(10, 33);
            this.lblLinea1.Name = "lblLinea1";
            this.lblLinea1.Size = new System.Drawing.Size(45, 13);
            this.lblLinea1.TabIndex = 1;
            this.lblLinea1.Text = "Linea 1:";
            // 
            // tbxLinea1
            // 
            this.tbxLinea1.Location = new System.Drawing.Point(61, 30);
            this.tbxLinea1.MaxLength = 140;
            this.tbxLinea1.Name = "tbxLinea1";
            this.tbxLinea1.Size = new System.Drawing.Size(422, 20);
            this.tbxLinea1.TabIndex = 19;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.tbxConvenio);
            this.groupBox3.Controls.Add(this.label15);
            this.groupBox3.Controls.Add(this.cboAño);
            this.groupBox3.Controls.Add(this.lblAño);
            this.groupBox3.Controls.Add(this.cboQuincena);
            this.groupBox3.Controls.Add(this.lblQuincena);
            this.groupBox3.Controls.Add(this.cboMes);
            this.groupBox3.Controls.Add(this.lblMes);
            this.groupBox3.Controls.Add(this.label11);
            this.groupBox3.Controls.Add(this.tbxPuesto);
            this.groupBox3.Location = new System.Drawing.Point(20, 45);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(518, 91);
            this.groupBox3.TabIndex = 0;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Cabecera";
            // 
            // tbxConvenio
            // 
            this.tbxConvenio.Location = new System.Drawing.Point(318, 58);
            this.tbxConvenio.MaxLength = 50;
            this.tbxConvenio.Name = "tbxConvenio";
            this.tbxConvenio.Size = new System.Drawing.Size(146, 20);
            this.tbxConvenio.TabIndex = 5;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(260, 61);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(52, 13);
            this.label15.TabIndex = 9;
            this.label15.Text = "Convenio";
            // 
            // cboAño
            // 
            this.cboAño.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboAño.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cboAño.FormattingEnabled = true;
            this.cboAño.Location = new System.Drawing.Point(381, 19);
            this.cboAño.Name = "cboAño";
            this.cboAño.Size = new System.Drawing.Size(83, 21);
            this.cboAño.TabIndex = 3;
            this.cboAño.SelectedIndexChanged += new System.EventHandler(this.cboAño_SelectedIndexChanged);
            // 
            // lblAño
            // 
            this.lblAño.AutoSize = true;
            this.lblAño.Location = new System.Drawing.Point(349, 22);
            this.lblAño.Name = "lblAño";
            this.lblAño.Size = new System.Drawing.Size(26, 13);
            this.lblAño.TabIndex = 7;
            this.lblAño.Text = "Año";
            // 
            // cboQuincena
            // 
            this.cboQuincena.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboQuincena.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cboQuincena.FormattingEnabled = true;
            this.cboQuincena.Items.AddRange(new object[] {
            "No especificar",
            "Primera",
            "Segunda"});
            this.cboQuincena.Location = new System.Drawing.Point(231, 19);
            this.cboQuincena.Name = "cboQuincena";
            this.cboQuincena.Size = new System.Drawing.Size(101, 21);
            this.cboQuincena.TabIndex = 2;
            // 
            // lblQuincena
            // 
            this.lblQuincena.AutoSize = true;
            this.lblQuincena.Location = new System.Drawing.Point(172, 22);
            this.lblQuincena.Name = "lblQuincena";
            this.lblQuincena.Size = new System.Drawing.Size(53, 13);
            this.lblQuincena.TabIndex = 5;
            this.lblQuincena.Text = "Quincena";
            // 
            // cboMes
            // 
            this.cboMes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboMes.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cboMes.FormattingEnabled = true;
            this.cboMes.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "10",
            "11",
            "12"});
            this.cboMes.Location = new System.Drawing.Point(110, 19);
            this.cboMes.Name = "cboMes";
            this.cboMes.Size = new System.Drawing.Size(48, 21);
            this.cboMes.TabIndex = 1;
            this.cboMes.SelectedIndexChanged += new System.EventHandler(this.cboMes_SelectedIndexChanged);
            // 
            // lblMes
            // 
            this.lblMes.AutoSize = true;
            this.lblMes.Location = new System.Drawing.Point(77, 22);
            this.lblMes.Name = "lblMes";
            this.lblMes.Size = new System.Drawing.Size(27, 13);
            this.lblMes.TabIndex = 3;
            this.lblMes.Text = "Mes";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(77, 61);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(40, 13);
            this.label11.TabIndex = 1;
            this.label11.Text = "Puesto";
            // 
            // tbxPuesto
            // 
            this.tbxPuesto.Location = new System.Drawing.Point(123, 58);
            this.tbxPuesto.MaxLength = 50;
            this.tbxPuesto.Name = "tbxPuesto";
            this.tbxPuesto.Size = new System.Drawing.Size(123, 20);
            this.tbxPuesto.TabIndex = 4;
            // 
            // lblRemTitle
            // 
            this.lblRemTitle.AutoSize = true;
            this.lblRemTitle.Location = new System.Drawing.Point(48, 24);
            this.lblRemTitle.Name = "lblRemTitle";
            this.lblRemTitle.Size = new System.Drawing.Size(36, 13);
            this.lblRemTitle.TabIndex = 13;
            this.lblRemTitle.Text = "RM: $";
            // 
            // lblRem
            // 
            this.lblRem.AutoSize = true;
            this.lblRem.Location = new System.Drawing.Point(83, 24);
            this.lblRem.Name = "lblRem";
            this.lblRem.Size = new System.Drawing.Size(25, 13);
            this.lblRem.TabIndex = 14;
            this.lblRem.Text = "------";
            // 
            // lblNoRem
            // 
            this.lblNoRem.AutoSize = true;
            this.lblNoRem.Location = new System.Drawing.Point(196, 24);
            this.lblNoRem.Name = "lblNoRem";
            this.lblNoRem.Size = new System.Drawing.Size(19, 13);
            this.lblNoRem.TabIndex = 16;
            this.lblNoRem.Text = "----";
            // 
            // lblNoRemTitle
            // 
            this.lblNoRemTitle.AutoSize = true;
            this.lblNoRemTitle.Location = new System.Drawing.Point(154, 24);
            this.lblNoRemTitle.Name = "lblNoRemTitle";
            this.lblNoRemTitle.Size = new System.Drawing.Size(44, 13);
            this.lblNoRemTitle.TabIndex = 15;
            this.lblNoRemTitle.Text = "NRM: $";
            // 
            // lblDeducciones
            // 
            this.lblDeducciones.AutoSize = true;
            this.lblDeducciones.Location = new System.Drawing.Point(312, 24);
            this.lblDeducciones.Name = "lblDeducciones";
            this.lblDeducciones.Size = new System.Drawing.Size(25, 13);
            this.lblDeducciones.TabIndex = 18;
            this.lblDeducciones.Text = "------";
            // 
            // lblDeduccionesTitle
            // 
            this.lblDeduccionesTitle.AutoSize = true;
            this.lblDeduccionesTitle.Location = new System.Drawing.Point(270, 24);
            this.lblDeduccionesTitle.Name = "lblDeduccionesTitle";
            this.lblDeduccionesTitle.Size = new System.Drawing.Size(42, 13);
            this.lblDeduccionesTitle.TabIndex = 17;
            this.lblDeduccionesTitle.Text = "DED: $";
            // 
            // lblNeto
            // 
            this.lblNeto.AutoSize = true;
            this.lblNeto.Location = new System.Drawing.Point(432, 24);
            this.lblNeto.Name = "lblNeto";
            this.lblNeto.Size = new System.Drawing.Size(25, 13);
            this.lblNeto.TabIndex = 20;
            this.lblNeto.Text = "------";
            // 
            // lblNetoTitle
            // 
            this.lblNetoTitle.AutoSize = true;
            this.lblNetoTitle.Location = new System.Drawing.Point(384, 24);
            this.lblNetoTitle.Name = "lblNetoTitle";
            this.lblNetoTitle.Size = new System.Drawing.Size(49, 13);
            this.lblNetoTitle.TabIndex = 19;
            this.lblNetoTitle.Text = "NETO: $";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.lblDeduccionesTitle);
            this.groupBox4.Controls.Add(this.lblNeto);
            this.groupBox4.Controls.Add(this.lblRemTitle);
            this.groupBox4.Controls.Add(this.lblNetoTitle);
            this.groupBox4.Controls.Add(this.lblRem);
            this.groupBox4.Controls.Add(this.lblDeducciones);
            this.groupBox4.Controls.Add(this.lblNoRemTitle);
            this.groupBox4.Controls.Add(this.lblNoRem);
            this.groupBox4.Location = new System.Drawing.Point(20, 520);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(518, 52);
            this.groupBox4.TabIndex = 26;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Totales";
            // 
            // dtpFechaLiquidacion
            // 
            this.dtpFechaLiquidacion.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFechaLiquidacion.Location = new System.Drawing.Point(262, 308);
            this.dtpFechaLiquidacion.Name = "dtpFechaLiquidacion";
            this.dtpFechaLiquidacion.Size = new System.Drawing.Size(97, 20);
            this.dtpFechaLiquidacion.TabIndex = 15;
            // 
            // dtpFechaDeposito
            // 
            this.dtpFechaDeposito.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFechaDeposito.Location = new System.Drawing.Point(441, 307);
            this.dtpFechaDeposito.Name = "dtpFechaDeposito";
            this.dtpFechaDeposito.Size = new System.Drawing.Size(97, 20);
            this.dtpFechaDeposito.TabIndex = 16;
            this.dtpFechaDeposito.ValueChanged += new System.EventHandler(this.dtpFechaDeposito_ValueChanged);
            // 
            // lblFechaDeposito
            // 
            this.lblFechaDeposito.AutoSize = true;
            this.lblFechaDeposito.Location = new System.Drawing.Point(376, 314);
            this.lblFechaDeposito.Name = "lblFechaDeposito";
            this.lblFechaDeposito.Size = new System.Drawing.Size(59, 13);
            this.lblFechaDeposito.TabIndex = 24;
            this.lblFechaDeposito.Text = "F. deposito";
            // 
            // lblFechaLiquidacion
            // 
            this.lblFechaLiquidacion.AutoSize = true;
            this.lblFechaLiquidacion.Location = new System.Drawing.Point(187, 314);
            this.lblFechaLiquidacion.Name = "lblFechaLiquidacion";
            this.lblFechaLiquidacion.Size = new System.Drawing.Size(69, 13);
            this.lblFechaLiquidacion.TabIndex = 25;
            this.lblFechaLiquidacion.Text = "F. liquidación";
            // 
            // saveFileDialog1
            // 
            this.saveFileDialog1.Filter = "Archivo XML | *.xml";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.archivoToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(555, 24);
            this.menuStrip1.TabIndex = 30;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // archivoToolStripMenuItem
            // 
            this.archivoToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnNuevoMenu,
            this.btnAbrirMenu,
            this.btnGuardarMenu,
            this.btnGuardarComoMenu,
            this.toolStripSeparator1,
            this.btnImprimirMenu,
            this.toolStripSeparator2,
            this.btnCerrarMenu});
            this.archivoToolStripMenuItem.Name = "archivoToolStripMenuItem";
            this.archivoToolStripMenuItem.Size = new System.Drawing.Size(60, 20);
            this.archivoToolStripMenuItem.Text = "Archivo";
            // 
            // btnNuevoMenu
            // 
            this.btnNuevoMenu.Name = "btnNuevoMenu";
            this.btnNuevoMenu.Size = new System.Drawing.Size(159, 22);
            this.btnNuevoMenu.Text = "Nuevo";
            this.btnNuevoMenu.Click += new System.EventHandler(this.btnNuevoMenu_Click);
            // 
            // btnAbrirMenu
            // 
            this.btnAbrirMenu.Name = "btnAbrirMenu";
            this.btnAbrirMenu.Size = new System.Drawing.Size(159, 22);
            this.btnAbrirMenu.Text = "Abrir";
            this.btnAbrirMenu.Click += new System.EventHandler(this.btnAbrirMenu_Click);
            // 
            // btnGuardarMenu
            // 
            this.btnGuardarMenu.Enabled = false;
            this.btnGuardarMenu.Name = "btnGuardarMenu";
            this.btnGuardarMenu.Size = new System.Drawing.Size(159, 22);
            this.btnGuardarMenu.Text = "Guardar";
            this.btnGuardarMenu.Click += new System.EventHandler(this.btnGuardarMenu_Click);
            // 
            // btnGuardarComoMenu
            // 
            this.btnGuardarComoMenu.Enabled = false;
            this.btnGuardarComoMenu.Name = "btnGuardarComoMenu";
            this.btnGuardarComoMenu.Size = new System.Drawing.Size(159, 22);
            this.btnGuardarComoMenu.Text = "Guardar como...";
            this.btnGuardarComoMenu.Click += new System.EventHandler(this.btnGuardarComoMenu_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(156, 6);
            // 
            // btnImprimirMenu
            // 
            this.btnImprimirMenu.Name = "btnImprimirMenu";
            this.btnImprimirMenu.Size = new System.Drawing.Size(159, 22);
            this.btnImprimirMenu.Text = "Imprimir";
            this.btnImprimirMenu.Click += new System.EventHandler(this.btnImprimirMenu_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(156, 6);
            // 
            // btnCerrarMenu
            // 
            this.btnCerrarMenu.Name = "btnCerrarMenu";
            this.btnCerrarMenu.Size = new System.Drawing.Size(159, 22);
            this.btnCerrarMenu.Text = "Cerrar";
            this.btnCerrarMenu.Click += new System.EventHandler(this.btnCerrarMenu_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // ReciboBuilderMini
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(555, 809);
            this.Controls.Add(this.lblFechaLiquidacion);
            this.Controls.Add(this.lblFechaDeposito);
            this.Controls.Add(this.dtpFechaDeposito);
            this.Controls.Add(this.dtpFechaLiquidacion);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.btnBorrar);
            this.Controls.Add(this.lblDetalle);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.dgvDetalle);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ReciboBuilderMini";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Liquidaciones extras";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ReciboBuilderMini_FormClosing);
            this.Load += new System.EventHandler(this.ReciboBuilderMini_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetalle)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvDetalle;
        private System.Windows.Forms.TextBox tbxCodigo;
        private System.Windows.Forms.TextBox tbxDescripcion;
        private System.Windows.Forms.Label lblCodigo;
        private System.Windows.Forms.Label lblDescripcion;
        private System.Windows.Forms.Label lblValor;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnAgregar;
        private System.Windows.Forms.RadioButton optDeduccion;
        private System.Windows.Forms.RadioButton optHabNoRem;
        private System.Windows.Forms.RadioButton optHabRem;
        private System.Windows.Forms.Label lblTipo;
        private System.Windows.Forms.Label lblDetalle;
        private System.Windows.Forms.Button btnBorrar;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label lblLinea4;
        private System.Windows.Forms.TextBox tbxLinea4;
        private System.Windows.Forms.Label lblLinea3;
        private System.Windows.Forms.TextBox tbxLinea3;
        private System.Windows.Forms.Label lblLinea2;
        private System.Windows.Forms.TextBox tbxLinea2;
        private System.Windows.Forms.Label lblLinea1;
        private System.Windows.Forms.TextBox tbxLinea1;
        private System.Windows.Forms.Label lblLinea5;
        private System.Windows.Forms.TextBox tbxLinea5;
        private System.Windows.Forms.Button btnCalculadora;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox tbxPuesto;
        private System.Windows.Forms.ComboBox cboAño;
        private System.Windows.Forms.Label lblAño;
        private System.Windows.Forms.ComboBox cboQuincena;
        private System.Windows.Forms.Label lblQuincena;
        private System.Windows.Forms.ComboBox cboMes;
        private System.Windows.Forms.Label lblMes;
        private System.Windows.Forms.TextBox tbxConvenio;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label lblRemTitle;
        private System.Windows.Forms.Label lblRem;
        private System.Windows.Forms.Label lblNoRem;
        private System.Windows.Forms.Label lblNoRemTitle;
        private System.Windows.Forms.Label lblDeducciones;
        private System.Windows.Forms.Label lblDeduccionesTitle;
        private System.Windows.Forms.Label lblNeto;
        private System.Windows.Forms.Label lblNetoTitle;
        private System.Windows.Forms.GroupBox groupBox4;
        public System.Windows.Forms.TextBox tbxValor;
        private System.Windows.Forms.DateTimePicker dtpFechaLiquidacion;
        private System.Windows.Forms.DateTimePicker dtpFechaDeposito;
        private System.Windows.Forms.Label lblFechaDeposito;
        private System.Windows.Forms.Label lblFechaLiquidacion;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem archivoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem btnNuevoMenu;
        private System.Windows.Forms.ToolStripMenuItem btnAbrirMenu;
        private System.Windows.Forms.ToolStripMenuItem btnGuardarMenu;
        private System.Windows.Forms.ToolStripMenuItem btnGuardarComoMenu;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem btnCerrarMenu;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.ToolStripMenuItem btnImprimirMenu;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbxPorcentaje;
    }
}