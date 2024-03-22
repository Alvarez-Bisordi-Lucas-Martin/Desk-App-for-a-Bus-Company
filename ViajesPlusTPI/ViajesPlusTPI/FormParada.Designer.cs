namespace ViajesPlusTPI
{
    partial class FormParada
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormParada));
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtLon = new System.Windows.Forms.TextBox();
            this.txtLat = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtParada = new System.Windows.Forms.TextBox();
            this.buttonEliminar = new System.Windows.Forms.Button();
            this.gMapControlMap = new GMap.NET.WindowsForms.GMapControl();
            this.label4 = new System.Windows.Forms.Label();
            this.txtCiudad = new System.Windows.Forms.TextBox();
            this.buttonAgregar = new System.Windows.Forms.Button();
            this.buttonLimpiar = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.BackColor = System.Drawing.Color.White;
            this.label2.Font = new System.Drawing.Font("Comic Sans MS", 9.75F);
            this.label2.Location = new System.Drawing.Point(647, 102);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(119, 18);
            this.label2.TabIndex = 26;
            this.label2.Text = "LATITUD";
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.BackColor = System.Drawing.Color.White;
            this.label3.Font = new System.Drawing.Font("Comic Sans MS", 9.75F);
            this.label3.Location = new System.Drawing.Point(647, 138);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(119, 18);
            this.label3.TabIndex = 25;
            this.label3.Text = "LONGITUD";
            // 
            // txtLon
            // 
            this.txtLon.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtLon.BackColor = System.Drawing.SystemColors.Window;
            this.txtLon.Font = new System.Drawing.Font("Comic Sans MS", 9.75F);
            this.txtLon.Location = new System.Drawing.Point(772, 135);
            this.txtLon.Name = "txtLon";
            this.txtLon.Size = new System.Drawing.Size(169, 26);
            this.txtLon.TabIndex = 24;
            // 
            // txtLat
            // 
            this.txtLat.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtLat.Font = new System.Drawing.Font("Comic Sans MS", 9.75F);
            this.txtLat.Location = new System.Drawing.Point(772, 99);
            this.txtLat.Name = "txtLat";
            this.txtLat.Size = new System.Drawing.Size(169, 26);
            this.txtLat.TabIndex = 23;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.BackColor = System.Drawing.Color.White;
            this.label1.Font = new System.Drawing.Font("Comic Sans MS", 9.75F);
            this.label1.Location = new System.Drawing.Point(647, 65);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(119, 18);
            this.label1.TabIndex = 21;
            this.label1.Text = "NOMBRE PARADA";
            // 
            // txtParada
            // 
            this.txtParada.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtParada.Font = new System.Drawing.Font("Comic Sans MS", 9.75F);
            this.txtParada.Location = new System.Drawing.Point(772, 62);
            this.txtParada.Name = "txtParada";
            this.txtParada.Size = new System.Drawing.Size(169, 26);
            this.txtParada.TabIndex = 20;
            this.txtParada.TextChanged += new System.EventHandler(this.txtParada_TextChanged);
            // 
            // buttonEliminar
            // 
            this.buttonEliminar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonEliminar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.buttonEliminar.Font = new System.Drawing.Font("Comic Sans MS", 9.75F);
            this.buttonEliminar.Location = new System.Drawing.Point(645, 229);
            this.buttonEliminar.Name = "buttonEliminar";
            this.buttonEliminar.Size = new System.Drawing.Size(296, 34);
            this.buttonEliminar.TabIndex = 18;
            this.buttonEliminar.Text = "ELIMINAR";
            this.buttonEliminar.UseVisualStyleBackColor = false;
            this.buttonEliminar.Click += new System.EventHandler(this.buttonEliminar_Click);
            // 
            // gMapControlMap
            // 
            this.gMapControlMap.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gMapControlMap.AutoScroll = true;
            this.gMapControlMap.Bearing = 0F;
            this.gMapControlMap.CanDragMap = true;
            this.gMapControlMap.EmptyTileColor = System.Drawing.Color.Navy;
            this.gMapControlMap.Font = new System.Drawing.Font("Comic Sans MS", 9.75F);
            this.gMapControlMap.GrayScaleMode = false;
            this.gMapControlMap.HelperLineOption = GMap.NET.WindowsForms.HelperLineOptions.DontShow;
            this.gMapControlMap.LevelsKeepInMemmory = 5;
            this.gMapControlMap.Location = new System.Drawing.Point(26, 26);
            this.gMapControlMap.MarkersEnabled = true;
            this.gMapControlMap.MaxZoom = 24;
            this.gMapControlMap.MinZoom = 0;
            this.gMapControlMap.MouseWheelZoomEnabled = true;
            this.gMapControlMap.MouseWheelZoomType = GMap.NET.MouseWheelZoomType.MousePositionAndCenter;
            this.gMapControlMap.Name = "gMapControlMap";
            this.gMapControlMap.NegativeMode = false;
            this.gMapControlMap.PolygonsEnabled = true;
            this.gMapControlMap.RetryLoadTile = 0;
            this.gMapControlMap.RoutesEnabled = true;
            this.gMapControlMap.ScaleMode = GMap.NET.WindowsForms.ScaleModes.Integer;
            this.gMapControlMap.SelectedAreaFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(65)))), ((int)(((byte)(105)))), ((int)(((byte)(225)))));
            this.gMapControlMap.ShowTileGridLines = false;
            this.gMapControlMap.Size = new System.Drawing.Size(586, 476);
            this.gMapControlMap.TabIndex = 17;
            this.gMapControlMap.Zoom = 5D;
            this.gMapControlMap.OnMarkerClick += new GMap.NET.WindowsForms.MarkerClick(this.gMapControlMap_OnMarkerClick);
            this.gMapControlMap.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.gMapControlMap_MouseDoubleClick);
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.White;
            this.label4.Font = new System.Drawing.Font("Comic Sans MS", 9.75F);
            this.label4.Location = new System.Drawing.Point(647, 29);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(119, 18);
            this.label4.TabIndex = 30;
            this.label4.Text = "NOMBRE CIUDAD";
            // 
            // txtCiudad
            // 
            this.txtCiudad.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtCiudad.Font = new System.Drawing.Font("Comic Sans MS", 9.75F);
            this.txtCiudad.Location = new System.Drawing.Point(772, 26);
            this.txtCiudad.Name = "txtCiudad";
            this.txtCiudad.Size = new System.Drawing.Size(169, 26);
            this.txtCiudad.TabIndex = 29;
            this.txtCiudad.TextChanged += new System.EventHandler(this.txtCiudad_TextChanged);
            // 
            // buttonAgregar
            // 
            this.buttonAgregar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonAgregar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.buttonAgregar.Font = new System.Drawing.Font("Comic Sans MS", 9.75F);
            this.buttonAgregar.Location = new System.Drawing.Point(645, 179);
            this.buttonAgregar.Name = "buttonAgregar";
            this.buttonAgregar.Size = new System.Drawing.Size(296, 34);
            this.buttonAgregar.TabIndex = 31;
            this.buttonAgregar.Text = "AGREGAR";
            this.buttonAgregar.UseVisualStyleBackColor = false;
            this.buttonAgregar.Click += new System.EventHandler(this.buttonAgregar_Click);
            // 
            // buttonLimpiar
            // 
            this.buttonLimpiar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonLimpiar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.buttonLimpiar.Font = new System.Drawing.Font("Comic Sans MS", 9.75F);
            this.buttonLimpiar.Location = new System.Drawing.Point(645, 280);
            this.buttonLimpiar.Name = "buttonLimpiar";
            this.buttonLimpiar.Size = new System.Drawing.Size(296, 34);
            this.buttonLimpiar.TabIndex = 32;
            this.buttonLimpiar.Text = "LIMPIAR";
            this.buttonLimpiar.UseVisualStyleBackColor = false;
            this.buttonLimpiar.Click += new System.EventHandler(this.buttonLimpiar_Click);
            // 
            // FormParada
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.BackgroundImage = global::ViajesPlusTPI.Properties.Resources.FondoModerno;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(974, 528);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.buttonLimpiar);
            this.Controls.Add(this.buttonAgregar);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtCiudad);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtLon);
            this.Controls.Add(this.txtLat);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtParada);
            this.Controls.Add(this.buttonEliminar);
            this.Controls.Add(this.gMapControlMap);
            this.DoubleBuffered = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormParada";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "PARADA";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtLon;
        private System.Windows.Forms.TextBox txtLat;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtParada;
        private System.Windows.Forms.Button buttonEliminar;
        private GMap.NET.WindowsForms.GMapControl gMapControlMap;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtCiudad;
        private System.Windows.Forms.Button buttonAgregar;
        private System.Windows.Forms.Button buttonLimpiar;
    }
}