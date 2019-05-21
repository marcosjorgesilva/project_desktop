using System.Linq;
using Microsoft.AspNetCore.Mvc;
using InterfaceVisual.Models;

namespace InterfaceVisual.Controllers
{
    public class ProdutoController : Controller
    {
        MyDbContext db = new MyDbContext();

        public ActionResult Listar()
        {
            return View(db.Produto.ToList());
        }

        public ActionResult Cadastrar()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CadastrarProduto(Produto produto)
        {
            db.Produto.Add(produto);
            db.SaveChanges();
            return RedirectToAction("Index", "Produto");
        }

        [HttpPost]
        public bool Apagar(int id)
        {
            try
            {
                db.Produto.Remove(db.Produto.Where(s => s.IdProduto == id).First());
                db.SaveChanges();
                return true;
            }
            catch (System.Exception)
            {
                return false;
            }
            
        }

        public ActionResult Atualizar(int id)
        {
            View(db.Produto.Where(s => s.IdProduto == id).First());
            return RedirectToAction("Index", "Produto");
        }

        [HttpPost]
        public ActionResult AtualizarProduto(Produto produto)
        {
            Produto p = db.Produto.Where(s => s.IdProduto == produto.IdProduto).First();
            p.Nome = produto.Nome;
            p.Tamanho = produto.Tamanho;
            p.Estoque = produto.Estoque;
            p.ValorProduto = produto.ValorProduto;
            db.SaveChanges();
            return RedirectToAction("Index", "Produto");
        }
    }
}