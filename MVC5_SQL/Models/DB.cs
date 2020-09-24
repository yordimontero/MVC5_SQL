using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;

namespace MVC5_SQL.Models
{
    public class DB
    {
        SqlConnection conexion = new SqlConnection("data source=DESKTOP-B7GF2C7\\SQLEXPRESS; database=TestMVC5; integrated security = true;");
        SqlCommand comando;
        DataTable dataTable;
        SqlDataAdapter adapter;
        String query = "";

        public Boolean AbrirConexionDB()
        {
            //Método para abrir la conexión de la base de datos.
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
            //Método para cerrar la conexión de la base de datos.
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

        public DataTable GetListaUsuariosDB()
        {
            //Método para retornar la lista de Usuarios por medio de un DataTable.
            try
            {
                dataTable = new DataTable();

                query = "SELECT * FROM Usuario";
                
                //Inicializar el Adaptador con el query SELECT.
                adapter = new SqlDataAdapter(query, conexion);

                AbrirConexionDB();

                //Cargar el DataTable con el query SELECT del adaptador.
                adapter.Fill(dataTable);

                CerrarConexionDB();

                //Retornar el DataTable lleno.
                return dataTable;
            }
            catch
            {
                return null;
            }

        }
        
        public Boolean CreateUsuarioDB(String nombre, String correo)
        {
            //Método para crear un nuevo usuario en la base de datos.
            try
            {
                query = "INSERT INTO Usuario (NombreUsuario, CorreoUsuario) VALUES (@NombreUsuario, @CorreoUsuario)";

                //Inicializar el Command con el query INSERT.
                comando = new SqlCommand(query, conexion);

                comando.Parameters.Add("@NombreUsuario", nombre);
                comando.Parameters.Add("@CorreoUsuario", correo);

                AbrirConexionDB();

                //Ejecucuón del Command.
                comando.ExecuteNonQuery();

                CerrarConexionDB();

                return true;
            }
            catch
            {
                return false;
            }

        }

        public Boolean UpdateUsuarioDB(int id, String nombre, String correo)
        {
            //Método para actualizar un Usuario existente en la base de datos.
            try
            {
                query = "UPDATE Usuario (NombreUsuario, CorreoUsuario) SET NombreUsuario=@NombreUsuario, CorreoUsuario=@CorreoUsuario WHERE IdUsuario=@IdUsuario";

                //Inicializar el Command con el query UPDATE.
                comando = new SqlCommand(query, conexion);

                comando.Parameters.Add("@IdUsuario", id);
                comando.Parameters.Add("@NombreUsuario", nombre);
                comando.Parameters.Add("@CorreoUsuario", correo);

                AbrirConexionDB();

                //Ejecución del Command.
                comando.ExecuteNonQuery();

                CerrarConexionDB();

                return true;

            }
            catch
            {
                return false;
            }

        }

        /*public String GetNombreUsuario()
        {

            try
            {
                //query = "SELECT NombreUsuario FROM Usuario WHERE IdUsuario=@IdUsuario";
                query = "SELECT NombreUsuario FROM Usuario";

                comando = new SqlCommand(query, conexion);

                //comando.Parameters.Add("@IdUsuario", id);

                AbrirConexionDB();

                string nombreUsuario = Convert.ToString(comando.ExecuteScalar());

                CerrarConexionDB();

                return nombreUsuario;
            }
            catch
            {
                return null;
            }

        }

        public String GetCorreoUsuario()
        {

            try
            {

                query = "SELECT CorreoUsuario FROM Usuario WHERE IdUsuario=8";

                String correo = "";

                comando = new SqlCommand(query, conexion);

                AbrirConexionDB();

                using (SqlDataReader dr = comando.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        correo = dr["CorreoUsuario"].ToString();
                    }
                    
                }
                CerrarConexionDB();
                return correo;
            }
            catch
            {
                return null;
            }

            /*try
            {
                //query = "SELECT CorreoUsuario FROM Usuario WHERE IdUsuario=@IdUsuario";
                query = "SELECT CorreoUsuario FROM Usuario";

                comando = new SqlCommand(query, conexion);

                //comando.Parameters.Add("@IdUsuario", id);

                AbrirConexionDB();

                comando.ExecuteReader();

                CerrarConexionDB();

                return true;
            }
            catch
            {
                return false;
            }
            
        }*/

    }

}