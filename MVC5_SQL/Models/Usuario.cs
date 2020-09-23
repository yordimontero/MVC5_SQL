using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC5_SQL.Models
{
    public class Usuario
    {
        public String NombreUsuario { get; set; }
        public String CorreoUsuario { get; set; }

        DB db;

        public Boolean InsertarUsuario()
        {

            try
            {
                db = new DB();

                db.InsertarUsuario(NombreUsuario, CorreoUsuario);

                return true;
            }
            catch
            {
                return false;
            }

        }

    }

}