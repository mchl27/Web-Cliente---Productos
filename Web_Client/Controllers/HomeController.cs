using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Security.Claims;
using Web_Client.Models;

namespace Web_Client.Controllers
{
    public class HomeController : Controller
    {
        //private readonly ILogger<HomeController> _logger;

        //public HomeController(ILogger<HomeController> logger)
        //{
        //    _logger = logger;
        //}

        private readonly DbWebClientContext _context;

        public HomeController(DbWebClientContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(string nombreUsuario, string contrasena)
        {
            var usuario = _context.Usuarios.FirstOrDefault(u => u.Username == nombreUsuario && u.Contraseña == contrasena);

            if (usuario != null)
            {
                // Iniciar sesión exitosa.
                return RedirectToAction("Index", "Main");
            }
            else
            {
                // Nombre de usuario o contraseña incorrectos.
                ModelState.AddModelError("", "Nombre de usuario o contraseña incorrectos.");
                return View();
            }
        }
    }
}
