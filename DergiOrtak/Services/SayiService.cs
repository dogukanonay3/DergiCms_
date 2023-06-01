using DergiOrtak.DataAccsess;
using DergiOrtak.Entity;
using DergiOrtak.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DergiOrtak.Services
{
    public interface ISayiService
    {
        public void Ekle(SayiViewModel vm);
        List<SayiViewModel> Listele(int dergiId);
        public void SayiGuncelle(SayiViewModel vm);
        public SayiViewModel Getir(int id);
    }
    public class SayiService : ISayiService
    {
        private IDataHandler _dataHandler;
        public SayiService(IDataHandler dataHandler)
        {
            _dataHandler = dataHandler;
        }
        public List<SayiViewModel> Listele(int dergiId)
        {
            var liste = _dataHandler.Sayi.Listele(dergiId);
            List<SayiViewModel> vm = new List<SayiViewModel>();

            foreach (var item in liste)
            {
                vm.Add(new SayiViewModel
                {
                    No = item.No,
                    Id = item.Id,
                    YayinTarihi = item.YayinTarihi,
                    DergiId = item.DergiId,
                    DergiAdi = item.Dergi.Adi
                });
            }
            return vm;
        }
        public void Ekle(SayiViewModel vm)
        {
            Sayi model = new Sayi
            {
                DergiId = vm.DergiId.Value,
                No = vm.No,
                YayinTarihi = vm.YayinTarihi
            };
            _dataHandler.Insert(model);
        }
        public SayiViewModel Getir(int id)
        {
            var model = _dataHandler.Sayi.Getir(id);
            var vm = new SayiViewModel
            {
                DergiAdi = model.Dergi.Adi,
                DergiId = model.DergiId,
                No = model.No
            };
            return vm;
        }
        public void SayiGuncelle(SayiViewModel vm)
        {
            Sayi model = new Sayi
            {
                Id = vm.Id,
                DergiId = vm.DergiId.Value,
                No = vm.No,
                YayinTarihi = vm.YayinTarihi
            };
            _dataHandler.Update(model);
        }
    }
}
