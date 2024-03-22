using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ViajesPlusTPI
{
    public partial class FormInicio : Form
    {
        bool inicio = false;

        public static bool admin = false;

        public static string user = "";

        string mensaje = "INGRESE BIEN SU NOMBRE DE USUARIO Y CONTRASEÑA!";

        public FormInicio()
        {
            InitializeComponent();

            using (SqlConnection cn = new SqlConnection(FormMain.coneccion))
            {
                SqlCommand cmd = new SqlCommand("EXEC EliminarPasajesNoAbonados", cn);
                cmd.CommandType = CommandType.Text;
                cn.Open();
                cmd.ExecuteNonQuery();
                cn.Close();
            }
        }

        public void Limpiar()
        {
            txtUsuario.Text = "";
            txtContraseña.Text = "";
        }

        private void buttonIniciar_Click_1(object sender, EventArgs e)
        {
            using (SqlConnection connection = new SqlConnection(FormMain.coneccion))
            {
                connection.Open();

                string sqlUsuario = "SELECT UserName, Contrasenia, EsCliente FROM Usuario";
                using (SqlCommand command = new SqlCommand(sqlUsuario, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            if (reader.GetString(reader.GetOrdinal("UserName")) == txtUsuario.Text)
                            {
                                if (reader.GetString(reader.GetOrdinal("Contrasenia")) == txtContraseña.Text)
                                {
                                    if (reader.GetSqlBoolean(reader.GetOrdinal("EsCliente")) == SqlBoolean.False)
                                    {
                                        admin = true;
                                    }
                                    inicio = true;
                                    user = $"{reader.GetString(reader.GetOrdinal("UserName"))}";
                                }
                            }
                        }
                    }
                }
            }

            if (inicio == true)
            {
                Form form1 = new FormMain();
                this.Hide();
                form1.ShowDialog();
                this.Close();
            }
            else
            {
                Form formError = new FormError(mensaje);
                formError.ShowDialog();
            }
            Limpiar();
        }

        private void buttonCrear_Click_1(object sender, EventArgs e)
        {
            Form formCrearCuenta = new FormCrearCuenta();
            formCrearCuenta.ShowDialog();
        }

        private void buttonVer_Click(object sender, EventArgs e)
        {
            if (txtContraseña.PasswordChar == '*')
            {
                txtContraseña.PasswordChar = '\0';
            }
            else
            {
                txtContraseña.PasswordChar = '*';
            }
        }
    }
}