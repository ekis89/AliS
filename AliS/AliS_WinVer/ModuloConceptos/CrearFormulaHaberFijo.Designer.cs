namespace AliS_WinVer
{
    partial class CrearFormulaHaberFijo
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
            this.dgvConceptosList = new System.Windows.Forms.DataGridView();
            this.btnSumar = new System.Windows.Forms.Button();
            this.btnRestar = new System.Windows.Forms.Button();
            this.btnMultiplicar = new System.Windows.Forms.Button();
            this.btnDividir = new System.Windows.Forms.Button();
            this.btnParentesis1 = new System.Windows.Forms.Button();
            this.btnParentesis2 = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.btnAceptar = new System.Windows.Forms.Button();
            this.btnPunto = new System.Windows.Forms.Button();
            this.tbxFormula = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvConceptosList)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvConceptosList
            // 
            this.dgvConceptosList.AllowUserToAddRows = false;
            this.dgvConceptosList.AllowUserToDeleteRows = false;
            this.dgvConceptosList.AllowUserToResizeColumns = false;
            this.dgvConceptosList.AllowUserToResizeRows = false;
            this.dgvConceptosList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvConceptosList.Location = new System.Drawing.Point(12, 71);
            this.dgvConceptosList.MultiSelect = false;
            this.dgvConceptosList.Name = "dgvConceptosList";
            this.dgvConceptosList.ReadOnly = true;
            this.dgvConceptosList.RowHeadersVisible = false;
            this.dgvConceptosList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvConceptosList.Size = new System.Drawing.Size(346, 257);
            this.dgvConceptosList.TabIndex = 4;
            this.dgvConceptosList.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvConceptosList_CellDoubleClick);
            // 
            // btnSumar
            // 
            this.btnSumar.Location = new System.Drawing.Point(80, 344);
            this.btnSumar.Name = "btnSumar";
            this.btnSumar.Size = new System.Drawing.Size(23, 23);
            this.btnSumar.TabIndex = 5;
            this.btnSumar.Text = "+";
            this.btnSumar.UseVisualStyleBackColor = true;
            this.btnSumar.Click += new System.EventHandler(this.btnSumar_Click);
            // 
            // btnRestar
            // 
            this.btnRestar.Location = new System.Drawing.Point(109, 344);
            this.btnRestar.Name = "btnRestar";
            this.btnRestar.Size = new System.Drawing.Size(23, 23);
            this.btnRestar.TabIndex = 6;
            this.btnRestar.Text = "-";
            this.btnRestar.UseVisualStyleBackColor = true;
            this.btnRestar.Click += new System.EventHandler(this.btnRestar_Click);
            // 
            // btnMultiplicar
            // 
            this.btnMultiplicar.Location = new System.Drawing.Point(138, 344);
            this.btnMultiplicar.Name = "btnMultiplicar";
            this.btnMultiplicar.Size = new System.Drawing.Size(23, 23);
            this.btnMultiplicar.TabIndex = 7;
            this.btnMultiplicar.Text = "*";
            this.btnMultiplicar.UseVisualStyleBackColor = true;
            this.btnMultiplicar.Click += new System.EventHandler(this.btnMultiplicar_Click);
            // 
            // btnDividir
            // 
            this.btnDividir.Location = new System.Drawing.Point(167, 344);
            this.btnDividir.Name = "btnDividir";
            this.btnDividir.Size = new System.Drawing.Size(23, 23);
            this.btnDividir.TabIndex = 8;
            this.btnDividir.Text = "/";
            this.btnDividir.UseVisualStyleBackColor = true;
            this.btnDividir.Click += new System.EventHandler(this.btnDividir_Click);
            // 
            // btnParentesis1
            // 
            this.btnParentesis1.Location = new System.Drawing.Point(196, 344);
            this.btnParentesis1.Name = "btnParentesis1";
            this.btnParentesis1.Size = new System.Drawing.Size(23, 23);
            this.btnParentesis1.TabIndex = 9;
            this.btnParentesis1.Text = "(";
            this.btnParentesis1.UseVisualStyleBackColor = true;
            this.btnParentesis1.Click += new System.EventHandler(this.btnParentesis1_Click);
            // 
            // btnParentesis2
            // 
            this.btnParentesis2.Location = new System.Drawing.Point(225, 344);
            this.btnParentesis2.Name = "btnParentesis2";
            this.btnParentesis2.Size = new System.Drawing.Size(23, 23);
            this.btnParentesis2.TabIndex = 10;
            this.btnParentesis2.Text = ")";
            this.btnParentesis2.UseVisualStyleBackColor = true;
            this.btnParentesis2.Click += new System.EventHandler(this.btnParentesis2_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(12, 385);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 17);
            this.label2.TabIndex = 11;
            this.label2.Text = "Fórmula";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 349);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(62, 13);
            this.label3.TabIndex = 12;
            this.label3.Text = "Operadores";
            // 
            // btnAceptar
            // 
            this.btnAceptar.Location = new System.Drawing.Point(146, 526);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(75, 23);
            this.btnAceptar.TabIndex = 13;
            this.btnAceptar.Text = "Aceptar";
            this.btnAceptar.UseVisualStyleBackColor = true;
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
            // 
            // btnPunto
            // 
            this.btnPunto.Location = new System.Drawing.Point(254, 344);
            this.btnPunto.Name = "btnPunto";
            this.btnPunto.Size = new System.Drawing.Size(23, 23);
            this.btnPunto.TabIndex = 24;
            this.btnPunto.Text = ".";
            this.btnPunto.UseVisualStyleBackColor = true;
            this.btnPunto.Click += new System.EventHandler(this.btnPunto_Click);
            // 
            // tbxFormula
            // 
            this.tbxFormula.Location = new System.Drawing.Point(12, 405);
            this.tbxFormula.Multiline = true;
            this.tbxFormula.Name = "tbxFormula";
            this.tbxFormula.Size = new System.Drawing.Size(346, 95);
            this.tbxFormula.TabIndex = 25;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(9, 45);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(300, 13);
            this.label4.TabIndex = 26;
            this.label4.Text = "Para añadir haga click dos veces sobre el concepto deseado,";
            // 
            // FormulaHab
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(370, 561);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.tbxFormula);
            this.Controls.Add(this.btnPunto);
            this.Controls.Add(this.btnAceptar);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnParentesis2);
            this.Controls.Add(this.btnParentesis1);
            this.Controls.Add(this.btnDividir);
            this.Controls.Add(this.btnMultiplicar);
            this.Controls.Add(this.btnRestar);
            this.Controls.Add(this.btnSumar);
            this.Controls.Add(this.dgvConceptosList);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormulaHab";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Haberes: Valor fijo($) - Añadir formula";
            this.Load += new System.EventHandler(this.FormulaHab_Load);
            this.Controls.SetChildIndex(this.dgvConceptosList, 0);
            this.Controls.SetChildIndex(this.btnSumar, 0);
            this.Controls.SetChildIndex(this.btnRestar, 0);
            this.Controls.SetChildIndex(this.btnMultiplicar, 0);
            this.Controls.SetChildIndex(this.btnDividir, 0);
            this.Controls.SetChildIndex(this.btnParentesis1, 0);
            this.Controls.SetChildIndex(this.btnParentesis2, 0);
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this.label3, 0);
            this.Controls.SetChildIndex(this.btnAceptar, 0);
            this.Controls.SetChildIndex(this.btnPunto, 0);
            this.Controls.SetChildIndex(this.tbxFormula, 0);
            this.Controls.SetChildIndex(this.label4, 0);
            ((System.ComponentModel.ISupportInitialize)(this.dgvConceptosList)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvConceptosList;
        private System.Windows.Forms.Button btnSumar;
        private System.Windows.Forms.Button btnRestar;
        private System.Windows.Forms.Button btnMultiplicar;
        private System.Windows.Forms.Button btnDividir;
        private System.Windows.Forms.Button btnParentesis1;
        private System.Windows.Forms.Button btnParentesis2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnAceptar;
        private System.Windows.Forms.Button btnPunto;
        private System.Windows.Forms.TextBox tbxFormula;
        private System.Windows.Forms.Label label4;
    }
}