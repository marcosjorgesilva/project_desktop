using System.Linq;
using Microsoft.AspNetCore.Mvc;
using InterfaceVisual.Models;

namespace InterfaceVisual.Controllers
{
    public class CategoryController : Controller
    {
        MyDbContext db = new MyDbContext();
        public ActionResult Index()
        {
            return View(db.Categoria.ToList());
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult CreateCategoria(Categoria categoria)
        {
            db.Categoria.Add(categoria);
            db.SaveChanges();
            return RedirectToAction("Index", "Categoria");
        }
        [HttpPost]
        public bool Delete(int idCategoria)
        {
            try
            {
                Categoria doctor = db.Categoria.Where(s => s.IdCategoria == idCategoria).First();
                db.Categoria.Remove(doctor);
                db.SaveChanges();
                return true;
            }
            catch (System.Exception)
            {
                return false;
            }

        }
        public ActionResult Update(int idCategoria)
        {
            return View(db.Categoria.Where(s => s.IdCategoria == idCategoria).First());
        }
        [HttpPost]
        public ActionResult UpdateDoctor(Categoria categoria)
        {
            Categoria d = db.Categoria.Where(s => s.IdCategoria == categoria.IdCategoria).First();
            d.TipoCategoria = categoria.TipoCategoria;
            db.SaveChanges();
            return RedirectToAction("Index", "Categoria");
        }
    }
}