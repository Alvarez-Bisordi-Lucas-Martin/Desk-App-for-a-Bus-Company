using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace ViajesPlusTPI
{
    public partial class FormDemanda : Form
    {
        public FormDemanda()
        {
            InitializeComponent();
            Iniciar();
        }

        private void Iniciar()
        {
            Limpiar();
            using (SqlConnection connection = new SqlConnection(FormMain.coneccion))
            {
                connection.Open();

                string sqlDemanda = "SELECT IDServicio FROM Servicio";
                using (SqlCommand command = new SqlCommand(sqlDemanda, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            comboBoxIDSG.Items.Add($"{reader.GetInt32(reader.GetOrdinal("IDServicio"))}");
                            comboBoxIDSE.Items.Add($"{reader.GetInt32(reader.GetOrdinal("IDServicio"))}");
                            comboBoxIDSV.Items.Add($"{reader.GetInt32(reader.GetOrdinal("IDServicio"))}");
                        }
                    }
                    connection.Close();
                }
            }

            using (SqlConnection connection = new SqlConnection(FormMain.coneccion))
            {
                connection.Open();

                string sqlDemanda = "SELECT TipoCosto FROM Costo";
                using (SqlCommand command = new SqlCommand(sqlDemanda, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            comboBoxCE.Items.Add($"{reader.GetString(reader.GetOrdinal("TipoCosto"))}");
                            comboBoxCG.Items.Add($"{reader.GetString(reader.GetOrdinal("TipoCosto"))}");
                        }
                    }
                    connection.Close();
                }
            }
        }

        private void Limpiar()
        {
            comboBoxIDSG.Items.Clear();
            comboBoxIDSE.Items.Clear();
            comboBoxIDSV.Items.Clear();
            comboBoxCG.Items.Clear();
            comboBoxCE.Items.Clear();
            comboBoxCV.Items.Clear();
        }

        private void buttonGI_Click(object sender, EventArgs e)
        {
            try
            {
                AgregarDemanda();
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
                EliminarDemanda();
            }
            catch (Exception ex)
            {
                Form formError = new FormError(ex.Message);
                formError.ShowDialog();
            }
            Iniciar();
        }

        private void AgregarDemanda()
        {
            using (SqlConnection cn = new SqlConnection(FormMain.coneccion))
            {
                SqlCommand cmd = new SqlCommand
                    ($"INSERT INTO DemandaServicio (FK_TipoCosto, FK_IDServicio)" +
                    $"VALUES ('{comboBoxCG.Text}', '{int.Parse(comboBoxIDSG.Text)}')", cn);
                cmd.CommandType = CommandType.Text;
                cn.Open();
                cmd.ExecuteNonQuery();
                cn.Close();
            }

            Form formRealizado = new FormRealizado();
            formRealizado.ShowDialog();
        }

        private void buttonVI_Click(object sender, EventArgs e)
        {
            try
            {
                VerDemanda();
            }
            catch (Exception ex)
            {
                Form formError = new FormError(ex.Message);
                formError.ShowDialog();
            }
        }

        private void VerDemanda()
        {
            bool vacio = true;

            using (SqlConnection connection = new SqlConnection(FormMain.coneccion))
            {
                connection.Open();

                string sqlDemanda = $"SELECT FK_TipoCosto FROM DemandaServicio WHERE FK_IDServicio = '{comboBoxIDSV.Text}'";
                using (SqlCommand command = new SqlCommand(sqlDemanda, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            comboBoxCV.Items.Add($"{reader.GetString(reader.GetOrdinal("FK_TipoCosto"))}");
                            vacio = false;
                        }
                    }
                    connection.Close();
                }
            }
            if (vacio)
            {
                comboBoxCV.Items.Add("Vacio...");
                comboBoxCV.SelectedIndex = 0;
            }
            else
            {
                comboBoxCV.SelectedIndex = 0;
            }
        }

        private void EliminarDemanda()
        {
            using (SqlConnection cn = new SqlConnection(FormMain.coneccion))
            {
                SqlCommand cmd = new SqlCommand
                    ($"DELETE FROM DemandaServicio WHERE FK_IDServicio = '{comboBoxIDSE.Text}' AND FK_TipoCosto = '{comboBoxCE.Text}'", cn);
                cmd.CommandType = CommandType.Text;
                cn.Open();
                cmd.ExecuteNonQuery();
                cn.Close();
            }

            Form formRealizado = new FormRealizado();
            formRealizado.ShowDialog();
        }

        private void comboBoxIDSV_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBoxCV.Items.Clear();
        }
    }
}