using Microsoft.AspNetCore.Mvc;
using OrnekUygulama.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrnekUygulama.Controllers
{
    public class YonetimController : Controller
    {
        yemektarifleriDBContext db = new yemektarifleriDBContext();
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
        public IActionResult Sayfalar()
        {
            var sayfalar = db.Sayfalars.Where(s => s.Silindi == false).OrderBy(s => s.Baslik).ToList();

            return View(sayfalar);
        }
        public IActionResult SayfaEkle()
        {
            return View();
        }
        [HttpPost]
        public IActionResult SayfaEkle(Sayfalar s)
        {
            s.Silindi = false;
            db.Sayfalars.Add(s);
            db.SaveChanges();
            return RedirectToAction("Sayfalar");
        }
        public IActionResult SayfaGetir(int id)
        {
            var sayfa = db.Sayfalars.Where(s => s.Silindi == false && s.SayfaId == id).FirstOrDefault();

            return View("SayfaGuncelle",sayfa);         
        }
        public IActionResult SayfaGuncelle(Sayfalar syf)
        {
            var sayfa = db.Sayfalars.Where(s => s.Silindi == false && s.SayfaId == syf.SayfaId).FirstOrDefault();

            sayfa.Baslik = syf.Baslik;
            sayfa.Icerik = syf.Icerik;
            sayfa.Aktif = syf.Aktif;
            db.Sayfalars.Update(sayfa);
            db.SaveChanges();
            return RedirectToAction("Sayfalar");
        }

        public IActionResult SayfaSil(int id)
        {
            var sayfa = db.Sayfalars.Where(s => s.Silindi == false && s.SayfaId == id).FirstOrDefault();

            sayfa.Silindi = true;
           
            db.Sayfalars.Update(sayfa);
            db.SaveChanges();
            return RedirectToAction("Sayfalar");
        }





        public IActionResult Kategoriler()
        {
            var kategoriler = db.Kategorilers.Where(k => k.Silindi == false).OrderBy(k => k.Kategoriadi).ToList();

            return View(kategoriler);
        }
        public IActionResult KategoriEkle()
        {
            return View();
        }
        [HttpPost]
        public IActionResult KategoriEkle(Kategoriler k)
        {
            k.Silindi = false;
            db.Kategorilers.Add(k);
            db.SaveChanges();
            return RedirectToAction("Kategoriler");
        }
        public IActionResult KategoriGetir(int id)
        {
            var kategori = db.Kategorilers.Where(k => k.Silindi == false && k.KategoriId == id).FirstOrDefault();

            return View("KategoriGuncelle", kategori);
        }


        public IActionResult KategoriYemekler(int id)
        {
            var yemekler = db.YemekTarifleris.Where(y => y.Silindi == false && y.KategoriId == id).ToList();

            return View("Tarifler", yemekler);

        }
        public IActionResult KategoriGuncelle(Kategoriler ktgr)
        {
            var kategori = db.Kategorilers.Where(k => k.Silindi == false && k.KategoriId == ktgr.KategoriId).FirstOrDefault();

            kategori.Kategoriadi = ktgr.Kategoriadi;

            kategori.Aktif = ktgr.Aktif;
            db.Kategorilers.Update(kategori);
            db.SaveChanges();
            return RedirectToAction("Kategoriler");
        }

        public IActionResult KategoriSil(int id)
        {
            var kategori = db.Kategorilers.Where(k => k.Silindi == false && k.KategoriId == id).FirstOrDefault();
            kategori.Silindi = true;

            db.Kategorilers.Update(kategori);
            db.SaveChanges();
            return RedirectToAction("Kategoriler");
        }
        public IActionResult CikisYap()
        {
            return View();
        }
    }
}
