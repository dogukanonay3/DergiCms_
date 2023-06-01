using DergiOrtak.Services;
using DergiOrtak.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DergiCms.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize]
    public class SayiController : Controller
    {
        private ISayiService _sayiService;
        private IDergiService _dergiService;
        public SayiController(ISayiService sayiService, IDergiService dergiService)
        {
            _dergiService = dergiService;
            _sayiService = sayiService;
        }
        public IActionResult Index(int id)
        {
            var result = _sayiService.Listele(id);
            return View(result);
        }
        [HttpGet]
        public IActionResult Ekle()
        {
            ViewBag.Dergiler = _dergiService.Listele();
            return View();
        }
        [HttpPost]
        public IActionResult Ekle(SayiViewModel model)
        {
            _sayiService.Ekle(model);
            return Redirect("/Admin/Home/Index");
        }
        [HttpGet]
        public IActionResult Guncelle(int id)
        {
            var result = _sayiService.Getir(id);
            ViewBag.Dergiler = _sayiService.Listele(id);
            return View(result);
        }
        [HttpPost]
        public IActionResult Guncelle(SayiViewModel model)
        {
            _sayiService.SayiGuncelle(model);
            return Redirect("/Admin/Home/Index");
        }
    }
}
