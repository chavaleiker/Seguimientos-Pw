
using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Actividad.Models;

namespace Actividad.Controllers;

public class HomeController : Controller
{
    private readonly RegistroJugadores registro;

    public HomeController(RegistroJugadores registro)
    {
        this.registro = registro;
    }

    public IActionResult Index()
    {
        ViewBag.Jugadores = registro.ObtenerTodos();
        return View(new Jugador());
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel
        {
            RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier
        });
    }
}
