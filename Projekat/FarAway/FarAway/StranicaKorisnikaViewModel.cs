using Microsoft.WindowsAzure.MobileServices;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Windows.UI.Popups;
using Microsoft.VisualBasic;

namespace FarAway
{
    public class StranicaKorisnikaViewModel: INotifyPropertyChanged
    {

        Korisnik korisnik;
        string user;
        public ICommand Azuriranje { get; set; }
        public ICommand Brisanje { get; set; }
        public INavigacija Navigacija { get; set; }
       
        public Korisnik Korisnik { get => korisnik; set { korisnik = value; OnPropertyChanged("Korisnik"); } }

        public string User
        {
            get => user;
            set
            {
                user = value;
                
            }
        }

        //public string HelpUsername { get => helpUsername; set { helpUsername = value; OnPropertyChanged("HelpUsername"); } }

        public StranicaKorisnikaViewModel()
        {
            Azuriranje = new RelayCommand<object>(AzurirajBazu);
            Brisanje = new RelayCommand<object>(IzbrisiIzBaze);
            korisnik = new Korisnik();
            Navigacija = new Navigacija();
           
            
        }

        public async void AzurirajBazu(object parametar)
        {
            try
            {
                if (korisnik.Username is null && korisnik.Password is null && korisnik.Email is null) throw new Exception("Molimo unesite username i password otvaranjem polja!");
             
                IMobileServiceTable<Korisnik> tabela = App.MobileService.GetTable<Korisnik>();
                Korisnik kor = (await tabela.ToListAsync()).Find(x => x.Username == korisnik.Username);
                if (kor != null) throw new Exception("Username je zauzet");

                if (korisnik.Password.Length <= 8) throw new Exception("Password mora imati najmanje 8 karaktera!");



                List<Korisnik> l = await tabela.ToListAsync();
                int i= l.FindIndex(x => x.Username==User);

                if (Korisnik.Username is null) { l.ElementAt(i).Username = l.ElementAt(i).Username; }
                else { l.ElementAt(i).Username = Korisnik.Username; }
                
                if (Korisnik.Password is null) { l.ElementAt(i).Password = l.ElementAt(i).Password; }
                else { l.ElementAt(i).Password = Korisnik.Password; }
               
                if (Korisnik.Email is null) { l.ElementAt(i).Email = l.ElementAt(i).Email; }
                else { l.ElementAt(i).Email = Korisnik.Email; }
               
             
                await tabela.UpdateAsync(l.ElementAt(i));
                MessageDialog msgDialog = new MessageDialog("Uspješno ste azurirali podatke.");
                await msgDialog.ShowAsync();

                Navigacija.Navigiraj(typeof(StranicaKorisnika), Korisnik.Username);
            }
            catch (Exception ex)
            {
                MessageDialog msgDialog = new MessageDialog(ex.ToString());
                await msgDialog.ShowAsync();
            }
        }

        public async void IzbrisiIzBaze(object parametar)
        {
            try
            {
                if (korisnik.Username is null && korisnik.Password is null) throw new Exception("Molimo unesite username i password otvaranjem polja!");
                IMobileServiceTable<Korisnik> tabela = App.MobileService.GetTable<Korisnik>();
                List<Korisnik> l = await tabela.ToListAsync();
                int i = l.FindIndex(x => x.Username == Korisnik.Username);
                await tabela.DeleteAsync(l.ElementAt(i));
                MessageDialog msgDialog = new MessageDialog("Uspješno ste obrisali profil");
                await msgDialog.ShowAsync();
                Navigacija.Navigiraj(typeof(MainPage));
            }
            catch(Exception ex)
            {
                MessageDialog msgDialog = new MessageDialog(ex.ToString());
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(nameof(propertyName)));
            }
        }

    }
}
