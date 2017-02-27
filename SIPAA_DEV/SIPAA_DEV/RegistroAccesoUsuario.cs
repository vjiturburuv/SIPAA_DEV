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
    public partial class RegistroAccesoUsuario : Form
    {
        Conexion c = new Conexion();
        public RegistroAccesoUsuario()
        {
            InitializeComponent();

        }

        private void RegistroAccesoUsuario_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Conexion c = new Conexion();
            string cvusuario,nombre, passw, usumod, prgumod, fhumod;
            DateTime fhumod1;
            int idtrab, stusuario;

            cvusuario = txtCvUsuario.Text;
            nombre = txtNombre.Text;
            passw = txtPassw.Text;
            usumod = txtUsuUmod.Text;
            prgumod = txtPrgUmod.Text;

            fhumod = dtpFhuMod.Text;

            fhumod1 = DateTime.Parse(fhumod);

            idtrab = int.Parse(txtIdTrab.Text);
            stusuario = int.Parse(txtStUsuario.Text);


            MD5 md5 = MD5.Create();
            byte[] inputBytes = System.Text.Encoding.ASCII.GetBytes(passw);
            byte[] hash = md5.ComputeHash(inputBytes);
            passw = BitConverter.ToString(hash).Replace("-", "");
            //txtPassEncriptado.Text = password.ToString();

            c.crearAccesoUsuario(cvusuario,idtrab,nombre,passw,stusuario,usumod,fhumod1,prgumod);

            
        }
    }
}
