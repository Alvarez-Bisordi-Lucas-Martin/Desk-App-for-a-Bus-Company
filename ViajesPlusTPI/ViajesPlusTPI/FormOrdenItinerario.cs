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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ProgressBar;

namespace ViajesPlusTPI
{
    public partial class FormOrdenItinerario : Form
    {
        int IDIG, IDIM, IDIE, IDIV, count = 0, cant = 0;

        public FormOrdenItinerario()
        {
            InitializeComponent();
            Iniciar();
        }

        private void ActualizarTabla(int id)
        {
            DataTable dataTable = new DataTable();
            dataGridViewI.AutoGenerateColumns = true;
            dataGridViewI.DataSource = dataTable;

            using (SqlConnection connection = new SqlConnection(FormMain.coneccion))
            {
                connection.Open();

                string sqlConsulta = $"SELECT * FROM OrdenParadaItinerario WHERE FK_IDItinerario = {id} ORDER BY OrdenParada";

                using (SqlDataAdapter adapter = new SqlDataAdapter(sqlConsulta, connection))
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
                            comboBoxIDIG.Items.Add($"{reader.GetInt32(reader.GetOrdinal("IDItinerario"))}");
                            comboBoxIDIM.Items.Add($"{reader.GetInt32(reader.GetOrdinal("IDItinerario"))}");
                            comboBoxIDIE.Items.Add($"{reader.GetInt32(reader.GetOrdinal("IDItinerario"))}");
                            comboBoxIDIV.Items.Add($"{reader.GetInt32(reader.GetOrdinal("IDItinerario"))}");
                        }
                    }
                    connection.Close();
                }
            }

            using (SqlConnection connection = new SqlConnection(FormMain.coneccion))
            {
                connection.Open();

                string sqlParada = "SELECT NombreParada FROM Parada";
                using (SqlCommand command = new SqlCommand(sqlParada, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            comboBoxIDPG.Items.Add($"{reader.GetString(reader.GetOrdinal("NombreParada"))}");
                            comboBoxIDPM.Items.Add($"{reader.GetString(reader.GetOrdinal("NombreParada"))}");
                            comboBoxIDPE.Items.Add($"{reader.GetString(reader.GetOrdinal("NombreParada"))}");
                        }
                    }
                    connection.Close();
                }
            }
        }

        private void AgregarOrdenItinerario()
        {
            IDIG = int.Parse(comboBoxIDIG.Text);

            using (SqlConnection connection = new SqlConnection(FormMain.coneccion))
            {
                connection.Open();

                string sqlOrden = $"SELECT COUNT(*) Contador FROM OrdenParadaItinerario WHERE FK_IDItinerario = '{IDIG}'";
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

                string sqlItinerario = $"SELECT CantidadParadas FROM Itinerario WHERE IDItinerario = '{IDIG}'";
                using (SqlCommand command = new SqlCommand(sqlItinerario, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            cant = reader.GetInt32(reader.GetOrdinal("CantidadParadas"));
                        }
                    }
                }
            }

            if (count < cant)
            {
                using (SqlConnection cn = new SqlConnection(FormMain.coneccion))
                {
                    SqlCommand cmd = new SqlCommand
                        ($"INSERT INTO OrdenParadaItinerario (FK_IDItinerario, FK_NombreParada, FK_NombreCiudad, OrdenParada)" +
                        $"VALUES ('{IDIG}', '{comboBoxIDPG.Text}', '{comboBoxIDPG.Text.Substring("Parada".Length).Trim()}', '{int.Parse(txtOrdenG.Text)}')", cn);
                    cmd.CommandType = CommandType.Text;
                    cn.Open();
                    cmd.ExecuteNonQuery();
                    cn.Close();
                }

                Form formRealizado = new FormRealizado();
                formRealizado.ShowDialog();
            }
            else
            {
                string mensaje = "Ya estan cargadas todas las paradas";
                Form formError = new FormError(mensaje);
                formError.ShowDialog();
            }

            ActualizarTabla(IDIG);
        }

        private void ModificarOrdenItinerario()
        {
            IDIM = int.Parse(comboBoxIDIM.Text);

            using (SqlConnection cn = new SqlConnection(FormMain.coneccion))
            {
                SqlCommand cmd = new SqlCommand
                    ($"UPDATE OrdenParadaItinerario SET OrdenParada = '{int.Parse(txtOrdenM.Text)}' WHERE FK_IDItinerario = '{IDIM}' AND FK_NombreParada = '{comboBoxIDPM.Text}'", cn);
                cmd.CommandType = CommandType.Text;
                cn.Open();
                cmd.ExecuteNonQuery();
                cn.Close();
            }

            Form formRealizado = new FormRealizado();
            formRealizado.ShowDialog();

            ActualizarTabla(IDIM);
        }


        private void buttonGI_Click(object sender, EventArgs e)
        {
            try
            {
                AgregarOrdenItinerario();
            }
            catch (Exception ex)
            {
                Form formError = new FormError(ex.Message);
                formError.ShowDialog();
            }
            Iniciar();
        }

        private void buttonEI_Click(object sender, EventArgs e)
        {
            try
            {
                EliminarOrdenItinerario();
            }
            catch (Exception ex)
            {
                Form formError = new FormError(ex.Message);
                formError.ShowDialog();
            }
            Iniciar();
        }

        private void buttonMI_Click(object sender, EventArgs e)
        {
            try
            {
                ModificarOrdenItinerario();
            }
            catch (Exception ex)
            {
                Form formError = new FormError(ex.Message);
                formError.ShowDialog();
            }
            Iniciar();
        }

        private void buttonVI_Click(object sender, EventArgs e)
        {
            try
            {
                VerOrdenItinerario();
            }
            catch (Exception ex)
            {
                Form formError = new FormError(ex.Message);
                formError.ShowDialog();
            }
        }

        private void VerOrdenItinerario()
        {
            IDIV = int.Parse(comboBoxIDIV.Text);

            ActualizarTabla(IDIV);
        }

        private void EliminarOrdenItinerario()
        {
            IDIE = int.Parse(comboBoxIDIE.Text);

            using (SqlConnection cn = new SqlConnection(FormMain.coneccion))
            {
                SqlCommand cmd = new SqlCommand
                    ($"DELETE FROM OrdenParadaItinerario WHERE FK_IDItinerario = '{IDIE}' AND FK_NombreParada = '{comboBoxIDPE.Text}'", cn);
                cmd.CommandType = CommandType.Text;
                cn.Open();
                cmd.ExecuteNonQuery();
                cn.Close();
            }

            Form formRealizado = new FormRealizado();
            formRealizado.ShowDialog();

            ActualizarTabla(IDIE);
        }

        private void Limpiar()
        {
            txtOrdenM.Text = "";
            txtOrdenG.Text = "";
            comboBoxIDPG.Items.Clear();
            comboBoxIDIG.Items.Clear();
            comboBoxIDIM.Items.Clear();
            comboBoxIDPM.Items.Clear();
            comboBoxIDIE.Items.Clear();
            comboBoxIDPE.Items.Clear();
            comboBoxIDIV.Items.Clear();
        }
    }
}