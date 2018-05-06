using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Popups;
using System.Net;

namespace FarAway
{
    public class KorisnikLoginViewModel
    {
        private string username;
        private string pass;
        private string email;
        Korisnik korisnik;

        public string Username { get => username; set => username = value; }
        public string Pass { get => pass; set => pass = value; }
        public string Email { get => email; set => email = value; }
        public Korisnik Korisnik { get => korisnik; set => korisnik = value; }

        public KorisnikLoginViewModel(string username, string password, string email)
        {
            Username = username;
            Pass = password;
            Email = email;
        }
        public async void VerifikacijaPassworda()
        {
            if (Pass.Any(c => char.IsDigit(c)) == false)
            {
                var dialog = new MessageDialog("Password mora sadrzati bar jedan broj!");
                await dialog.ShowAsync();
            }

            else if (Pass.Length < 5)
            {
                var dialog = new MessageDialog("Password mora imati vise od 5 znakova!");

                await dialog.ShowAsync();
            }

        }
      /*  public bool VerifikacijaEmaila()
        {
            try
            {
                var addr = new System.Net. Mail.MailAddress(Email);
                return addr.Address == Email;
            }
            catch
            {
                return false;
            }
        }*/



    }
}
