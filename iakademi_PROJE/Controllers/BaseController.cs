using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using iakademi_PROJE.Models;

namespace iakademi_PROJE.Controllers
{
    public class BaseController : Controller
    {
        // GET: Base


        /*
         * tbl_products -> status (2) -> slider
         * tbl_products -> status (1) -> Special Products
         * tbl_products -> tarih kolonu order by desc
         * tbl_products -> status (3) -> özel ürünler
         * tbl_products -> indirim kolonu -> indirimli ürünler
         * tbl_products -> onecikanlar_kolonu () öne çıkanlar order by desc
         * tbl_products -> coksatanlar_kolonu () çok satanlar order by desc
         * tbl_products -> Süper Fiyat, Süper Teklif (status = 4)
         * tbl_products -> dikkat çeken ürünler (status = 5)
         * detay -> kategorinin en çok bakılan ürünleri
         * sıklıkla  birlikte bakılanlar
        */

        iakademi9_PROJEEntities db = new iakademi9_PROJEEntities();

        public BaseController()
       {
            //kategori
            List<tbl_Categories> catlist = db.tbl_Categories.ToList();
            ViewBag.kategoriler = catlist;

            //marka
            ViewBag.markalar = db.tbl_Suppliers.ToList();
            
            //ceo
        }
    }
}