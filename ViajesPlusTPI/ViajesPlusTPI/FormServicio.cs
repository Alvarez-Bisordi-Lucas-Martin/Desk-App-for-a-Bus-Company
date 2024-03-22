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
    public partial class FormServicio : Form
    {
        int IDSM, IDSE, IDSV, IDCG, IDIG, IDTG, IDCM, IDIM, IDTM;

        public FormServicio()
        {
            InitializeComponent();
            Iniciar();
        }

        private void Iniciar()
        {
            Limpiar();

            using (SqlConnection cn = new SqlConnection(FormMain.coneccion))
            {
                SqlCommand cmd = new SqlCommand("EXEC EliminarPasajesNoAbonados", cn);
                cmd.CommandType = CommandType.Text;
                cn.Open();
                cmd.ExecuteNonQuery();
                cn.Close();
            }

            comboBoxDisp.Items.Add("SI");
            comboBoxDisp.Items.Add("NO");

            using (SqlConnection connection = new SqlConnection(FormMain.coneccion))
            {
                connection.Open();

                string sqlServicio = "SELECT IDServicio FROM Servicio";
                using (SqlCommand command = new SqlCommand(sqlServicio, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            comboBoxIDSM.Items.Add($"{reader.GetInt32(reader.GetOrdinal("IDServicio"))}");
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

                string sqlItinerario = "SELECT IDItinerario FROM Itinerario";
                using (SqlCommand command = new SqlCommand(sqlItinerario, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            comboBoxIDIG.Items.Add($"{reader.GetInt32(reader.GetOrdinal("IDItinerario"))}");
                            comboBoxIDIM.Items.Add($"{reader.GetInt32(reader.GetOrdinal("IDItinerario"))}");
                        }
                    }
                    connection.Close();
                }
            }

            using (SqlConnection connection = new SqlConnection(FormMain.coneccion))
            {
                connection.Open();

                string sqlUnidadTransporte = "SELECT IDTransporte FROM UnidadTransporte";
                using (SqlCommand command = new SqlCommand(sqlUnidadTransporte, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            comboBoxIDTG.Items.Add($"{reader.GetInt32(reader.GetOrdinal("IDTransporte"))}");
                            comboBoxIDTM.Items.Add($"{reader.GetInt32(reader.GetOrdinal("IDTransporte"))}");
                        }
                    }
                    connection.Close();
                }
            }

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
                            comboBoxIDCG.Items.Add($"{reader.GetInt32(reader.GetOrdinal("IDCalidad"))}");
                            comboBoxIDCM.Items.Add($"{reader.GetInt32(reader.GetOrdinal("IDCalidad"))}");
                        }
                    }
                    connection.Close();
                }
            }
        }

        private void AgregarServicio()
        {
            IDIG = int.Parse(comboBoxIDIG.Text);
            IDCG = int.Parse(comboBoxIDCG.Text);
            IDTG = int.Parse(comboBoxIDTG.Text);

            string horaS = "", horaL = "";

            using (SqlConnection connection = new SqlConnection(FormMain.coneccion))
            {
                connection.Open();

                string sqlItinerario = $"SELECT HorarioPartidaItinerario, HorarioLlegadaItinerario FROM Itinerario WHERE IDItinerario = '{IDIG}'";
                using (SqlCommand command = new SqlCommand(sqlItinerario, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                           horaS = reader.GetTimeSpan(reader.GetOrdinal("HorarioPartidaItinerario")).ToString();
                           horaL = reader.GetTimeSpan(reader.GetOrdinal("HorarioLlegadaItinerario")).ToString();
                        }
                    }
                    connection.Close();
                }
            }

            using (SqlConnection cn = new SqlConnection(FormMain.coneccion))
            {
                SqlCommand cmd = new SqlCommand
                    ($"INSERT INTO Servicio (FechaPartidaServicio, FechaLlegadaServicio, HoraPartidaServicio, HoraLlegadaServicio, HayDisponibilidad, FK_IDCalidad, FK_IDItinerario, FK_IDTransporte)" +
                    $"VALUES ('{dateTimePickerFechaPG.Text}', '{dateTimePickerFechaLG.Text}', '{horaS}', '{horaL}', '{1}', '{IDCG}', '{IDIG}', '{IDTG}')", cn);
                cmd.CommandType = CommandType.Text;
                cn.Open();
                cmd.ExecuteNonQuery();
                cn.Close();
            }

            Form formRealizado = new FormRealizado();
            formRealizado.ShowDialog();
        }

        private void comboBoxIDSV_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            textBoxIDC.Text = "";
            textBoxIDI.Text = "";
            textBoxIDT.Text = "";
            textBoxHSalV.Text = "";
            textBoxHLleV.Text = "";
            textBoxFSalV.Text = "";
            textBoxFLleV.Text = "";
            textBoxDisp.Text = "";
            textBoxTiempo.Text = "";
            textBoxAsientos.Text = "";
        }

        private void buttonGS_Click(object sender, EventArgs e)
        {
            try
            {
                AgregarServicio();
            }
            catch (Exception ex)
            {
                Form formError = new FormError(ex.Message);
                formError.ShowDialog();
            }
            Iniciar();
        }

        private void buttonES_Click(object sender, EventArgs e)
        {
            try
            {
                EliminarServicio();
            }
            catch (Exception ex)
            {
                Form formError = new FormError(ex.Message);
                formError.ShowDialog();
            }
            Iniciar();
        }

        private void buttonMS_Click(object sender, EventArgs e)
        {
            try
            {
                ModificarServicio();
            }
            catch (Exception ex)
            {
                Form formError = new FormError(ex.Message);
                formError.ShowDialog();
            }
            Iniciar();
        }

        private void buttonVS_Click(object sender, EventArgs e)
        {
            try
            {
                VerServicio();
            }
            catch (Exception ex)
            {
                Form formError = new FormError(ex.Message);
                formError.ShowDialog();
            }
        }

        private void ModificarServicio()
        {
            int disp;
            if (comboBoxDisp.Text == "SI") { disp = 1; } else { disp = 0; }

            IDSM = int.Parse(comboBoxIDSM.Text);
            IDIM = int.Parse(comboBoxIDIM.Text);
            IDCM = int.Parse(comboBoxIDCM.Text);
            IDTM = int.Parse(comboBoxIDTM.Text);

            using (SqlConnection cn = new SqlConnection(FormMain.coneccion))
            {
                SqlCommand cmd = new SqlCommand
                    ($"UPDATE Servicio SET " +
                    $"FechaPartidaServicio = '{dateTimePickerFechaPM.Value.ToShortDateString()}', HoraPartidaServicio = '{dateTimePickerHoraPM.Text}'," +
                    $"FechaLlegadaServicio = '{dateTimePickerFechaLM.Value.ToShortDateString()}', HoraLlegadaServicio = '{dateTimePickerHoraLM.Text}'," +
                    $"HayDisponibilidad = '{disp}', FK_IDCalidad = '{IDCM}', FK_IDItinerario = '{IDIM}', FK_IDTransporte = '{IDTM}' WHERE IDServicio = '{IDSM}'", cn);
                cmd.CommandType = CommandType.Text;
                cn.Open();
                cmd.ExecuteNonQuery();
                cn.Close();
            }

            Form formRealizado = new FormRealizado();
            formRealizado.ShowDialog();
        }

        private void VerServicio()
        {
            IDSV = int.Parse(comboBoxIDSV.Text);
            string disp;

            using (SqlConnection connection = new SqlConnection(FormMain.coneccion))
            {
                connection.Open();

                string sqlServicio = $"SELECT * FROM Servicio WHERE IDServicio = '{IDSV}'";
                using (SqlCommand command = new SqlCommand(sqlServicio, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            textBoxIDC.Text = reader.GetInt32(reader.GetOrdinal("FK_IDCalidad")).ToString();
                            textBoxIDI.Text = reader.IsDBNull(reader.GetOrdinal("FK_IDItinerario")) ? "NULL" : reader.GetInt32(reader.GetOrdinal("FK_IDItinerario")).ToString();
                            textBoxIDT.Text = reader.IsDBNull(reader.GetOrdinal("FK_IDTransporte")) ? "NULL" : reader.GetInt32(reader.GetOrdinal("FK_IDTransporte")).ToString();
                            textBoxHSalV.Text = reader.GetTimeSpan(reader.GetOrdinal("HoraPartidaServicio")).ToString();
                            textBoxHLleV.Text = reader.GetTimeSpan(reader.GetOrdinal("HoraLlegadaServicio")).ToString();
                            textBoxFSalV.Text = reader.GetDateTime(reader.GetOrdinal("FechaPartidaServicio")).ToShortDateString();
                            textBoxFLleV.Text = reader.GetDateTime(reader.GetOrdinal("FechaLlegadaServicio")).ToShortDateString();
                            if (reader.GetBoolean(reader.GetOrdinal("HayDisponibilidad")) == true) { disp = "SI"; } else { disp = "NO"; }
                            textBoxDisp.Text = disp;
                            textBoxTiempo.Text = reader.GetInt32(reader.GetOrdinal("TiempoDeViaje")).ToString();
                            textBoxAsientos.Text = reader.GetInt32(reader.GetOrdinal("AsientosDisponibles")).ToString();
                        }
                    }
                    connection.Close();
                }
            }
        }

        private void EliminarServicio()
        {
            IDSE = int.Parse(comboBoxIDSE.Text);

            using (SqlConnection cn = new SqlConnection(FormMain.coneccion))
            {
                SqlCommand cmd = new SqlCommand
                    ($"DELETE FROM Servicio WHERE IDServicio = '{IDSE}'", cn);
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
            textBoxIDC.Text = "";
            textBoxIDI.Text = "";
            textBoxIDT.Text = "";
            textBoxHSalV.Text = "";
            textBoxHLleV.Text = "";
            textBoxFSalV.Text = "";
            textBoxFLleV.Text = "";
            textBoxDisp.Text = "";
            textBoxTiempo.Text = "";
            textBoxAsientos.Text = "";
            dateTimePickerFechaLG.Value = DateTime.Now;
            dateTimePickerFechaPG.Value = DateTime.Now;
            dateTimePickerFechaLM.Value = DateTime.Now;
            dateTimePickerHoraPM.Value = DateTimePicker.MinimumDateTime.Date + new TimeSpan(0, 0, 0);
            dateTimePickerFechaPM.Value = DateTime.Now;
            dateTimePickerHoraLM.Value = DateTimePicker.MinimumDateTime.Date + new TimeSpan(0, 0, 0);
            comboBoxIDSM.Items.Clear();
            comboBoxIDSE.Items.Clear();
            comboBoxIDSV.Items.Clear();
            comboBoxIDCG.Items.Clear();
            comboBoxIDIG.Items.Clear();
            comboBoxIDTG.Items.Clear();
            comboBoxIDCM.Items.Clear();
            comboBoxIDIM.Items.Clear();
            comboBoxIDTM.Items.Clear();
            comboBoxDisp.Items.Clear();
        }
    }
}