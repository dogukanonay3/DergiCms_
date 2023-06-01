using DergiOrtak.DataAccsess;
using DergiOrtak.Services;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace DergiCms.Controllers
{
    public class HomeController : Controller
    {
        private IDergiService _dergiservice;
        private IMakaleService _makaleService;
        private ISayiService _sayiService;
        public HomeController(IDergiService dergiservice, IMakaleService makaleService, ISayiService sayiService)
        {
            _dergiservice = dergiservice;
            _makaleService = makaleService;
            _sayiService = sayiService;
        }

        public IActionResult Index()
        {
            var result = _dergiservice.Listele();
            return View(result);
        }
        public IActionResult Sayi(int id)
        {
            var result = _sayiService.Listele(id);
            return View(result);
        }

        public IActionResult Makaleler(int id)
        {
            var liste = _makaleService.Listele(id);
            return View(liste);
        }
        public IActionResult Makale(int id)
        {
            var result = _makaleService.Getir(id);
            return View(result);
        }
    }
}