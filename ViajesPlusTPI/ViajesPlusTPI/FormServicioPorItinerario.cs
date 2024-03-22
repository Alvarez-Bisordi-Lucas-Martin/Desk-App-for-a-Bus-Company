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

namespace ViajesPlusTPI
{
    public partial class FormServicioPorItinerario : Form
    {
        private DataTable dataTable = new DataTable();

        public FormServicioPorItinerario()
        {
            InitializeComponent();

            dataGridViewI.AutoGenerateColumns = true;
            dataGridViewI.DataSource = dataTable;

            using (SqlConnection connection = new SqlConnection(FormMain.coneccion))
            {
                connection.Open();

                string sqlItinerario = "SELECT Itinerario.[IDItinerario], Itinerario.[CantidadParadas], Itinerario.[DistKmItinerario] DistKm, ( SELECT P.[FK_NombreCiudad] FROM Parada P INNER JOIN OrdenParadaItinerario O ON P.[NombreParada] = O.[FK_NombreParada] WHERE O.[OrdenParada] = ( SELECT MIN(OrdenParadaItinerario.[OrdenParada]) FROM OrdenParadaItinerario WHERE OrdenParadaItinerario.[FK_IDItinerario] = Itinerario.[IDItinerario]) AND O.[FK_IDItinerario] = Itinerario.[IDItinerario]) Origen, ( SELECT P.[FK_NombreCiudad] FROM Parada P INNER JOIN OrdenParadaItinerario O ON P.[NombreParada] = O.[FK_NombreParada] WHERE O.[OrdenParada] = ( SELECT MAX(OrdenParadaItinerario.[OrdenParada]) FROM OrdenParadaItinerario WHERE OrdenParadaItinerario.[FK_IDItinerario] = Itinerario.[IDItinerario]) AND O.[FK_IDItinerario] = Itinerario.[IDItinerario]) Destino, Servicio.[IDServicio], Servicio.[FechaPartidaServicio] FechaPartida, Servicio.[FechaLlegadaServicio] FechaLlegada, Servicio.[HoraPartidaServicio] HoraPartida, Servicio.[HoraLlegadaServicio] HoraLlegada, Servicio.[TiempoDeViaje], CASE WHEN Calidad.[EsAtencionEjecutiva] = 1 THEN 'Ejecutiva' WHEN Calidad.[EsAtencionEjecutiva] = 0 THEN 'Comun' ELSE '' END Atencion, Categoria.[NombreCategoria] Categoria, COALESCE(COUNT(Pasaje.[IDPasaje]), 0) Pasajes FROM Itinerario FULL JOIN Servicio ON Servicio.[FK_IDItinerario] = Itinerario.[IDItinerario] LEFT JOIN Calidad ON Calidad.[IDCalidad] = Servicio.[FK_IDCalidad] LEFT JOIN Categoria ON Categoria.[NombreCategoria] = Calidad.[FK_NombreCategoria] LEFT JOIN Pasaje ON Pasaje.[FK_IDServicio] = Servicio.[IDServicio] GROUP BY Itinerario.[IDItinerario], Itinerario.[CantidadParadas], Itinerario.[DistKmItinerario], Servicio.[IDServicio], Servicio.[FechaPartidaServicio], Servicio.[FechaLlegadaServicio], Servicio.[HoraPartidaServicio], Servicio.[HoraLlegadaServicio], Servicio.[TiempoDeViaje], CASE WHEN Calidad.[EsAtencionEjecutiva] = 1 THEN 'Ejecutiva' WHEN Calidad.[EsAtencionEjecutiva] = 0 THEN 'Comun' ELSE '' END, Categoria.[NombreCategoria] ORDER BY Itinerario.[IDItinerario]";

                using (SqlDataAdapter adapter = new SqlDataAdapter(sqlItinerario, connection))
                {
                    adapter.Fill(dataTable);
                }

                connection.Close();
            }

            //Ajustar();
        }

        private void buttonCopiar_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(label2.Text);
        }

        private void Ajustar()
        {
            var altura = dataGridViewI.ColumnHeadersHeight;
            foreach (DataGridViewRow fila in dataGridViewI.Rows)
            {
                altura += fila.Height;
            }
            dataGridViewI.Height = altura;
        }
    }
}