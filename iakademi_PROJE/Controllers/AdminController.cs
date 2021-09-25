using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using iakademi_PROJE.Models;

namespace iakademi_PROJE.Controllers
{
    public class AdminController : Controller
    {

        iakademi9_PROJEEntities db = new iakademi9_PROJEEntities();
        
        
        // GET: Admin
        public ActionResult login()
        {
            return View();
        }


        [HttpPost]
        public ActionResult login(string email,string password)
        {
            tbl_Users usr = db.tbl_Users.FirstOrDefault(u => u.email == email && u.password == password && u.adminmi == true);
            if (usr!=null)
            {
                //admin kullanıcısı
                Session["email"] = usr.email;
                Session["isim"] = usr.name_surname;
                return RedirectToAction("Anasayfa", "Admin");
            }
            return View();
        }

        public ActionResult Anasayfa()
        {
            return View();
        }


        [HttpGet]
        public ActionResult urunGiris()
        {
            List<tbl_Categories> catlist = db.tbl_Categories.ToList();
            ViewData["catlist"] = catlist.Select(a => new SelectListItem { Text = a.categoryname, Value = a.categoryID.ToString() }).ToList();

            List<tbl_Suppliers> marlist = db.tbl_Suppliers.ToList();
            ViewData["marlist"] = marlist.Select(a => new SelectListItem { Text = a.brandname, Value = a.supplierID.ToString() }).ToList();

            return View();
        }


        [HttpPost]
        public ActionResult urunGiris(tbl_Products urn,HttpPostedFileBase fileuploader)
        {
            urn.aktif = true;
            urn.adddate = DateTime.Now;
            urn.coksatanlar = 0;
            urn.onecikanlar = 0;
            urn.photopath = fileuploader.FileName;
            //"/Content/urun_resimleri/new-p/2.jpg"

            //resmi ürün resimleri klasörüne fiziksel olarak kopyalayacak
            string path = Path.Combine(Server.MapPath("/Content/urun_resimleri"), Path.GetFileName(fileuploader.FileName));
            fileuploader.SaveAs(path);

            if (urn.discount==null)
            {
                urn.discount = 0;
            }

            if (urn.status == null)
            {
                urn.status = 0;
            }

            try
            {
                db.tbl_Products.Add(urn);
                db.SaveChanges();
                Session["Mesaj"] = "Ürün başarıyla kaydedildi.";
            }
            catch (Exception)
            {

                Session["Mesaj"] = "HATA!! Ürün başarıyla kaydedilemedi.";
            }

            

            return RedirectToAction("urunGiris");
        }


    }
}