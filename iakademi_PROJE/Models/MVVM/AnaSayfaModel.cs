using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace iakademi_PROJE.Models.MVVM
{
    public class AnaSayfaModel
    {
        public List<tbl_Products> urunler { get; set; }

        public tbl_Products tek_urun { get; set; }

        public List<tbl_Products> yeni_urunler { get; set; }

        public List<tbl_Products> ozel_urunler { get; set; }

        public List<tbl_Products> indirim_urunler { get; set; }

        public List<tbl_Products> onecikan_urunler { get; set; }

        public List<tbl_Products> coksatan_urunler { get; set; }

        public List<tbl_Products> superfiyat_urunler { get; set; }

        public List<tbl_Products> dikkatceken_urunler { get; set; }
    }
}