using EstudoWeb.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace EstudoWeb.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            //HomeModel home = new HomeModel();
            //home.Name = "Acrovisão";
            //home.Email = "acrovisao@gmail.com";
            //home.date = DateTime.Now;
            return View();
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