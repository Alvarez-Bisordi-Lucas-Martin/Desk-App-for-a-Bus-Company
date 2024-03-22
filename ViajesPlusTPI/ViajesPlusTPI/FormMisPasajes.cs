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
    public partial class FormMisPasajes : Form
    {
        private DataTable dataTable = new DataTable();

        public FormMisPasajes()
        {
            InitializeComponent();

            dataGridViewI.AutoGenerateColumns = true;
            dataGridViewI.DataSource = dataTable;

            using (SqlConnection connection = new SqlConnection(FormMain.coneccion))
            {
                connection.Open();

                string sqlPasaje = $"SELECT Pasaje.[IDPasaje] ID, Pasaje.[NombreParadaSubida] Inicio, Pasaje.[NombreParadaBajada] Fin, Pasaje.[EstaAbonado], Pasaje.[DistKmPasaje] DistKm, Pasaje.[CostoPasaje] Costo, Servicio.[IDServicio], Servicio.[FechaPartidaServicio] FechaPartida, Servicio.[FechaLlegadaServicio] FechaLlegada, Servicio.[HoraPartidaServicio] HoraPartida, Servicio.[HoraLlegadaServicio] HoraLlegada, Servicio.[TiempoDeViaje], Calidad.[EsAtencionEjecutiva], Categoria.[NombreCategoria] Categoria FROM Pasaje INNER JOIN Servicio ON Servicio.[IDServicio] = Pasaje.[FK_IDServicio] INNER JOIN Calidad ON Calidad.[IDCalidad] = Servicio.[FK_IDCalidad] INNER JOIN Categoria ON Categoria.[NombreCategoria] = Calidad.[FK_NombreCategoria] WHERE Pasaje.[FK_UserName] = '{FormInicio.user}'";

                using (SqlDataAdapter adapter = new SqlDataAdapter(sqlPasaje, connection))
                {
                    adapter.Fill(dataTable);
                }

                connection.Close();
            }

            Ajustar();
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