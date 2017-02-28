using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SIPAA_DEV
{
    public class Conexion
    {
        SqlConnection cn;
        SqlCommand cmd;
        //SqlDataReader dr;

        public Conexion()
        {
            try
            {
                cn = new SqlConnection("Data Source=192.168.9.77;Initial Catalog=sipaa_d;User ID=Desarrollo;Password=Desa17");
                cn.Open();
                MessageBox.Show("Conectado");
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se concto con la BD: " + ex.ToString());
            }
        }

        //public int usuarioEncontrado(string nombre, string pwd)
        //{
        //    int resultado = 0;

        //    try
        //    {
        //        cmd = new SqlCommand("select count(1) from ACCECUSUARIO where NOMBRE ='" + nombre + "' AND PASSW = '" + pwd + "'", cn);
        //        dr = cmd.ExecuteReader();

        //        if (dr.Read())
        //        {
        //            resultado = 1;
        //            Console.WriteLine("Si");
        //        }
        //        else
        //        {
        //            resultado = 0;
        //            Console.WriteLine("No");
        //        }
        //        dr.Close();
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show("No se encontro usuario: " + ex);
        //    }

        //    return resultado;

        //}
        
        public void crearAccesoUsuario(string cvusuario,int idtrab,string nombre, string passw, int stusuario, string usumod,DateTime fhumod, string prgumod)
        {
            int dr;
            try
            {
                cmd = new SqlCommand("insert into ACCECUSUARIO(CVUSUARIO,IDTRAB,NOMBRE,PASSW,STUSUARIO,USUUMOD,FHUMOD,PRGUMOD) values" +
                                    "('" + cvusuario + "','" + idtrab + "', '" + nombre + "','" + passw + "', '" + stusuario + "','" + usumod + "','" + fhumod + "','" + prgumod + "')", cn);
                dr = cmd.ExecuteNonQuery();

                if (dr == 1)
                {
                    MessageBox.Show("Se ha creado correctamente");
                }
                else
                {
                    MessageBox.Show("No se puede crear");
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("No pudo crear: " + ex);
            }  
        }

        public void crearModulo(string cvmodulo, string descripcion, string cvmodpad, int orden, string ambiente, string modulo, string usuumod, DateTime fhumod, string prgumod)
        {
            int dr;
            try
            {
                cmd = new SqlCommand("insert into ACCECMODULO(CVMODULO,DESCRIPCION,CVMODPAD,ORDEN,AMBIENTE,MODULO,USUUMOD,FHUMOD,PRGUMOD) values" +
                                   "('" + cvmodulo + "','" + descripcion + "', '" + cvmodpad + "','" + orden + "', '" + ambiente + "','" + modulo + "','" + usuumod + "','" + fhumod + "','"+ prgumod + "')", cn);
                dr = cmd.ExecuteNonQuery();

                if (dr == 1)
                {
                    MessageBox.Show("Se ha creado correctamente");
                }
                else
                {
                    MessageBox.Show("No se puede crear");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se pudo crear el modulo: " + ex);
            }
        }
    }
}
