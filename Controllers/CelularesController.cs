using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;
using LaboratorioJG.Models;
using LaboratorioJG.Models.TableViewModels;
using LaboratorioJG.Models.ViewModels;

namespace Laboratorio.Controllers
{
    public class CelularesController : Controller
    {
        // GET: Celulares
        public ActionResult Index()
        {
            List<CelularesTableViewModels> lst = null;
            using (var db = new db_celularesEntities())
            {
                lst = (from p in db.tbl_celulares
                       join
                       g in db.tbl_operadora on
                       p.idOperadora equals g.id
                       select new CelularesTableViewModels
                       {
                           Id = p.id,
                           Modelo = p.modelo,
                           Marca = p.marca,
                           Precio = (decimal)p.precio,
                           Operadora = g.nombre
                       }).ToList();
            }
            return View(lst);
        }
        public void cargarCboxOperadoras()
        {
            List<SelectListItem> ListOpeadoras = null;
            using (var db = new db_celularesEntities())
            {
                ListOpeadoras = (from g in db.tbl_operadora
                                 select new SelectListItem
                                 {
                                     Value = g.id.ToString(),
                                     Text = g.nombre.ToString(),
                                 }).ToList();
            }
            ViewBag.ListOpeadoras = ListOpeadoras;
        }

        [HttpGet]
        public ActionResult Nuevo()
        {
            cargarCboxOperadoras();
            return View();
        }

        [HttpPost]
        public ActionResult Nuevo(CelularesViewModel model)
        {
            if (!ModelState.IsValid)
            {
                cargarCboxOperadoras();
                return View(model);
            }
            using (db_celularesEntities db = new db_celularesEntities())
            {
                tbl_celulares oCelular = new tbl_celulares();

                oCelular.modelo = model.Modelo;
                oCelular.marca = model.Marca;
                oCelular.precio = model.Precio;
                oCelular.idOperadora = model.IdOperadora;

                db.tbl_celulares.Add(oCelular);
                db.SaveChanges();
            }
            return Redirect(Url.Content("~/Celulares/"));
        }

        public ActionResult Editar(int id)
        {
            cargarCboxOperadoras();
            EditarCelularesViewModels model = new EditarCelularesViewModels();

            using (db_celularesEntities db = new db_celularesEntities())
            {
                var oCelular = db.tbl_celulares.Find(id);

                model.Id = oCelular.id;
                model.Marca = oCelular.marca;
                model.Modelo = oCelular.modelo;
                model.Precio = (decimal)oCelular.precio;
                model.IdOperadora = (int)oCelular.idOperadora;
            }
            return View(model);
        }

        [HttpPost]
        public ActionResult Editar(EditarCelularesViewModels model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            using (db_celularesEntities db = new db_celularesEntities())
            {
                var oCelular = db.tbl_celulares.Find(model.Id);
                oCelular.modelo = model.Modelo;
                oCelular.marca = model.Marca;
                oCelular.precio = model.Precio;
                oCelular.idOperadora = model.IdOperadora;
                db.Entry(oCelular).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
            }
            return Redirect(Url.Content("~/Celulares/"));
        }
        public ActionResult Eliminar(int id)
        {
            using (db_celularesEntities db = new db_celularesEntities())
            {
                var oCelular = db.tbl_celulares.Find(id);

                db.tbl_celulares.Remove(oCelular);
                db.SaveChanges();
            }
            return Redirect(Url.Content("~/Celulares/"));
        }
    }
}