namespace ViajesPlusTPI
{
    partial class FormAbonar
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormAbonar));
            this.comboBoxPA = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtMonto = new System.Windows.Forms.TextBox();
            this.buttonAbonar = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // comboBoxPA
            // 
            this.comboBoxPA.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.comboBoxPA.BackColor = System.Drawing.Color.White;
            this.comboBoxPA.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxPA.Font = new System.Drawing.Font("Comic Sans MS", 9.75F);
            this.comboBoxPA.FormattingEnabled = true;
            this.comboBoxPA.Location = new System.Drawing.Point(117, 35);
            this.comboBoxPA.Name = "comboBoxPA";
            this.comboBoxPA.Size = new System.Drawing.Size(177, 26);
            this.comboBoxPA.TabIndex = 146;
            this.comboBoxPA.SelectedIndexChanged += new System.EventHandler(this.comboBoxPA_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label2.BackColor = System.Drawing.Color.White;
            this.label2.Font = new System.Drawing.Font("Comic Sans MS", 9.75F);
            this.label2.Location = new System.Drawing.Point(39, 38);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(72, 18);
            this.label2.TabIndex = 145;
            this.label2.Text = "PASAJE";
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label4.BackColor = System.Drawing.Color.White;
            this.label4.Font = new System.Drawing.Font("Comic Sans MS", 9.75F);
            this.label4.Location = new System.Drawing.Point(39, 79);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(72, 18);
            this.label4.TabIndex = 144;
            this.label4.Text = "MONTO";
            // 
            // txtMonto
            // 
            this.txtMonto.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtMonto.Font = new System.Drawing.Font("Comic Sans MS", 9.75F);
            this.txtMonto.Location = new System.Drawing.Point(117, 76);
            this.txtMonto.Name = "txtMonto";
            this.txtMonto.Size = new System.Drawing.Size(177, 26);
            this.txtMonto.TabIndex = 143;
            this.txtMonto.TextChanged += new System.EventHandler(this.txtMonto_TextChanged);
            // 
            // buttonAbonar
            // 
            this.buttonAbonar.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.buttonAbonar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.buttonAbonar.Font = new System.Drawing.Font("Comic Sans MS", 9.75F);
            this.buttonAbonar.Location = new System.Drawing.Point(36, 118);
            this.buttonAbonar.Name = "buttonAbonar";
            this.buttonAbonar.Size = new System.Drawing.Size(258, 37);
            this.buttonAbonar.TabIndex = 142;
            this.buttonAbonar.Text = "ABONAR";
            this.buttonAbonar.UseVisualStyleBackColor = false;
            this.buttonAbonar.Click += new System.EventHandler(this.buttonAbonar_Click);
            // 
            // FormAbonar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.BackgroundImage = global::ViajesPlusTPI.Properties.Resources.FondoModerno;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(330, 189);
            this.Controls.Add(this.comboBoxPA);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtMonto);
            this.Controls.Add(this.buttonAbonar);
            this.DoubleBuffered = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormAbonar";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ABONAR";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox comboBoxPA;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtMonto;
        private System.Windows.Forms.Button buttonAbonar;
    }
}