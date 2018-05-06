using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FarAway
{
    class KorisnikRegistracijaViewModel
    {
        private string username;
        private string password;
        private string email;

        public KorisnikRegistracijaViewModel(string username, string email, string password)
        {
            Username = username;
            Password = password;
            Email = email;
        }

        public string Username { get => username; set => username = value; }
        public string Password { get => password; set => password = value; }
        public string Email { get => email; set => email = value; }

        //ovdje ide povezivanje sa bazom
    }
}

