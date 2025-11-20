using DiagGen.ApplicationCore.CEN.Diag;
using DiagGen.ApplicationCore.EN.Diag;
using DiagGen.Infraestructure.Repository.Diag;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Webdiag.Models;

namespace Webdiag.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            ProductoRepository productoRpeo = new ProductoRepository();
            ProductoCEN productoCEN = new ProductoCEN(productoRpeo);
            IList<ProductoEN> list = productoCEN.get_IProductoRepository().ReadAllDefault(0, -1);
            return View(list);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}