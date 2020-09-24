using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

namespace MVC5_SQL.Models
{
    public class Usuario
    {
        public int IdUsuario { get; set; }
        public String NombreUsuario { get; set; }
        public String CorreoUsuario { get; set; }

        DB db;

        public DataTable GetListaUsuarios()
        {
            //Método para obtener la lista de los Usuarios registrados en el sistema.

            db = new DB();

            return db.GetListaUsuariosDB();
        }


        public Boolean CreateUsuario()
        {
            //Método para crear un nuevo Usuario en la base de datos.
            try
            {
                db = new DB();

                db.CreateUsuarioDB(NombreUsuario, CorreoUsuario);

                return true;
            }
            catch
            {
                return false;
            }
            
        }

        public Boolean UpdateUsuario()
        {
            //Método para actualizar un Usuario registrado en la base de datos.
            try
            {
                db = new DB();

                db.UpdateUsuarioDB(IdUsuario, NombreUsuario, CorreoUsuario);

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
                db = new DB();

                String nombreUsuario = db.GetNombreUsuario();

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
                db = new DB();

                String correo = db.GetCorreoUsuario();

                return correo;
            }
            catch
            {
                return null;
            }

        }*/

    }

}