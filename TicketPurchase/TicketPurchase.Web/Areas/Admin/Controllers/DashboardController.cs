using FirstDemo.Web.Models;
using Microsoft.AspNetCore.Mvc;
using TicketPurchase.Web.Areas.Admin.Models;

namespace TicketPurchase.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class DashboardController : Controller
    {
        public IActionResult Index()
        {
            var model = new IndexModel();
            return View();
        }

        [HttpPost] [ValidateAntiForgeryToken]
        public IActionResult Index(IndexModel model)
        {
            
            return View(model);
        }
    }
}
