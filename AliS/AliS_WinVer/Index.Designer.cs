namespace AliS_WinVer
{
    partial class Index
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Index));
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.deleteEmpresaButton = new System.Windows.Forms.Button();
            this.archivoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.nuevaEmpresaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.salirToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.herramientasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.backupToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.liquidacionesButton = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label14 = new System.Windows.Forms.Label();
            this.postalInfo = new System.Windows.Forms.Label();
            this.telefonoInfo = new System.Windows.Forms.Label();
            this.direccionInfo = new System.Windows.Forms.Label();
            this.localidadInfo = new System.Windows.Forms.Label();
            this.cuitInfo = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label7 = new System.Windows.Forms.Label();
            this.conceptosButton = new System.Windows.Forms.Button();
            this.legajosButton = new System.Windows.Forms.Button();
            this.puestosButton = new System.Windows.Forms.Button();
            this.cantidadLabel = new System.Windows.Forms.Label();
            this.leg_number = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.comboEmpresas = new System.Windows.Forms.ComboBox();
            this.menuStrip1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "build.png");
            // 
            // deleteEmpresaButton
            // 
            this.deleteEmpresaButton.Enabled = false;
            this.deleteEmpresaButton.Location = new System.Drawing.Point(249, 36);
            this.deleteEmpresaButton.Name = "deleteEmpresaButton";
            this.deleteEmpresaButton.Size = new System.Drawing.Size(37, 23);
            this.deleteEmpresaButton.TabIndex = 2;
            this.deleteEmpresaButton.Text = "DEL";
            this.deleteEmpresaButton.UseVisualStyleBackColor = true;
            this.deleteEmpresaButton.Click += new System.EventHandler(this.deleteEmpresaButton_Click);
            // 
            // archivoToolStripMenuItem
            // 
            this.archivoToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.nuevaEmpresaToolStripMenuItem,
            this.toolStripSeparator1,
            this.salirToolStripMenuItem});
            this.archivoToolStripMenuItem.Name = "archivoToolStripMenuItem";
            this.archivoToolStripMenuItem.Size = new System.Drawing.Size(60, 20);
            this.archivoToolStripMenuItem.Text = "Archivo";
            // 
            // nuevaEmpresaToolStripMenuItem
            // 
            this.nuevaEmpresaToolStripMenuItem.Name = "nuevaEmpresaToolStripMenuItem";
            this.nuevaEmpresaToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.N)));
            this.nuevaEmpresaToolStripMenuItem.Size = new System.Drawing.Size(199, 22);
            this.nuevaEmpresaToolStripMenuItem.Text = "Nueva empresa";
            this.nuevaEmpresaToolStripMenuItem.Click += new System.EventHandler(this.nuevaEmpresaToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(196, 6);
            // 
            // salirToolStripMenuItem
            // 
            this.salirToolStripMenuItem.Name = "salirToolStripMenuItem";
            this.salirToolStripMenuItem.Size = new System.Drawing.Size(199, 22);
            this.salirToolStripMenuItem.Text = "Salir";
            this.salirToolStripMenuItem.Click += new System.EventHandler(this.salirToolStripMenuItem_Click);
            // 
            // herramientasToolStripMenuItem
            // 
            this.herramientasToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.backupToolStripMenuItem});
            this.herramientasToolStripMenuItem.Name = "herramientasToolStripMenuItem";
            this.herramientasToolStripMenuItem.Size = new System.Drawing.Size(90, 20);
            this.herramientasToolStripMenuItem.Text = "Herramientas";
            // 
            // backupToolStripMenuItem
            // 
            this.backupToolStripMenuItem.Name = "backupToolStripMenuItem";
            this.backupToolStripMenuItem.Size = new System.Drawing.Size(113, 22);
            this.backupToolStripMenuItem.Text = "Backup";
            this.backupToolStripMenuItem.Click += new System.EventHandler(this.backupToolStripMenuItem_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.archivoToolStripMenuItem,
            this.herramientasToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(300, 24);
            this.menuStrip1.TabIndex = 3;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Enabled = false;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(13, 30);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(44, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "C.U.I.T:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Enabled = false;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(13, 53);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(56, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "Localidad:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Enabled = false;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(13, 103);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(55, 13);
            this.label5.TabIndex = 9;
            this.label5.Text = "Dirección:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Enabled = false;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(13, 128);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(52, 13);
            this.label6.TabIndex = 10;
            this.label6.Text = "Teléfono:";
            // 
            // liquidacionesButton
            // 
            this.liquidacionesButton.Enabled = false;
            this.liquidacionesButton.Location = new System.Drawing.Point(199, 345);
            this.liquidacionesButton.Name = "liquidacionesButton";
            this.liquidacionesButton.Size = new System.Drawing.Size(87, 23);
            this.liquidacionesButton.TabIndex = 12;
            this.liquidacionesButton.Text = "Liquidaciones";
            this.liquidacionesButton.UseVisualStyleBackColor = true;
            this.liquidacionesButton.Click += new System.EventHandler(this.liquidacionesButton_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label14);
            this.groupBox1.Controls.Add(this.postalInfo);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.telefonoInfo);
            this.groupBox1.Controls.Add(this.direccionInfo);
            this.groupBox1.Controls.Add(this.localidadInfo);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.cuitInfo);
            this.groupBox1.Enabled = false;
            this.groupBox1.Location = new System.Drawing.Point(12, 64);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(276, 196);
            this.groupBox1.TabIndex = 18;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Información:";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Enabled = false;
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.Location = new System.Drawing.Point(13, 78);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(74, 13);
            this.label14.TabIndex = 18;
            this.label14.Text = "Codigo postal:";
            // 
            // postalInfo
            // 
            this.postalInfo.AutoSize = true;
            this.postalInfo.Enabled = false;
            this.postalInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.postalInfo.Location = new System.Drawing.Point(91, 78);
            this.postalInfo.Name = "postalInfo";
            this.postalInfo.Size = new System.Drawing.Size(64, 13);
            this.postalInfo.TabIndex = 19;
            this.postalInfo.Text = "- - - - - - - - - -";
            // 
            // telefonoInfo
            // 
            this.telefonoInfo.AutoSize = true;
            this.telefonoInfo.Enabled = false;
            this.telefonoInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.telefonoInfo.Location = new System.Drawing.Point(91, 128);
            this.telefonoInfo.Name = "telefonoInfo";
            this.telefonoInfo.Size = new System.Drawing.Size(64, 13);
            this.telefonoInfo.TabIndex = 17;
            this.telefonoInfo.Text = "- - - - - - - - - -";
            // 
            // direccionInfo
            // 
            this.direccionInfo.AutoSize = true;
            this.direccionInfo.Enabled = false;
            this.direccionInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.direccionInfo.Location = new System.Drawing.Point(91, 103);
            this.direccionInfo.Name = "direccionInfo";
            this.direccionInfo.Size = new System.Drawing.Size(64, 13);
            this.direccionInfo.TabIndex = 16;
            this.direccionInfo.Text = "- - - - - - - - - -";
            // 
            // localidadInfo
            // 
            this.localidadInfo.AutoSize = true;
            this.localidadInfo.Enabled = false;
            this.localidadInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.localidadInfo.Location = new System.Drawing.Point(91, 53);
            this.localidadInfo.Name = "localidadInfo";
            this.localidadInfo.Size = new System.Drawing.Size(64, 13);
            this.localidadInfo.TabIndex = 15;
            this.localidadInfo.Text = "- - - - - - - - - -";
            // 
            // cuitInfo
            // 
            this.cuitInfo.AutoSize = true;
            this.cuitInfo.Enabled = false;
            this.cuitInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cuitInfo.Location = new System.Drawing.Point(91, 29);
            this.cuitInfo.Name = "cuitInfo";
            this.cuitInfo.Size = new System.Drawing.Size(64, 13);
            this.cuitInfo.TabIndex = 13;
            this.cuitInfo.Text = "- - - - - - - - - -";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.conceptosButton);
            this.groupBox2.Controls.Add(this.legajosButton);
            this.groupBox2.Controls.Add(this.puestosButton);
            this.groupBox2.Enabled = false;
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(12, 267);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(276, 65);
            this.groupBox2.TabIndex = 22;
            this.groupBox2.TabStop = false;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(6, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(63, 13);
            this.label7.TabIndex = 23;
            this.label7.Text = "Parámetros:";
            // 
            // conceptosButton
            // 
            this.conceptosButton.Location = new System.Drawing.Point(16, 26);
            this.conceptosButton.Name = "conceptosButton";
            this.conceptosButton.Size = new System.Drawing.Size(69, 23);
            this.conceptosButton.TabIndex = 19;
            this.conceptosButton.Text = "Conceptos";
            this.conceptosButton.UseVisualStyleBackColor = true;
            this.conceptosButton.Click += new System.EventHandler(this.conceptosButton_Click);
            // 
            // legajosButton
            // 
            this.legajosButton.Location = new System.Drawing.Point(191, 26);
            this.legajosButton.Name = "legajosButton";
            this.legajosButton.Size = new System.Drawing.Size(69, 23);
            this.legajosButton.TabIndex = 21;
            this.legajosButton.Text = "Legajos";
            this.legajosButton.UseVisualStyleBackColor = true;
            this.legajosButton.Click += new System.EventHandler(this.legajosButton_Click);
            // 
            // puestosButton
            // 
            this.puestosButton.Location = new System.Drawing.Point(104, 26);
            this.puestosButton.Name = "puestosButton";
            this.puestosButton.Size = new System.Drawing.Size(69, 23);
            this.puestosButton.TabIndex = 20;
            this.puestosButton.Text = "Puestos";
            this.puestosButton.UseVisualStyleBackColor = true;
            this.puestosButton.Click += new System.EventHandler(this.puestosButton_Click);
            // 
            // cantidadLabel
            // 
            this.cantidadLabel.AutoSize = true;
            this.cantidadLabel.Enabled = false;
            this.cantidadLabel.Location = new System.Drawing.Point(25, 350);
            this.cantidadLabel.Name = "cantidadLabel";
            this.cantidadLabel.Size = new System.Drawing.Size(103, 13);
            this.cantidadLabel.TabIndex = 23;
            this.cantidadLabel.Text = "Cantidad de legajos:";
            // 
            // leg_number
            // 
            this.leg_number.AutoSize = true;
            this.leg_number.Enabled = false;
            this.leg_number.Location = new System.Drawing.Point(134, 350);
            this.leg_number.Name = "leg_number";
            this.leg_number.Size = new System.Drawing.Size(10, 13);
            this.leg_number.TabIndex = 24;
            this.leg_number.Text = "-";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(12, 29);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(32, 32);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 25;
            this.pictureBox1.TabStop = false;
            // 
            // comboEmpresas
            // 
            this.comboEmpresas.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboEmpresas.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.comboEmpresas.FormattingEnabled = true;
            this.comboEmpresas.Location = new System.Drawing.Point(50, 37);
            this.comboEmpresas.MaxDropDownItems = 100;
            this.comboEmpresas.Name = "comboEmpresas";
            this.comboEmpresas.Size = new System.Drawing.Size(184, 21);
            this.comboEmpresas.TabIndex = 26;
            this.comboEmpresas.SelectedIndexChanged += new System.EventHandler(this.comboEmpresas_SelectedIndexChanged);
            // 
            // Index
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(300, 378);
            this.Controls.Add(this.comboEmpresas);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.leg_number);
            this.Controls.Add(this.cantidadLabel);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.deleteEmpresaButton);
            this.Controls.Add(this.liquidacionesButton);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.groupBox1);
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(560, 417);
            this.MinimumSize = new System.Drawing.Size(316, 390);
            this.Name = "Index";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "A.li.S: Liquidador de sueldos";
            this.Load += new System.EventHandler(this.Index_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.Index_Paint);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button deleteEmpresaButton;
        private System.Windows.Forms.ToolStripMenuItem archivoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem salirToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem herramientasToolStripMenuItem;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button liquidacionesButton;
        private System.Windows.Forms.GroupBox groupBox1;
        public System.Windows.Forms.Label telefonoInfo;
        public System.Windows.Forms.Label direccionInfo;
        public System.Windows.Forms.Label localidadInfo;
        public System.Windows.Forms.Label cuitInfo;
        public System.Windows.Forms.Label label4;
        private System.Windows.Forms.ToolStripMenuItem nuevaEmpresaToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button conceptosButton;
        private System.Windows.Forms.Button legajosButton;
        private System.Windows.Forms.Button puestosButton;
        private System.Windows.Forms.Label cantidadLabel;
        private System.Windows.Forms.ToolStripMenuItem backupToolStripMenuItem;
        private System.Windows.Forms.Label label14;
        public System.Windows.Forms.Label postalInfo;
        public System.Windows.Forms.Label leg_number;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.ComboBox comboEmpresas;
    }
}