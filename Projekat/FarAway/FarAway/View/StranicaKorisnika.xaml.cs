using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using Microsoft.WindowsAzure.MobileServices;
using Windows.UI.Popups;
using Newtonsoft.Json.Linq;
// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace FarAway
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class StranicaKorisnika : Page
    {
        public StranicaKorisnika()
        {

            this.InitializeComponent();


        }
        protected override void OnNavigatedTo(NavigationEventArgs e) //koristimo jer smo prenosili info sa jedne stranice na drugu
        {
           
            if (e.Parameter is string)
            {
                username.Text=e.Parameter.ToString();
                //ovdje treba pored username popuniti i ostale textblokove (password i email)
            }

        }
        IMobileServiceTable<Korisnik> userTableObj = App.MobileService.GetTable<Korisnik>();
        private async void Button_Click(object sender, RoutedEventArgs e)
        {

           
            try
            {

               /*   var item = from x in userTableObj where x.Username == username.Text select x;                
                   var k = await item.ToListAsync();
                   var i = k[0];
                   await userTableObj.DeleteAsync(i);*/
               /* Korisnik k = new Korisnik();
                k.Username = username.dajUsername();
                k.Email = email.Text;
                await userTableObj.DeleteAsync(k);*/
                Korisnik kor = (await userTableObj.ToListAsync()).Find(x => x.Username == username.Text); //koristimo da pretrazujemo korisnika
                await userTableObj.DeleteAsync(kor);
                MessageDialog msgDialog = new MessageDialog("Uspješno ste izbrisali vas racun.");
                await msgDialog.ShowAsync();
            }
            catch (Exception ex)
            {
                MessageDialog msgDialogError = new MessageDialog("Error : " + ex.ToString());
                await msgDialogError.ShowAsync();
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            //Ovdje treba dodati funkcionalnost da updatetuje podatke tj. moze promijeniti username, pass i email
            //treba i ovdje provjeriti da nemaju 2 ista username

        }
    }
}
/*try
            {
                Korisnik kor = (await tabelica.ToListAsync()).Find(x => x.Id == IDProfilaBrisanjeText.Text);
await tabelica.DeleteAsync(kor);
MessageDialog msg = new MessageDialog("Uspjesno ste obrisali korisnika.");
await msg.ShowAsync();
            }
            catch (Exception)
            {
                MessageDialog msgError = new MessageDialog("Ne postoji korisnik sa tim username-om.");
await msgError.ShowAsync();
            }*/