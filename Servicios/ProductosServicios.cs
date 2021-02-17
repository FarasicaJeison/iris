using Iris.conexion;
using Iris.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Iris.Servicios
{
    public class ProductosServicios
    {
        Conexion con = new Conexion();
        public List<modelsProducto> listaproductos()
        {
            try
            {
                List<modelsProducto> lista = new List<modelsProducto>();
                //SqlConnection cnn = con.abrirConexion();
                SqlConnection cnn = con.getConexion();
                if (cnn.State != ConnectionState.Open)
                {
                    cnn.Open();
                }
                SqlCommand cmd = new SqlCommand("proalmaProductos", cnn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@option", 4);
                cmd.Parameters.AddWithValue("@nombprod", "");
                cmd.Parameters.AddWithValue("@descprod", "");
                cmd.Parameters.AddWithValue("@codiprod", "");
                SqlDataReader Rs = cmd.ExecuteReader();

                while (Rs.Read())
                {
                    lista.Add(new modelsProducto(Rs.GetInt32(0), Rs.GetString(1), Rs.GetString(2), Rs.GetInt32(3)));
                }
                return lista;
            }
            catch (SqlException e)
            {
                e.ToString();
            }
            finally
            {
                con.cerrarConexion();
            }
            return null;
        }

        public Boolean agregarPaciente(int pasinume, string pasinomb, string pasiapel, DateTime pasifech, string pasidire)
        {
            try
            {
                SqlConnection cnn = con.getConexion();
                if (cnn.State != ConnectionState.Open)
                {
                    cnn.Open();
                }
                SqlCommand cmd = new SqlCommand("pacientes", cnn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@pasinume", pasinume);
                cmd.Parameters.AddWithValue("@pasinomb", pasinomb);
                cmd.Parameters.AddWithValue("@pasiapel", pasiapel);
                cmd.Parameters.AddWithValue("@pasifech", pasifech);
                cmd.Parameters.AddWithValue("@pasedire", pasidire);
                cmd.Parameters.AddWithValue("@option", 1);
                int consecutivo = cmd.ExecuteNonQuery();
                if (consecutivo > 0) { return true; }
            }
            catch (SqlException e)
            {
                e.ToString();
            }
            finally
            {
                con.cerrarConexion();
                
            }
            return false;
        }

        public List<modelsProducto> listarproductos(int codiproc, int opcion)
        {
            try
            {
                List<modelsProducto> listacol = new List<modelsProducto>();
                SqlConnection cnn = con.getConexion();
                if (cnn.State != ConnectionState.Open)
                {
                    cnn.Open();
                }
                SqlCommand cmd = new SqlCommand("proalmaProductos", cnn);
                cmd.CommandType = CommandType.StoredProcedure;// con esta le digo que es un procedimiento procesado
                cmd.Parameters.AddWithValue("@codiproc", codiproc);
                cmd.Parameters.AddWithValue("@option", opcion);
                SqlDataReader rs = cmd.ExecuteReader();
                while (rs.Read())
                {
                    listacol.Add(new modelsProducto(rs.GetInt32(0), rs.GetString(1), rs.GetString(2), rs.GetInt32(3)));
                }
                return listacol;
            }
            catch (SqlException e)
            {
                e.ToString();
            }
            finally
            {
                con.cerrarConexion();
            }
            return null;
        }

        public Boolean eliminarPersona(int pasinume)
        {
            try
            {
                SqlConnection cnn = con.getConexion();
                if (cnn.State != ConnectionState.Open)
                {
                    cnn.Open();
                }
                SqlCommand cmd = new SqlCommand("pacientes", cnn);
                cmd.CommandType = CommandType.StoredProcedure;// con esta le digo que es un procedimiento procesado
                cmd.Parameters.AddWithValue("@pasinume", pasinume);
                cmd.Parameters.AddWithValue("@option", 2);
                int consecutivo = cmd.ExecuteNonQuery();
                if (consecutivo > 0) { return true; }
            }
            catch (SqlException e)
            {
                e.ToString();
            }
            finally
            {
                con.cerrarConexion();
            }
            return false;

        }
    }
}