namespace ViajesPlusTPI
{
    partial class FormCalidad
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormCalidad));
            this.comboBoxIDCV = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.buttonVer = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtAtencion = new System.Windows.Forms.TextBox();
            this.textCat = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // comboBoxIDCV
            // 
            this.comboBoxIDCV.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.comboBoxIDCV.BackColor = System.Drawing.Color.White;
            this.comboBoxIDCV.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxIDCV.Font = new System.Drawing.Font("Comic Sans MS", 9.75F);
            this.comboBoxIDCV.FormattingEnabled = true;
            this.comboBoxIDCV.Location = new System.Drawing.Point(139, 36);
            this.comboBoxIDCV.Name = "comboBoxIDCV";
            this.comboBoxIDCV.Size = new System.Drawing.Size(80, 26);
            this.comboBoxIDCV.TabIndex = 163;
            // 
            // label5
            // 
            this.label5.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label5.BackColor = System.Drawing.Color.White;
            this.label5.Font = new System.Drawing.Font("Comic Sans MS", 9.75F);
            this.label5.Location = new System.Drawing.Point(41, 39);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(92, 18);
            this.label5.TabIndex = 162;
            this.label5.Text = "ID CALIDAD";
            // 
            // buttonVer
            // 
            this.buttonVer.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.buttonVer.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.buttonVer.Font = new System.Drawing.Font("Comic Sans MS", 9.75F);
            this.buttonVer.Location = new System.Drawing.Point(32, 155);
            this.buttonVer.Name = "buttonVer";
            this.buttonVer.Size = new System.Drawing.Size(187, 37);
            this.buttonVer.TabIndex = 161;
            this.buttonVer.Text = "VER";
            this.buttonVer.UseVisualStyleBackColor = false;
            this.buttonVer.Click += new System.EventHandler(this.buttonVer_Click);
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label1.BackColor = System.Drawing.Color.White;
            this.label1.Font = new System.Drawing.Font("Comic Sans MS", 9.75F);
            this.label1.Location = new System.Drawing.Point(41, 76);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(92, 18);
            this.label1.TabIndex = 164;
            this.label1.Text = "ATENCION";
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label2.BackColor = System.Drawing.Color.White;
            this.label2.Font = new System.Drawing.Font("Comic Sans MS", 9.75F);
            this.label2.Location = new System.Drawing.Point(41, 116);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(92, 18);
            this.label2.TabIndex = 165;
            this.label2.Text = "CATEGORIA";
            // 
            // txtAtencion
            // 
            this.txtAtencion.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtAtencion.Font = new System.Drawing.Font("Comic Sans MS", 9.75F);
            this.txtAtencion.Location = new System.Drawing.Point(139, 73);
            this.txtAtencion.Name = "txtAtencion";
            this.txtAtencion.Size = new System.Drawing.Size(80, 26);
            this.txtAtencion.TabIndex = 166;
            // 
            // textCat
            // 
            this.textCat.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.textCat.Font = new System.Drawing.Font("Comic Sans MS", 9.75F);
            this.textCat.Location = new System.Drawing.Point(139, 113);
            this.textCat.Name = "textCat";
            this.textCat.Size = new System.Drawing.Size(80, 26);
            this.textCat.TabIndex = 167;
            // 
            // FormCalidad
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.BackgroundImage = global::ViajesPlusTPI.Properties.Resources.FondoModerno;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(258, 221);
            this.Controls.Add(this.textCat);
            this.Controls.Add(this.txtAtencion);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.comboBoxIDCV);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.buttonVer);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormCalidad";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "CALIDAD";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox comboBoxIDCV;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button buttonVer;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtAtencion;
        private System.Windows.Forms.TextBox textCat;
    }
}