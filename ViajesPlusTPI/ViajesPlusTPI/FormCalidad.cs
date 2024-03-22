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
    public partial class FormCalidad : Form
    {
        public FormCalidad()
        {
            InitializeComponent();

            using (SqlConnection connection = new SqlConnection(FormMain.coneccion))
            {
                connection.Open();

                string sqlCalidad = "SELECT IDCalidad FROM Calidad";
                using (SqlCommand command = new SqlCommand(sqlCalidad, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            comboBoxIDCV.Items.Add($"{reader.GetInt32(reader.GetOrdinal("IDCalidad"))}");
                        }
                    }
                    connection.Close();
                }
            }
        }

        private void buttonVer_Click(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(FormMain.coneccion))
                {
                    connection.Open();

                    string sqlCalidad = $"SELECT EsAtencionEjecutiva, FK_NombreCategoria FROM Calidad WHERE IDCalidad = '{int.Parse(comboBoxIDCV.Text)}'";
                    using (SqlCommand command = new SqlCommand(sqlCalidad, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                textCat.Text = reader.GetString(reader.GetOrdinal("FK_NombreCategoria"));
                                if (reader.GetBoolean(reader.GetOrdinal("EsAtencionEjecutiva")) == false) { txtAtencion.Text = "Comun"; } else { txtAtencion.Text = "Ejecutiva"; }
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
    }
}