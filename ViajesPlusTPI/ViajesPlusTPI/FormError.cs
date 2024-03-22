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
    public partial class FormError : Form
    {
        public FormError(string mensaje)
        {
            InitializeComponent();
            label1.Text = mensaje.ToUpper();
        }

        private void buttonOK_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}