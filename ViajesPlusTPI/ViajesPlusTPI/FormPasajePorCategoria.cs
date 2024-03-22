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
    public partial class FormPasajePorCategoria : Form
    {
        private DataTable dataTable = new DataTable();

        public FormPasajePorCategoria()
        {
            InitializeComponent();

            dataGridViewI.AutoGenerateColumns = true;
            dataGridViewI.DataSource = dataTable;

            using (SqlConnection connection = new SqlConnection(FormMain.coneccion))
            {
                connection.Open();

                string sqlCategoria = "SELECT Categoria.[NombreCategoria], COALESCE(COUNT(Pasaje.[IDPasaje]), 0) Pasajes FROM Categoria LEFT JOIN UnidadTransporte ON Categoria.[NombreCategoria] = UnidadTRansporte.[FK_NombreCategoria] LEFT JOIN Servicio ON UnidadTransporte.[IDTransporte] = Servicio.[FK_IDTransporte] LEFT JOIN Pasaje ON Pasaje.[FK_IDServicio] = Servicio.[IDServicio] GROUP BY Categoria.[NombreCategoria] ORDER BY Pasajes DESC";

                using (SqlDataAdapter adapter = new SqlDataAdapter(sqlCategoria, connection))
                {
                    adapter.Fill(dataTable);
                }

                connection.Close();
            }

            Ajustar();
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