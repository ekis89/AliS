namespace AliS_WinVer
{
    partial class GestionLiquidacionConceptos
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dgvDetalles = new System.Windows.Forms.DataGridView();
            this.btnQuitar = new System.Windows.Forms.Button();
            this.btnAgregar = new System.Windows.Forms.Button();
            this.btnEditar = new System.Windows.Forms.Button();
            this.dtpFechaLiquidacion = new System.Windows.Forms.DateTimePicker();
            this.lblFechaLiquidacion = new System.Windows.Forms.Label();
            this.dtpFechaDeposito = new System.Windows.Forms.DateTimePicker();
            this.lblFechaDeposito = new System.Windows.Forms.Label();
            this.lblDetalle = new System.Windows.Forms.Label();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.lblRem = new System.Windows.Forms.Label();
            this.lblRemInfo = new System.Windows.Forms.Label();
            this.lblNetoInfo = new System.Windows.Forms.Label();
            this.lblNoRem = new System.Windows.Forms.Label();
            this.lblNeto = new System.Windows.Forms.Label();
            this.lblDeduccionesInfo = new System.Windows.Forms.Label();
            this.lblNoRemInfo = new System.Windows.Forms.Label();
            this.lblDeducciones = new System.Windows.Forms.Label();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.herramientasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mnubtnCalculadoraSAC = new System.Windows.Forms.ToolStripMenuItem();
            this.liquidarBtn = new System.Windows.Forms.Button();
            this.btnSubir = new System.Windows.Forms.Button();
            this.btnBajar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetalles)).BeginInit();
            this.groupBox4.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvDetalles
            // 
            this.dgvDetalles.AllowUserToAddRows = false;
            this.dgvDetalles.AllowUserToDeleteRows = false;
            this.dgvDetalles.AllowUserToResizeColumns = false;
            this.dgvDetalles.AllowUserToResizeRows = false;
            this.dgvDetalles.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvDetalles.BackgroundColor = System.Drawing.SystemColors.ActiveCaption;
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvDetalles.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle7;
            this.dgvDetalles.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle8.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvDetalles.DefaultCellStyle = dataGridViewCellStyle8;
            this.dgvDetalles.Location = new System.Drawing.Point(12, 83);
            this.dgvDetalles.MultiSelect = false;
            this.dgvDetalles.Name = "dgvDetalles";
            this.dgvDetalles.ReadOnly = true;
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle9.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle9.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle9.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle9.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvDetalles.RowHeadersDefaultCellStyle = dataGridViewCellStyle9;
            this.dgvDetalles.RowHeadersVisible = false;
            this.dgvDetalles.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dgvDetalles.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvDetalles.Size = new System.Drawing.Size(575, 235);
            this.dgvDetalles.TabIndex = 16;
            this.dgvDetalles.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDetalles_CellContentClick);
            // 
            // btnQuitar
            // 
            this.btnQuitar.Location = new System.Drawing.Point(511, 324);
            this.btnQuitar.Name = "btnQuitar";
            this.btnQuitar.Size = new System.Drawing.Size(75, 23);
            this.btnQuitar.TabIndex = 45;
            this.btnQuitar.Text = "Quitar";
            this.btnQuitar.UseVisualStyleBackColor = true;
            this.btnQuitar.Click += new System.EventHandler(this.Del_con_Click);
            // 
            // btnAgregar
            // 
            this.btnAgregar.Location = new System.Drawing.Point(349, 324);
            this.btnAgregar.Name = "btnAgregar";
            this.btnAgregar.Size = new System.Drawing.Size(75, 23);
            this.btnAgregar.TabIndex = 44;
            this.btnAgregar.Text = "Agregar";
            this.btnAgregar.UseVisualStyleBackColor = true;
            this.btnAgregar.Click += new System.EventHandler(this.Add_con_Click);
            // 
            // btnEditar
            // 
            this.btnEditar.Location = new System.Drawing.Point(430, 324);
            this.btnEditar.Name = "btnEditar";
            this.btnEditar.Size = new System.Drawing.Size(75, 23);
            this.btnEditar.TabIndex = 43;
            this.btnEditar.Text = "Editar";
            this.btnEditar.UseVisualStyleBackColor = true;
            this.btnEditar.Click += new System.EventHandler(this.Edit_con_Click);
            // 
            // dtpFechaLiquidacion
            // 
            this.dtpFechaLiquidacion.CustomFormat = "dd/MMM/yy";
            this.dtpFechaLiquidacion.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFechaLiquidacion.Location = new System.Drawing.Point(259, 58);
            this.dtpFechaLiquidacion.Name = "dtpFechaLiquidacion";
            this.dtpFechaLiquidacion.Size = new System.Drawing.Size(98, 20);
            this.dtpFechaLiquidacion.TabIndex = 54;
            // 
            // lblFechaLiquidacion
            // 
            this.lblFechaLiquidacion.AutoSize = true;
            this.lblFechaLiquidacion.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFechaLiquidacion.Location = new System.Drawing.Point(124, 61);
            this.lblFechaLiquidacion.Name = "lblFechaLiquidacion";
            this.lblFechaLiquidacion.Size = new System.Drawing.Size(129, 13);
            this.lblFechaLiquidacion.TabIndex = 53;
            this.lblFechaLiquidacion.Text = "Fecha de liquidación:";
            // 
            // dtpFechaDeposito
            // 
            this.dtpFechaDeposito.CustomFormat = "dd/MMM/yy";
            this.dtpFechaDeposito.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFechaDeposito.Location = new System.Drawing.Point(489, 58);
            this.dtpFechaDeposito.Name = "dtpFechaDeposito";
            this.dtpFechaDeposito.Size = new System.Drawing.Size(98, 20);
            this.dtpFechaDeposito.TabIndex = 52;
            // 
            // lblFechaDeposito
            // 
            this.lblFechaDeposito.AutoSize = true;
            this.lblFechaDeposito.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFechaDeposito.Location = new System.Drawing.Point(367, 61);
            this.lblFechaDeposito.Name = "lblFechaDeposito";
            this.lblFechaDeposito.Size = new System.Drawing.Size(116, 13);
            this.lblFechaDeposito.TabIndex = 51;
            this.lblFechaDeposito.Text = "Fecha de deposito:";
            // 
            // lblDetalle
            // 
            this.lblDetalle.AutoSize = true;
            this.lblDetalle.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDetalle.Location = new System.Drawing.Point(11, 61);
            this.lblDetalle.Name = "lblDetalle";
            this.lblDetalle.Size = new System.Drawing.Size(51, 13);
            this.lblDetalle.TabIndex = 50;
            this.lblDetalle.Text = "Detalle:";
            // 
            // btnGuardar
            // 
            this.btnGuardar.Location = new System.Drawing.Point(223, 497);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(75, 23);
            this.btnGuardar.TabIndex = 55;
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.UseVisualStyleBackColor = true;
            this.btnGuardar.Click += new System.EventHandler(this.Save_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.Location = new System.Drawing.Point(304, 497);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(75, 23);
            this.btnCancelar.TabIndex = 56;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.Cancel_Click);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.lblRem);
            this.groupBox4.Controls.Add(this.lblRemInfo);
            this.groupBox4.Controls.Add(this.lblNetoInfo);
            this.groupBox4.Controls.Add(this.lblNoRem);
            this.groupBox4.Controls.Add(this.lblNeto);
            this.groupBox4.Controls.Add(this.lblDeduccionesInfo);
            this.groupBox4.Controls.Add(this.lblNoRemInfo);
            this.groupBox4.Controls.Add(this.lblDeducciones);
            this.groupBox4.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.groupBox4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox4.Location = new System.Drawing.Point(150, 362);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(302, 114);
            this.groupBox4.TabIndex = 57;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Totales";
            // 
            // lblRem
            // 
            this.lblRem.AutoSize = true;
            this.lblRem.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRem.Location = new System.Drawing.Point(35, 25);
            this.lblRem.Name = "lblRem";
            this.lblRem.Size = new System.Drawing.Size(141, 13);
            this.lblRem.TabIndex = 23;
            this.lblRem.Text = "Haberes remunerativos:";
            // 
            // lblRemInfo
            // 
            this.lblRemInfo.AutoSize = true;
            this.lblRemInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRemInfo.Location = new System.Drawing.Point(182, 25);
            this.lblRemInfo.Name = "lblRemInfo";
            this.lblRemInfo.Size = new System.Drawing.Size(40, 13);
            this.lblRemInfo.TabIndex = 28;
            this.lblRemInfo.Text = "$00.00";
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
            // lblNoRem
            // 
            this.lblNoRem.AutoSize = true;
            this.lblNoRem.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNoRem.Location = new System.Drawing.Point(35, 45);
            this.lblNoRem.Name = "lblNoRem";
            this.lblNoRem.Size = new System.Drawing.Size(159, 13);
            this.lblNoRem.TabIndex = 24;
            this.lblNoRem.Text = "Haberes no remunerativos:";
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
            // lblDeduccionesInfo
            // 
            this.lblDeduccionesInfo.AutoSize = true;
            this.lblDeduccionesInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDeduccionesInfo.Location = new System.Drawing.Point(126, 65);
            this.lblDeduccionesInfo.Name = "lblDeduccionesInfo";
            this.lblDeduccionesInfo.Size = new System.Drawing.Size(40, 13);
            this.lblDeduccionesInfo.TabIndex = 30;
            this.lblDeduccionesInfo.Text = "$00.00";
            // 
            // lblNoRemInfo
            // 
            this.lblNoRemInfo.AutoSize = true;
            this.lblNoRemInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNoRemInfo.Location = new System.Drawing.Point(200, 45);
            this.lblNoRemInfo.Name = "lblNoRemInfo";
            this.lblNoRemInfo.Size = new System.Drawing.Size(40, 13);
            this.lblNoRemInfo.TabIndex = 29;
            this.lblNoRemInfo.Text = "$00.00";
            // 
            // lblDeducciones
            // 
            this.lblDeducciones.AutoSize = true;
            this.lblDeducciones.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDeducciones.Location = new System.Drawing.Point(35, 65);
            this.lblDeducciones.Name = "lblDeducciones";
            this.lblDeducciones.Size = new System.Drawing.Size(85, 13);
            this.lblDeducciones.TabIndex = 25;
            this.lblDeducciones.Text = "Deducciones:";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.herramientasToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(603, 24);
            this.menuStrip1.TabIndex = 59;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // herramientasToolStripMenuItem
            // 
            this.herramientasToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnubtnCalculadoraSAC});
            this.herramientasToolStripMenuItem.Name = "herramientasToolStripMenuItem";
            this.herramientasToolStripMenuItem.Size = new System.Drawing.Size(90, 20);
            this.herramientasToolStripMenuItem.Text = "Herramientas";
            // 
            // mnubtnCalculadoraSAC
            // 
            this.mnubtnCalculadoraSAC.Name = "mnubtnCalculadoraSAC";
            this.mnubtnCalculadoraSAC.Size = new System.Drawing.Size(203, 22);
            this.mnubtnCalculadoraSAC.Text = "Calculador de aguinaldo";
            this.mnubtnCalculadoraSAC.Click += new System.EventHandler(this.mnubtnCalculadoraSAC_Click);
            // 
            // liquidarBtn
            // 
            this.liquidarBtn.Location = new System.Drawing.Point(516, 497);
            this.liquidarBtn.Name = "liquidarBtn";
            this.liquidarBtn.Size = new System.Drawing.Size(75, 23);
            this.liquidarBtn.TabIndex = 58;
            this.liquidarBtn.Text = "debug";
            this.liquidarBtn.UseVisualStyleBackColor = true;
            this.liquidarBtn.Visible = false;
            // 
            // btnSubir
            // 
            this.btnSubir.Location = new System.Drawing.Point(66, 324);
            this.btnSubir.Name = "btnSubir";
            this.btnSubir.Size = new System.Drawing.Size(48, 23);
            this.btnSubir.TabIndex = 60;
            this.btnSubir.Text = "Subir";
            this.btnSubir.UseVisualStyleBackColor = true;
            this.btnSubir.Click += new System.EventHandler(this.btnSubir_Click);
            // 
            // btnBajar
            // 
            this.btnBajar.Location = new System.Drawing.Point(12, 324);
            this.btnBajar.Name = "btnBajar";
            this.btnBajar.Size = new System.Drawing.Size(48, 23);
            this.btnBajar.TabIndex = 61;
            this.btnBajar.Text = "Bajar";
            this.btnBajar.UseVisualStyleBackColor = true;
            this.btnBajar.Click += new System.EventHandler(this.btnBajar_Click);
            // 
            // Liquidar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(603, 532);
            this.Controls.Add(this.btnBajar);
            this.Controls.Add(this.btnSubir);
            this.Controls.Add(this.liquidarBtn);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnGuardar);
            this.Controls.Add(this.dtpFechaLiquidacion);
            this.Controls.Add(this.lblFechaLiquidacion);
            this.Controls.Add(this.dtpFechaDeposito);
            this.Controls.Add(this.lblFechaDeposito);
            this.Controls.Add(this.lblDetalle);
            this.Controls.Add(this.btnQuitar);
            this.Controls.Add(this.btnAgregar);
            this.Controls.Add(this.btnEditar);
            this.Controls.Add(this.dgvDetalles);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Liquidar";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Liquidación";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Liquidar_FormClosing);
            this.Load += new System.EventHandler(this.Liquidar_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetalles)).EndInit();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.DataGridView dgvDetalles;
        private System.Windows.Forms.Button btnQuitar;
        private System.Windows.Forms.Button btnAgregar;
        private System.Windows.Forms.Button btnEditar;
        private System.Windows.Forms.DateTimePicker dtpFechaLiquidacion;
        private System.Windows.Forms.Label lblFechaLiquidacion;
        private System.Windows.Forms.DateTimePicker dtpFechaDeposito;
        private System.Windows.Forms.Label lblFechaDeposito;
        private System.Windows.Forms.Label lblDetalle;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Label lblRem;
        private System.Windows.Forms.Label lblNoRem;
        private System.Windows.Forms.Label lblNeto;
        private System.Windows.Forms.Label lblDeducciones;
        public System.Windows.Forms.Label lblRemInfo;
        public System.Windows.Forms.Label lblNetoInfo;
        public System.Windows.Forms.Label lblDeduccionesInfo;
        public System.Windows.Forms.Label lblNoRemInfo;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem herramientasToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mnubtnCalculadoraSAC;
        private System.Windows.Forms.Button liquidarBtn;
        private System.Windows.Forms.Button btnSubir;
        private System.Windows.Forms.Button btnBajar;
    }
}