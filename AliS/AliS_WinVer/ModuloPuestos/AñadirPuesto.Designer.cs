namespace AliS_WinVer
{
    partial class AñadirPuesto
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
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.puestoBox = new System.Windows.Forms.TextBox();
            this.radioMen = new System.Windows.Forms.RadioButton();
            this.radioQuin = new System.Windows.Forms.RadioButton();
            this.label4 = new System.Windows.Forms.Label();
            this.BasiBox = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.label10 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(41, 58);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(66, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Descripción:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(40, 88);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(31, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Tipo:";
            // 
            // puestoBox
            // 
            this.puestoBox.Location = new System.Drawing.Point(122, 55);
            this.puestoBox.Name = "puestoBox";
            this.puestoBox.Size = new System.Drawing.Size(211, 20);
            this.puestoBox.TabIndex = 0;
            // 
            // radioMen
            // 
            this.radioMen.AutoSize = true;
            this.radioMen.Location = new System.Drawing.Point(122, 86);
            this.radioMen.Name = "radioMen";
            this.radioMen.Size = new System.Drawing.Size(65, 17);
            this.radioMen.TabIndex = 1;
            this.radioMen.TabStop = true;
            this.radioMen.Text = "Mensual";
            this.radioMen.UseVisualStyleBackColor = true;
            // 
            // radioQuin
            // 
            this.radioQuin.AutoSize = true;
            this.radioQuin.Location = new System.Drawing.Point(198, 86);
            this.radioQuin.Name = "radioQuin";
            this.radioQuin.Size = new System.Drawing.Size(135, 17);
            this.radioQuin.TabIndex = 2;
            this.radioQuin.TabStop = true;
            this.radioQuin.Text = "Jornalizado (Quincenal)";
            this.radioQuin.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(93, 126);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(92, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "Sueldo básico ($):";
            // 
            // BasiBox
            // 
            this.BasiBox.Location = new System.Drawing.Point(191, 123);
            this.BasiBox.Name = "BasiBox";
            this.BasiBox.Size = new System.Drawing.Size(100, 20);
            this.BasiBox.TabIndex = 3;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(114, 164);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 4;
            this.button1.Text = "Aceptar";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(195, 164);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 5;
            this.button2.Text = "Cancelar";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(103, 21);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(170, 17);
            this.label10.TabIndex = 21;
            this.label10.Text = "Ingrese puesto de trabajo";
            // 
            // AddPuesto
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(385, 205);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.BasiBox);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.radioQuin);
            this.Controls.Add(this.radioMen);
            this.Controls.Add(this.puestoBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AddPuesto";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Nuevo puesto";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.new_puesto_FormClosing);
            this.Load += new System.EventHandler(this.AddPuesto_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox puestoBox;
        private System.Windows.Forms.RadioButton radioMen;
        private System.Windows.Forms.RadioButton radioQuin;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox BasiBox;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label10;
    }
}