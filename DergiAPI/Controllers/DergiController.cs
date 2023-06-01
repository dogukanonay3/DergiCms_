using DergiOrtak.Services;
using DergiOrtak.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace DergiAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class DergiController : ControllerBase
    {
        private IDergiService _dergiService;
        private ISayiService _sayiService;
        private IMakaleService _makaleService;

        public DergiController(IDergiService dergiService, ISayiService sayiService, IMakaleService makaleService)
        {
            _dergiService = dergiService;
            _sayiService = sayiService;
            _makaleService = makaleService;
        }

        [HttpGet]
        public List<DergiViewModel> Listele()
        {
            return _dergiService.Listele();
        }

        [HttpGet]
        public List<SayiViewModel> Sayilar(int dergiId)
        {
            return _sayiService.Listele(dergiId);
        }

        [HttpGet]
        public List<MakaleViewModel> Makaleler(int sayiId)
        {
            return _makaleService.Listele(sayiId);
        }

        [HttpGet]
        public MakaleViewModel Makale(int id)
        {
            return _makaleService.Getir(id);
        }
    }
}
