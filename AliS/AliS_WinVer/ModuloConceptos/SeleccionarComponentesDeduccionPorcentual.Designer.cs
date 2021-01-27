namespace AliS_WinVer
{
    partial class SeleccionarComponentesDeduccionPorcentual
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SeleccionarComponentesDeduccionPorcentual));
            this.tbxPorcentaje = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btnAceptar = new System.Windows.Forms.Button();
            this.lblTip = new System.Windows.Forms.Label();
            this.dgvConceptosList = new System.Windows.Forms.DataGridView();
            this.checkCol = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.chkAplicaEnRem = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvConceptosList)).BeginInit();
            this.SuspendLayout();
            // 
            // tbxPorcentaje
            // 
            this.tbxPorcentaje.Location = new System.Drawing.Point(177, 478);
            this.tbxPorcentaje.MaxLength = 3;
            this.tbxPorcentaje.Name = "tbxPorcentaje";
            this.tbxPorcentaje.Size = new System.Drawing.Size(100, 20);
            this.tbxPorcentaje.TabIndex = 11;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(93, 481);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(78, 13);
            this.label3.TabIndex = 10;
            this.label3.Text = "Porcentaje (%);";
            // 
            // btnAceptar
            // 
            this.btnAceptar.Location = new System.Drawing.Point(148, 526);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(75, 23);
            this.btnAceptar.TabIndex = 9;
            this.btnAceptar.Text = "Aceptar";
            this.btnAceptar.UseVisualStyleBackColor = true;
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
            // 
            // lblTip
            // 
            this.lblTip.AutoSize = true;
            this.lblTip.Location = new System.Drawing.Point(12, 46);
            this.lblTip.Name = "lblTip";
            this.lblTip.Size = new System.Drawing.Size(326, 26);
            this.lblTip.TabIndex = 8;
            this.lblTip.Text = "Seleccione de la lista los haberes sobre los cuales se aplica la parte\r\n porcentu" +
    "al de este concepto.";
            // 
            // dgvConceptosList
            // 
            this.dgvConceptosList.AllowUserToAddRows = false;
            this.dgvConceptosList.AllowUserToDeleteRows = false;
            this.dgvConceptosList.AllowUserToResizeColumns = false;
            this.dgvConceptosList.AllowUserToResizeRows = false;
            this.dgvConceptosList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvConceptosList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.checkCol});
            this.dgvConceptosList.Location = new System.Drawing.Point(12, 87);
            this.dgvConceptosList.Name = "dgvConceptosList";
            this.dgvConceptosList.RowHeadersVisible = false;
            this.dgvConceptosList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvConceptosList.Size = new System.Drawing.Size(346, 351);
            this.dgvConceptosList.TabIndex = 7;
            // 
            // checkCol
            // 
            this.checkCol.FalseValue = "false";
            this.checkCol.HeaderText = "";
            this.checkCol.Name = "checkCol";
            this.checkCol.TrueValue = "true";
            this.checkCol.Width = 30;
            // 
            // chkAplicaEnRem
            // 
            this.chkAplicaEnRem.AutoSize = true;
            this.chkAplicaEnRem.Location = new System.Drawing.Point(12, 444);
            this.chkAplicaEnRem.Name = "chkAplicaEnRem";
            this.chkAplicaEnRem.Size = new System.Drawing.Size(261, 17);
            this.chkAplicaEnRem.TabIndex = 12;
            this.chkAplicaEnRem.Text = "Aplicar porcentaje sobre remunerativos del recibo.";
            this.chkAplicaEnRem.UseVisualStyleBackColor = true;
            this.chkAplicaEnRem.CheckedChanged += new System.EventHandler(this.chkAplicaEnRem_CheckedChanged);
            // 
            // SeleccionarComponentesDeduccionPorcentual
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(370, 561);
            this.Controls.Add(this.chkAplicaEnRem);
            this.Controls.Add(this.tbxPorcentaje);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnAceptar);
            this.Controls.Add(this.lblTip);
            this.Controls.Add(this.dgvConceptosList);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SeleccionarComponentesDeduccionPorcentual";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Deducciones: Porcentaje(%) - Componentes";
            this.Load += new System.EventHandler(this.PorcDedComp_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvConceptosList)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tbxPorcentaje;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnAceptar;
        private System.Windows.Forms.Label lblTip;
        private System.Windows.Forms.DataGridView dgvConceptosList;
        private System.Windows.Forms.DataGridViewCheckBoxColumn checkCol;
        private System.Windows.Forms.CheckBox chkAplicaEnRem;
    }
}