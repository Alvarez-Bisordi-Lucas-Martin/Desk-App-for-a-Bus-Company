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
    public partial class FormMain : Form
    {
        public static string coneccion = "Data Source=LUCASALVAREZ\\SQLEXPRESS;Initial Catalog=ViajesTPI;Integrated Security=True";

        public FormMain()
        {
            InitializeComponent();
            timer1.Start();
            timer2.Start();
            if (FormInicio.admin == false)
            {
                serviciosToolStripMenuItem.Visible = false;
                consultasToolStripMenuItem.Visible = false;
                string link = "C:\\Users\\lukas\\OneDrive\\Documentos\\Tecnicatura en Programacion\\2do Año\\2do Cuatrimestre\\Base de Datos\\ViajesPlusTPI\\Publi.mp4";
                axWindowsMediaPlayer1.URL = link;
            }
            else
            {
                pasajesToolStripMenuItem.Visible = false;
                axWindowsMediaPlayer1.Visible = false;
            }
        }

        private void cerrarSesionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormInicio.admin = false;
            this.Close();
            Application.Restart();
        }

        private void paradaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form formParada = new FormParada();
            this.Hide();
            formParada.ShowDialog();
            this.Show();
        }

        private void itinerarioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form formItinerario = new FormItinerario();
            this.Hide();
            formItinerario.ShowDialog();
            this.Show();
        }
        
        private void ordenItinerarioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form formOrdenItinerario = new FormOrdenItinerario();
            this.Hide();
            formOrdenItinerario.ShowDialog();
            this.Show();
        }

        private void servicioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form formServicio = new FormServicio();
            this.Hide();
            formServicio.ShowDialog();
            this.Show();
        }

        private void transporteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form formTransporte = new FormTransporte();
            this.Hide();
            formTransporte.ShowDialog();
            this.Show();
        }

        private void categoriaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form formCategoria = new FormCategoria();
            this.Hide();
            formCategoria.ShowDialog();
            this.Show();
        }

        private void calidadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form formCalidad = new FormCalidad();
            this.Hide();
            formCalidad.ShowDialog();
            this.Show();
        }

        private void costoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form formCosto = new FormCosto();
            this.Hide();
            formCosto.ShowDialog();
            this.Show();
        }

        private void demandaDeCostosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form formDemanda = new FormDemanda();
            this.Hide();
            formDemanda.ShowDialog();
            this.Show();
        }

        private void pasajesPorItinerarioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form formPasajePorItinerario = new FormPasajePorItinerario();
            this.Hide();
            formPasajePorItinerario.ShowDialog();
            this.Show();
        }

        private void pasajesPorFechaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form formPasajePorFecha = new FormPasajePorFecha();
            this.Hide();
            formPasajePorFecha.ShowDialog();
            this.Show();
        }

        private void pasajePorCategoriaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form formPasajePorCategoria = new FormPasajePorCategoria();
            this.Hide();
            formPasajePorCategoria.ShowDialog();
            this.Show();
        }

        private void servicioPorItinerarioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form formServicioPorItinerario = new FormServicioPorItinerario();
            this.Hide();
            formServicioPorItinerario.ShowDialog();
            this.Show();
        }

        private void insertarConsultaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form formSeguridad = new FormSeguridad();
            this.Hide();
            formSeguridad.ShowDialog();
            if (FormSeguridad.seguridad == true)
            {
                Form formConsulta = new FormConsulta();
                formConsulta.ShowDialog();
            }
            this.Show();
        }

        private void reservarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form formReservar = new FormReservar();
            this.Hide();
            formReservar.ShowDialog();
            this.Show();
        }

        private void abonarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form formAbonar = new FormAbonar();
            this.Hide();
            formAbonar.ShowDialog();
            this.Show();
        }

        private void cancelarReservaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form formCancelarReserva = new FormCancelarReserva();
            this.Hide();
            formCancelarReserva.ShowDialog();
            this.Show();
        }

        private void misPasajesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form formMisPasajes = new FormMisPasajes();
            this.Hide();
            formMisPasajes.ShowDialog();
            this.Show();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Start();
            DateTime fechaHoraActual = DateTime.Now;
            label6.Text = fechaHoraActual.ToString();
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            using (SqlConnection cn = new SqlConnection(FormMain.coneccion))
            {
                SqlCommand cmd = new SqlCommand("EXEC EliminarPasajesNoAbonados", cn);
                cmd.CommandType = CommandType.Text;
                cn.Open();
                cmd.ExecuteNonQuery();
                cn.Close();
            }
        }
    }
}