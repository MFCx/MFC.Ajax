using MFC.Ajax.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace MFC.Ajax.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private List<Kullanici> kullanicilar;
        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
            kullanicilar = new List<Kullanici>()
            {
                new Kullanici(){Id=1,Ad = "Luffy"},
                new Kullanici(){Id=2,Ad = "Zoro"},
                new Kullanici(){Id=3,Ad = "Nami"},
                new Kullanici(){Id=4,Ad = "Sanji"},
                new Kullanici(){Id=5,Ad = "Usop"},
                new Kullanici(){Id=6,Ad = "Chopper"},
            };
        }

        public IActionResult Index()
        {
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
        public IActionResult Listele()
        {
            var jsonKullanicilar = JsonConvert.SerializeObject(kullanicilar);
            return Json(jsonKullanicilar);
        } 
        public IActionResult GetirIdile(int kullaniciId)
        {
            var bulunanKullanici = kullanicilar.FirstOrDefault(I => I.Id == kullaniciId);
            var jsonKullanici = JsonConvert.SerializeObject(bulunanKullanici);
            return Json(jsonKullanici);
        }
    }
   

    public class Kullanici
    {
        public int Id { get; set; }
        public string Ad { get; set; }
    }

    
}
