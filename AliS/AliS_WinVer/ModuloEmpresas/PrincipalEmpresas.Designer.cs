namespace AliS_WinVer
{
    partial class PrincipalEmpresas
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
            this.Aceptar = new System.Windows.Forms.Button();
            this.Cancelar = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.nombreInput = new System.Windows.Forms.TextBox();
            this.CUIT1 = new System.Windows.Forms.TextBox();
            this.localidadInput = new System.Windows.Forms.TextBox();
            this.direccionInput = new System.Windows.Forms.TextBox();
            this.telefonoInput = new System.Windows.Forms.TextBox();
            this.postalInput = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.CUIT2 = new System.Windows.Forms.TextBox();
            this.CUIT3 = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // Aceptar
            // 
            this.Aceptar.Location = new System.Drawing.Point(121, 378);
            this.Aceptar.Name = "Aceptar";
            this.Aceptar.Size = new System.Drawing.Size(75, 23);
            this.Aceptar.TabIndex = 8;
            this.Aceptar.Text = "Aceptar";
            this.Aceptar.UseVisualStyleBackColor = true;
            this.Aceptar.Click += new System.EventHandler(this.Aceptar_Click);
            // 
            // Cancelar
            // 
            this.Cancelar.Location = new System.Drawing.Point(202, 378);
            this.Cancelar.Name = "Cancelar";
            this.Cancelar.Size = new System.Drawing.Size(75, 23);
            this.Cancelar.TabIndex = 9;
            this.Cancelar.Text = "Cancelar";
            this.Cancelar.UseVisualStyleBackColor = true;
            this.Cancelar.Click += new System.EventHandler(this.Cancelar_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(67, 73);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Nombre:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(67, 123);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(44, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "C.U.I.T:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(68, 171);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(56, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Localidad:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(68, 271);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(55, 13);
            this.label4.TabIndex = 5;
            this.label4.Text = "Dirección:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(68, 321);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(52, 13);
            this.label5.TabIndex = 6;
            this.label5.Text = "Teléfono:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(76, 18);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(247, 24);
            this.label7.TabIndex = 8;
            this.label7.Text = "Ingrese los siguientes datos:";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // nombreInput
            // 
            this.nombreInput.Location = new System.Drawing.Point(146, 70);
            this.nombreInput.MaxLength = 50;
            this.nombreInput.Name = "nombreInput";
            this.nombreInput.Size = new System.Drawing.Size(186, 20);
            this.nombreInput.TabIndex = 0;
            // 
            // CUIT1
            // 
            this.CUIT1.Location = new System.Drawing.Point(146, 120);
            this.CUIT1.MaxLength = 3;
            this.CUIT1.Name = "CUIT1";
            this.CUIT1.Size = new System.Drawing.Size(37, 20);
            this.CUIT1.TabIndex = 1;
            this.CUIT1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.CUIT1_KeyPress);
            // 
            // localidadInput
            // 
            this.localidadInput.Location = new System.Drawing.Point(147, 168);
            this.localidadInput.MaxLength = 50;
            this.localidadInput.Name = "localidadInput";
            this.localidadInput.Size = new System.Drawing.Size(185, 20);
            this.localidadInput.TabIndex = 4;
            // 
            // direccionInput
            // 
            this.direccionInput.Location = new System.Drawing.Point(147, 268);
            this.direccionInput.MaxLength = 50;
            this.direccionInput.Name = "direccionInput";
            this.direccionInput.Size = new System.Drawing.Size(185, 20);
            this.direccionInput.TabIndex = 6;
            // 
            // telefonoInput
            // 
            this.telefonoInput.Location = new System.Drawing.Point(147, 318);
            this.telefonoInput.MaxLength = 20;
            this.telefonoInput.Name = "telefonoInput";
            this.telefonoInput.Size = new System.Drawing.Size(185, 20);
            this.telefonoInput.TabIndex = 7;
            this.telefonoInput.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox6_KeyPress);
            // 
            // postalInput
            // 
            this.postalInput.Location = new System.Drawing.Point(147, 218);
            this.postalInput.MaxLength = 10;
            this.postalInput.Name = "postalInput";
            this.postalInput.Size = new System.Drawing.Size(185, 20);
            this.postalInput.TabIndex = 5;
            this.postalInput.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox7_KeyPress);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(68, 221);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(74, 13);
            this.label8.TabIndex = 15;
            this.label8.Text = "Codigo postal:";
            // 
            // CUIT2
            // 
            this.CUIT2.Location = new System.Drawing.Point(189, 120);
            this.CUIT2.MaxLength = 10;
            this.CUIT2.Name = "CUIT2";
            this.CUIT2.Size = new System.Drawing.Size(100, 20);
            this.CUIT2.TabIndex = 2;
            this.CUIT2.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.CUIT2_KeyPress);
            // 
            // CUIT3
            // 
            this.CUIT3.Location = new System.Drawing.Point(295, 120);
            this.CUIT3.MaxLength = 3;
            this.CUIT3.Name = "CUIT3";
            this.CUIT3.Size = new System.Drawing.Size(37, 20);
            this.CUIT3.TabIndex = 3;
            this.CUIT3.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.CUIT3_KeyPress);
            // 
            // AddEmpresas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(399, 418);
            this.Controls.Add(this.CUIT3);
            this.Controls.Add(this.CUIT2);
            this.Controls.Add(this.postalInput);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.telefonoInput);
            this.Controls.Add(this.direccionInput);
            this.Controls.Add(this.localidadInput);
            this.Controls.Add(this.CUIT1);
            this.Controls.Add(this.nombreInput);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Cancelar);
            this.Controls.Add(this.Aceptar);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AddEmpresas";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Nueva empresa";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.add_empr_FormClosing);
            this.Load += new System.EventHandler(this.add_empr_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button Aceptar;
        private System.Windows.Forms.Button Cancelar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox nombreInput;
        private System.Windows.Forms.TextBox CUIT1;
        private System.Windows.Forms.TextBox localidadInput;
        private System.Windows.Forms.TextBox direccionInput;
        private System.Windows.Forms.TextBox telefonoInput;
        private System.Windows.Forms.TextBox postalInput;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox CUIT2;
        private System.Windows.Forms.TextBox CUIT3;
    }
}