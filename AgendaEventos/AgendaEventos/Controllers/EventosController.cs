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
    public class EventosController : Controller
    {
        private AgendaEventosEntities db = new AgendaEventosEntities();

        // GET: Eventos
        public ActionResult Index()
        {
            var eventos = db.Eventos.Include(e => e.Categoria).Include(e => e.Palestrante);
            return View(eventos.ToList());
        }

        // GET: Eventos/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Evento evento = db.Eventos.Find(id);
            if (evento == null)
            {
                return HttpNotFound();
            }
            return View(evento);
        }

        // GET: Eventos/Create
        public ActionResult Create()
        {
            ViewBag.IDCategoria = new SelectList(db.Categorias, "ID", "Nome");
            ViewBag.IDPalestrante = new SelectList(db.Palestrantes, "ID", "Nome");
            return View();
        }

        // POST: Eventos/Create
        // Para proteger-se contra ataques de excesso de postagem, ative as propriedades específicas às quais deseja se associar. 
        // Para obter mais detalhes, confira https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,IDCategoria,IDPalestrante,Titulo,DataHora,Local,Descricao,Destaque")] Evento evento)
        {
            if (string.IsNullOrWhiteSpace(evento.Titulo))
            {
                ModelState.AddModelError("Titulo", "O título é obrigatório.");
            }
            if (string.IsNullOrWhiteSpace(evento.Local))
            {
                ModelState.AddModelError("Local", "O local é obrigatório.");
            }
            if (evento.DataHora < DateTime.Now)
            {
                ModelState.AddModelError("DataHora", "Não é permitido cadastrar evento com data no passado.");
            } 
            if (ModelState.IsValid)
            {
                db.Eventos.Add(evento);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IDCategoria = new SelectList(db.Categorias, "ID", "Nome", evento.IDCategoria);
            ViewBag.IDPalestrante = new SelectList(db.Palestrantes, "ID", "Nome", evento.IDPalestrante);
            return View(evento);
        }

        // GET: Eventos/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Evento evento = db.Eventos.Find(id);
            if (evento == null)
            {
                return HttpNotFound();
            }
            ViewBag.IDCategoria = new SelectList(db.Categorias, "ID", "Nome", evento.IDCategoria);
            ViewBag.IDPalestrante = new SelectList(db.Palestrantes, "ID", "Nome", evento.IDPalestrante);
            return View(evento);
        }

        // POST: Eventos/Edit/5
        // Para proteger-se contra ataques de excesso de postagem, ative as propriedades específicas às quais deseja se associar. 
        // Para obter mais detalhes, confira https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,IDCategoria,IDPalestrante,Titulo,DataHora,Local,Descricao,Destaque")] Evento evento)
        {
            if (ModelState.IsValid)
            {
                db.Entry(evento).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IDCategoria = new SelectList(db.Categorias, "ID", "Nome", evento.IDCategoria);
            ViewBag.IDPalestrante = new SelectList(db.Palestrantes, "ID", "Nome", evento.IDPalestrante);
            return View(evento);
        }

        // GET: Eventos/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Evento evento = db.Eventos.Find(id);
            if (evento == null)
            {
                return HttpNotFound();
            }
            return View(evento);
        }

        // POST: Eventos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Evento evento = db.Eventos.Find(id);
            db.Eventos.Remove(evento);
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
