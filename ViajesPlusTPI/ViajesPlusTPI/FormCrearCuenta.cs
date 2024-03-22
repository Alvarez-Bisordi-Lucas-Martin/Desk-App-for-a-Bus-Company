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
    public partial class FormCrearCuenta : Form
    {
        public FormCrearCuenta()
        {
            InitializeComponent();
        }

        public void Limpiar()
        {
            txtUsuario.Text = "";
            txtContraseña.Text = "";
            txtVerificacion.Text = "";
            txtNombre.Text = "";
            txtApellido.Text = "";
        }

        private void txtVerificacion_TextChanged(object sender, EventArgs e)
        {
            txtVerificacion.ForeColor = Color.Black;
        }

        private void buttonCrear_Click_1(object sender, EventArgs e)
        {
            try
            {
                if (txtContraseña.Text == txtVerificacion.Text)
                {
                    using (SqlConnection cn = new SqlConnection(FormMain.coneccion))
                    {
                        SqlCommand cmd = new SqlCommand($"INSERT INTO Usuario (UserName, Contrasenia, NombreUsuario, ApellidoUsuario, EsCliente) VALUES ('{txtUsuario.Text}', '{txtContraseña.Text}', '{txtNombre.Text}', '{txtApellido.Text}', '1')", cn);
                        cmd.CommandType = CommandType.Text;
                        cn.Open();
                        cmd.ExecuteNonQuery();
                        cn.Close();
                    }

                    Form formRealizado = new FormRealizado();
                    formRealizado.ShowDialog();

                    Limpiar();

                    this.Close();
                }
                else
                {
                    txtVerificacion.Text = "Ingrese la Contraseña correcta...";
                    txtVerificacion.ForeColor = Color.Red;
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