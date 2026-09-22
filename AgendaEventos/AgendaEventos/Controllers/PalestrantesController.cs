using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using AgendaEventos.Models;

namespace AgendaEventos.Controllers
{
    public class PalestrantesController : Controller
    {
        private AgendaEventosEntities db = new AgendaEventosEntities();

        // GET: Palestrantes
        public ActionResult Index()
        {
            return View(db.Palestrantes.ToList());
        }

        // GET: Palestrantes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Palestrante palestrante = db.Palestrantes.Find(id);
            if (palestrante == null)
            {
                return HttpNotFound();
            }
            return View(palestrante);
        }

        // GET: Palestrantes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Palestrantes/Create
        // Para proteger-se contra ataques de excesso de postagem, ative as propriedades específicas às quais deseja se associar. 
        // Para obter mais detalhes, confira https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Nome,BioCurta")] Palestrante palestrante)
        {
            if (ModelState.IsValid)
            {
                db.Palestrantes.Add(palestrante);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(palestrante);
        }

        // GET: Palestrantes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Palestrante palestrante = db.Palestrantes.Find(id);
            if (palestrante == null)
            {
                return HttpNotFound();
            }
            return View(palestrante);
        }

        // POST: Palestrantes/Edit/5
        // Para proteger-se contra ataques de excesso de postagem, ative as propriedades específicas às quais deseja se associar. 
        // Para obter mais detalhes, confira https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Nome,BioCurta")] Palestrante palestrante)
        {
            if (ModelState.IsValid)
            {
                db.Entry(palestrante).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(palestrante);
        }

        // GET: Palestrantes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Palestrante palestrante = db.Palestrantes.Find(id);
            if (palestrante == null)
            {
                return HttpNotFound();
            }
            return View(palestrante);
        }

        // POST: Palestrantes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Palestrante palestrante = db.Palestrantes.Find(id);
            db.Palestrantes.Remove(palestrante);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
