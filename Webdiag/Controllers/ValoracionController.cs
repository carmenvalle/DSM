using DiagGen.ApplicationCore.CEN.Diag;
using DiagGen.ApplicationCore.EN.Diag;
using DiagGen.ApplicationCore.IRepository.Diag;
using DiagGen.Infraestructure.Repository.Diag;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Webdiag.Assemblers;
using Webdiag.Models;

namespace Webdiag.Controllers
{
    public class ValoracionController : BasicController
    {
        // GET: ValoracionController
        public ActionResult Index(int? idProducto = null)
        {
            SessionInitialize();
            ValoracionRepository valRepo = new ValoracionRepository(session); // tu repositorio
            ValoracionCEN valCEN = new ValoracionCEN(valRepo);

            IList<ValoracionEN> listEN;
            if (idProducto.HasValue)
            {
                listEN = valRepo.BuscarPorProducto(idProducto.Value);
            }
            else
            {
                listEN = valRepo.ReadAllDefault(0, -1);
            }

            IEnumerable<ValoracionViewModel> listVM = new ValoracionAssembler().ConvertirListaENToViewModel(listEN);
            SessionClose();
            return View(listVM);
        }

        // GET: ValoracionController/Details/5
        public ActionResult Details(int id)
        {
            SessionInitialize();
            ValoracionRepository valRepo = new ValoracionRepository(session);
            ValoracionCEN valCEN = new ValoracionCEN(valRepo);

            ValoracionEN valEN = valRepo.ReadOIDDefault(id);
            ValoracionViewModel valVM = new ValoracionAssembler().ConvertirENToViewModel(valEN);
            SessionClose();
            return View(valVM);
        }

        // GET: ValoracionController/Create
        // GET: Valoracion/Create
        public ActionResult Create()
        {
            // Inicializar sesión si es necesario
            SessionInitialize();

            // Repositorios y CEN
            ProductoRepository prRepo = new ProductoRepository(session);
            ProductoCEN prCEN = new ProductoCEN(prRepo);
            UsuarioRepository uRepo = new UsuarioRepository(session);
            UsuarioCEN uCEN = new UsuarioCEN(uRepo);

            // Obtener lista de productos y usuarios
            var productos = prCEN.readAll();

            // Asignar a ViewBag
            ViewBag.Productos = productos;

            SessionClose();

            return View();
        }


        // POST: Valoracion/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ValoracionViewModel valoracion)
        {
            if (!ModelState.IsValid)
                return View(valoracion);

            try
            {
                SessionInitialize();
                ValoracionRepository valRepo = new ValoracionRepository(session);
                ValoracionCEN valCEN = new ValoracionCEN(valRepo);

                // Crear ValoracionEN a partir del ViewModel
                ValoracionEN valEN = new ValoracionEN
                {
                    Puntuacion = valoracion.Puntuacion,
                    Comentario = valoracion.Comentario,
                    Producto = new ProductoEN { IdProducto = valoracion.ProductoId },
                    Usuario = new UsuarioEN { IdUsuario = valoracion.UsuarioId }
                };

                valCEN.Guardar(valEN.Puntuacion, valEN.Comentario, valEN.Producto.IdProducto, valEN.Usuario.IdUsuario);

                SessionClose();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                SessionClose();
                return View(valoracion);
            }
        }


        // GET: ValoracionController/Edit/5
        public ActionResult Edit(int id)
        {
            SessionInitialize();
            ValoracionRepository valRepo = new ValoracionRepository(session);
            ValoracionCEN valCEN = new ValoracionCEN(valRepo);

            ValoracionEN valEN = valRepo.ReadOIDDefault(id);
            ValoracionViewModel valVM = new ValoracionAssembler().ConvertirENToViewModel(valEN);
            SessionClose();
            return View(valVM);
        }

        // POST: ValoracionController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, ValoracionViewModel val)
        {
            try
            {
                SessionInitialize();
                ValoracionRepository valRepo = new ValoracionRepository(session);
                ValoracionCEN valCEN = new ValoracionCEN(valRepo);

                valCEN.Editar(val.IdValoracion, val.Puntuacion, val.Comentario, val.ProductoId, val.UsuarioId);

                SessionClose();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ValoracionController/Delete/5
        public ActionResult Delete(int id)
        {
            SessionInitialize();
            ValoracionRepository valRepo = new ValoracionRepository(session);
            ValoracionCEN valCEN = new ValoracionCEN(valRepo);

            valCEN.Borrar(id);

            SessionClose();
            return RedirectToAction(nameof(Index));
        }

        // POST: ValoracionController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                SessionInitialize();
                ValoracionRepository valRepo = new ValoracionRepository(session);
                ValoracionCEN valCEN = new ValoracionCEN(valRepo);

                valCEN.Borrar(id);

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


