namespace ViajesPlusTPI
{
    partial class FormCategoria
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormCategoria));
            this.comboBoxIDCV = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.buttonVer = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // comboBoxIDCV
            // 
            this.comboBoxIDCV.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.comboBoxIDCV.BackColor = System.Drawing.Color.White;
            this.comboBoxIDCV.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxIDCV.Font = new System.Drawing.Font("Comic Sans MS", 9.75F);
            this.comboBoxIDCV.FormattingEnabled = true;
            this.comboBoxIDCV.Location = new System.Drawing.Point(167, 31);
            this.comboBoxIDCV.Name = "comboBoxIDCV";
            this.comboBoxIDCV.Size = new System.Drawing.Size(84, 26);
            this.comboBoxIDCV.TabIndex = 160;
            // 
            // label5
            // 
            this.label5.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label5.BackColor = System.Drawing.Color.White;
            this.label5.Font = new System.Drawing.Font("Comic Sans MS", 9.75F);
            this.label5.Location = new System.Drawing.Point(46, 34);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(115, 18);
            this.label5.TabIndex = 159;
            this.label5.Text = "CATEGORIA";
            // 
            // buttonVer
            // 
            this.buttonVer.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.buttonVer.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.buttonVer.Font = new System.Drawing.Font("Comic Sans MS", 9.75F);
            this.buttonVer.Location = new System.Drawing.Point(40, 73);
            this.buttonVer.Name = "buttonVer";
            this.buttonVer.Size = new System.Drawing.Size(211, 37);
            this.buttonVer.TabIndex = 158;
            this.buttonVer.Text = "VER";
            this.buttonVer.UseVisualStyleBackColor = false;
            this.buttonVer.Click += new System.EventHandler(this.buttonVer_Click);
            // 
            // FormCategoria
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.BackgroundImage = global::ViajesPlusTPI.Properties.Resources.FondoModerno;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(291, 140);
            this.Controls.Add(this.comboBoxIDCV);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.buttonVer);
            this.DoubleBuffered = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormCategoria";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "CATEGORIA";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox comboBoxIDCV;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button buttonVer;
    }
}