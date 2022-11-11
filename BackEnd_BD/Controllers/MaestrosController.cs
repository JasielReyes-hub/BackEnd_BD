using BackEnd_BD.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;



namespace Back_End_BD.Controllers
{
    public class MaestrosController : Controller
    {
        // GET: Alumnos
        public ActionResult Index()
        {
            using (AlumnoDBContext dbMaestro = new AlumnoDBContext())
            {
                return View(dbMaestro.Maestros.ToList());
            }

        }

        public ActionResult Details(int? id)
        {
            using (AlumnoDBContext dbMaestro = new AlumnoDBContext())
            {
                Maestros maestros = dbMaestro.Maestros.Find(id);

                if (maestros == null)
                {
                    return HttpNotFound();
                }
                return View(maestros);
            }
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Maestros mae)
        {
            using (AlumnoDBContext dbMaestro = new AlumnoDBContext())
            {
                dbMaestro.Maestros.Add(mae);
                dbMaestro.SaveChanges();
            }
            return RedirectToAction("Index");
        }

        public ActionResult Edit(int? matricula)
        {
            using (AlumnoDBContext dbMaestro = new AlumnoDBContext())
            {
                return View(dbMaestro.Maestros.Where(x => x.Matricula == matricula).FirstOrDefault());
            }
        }

        [HttpPost]
        public ActionResult Edit(Maestros mae)
        {
            using (AlumnoDBContext dbMaestro = new AlumnoDBContext())
            {
                dbMaestro.Entry(mae).State = System.Data.Entity.EntityState.Modified;
                dbMaestro.SaveChanges();
            }

            return RedirectToAction("Index");
        }

        public ActionResult Delete(int? matricula)
        {
            using (AlumnoDBContext dbMaestro = new AlumnoDBContext())
            {
                return View(dbMaestro.Maestros.Where(x => x.Matricula == matricula).FirstOrDefault());
            }

        }

        [HttpPost]
        public ActionResult Delete(Maestros mae, int? matricula)
        {
            using (AlumnoDBContext dbMaestro = new AlumnoDBContext())
            {
                Maestros ale = dbMaestro.Maestros.Where(x => x.Matricula == matricula).FirstOrDefault();
                dbMaestro.Maestros.Remove(ale);
                dbMaestro.SaveChanges();
            }

            return RedirectToAction("Index");
        }
    }
}