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
    public partial class FormTransporte : Form
    {
        int IDTM, IDTE, IDTV;
        string IDCG, pisos;

        public FormTransporte()
        {
            InitializeComponent();
            Iniciar();
        }

        private void Iniciar()
        {
            Limpiar();

            comboBoxPisos.Items.Add("1");
            comboBoxPisos.Items.Add("2");
            comboBoxPisosM.Items.Add("1");
            comboBoxPisosM.Items.Add("2");

            using (SqlConnection connection = new SqlConnection(FormMain.coneccion))
            {
                connection.Open();

                string sqlTransporte = "SELECT IDTransporte FROM UnidadTransporte";
                using (SqlCommand command = new SqlCommand(sqlTransporte, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            comboBoxIDTE.Items.Add($"{reader.GetInt32(reader.GetOrdinal("IDTransporte"))}");
                            comboBoxIDTM.Items.Add($"{reader.GetInt32(reader.GetOrdinal("IDTransporte"))}");
                            comboBoxIDTV.Items.Add($"{reader.GetInt32(reader.GetOrdinal("IDTransporte"))}");
                        }
                    }
                    connection.Close();
                }
            }

            using (SqlConnection connection = new SqlConnection(FormMain.coneccion))
            {
                connection.Open();

                string sqlParada = "SELECT NombreCategoria FROM Categoria";
                using (SqlCommand command = new SqlCommand(sqlParada, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            comboBoxIDCG.Items.Add($"{reader.GetString(reader.GetOrdinal("NombreCategoria"))}");
                            comboBoxIDCM.Items.Add($"{reader.GetString(reader.GetOrdinal("NombreCategoria"))}");
                        }
                    }
                    connection.Close();
                }
            }
        }

        private void AgregarTransporte()
        {
            IDCG = comboBoxIDCG.Text;

            using (SqlConnection cn = new SqlConnection(FormMain.coneccion))
            {
                SqlCommand cmd = new SqlCommand
                    ($"INSERT INTO UnidadTransporte (EsDosPisos, CantidadDeAsientos, FK_NombreCategoria)" +
                    $"VALUES ('{comboBoxPisos.Text}', '{txtAsientos.Text}', '{IDCG}')", cn);
                cmd.CommandType = CommandType.Text;
                cn.Open();
                cmd.ExecuteNonQuery();
                cn.Close();
            }

            Form formRealizado = new FormRealizado();
            formRealizado.ShowDialog();
        }

        private void ModificarTransporte()
        {
            int cantVieja = 0, diferencia = 0;
            IDTM = int.Parse(comboBoxIDTM.Text);
            if (comboBoxPisosM.Text == "1") { pisos = "0"; } else { pisos = "1"; }

            using (SqlConnection connection = new SqlConnection(FormMain.coneccion))
            {
                connection.Open();

                string sqlTransporte = $"SELECT CantidadDeAsientos FROM UnidadTransporte WHERE IDTransporte = '{IDTM}'";
                using (SqlCommand command = new SqlCommand(sqlTransporte, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            cantVieja = reader.GetInt32(reader.GetOrdinal("CantidadDeAsientos"));
                        }
                    }
                    connection.Close();
                }

                diferencia = int.Parse(txtAsientosM.Text) - cantVieja;
            }

            using (SqlConnection cn = new SqlConnection(FormMain.coneccion))
            {
                SqlCommand cmd = new SqlCommand
                    ($"UPDATE UnidadTransporte SET EsDosPisos = '{pisos}', CantidadDeAsientos = '{txtAsientosM.Text}', FK_NombreCategoria = '{comboBoxIDCM.Text}' WHERE IDTransporte = '{IDTM}'", cn);
                cmd.CommandType = CommandType.Text;
                cn.Open();
                cmd.ExecuteNonQuery();
                cn.Close();
            }

            using (SqlConnection cn = new SqlConnection(FormMain.coneccion))
            {
                SqlCommand cmd = new SqlCommand
                    ($"UPDATE Servicio SET AsientosDisponibles = AsientosDisponibles + {diferencia}, HayDisponibilidad = CASE WHEN AsientosDisponibles + {diferencia} > 0 THEN '{1}' ELSE '{0}' END WHERE FK_IDTransporte = '{IDTM}'", cn);
                cmd.CommandType = CommandType.Text;
                cn.Open();
                cmd.ExecuteNonQuery();
                cn.Close();
            }

            Form formRealizado = new FormRealizado();
            formRealizado.ShowDialog();
        }

        private void buttonGI_Click_1(object sender, EventArgs e)
        {
            try
            {
                AgregarTransporte();
            }
            catch (Exception ex)
            {
                Form formError = new FormError(ex.Message);
                formError.ShowDialog();
            }
            Iniciar();
        }

        private void buttonEI_Click_1(object sender, EventArgs e)
        {
            try
            {
                EliminarTransporte();
            }
            catch (Exception ex)
            {
                Form formError = new FormError(ex.Message);
                formError.ShowDialog();
            }
            Iniciar();
        }

        private void buttonMI_Click_1(object sender, EventArgs e)
        {
            try
            {
                ModificarTransporte();
            }
            catch (Exception ex)
            {
                Form formError = new FormError(ex.Message);
                formError.ShowDialog();
            }
            Iniciar();
        }

        private void buttonVI_Click_1(object sender, EventArgs e)
        {
            try
            {
                VerTransporte();
            }
            catch (Exception ex)
            {
                Form formError = new FormError(ex.Message);
                formError.ShowDialog();
            }
        }

        private void VerTransporte()
        {
            IDTV = int.Parse(comboBoxIDTV.Text);

            using (SqlConnection connection = new SqlConnection(FormMain.coneccion))
            {
                connection.Open();

                string sqlOrdenItinerario = $"SELECT * FROM UnidadTransporte WHERE IDTransporte = '{IDTV}'";
                using (SqlCommand command = new SqlCommand(sqlOrdenItinerario, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            textBoxCat.Text = reader.GetString(reader.GetOrdinal("FK_NombreCategoria"));
                            textAsientosV.Text = reader.GetInt32(reader.GetOrdinal("CantidadDeAsientos")).ToString();
                            if (reader.GetBoolean(reader.GetOrdinal("EsDosPisos")) == false) { textBoxPisos.Text = "1"; } else { textBoxPisos.Text = "2"; }
                        }
                    }
                    connection.Close();
                }
            }
        }

        private void EliminarTransporte()
        {
            IDTE = int.Parse(comboBoxIDTE.Text);

            using (SqlConnection cn = new SqlConnection(FormMain.coneccion))
            {
                SqlCommand cmd = new SqlCommand
                    ($"DELETE FROM UnidadTransporte WHERE IDTransporte = '{IDTE}'", cn);
                cmd.CommandType = CommandType.Text;
                cn.Open();
                cmd.ExecuteNonQuery();
                cn.Close();
            }

            Form formRealizado = new FormRealizado();
            formRealizado.ShowDialog();
        }

        private void Limpiar()
        {
            textAsientosV.Text = "";
            txtAsientosM.Text = "";
            txtAsientos.Text = "";
            textBoxCat.Text = "";
            textBoxPisos.Text = "";
            comboBoxPisos.Items.Clear();
            comboBoxIDCG.Items.Clear();
            comboBoxIDTM.Items.Clear();
            comboBoxPisosM.Items.Clear();
            comboBoxIDCM.Items.Clear();
            comboBoxIDTE.Items.Clear();
            comboBoxIDTV.Items.Clear();
        }
    }
}