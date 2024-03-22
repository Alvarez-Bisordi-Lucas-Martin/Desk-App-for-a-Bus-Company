namespace ViajesPlusTPI
{
    partial class FormCancelarReserva
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormCancelarReserva));
            this.comboBoxPE = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.buttonEI = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // comboBoxPE
            // 
            this.comboBoxPE.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.comboBoxPE.BackColor = System.Drawing.Color.White;
            this.comboBoxPE.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxPE.Font = new System.Drawing.Font("Comic Sans MS", 9.75F);
            this.comboBoxPE.FormattingEnabled = true;
            this.comboBoxPE.Location = new System.Drawing.Point(130, 26);
            this.comboBoxPE.Name = "comboBoxPE";
            this.comboBoxPE.Size = new System.Drawing.Size(88, 26);
            this.comboBoxPE.TabIndex = 168;
            // 
            // label5
            // 
            this.label5.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label5.BackColor = System.Drawing.Color.White;
            this.label5.Font = new System.Drawing.Font("Comic Sans MS", 9.75F);
            this.label5.Location = new System.Drawing.Point(31, 29);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(93, 18);
            this.label5.TabIndex = 167;
            this.label5.Text = "ID PASAJE";
            // 
            // buttonEI
            // 
            this.buttonEI.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.buttonEI.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.buttonEI.Font = new System.Drawing.Font("Comic Sans MS", 9.75F);
            this.buttonEI.Location = new System.Drawing.Point(25, 68);
            this.buttonEI.Name = "buttonEI";
            this.buttonEI.Size = new System.Drawing.Size(193, 37);
            this.buttonEI.TabIndex = 166;
            this.buttonEI.Text = "ELIMINAR";
            this.buttonEI.UseVisualStyleBackColor = false;
            this.buttonEI.Click += new System.EventHandler(this.buttonEI_Click);
            // 
            // FormCancelarReserva
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.BackgroundImage = global::ViajesPlusTPI.Properties.Resources.FondoModerno;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(248, 127);
            this.Controls.Add(this.comboBoxPE);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.buttonEI);
            this.DoubleBuffered = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormCancelarReserva";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "CANCELAR RESERVA";
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.ComboBox comboBoxPE;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button buttonEI;
    }
}