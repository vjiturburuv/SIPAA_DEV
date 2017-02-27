using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SIPAA_DEV
{
    public partial class CrearAccesoUsuario : Form
    {
        public Point formPosition;
        public Boolean mouseAction;
        public CrearAccesoUsuario()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {   
            // se instancia la clase conexion
            Conexion c = new Conexion();

            //Se declaran variables locales
            string cvusuario, nombre, passw, usumod, prgumod, fhumod, stusuario;
            DateTime fhumod1;
            int idtrab,stu;

            // Se asginan valores de los componentes
            cvusuario = txtCvUsuario.Text;
            nombre = txtNombre.Text;
            passw = txtPassw.Text;
            usumod = txtUsuUmod.Text;
            prgumod = txtPrgUmod.Text;

            fhumod = dtpFhuMod.Text;

            fhumod1 = DateTime.Parse(fhumod);

            idtrab = int.Parse(txtIdTrab.Text);
            //stusuario = int.Parse(txtStUsuario.Text);
            stusuario = cbStUsuario.Text;

            //asigan el valor del status
            switch (stusuario)
            {
                case "Activo":
                    stu = 1;
                    break;

                case "No Activo":
                    stu = 0;
                    break;

                default:
                    stu = 1;
                    break;
            }

           // se cifra el password en MD5
            MD5 md5 = MD5.Create();
            byte[] inputBytes = System.Text.Encoding.ASCII.GetBytes(passw);
            byte[] hash = md5.ComputeHash(inputBytes);
            passw = BitConverter.ToString(hash).Replace("-", "");
            //txtPassEncriptado.Text = password.ToString();

            // pasamos parametros a la funcion
            c.crearAccesoUsuario(cvusuario, idtrab, nombre, passw, stu, usumod, fhumod1, prgumod);
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

        private void btnMin_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }
    }
}
