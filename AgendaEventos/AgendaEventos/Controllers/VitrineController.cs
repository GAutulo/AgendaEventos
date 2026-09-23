using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;
using AgendaEventos.Models;

namespace AgendaEventos.Controllers
{
    public class VitrineController : Controller
    {
        private AgendaEventosEntities db = new AgendaEventosEntities();

        // GET: Vitrine
        public ActionResult Index(int? categoria, int? destaque, string titulo)
        {
            var eventos = db.Eventos.Include(e => e.Categoria);

            if (categoria != null)
            {
                eventos = eventos.Where(e => e.IDCategoria == categoria);
            }
            if (destaque == 1)
            {
                eventos = eventos.Where(e => e.Destaque);
            }
            if (!string.IsNullOrWhiteSpace(titulo))
            {
                eventos = eventos.Where(e => e.Titulo.Contains(titulo));
            }
            ViewBag.Titulo = titulo;
            ViewBag.Destaque = destaque == 1;
            ViewBag.Categoria = new SelectList(db.Categorias, "ID", "Nome", categoria);
            return View(eventos
                .OrderByDescending(e => e.Destaque)
                .ThenBy(e => e.DataHora)
                .ToList());
        }
        public ActionResult Detalhes(int id)
        {
            var evento = db.Eventos
                .Include(e => e.Categoria)
                .Include(e => e.Palestrante)
                .FirstOrDefault(e => e.ID == id);

            if (evento == null)
            {
                return HttpNotFound();
            }

            return View(evento);
        }
    }
}