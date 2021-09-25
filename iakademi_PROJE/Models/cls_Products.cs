using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace iakademi_PROJE.Models
{
    public class cls_Products
    {

        iakademi9_PROJEEntities db = new iakademi9_PROJEEntities();
        List<tbl_Products> urunler;
        tbl_Products urun;

        public List<tbl_Products> slider_urunler_getir()
        {
          urunler = db.tbl_Products.Where(p => p.status == 2).Take(8).ToList();
            return urunler;
        }

        public tbl_Products gunun_urununu_getir()
        {
            urun = db.tbl_Products.FirstOrDefault(p => p.status == 1);
            return urun;
        }

        public List<tbl_Products> enyeni_urunler_getir()
        {
            urunler = db.tbl_Products.OrderByDescending(p => p.adddate).Take(8).ToList();
            return urunler;
        }

        public List<tbl_Products> ozel_urunler_getir()
        {
            urunler = db.tbl_Products.Where(p => p.status == 3).Take(8).ToList();
            return urunler;
        }

        public List<tbl_Products> indirimli_urunler_getir()
        {
            urunler = db.tbl_Products.OrderByDescending(p => p.discount).Take(8).ToList();
            return urunler;
        }

        public List<tbl_Products> onecikan_urunler_getir()
        {
            urunler = db.tbl_Products.OrderByDescending(p => p.onecikanlar).Take(8).ToList();
            return urunler;
        }

        public List<tbl_Products> coksatan_urunler_getir()
        {
            urunler = db.tbl_Products.OrderByDescending(p => p.coksatanlar).Take(8).ToList();
            return urunler;
        }

        public List<tbl_Products> superfiyat_urunler_getir()
        {
            urunler = db.tbl_Products.Where(p => p.status == 4).Take(8).ToList();
            return urunler;
        }

        public List<tbl_Products> dikkatceken_urunler_getir()
        {
            urunler = db.tbl_Products.Where(p => p.status == 5).Take(8).ToList();
            return urunler;
        }

        public static void one_cikanlar_kolonunu_arttır(int id)
        {
            using(iakademi9_PROJEEntities dbs =new iakademi9_PROJEEntities())
            {
                tbl_Products prd = dbs.tbl_Products.FirstOrDefault(p => p.productID == id);
                prd.onecikanlar += 1;
                dbs.SaveChanges();
            }
        }







    }
}