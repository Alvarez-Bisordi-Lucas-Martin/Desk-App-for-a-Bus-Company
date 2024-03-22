namespace ViajesPlusTPI
{
    partial class FormConsulta
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormConsulta));
            this.label1 = new System.Windows.Forms.Label();
            this.dataGridViewI = new System.Windows.Forms.DataGridView();
            this.txtConsulta = new System.Windows.Forms.TextBox();
            this.buttonHacer = new System.Windows.Forms.Button();
            this.buttonLimpiar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewI)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Comic Sans MS", 9.75F);
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(36, 35);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(153, 18);
            this.label1.TabIndex = 248;
            this.label1.Text = "EJECUTAR CONSULTA";
            // 
            // dataGridViewI
            // 
            this.dataGridViewI.AllowUserToAddRows = false;
            this.dataGridViewI.AllowUserToDeleteRows = false;
            this.dataGridViewI.AllowUserToResizeColumns = false;
            this.dataGridViewI.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Comic Sans MS", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.Black;
            this.dataGridViewI.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridViewI.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridViewI.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewI.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.dataGridViewI.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridViewI.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Comic Sans MS", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewI.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridViewI.ColumnHeadersHeight = 30;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Comic Sans MS", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewI.DefaultCellStyle = dataGridViewCellStyle3;
            this.dataGridViewI.EnableHeadersVisualStyles = false;
            this.dataGridViewI.Location = new System.Drawing.Point(39, 266);
            this.dataGridViewI.Name = "dataGridViewI";
            this.dataGridViewI.ReadOnly = true;
            this.dataGridViewI.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.dataGridViewI.RowHeadersVisible = false;
            this.dataGridViewI.RowTemplate.Height = 30;
            this.dataGridViewI.ShowEditingIcon = false;
            this.dataGridViewI.Size = new System.Drawing.Size(738, 226);
            this.dataGridViewI.TabIndex = 245;
            // 
            // txtConsulta
            // 
            this.txtConsulta.Font = new System.Drawing.Font("Comic Sans MS", 9.75F);
            this.txtConsulta.Location = new System.Drawing.Point(39, 81);
            this.txtConsulta.Multiline = true;
            this.txtConsulta.Name = "txtConsulta";
            this.txtConsulta.Size = new System.Drawing.Size(329, 151);
            this.txtConsulta.TabIndex = 249;
            this.txtConsulta.Text = "Inserte una consulta...";
            // 
            // buttonHacer
            // 
            this.buttonHacer.BackColor = System.Drawing.Color.Transparent;
            this.buttonHacer.BackgroundImage = global::ViajesPlusTPI.Properties.Resources.play;
            this.buttonHacer.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.buttonHacer.Font = new System.Drawing.Font("Comic Sans MS", 9.75F);
            this.buttonHacer.Location = new System.Drawing.Point(195, 28);
            this.buttonHacer.Name = "buttonHacer";
            this.buttonHacer.Size = new System.Drawing.Size(34, 33);
            this.buttonHacer.TabIndex = 250;
            this.buttonHacer.UseVisualStyleBackColor = false;
            this.buttonHacer.Click += new System.EventHandler(this.buttonHacer_Click);
            // 
            // buttonLimpiar
            // 
            this.buttonLimpiar.BackColor = System.Drawing.Color.Transparent;
            this.buttonLimpiar.BackgroundImage = global::ViajesPlusTPI.Properties.Resources.basura;
            this.buttonLimpiar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.buttonLimpiar.Font = new System.Drawing.Font("Comic Sans MS", 9.75F);
            this.buttonLimpiar.Location = new System.Drawing.Point(235, 28);
            this.buttonLimpiar.Name = "buttonLimpiar";
            this.buttonLimpiar.Size = new System.Drawing.Size(34, 33);
            this.buttonLimpiar.TabIndex = 251;
            this.buttonLimpiar.UseVisualStyleBackColor = false;
            this.buttonLimpiar.Click += new System.EventHandler(this.buttonLimpiar_Click);
            // 
            // FormConsulta
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.BackgroundImage = global::ViajesPlusTPI.Properties.Resources.FondoModerno;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(822, 523);
            this.Controls.Add(this.buttonLimpiar);
            this.Controls.Add(this.buttonHacer);
            this.Controls.Add(this.txtConsulta);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dataGridViewI);
            this.DoubleBuffered = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormConsulta";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "CONSULTA";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewI)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dataGridViewI;
        private System.Windows.Forms.TextBox txtConsulta;
        private System.Windows.Forms.Button buttonHacer;
        private System.Windows.Forms.Button buttonLimpiar;
    }
}