using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GMap.NET;
using GMap.NET.MapProviders;
using GMap.NET.WindowsForms;
using GMap.NET.WindowsForms.Markers;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace ViajesPlusTPI
{
    public partial class FormReservar : Form
    {
        int IDV, count, i, cant, ini, fin;

        string dist;

        bool cargarFin = false;
        
        GMarkerGoogle marcador;
        GMapOverlay capaMarcador = new GMapOverlay("Marcador");

        double latitudInicial = -34.6264279126189;
        double longitudInicial = -58.4088134765625;

        public FormReservar()
        {
            InitializeComponent();
            Iniciar();

            gMapControlMap.ShowCenter = false;

            gMapControlMap.DragButton = MouseButtons.Left;
            gMapControlMap.CanDragMap = true;
            gMapControlMap.MapProvider = GMapProviders.GoogleMap;
            gMapControlMap.Position = new PointLatLng(latitudInicial, longitudInicial);
        }

        private void CargarMarcador(string nombre, double lat, double lng, GMarkerGoogleType color)
        {
            marcador = new GMarkerGoogle(new PointLatLng(lat, lng), color);

            if (color == GMarkerGoogleType.blue)
            {
                marcador.ToolTipText = string.Format($"Inicial: {nombre}");
            }
            else if (color == GMarkerGoogleType.red)
            {
                marcador.ToolTipText = string.Format($"Final: {nombre}");
            }
            else
            {
                marcador.ToolTipText = string.Format($"Intermedia: {nombre}");
            }

            capaMarcador.Markers.Add(marcador);
            gMapControlMap.Overlays.Add(capaMarcador);

            gMapControlMap.Zoom = gMapControlMap.Zoom + 1;
            gMapControlMap.Zoom = gMapControlMap.Zoom - 1;
        }

        private void Iniciar()
        {
            Limpiar();

            comboBoxDestino.Items.Add($"Ingrese la ciudad de destino...");
            using (SqlConnection connection = new SqlConnection(FormMain.coneccion))
            {
                connection.Open();

                string sqlCiudad = "SELECT * FROM Ciudad";
                using (SqlCommand command = new SqlCommand(sqlCiudad, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            comboBoxDestino.Items.Add($"{reader.GetString(reader.GetOrdinal("NombreCiudad"))}");
                        }
                    }
                    connection.Close();
                }
            }
            comboBoxDestino.SelectedIndex = 0;
        }

        private void EliminarTodosMarcadores()
        {
            if (capaMarcador != null)
            {
                gMapControlMap.Overlays.Remove(capaMarcador);
                capaMarcador.Clear();
            }
        }

        private void VerItinerario()
        {
            string fechaP = "", fechaL = "";

            textBoxCantV.ForeColor = Color.Black;
            textBoxDistV.ForeColor = Color.Black;

            IDV = int.Parse(comboBoxIDV.Text);

            using (SqlConnection connection = new SqlConnection(FormMain.coneccion))
            {
                connection.Open();

                string sqlOrden = $"SELECT COUNT(*) Contador FROM OrdenParadaItinerario WHERE FK_IDItinerario = '{IDV}'";
                using (SqlCommand command = new SqlCommand(sqlOrden, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            count = reader.GetInt32(reader.GetOrdinal("Contador"));
                        }
                    }
                }

                string sqlItinerario = $"SELECT CantidadParadas, HorarioPartidaItinerario, HorarioLlegadaItinerario FROM Itinerario WHERE IDItinerario = '{IDV}'";
                using (SqlCommand command = new SqlCommand(sqlItinerario, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            fechaL = reader.GetTimeSpan(reader.GetOrdinal("HorarioLlegadaItinerario")).ToString(); ;
                            fechaP = reader.GetTimeSpan(reader.GetOrdinal("HorarioPartidaItinerario")).ToString(); ;
                            cant = reader.GetInt32(reader.GetOrdinal("CantidadParadas"));
                        }
                    }
                }
            }

            EliminarTodosMarcadores();
            EliminarRutasAnteriores();
            gMapControlMap.Refresh();

            if (cant > count)
            {
                textBoxSalV.Text = fechaP;
                textBoxLleV.Text = fechaL;
                textBoxCantV.Text = $"Falta cargar {cant - count} parada/s...";
                textBoxDistV.Text = $"Falta cargar {cant - count} parada/s...";
                textBoxCantV.ForeColor = Color.Red;
                textBoxDistV.ForeColor = Color.Red;
            }
            else if (cant < count)
            {
                textBoxSalV.Text = fechaP;
                textBoxLleV.Text = fechaL;
                textBoxCantV.Text = $"Hay {count - cant} parada/s de mas...";
                textBoxDistV.Text = $"Hay {count - cant} parada/s de mas...";
                textBoxCantV.ForeColor = Color.Red;
                textBoxDistV.ForeColor = Color.Red;
            }
            else
            {
                i = 1;

                GMapOverlay Ruta = new GMapOverlay("CapaRuta");
                List<PointLatLng> puntos = new List<PointLatLng>();

                using (SqlConnection connection = new SqlConnection(FormMain.coneccion))
                {
                    connection.Open();

                    string sqlItinerario = $"SELECT * FROM Itinerario WHERE IDItinerario = '{IDV}'";
                    using (SqlCommand command = new SqlCommand(sqlItinerario, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                int cant = reader.GetInt32(reader.GetOrdinal("CantidadParadas"));
                                if (cant > count)
                                {
                                    textBoxCantV.Text = $"Falta cargar {cant - count} paradas...";
                                    textBoxDistV.Text = $"Falta cargar {cant - count} paradas...";
                                    textBoxCantV.ForeColor = Color.Red;
                                    textBoxDistV.ForeColor = Color.Red;
                                }
                                else
                                {
                                    textBoxCantV.Text = reader.GetInt32(reader.GetOrdinal("CantidadParadas")).ToString();
                                    textBoxDistV.Text = reader.GetDouble(reader.GetOrdinal("DistKmItinerario")).ToString();
                                    textBoxSalV.Text = reader.GetTimeSpan(reader.GetOrdinal("HorarioPartidaItinerario")).ToString();
                                    textBoxLleV.Text = reader.GetTimeSpan(reader.GetOrdinal("HorarioLlegadaItinerario")).ToString();
                                }
                            }
                        }
                    }
                }

                using (SqlConnection connection = new SqlConnection(FormMain.coneccion))
                {
                    connection.Open();

                    string sqlParada = $"SELECT Parada.[NombreParada], Parada.[Latitud], Parada.[Longitud], OrdenParadaItinerario.[OrdenParada] FROM Parada INNER JOIN OrdenParadaItinerario ON Parada.[NombreParada] = OrdenParadaItinerario.[FK_NombreParada] WHERE OrdenParadaItinerario.[FK_IDItinerario] = '{IDV}' ORDER BY OrdenParadaItinerario.[OrdenParada]";
                    using (SqlCommand command = new SqlCommand(sqlParada, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {

                                if (i == 1)
                                {
                                    CargarMarcador(reader.GetString(reader.GetOrdinal("NombreParada")), reader.GetDouble(reader.GetOrdinal("Latitud")), reader.GetDouble(reader.GetOrdinal("Longitud")), GMarkerGoogleType.blue);
                                    i++;
                                }
                                else if (i == count)
                                {
                                    CargarMarcador(reader.GetString(reader.GetOrdinal("NombreParada")), reader.GetDouble(reader.GetOrdinal("Latitud")), reader.GetDouble(reader.GetOrdinal("Longitud")), GMarkerGoogleType.red);
                                }
                                else
                                {
                                    CargarMarcador(reader.GetString(reader.GetOrdinal("NombreParada")), reader.GetDouble(reader.GetOrdinal("Latitud")), reader.GetDouble(reader.GetOrdinal("Longitud")), GMarkerGoogleType.yellow);
                                    i++;
                                }
                                puntos.Add(new PointLatLng(reader.GetDouble(reader.GetOrdinal("Latitud")), reader.GetDouble(reader.GetOrdinal("Longitud"))));
                            }
                        }
                    }
                }

                GMapRoute PuntosRuta = new GMapRoute(puntos, "Ruta");
                Ruta.Routes.Add(PuntosRuta);

                gMapControlMap.Overlays.Add(Ruta);

                dist = Math.Round(PuntosRuta.Distance, 2).ToString().Replace(',', '.');
                txtdist.Text = dist;

                gMapControlMap.Zoom = gMapControlMap.Zoom + 1;
                gMapControlMap.Zoom = gMapControlMap.Zoom - 1;
            }
        }

        private void EliminarRutasAnteriores()
        {
            GMapOverlay capaRutaExistente = gMapControlMap.Overlays.FirstOrDefault(o => o.Id == "CapaRuta");
            if (capaRutaExistente != null)
            {
                gMapControlMap.Overlays.Remove(capaRutaExistente);
            }
        }

        private void buttonVS_Click(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(FormMain.coneccion))
                {
                    connection.Open();

                    string sqlServicio = $"SELECT Servicio.[FechaLlegadaServicio], Servicio.[FechaPartidaServicio], Servicio.[TiempoDeViaje], CASE WHEN Calidad.[EsAtencionEjecutiva] = 0 THEN 'Comun' ELSE 'Ejecutiva' END Atencion, Categoria.[NombreCategoria] FROM Servicio INNER JOIN Calidad ON Servicio.[FK_IDCalidad] = Calidad.[IDCalidad] INNER JOIN Categoria ON Categoria.[NombreCategoria] = Calidad.[FK_NombreCategoria] WHERE Servicio.[IDServicio] = '{comboBoxIDSV.Text}'";
                    using (SqlCommand command = new SqlCommand(sqlServicio, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                textBoxIDC.Text = reader.GetString(reader.GetOrdinal("Atencion"));
                                textBoxTiempo.Text = reader.GetInt32(reader.GetOrdinal("TiempoDeViaje")).ToString();
                                textBoxIDT.Text = reader.GetString(reader.GetOrdinal("NombreCategoria"));
                                textBoxFSalV.Text = reader.GetDateTime(reader.GetOrdinal("FechaPartidaServicio")).ToShortDateString();
                                textBoxFLleV.Text = reader.GetDateTime(reader.GetOrdinal("FechaLlegadaServicio")).ToShortDateString();
                            }
                        }
                        connection.Close();
                    }
                }

                buttonMF.Enabled = true;
                buttonMO.Enabled = true;
                button1.Enabled = true;
            }
            catch (Exception ex)
            {
                Form formError = new FormError(ex.Message);
                formError.ShowDialog();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            cargarFin = false;
        }

        private void buttonReservar_Click(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection cn = new SqlConnection(FormMain.coneccion))
                {
                    SqlCommand cmd = new SqlCommand
                        ($"INSERT INTO Pasaje (FK_IDServicio, NombreParadaSubida, NombreParadaBajada, EstaAbonado, DistKmPasaje, FK_UserName)" +
                        $"VALUES ('{comboBoxIDSV.Text}', '{txtParada.Text}', '{textBoxParadaF.Text}', '{0}', '{dist}', '{FormInicio.user}')", cn);
                    cmd.CommandType = CommandType.Text;
                    cn.Open();
                    cmd.ExecuteNonQuery();
                    cn.Close();
                }

                Form formRealizado = new FormRealizado();
                formRealizado.ShowDialog();

                using (SqlConnection connection = new SqlConnection(FormMain.coneccion))
                {
                    connection.Open();

                    string sqlServicio = $"SELECT AsientosDisponibles FROM Servicio WHERE IDServicio = '{comboBoxIDSV.Text}'";
                    using (SqlCommand command = new SqlCommand(sqlServicio, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                if (reader.GetInt32(reader.GetOrdinal("AsientosDisponibles")) == 0)
                                {
                                    LimpiarReserva();
                                    Iniciar();
                                }
                            }
                        }
                        connection.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                Form formError = new FormError(ex.Message);
                formError.ShowDialog();
            }
        }

        private void LimpiarReserva()
        {
            textBoxCantV.Text = "";
            textBoxDistV.Text = "";
            textBoxSalV.Text = "";
            textBoxLleV.Text = "";

            textBoxIDT.Text = "";
            textBoxTiempo.Text = "";
            textBoxFSalV.Text = "";
            textBoxFLleV.Text = "";
            textBoxIDC.Text = "";

            txtCiudad.Text = "";
            txtParada.Text = "";
            txtLat.Text = "";
            txtLon.Text = "";

            textBoxCiudadF.Text = "";
            textBoxParadaF.Text = "";
            textBoxLatF.Text = "";
            textBoxLngF.Text = "";

            comboBoxIDV.Items.Clear();
            comboBoxDestino.Items.Clear();
            comboBoxIDSV.Items.Clear();
            buttonMO.Enabled = false;
            buttonMF.Enabled = false;
            buttonReservar.Enabled = false;
            button1.Enabled = false;
        }

        private void gMapControlMap_OnMarkerClick(GMapMarker item, MouseEventArgs e)
        {
            string nombreParadaFull = item.ToolTipText;
            string[] partes = nombreParadaFull.Split(':');
            string nombreParada = partes[1].TrimStart();

            textBoxParadaF.ForeColor = Color.Black;
            textBoxLatF.ForeColor = Color.Black;
            textBoxLngF.ForeColor = Color.Black;
            textBoxCiudadF.ForeColor = Color.Black;

            if (cargarFin == false)
            {
                using (SqlConnection connection = new SqlConnection(FormMain.coneccion))
                {
                    connection.Open();

                    string sqlParadaInfo = $"SELECT * FROM Parada WHERE NombreParada = '{nombreParada}'";
                    using (SqlCommand command = new SqlCommand(sqlParadaInfo, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                txtParada.Text = reader.GetString(reader.GetOrdinal("NombreParada"));
                                txtLat.Text = reader.GetDouble(reader.GetOrdinal("Latitud")).ToString();
                                txtLon.Text = reader.GetDouble(reader.GetOrdinal("Longitud")).ToString();
                                txtCiudad.Text = reader.GetString(reader.GetOrdinal("FK_NombreCiudad"));
                            }
                        }
                    }
                }
            }
            else
            {
                using (SqlConnection connection = new SqlConnection(FormMain.coneccion))
                {
                    connection.Open();

                    string sqlParadaInfo = $"SELECT * FROM Parada WHERE NombreParada = '{nombreParada}'";
                    using (SqlCommand command = new SqlCommand(sqlParadaInfo, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                textBoxParadaF.Text = reader.GetString(reader.GetOrdinal("NombreParada"));
                                textBoxLatF.Text = reader.GetDouble(reader.GetOrdinal("Latitud")).ToString();
                                textBoxLngF.Text = reader.GetDouble(reader.GetOrdinal("Longitud")).ToString();
                                textBoxCiudadF.Text = reader.GetString(reader.GetOrdinal("FK_NombreCiudad"));
                            }
                        }
                    }
                }
            }
        }

        private void buttonMO_Click(object sender, EventArgs e)
        {
            try
            {
                cargarFin = true;
            }
            catch (Exception ex)
            {
                Form formError = new FormError(ex.Message);
                formError.ShowDialog();
            }
        }

        private void buttonMF_Click(object sender, EventArgs e)
        {
            try
            {
                Validar();
                ActualizarRuta(ini, fin);
            }
            catch (Exception ex)
            {
                Form formError = new FormError(ex.Message);
                formError.ShowDialog();
            }
        }

        private void comboBoxDestino_SelectedIndexChanged(object sender, EventArgs e)
        {
            bool vacio = true;
            Limpiar();

            using (SqlConnection connection = new SqlConnection(FormMain.coneccion))
            {
                connection.Open();

                string sqlItinerario = $"SELECT I.[IDItinerario] FROM Itinerario I INNER JOIN OrdenParadaItinerario O ON O.[FK_IDItinerario] = I.[IDItinerario] INNER JOIN Parada P ON P.[NombreParada] = O.[FK_NombreParada] WHERE O.[OrdenParada] = (SELECT MAX(OrdenParadaItinerario.[OrdenParada]) FROM OrdenParadaItinerario WHERE OrdenParadaItinerario.[FK_IDItinerario] = I.[IDItinerario]) AND P.[FK_NombreCiudad] = '{comboBoxDestino.Text}'";
                using (SqlCommand command = new SqlCommand(sqlItinerario, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            comboBoxIDV.Items.Add($"{reader.GetInt32(reader.GetOrdinal("IDItinerario"))}");
                            vacio = false;
                        }
                    }
                    connection.Close();
                }
            }
            if (vacio)
            {
                comboBoxIDV.Items.Add("Vacio...");
                comboBoxIDV.SelectedIndex = 0;
            }
            else
            {
                comboBoxIDV.SelectedIndex = 0;
            }
        }

        private void Validar()
        {
            int ordenA = 0, ordenB = 0;

            using (SqlConnection connection = new SqlConnection(FormMain.coneccion))
            {
                connection.Open();

                string sqlParadaInfoO = $"SELECT OrdenParada FROM OrdenParadaItinerario WHERE FK_NombreParada = '{txtParada.Text}' AND FK_IDItinerario = '{IDV}'";
                using (SqlCommand command = new SqlCommand(sqlParadaInfoO, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            ordenA = reader.GetInt32(reader.GetOrdinal("OrdenParada"));
                        }
                    }
                }

                string sqlParadaInfoF = $"SELECT OrdenParada FROM OrdenParadaItinerario WHERE FK_NombreParada = '{textBoxParadaF.Text}' AND FK_IDItinerario = '{IDV}'";
                using (SqlCommand command = new SqlCommand(sqlParadaInfoF, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            ordenB = reader.GetInt32(reader.GetOrdinal("OrdenParada"));
                        }
                    }
                }
            }

            ini = ordenA;
            fin = ordenB;

            if (ordenA >= ordenB)
            {
                textBoxParadaF.Text = "Error...";
                textBoxParadaF.ForeColor = Color.Red;
                textBoxLatF.Text = "Error...";
                textBoxLatF.ForeColor = Color.Red;
                textBoxLngF.Text = "Error...";
                textBoxLngF.ForeColor = Color.Red;
                textBoxCiudadF.Text = "Error...";
                textBoxCiudadF.ForeColor = Color.Red;
                buttonReservar.Enabled = false;
            }
            else { buttonReservar.Enabled = true; }
        }

        private void ActualizarRuta(int fini, int ffin)
        {
            EliminarRutasAnteriores();
            gMapControlMap.Refresh();

            GMapOverlay Ruta = new GMapOverlay("CapaRuta");
            List<PointLatLng> puntos = new List<PointLatLng>();

            using (SqlConnection connection = new SqlConnection(FormMain.coneccion))
            {
                connection.Open();

                string sqlItinerario = $"SELECT COUNT(*) ParadasParciales FROM OrdenParadaItinerario WHERE OrdenParada >= '{fini}' AND OrdenParada <= '{ffin}'";
                using (SqlCommand command = new SqlCommand(sqlItinerario, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            int cant = reader.GetInt32(reader.GetOrdinal("ParadasParciales"));
                        }
                    }
                }
            }

            using (SqlConnection connection = new SqlConnection(FormMain.coneccion))
            {
                connection.Open();

                string sqlParada = $"SELECT Parada.[NombreParada], Parada.[Latitud], Parada.[Longitud], OrdenParadaItinerario.[OrdenParada] FROM Parada INNER JOIN OrdenParadaItinerario ON Parada.[NombreParada] = OrdenParadaItinerario.[FK_NombreParada] WHERE OrdenParadaItinerario.[FK_IDItinerario] = '{IDV}' AND OrdenParadaItinerario.[OrdenParada] >= '{fini}' AND OrdenParadaItinerario.[OrdenParada] <= '{ffin}' ORDER BY OrdenParadaItinerario.[OrdenParada]";
                using (SqlCommand command = new SqlCommand(sqlParada, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            puntos.Add(new PointLatLng(reader.GetDouble(reader.GetOrdinal("Latitud")), reader.GetDouble(reader.GetOrdinal("Longitud"))));
                        }
                    }
                }
            }

            GMapRoute PuntosRuta = new GMapRoute(puntos, "Ruta");
            Ruta.Routes.Add(PuntosRuta);

            gMapControlMap.Overlays.Add(Ruta);

            dist = Math.Round(PuntosRuta.Distance, 2).ToString().Replace(',', '.');
            txtdist.Text = dist;

            gMapControlMap.Zoom = gMapControlMap.Zoom + 1;
            gMapControlMap.Zoom = gMapControlMap.Zoom - 1;
        }

        private void Limpiar()
        {
            textBoxCantV.Text = "";
            textBoxDistV.Text = "";
            textBoxSalV.Text = "";
            textBoxLleV.Text = "";
            comboBoxIDV.Items.Clear();
        }

        private void buttonVI_Click_1(object sender, EventArgs e)
        {
            try
            {
                VerItinerario();

                cargarFin = false;
                comboBoxIDSV.Items.Clear();

                bool vacio = true;

                using (SqlConnection connection = new SqlConnection(FormMain.coneccion))
                {
                    connection.Open();

                    string sqlServicio = $"SELECT IDServicio FROM Servicio WHERE FK_IDItinerario = '{IDV}' AND HayDisponibilidad = '{1}'";
                    using (SqlCommand command = new SqlCommand(sqlServicio, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                comboBoxIDSV.Items.Add($"{reader.GetInt32(reader.GetOrdinal("IDServicio"))}");
                                vacio = false;
                            }
                        }
                    }
                }
                if (vacio)
                {
                    comboBoxIDSV.Items.Add("Vacio...");
                    comboBoxIDSV.SelectedIndex = 0;
                }
                else
                {
                    comboBoxIDSV.SelectedIndex = 0;
                }
            }
            catch (Exception ex)
            {
                Form formError = new FormError(ex.Message);
                formError.ShowDialog();
            }
        }

        private void FormReservar_Load(object sender, EventArgs e)
        {

        }
    }
}