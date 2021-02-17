using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using System.Data.SqlClient;

namespace Iris.conexion
{
    public class Conexion
    {
        private SqlConnection con;
        public static Conexion cnn;

        public Conexion()
        {
            Console.Write("creando instancia de conexion");
            String cadenaConexion = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            con = new SqlConnection(cadenaConexion);
        }

        public SqlConnection getConexion()
        {
            return con;
        }

        public void cerrarConexion()
        {
            con.Close();
            cnn = null;
        }

        public void abrirConexion()
        {
            con.Open();
        }

    
    }
}