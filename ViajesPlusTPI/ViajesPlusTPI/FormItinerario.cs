using GMap.NET.MapProviders;
using GMap.NET;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GMap.NET.WindowsForms.Markers;
using GMap.NET.WindowsForms;

namespace ViajesPlusTPI
{
    public partial class FormItinerario : Form
    {
        int ID, IDM, IDV, count, i, cant;

        GMarkerGoogle marcador;
        GMapOverlay capaMarcador = new GMapOverlay("Marcador");

        double latitudInicial = -34.6264279126189;
        double longitudInicial = -58.4088134765625;

        public FormItinerario()
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
            using (SqlConnection connection = new SqlConnection(FormMain.coneccion))
            {
                connection.Open();

                string sqlItinerario = "SELECT IDItinerario FROM Itinerario";
                using (SqlCommand command = new SqlCommand(sqlItinerario, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            comboBoxIDE.Items.Add($"{reader.GetInt32(reader.GetOrdinal("IDItinerario"))}");
                            comboBoxIDM.Items.Add($"{reader.GetInt32(reader.GetOrdinal("IDItinerario"))}");
                            comboBoxIDV.Items.Add($"{reader.GetInt32(reader.GetOrdinal("IDItinerario"))}");
                        }
                    }
                    connection.Close();
                }
            }
        }

        private void AgregarItinerario()
        {
            try
            {
                using (SqlConnection cn = new SqlConnection(FormMain.coneccion))
                {
                    SqlCommand cmd = new SqlCommand
                        ($"INSERT INTO Itinerario (HorarioPartidaItinerario, HorarioLlegadaItinerario, CantidadParadas, DistKmItinerario)" +
                        $"VALUES ('{dateTimePickerSalida.Text}', '{dateTimePickerLlegada.Text}', '{txtCantidad.Text}', '{0}')", cn);
                    cmd.CommandType = CommandType.Text;
                    cn.Open();
                    cmd.ExecuteNonQuery();
                    cn.Close();
                }

                Form formRealizado = new FormRealizado();
                formRealizado.ShowDialog();
            }
            catch (Exception ex)
            {
                Form formError = new FormError(ex.Message) ;
                formError.ShowDialog();
            }
        }

        private void ModificarItinerario()
        {
            IDM = int.Parse(comboBoxIDM.Text);

            using (SqlConnection cn = new SqlConnection(FormMain.coneccion))
            {
                SqlCommand cmd = new SqlCommand
                    ($"UPDATE Itinerario SET HorarioPartidaItinerario = '{dateTimePickerSalidaM.Text}', HorarioLlegadaItinerario = '{dateTimePickerLlegadaM.Text}', CantidadParadas = '{txtCantidadM.Text}' WHERE IDItinerario = '{IDM}'", cn);
                cmd.CommandType = CommandType.Text;
                cn.Open();
                cmd.ExecuteNonQuery();
                cn.Close();
            }

            using (SqlConnection cn = new SqlConnection(FormMain.coneccion))
            {
                SqlCommand cmd = new SqlCommand
                    ($"UPDATE Servicio SET HoraPartidaServicio = '{dateTimePickerSalidaM.Text}', HoraLlegadaServicio = '{dateTimePickerLlegadaM.Text}' WHERE FK_IDItinerario = '{IDM}'", cn);
                cmd.CommandType = CommandType.Text;
                cn.Open();
                cmd.ExecuteNonQuery();
                cn.Close();
            }

            Form formRealizado = new FormRealizado();
            formRealizado.ShowDialog();
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
            textBoxOrigen.ForeColor = Color.Black;
            textBoxDestino.ForeColor = Color.Black;

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
                            fechaL = reader.GetTimeSpan(reader.GetOrdinal("HorarioLlegadaItinerario")).ToString();
                            fechaP = reader.GetTimeSpan(reader.GetOrdinal("HorarioPartidaItinerario")).ToString();
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
                textBoxDestino.Text = $"Falta cargar {cant - count} parada/s...";
                textBoxOrigen.Text = $"Falta cargar {cant - count} parada/s...";
                textBoxCantV.ForeColor = Color.Red;
                textBoxDistV.ForeColor = Color.Red;
                textBoxDestino.ForeColor = Color.Red;
                textBoxOrigen.ForeColor = Color.Red;
            }
            else if (cant < count)
            {
                textBoxSalV.Text = fechaP;
                textBoxLleV.Text = fechaL;
                textBoxCantV.Text = $"Hay {count - cant} parada/s de mas...";
                textBoxDistV.Text = $"Hay {count - cant} parada/s de mas...";
                textBoxDestino.Text = $"Hay {count - cant} parada/s de mas...";
                textBoxOrigen.Text = $"Hay {count - cant} parada/s de mas...";
                textBoxCantV.ForeColor = Color.Red;
                textBoxDistV.ForeColor = Color.Red;
                textBoxDestino.ForeColor = Color.Red;
                textBoxOrigen.ForeColor = Color.Red;
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
                                textBoxCantV.Text = reader.GetInt32(reader.GetOrdinal("CantidadParadas")).ToString();
                                textBoxDistV.Text = reader.GetDouble(reader.GetOrdinal("DistKmItinerario")).ToString();
                                textBoxSalV.Text = reader.GetTimeSpan(reader.GetOrdinal("HorarioPartidaItinerario")).ToString();
                                textBoxLleV.Text = reader.GetTimeSpan(reader.GetOrdinal("HorarioLlegadaItinerario")).ToString();
                            }
                        }
                    }

                    string sqlOrigen = $"SELECT P.[FK_NombreCiudad] FROM Parada P INNER JOIN OrdenParadaItinerario O ON P.[NombreParada] = O.[FK_NombreParada] WHERE O.[OrdenParada] = (SELECT MIN(OrdenParadaItinerario.[OrdenParada]) FROM Itinerario INNER JOIN OrdenParadaItinerario ON OrdenParadaItinerario.[FK_IDItinerario] = Itinerario.[IDItinerario] WHERE IDItinerario = '{IDV}') AND O.[FK_IDItinerario] = '{IDV}'";
                    using (SqlCommand command = new SqlCommand(sqlOrigen, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                textBoxOrigen.Text = reader.GetString(reader.GetOrdinal("FK_NombreCiudad"));
                            }
                        }
                    }

                    string sqlDestino = $"SELECT P.[FK_NombreCiudad] FROM Parada P INNER JOIN OrdenParadaItinerario O ON P.[NombreParada] = O.[FK_NombreParada] WHERE O.[OrdenParada] = (SELECT MAX(OrdenParadaItinerario.[OrdenParada]) FROM Itinerario INNER JOIN OrdenParadaItinerario ON OrdenParadaItinerario.[FK_IDItinerario] = Itinerario.[IDItinerario] WHERE IDItinerario = '{IDV}') AND O.[FK_IDItinerario] = '{IDV}'";
                    using (SqlCommand command = new SqlCommand(sqlDestino, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                textBoxDestino.Text = reader.GetString(reader.GetOrdinal("FK_NombreCiudad"));
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

                textBoxDistV.Text = Math.Round(PuntosRuta.Distance, 2).ToString();

                using (SqlConnection cn = new SqlConnection(FormMain.coneccion))
                {
                    SqlCommand cmd = new SqlCommand
                        ($"UPDATE Itinerario SET DistKmItinerario = '{textBoxDistV.Text.Replace(',', '.')}' WHERE IDItinerario = '{IDV}'", cn);
                    cmd.CommandType = CommandType.Text;
                    cn.Open();
                    cmd.ExecuteNonQuery();
                    cn.Close();
                }

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

        private void EliminarItinerario()
        {
            using (SqlConnection cn = new SqlConnection(FormMain.coneccion))
            {
                SqlCommand cmd = new SqlCommand
                    ($"DELETE FROM Pasaje WHERE FK_IDServicio IN ( SELECT Servicio.[IDServicio] FROM Itinerario INNER JOIN Servicio ON Servicio.[FK_IDItinerario] = Itinerario.[IDItinerario] WHERE Itinerario.[IDItinerario] = '{ID}')", cn);
                cmd.CommandType = CommandType.Text;
                cn.Open();
                cmd.ExecuteNonQuery();
                cn.Close();
            }

            using (SqlConnection cn = new SqlConnection(FormMain.coneccion))
            {
                SqlCommand cmd = new SqlCommand
                    ($"DELETE FROM Itinerario WHERE IDItinerario = '{ID}'", cn);
                cmd.CommandType = CommandType.Text;
                cn.Open();
                cmd.ExecuteNonQuery();
                cn.Close();
            }

            Form formRealizado = new FormRealizado();
            formRealizado.ShowDialog();
        }

        private void Limpiar()
        {
            txtCantidad.Text = "";
            dateTimePickerSalida.Value = DateTimePicker.MinimumDateTime.Date + new TimeSpan(0, 0, 0);
            dateTimePickerLlegada.Value = DateTimePicker.MinimumDateTime.Date + new TimeSpan(0, 0, 0);
            dateTimePickerSalidaM.Value = DateTimePicker.MinimumDateTime.Date + new TimeSpan(0, 0, 0);
            dateTimePickerLlegadaM.Value = DateTimePicker.MinimumDateTime.Date + new TimeSpan(0, 0, 0);
            txtCantidadM.Text = "";
            textBoxCantV.Text = "";
            textBoxDistV.Text = "";
            textBoxSalV.Text = "";
            textBoxLleV.Text = "";
            textBoxDestino.Text = "";
            textBoxOrigen.Text = "";
            comboBoxIDE.Items.Clear();
            comboBoxIDV.Items.Clear();
            comboBoxIDM.Items.Clear();
        }

        private void buttonGI_Click(object sender, EventArgs e)
        {
            AgregarItinerario();
            Iniciar();
        }

        private void buttonEI_Click(object sender, EventArgs e)
        {
            try
            {
                EliminarItinerario();
            }
            catch (Exception ex)
            {
                Form formError = new FormError(ex.Message);
                formError.ShowDialog();
            }
            Iniciar();
        }

        private void comboBoxIDE_SelectedIndexChanged(object sender, EventArgs e)
        {
            ID = int.Parse(comboBoxIDE.SelectedItem.ToString());
        }

        private void buttonVI_Click(object sender, EventArgs e)
        {
            try
            {
                VerItinerario();
            }
            catch (Exception ex)
            {
                Form formError = new FormError(ex.Message);
                formError.ShowDialog();
            }
        }

        private void buttonMI_Click(object sender, EventArgs e)
        {
            try
            {
                ModificarItinerario();
            }
            catch (Exception ex)
            {
                Form formError = new FormError(ex.Message);
                formError.ShowDialog();
            }
            Iniciar();
        }
    }
}