using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GMap.NET;
using GMap.NET.MapProviders;
using GMap.NET.WindowsForms;
using GMap.NET.WindowsForms.Markers;

namespace ViajesPlusTPI
{
    public partial class FormParada : Form
    {
        GMarkerGoogle marcador;
        GMapOverlay capaMarcador = new GMapOverlay("Marcador");

        double latitudInicial = -34.6264279126189;
        double longitudInicial = -58.4088134765625;
        bool validacion = false, repetida = false;
        
        public FormParada()
        {
            InitializeComponent();

            gMapControlMap.ShowCenter = false;
            Cargar();
        }

        private void Cargar()
        {
            gMapControlMap.DragButton = MouseButtons.Left;
            gMapControlMap.CanDragMap = true;
            gMapControlMap.MapProvider = GMapProviders.GoogleMap;
            gMapControlMap.Position = new PointLatLng(latitudInicial, longitudInicial);
            using (SqlConnection connection = new SqlConnection(FormMain.coneccion))
            {
                connection.Open();

                string sqlParada = "SELECT * FROM Parada";
                using (SqlCommand command = new SqlCommand(sqlParada, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            CargarMarcador(reader.GetString(reader.GetOrdinal("NombreParada")), reader.GetDouble(reader.GetOrdinal("Latitud")), reader.GetDouble(reader.GetOrdinal("Longitud")));
                        }
                    }
                }
            }
        }

        private void CargarMarcador(string nombre, double lat, double lng)
        {
            marcador = new GMarkerGoogle(new PointLatLng(lat, lng), GMarkerGoogleType.blue);
            capaMarcador.Markers.Add(marcador);
            gMapControlMap.Overlays.Add(capaMarcador);
            marcador.ToolTipText = string.Format($"{nombre}");

            gMapControlMap.Zoom = gMapControlMap.Zoom + 1;
            gMapControlMap.Zoom = gMapControlMap.Zoom - 1;
        }

        private void EliminarTodosMarcadores()
        {
            if (capaMarcador != null)
            {
                gMapControlMap.Overlays.Remove(capaMarcador);
                capaMarcador.Clear();
            }
        }

        private void gMapControlMap_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            using (SqlConnection cn = new SqlConnection(FormMain.coneccion))
            {
                cn.Open();

                string sqlCiudad = $"SELECT COALESCE(COUNT(NombreCiudad), 0) Cantidad FROM Ciudad WHERE NombreCiudad = '{txtCiudad.Text}'";
                using (SqlCommand command = new SqlCommand(sqlCiudad, cn))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            if (reader.GetInt32(reader.GetOrdinal("Cantidad")) == 0)
                            {
                                repetida = false;
                            }
                            else
                            {
                                repetida = true;
                            }
                        }
                    }
                }
            }
            if (txtCiudad.Text == "" || txtCiudad.Text == "Agregue el nombre de la Ciudad...")
            {
                txtCiudad.Text = "Agregue el nombre de la Ciudad...";
                txtCiudad.ForeColor = Color.Red;
            }
            else if (repetida == false)
            {
                txtParada.Text = "Parada" + txtCiudad.Text;
                double latitud = gMapControlMap.FromLocalToLatLng(e.X, e.Y).Lat;
                double longitud = gMapControlMap.FromLocalToLatLng(e.X, e.Y).Lng;

                txtLat.Text = latitud.ToString();
                txtLon.Text = longitud.ToString();

                CargarMarcador(txtParada.Text, latitud, longitud);
            }
            else
            {
                txtCiudad.Text = "Ya existe una parada en esta Ciudad...";
                txtCiudad.ForeColor = Color.Red;
            }
        }

        private void buttonAgregar_Click(object sender, EventArgs e)
        {
            if (txtCiudad.Text != "" && txtParada.Text != "" && txtParada.Text  != "Ingrese un nombre...")
            {
                try
                {
                    using (SqlConnection cn = new SqlConnection(FormMain.coneccion))
                    {
                        cn.Open();

                        string sqlCiudad = $"SELECT COALESCE(COUNT(NombreCiudad), 0) Cantidad FROM Ciudad WHERE NombreCiudad = '{txtCiudad.Text}'";
                        using (SqlCommand command = new SqlCommand(sqlCiudad, cn))
                        {
                            using (SqlDataReader reader = command.ExecuteReader())
                            {
                                while (reader.Read())
                                {
                                    if (reader.GetInt32(reader.GetOrdinal("Cantidad")) == 0)
                                    {
                                        validacion = true;
                                    }
                                    else
                                    {
                                        txtCiudad.Text = "Ya existe una parada en esta Ciudad...";
                                        txtCiudad.ForeColor = Color.Red;
                                        validacion = false;
                                    }
                                }
                            }
                        }
                    }
                    if (validacion)
                    {
                        using (SqlConnection cn = new SqlConnection(FormMain.coneccion))
                        {
                            using (SqlCommand cmdCiudad = new SqlCommand($"INSERT INTO Ciudad (NombreCiudad) VALUES ('{txtCiudad.Text}')", cn))
                            {
                                cmdCiudad.CommandType = CommandType.Text;
                                cn.Open();
                                cmdCiudad.ExecuteNonQuery();
                                cn.Close();
                            }
                            using (SqlCommand cmdParada = new SqlCommand($"INSERT INTO Parada (NombreParada, Latitud, Longitud, FK_NombreCiudad) VALUES ('{txtParada.Text}', '{txtLat.Text.Replace(',', '.')}', '{txtLon.Text.Replace(',', '.')}', '{txtCiudad.Text}')", cn))
                            {
                                cmdParada.CommandType = CommandType.Text;
                                cn.Open();
                                cmdParada.ExecuteNonQuery();
                                cn.Close();
                            }
                        }

                        Form formRealizado = new FormRealizado();
                        formRealizado.ShowDialog();
                    }
                }
                catch (Exception ex)
                {
                    Form formError = new FormError(ex.Message);
                    formError.ShowDialog();
                }

                txtParada.Text = "";
                txtLat.Text = "";
                txtLon.Text = "";
                txtCiudad.Text = "";
            }
            else
            {
                txtParada.Text = "Ingrese un nombre...";
                txtCiudad.Text = "Ingrese un nombre...";
                txtParada.ForeColor = Color.Red;
                txtCiudad.ForeColor = Color.Red;
            }
        }

        private void buttonEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection cn = new SqlConnection(FormMain.coneccion))
                {
                    SqlCommand cmd = new SqlCommand
                        ($"DELETE FROM Parada WHERE NombreParada = '{txtParada.Text}'", cn);
                    cmd.CommandType = CommandType.Text;
                    cn.Open();
                    cmd.ExecuteNonQuery();
                    cn.Close();
                }
                using (SqlConnection cn = new SqlConnection(FormMain.coneccion))
                {
                    SqlCommand cmd = new SqlCommand
                        ($"DELETE FROM Ciudad WHERE NombreCiudad = '{txtCiudad.Text}'", cn);
                    cmd.CommandType = CommandType.Text;
                    cn.Open();
                    cmd.ExecuteNonQuery();
                    cn.Close();
                }

                txtParada.Text = "";
                txtLat.Text = "";
                txtLon.Text = "";
                txtCiudad.Text = "";

                Form formRealizado = new FormRealizado();
                formRealizado.ShowDialog();
            }
            catch (Exception ex)
            {
                Form formError = new FormError(ex.Message);
                formError.ShowDialog();
            }

            EliminarTodosMarcadores();
            Cargar();
        }

        private void txtCiudad_TextChanged(object sender, EventArgs e)
        {
            txtCiudad.ForeColor = Color.Black;
        }

        private void gMapControlMap_OnMarkerClick(GMapMarker item, MouseEventArgs e)
        {
            string nombreParada = item.ToolTipText;

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

        private void buttonLimpiar_Click(object sender, EventArgs e)
        {
            txtParada.Text = "";
            txtLat.Text = "";
            txtLon.Text = "";
            txtCiudad.Text = "";
        }

        private void txtParada_TextChanged(object sender, EventArgs e)
        {
            txtParada.ForeColor = Color.Black;
        }
    }
}