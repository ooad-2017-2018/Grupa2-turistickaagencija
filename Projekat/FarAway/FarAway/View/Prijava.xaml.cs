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
// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace FarAway
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class Prijava : Page
    {
        public Prijava()
        {
            this.InitializeComponent();
        }

        private void naziv_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(MainPage));
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private async void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if (yas.Text.Length == 0 || password.Password.Length == 0)
            {
                MessageDialog msgbox = new MessageDialog("Molimo unesite sva polja!");
            }
            else if (yas.Text.Length != 0 || (password.Password).Length != 0)
            {
                IMobileServiceTable<Korisnik> rKorisnik = App.MobileService.GetTable<Korisnik>();

                try
                {
                    Korisnik kor = (await rKorisnik.ToListAsync()).Find(x => x.Username == yas.Text); //koristimo da pretrazujemo korisnika

                    if (kor == null)
                    {
                        MessageDialog msgbox = new MessageDialog("Nemate racun, da li želite kreirati racun?");

                        msgbox.Commands.Clear();
                        msgbox.Commands.Add(new UICommand { Label = "Da", Id = 0 });
                        msgbox.Commands.Add(new UICommand { Label = "Ne", Id = 1 });


                        var res = await msgbox.ShowAsync();

                        if ((int)res.Id == 0)
                        {
                            Frame.Navigate(typeof(Registracija));
                        }

                        if ((int)res.Id == 1)
                        {
                            Frame.Navigate(typeof(MainPage));
                        }

                    }
                    else
                    {
                        if (password.Password != kor.Password) throw new Exception("Pasword nije validan!");
                        else if (yas.Text != kor.Username) throw new Exception("Username nije validan");
                        this.Frame.Navigate(typeof(StranicaKorisnika), yas.Text);
                    }
                }
                catch (Exception ex)
                {

                    MessageDialog msgDialogError = new MessageDialog("Error : " + ex.ToString());
                    await msgDialogError.ShowAsync();

                }
            }
        }
    }
}
