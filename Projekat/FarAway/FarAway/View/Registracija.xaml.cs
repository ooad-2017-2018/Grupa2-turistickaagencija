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
using System.Net;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace FarAway
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class Registracija : Page
    {
        public Registracija()
        {
           
            this.InitializeComponent();
        }

        private void naziv_Click(object sender, RoutedEventArgs e)
        {
          
            this.Frame.Navigate(typeof(MainPage));
        }

        private async void btnRegistracija_Click(object sender, RoutedEventArgs e)
        {
            IMobileServiceTable<Korisnik> userTableObj = App.MobileService.GetTable<Korisnik>();
            //dodati provjeru da se oba passworda slazu
            try
            {
                Korisnik kor = (await userTableObj.ToListAsync()).Find(x => x.Username == username.Text);
                if (kor == null)
                {
                    if(password.Password!=password2.Password)
                    {
                        password.Password = "";
                        password2.Password = "";
                        throw new Exception("Password nije isti! sorry fish");
                        
                    }
                    Korisnik obj = new Korisnik();
                    obj.Id = username.Text;
                    obj.Ime = ime.Text;
                    obj.Prezime = prezime.Text;
                    obj.DatumRodjenja = Convert.ToString(dRodjenja.Date);
                    obj.Email = email.Text;
                    obj.Username = username.Text;
                    obj.Password = password.Password;
                    userTableObj.InsertAsync(obj);
                    MessageDialog msgDialog = new MessageDialog("Uspješno ste unijeli novog korisnika.");
                    msgDialog.ShowAsync();
                }
                else
                {
                    MessageDialog msgDialog = new MessageDialog("Korisnik vec postoji");
                    msgDialog.ShowAsync();
                    this.Frame.Navigate(typeof(Prijava));
                }
            }
            catch (Exception ex)
            {
                MessageDialog msgDialogError = new MessageDialog("Error : " + ex.ToString());
                msgDialogError.ShowAsync();
            }
        }
    }
}
