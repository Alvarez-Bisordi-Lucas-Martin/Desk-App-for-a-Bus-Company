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
    public partial class FormConsulta : Form
    {
        public FormConsulta()
        {
            InitializeComponent();
        }

        private void buttonHacer_Click(object sender, EventArgs e)
        {
            try
            {
                DataTable dataTable = new DataTable();
                dataGridViewI.AutoGenerateColumns = true;
                dataGridViewI.DataSource = dataTable;

                using (SqlConnection connection = new SqlConnection(FormMain.coneccion))
                {
                    connection.Open();

                    string sqlConsulta = $"{txtConsulta.Text}";

                    using (SqlDataAdapter adapter = new SqlDataAdapter(sqlConsulta, connection))
                    {
                        adapter.Fill(dataTable);
                    }

                    connection.Close();
                }

                //Ajustar();
            }
            catch (Exception ex)
            {
                Form formError = new FormError(ex.Message);
                formError.ShowDialog();
            }
        }

        private void buttonLimpiar_Click(object sender, EventArgs e)
        {
            txtConsulta.Text = "";
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