using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FarAway
{
    public class Korisnik
    {
        private string id;
        private string ime;
        private string prezime;
        private double brojputovanja;
        private string username;
        private string password;
        private string email;
        private string datumRodjenja; 

        public Korisnik() { }

        public Korisnik(string ime, string prezime, string username, string password, string email, string datumrodjenja)
        {
            Ime = ime;
            Prezime = prezime;
            Username = username;
            Password = Password;
            Email = email;
            DatumRodjenja = datumrodjenja;          

        }

        public string Ime { get => ime; set => ime = value; }
        public string Prezime { get => prezime; set => prezime = value; }
        public double Brojputovanja { get => brojputovanja; set => brojputovanja = value; }
        public string Username { get => username; set => username = value; }
        public string Password { get => password; set => password = value; }
        public string Email { get => email; set => email = value; }
        public string DatumRodjenja { get => datumRodjenja; set => datumRodjenja = value; }
        public string Id { get => id; set => id = value; }
    }
}
