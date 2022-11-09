
namespace _logueo_v2
{
    partial class registroU
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtregistnom = new System.Windows.Forms.TextBox();
            this.txtregusu = new System.Windows.Forms.TextBox();
            this.txtregcontra = new System.Windows.Forms.TextBox();
            this.btnregistrar = new System.Windows.Forms.Button();
            this.btnlimpiar = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.btnregresar1 = new System.Windows.Forms.Button();
            this.epcampos2 = new System.Windows.Forms.ErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.epcampos2)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 47);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(99, 24);
            this.label1.TabIndex = 0;
            this.label1.Text = "NOMBRE";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(12, 119);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(100, 24);
            this.label2.TabIndex = 1;
            this.label2.Text = "USUARIO";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(12, 194);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(167, 25);
            this.label3.TabIndex = 2;
            this.label3.Text = "CONTRASEÑA";
            // 
            // txtregistnom
            // 
            this.txtregistnom.Location = new System.Drawing.Point(27, 74);
            this.txtregistnom.Name = "txtregistnom";
            this.txtregistnom.Size = new System.Drawing.Size(213, 20);
            this.txtregistnom.TabIndex = 3;
            // 
            // txtregusu
            // 
            this.txtregusu.Location = new System.Drawing.Point(27, 157);
            this.txtregusu.Name = "txtregusu";
            this.txtregusu.Size = new System.Drawing.Size(213, 20);
            this.txtregusu.TabIndex = 4;
            // 
            // txtregcontra
            // 
            this.txtregcontra.Location = new System.Drawing.Point(27, 232);
            this.txtregcontra.Name = "txtregcontra";
            this.txtregcontra.Size = new System.Drawing.Size(213, 20);
            this.txtregcontra.TabIndex = 5;
            // 
            // btnregistrar
            // 
            this.btnregistrar.Location = new System.Drawing.Point(310, 38);
            this.btnregistrar.Name = "btnregistrar";
            this.btnregistrar.Size = new System.Drawing.Size(152, 47);
            this.btnregistrar.TabIndex = 6;
            this.btnregistrar.Text = "REGISTRAR USUARIO";
            this.btnregistrar.UseVisualStyleBackColor = true;
            this.btnregistrar.Click += new System.EventHandler(this.btnregistrar_Click);
            // 
            // btnlimpiar
            // 
            this.btnlimpiar.Location = new System.Drawing.Point(319, 157);
            this.btnlimpiar.Name = "btnlimpiar";
            this.btnlimpiar.Size = new System.Drawing.Size(143, 47);
            this.btnlimpiar.TabIndex = 7;
            this.btnlimpiar.Text = "NUEVO USUARIO";
            this.btnlimpiar.UseVisualStyleBackColor = true;
            this.btnlimpiar.Click += new System.EventHandler(this.btnlimpiar_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.Color.Gold;
            this.label4.Location = new System.Drawing.Point(307, 119);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(175, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "¿REGISTRAR OTRO USUSARIO?";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.ForeColor = System.Drawing.Color.Gold;
            this.label5.Location = new System.Drawing.Point(316, 235);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(150, 13);
            this.label5.TabIndex = 9;
            this.label5.Text = "¿volver a la pantalla principal?";
            // 
            // btnregresar1
            // 
            this.btnregresar1.Location = new System.Drawing.Point(319, 259);
            this.btnregresar1.Name = "btnregresar1";
            this.btnregresar1.Size = new System.Drawing.Size(143, 53);
            this.btnregresar1.TabIndex = 10;
            this.btnregresar1.Text = "regresar a la pantalla principal";
            this.btnregresar1.UseVisualStyleBackColor = true;
            this.btnregresar1.Click += new System.EventHandler(this.btnregresar1_Click);
            // 
            // epcampos2
            // 
            this.epcampos2.ContainerControl = this;
            // 
            // registroU
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.WindowFrame;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnregresar1);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.btnlimpiar);
            this.Controls.Add(this.btnregistrar);
            this.Controls.Add(this.txtregcontra);
            this.Controls.Add(this.txtregusu);
            this.Controls.Add(this.txtregistnom);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "registroU";
            this.Text = "registroU";
            ((System.ComponentModel.ISupportInitialize)(this.epcampos2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtregistnom;
        private System.Windows.Forms.TextBox txtregusu;
        private System.Windows.Forms.TextBox txtregcontra;
        private System.Windows.Forms.Button btnregistrar;
        private System.Windows.Forms.Button btnlimpiar;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnregresar1;
        private System.Windows.Forms.ErrorProvider epcampos2;
    }
}