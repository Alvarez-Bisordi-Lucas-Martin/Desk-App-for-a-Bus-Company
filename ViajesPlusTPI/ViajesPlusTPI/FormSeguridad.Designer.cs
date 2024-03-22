namespace ViajesPlusTPI
{
    partial class FormSeguridad
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormSeguridad));
            this.buttonInsertar = new System.Windows.Forms.Button();
            this.buttonVer = new System.Windows.Forms.Button();
            this.txtContraseña = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // buttonInsertar
            // 
            this.buttonInsertar.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.buttonInsertar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.buttonInsertar.Font = new System.Drawing.Font("Comic Sans MS", 9.75F);
            this.buttonInsertar.ForeColor = System.Drawing.Color.Black;
            this.buttonInsertar.Location = new System.Drawing.Point(248, 43);
            this.buttonInsertar.Name = "buttonInsertar";
            this.buttonInsertar.Size = new System.Drawing.Size(155, 34);
            this.buttonInsertar.TabIndex = 6;
            this.buttonInsertar.Text = "INGRESAR";
            this.buttonInsertar.UseVisualStyleBackColor = false;
            this.buttonInsertar.Click += new System.EventHandler(this.buttonInsertar_Click);
            // 
            // buttonVer
            // 
            this.buttonVer.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.buttonVer.BackColor = System.Drawing.Color.White;
            this.buttonVer.BackgroundImage = global::ViajesPlusTPI.Properties.Resources.Ojo;
            this.buttonVer.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.buttonVer.Font = new System.Drawing.Font("Comic Sans MS", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonVer.Location = new System.Drawing.Point(216, 47);
            this.buttonVer.Name = "buttonVer";
            this.buttonVer.Size = new System.Drawing.Size(26, 26);
            this.buttonVer.TabIndex = 23;
            this.buttonVer.UseVisualStyleBackColor = false;
            this.buttonVer.Click += new System.EventHandler(this.buttonVer_Click);
            // 
            // txtContraseña
            // 
            this.txtContraseña.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtContraseña.BackColor = System.Drawing.Color.White;
            this.txtContraseña.Font = new System.Drawing.Font("Comic Sans MS", 9.75F);
            this.txtContraseña.Location = new System.Drawing.Point(55, 47);
            this.txtContraseña.Name = "txtContraseña";
            this.txtContraseña.Size = new System.Drawing.Size(155, 26);
            this.txtContraseña.TabIndex = 22;
            this.txtContraseña.Text = "Ingrese la Contraseña...";
            this.txtContraseña.TextChanged += new System.EventHandler(this.txtContraseña_TextChanged);
            // 
            // FormSeguridad
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.BackgroundImage = global::ViajesPlusTPI.Properties.Resources.FondoModerno;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(460, 117);
            this.Controls.Add(this.buttonVer);
            this.Controls.Add(this.txtContraseña);
            this.Controls.Add(this.buttonInsertar);
            this.DoubleBuffered = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormSeguridad";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SEGURIDAD";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonInsertar;
        private System.Windows.Forms.Button buttonVer;
        private System.Windows.Forms.TextBox txtContraseña;
    }
}