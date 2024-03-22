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
    public partial class FormCancelarReserva : Form
    {
        public FormCancelarReserva()
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
                            comboBoxPE.Items.Add($"{reader.GetInt32(reader.GetOrdinal("IDPasaje"))}");
                        }
                    }
                    connection.Close();
                }
            }
        }

        private void buttonEI_Click(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection cn = new SqlConnection(FormMain.coneccion))
                {
                    SqlCommand cmd = new SqlCommand
                        ($"DELETE FROM Pasaje WHERE IDPasaje = '{comboBoxPE.Text}'", cn);
                    cmd.CommandType = CommandType.Text;
                    cn.Open();
                    cmd.ExecuteNonQuery();
                    cn.Close();
                }

                Form formRealizado = new FormRealizado();
                formRealizado.ShowDialog();

                comboBoxPE.Items.Clear();
                Iniciar();
            }
            catch (Exception ex)
            {
                Form formError = new FormError(ex.Message);
                formError.ShowDialog();
            }
        }
    }
}