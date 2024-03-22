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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace ViajesPlusTPI
{
    public partial class FormAbonar : Form
    {
        double costo = 0, pago = 0;

        public FormAbonar()
        {
            InitializeComponent();

            Iniciar();
        }

        private void Iniciar()
        {
            using (SqlConnection connection = new SqlConnection(FormMain.coneccion))
            {
                connection.Open();

                string sqlPasaje = $"SELECT IDPasaje FROM Pasaje WHERE EstaAbonado = '{0}' AND FK_UserName = '{FormInicio.user}'";
                using (SqlCommand command = new SqlCommand(sqlPasaje, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            comboBoxPA.Items.Add($"{reader.GetInt32(reader.GetOrdinal("IDPasaje"))}");
                        }
                    }
                    connection.Close();
                }
            }
        }

        private void comboBoxPA_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtMonto.Text = "";
            using (SqlConnection connection = new SqlConnection(FormMain.coneccion))
            {
                connection.Open();

                string sqlPasaje = $"SELECT CostoPasaje FROM Pasaje WHERE IDPasaje = '{comboBoxPA.Text}' AND FK_UserName = '{FormInicio.user}'";
                using (SqlCommand command = new SqlCommand(sqlPasaje, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            txtMonto.Text = reader.GetDouble(reader.GetOrdinal("CostoPasaje")).ToString();
                            costo = reader.GetDouble(reader.GetOrdinal("CostoPasaje"));
                        }
                    }
                    connection.Close();
                }
            }
        }

        private void Limpiar()
        {
            txtMonto.Text = "";
            comboBoxPA.Items.Clear();
        }

        private void txtMonto_TextChanged(object sender, EventArgs e)
        {
            txtMonto.ForeColor = Color.Black;
        }

        private void buttonAbonar_Click(object sender, EventArgs e)
        {
            try
            {
                txtMonto.ForeColor = Color.Black;

                pago = double.Parse(txtMonto.Text);

                if (costo == pago)
                {
                    using (SqlConnection cn = new SqlConnection(FormMain.coneccion))
                    {
                        SqlCommand cmd = new SqlCommand
                            ($"UPDATE Pasaje SET EstaAbonado = '{1}' WHERE IDPasaje = '{comboBoxPA.Text}'", cn);
                        cmd.CommandType = CommandType.Text;
                        cn.Open();
                        cmd.ExecuteNonQuery();
                        cn.Close();
                    }

                    Form formRealizado = new FormRealizado();
                    formRealizado.ShowDialog();

                    Limpiar();
                    Iniciar();
                }
                else if (costo < pago)
                {
                    txtMonto.Text = $"Estas abonando ${pago - costo} de mas...";
                    txtMonto.ForeColor = Color.Red;
                }
                else
                {
                    txtMonto.Text = $"Te falta abonar ${costo - pago}...";
                    txtMonto.ForeColor = Color.Red;
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