using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVC5_SQL.Models;

namespace MVC5_SQL.Controllers
{
    public class UsuarioController : Controller
    {
        // GET: Usuario
        public ActionResult Index()
        {
            /*
                Pasar como parámetro del View una instancia de la Clase a utilizar.

                Si no se pasa la Clase como parámetro, se muestra el siguiente error:
                System.NullReferenceException: 'Referencia a objeto no establecida como instancia de un objeto.'
                System.Web.Mvc.WebViewPage<TModel>.Model.get devolvió null.
            */
            return View(new Usuario());
        }

        /*
            Pasar como parámetro del ActionResult una instancia de la Clase a utilizar.
            Si no se pasa la Clase como parámetro, la instancia se toma como Nula.
        */
        [HttpPost]
        public ActionResult AgregarUsuario(Usuario usuario)
        {

            if (usuario.InsertarUsuario())
            {
                return RedirectToAction("Index");
            }
            else
            {
                return new HttpStatusCodeResult(500, "Error al insertar usuario.");
            }

        }

    }

}