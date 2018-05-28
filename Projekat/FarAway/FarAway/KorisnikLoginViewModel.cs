using Microsoft.WindowsAzure.MobileServices;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Windows.UI.Popups;

namespace FarAway
{
    public class KorisnikLoginViewModel: INotifyPropertyChanged
    {
        Korisnik korisnik;
        public ICommand Prijava { get; set; }
        public INavigacija Navigacija { get; set; }
    

        public Korisnik Korisnik { get => korisnik; set { korisnik = value; OnPropertyChanged("Korisnik"); } }

        public KorisnikLoginViewModel()
        {
            Prijava = new RelayCommand<object>(PrijavaNaStranicu);
            Navigacija = new Navigacija();
            korisnik = new Korisnik();

        }


        public async void PrijavaNaStranicu(object parametar)
        {
            try
            {

                if (korisnik.Username is null) throw new Exception("Molimo unesite sva polja!");
                if (korisnik.Password is null) throw new Exception("Molimo unesite sva polja!");
                IMobileServiceTable<Korisnik> tabela = App.MobileService.GetTable<Korisnik>();
                Korisnik kor = (await tabela.ToListAsync()).Find(x => x.Username == Korisnik.Username);
                if (kor != null)
                {
                    if (korisnik.Password != kor.Password) throw new Exception("Pogresan password!");
                    else Navigacija.Navigiraj(typeof(StranicaKorisnika), Korisnik.Username);
                }
                else
                {
                    MessageDialog msgbox = new MessageDialog("Nemate racun, da li želite kreirati racun?");

                    msgbox.Commands.Clear();
                    msgbox.Commands.Add(new UICommand { Label = "Da", Id = 0 });
                    msgbox.Commands.Add(new UICommand { Label = "Ne", Id = 1 });

                    var res = await msgbox.ShowAsync();

                    if ((int)res.Id == 0)
                    {
                        Navigacija.Navigiraj(typeof(Registracija));
                    }

                    if ((int)res.Id == 1)
                    {
                        Navigacija.Navigiraj(typeof(MainPage));
                    }
                }
            }
            catch(Exception ex)
            {
                MessageDialog msgDialogError = new MessageDialog(ex.ToString());
                await msgDialogError.ShowAsync();
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

