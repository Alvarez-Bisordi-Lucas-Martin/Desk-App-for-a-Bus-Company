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
    public partial class FormCategoria : Form
    {
        public FormCategoria()
        {
            InitializeComponent();
        }

        private void buttonVer_Click(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(FormMain.coneccion))
                {
                    connection.Open();

                    string sqlCategoria = "SELECT * FROM Categoria";
                    using (SqlCommand command = new SqlCommand(sqlCategoria, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                comboBoxIDCV.Items.Add($"{reader.GetString(reader.GetOrdinal("NombreCategoria"))}");
                            }
                        }
                        connection.Close();
                    }
                }
                comboBoxIDCV.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                Form formError = new FormError(ex.Message);
                formError.ShowDialog();
            }
        }
    }
}