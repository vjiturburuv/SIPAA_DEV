using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SIPAA_DEV
{

    public partial class CrearModulo : Form
    {
        public Point formPosition;
        public Boolean mouseAction;
        public CrearModulo()
        {
            InitializeComponent();
        }

        private void BarraSuperior_MouseUp(object sender, MouseEventArgs e)
        {
            mouseAction = false;
        }

        private void BarraSuperior_MouseDown(object sender, MouseEventArgs e)
        {
            formPosition = new Point(Cursor.Position.X - Location.X, Cursor.Position.Y - Location.Y);
            mouseAction = true;
        }

        private void BarraSuperior_MouseMove(object sender, MouseEventArgs e)
        {
            if (mouseAction == true)
            {
                Location = new Point(Cursor.Position.X - formPosition.X, Cursor.Position.Y - formPosition.Y);
            }
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("¿Seguro que dese salir?", "Salir", MessageBoxButtons.YesNoCancel);

            if (result == DialogResult.Yes)
            {
                Application.Exit();
            }
            else if (result == DialogResult.No)
            {

            }
            else if (result == DialogResult.Cancel)
            {

            }
        }

        private void btnMin_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Se instancia la clase conexion
            Conexion c = new Conexion();

            //Se declaran variables locales
            string cvmodulo, descripcion, cvmodpad, ambiente, modulo, usuumod, prgumod,fhumod, fecha, hora, fecha_hora;
            DateTime fhumod1,fh;
            int orden;

            // Se asginan valores de los componentes
            cvmodulo = txtModulo.Text;
            descripcion = txtDescripcion.Text;
            cvmodpad = txtCvModPad.Text;
            ambiente = txtAmbiente.Text;
            modulo = txtModulo.Text;
            usuumod = txtUsuUmod.Text;
            prgumod = txtPrguMod.Text;


            fhumod = dtpFhuMod.Text;
            //Se parsea el texto tomado del datetimepicker 
            fhumod1 = DateTime.Parse(fhumod);

            //orden = int.Parse(txtOrden.Text);

            //se arma la fecha 
            fecha = DateTime.Now.ToShortDateString();
            hora = DateTime.Now.ToLongTimeString();

            fecha_hora = fecha+" "+hora;

            fh = DateTime.Parse(fecha_hora);
            MessageBox.Show(fecha_hora);

            // pasamos parametros a la funcion
            //c.crearModulo(cvmodulo,descripcion,cvmodpad,orden,ambiente,modulo,usuumod,fh,prgumod);
        }
    }
}
