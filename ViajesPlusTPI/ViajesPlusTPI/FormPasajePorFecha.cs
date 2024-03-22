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
    public partial class FormPasajePorFecha : Form
    {
        private DataTable dataTable = new DataTable();

        public FormPasajePorFecha()
        {
            InitializeComponent();

            dataGridViewI.AutoGenerateColumns = true;
            dataGridViewI.DataSource = dataTable;

            using (SqlConnection connection = new SqlConnection(FormMain.coneccion))
            {
                connection.Open();

                string sqlServicio = "SELECT Servicio.[IDServicio], Servicio.[FechaPartidaServicio], COALESCE(COUNT(Pasaje.[IDPasaje]), 0) Pasajes FROM Servicio LEFT JOIN Pasaje ON Pasaje.[FK_IDServicio] = Servicio.[IDServicio] GROUP BY Servicio.[IDServicio], Servicio.[FechaPartidaServicio] ORDER BY Pasajes DESC";

                using (SqlDataAdapter adapter = new SqlDataAdapter(sqlServicio, connection))
                {
                    adapter.Fill(dataTable);
                }

                connection.Close();
            }

            //Ajustar();
        }

        private void buttonCopiar_Click_1(object sender, EventArgs e)
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