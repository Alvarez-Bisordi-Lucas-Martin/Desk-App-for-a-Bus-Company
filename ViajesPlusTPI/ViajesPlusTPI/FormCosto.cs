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
    public partial class FormCosto : Form
    {
        public FormCosto()
        {
            InitializeComponent();

            using (SqlConnection connection = new SqlConnection(FormMain.coneccion))
            {
                connection.Open();

                string sqlCosto = "SELECT TipoCosto FROM Costo";
                using (SqlCommand command = new SqlCommand(sqlCosto, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            comboBoxIDCV.Items.Add($"{reader.GetString(reader.GetOrdinal("TipoCosto"))}");
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

                    string sqlCosto = $"SELECT * FROM Costo WHERE TipoCosto = '{comboBoxIDCV.Text}'";
                    using (SqlCommand command = new SqlCommand(sqlCosto, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                txtMonto.Text = reader.GetDouble(reader.GetOrdinal("PrecioUnitario")).ToString();
                                txtUnidad.Text = reader.GetString(reader.GetOrdinal("UnidadDeMedida"));
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