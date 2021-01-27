namespace AliS_WinVer
{
    partial class Calculator
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Calculator));
            this.dgvConceptosList = new System.Windows.Forms.DataGridView();
            this.btnSumar = new System.Windows.Forms.Button();
            this.btnRestar = new System.Windows.Forms.Button();
            this.btnMultiplicar = new System.Windows.Forms.Button();
            this.btnDividir = new System.Windows.Forms.Button();
            this.btnParentesis1 = new System.Windows.Forms.Button();
            this.btnParentesis2 = new System.Windows.Forms.Button();
            this.tbxFormula = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.btnCalcular = new System.Windows.Forms.Button();
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
            this.dgvConceptosList.Location = new System.Drawing.Point(12, 30);
            this.dgvConceptosList.Name = "dgvConceptosList";
            this.dgvConceptosList.ReadOnly = true;
            this.dgvConceptosList.RowHeadersVisible = false;
            this.dgvConceptosList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvConceptosList.Size = new System.Drawing.Size(537, 246);
            this.dgvConceptosList.TabIndex = 0;
            this.dgvConceptosList.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvConceptosList_CellDoubleClick);
            // 
            // btnSumar
            // 
            this.btnSumar.Location = new System.Drawing.Point(230, 282);
            this.btnSumar.Name = "btnSumar";
            this.btnSumar.Size = new System.Drawing.Size(23, 23);
            this.btnSumar.TabIndex = 1;
            this.btnSumar.Text = "+";
            this.btnSumar.UseVisualStyleBackColor = true;
            this.btnSumar.Click += new System.EventHandler(this.btnSumar_Click);
            // 
            // btnRestar
            // 
            this.btnRestar.Location = new System.Drawing.Point(259, 282);
            this.btnRestar.Name = "btnRestar";
            this.btnRestar.Size = new System.Drawing.Size(23, 23);
            this.btnRestar.TabIndex = 2;
            this.btnRestar.Text = "-";
            this.btnRestar.UseVisualStyleBackColor = true;
            this.btnRestar.Click += new System.EventHandler(this.btnRestar_Click);
            // 
            // btnMultiplicar
            // 
            this.btnMultiplicar.Location = new System.Drawing.Point(288, 282);
            this.btnMultiplicar.Name = "btnMultiplicar";
            this.btnMultiplicar.Size = new System.Drawing.Size(23, 23);
            this.btnMultiplicar.TabIndex = 3;
            this.btnMultiplicar.Text = "*";
            this.btnMultiplicar.UseVisualStyleBackColor = true;
            this.btnMultiplicar.Click += new System.EventHandler(this.btnMultiplicar_Click);
            // 
            // btnDividir
            // 
            this.btnDividir.Location = new System.Drawing.Point(317, 282);
            this.btnDividir.Name = "btnDividir";
            this.btnDividir.Size = new System.Drawing.Size(23, 23);
            this.btnDividir.TabIndex = 4;
            this.btnDividir.Text = "/";
            this.btnDividir.UseVisualStyleBackColor = true;
            this.btnDividir.Click += new System.EventHandler(this.btnDividir_Click);
            // 
            // btnParentesis1
            // 
            this.btnParentesis1.Location = new System.Drawing.Point(346, 282);
            this.btnParentesis1.Name = "btnParentesis1";
            this.btnParentesis1.Size = new System.Drawing.Size(23, 23);
            this.btnParentesis1.TabIndex = 5;
            this.btnParentesis1.Text = "(";
            this.btnParentesis1.UseVisualStyleBackColor = true;
            this.btnParentesis1.Click += new System.EventHandler(this.btnParentesis1_Click);
            // 
            // btnParentesis2
            // 
            this.btnParentesis2.Location = new System.Drawing.Point(375, 282);
            this.btnParentesis2.Name = "btnParentesis2";
            this.btnParentesis2.Size = new System.Drawing.Size(23, 23);
            this.btnParentesis2.TabIndex = 6;
            this.btnParentesis2.Text = ")";
            this.btnParentesis2.UseVisualStyleBackColor = true;
            this.btnParentesis2.Click += new System.EventHandler(this.btnParentesis2_Click);
            // 
            // tbxFormula
            // 
            this.tbxFormula.Location = new System.Drawing.Point(59, 326);
            this.tbxFormula.Name = "tbxFormula";
            this.tbxFormula.Size = new System.Drawing.Size(490, 20);
            this.tbxFormula.TabIndex = 7;
            this.tbxFormula.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbxFormula_KeyPress);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 329);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 13);
            this.label1.TabIndex = 8;
            this.label1.Text = "Fórmula";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(162, 287);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(62, 13);
            this.label2.TabIndex = 9;
            this.label2.Text = "Operadores";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 14);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(58, 13);
            this.label3.TabIndex = 10;
            this.label3.Text = "Conceptos";
            // 
            // btnCalcular
            // 
            this.btnCalcular.Location = new System.Drawing.Point(243, 364);
            this.btnCalcular.Name = "btnCalcular";
            this.btnCalcular.Size = new System.Drawing.Size(75, 23);
            this.btnCalcular.TabIndex = 11;
            this.btnCalcular.Text = "Calcular";
            this.btnCalcular.UseVisualStyleBackColor = true;
            this.btnCalcular.Click += new System.EventHandler(this.btnCalcular_Click);
            // 
            // Calculator
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(561, 397);
            this.Controls.Add(this.btnCalcular);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tbxFormula);
            this.Controls.Add(this.btnParentesis2);
            this.Controls.Add(this.btnParentesis1);
            this.Controls.Add(this.btnDividir);
            this.Controls.Add(this.btnMultiplicar);
            this.Controls.Add(this.btnRestar);
            this.Controls.Add(this.btnSumar);
            this.Controls.Add(this.dgvConceptosList);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Calculator";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Calculadora";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Calculator_FormClosing);
            this.Load += new System.EventHandler(this.Calculator_Load);
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
        private System.Windows.Forms.TextBox tbxFormula;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnCalcular;
    }
}