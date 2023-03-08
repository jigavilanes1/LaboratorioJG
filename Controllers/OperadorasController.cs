using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LaboratorioJG.Models.TableViewModels;
using LaboratorioJG.Models.ViewModels;
using LaboratorioJG.Models;

namespace LaboratorioJG.Controllers
{
    public class OperadorasController : Controller
    {
        // GET: Marca
        public ActionResult Index()
        {
            List<OperadorasTableViewModels> lst = null;

            using (db_celularesEntities db = new db_celularesEntities())
            {
                lst = (from d in db.tbl_operadora
                       select new OperadorasTableViewModels
                       {
                           Id = d.id,
                           Nombre = d.nombre,
                           Anio = (int)d.anio
                       }).ToList();
            }
            return View(lst);
        }

        [HttpGet]
        public ActionResult Nuevo()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Nuevo(OperadorasViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            using (db_celularesEntities db = new db_celularesEntities())
            {
                tbl_operadora oOperadora = new tbl_operadora();

                oOperadora.nombre = model.Nombre;
                oOperadora.anio = model.Anio;

                db.tbl_operadora.Add(oOperadora);
                db.SaveChanges();
            }
            return Redirect(Url.Content("~/Operadoras/"));
        }

        public ActionResult Editar(int id)
        {
            EditarOperadorasViewModel model = new EditarOperadorasViewModel();

            using (db_celularesEntities db = new db_celularesEntities())
            {
                var oOperadora = db.tbl_operadora.Find(id);

                model.Id = oOperadora.id;
                model.Nombre = oOperadora.nombre;
                model.Anio = (int)oOperadora.anio;
            }
            return View(model);
        }

        [HttpPost]
        public ActionResult Editar(EditarOperadorasViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            using (db_celularesEntities db = new db_celularesEntities())
            {
                var oOperadora = db.tbl_operadora.Find(model.Id);
                oOperadora.nombre = model.Nombre;
                oOperadora.anio = model.Anio;
                db.Entry(oOperadora).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
            }
            return Redirect(Url.Content("~/Operadoras/"));
        }


        public ActionResult Eliminar(int id)
        {
            using (db_celularesEntities db = new db_celularesEntities())
            {
                var oOperadora = db.tbl_operadora.Find(id);

                db.tbl_operadora.Remove(oOperadora);
                db.SaveChanges();
            }
            return Redirect(Url.Content("~/Operadoras/"));
        }
    }
}