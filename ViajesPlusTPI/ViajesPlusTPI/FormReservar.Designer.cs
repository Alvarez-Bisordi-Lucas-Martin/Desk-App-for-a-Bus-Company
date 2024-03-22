namespace ViajesPlusTPI
{
    partial class FormReservar
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormReservar));
            this.gMapControlMap = new GMap.NET.WindowsForms.GMapControl();
            this.label14 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.buttonVI = new System.Windows.Forms.Button();
            this.textBoxSalV = new System.Windows.Forms.TextBox();
            this.textBoxLleV = new System.Windows.Forms.TextBox();
            this.textBoxDistV = new System.Windows.Forms.TextBox();
            this.comboBoxIDV = new System.Windows.Forms.ComboBox();
            this.textBoxCantV = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.buttonMO = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.txtCiudad = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtLon = new System.Windows.Forms.TextBox();
            this.txtLat = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtParada = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.buttonMF = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.textBoxCiudadF = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.textBoxLngF = new System.Windows.Forms.TextBox();
            this.textBoxLatF = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.textBoxParadaF = new System.Windows.Forms.TextBox();
            this.label26 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.label22 = new System.Windows.Forms.Label();
            this.label24 = new System.Windows.Forms.Label();
            this.textBoxTiempo = new System.Windows.Forms.TextBox();
            this.textBoxFSalV = new System.Windows.Forms.TextBox();
            this.comboBoxIDSV = new System.Windows.Forms.ComboBox();
            this.textBoxFLleV = new System.Windows.Forms.TextBox();
            this.textBoxIDC = new System.Windows.Forms.TextBox();
            this.textBoxIDT = new System.Windows.Forms.TextBox();
            this.buttonVS = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.buttonReservar = new System.Windows.Forms.Button();
            this.txtdist = new System.Windows.Forms.TextBox();
            this.comboBoxDestino = new System.Windows.Forms.ComboBox();
            this.label10 = new System.Windows.Forms.Label();
            this.SuspendLayout();
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
            this.gMapControlMap.Location = new System.Drawing.Point(37, 23);
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
            this.gMapControlMap.Size = new System.Drawing.Size(336, 463);
            this.gMapControlMap.TabIndex = 157;
            this.gMapControlMap.Zoom = 5D;
            this.gMapControlMap.OnMarkerClick += new GMap.NET.WindowsForms.MarkerClick(this.gMapControlMap_OnMarkerClick);
            // 
            // label14
            // 
            this.label14.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label14.BackColor = System.Drawing.Color.White;
            this.label14.Font = new System.Drawing.Font("Comic Sans MS", 9.75F);
            this.label14.Location = new System.Drawing.Point(409, 67);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(163, 18);
            this.label14.TabIndex = 156;
            this.label14.Text = "ID ITINERARIO";
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label5.BackColor = System.Drawing.Color.White;
            this.label5.Font = new System.Drawing.Font("Comic Sans MS", 9.75F);
            this.label5.Location = new System.Drawing.Point(409, 189);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(163, 18);
            this.label5.TabIndex = 155;
            this.label5.Text = "DISTANCIA";
            // 
            // label11
            // 
            this.label11.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label11.BackColor = System.Drawing.Color.White;
            this.label11.Font = new System.Drawing.Font("Comic Sans MS", 9.75F);
            this.label11.Location = new System.Drawing.Point(409, 107);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(163, 18);
            this.label11.TabIndex = 154;
            this.label11.Text = "HORA SALIDA";
            // 
            // label12
            // 
            this.label12.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label12.BackColor = System.Drawing.Color.White;
            this.label12.Font = new System.Drawing.Font("Comic Sans MS", 9.75F);
            this.label12.Location = new System.Drawing.Point(409, 148);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(163, 18);
            this.label12.TabIndex = 153;
            this.label12.Text = "HORA LLEGADA";
            // 
            // label13
            // 
            this.label13.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label13.AutoSize = true;
            this.label13.BackColor = System.Drawing.Color.White;
            this.label13.Font = new System.Drawing.Font("Comic Sans MS", 9.75F);
            this.label13.Location = new System.Drawing.Point(409, 231);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(163, 18);
            this.label13.TabIndex = 152;
            this.label13.Text = "CANTIDAD DE PARADAS";
            // 
            // buttonVI
            // 
            this.buttonVI.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonVI.BackColor = System.Drawing.Color.Cyan;
            this.buttonVI.Font = new System.Drawing.Font("Comic Sans MS", 9.75F);
            this.buttonVI.Location = new System.Drawing.Point(406, 271);
            this.buttonVI.Name = "buttonVI";
            this.buttonVI.Size = new System.Drawing.Size(260, 37);
            this.buttonVI.TabIndex = 147;
            this.buttonVI.Text = "VER ITINERARIO";
            this.buttonVI.UseVisualStyleBackColor = false;
            this.buttonVI.Click += new System.EventHandler(this.buttonVI_Click_1);
            // 
            // textBoxSalV
            // 
            this.textBoxSalV.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxSalV.Font = new System.Drawing.Font("Comic Sans MS", 9.75F);
            this.textBoxSalV.Location = new System.Drawing.Point(578, 104);
            this.textBoxSalV.Name = "textBoxSalV";
            this.textBoxSalV.Size = new System.Drawing.Size(88, 26);
            this.textBoxSalV.TabIndex = 143;
            // 
            // textBoxLleV
            // 
            this.textBoxLleV.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxLleV.Font = new System.Drawing.Font("Comic Sans MS", 9.75F);
            this.textBoxLleV.Location = new System.Drawing.Point(578, 145);
            this.textBoxLleV.Name = "textBoxLleV";
            this.textBoxLleV.Size = new System.Drawing.Size(88, 26);
            this.textBoxLleV.TabIndex = 142;
            // 
            // textBoxDistV
            // 
            this.textBoxDistV.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxDistV.Font = new System.Drawing.Font("Comic Sans MS", 9.75F);
            this.textBoxDistV.Location = new System.Drawing.Point(578, 186);
            this.textBoxDistV.Name = "textBoxDistV";
            this.textBoxDistV.Size = new System.Drawing.Size(88, 26);
            this.textBoxDistV.TabIndex = 141;
            // 
            // comboBoxIDV
            // 
            this.comboBoxIDV.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBoxIDV.BackColor = System.Drawing.Color.White;
            this.comboBoxIDV.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxIDV.Font = new System.Drawing.Font("Comic Sans MS", 9.75F);
            this.comboBoxIDV.FormattingEnabled = true;
            this.comboBoxIDV.Location = new System.Drawing.Point(578, 64);
            this.comboBoxIDV.Name = "comboBoxIDV";
            this.comboBoxIDV.Size = new System.Drawing.Size(88, 26);
            this.comboBoxIDV.TabIndex = 140;
            // 
            // textBoxCantV
            // 
            this.textBoxCantV.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxCantV.Font = new System.Drawing.Font("Comic Sans MS", 9.75F);
            this.textBoxCantV.Location = new System.Drawing.Point(578, 228);
            this.textBoxCantV.Name = "textBoxCantV";
            this.textBoxCantV.Size = new System.Drawing.Size(88, 26);
            this.textBoxCantV.TabIndex = 139;
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.BackColor = System.Drawing.Color.White;
            this.label3.Font = new System.Drawing.Font("Comic Sans MS", 9.75F);
            this.label3.Location = new System.Drawing.Point(408, 463);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(119, 18);
            this.label3.TabIndex = 162;
            this.label3.Text = "LONGITUD";
            // 
            // buttonMO
            // 
            this.buttonMO.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonMO.BackColor = System.Drawing.Color.Cyan;
            this.buttonMO.Enabled = false;
            this.buttonMO.Font = new System.Drawing.Font("Comic Sans MS", 9.75F);
            this.buttonMO.Location = new System.Drawing.Point(406, 502);
            this.buttonMO.Name = "buttonMO";
            this.buttonMO.Size = new System.Drawing.Size(260, 34);
            this.buttonMO.TabIndex = 166;
            this.buttonMO.Text = "MARCAR ORIGEN";
            this.buttonMO.UseVisualStyleBackColor = false;
            this.buttonMO.Click += new System.EventHandler(this.buttonMO_Click);
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.White;
            this.label4.Font = new System.Drawing.Font("Comic Sans MS", 9.75F);
            this.label4.Location = new System.Drawing.Point(408, 341);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(119, 18);
            this.label4.TabIndex = 165;
            this.label4.Text = "NOMBRE CIUDAD";
            // 
            // txtCiudad
            // 
            this.txtCiudad.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtCiudad.Font = new System.Drawing.Font("Comic Sans MS", 9.75F);
            this.txtCiudad.Location = new System.Drawing.Point(533, 338);
            this.txtCiudad.Name = "txtCiudad";
            this.txtCiudad.Size = new System.Drawing.Size(132, 26);
            this.txtCiudad.TabIndex = 164;
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.BackColor = System.Drawing.Color.White;
            this.label2.Font = new System.Drawing.Font("Comic Sans MS", 9.75F);
            this.label2.Location = new System.Drawing.Point(408, 421);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(119, 18);
            this.label2.TabIndex = 163;
            this.label2.Text = "LATITUD";
            // 
            // txtLon
            // 
            this.txtLon.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtLon.BackColor = System.Drawing.SystemColors.Window;
            this.txtLon.Font = new System.Drawing.Font("Comic Sans MS", 9.75F);
            this.txtLon.Location = new System.Drawing.Point(533, 460);
            this.txtLon.Name = "txtLon";
            this.txtLon.Size = new System.Drawing.Size(132, 26);
            this.txtLon.TabIndex = 161;
            // 
            // txtLat
            // 
            this.txtLat.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtLat.Font = new System.Drawing.Font("Comic Sans MS", 9.75F);
            this.txtLat.Location = new System.Drawing.Point(533, 418);
            this.txtLat.Name = "txtLat";
            this.txtLat.Size = new System.Drawing.Size(132, 26);
            this.txtLat.TabIndex = 160;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.BackColor = System.Drawing.Color.White;
            this.label1.Font = new System.Drawing.Font("Comic Sans MS", 9.75F);
            this.label1.Location = new System.Drawing.Point(408, 381);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(119, 18);
            this.label1.TabIndex = 159;
            this.label1.Text = "NOMBRE PARADA";
            // 
            // txtParada
            // 
            this.txtParada.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtParada.Font = new System.Drawing.Font("Comic Sans MS", 9.75F);
            this.txtParada.Location = new System.Drawing.Point(533, 378);
            this.txtParada.Name = "txtParada";
            this.txtParada.Size = new System.Drawing.Size(132, 26);
            this.txtParada.TabIndex = 158;
            // 
            // label6
            // 
            this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label6.BackColor = System.Drawing.Color.White;
            this.label6.Font = new System.Drawing.Font("Comic Sans MS", 9.75F);
            this.label6.Location = new System.Drawing.Point(712, 463);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(119, 18);
            this.label6.TabIndex = 171;
            this.label6.Text = "LONGITUD";
            // 
            // buttonMF
            // 
            this.buttonMF.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonMF.BackColor = System.Drawing.Color.Cyan;
            this.buttonMF.Enabled = false;
            this.buttonMF.Font = new System.Drawing.Font("Comic Sans MS", 9.75F);
            this.buttonMF.Location = new System.Drawing.Point(710, 502);
            this.buttonMF.Name = "buttonMF";
            this.buttonMF.Size = new System.Drawing.Size(259, 34);
            this.buttonMF.TabIndex = 175;
            this.buttonMF.Text = "MARCAR FIN";
            this.buttonMF.UseVisualStyleBackColor = false;
            this.buttonMF.Click += new System.EventHandler(this.buttonMF_Click);
            // 
            // label7
            // 
            this.label7.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.White;
            this.label7.Font = new System.Drawing.Font("Comic Sans MS", 9.75F);
            this.label7.Location = new System.Drawing.Point(712, 341);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(119, 18);
            this.label7.TabIndex = 174;
            this.label7.Text = "NOMBRE CIUDAD";
            // 
            // textBoxCiudadF
            // 
            this.textBoxCiudadF.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxCiudadF.Font = new System.Drawing.Font("Comic Sans MS", 9.75F);
            this.textBoxCiudadF.Location = new System.Drawing.Point(837, 338);
            this.textBoxCiudadF.Name = "textBoxCiudadF";
            this.textBoxCiudadF.Size = new System.Drawing.Size(132, 26);
            this.textBoxCiudadF.TabIndex = 173;
            // 
            // label8
            // 
            this.label8.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label8.BackColor = System.Drawing.Color.White;
            this.label8.Font = new System.Drawing.Font("Comic Sans MS", 9.75F);
            this.label8.Location = new System.Drawing.Point(712, 421);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(119, 18);
            this.label8.TabIndex = 172;
            this.label8.Text = "LATITUD";
            // 
            // textBoxLngF
            // 
            this.textBoxLngF.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxLngF.BackColor = System.Drawing.SystemColors.Window;
            this.textBoxLngF.Font = new System.Drawing.Font("Comic Sans MS", 9.75F);
            this.textBoxLngF.Location = new System.Drawing.Point(837, 460);
            this.textBoxLngF.Name = "textBoxLngF";
            this.textBoxLngF.Size = new System.Drawing.Size(132, 26);
            this.textBoxLngF.TabIndex = 170;
            // 
            // textBoxLatF
            // 
            this.textBoxLatF.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxLatF.Font = new System.Drawing.Font("Comic Sans MS", 9.75F);
            this.textBoxLatF.Location = new System.Drawing.Point(837, 418);
            this.textBoxLatF.Name = "textBoxLatF";
            this.textBoxLatF.Size = new System.Drawing.Size(132, 26);
            this.textBoxLatF.TabIndex = 169;
            // 
            // label9
            // 
            this.label9.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label9.BackColor = System.Drawing.Color.White;
            this.label9.Font = new System.Drawing.Font("Comic Sans MS", 9.75F);
            this.label9.Location = new System.Drawing.Point(712, 381);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(119, 18);
            this.label9.TabIndex = 168;
            this.label9.Text = "NOMBRE PARADA";
            // 
            // textBoxParadaF
            // 
            this.textBoxParadaF.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxParadaF.Font = new System.Drawing.Font("Comic Sans MS", 9.75F);
            this.textBoxParadaF.Location = new System.Drawing.Point(837, 378);
            this.textBoxParadaF.Name = "textBoxParadaF";
            this.textBoxParadaF.Size = new System.Drawing.Size(132, 26);
            this.textBoxParadaF.TabIndex = 167;
            // 
            // label26
            // 
            this.label26.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label26.BackColor = System.Drawing.Color.White;
            this.label26.Font = new System.Drawing.Font("Comic Sans MS", 9.75F);
            this.label26.Location = new System.Drawing.Point(712, 147);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(130, 18);
            this.label26.TabIndex = 283;
            this.label26.Text = "TIEMPO DE VIAJE";
            // 
            // label17
            // 
            this.label17.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label17.BackColor = System.Drawing.Color.White;
            this.label17.Font = new System.Drawing.Font("Comic Sans MS", 9.75F);
            this.label17.Location = new System.Drawing.Point(712, 107);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(130, 18);
            this.label17.TabIndex = 278;
            this.label17.Text = "FECHA LLEGADA";
            // 
            // label18
            // 
            this.label18.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label18.BackColor = System.Drawing.Color.White;
            this.label18.Font = new System.Drawing.Font("Comic Sans MS", 9.75F);
            this.label18.Location = new System.Drawing.Point(712, 67);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(130, 18);
            this.label18.TabIndex = 277;
            this.label18.Text = "FECHA PARTIDA";
            // 
            // label19
            // 
            this.label19.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label19.BackColor = System.Drawing.Color.White;
            this.label19.Font = new System.Drawing.Font("Comic Sans MS", 9.75F);
            this.label19.Location = new System.Drawing.Point(712, 26);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(130, 18);
            this.label19.TabIndex = 276;
            this.label19.Text = "ID SERVICIO";
            // 
            // label22
            // 
            this.label22.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label22.BackColor = System.Drawing.Color.White;
            this.label22.Font = new System.Drawing.Font("Comic Sans MS", 9.75F);
            this.label22.Location = new System.Drawing.Point(712, 189);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(130, 18);
            this.label22.TabIndex = 275;
            this.label22.Text = "ATENCION";
            // 
            // label24
            // 
            this.label24.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label24.BackColor = System.Drawing.Color.White;
            this.label24.Font = new System.Drawing.Font("Comic Sans MS", 9.75F);
            this.label24.Location = new System.Drawing.Point(712, 231);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(130, 18);
            this.label24.TabIndex = 273;
            this.label24.Text = "CATEGORIA";
            // 
            // textBoxTiempo
            // 
            this.textBoxTiempo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxTiempo.Font = new System.Drawing.Font("Comic Sans MS", 9.75F);
            this.textBoxTiempo.Location = new System.Drawing.Point(848, 144);
            this.textBoxTiempo.Name = "textBoxTiempo";
            this.textBoxTiempo.Size = new System.Drawing.Size(121, 26);
            this.textBoxTiempo.TabIndex = 270;
            // 
            // textBoxFSalV
            // 
            this.textBoxFSalV.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxFSalV.Font = new System.Drawing.Font("Comic Sans MS", 9.75F);
            this.textBoxFSalV.Location = new System.Drawing.Point(848, 64);
            this.textBoxFSalV.Name = "textBoxFSalV";
            this.textBoxFSalV.Size = new System.Drawing.Size(121, 26);
            this.textBoxFSalV.TabIndex = 267;
            // 
            // comboBoxIDSV
            // 
            this.comboBoxIDSV.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBoxIDSV.BackColor = System.Drawing.Color.White;
            this.comboBoxIDSV.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxIDSV.Font = new System.Drawing.Font("Comic Sans MS", 9.75F);
            this.comboBoxIDSV.FormattingEnabled = true;
            this.comboBoxIDSV.Location = new System.Drawing.Point(848, 23);
            this.comboBoxIDSV.Name = "comboBoxIDSV";
            this.comboBoxIDSV.Size = new System.Drawing.Size(121, 26);
            this.comboBoxIDSV.TabIndex = 266;
            // 
            // textBoxFLleV
            // 
            this.textBoxFLleV.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxFLleV.Font = new System.Drawing.Font("Comic Sans MS", 9.75F);
            this.textBoxFLleV.Location = new System.Drawing.Point(848, 104);
            this.textBoxFLleV.Name = "textBoxFLleV";
            this.textBoxFLleV.Size = new System.Drawing.Size(121, 26);
            this.textBoxFLleV.TabIndex = 265;
            // 
            // textBoxIDC
            // 
            this.textBoxIDC.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxIDC.Font = new System.Drawing.Font("Comic Sans MS", 9.75F);
            this.textBoxIDC.Location = new System.Drawing.Point(848, 186);
            this.textBoxIDC.Name = "textBoxIDC";
            this.textBoxIDC.Size = new System.Drawing.Size(121, 26);
            this.textBoxIDC.TabIndex = 264;
            // 
            // textBoxIDT
            // 
            this.textBoxIDT.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxIDT.Font = new System.Drawing.Font("Comic Sans MS", 9.75F);
            this.textBoxIDT.Location = new System.Drawing.Point(848, 228);
            this.textBoxIDT.Name = "textBoxIDT";
            this.textBoxIDT.Size = new System.Drawing.Size(121, 26);
            this.textBoxIDT.TabIndex = 262;
            // 
            // buttonVS
            // 
            this.buttonVS.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonVS.BackColor = System.Drawing.Color.Cyan;
            this.buttonVS.Font = new System.Drawing.Font("Comic Sans MS", 9.75F);
            this.buttonVS.Location = new System.Drawing.Point(710, 271);
            this.buttonVS.Name = "buttonVS";
            this.buttonVS.Size = new System.Drawing.Size(259, 37);
            this.buttonVS.TabIndex = 261;
            this.buttonVS.Text = "VER SERVICIO";
            this.buttonVS.UseVisualStyleBackColor = false;
            this.buttonVS.Click += new System.EventHandler(this.buttonVS_Click);
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.BackColor = System.Drawing.Color.White;
            this.button1.BackgroundImage = global::ViajesPlusTPI.Properties.Resources.volver;
            this.button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button1.Enabled = false;
            this.button1.Font = new System.Drawing.Font("Comic Sans MS", 9.75F);
            this.button1.Location = new System.Drawing.Point(671, 502);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(33, 34);
            this.button1.TabIndex = 284;
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // buttonReservar
            // 
            this.buttonReservar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonReservar.BackColor = System.Drawing.Color.Cyan;
            this.buttonReservar.Enabled = false;
            this.buttonReservar.Font = new System.Drawing.Font("Comic Sans MS", 9.75F);
            this.buttonReservar.Location = new System.Drawing.Point(37, 502);
            this.buttonReservar.Name = "buttonReservar";
            this.buttonReservar.Size = new System.Drawing.Size(259, 34);
            this.buttonReservar.TabIndex = 285;
            this.buttonReservar.Text = "RESERVAR PASAJE";
            this.buttonReservar.UseVisualStyleBackColor = false;
            this.buttonReservar.Click += new System.EventHandler(this.buttonReservar_Click);
            // 
            // txtdist
            // 
            this.txtdist.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.txtdist.Font = new System.Drawing.Font("Comic Sans MS", 9.75F);
            this.txtdist.Location = new System.Drawing.Point(320, 507);
            this.txtdist.Name = "txtdist";
            this.txtdist.ReadOnly = true;
            this.txtdist.Size = new System.Drawing.Size(53, 26);
            this.txtdist.TabIndex = 286;
            this.txtdist.Text = "Km...";
            // 
            // comboBoxDestino
            // 
            this.comboBoxDestino.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBoxDestino.BackColor = System.Drawing.Color.White;
            this.comboBoxDestino.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxDestino.Font = new System.Drawing.Font("Comic Sans MS", 9.75F);
            this.comboBoxDestino.FormattingEnabled = true;
            this.comboBoxDestino.Location = new System.Drawing.Point(578, 23);
            this.comboBoxDestino.Name = "comboBoxDestino";
            this.comboBoxDestino.Size = new System.Drawing.Size(87, 26);
            this.comboBoxDestino.TabIndex = 287;
            this.comboBoxDestino.SelectedIndexChanged += new System.EventHandler(this.comboBoxDestino_SelectedIndexChanged);
            // 
            // label10
            // 
            this.label10.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label10.BackColor = System.Drawing.Color.White;
            this.label10.Font = new System.Drawing.Font("Comic Sans MS", 9.75F);
            this.label10.Location = new System.Drawing.Point(409, 26);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(163, 18);
            this.label10.TabIndex = 288;
            this.label10.Text = "DESTINO";
            // 
            // FormReservar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Cyan;
            this.BackgroundImage = global::ViajesPlusTPI.Properties.Resources.FondoModerno;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1008, 559);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.comboBoxDestino);
            this.Controls.Add(this.txtdist);
            this.Controls.Add(this.buttonReservar);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label26);
            this.Controls.Add(this.label17);
            this.Controls.Add(this.label18);
            this.Controls.Add(this.label19);
            this.Controls.Add(this.label22);
            this.Controls.Add(this.label24);
            this.Controls.Add(this.textBoxTiempo);
            this.Controls.Add(this.textBoxFSalV);
            this.Controls.Add(this.comboBoxIDSV);
            this.Controls.Add(this.textBoxFLleV);
            this.Controls.Add(this.textBoxIDC);
            this.Controls.Add(this.textBoxIDT);
            this.Controls.Add(this.buttonVS);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.buttonMF);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.textBoxCiudadF);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.textBoxLngF);
            this.Controls.Add(this.textBoxLatF);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.textBoxParadaF);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.buttonMO);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtCiudad);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtLon);
            this.Controls.Add(this.txtLat);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtParada);
            this.Controls.Add(this.gMapControlMap);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.buttonVI);
            this.Controls.Add(this.textBoxSalV);
            this.Controls.Add(this.textBoxLleV);
            this.Controls.Add(this.textBoxDistV);
            this.Controls.Add(this.comboBoxIDV);
            this.Controls.Add(this.textBoxCantV);
            this.DoubleBuffered = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormReservar";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "RESERVAR";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FormReservar_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private GMap.NET.WindowsForms.GMapControl gMapControlMap;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Button buttonVI;
        private System.Windows.Forms.TextBox textBoxSalV;
        private System.Windows.Forms.TextBox textBoxLleV;
        private System.Windows.Forms.TextBox textBoxDistV;
        private System.Windows.Forms.ComboBox comboBoxIDV;
        private System.Windows.Forms.TextBox textBoxCantV;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button buttonMO;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtCiudad;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtLon;
        private System.Windows.Forms.TextBox txtLat;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtParada;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button buttonMF;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox textBoxCiudadF;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox textBoxLngF;
        private System.Windows.Forms.TextBox textBoxLatF;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox textBoxParadaF;
        private System.Windows.Forms.Label label26;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.TextBox textBoxTiempo;
        private System.Windows.Forms.TextBox textBoxFSalV;
        private System.Windows.Forms.ComboBox comboBoxIDSV;
        private System.Windows.Forms.TextBox textBoxFLleV;
        private System.Windows.Forms.TextBox textBoxIDC;
        private System.Windows.Forms.TextBox textBoxIDT;
        private System.Windows.Forms.Button buttonVS;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button buttonReservar;
        private System.Windows.Forms.TextBox txtdist;
        private System.Windows.Forms.ComboBox comboBoxDestino;
        private System.Windows.Forms.Label label10;
    }
}