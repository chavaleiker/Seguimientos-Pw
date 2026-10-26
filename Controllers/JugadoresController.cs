using Microsoft.AspNetCore.Mvc;
using Actividad.Models;

namespace TorneoTenisMesa.Controllers
{
    public class JugadoresController : Controller
    {
        private readonly RegistroJugadores registro;

        public JugadoresController(RegistroJugadores registro)
        {
            this.registro = registro;
        }

        [HttpGet]
        public IActionResult Reglamentacion()
        {
            return View("~/Views/Home/Reglamentacion.cshtml");
        }


        [HttpGet]
        public IActionResult Index()
        {
            ViewBag.Jugadores = registro.ObtenerTodos();
            return View(new Jugador());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Index(Jugador jugador)
        {
            if (ModelState.IsValid &&
                registro.ExisteCorreo(jugador.Correo))
            {
                ModelState.AddModelError(
                    nameof(jugador.Correo),
                    "Este correo ya está inscrito.");
            }

            if (!ModelState.IsValid)
            {
                ViewBag.Jugadores = registro.ObtenerTodos();
                return View("~/Views/Home/Index.cshtml", jugador);
            }

            registro.Agregar(jugador);

            TempData["Mensaje"] =
                $"Inscripción exitosa para {jugador.Nombre}.";

            return RedirectToAction("Index", "Home");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Eliminar(int id)
        {
            if (registro.Eliminar(id))
            {
                TempData["Mensaje"] =
                    "La inscripción se eliminó correctamente.";
            }

            return RedirectToAction("Index", "Home");
        }
    }
}