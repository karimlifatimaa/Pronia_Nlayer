using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using WebApp_Pronia.Models;

namespace WebApp_Pronia.Controllers
{
    public class HomeController : Controller
    {
        

        public IActionResult Index()
        {

            return View();
        }

      
    }
}
