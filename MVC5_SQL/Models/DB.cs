using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;

namespace MVC5_SQL.Models
{
    public class DB
    {
        SqlConnection conexion = new SqlConnection("data source=DESKTOP-B7GF2C7\\SQLEXPRESS; database=TestMVC5; integrated security = true;");
        SqlCommand comando;
        String query = "";

        public Boolean AbrirConexionDB()
        {
            try
            {
                conexion.Open();

                return true;
            }
            catch
            {
                return false;
            }

        }

        public Boolean CerrarConexionDB()
        {
            try
            {
                conexion.Close();

                return true;
            }
            catch
            {
                return false;
            }

        }

        public Boolean InsertarUsuario(String nombre, String correo)
        {
            try
            {
                query = "INSERT INTO Usuario (NombreUsuario, CorreoUsuario) VALUES (@NombreUsuario, @CorreoUsuario)";

                comando = new SqlCommand(query, conexion);

                comando.Parameters.Add("@NombreUsuario", nombre);
                comando.Parameters.Add("@CorreoUsuario", correo);

                AbrirConexionDB();

                comando.ExecuteNonQuery();

                CerrarConexionDB();

                return true;
            }
            catch
            {
                return false;
            }

        }

    }

}