using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using OrnekUygulama.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace OrnekUygulama.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index(int id)
        {
            yemektarifleriDBContext db = new yemektarifleriDBContext();
            var sayfa = db.Sayfalars.Where(a => a.Silindi == false && a.Aktif == true && a.SayfaId == id).FirstOrDefault();
            return View(sayfa);
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
