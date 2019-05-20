using System.Linq;
using Microsoft.AspNetCore.Mvc;
using InterfaceVisual.Models;

namespace InterfaceVisual.Controllers
{
    public class CategoriaController : Controller
    {
        MyDbContext db = new MyDbContext();
        public ActionResult Listar()
        {
            return View(db.Categoria.ToList());
        }
        public ActionResult Cadastrar()
        {
            return View();
        }
        [HttpPost]
        public ActionResult CadastrarCategoria(Categoria categoria)
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
                Categoria categoria = db.Categoria.Where(s => s.IdCategoria == idCategoria).First();
                db.Categoria.Remove(categoria);
                db.SaveChanges();
                return true;
            }
            catch (System.Exception)
            {
                return false;
            }

        }
        public ActionResult Atualizar(int idCategoria)
        {
            return View(db.Categoria.Where(s => s.IdCategoria == idCategoria).First());
        }
        [HttpPost]
        public ActionResult AtualizarCategoria(Categoria categoria)
        {
            Categoria d = db.Categoria.Where(s => s.IdCategoria == categoria.IdCategoria).First();
            d.TipoCategoria = categoria.TipoCategoria;
            db.SaveChanges();
            return RedirectToAction("Index", "Categoria");
        }
    }
}