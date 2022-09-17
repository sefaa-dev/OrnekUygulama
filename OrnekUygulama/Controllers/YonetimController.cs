using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrnekUygulama.Controllers
{
    public class YonetimController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Tarifler()
        {
            return View();
        }
        public IActionResult Yorumlar()
        {
            return View();
        }
        public IActionResult Kullanicilar()
        {
            return View();
        }
        public IActionResult Bilgilerim()
        {
            return View();
        }
        public IActionResult CikisYap()
        {
            return View();
        }
    }
}
