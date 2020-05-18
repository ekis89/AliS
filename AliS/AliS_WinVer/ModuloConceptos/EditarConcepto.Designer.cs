namespace AliS_WinVer
{
    partial class EditarConcepto
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
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.tbxComponentes = new System.Windows.Forms.TextBox();
            this.btnSeleccionar = new System.Windows.Forms.Button();
            this.optPorcentaje = new System.Windows.Forms.RadioButton();
            this.lblComponentes = new System.Windows.Forms.Label();
            this.lblPorcentaje = new System.Windows.Forms.Label();
            this.tbxPorcentaje = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnFormula = new System.Windows.Forms.Button();
            this.optValorFijo = new System.Windows.Forms.RadioButton();
            this.tbxValorFijo = new System.Windows.Forms.TextBox();
            this.lblValor = new System.Windows.Forms.Label();
            this.tbxCodigo = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.lblTipoConcepto = new System.Windows.Forms.Label();
            this.tbxNombre = new System.Windows.Forms.TextBox();
            this.optRemunerativo = new System.Windows.Forms.RadioButton();
            this.optNoRemunerativo = new System.Windows.Forms.RadioButton();
            this.btnAceptar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.tbxComponentes);
            this.groupBox2.Controls.Add(this.btnSeleccionar);
            this.groupBox2.Controls.Add(this.optPorcentaje);
            this.groupBox2.Controls.Add(this.lblComponentes);
            this.groupBox2.Controls.Add(this.lblPorcentaje);
            this.groupBox2.Controls.Add(this.tbxPorcentaje);
            this.groupBox2.Location = new System.Drawing.Point(16, 199);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(386, 128);
            this.groupBox2.TabIndex = 30;
            this.groupBox2.TabStop = false;
            // 
            // tbxComponentes
            // 
            this.tbxComponentes.Enabled = false;
            this.tbxComponentes.Location = new System.Drawing.Point(91, 85);
            this.tbxComponentes.MaxLength = 255;
            this.tbxComponentes.Name = "tbxComponentes";
            this.tbxComponentes.ReadOnly = true;
            this.tbxComponentes.Size = new System.Drawing.Size(206, 20);
            this.tbxComponentes.TabIndex = 8;
            // 
            // btnSeleccionar
            // 
            this.btnSeleccionar.Enabled = false;
            this.btnSeleccionar.Location = new System.Drawing.Point(303, 83);
            this.btnSeleccionar.Name = "btnSeleccionar";
            this.btnSeleccionar.Size = new System.Drawing.Size(75, 23);
            this.btnSeleccionar.TabIndex = 9;
            this.btnSeleccionar.Text = "Seleccionar";
            this.btnSeleccionar.UseVisualStyleBackColor = true;
            this.btnSeleccionar.Click += new System.EventHandler(this.btnSeleccionar_Click);
            // 
            // optPorcentaje
            // 
            this.optPorcentaje.AutoSize = true;
            this.optPorcentaje.Location = new System.Drawing.Point(6, 20);
            this.optPorcentaje.Name = "optPorcentaje";
            this.optPorcentaje.Size = new System.Drawing.Size(96, 17);
            this.optPorcentaje.TabIndex = 6;
            this.optPorcentaje.TabStop = true;
            this.optPorcentaje.Text = "Porcentaje (%):";
            this.optPorcentaje.UseVisualStyleBackColor = true;
            this.optPorcentaje.CheckedChanged += new System.EventHandler(this.optPorcentaje_CheckedChanged);
            // 
            // lblComponentes
            // 
            this.lblComponentes.AutoSize = true;
            this.lblComponentes.Enabled = false;
            this.lblComponentes.Location = new System.Drawing.Point(10, 90);
            this.lblComponentes.Name = "lblComponentes";
            this.lblComponentes.Size = new System.Drawing.Size(75, 13);
            this.lblComponentes.TabIndex = 13;
            this.lblComponentes.Text = "Componentes:";
            // 
            // lblPorcentaje
            // 
            this.lblPorcentaje.AutoSize = true;
            this.lblPorcentaje.Enabled = false;
            this.lblPorcentaje.Location = new System.Drawing.Point(10, 55);
            this.lblPorcentaje.Name = "lblPorcentaje";
            this.lblPorcentaje.Size = new System.Drawing.Size(61, 13);
            this.lblPorcentaje.TabIndex = 15;
            this.lblPorcentaje.Text = "Porcentaje:";
            // 
            // tbxPorcentaje
            // 
            this.tbxPorcentaje.Enabled = false;
            this.tbxPorcentaje.Location = new System.Drawing.Point(91, 52);
            this.tbxPorcentaje.MaxLength = 3;
            this.tbxPorcentaje.Name = "tbxPorcentaje";
            this.tbxPorcentaje.Size = new System.Drawing.Size(97, 20);
            this.tbxPorcentaje.TabIndex = 7;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnFormula);
            this.groupBox1.Controls.Add(this.optValorFijo);
            this.groupBox1.Controls.Add(this.tbxValorFijo);
            this.groupBox1.Controls.Add(this.lblValor);
            this.groupBox1.Location = new System.Drawing.Point(16, 85);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(386, 95);
            this.groupBox1.TabIndex = 29;
            this.groupBox1.TabStop = false;
            // 
            // btnFormula
            // 
            this.btnFormula.Location = new System.Drawing.Point(287, 50);
            this.btnFormula.Name = "btnFormula";
            this.btnFormula.Size = new System.Drawing.Size(75, 23);
            this.btnFormula.TabIndex = 5;
            this.btnFormula.Text = "Formula";
            this.btnFormula.UseVisualStyleBackColor = true;
            this.btnFormula.Click += new System.EventHandler(this.btnFormula_Click);
            // 
            // optValorFijo
            // 
            this.optValorFijo.AutoSize = true;
            this.optValorFijo.Checked = true;
            this.optValorFijo.Location = new System.Drawing.Point(8, 20);
            this.optValorFijo.Name = "optValorFijo";
            this.optValorFijo.Size = new System.Drawing.Size(83, 17);
            this.optValorFijo.TabIndex = 3;
            this.optValorFijo.TabStop = true;
            this.optValorFijo.Text = "Valor fijo ($):";
            this.optValorFijo.UseVisualStyleBackColor = true;
            this.optValorFijo.CheckedChanged += new System.EventHandler(this.optValorFijo_CheckedChanged);
            // 
            // tbxValorFijo
            // 
            this.tbxValorFijo.Location = new System.Drawing.Point(91, 52);
            this.tbxValorFijo.MaxLength = 255;
            this.tbxValorFijo.Name = "tbxValorFijo";
            this.tbxValorFijo.Size = new System.Drawing.Size(173, 20);
            this.tbxValorFijo.TabIndex = 4;
            // 
            // lblValor
            // 
            this.lblValor.AutoSize = true;
            this.lblValor.Location = new System.Drawing.Point(10, 55);
            this.lblValor.Name = "lblValor";
            this.lblValor.Size = new System.Drawing.Size(34, 13);
            this.lblValor.TabIndex = 17;
            this.lblValor.Text = "Valor:";
            // 
            // tbxCodigo
            // 
            this.tbxCodigo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.tbxCodigo.Location = new System.Drawing.Point(111, 12);
            this.tbxCodigo.MaxLength = 8;
            this.tbxCodigo.Name = "tbxCodigo";
            this.tbxCodigo.Size = new System.Drawing.Size(85, 20);
            this.tbxCodigo.TabIndex = 21;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 50);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 13);
            this.label1.TabIndex = 22;
            this.label1.Text = "Nombre:";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(13, 15);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(40, 13);
            this.label13.TabIndex = 25;
            this.label13.Text = "Código";
            // 
            // lblTipoConcepto
            // 
            this.lblTipoConcepto.AutoSize = true;
            this.lblTipoConcepto.Location = new System.Drawing.Point(13, 352);
            this.lblTipoConcepto.Name = "lblTipoConcepto";
            this.lblTipoConcepto.Size = new System.Drawing.Size(94, 13);
            this.lblTipoConcepto.TabIndex = 23;
            this.lblTipoConcepto.Text = "Tipo de concepto:";
            // 
            // tbxNombre
            // 
            this.tbxNombre.Location = new System.Drawing.Point(111, 47);
            this.tbxNombre.MaxLength = 50;
            this.tbxNombre.Name = "tbxNombre";
            this.tbxNombre.Size = new System.Drawing.Size(291, 20);
            this.tbxNombre.TabIndex = 24;
            // 
            // optRemunerativo
            // 
            this.optRemunerativo.AutoSize = true;
            this.optRemunerativo.Location = new System.Drawing.Point(113, 350);
            this.optRemunerativo.Name = "optRemunerativo";
            this.optRemunerativo.Size = new System.Drawing.Size(91, 17);
            this.optRemunerativo.TabIndex = 26;
            this.optRemunerativo.TabStop = true;
            this.optRemunerativo.Text = "Remunerativo";
            this.optRemunerativo.UseVisualStyleBackColor = true;
            // 
            // optNoRemunerativo
            // 
            this.optNoRemunerativo.AutoSize = true;
            this.optNoRemunerativo.Location = new System.Drawing.Point(210, 350);
            this.optNoRemunerativo.Name = "optNoRemunerativo";
            this.optNoRemunerativo.Size = new System.Drawing.Size(103, 17);
            this.optNoRemunerativo.TabIndex = 27;
            this.optNoRemunerativo.TabStop = true;
            this.optNoRemunerativo.Text = "No remunerativo";
            this.optNoRemunerativo.UseVisualStyleBackColor = true;
            // 
            // btnAceptar
            // 
            this.btnAceptar.Location = new System.Drawing.Point(255, 393);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(75, 23);
            this.btnAceptar.TabIndex = 28;
            this.btnAceptar.Text = "Aceptar";
            this.btnAceptar.UseVisualStyleBackColor = true;
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.Location = new System.Drawing.Point(336, 393);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(75, 23);
            this.btnCancelar.TabIndex = 31;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // EditConcepto
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(423, 428);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.tbxCodigo);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.lblTipoConcepto);
            this.Controls.Add(this.tbxNombre);
            this.Controls.Add(this.optRemunerativo);
            this.Controls.Add(this.optNoRemunerativo);
            this.Controls.Add(this.btnAceptar);
            this.Name = "EditConcepto";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Editar concepto";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.EditConcepto_FormClosing);
            this.Load += new System.EventHandler(this.EditConcepto_Load);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox2;
        public System.Windows.Forms.TextBox tbxComponentes;
        private System.Windows.Forms.Button btnSeleccionar;
        private System.Windows.Forms.RadioButton optPorcentaje;
        private System.Windows.Forms.Label lblComponentes;
        private System.Windows.Forms.Label lblPorcentaje;
        public System.Windows.Forms.TextBox tbxPorcentaje;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnFormula;
        private System.Windows.Forms.RadioButton optValorFijo;
        public System.Windows.Forms.TextBox tbxValorFijo;
        private System.Windows.Forms.Label lblValor;
        private System.Windows.Forms.TextBox tbxCodigo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label lblTipoConcepto;
        private System.Windows.Forms.TextBox tbxNombre;
        private System.Windows.Forms.RadioButton optRemunerativo;
        private System.Windows.Forms.RadioButton optNoRemunerativo;
        private System.Windows.Forms.Button btnAceptar;
        private System.Windows.Forms.Button btnCancelar;
    }
}