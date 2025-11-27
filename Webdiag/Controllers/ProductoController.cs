using DiagGen.ApplicationCore.CEN.Diag;
using DiagGen.ApplicationCore.EN.Diag;
using DiagGen.Infraestructure.Repository.Diag;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Webdiag.Assemblers;
using Webdiag.Models;

namespace Webdiag.Controllers
{
    public class ProductoController : BasicController
    {
        // GET: ProductoController
        public ActionResult Index()
        {
            SessionInitialize();
            ProductoRepository prRepository = new ProductoRepository(session);
            ProductoCEN prCen = new ProductoCEN(prRepository);

            IList<ProductoEN> listEN = prCen.readAll();
            IEnumerable<ProductoViewModel> listPrs = new ProductoAssembler().ConvertirListaENToViewModel(listEN).ToList();
            SessionClose();
            return View(listPrs);
        }

        // GET: ProductoController/Details/5
        public ActionResult Details(int id)
        {
            SessionInitialize();
            ProductoRepository prRepo = new ProductoRepository();
            ProductoCEN prCEN = new ProductoCEN(prRepo);

            ProductoEN prEN = prCEN.readId(id);
            ProductoViewModel prView = new ProductoAssembler().ConvertirENToViewModel(prEN);
            SessionClose();
            return View(prView);
        }

        // GET: ProductoController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ProductoController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ProductoViewModel pr)
        {
            try
            {
                ProductoRepository prRepo = new ProductoRepository();
                ProductoCEN prCEN = new ProductoCEN(prRepo);
                prCEN.Publicar(pr.Nombre, pr.Descripcion, pr.Precio, pr.Imagenes, pr.Stock, pr.Valoracion, pr.Categoria);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ProductoController/Edit/5
        public ActionResult Edit(int id)
        {
            SessionInitialize();
            ProductoRepository prRepo = new ProductoRepository();
            ProductoCEN prCEN = new ProductoCEN(prRepo);

            ProductoEN prEN = prCEN.readId(id);
            ProductoViewModel prView = new ProductoAssembler().ConvertirENToViewModel(prEN);
            SessionClose();
            return View(prView);
        }

        // POST: ProductoController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, ProductoViewModel pr)
        {
            try
            {
                ProductoRepository prRepo = new ProductoRepository();
                ProductoCEN prCEN = new ProductoCEN(prRepo);
                prCEN.EditarProducto(id, pr.Nombre, pr.Descripcion, pr.Precio, pr.Imagenes, pr.Stock, pr.Valoracion, pr.Categoria);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ProductoController/Delete/5
        public ActionResult Delete(int id)
        {
            ProductoRepository prRepo = new ProductoRepository();
            ProductoCEN prCEN = new ProductoCEN(prRepo);
            prCEN.Eliminar(id);
            return RedirectToAction(nameof(Index));
        }

        // POST: ProductoController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                SessionInitialize();
                ProductoRepository prRepo = new ProductoRepository(session);
                ProductoCEN prCEN = new ProductoCEN(prRepo);
                prCEN.Eliminar(id);
                SessionClose();

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
