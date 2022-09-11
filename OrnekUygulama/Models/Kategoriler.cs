﻿using System;
using System.Collections.Generic;

#nullable disable

namespace OrnekUygulama.Models
{
    public partial class Kategoriler
    {
        public Kategoriler()
        {
            YemekTarifleris = new HashSet<YemekTarifleri>();
        }

        public int KategoriId { get; set; }
        public string Kategoriadi { get; set; }
        public bool? Aktif { get; set; }
        public bool? Silindi { get; set; }

        public virtual ICollection<YemekTarifleri> YemekTarifleris { get; set; }
    }
}
