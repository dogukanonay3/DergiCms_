using DergiOrtak.DataAccsess;
using DergiOrtak.Entity;
using DergiOrtak.ViewModels;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DergiOrtak.Services
{
    public interface IDergiService
    {
        List<KategoriViewModel> KategoriListele();
        List<DergiViewModel> Listele();
        DergiViewModel Getir(int id);
        public void DergiEkle(DergiViewModel vm);
        public void DergiGuncelle(DergiViewModel vm);
        public void DergiSil(int id);

    }
    public class DergiService : IDergiService
    {
        private IDataHandler _dataHandler;
        public DergiService(IDataHandler dataHandler)
        {
            _dataHandler = dataHandler;
        }
        public List<DergiViewModel> Listele()
        {
            var liste = _dataHandler.Dergi.Listele();
            List<DergiViewModel> Dvm = new List<DergiViewModel>();
            foreach (var item in liste)
            {
                Dvm.Add(new DergiViewModel
                {
                    Adi = item.Adi,
                    Aciklama = item.Aciklama,
                    Id = item.Id,
                    KategoriAdi = item.Kategori.Adi,
                    KategoriId = item.KategoriId
                });
            }
            return Dvm;
        }
        public DergiViewModel Getir(int id)
        {
            var model = _dataHandler.Dergi.Getir(id);
            var vm = new DergiViewModel
            {
                Adi = model.Adi,
                Aciklama = model.Aciklama,
                Id = model.Id,
                KategoriAdi = model.Kategori.Adi,
                KategoriId = model.KategoriId
            };
            return vm;
        }
        public List<KategoriViewModel> KategoriListele()
        {
            var liste = _dataHandler.Kategori.Listele();
            List<KategoriViewModel> Dvm = new List<KategoriViewModel>();
            foreach (var item in liste)
            {
                Dvm.Add(new KategoriViewModel
                {
                    Adi = item.Adi,
                    Id = item.Id,
                    
                });
            }
            return Dvm;
        }
        public void DergiEkle(DergiViewModel vm)
        {
            var model = new Dergi
            {
                Aciklama = vm.Aciklama,
                Adi = vm.Adi,
                KategoriId = vm.KategoriId.Value
            };
            _dataHandler.Insert(model);
        }
        public void DergiGuncelle(DergiViewModel vm)
        {
            var model = new Dergi
            {
                Id = vm.Id,
                Aciklama = vm.Adi,
                Adi = vm.Adi,
                KategoriId = vm.KategoriId.Value
            };
            _dataHandler.Update(model);
        }
        public void DergiSil(int id)
        {
            var model = _dataHandler.Dergi.Getir(id);
            _dataHandler.Delete(model);
        }
    }
}
