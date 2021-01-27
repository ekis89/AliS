namespace AliS_WinVer
{
    partial class SelectorLegajo
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SelectorLegajo));
            this.dgvLegajos = new System.Windows.Forms.DataGridView();
            this.btnLiquidaciones = new System.Windows.Forms.Button();
            this.lblLegajos = new System.Windows.Forms.Label();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLegajos)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvLegajos
            // 
            this.dgvLegajos.AllowUserToAddRows = false;
            this.dgvLegajos.AllowUserToDeleteRows = false;
            this.dgvLegajos.AllowUserToResizeColumns = false;
            this.dgvLegajos.AllowUserToResizeRows = false;
            this.dgvLegajos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvLegajos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvLegajos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvLegajos.Location = new System.Drawing.Point(3, 25);
            this.dgvLegajos.MultiSelect = false;
            this.dgvLegajos.Name = "dgvLegajos";
            this.dgvLegajos.ReadOnly = true;
            this.dgvLegajos.RowHeadersVisible = false;
            this.dgvLegajos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvLegajos.Size = new System.Drawing.Size(795, 382);
            this.dgvLegajos.TabIndex = 0;
            this.dgvLegajos.RowEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvLegajos_RowEnter);
            // 
            // btnLiquidaciones
            // 
            this.btnLiquidaciones.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btnLiquidaciones.Location = new System.Drawing.Point(713, 416);
            this.btnLiquidaciones.Name = "btnLiquidaciones";
            this.btnLiquidaciones.Size = new System.Drawing.Size(85, 23);
            this.btnLiquidaciones.TabIndex = 1;
            this.btnLiquidaciones.Text = "Liquidaciones";
            this.btnLiquidaciones.UseVisualStyleBackColor = true;
            this.btnLiquidaciones.Click += new System.EventHandler(this.btnLiquidaciones_Click);
            // 
            // lblLegajos
            // 
            this.lblLegajos.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblLegajos.AutoSize = true;
            this.lblLegajos.Location = new System.Drawing.Point(3, 4);
            this.lblLegajos.Name = "lblLegajos";
            this.lblLegajos.Size = new System.Drawing.Size(47, 13);
            this.lblLegajos.TabIndex = 2;
            this.lblLegajos.Text = "Legajos:";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.lblLegajos, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.btnLiquidaciones, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.dgvLegajos, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5.440414F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 94.55959F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 34F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(801, 445);
            this.tableLayoutPanel1.TabIndex = 3;
            // 
            // SelectorLegajo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(801, 445);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "SelectorLegajo";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SelectorLegajo";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.SelectorLegajo_FormClosing);
            this.Load += new System.EventHandler(this.SelectorLegajo_Load);
            this.Enter += new System.EventHandler(this.SelectorLegajo_Enter);
            ((System.ComponentModel.ISupportInitialize)(this.dgvLegajos)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvLegajos;
        private System.Windows.Forms.Button btnLiquidaciones;
        private System.Windows.Forms.Label lblLegajos;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
    }
}