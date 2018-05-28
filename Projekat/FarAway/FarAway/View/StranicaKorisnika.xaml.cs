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

        string user;
        StranicaKorisnikaViewModel skvm { get; set; } = new StranicaKorisnikaViewModel();

        protected async override void OnNavigatedTo(NavigationEventArgs e) //koristimo jer smo prenosili info sa jedne stranice na drugu
        {
            base.OnNavigatedTo(e);
           
            if (e.Parameter is string)
            {
                IMobileServiceTable<Korisnik> userTableObj = App.MobileService.GetTable<Korisnik>();
                Korisnik kor = (await userTableObj.ToListAsync()).Find(x => x.Username == e.Parameter.ToString()); //koristimo da pretrazujemo korisnika
                username.Text = e.Parameter.ToString();
                password.Text = kor.Password;
                email.Text = kor.Email;
                //ovdje treba pored username popuniti i ostale textblokove (password i email)
            }

        }
        public StranicaKorisnika()
        {

            this.InitializeComponent();
            DataContext = skvm;
        }

         /*private async void Button_Click(object sender, RoutedEventArgs e)
         {

             IMobileServiceTable<Korisnik> userTableObj = App.MobileService.GetTable<Korisnik>();
             try
             {
                 Korisnik kor = (await userTableObj.ToListAsync()).Find(x => x.Username == username.Text); //koristimo da pretrazujemo korisnika
                 await userTableObj.DeleteAsync(kor);
                 MessageDialog msgDialog = new MessageDialog("Uspješno ste izbrisali vas racun.");
                 await msgDialog.ShowAsync();
                 this.Frame.Navigate(typeof(MainPage));
             }
             catch (Exception ex)
             {
                 MessageDialog msgDialogError = new MessageDialog("Error : " + ex.ToString());
                 await msgDialogError.ShowAsync();
             }
         }

         private async void Button_Click_1(object sender, RoutedEventArgs e)
         {

             IMobileServiceTable<Korisnik> userTableObj = App.MobileService.GetTable<Korisnik>();
             Korisnik kor = (await userTableObj.ToListAsync()).Find(x => x.Username == user);
             try
             {
                 if (username.Text != user)
                 {

                     Korisnik kor2 = (await userTableObj.ToListAsync()).Find(x => x.Username == username.Text);
                     if (kor2 != null)
                     {
                         username.Text = kor.Username;
                         throw new Exception("Username je zauzet");
                     }
                     else
                     {
                         kor.Username = username.Text;
                         user = username.Text;
                     }
                 }
                 if (password.Text != kor.Password)
                 {
                     if (password.Text.Length <= 8)
                     {

                         password.Text = kor.Password;
                         throw new Exception("Password mora imati najmanje 8 karaktera");
                     }
                     kor.Password = password.Text;

                 }
                 if (email.Text != kor.Email)
                 {
                     kor.Email = email.Text;

                 }
                 await userTableObj.UpdateAsync(kor);
                 MessageDialog msgDialogError = new MessageDialog("Uspjesno ste ažurirali vaše podatke ;)");
                 await msgDialogError.ShowAsync();
             }
             catch(Exception ex)
             {
                 MessageDialog Error = new MessageDialog(ex.ToString());
                 await Error.ShowAsync();
             }

         }*/

        private void logout_Clik(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(MainPage));
        }

        private void unpin_Click(object sender, RoutedEventArgs e)
        {
            skvm.User = username.Text;
            username.Visibility = Visibility.Collapsed;
            newUsername.Visibility = Visibility.Visible;

            password.Visibility = Visibility.Collapsed;
            newPassword.Visibility = Visibility.Visible;

            email.Visibility = Visibility.Collapsed;
            newEmail.Visibility = Visibility.Visible;
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