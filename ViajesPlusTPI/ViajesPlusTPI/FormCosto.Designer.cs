namespace ViajesPlusTPI
{
    partial class FormCosto
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormCosto));
            this.txtMonto = new System.Windows.Forms.TextBox();
            this.txtUnidad = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.comboBoxIDCV = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.buttonVer = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txtMonto
            // 
            this.txtMonto.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtMonto.Font = new System.Drawing.Font("Comic Sans MS", 9.75F);
            this.txtMonto.Location = new System.Drawing.Point(136, 105);
            this.txtMonto.Name = "txtMonto";
            this.txtMonto.Size = new System.Drawing.Size(80, 26);
            this.txtMonto.TabIndex = 174;
            // 
            // txtUnidad
            // 
            this.txtUnidad.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtUnidad.Font = new System.Drawing.Font("Comic Sans MS", 9.75F);
            this.txtUnidad.Location = new System.Drawing.Point(136, 65);
            this.txtUnidad.Name = "txtUnidad";
            this.txtUnidad.Size = new System.Drawing.Size(80, 26);
            this.txtUnidad.TabIndex = 173;
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label2.BackColor = System.Drawing.Color.White;
            this.label2.Font = new System.Drawing.Font("Comic Sans MS", 9.75F);
            this.label2.Location = new System.Drawing.Point(38, 108);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(92, 18);
            this.label2.TabIndex = 172;
            this.label2.Text = "MONTO";
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label1.BackColor = System.Drawing.Color.White;
            this.label1.Font = new System.Drawing.Font("Comic Sans MS", 9.75F);
            this.label1.Location = new System.Drawing.Point(38, 68);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(92, 18);
            this.label1.TabIndex = 171;
            this.label1.Text = "UNIDAD";
            // 
            // comboBoxIDCV
            // 
            this.comboBoxIDCV.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.comboBoxIDCV.BackColor = System.Drawing.Color.White;
            this.comboBoxIDCV.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxIDCV.Font = new System.Drawing.Font("Comic Sans MS", 9.75F);
            this.comboBoxIDCV.FormattingEnabled = true;
            this.comboBoxIDCV.Location = new System.Drawing.Point(136, 28);
            this.comboBoxIDCV.Name = "comboBoxIDCV";
            this.comboBoxIDCV.Size = new System.Drawing.Size(80, 26);
            this.comboBoxIDCV.TabIndex = 170;
            // 
            // label5
            // 
            this.label5.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label5.BackColor = System.Drawing.Color.White;
            this.label5.Font = new System.Drawing.Font("Comic Sans MS", 9.75F);
            this.label5.Location = new System.Drawing.Point(38, 31);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(92, 18);
            this.label5.TabIndex = 169;
            this.label5.Text = "COSTO";
            // 
            // buttonVer
            // 
            this.buttonVer.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.buttonVer.BackColor = System.Drawing.Color.Teal;
            this.buttonVer.Font = new System.Drawing.Font("Comic Sans MS", 9.75F);
            this.buttonVer.Location = new System.Drawing.Point(32, 147);
            this.buttonVer.Name = "buttonVer";
            this.buttonVer.Size = new System.Drawing.Size(184, 37);
            this.buttonVer.TabIndex = 168;
            this.buttonVer.Text = "VER";
            this.buttonVer.UseVisualStyleBackColor = false;
            this.buttonVer.Click += new System.EventHandler(this.buttonVer_Click);
            // 
            // FormCosto
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Teal;
            this.BackgroundImage = global::ViajesPlusTPI.Properties.Resources.FondoModerno;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(251, 211);
            this.Controls.Add(this.txtMonto);
            this.Controls.Add(this.txtUnidad);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.comboBoxIDCV);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.buttonVer);
            this.DoubleBuffered = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormCosto";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "COSTO";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtMonto;
        private System.Windows.Forms.TextBox txtUnidad;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboBoxIDCV;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button buttonVer;
    }
}