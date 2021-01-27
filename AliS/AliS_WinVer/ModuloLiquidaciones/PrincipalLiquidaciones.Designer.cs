namespace AliS_WinVer
{
    partial class PrincipalLiquidaciones
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PrincipalLiquidaciones));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.archivoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mnubtnCerrar = new System.Windows.Forms.ToolStripMenuItem();
            this.herramientasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mnubtnRBMini = new System.Windows.Forms.ToolStripMenuItem();
            this.dgvDetallesRecibo = new System.Windows.Forms.DataGridView();
            this.lblHaberesRem = new System.Windows.Forms.Label();
            this.lblHaberesNoRem = new System.Windows.Forms.Label();
            this.lblDeduccion = new System.Windows.Forms.Label();
            this.lblNeto = new System.Windows.Forms.Label();
            this.lblCUIL = new System.Windows.Forms.Label();
            this.lblFechaIngreso = new System.Windows.Forms.Label();
            this.lblNombre = new System.Windows.Forms.Label();
            this.lblOcupacion = new System.Windows.Forms.Label();
            this.lblDetalle = new System.Windows.Forms.Label();
            this.lblHaberesRemInfo = new System.Windows.Forms.Label();
            this.lblHaberesNoRemInfo = new System.Windows.Forms.Label();
            this.lblDeduccionInfo = new System.Windows.Forms.Label();
            this.lblNetoInfo = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnLiquidar = new System.Windows.Forms.Button();
            this.cboQuincena = new System.Windows.Forms.ComboBox();
            this.lblQuincena = new System.Windows.Forms.Label();
            this.lblAño = new System.Windows.Forms.Label();
            this.lblMes = new System.Windows.Forms.Label();
            this.cboAño = new System.Windows.Forms.ComboBox();
            this.cboMes = new System.Windows.Forms.ComboBox();
            this.btnEditar = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lblFechaDepositoInfo = new System.Windows.Forms.Label();
            this.lblFechaLiquidacionInfo = new System.Windows.Forms.Label();
            this.lblTipoSalarioInfo = new System.Windows.Forms.Label();
            this.lblLegajoNumInfo = new System.Windows.Forms.Label();
            this.lblTipoSalario = new System.Windows.Forms.Label();
            this.lblLegajoNumero = new System.Windows.Forms.Label();
            this.lblFechaLiquidacion = new System.Windows.Forms.Label();
            this.lblFechaDeposito = new System.Windows.Forms.Label();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.btnImprimir = new System.Windows.Forms.Button();
            this.lblFechaIngresoInfo = new System.Windows.Forms.Label();
            this.lblOcupacionInfo = new System.Windows.Forms.Label();
            this.lblCUILInfo = new System.Windows.Forms.Label();
            this.nombre = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetallesRecibo)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "person.png");
            // 
            // menuStrip1
            // 
            this.menuStrip1.AllowMerge = false;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.archivoToolStripMenuItem,
            this.herramientasToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(629, 24);
            this.menuStrip1.TabIndex = 4;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // archivoToolStripMenuItem
            // 
            this.archivoToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnubtnCerrar});
            this.archivoToolStripMenuItem.Name = "archivoToolStripMenuItem";
            this.archivoToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.N)));
            this.archivoToolStripMenuItem.Size = new System.Drawing.Size(60, 20);
            this.archivoToolStripMenuItem.Text = "Archivo";
            // 
            // mnubtnCerrar
            // 
            this.mnubtnCerrar.Name = "mnubtnCerrar";
            this.mnubtnCerrar.Size = new System.Drawing.Size(106, 22);
            this.mnubtnCerrar.Text = "Cerrar";
            this.mnubtnCerrar.Click += new System.EventHandler(this.mnubtnCerrar_Click);
            // 
            // herramientasToolStripMenuItem
            // 
            this.herramientasToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnubtnRBMini});
            this.herramientasToolStripMenuItem.Name = "herramientasToolStripMenuItem";
            this.herramientasToolStripMenuItem.Size = new System.Drawing.Size(90, 20);
            this.herramientasToolStripMenuItem.Text = "Herramientas";
            // 
            // mnubtnRBMini
            // 
            this.mnubtnRBMini.Name = "mnubtnRBMini";
            this.mnubtnRBMini.Size = new System.Drawing.Size(181, 22);
            this.mnubtnRBMini.Text = "Liquidaciones extras";
            this.mnubtnRBMini.Click += new System.EventHandler(this.mnubtnRBMini_Click);
            // 
            // dgvDetallesRecibo
            // 
            this.dgvDetallesRecibo.AllowUserToAddRows = false;
            this.dgvDetallesRecibo.AllowUserToDeleteRows = false;
            this.dgvDetallesRecibo.AllowUserToResizeColumns = false;
            this.dgvDetallesRecibo.AllowUserToResizeRows = false;
            this.dgvDetallesRecibo.BackgroundColor = System.Drawing.SystemColors.ActiveCaption;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvDetallesRecibo.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvDetallesRecibo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.ButtonHighlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvDetallesRecibo.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvDetallesRecibo.Location = new System.Drawing.Point(17, 264);
            this.dgvDetallesRecibo.MultiSelect = false;
            this.dgvDetallesRecibo.Name = "dgvDetallesRecibo";
            this.dgvDetallesRecibo.ReadOnly = true;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvDetallesRecibo.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvDetallesRecibo.RowHeadersVisible = false;
            this.dgvDetallesRecibo.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dgvDetallesRecibo.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvDetallesRecibo.Size = new System.Drawing.Size(575, 235);
            this.dgvDetallesRecibo.TabIndex = 15;
            // 
            // lblHaberesRem
            // 
            this.lblHaberesRem.AutoSize = true;
            this.lblHaberesRem.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHaberesRem.Location = new System.Drawing.Point(35, 25);
            this.lblHaberesRem.Name = "lblHaberesRem";
            this.lblHaberesRem.Size = new System.Drawing.Size(141, 13);
            this.lblHaberesRem.TabIndex = 23;
            this.lblHaberesRem.Text = "Haberes remunerativos:";
            // 
            // lblHaberesNoRem
            // 
            this.lblHaberesNoRem.AutoSize = true;
            this.lblHaberesNoRem.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHaberesNoRem.Location = new System.Drawing.Point(35, 45);
            this.lblHaberesNoRem.Name = "lblHaberesNoRem";
            this.lblHaberesNoRem.Size = new System.Drawing.Size(159, 13);
            this.lblHaberesNoRem.TabIndex = 24;
            this.lblHaberesNoRem.Text = "Haberes no remunerativos:";
            // 
            // lblDeduccion
            // 
            this.lblDeduccion.AutoSize = true;
            this.lblDeduccion.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDeduccion.Location = new System.Drawing.Point(35, 65);
            this.lblDeduccion.Name = "lblDeduccion";
            this.lblDeduccion.Size = new System.Drawing.Size(85, 13);
            this.lblDeduccion.TabIndex = 25;
            this.lblDeduccion.Text = "Deducciones:";
            // 
            // lblNeto
            // 
            this.lblNeto.AutoSize = true;
            this.lblNeto.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNeto.Location = new System.Drawing.Point(187, 88);
            this.lblNeto.Name = "lblNeto";
            this.lblNeto.Size = new System.Drawing.Size(34, 13);
            this.lblNeto.TabIndex = 26;
            this.lblNeto.Text = "Neto";
            // 
            // lblCUIL
            // 
            this.lblCUIL.AutoSize = true;
            this.lblCUIL.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCUIL.Location = new System.Drawing.Point(467, 119);
            this.lblCUIL.Name = "lblCUIL";
            this.lblCUIL.Size = new System.Drawing.Size(51, 13);
            this.lblCUIL.TabIndex = 7;
            this.lblCUIL.Text = "C.U.I.L:";
            // 
            // lblFechaIngreso
            // 
            this.lblFechaIngreso.AutoSize = true;
            this.lblFechaIngreso.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFechaIngreso.Location = new System.Drawing.Point(241, 171);
            this.lblFechaIngreso.Name = "lblFechaIngreso";
            this.lblFechaIngreso.Size = new System.Drawing.Size(109, 13);
            this.lblFechaIngreso.TabIndex = 9;
            this.lblFechaIngreso.Text = "Fecha de ingreso:";
            // 
            // lblNombre
            // 
            this.lblNombre.AutoSize = true;
            this.lblNombre.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNombre.Location = new System.Drawing.Point(241, 119);
            this.lblNombre.Name = "lblNombre";
            this.lblNombre.Size = new System.Drawing.Size(112, 13);
            this.lblNombre.TabIndex = 6;
            this.lblNombre.Text = "Nombre y apellido:";
            // 
            // lblOcupacion
            // 
            this.lblOcupacion.AutoSize = true;
            this.lblOcupacion.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOcupacion.Location = new System.Drawing.Point(16, 171);
            this.lblOcupacion.Name = "lblOcupacion";
            this.lblOcupacion.Size = new System.Drawing.Size(72, 13);
            this.lblOcupacion.TabIndex = 8;
            this.lblOcupacion.Text = "Ocupación:";
            // 
            // lblDetalle
            // 
            this.lblDetalle.AutoSize = true;
            this.lblDetalle.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDetalle.Location = new System.Drawing.Point(16, 240);
            this.lblDetalle.Name = "lblDetalle";
            this.lblDetalle.Size = new System.Drawing.Size(51, 13);
            this.lblDetalle.TabIndex = 17;
            this.lblDetalle.Text = "Detalle:";
            // 
            // lblHaberesRemInfo
            // 
            this.lblHaberesRemInfo.AutoSize = true;
            this.lblHaberesRemInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHaberesRemInfo.Location = new System.Drawing.Point(182, 25);
            this.lblHaberesRemInfo.Name = "lblHaberesRemInfo";
            this.lblHaberesRemInfo.Size = new System.Drawing.Size(40, 13);
            this.lblHaberesRemInfo.TabIndex = 28;
            this.lblHaberesRemInfo.Text = "$00.00";
            // 
            // lblHaberesNoRemInfo
            // 
            this.lblHaberesNoRemInfo.AutoSize = true;
            this.lblHaberesNoRemInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHaberesNoRemInfo.Location = new System.Drawing.Point(200, 45);
            this.lblHaberesNoRemInfo.Name = "lblHaberesNoRemInfo";
            this.lblHaberesNoRemInfo.Size = new System.Drawing.Size(40, 13);
            this.lblHaberesNoRemInfo.TabIndex = 29;
            this.lblHaberesNoRemInfo.Text = "$00.00";
            // 
            // lblDeduccionInfo
            // 
            this.lblDeduccionInfo.AutoSize = true;
            this.lblDeduccionInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDeduccionInfo.Location = new System.Drawing.Point(126, 65);
            this.lblDeduccionInfo.Name = "lblDeduccionInfo";
            this.lblDeduccionInfo.Size = new System.Drawing.Size(40, 13);
            this.lblDeduccionInfo.TabIndex = 30;
            this.lblDeduccionInfo.Text = "$00.00";
            // 
            // lblNetoInfo
            // 
            this.lblNetoInfo.AutoSize = true;
            this.lblNetoInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNetoInfo.Location = new System.Drawing.Point(223, 88);
            this.lblNetoInfo.Name = "lblNetoInfo";
            this.lblNetoInfo.Size = new System.Drawing.Size(40, 13);
            this.lblNetoInfo.TabIndex = 31;
            this.lblNetoInfo.Text = "$00.00";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnLiquidar);
            this.groupBox2.Controls.Add(this.cboQuincena);
            this.groupBox2.Controls.Add(this.lblQuincena);
            this.groupBox2.Controls.Add(this.lblAño);
            this.groupBox2.Controls.Add(this.lblMes);
            this.groupBox2.Controls.Add(this.cboAño);
            this.groupBox2.Controls.Add(this.cboMes);
            this.groupBox2.Controls.Add(this.btnEditar);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(16, 19);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(575, 82);
            this.groupBox2.TabIndex = 34;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Período:";
            // 
            // btnLiquidar
            // 
            this.btnLiquidar.Enabled = false;
            this.btnLiquidar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLiquidar.Location = new System.Drawing.Point(490, 53);
            this.btnLiquidar.Name = "btnLiquidar";
            this.btnLiquidar.Size = new System.Drawing.Size(75, 23);
            this.btnLiquidar.TabIndex = 38;
            this.btnLiquidar.Text = "Liquidar";
            this.btnLiquidar.UseVisualStyleBackColor = true;
            this.btnLiquidar.Visible = false;
            this.btnLiquidar.Click += new System.EventHandler(this.btnLiquidar_Click);
            // 
            // cboQuincena
            // 
            this.cboQuincena.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboQuincena.Enabled = false;
            this.cboQuincena.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cboQuincena.FormattingEnabled = true;
            this.cboQuincena.Items.AddRange(new object[] {
            "Primera",
            "Segunda"});
            this.cboQuincena.Location = new System.Drawing.Point(356, 18);
            this.cboQuincena.Name = "cboQuincena";
            this.cboQuincena.Size = new System.Drawing.Size(79, 23);
            this.cboQuincena.TabIndex = 37;
            this.cboQuincena.SelectedIndexChanged += new System.EventHandler(this.cboQuincena_SelectedIndexChanged);
            // 
            // lblQuincena
            // 
            this.lblQuincena.AutoSize = true;
            this.lblQuincena.Location = new System.Drawing.Point(278, 21);
            this.lblQuincena.Name = "lblQuincena";
            this.lblQuincena.Size = new System.Drawing.Size(72, 15);
            this.lblQuincena.TabIndex = 36;
            this.lblQuincena.Text = "Quincena:";
            // 
            // lblAño
            // 
            this.lblAño.AutoSize = true;
            this.lblAño.Location = new System.Drawing.Point(451, 21);
            this.lblAño.Name = "lblAño";
            this.lblAño.Size = new System.Drawing.Size(35, 15);
            this.lblAño.TabIndex = 35;
            this.lblAño.Text = "Año:";
            // 
            // lblMes
            // 
            this.lblMes.AutoSize = true;
            this.lblMes.Location = new System.Drawing.Point(168, 21);
            this.lblMes.Name = "lblMes";
            this.lblMes.Size = new System.Drawing.Size(38, 15);
            this.lblMes.TabIndex = 34;
            this.lblMes.Text = "Mes:";
            // 
            // cboAño
            // 
            this.cboAño.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboAño.Enabled = false;
            this.cboAño.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cboAño.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboAño.FormattingEnabled = true;
            this.cboAño.Location = new System.Drawing.Point(486, 18);
            this.cboAño.Name = "cboAño";
            this.cboAño.Size = new System.Drawing.Size(80, 21);
            this.cboAño.TabIndex = 33;
            this.cboAño.SelectedIndexChanged += new System.EventHandler(this.cboAño_SelectedIndexChanged);
            // 
            // cboMes
            // 
            this.cboMes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboMes.Enabled = false;
            this.cboMes.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cboMes.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
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
            this.cboMes.Location = new System.Drawing.Point(210, 18);
            this.cboMes.Name = "cboMes";
            this.cboMes.Size = new System.Drawing.Size(52, 21);
            this.cboMes.TabIndex = 32;
            this.cboMes.SelectedIndexChanged += new System.EventHandler(this.cboMes_SelectedIndexChanged);
            // 
            // btnEditar
            // 
            this.btnEditar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEditar.Location = new System.Drawing.Point(491, 53);
            this.btnEditar.Name = "btnEditar";
            this.btnEditar.Size = new System.Drawing.Size(75, 23);
            this.btnEditar.TabIndex = 39;
            this.btnEditar.Text = "Editar";
            this.btnEditar.UseVisualStyleBackColor = true;
            this.btnEditar.Visible = false;
            this.btnEditar.Click += new System.EventHandler(this.btnEditar_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lblFechaDepositoInfo);
            this.groupBox1.Controls.Add(this.lblFechaLiquidacionInfo);
            this.groupBox1.Controls.Add(this.lblTipoSalarioInfo);
            this.groupBox1.Controls.Add(this.lblLegajoNumInfo);
            this.groupBox1.Controls.Add(this.lblTipoSalario);
            this.groupBox1.Controls.Add(this.lblLegajoNumero);
            this.groupBox1.Controls.Add(this.lblFechaLiquidacion);
            this.groupBox1.Controls.Add(this.lblFechaDeposito);
            this.groupBox1.Controls.Add(this.groupBox4);
            this.groupBox1.Controls.Add(this.groupBox3);
            this.groupBox1.Controls.Add(this.lblFechaIngresoInfo);
            this.groupBox1.Controls.Add(this.lblOcupacionInfo);
            this.groupBox1.Controls.Add(this.lblCUILInfo);
            this.groupBox1.Controls.Add(this.nombre);
            this.groupBox1.Controls.Add(this.groupBox2);
            this.groupBox1.Controls.Add(this.lblDetalle);
            this.groupBox1.Controls.Add(this.lblOcupacion);
            this.groupBox1.Controls.Add(this.lblNombre);
            this.groupBox1.Controls.Add(this.lblFechaIngreso);
            this.groupBox1.Controls.Add(this.lblCUIL);
            this.groupBox1.Controls.Add(this.dgvDetallesRecibo);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(11, 27);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(607, 642);
            this.groupBox1.TabIndex = 27;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Perfil de empleado:";
            this.groupBox1.Visible = false;
            // 
            // lblFechaDepositoInfo
            // 
            this.lblFechaDepositoInfo.AutoSize = true;
            this.lblFechaDepositoInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFechaDepositoInfo.Location = new System.Drawing.Point(494, 240);
            this.lblFechaDepositoInfo.Name = "lblFechaDepositoInfo";
            this.lblFechaDepositoInfo.Size = new System.Drawing.Size(51, 13);
            this.lblFechaDepositoInfo.TabIndex = 55;
            this.lblFechaDepositoInfo.Text = "--/--/----";
            // 
            // lblFechaLiquidacionInfo
            // 
            this.lblFechaLiquidacionInfo.AutoSize = true;
            this.lblFechaLiquidacionInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFechaLiquidacionInfo.Location = new System.Drawing.Point(264, 240);
            this.lblFechaLiquidacionInfo.Name = "lblFechaLiquidacionInfo";
            this.lblFechaLiquidacionInfo.Size = new System.Drawing.Size(51, 13);
            this.lblFechaLiquidacionInfo.TabIndex = 54;
            this.lblFechaLiquidacionInfo.Text = "--/--/----";
            // 
            // lblTipoSalarioInfo
            // 
            this.lblTipoSalarioInfo.AutoSize = true;
            this.lblTipoSalarioInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTipoSalarioInfo.Location = new System.Drawing.Point(467, 187);
            this.lblTipoSalarioInfo.Name = "lblTipoSalarioInfo";
            this.lblTipoSalarioInfo.Size = new System.Drawing.Size(125, 17);
            this.lblTipoSalarioInfo.TabIndex = 53;
            this.lblTipoSalarioInfo.Text = "- - - - - - - - - - - - - ";
            // 
            // lblLegajoNumInfo
            // 
            this.lblLegajoNumInfo.AutoSize = true;
            this.lblLegajoNumInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLegajoNumInfo.Location = new System.Drawing.Point(14, 135);
            this.lblLegajoNumInfo.Name = "lblLegajoNumInfo";
            this.lblLegajoNumInfo.Size = new System.Drawing.Size(125, 17);
            this.lblLegajoNumInfo.TabIndex = 52;
            this.lblLegajoNumInfo.Text = "- - - - - - - - - - - - - ";
            // 
            // lblTipoSalario
            // 
            this.lblTipoSalario.AutoSize = true;
            this.lblTipoSalario.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTipoSalario.Location = new System.Drawing.Point(467, 171);
            this.lblTipoSalario.Name = "lblTipoSalario";
            this.lblTipoSalario.Size = new System.Drawing.Size(95, 13);
            this.lblTipoSalario.TabIndex = 51;
            this.lblTipoSalario.Text = "Tipo de salario:";
            // 
            // lblLegajoNumero
            // 
            this.lblLegajoNumero.AutoSize = true;
            this.lblLegajoNumero.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLegajoNumero.Location = new System.Drawing.Point(14, 119);
            this.lblLegajoNumero.Name = "lblLegajoNumero";
            this.lblLegajoNumero.Size = new System.Drawing.Size(67, 13);
            this.lblLegajoNumero.TabIndex = 50;
            this.lblLegajoNumero.Text = "Legajo Nº:";
            // 
            // lblFechaLiquidacion
            // 
            this.lblFechaLiquidacion.AutoSize = true;
            this.lblFechaLiquidacion.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFechaLiquidacion.Location = new System.Drawing.Point(129, 240);
            this.lblFechaLiquidacion.Name = "lblFechaLiquidacion";
            this.lblFechaLiquidacion.Size = new System.Drawing.Size(129, 13);
            this.lblFechaLiquidacion.TabIndex = 48;
            this.lblFechaLiquidacion.Text = "Fecha de liquidación:";
            // 
            // lblFechaDeposito
            // 
            this.lblFechaDeposito.AutoSize = true;
            this.lblFechaDeposito.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFechaDeposito.Location = new System.Drawing.Point(372, 240);
            this.lblFechaDeposito.Name = "lblFechaDeposito";
            this.lblFechaDeposito.Size = new System.Drawing.Size(116, 13);
            this.lblFechaDeposito.TabIndex = 46;
            this.lblFechaDeposito.Text = "Fecha de deposito:";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.lblHaberesRem);
            this.groupBox4.Controls.Add(this.lblHaberesRemInfo);
            this.groupBox4.Controls.Add(this.lblNetoInfo);
            this.groupBox4.Controls.Add(this.lblHaberesNoRem);
            this.groupBox4.Controls.Add(this.lblNeto);
            this.groupBox4.Controls.Add(this.lblDeduccionInfo);
            this.groupBox4.Controls.Add(this.lblHaberesNoRemInfo);
            this.groupBox4.Controls.Add(this.lblDeduccion);
            this.groupBox4.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.groupBox4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox4.Location = new System.Drawing.Point(17, 512);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(302, 114);
            this.groupBox4.TabIndex = 44;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Totales";
            // 
            // groupBox3
            // 
            this.groupBox3.BackColor = System.Drawing.SystemColors.Control;
            this.groupBox3.Controls.Add(this.btnImprimir);
            this.groupBox3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox3.Location = new System.Drawing.Point(486, 512);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(106, 114);
            this.groupBox3.TabIndex = 43;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Acciones";
            // 
            // btnImprimir
            // 
            this.btnImprimir.Enabled = false;
            this.btnImprimir.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnImprimir.Location = new System.Drawing.Point(16, 25);
            this.btnImprimir.Name = "btnImprimir";
            this.btnImprimir.Size = new System.Drawing.Size(75, 75);
            this.btnImprimir.TabIndex = 1;
            this.btnImprimir.Text = "Generar ";
            this.btnImprimir.UseVisualStyleBackColor = true;
            this.btnImprimir.Click += new System.EventHandler(this.btnImprimir_Click);
            // 
            // lblFechaIngresoInfo
            // 
            this.lblFechaIngresoInfo.AutoSize = true;
            this.lblFechaIngresoInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFechaIngresoInfo.Location = new System.Drawing.Point(241, 187);
            this.lblFechaIngresoInfo.Name = "lblFechaIngresoInfo";
            this.lblFechaIngresoInfo.Size = new System.Drawing.Size(92, 17);
            this.lblFechaIngresoInfo.TabIndex = 39;
            this.lblFechaIngresoInfo.Text = "- - / - - / - - - -";
            // 
            // lblOcupacionInfo
            // 
            this.lblOcupacionInfo.AutoSize = true;
            this.lblOcupacionInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOcupacionInfo.Location = new System.Drawing.Point(15, 187);
            this.lblOcupacionInfo.Name = "lblOcupacionInfo";
            this.lblOcupacionInfo.Size = new System.Drawing.Size(125, 17);
            this.lblOcupacionInfo.TabIndex = 38;
            this.lblOcupacionInfo.Text = "- - - - - - - - - - - - - ";
            // 
            // lblCUILInfo
            // 
            this.lblCUILInfo.AutoSize = true;
            this.lblCUILInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCUILInfo.Location = new System.Drawing.Point(467, 135);
            this.lblCUILInfo.Name = "lblCUILInfo";
            this.lblCUILInfo.Size = new System.Drawing.Size(125, 17);
            this.lblCUILInfo.TabIndex = 37;
            this.lblCUILInfo.Text = "- - - - - - - - - - - - - ";
            // 
            // nombre
            // 
            this.nombre.AutoSize = true;
            this.nombre.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nombre.Location = new System.Drawing.Point(241, 135);
            this.nombre.Name = "nombre";
            this.nombre.Size = new System.Drawing.Size(125, 17);
            this.nombre.TabIndex = 36;
            this.nombre.Text = "- - - - - - - - - - - - - ";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(197, 332);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(235, 13);
            this.label15.TabIndex = 29;
            this.label15.Text = "Seleccione un legajo y presione el botón \"Abrir\".";
            // 
            // PrincipalLiquidaciones
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(629, 676);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label15);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.MinimumSize = new System.Drawing.Size(16, 715);
            this.Name = "PrincipalLiquidaciones";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "tgg";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ReciboBuilder_FormClosing);
            this.Load += new System.EventHandler(this.ReciboBuilder_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetallesRecibo)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem archivoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem herramientasToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mnubtnCerrar;
        private System.Windows.Forms.Label lblHaberesRem;
        private System.Windows.Forms.Label lblHaberesNoRem;
        private System.Windows.Forms.Label lblDeduccion;
        private System.Windows.Forms.Label lblNeto;
        private System.Windows.Forms.Label lblCUIL;
        private System.Windows.Forms.Label lblFechaIngreso;
        private System.Windows.Forms.Label lblNombre;
        private System.Windows.Forms.Label lblOcupacion;
        private System.Windows.Forms.Label lblDetalle;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label lblQuincena;
        private System.Windows.Forms.Label lblAño;
        private System.Windows.Forms.Label lblMes;
        private System.Windows.Forms.GroupBox groupBox1;
        public System.Windows.Forms.DataGridView dgvDetallesRecibo;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Label lblFechaDeposito;
        private System.Windows.Forms.Label lblFechaLiquidacion;
        private System.Windows.Forms.Label lblTipoSalario;
        private System.Windows.Forms.Label lblLegajoNumero;
        public System.Windows.Forms.ComboBox cboQuincena;
        public System.Windows.Forms.ComboBox cboAño;
        public System.Windows.Forms.ComboBox cboMes;
        public System.Windows.Forms.Label lblLegajoNumInfo;
        public System.Windows.Forms.Label lblCUILInfo;
        public System.Windows.Forms.Label lblHaberesRemInfo;
        public System.Windows.Forms.Label lblHaberesNoRemInfo;
        public System.Windows.Forms.Label lblDeduccionInfo;
        public System.Windows.Forms.Label lblNetoInfo;
        public System.Windows.Forms.Label lblFechaDepositoInfo;
        public System.Windows.Forms.Label lblFechaLiquidacionInfo;
        public System.Windows.Forms.Button btnLiquidar;
        public System.Windows.Forms.Button btnEditar;
        public System.Windows.Forms.Button btnImprimir;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.ToolStripMenuItem mnubtnRBMini;
        public System.Windows.Forms.Label nombre;
        public System.Windows.Forms.Label lblTipoSalarioInfo;
        public System.Windows.Forms.Label lblFechaIngresoInfo;
        private System.Windows.Forms.ImageList imageList1;
        public System.Windows.Forms.Label lblOcupacionInfo;
    }
}