using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FarAwayWeb.Models
{
    public class UpisUBazu
    {
        public int UpisUBazuId { get; set; }
         public int KorisnikId { get; set; }
        public virtual Korisnik2 Korisnik { get; set; }



    }
}