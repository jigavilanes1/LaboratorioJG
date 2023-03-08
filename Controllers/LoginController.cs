using LaboratorioJG.Models;
using LaboratorioJG.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LaboratorioJG.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(LoginViewModel model)
        {
            if(!ModelState.IsValid)
            {
                return View(model);
            }
            using(var db = new db_celularesEntities())
            {
                var list = from u in db.tbl_usuarios
                           where u.usuario == model.Usuario &&
                           u.clave == model.Clave &&
                           u.estado == 1
                           select u;
                if(list.Count() >0)
                {
                    Session["Usuario"] = list.First();
                }
            }
            return Redirect(Url.Content("~/Home/"));
        }
    }
}