using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Popups;
using System.Net;
using System.ComponentModel;
using System.Windows.Input;
using Microsoft.WindowsAzure.MobileServices;

namespace FarAway
{
    public class KorisnikViewModel : INotifyPropertyChanged
    {
        private Korisnik korisnik;
        private string pSifra;
        public ICommand UnesiUBazu { get; set; }
        public INavigacija Navigacija { get; set; }
       
        public Korisnik Korisnik { get => korisnik; set { korisnik = value; OnPropertyChanged("Korisnik"); } }
        public string PSifra { get => pSifra; set { pSifra = value; OnPropertyChanged("password2"); } }


        public KorisnikViewModel()
        {
            UnesiUBazu = new RelayCommand<object>(DodajUBazu);
            korisnik = new Korisnik();
            Navigacija = new Navigacija();
           
        }

        public async void DodajUBazu(object parametar)
        {
            try
            {
                if (korisnik.Password.Length <= 8) throw new Exception("Password mora imati najmanje 8 karaktera!");
                if (korisnik.Password != PSifra) throw new Exception("Password-i nisu isti!");

                if (korisnik.Ime is null || korisnik.Prezime is null || korisnik.DatumRodjenja is null || korisnik.Email is null || korisnik.Username is null || korisnik.Password is null || PSifra is null) throw new Exception("Molimo unesite sva polja!");

                IMobileServiceTable<Korisnik> userTableObj = App.MobileService.GetTable<Korisnik>();
                Korisnik kor = (await userTableObj.ToListAsync()).Find(x => x.Username == korisnik.Username);
                if (kor != null) throw new Exception("Username je zauzet");

                await userTableObj.InsertAsync(korisnik);
                MessageDialog msgDialog = new MessageDialog("Uspješno ste se registrovali :)");
                await msgDialog.ShowAsync();
                Navigacija.Navigiraj(typeof(StranicaKorisnika), korisnik.Username);

            }
            catch (Exception ex)
            {

                MessageDialog error4 = new MessageDialog(ex.ToString());
                await error4.ShowAsync();
            }                     
        }
        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
