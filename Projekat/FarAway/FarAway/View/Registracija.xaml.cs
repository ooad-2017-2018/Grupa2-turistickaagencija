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

        private void btnRegistracija_Click(object sender, RoutedEventArgs e)
        {
            IMobileServiceTable<Korisnik> userTableObj = App.MobileService.GetTable<Korisnik>();
            try
            {
                Korisnik obj = new Korisnik();
                obj.Ime = ime.Text;
                obj.Prezime = prezime.Text;
                obj.DatumRodjenja = Convert.ToString(dRodjenja);
                obj.Email = email.Text;
                obj.Username = username.Text;
                obj.Password = Convert.ToString(password);
                userTableObj.InsertAsync(obj);
                MessageDialog msgDialog = new MessageDialog("Uspješno ste unijeli novog korisnika.");
                msgDialog.ShowAsync();
            }
            catch (Exception ex)
            {
                MessageDialog msgDialogError = new MessageDialog("Error : " + ex.ToString());
                msgDialogError.ShowAsync();
            }
        }
    }
}
