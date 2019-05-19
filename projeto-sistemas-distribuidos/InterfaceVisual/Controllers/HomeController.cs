using System.Linq;
using InterfaceVisual.Models;
using Microsoft.AspNetCore.Mvc;

namespace InterfaceVisual
{
    public class HomeController : Controller
    {
        private MyDbContext db = new MyDbContext();
        public IActionResult Index()
        {
            DashboardViewModel dashboard = new DashboardViewModel();
            
            dashboard.produto_count = db.Produto.Count();
            //dashboard.nurses_count = db.Admins.Count();
            //dashboard.patients_count = db.Categoria.Count();
            return View(dashboard);
        }
    }
}