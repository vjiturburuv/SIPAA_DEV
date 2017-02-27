using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIPAA_DEV.Recursos_Humanos.App_Code
{
    class Perfiles
    {

        public int CVPerfil;
        public string Descripcion;
        public string UsuuMod;
        public DateTime FhumMod;
        public string PrguMod;
        Conexion objConexion = new Conexion();

        public Dictionary<int,string> ObtenerListPerfiles() {

            Dictionary<int, string> dcPerfiles = new Dictionary<int, string>();

         //   ConnectionStringSettings strConexion = ConfigurationManager.ConnectionStrings["DefaultConnection"];
            SqlConnection sqlConnection1 = new SqlConnection("Data Source=192.168.9.77;Initial Catalog=sipaa_d;User ID=Desarrollo;Password=Desa17");
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = @"SELECT [CVPERFIL]
                                     ,[DESCRIPCION]
                                     ,[USUUMOD]
                                     ,[FHUMOD]
                                     ,[PRGUMOD]
                                     FROM[dbo].[ACCECPERFIL]";

            cmd.Connection = sqlConnection1;

            sqlConnection1.Open();

            SqlDataReader reader = cmd.ExecuteReader();


            while (reader.Read())
            {

                Perfiles objPerfiles = new Perfiles();
                objPerfiles.CVPerfil = reader.GetInt32(reader.GetOrdinal("CVPERFIL"));
                objPerfiles.Descripcion = reader.GetString(reader.GetOrdinal("DESCRIPCION"));

                dcPerfiles.Add(objPerfiles.CVPerfil, objPerfiles.Descripcion);
            }

            sqlConnection1.Close();

            return dcPerfiles;

        }
    }


}
