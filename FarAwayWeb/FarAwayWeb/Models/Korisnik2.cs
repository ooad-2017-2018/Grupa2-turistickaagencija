using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FarAwayWeb.Models
{
    public class Korisnik2
    {
        public int Id { get; set; }
        [Required]
        [DisplayName("Ime")]
        public string Ime { get; set; }
        [Required]
        [DisplayName("Prezime")]
        public string Prezime { get; set; }
        [Required]
        [DisplayName("Datum rodjenja")]
        public string DRodjenja { get; set; }
        [Required]
        [DisplayName("Email")]
        public string Email { get; set; }
        [Required]
        [DisplayName("Username")]
        public string Username { get; set; }
        [Required]
        [DisplayName("Password")]
        public string Password { get; set; }
        [Range(8,20,ErrorMessage = "Password mora imati najmanje 8 karaktera")]
        public virtual ICollection<UpisUBazu> UpisUBazu { get; set; }


    }
}