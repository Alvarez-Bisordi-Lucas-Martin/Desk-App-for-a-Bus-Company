using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ViajesPlusTPI
{
    public partial class FormSeguridad : Form
    {
        public static bool seguridad = false;
        public static string contraseña = "contraseña";

        public FormSeguridad()
        {
            InitializeComponent();
        }

        private void buttonInsertar_Click(object sender, EventArgs e)
        {
            if (txtContraseña.Text == contraseña)
            {
                seguridad = true;
                this.Close();
            }
            else
            {
                txtContraseña.Text = "Contraseña incorrecta...";
                txtContraseña.ForeColor = Color.Red;
                seguridad = false;
            }
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

        private void txtContraseña_TextChanged(object sender, EventArgs e)
        {
            txtContraseña.ForeColor = Color.Black;
        }
    }
}