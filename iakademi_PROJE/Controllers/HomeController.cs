using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using iakademi_PROJE.Models;
using iakademi_PROJE.Models.MVVM;

namespace iakademi_PROJE.Controllers
{
    public class HomeController : BaseController
    {

        iakademi9_PROJEEntities db = new iakademi9_PROJEEntities();
        AnaSayfaModel ans = new AnaSayfaModel();
        cls_Products cp = new cls_Products();

        // GET: Home
        public ActionResult Index()
        {
            ans.urunler = cp.slider_urunler_getir();
            ans.tek_urun = cp.gunun_urununu_getir();
            ans.yeni_urunler = cp.enyeni_urunler_getir();
            ans.ozel_urunler = cp.ozel_urunler_getir();
            ans.indirim_urunler = cp.indirimli_urunler_getir();
            ans.onecikan_urunler = cp.onecikan_urunler_getir();
            ans.coksatan_urunler = cp.coksatan_urunler_getir();
            ans.superfiyat_urunler = cp.superfiyat_urunler_getir();
            ans.dikkatceken_urunler = cp.dikkatceken_urunler_getir();

            return View(ans);
        }

        
        //sepet sayfası
        public ActionResult cart()
        {
            return View();
        }
        
       
        //sepete ekle
        public ActionResult Sepet(int id)
        {
            cls_Products.one_cikanlar_kolonunu_arttır(id);
            return View();
        }

       
        
        public ActionResult detaylar(int id)
        {
            cls_Products.one_cikanlar_kolonunu_arttır(id);
            return View();
        }
    }
}