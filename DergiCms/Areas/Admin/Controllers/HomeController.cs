using DergiOrtak.DataAccsess;
using DergiOrtak.Entity;
using DergiOrtak.Services;
using DergiOrtak.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Principal;

namespace DergiCms.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize]
    public class HomeController : Controller
    {
        private IDergiService _dergiService;
        private IDataHandler _dataHandler;
        SignInManager<IdentityUser> _signInManager;
        public HomeController(IDergiService dergiService, IDataHandler dataHandler, SignInManager<IdentityUser> signInManager)
        {
            _dergiService = dergiService;
            _dataHandler = dataHandler;
            _signInManager = signInManager;
        }

        public IActionResult Index()
        {
            var liste = _dergiService.Listele();
            return View(liste);
        }

        [HttpGet]
        public IActionResult Ekle()
        {
            ViewBag.Kategoriler = _dergiService.KategoriListele();
            return View();
        }
        [HttpPost]
        public IActionResult Ekle(DergiViewModel model)
        {
            if(ModelState.IsValid)
            {
                _dergiService.DergiEkle(model);
                return RedirectToAction("Index");
            }
            return View();

        }
        public IActionResult DergiSil(int id)
        {
            _dergiService.DergiSil(id);
            //_dergiService.DergiSil(model);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult Guncelle(int id)
        {
            var result = _dergiService.Getir(id);
            ViewBag.Kategoriler = _dergiService.KategoriListele();
            return View(result);
        }
        [HttpPost]
        public IActionResult Guncelle(DergiViewModel model)
        {
            _dergiService.DergiGuncelle(model);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return Redirect("/Home/Index");
        }
    }
}
