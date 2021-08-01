using Acr.UserDialogs;
using App_ISSSTE.Helpers;
using App_ISSSTE.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Ubiety.Dns.Core;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App_ISSSTE.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginPage : ContentPage
    {
        
        public LoginPage()
        {
            InitializeComponent();
        }

        private async void ButtonLogin_Clicked(object sender, EventArgs e)
        {
            UserDialogs.Instance.ShowLoading("Iniciando Sesion...");
            if (EntryUsername.Text != null && EntryPassword.Text != null)
            {
                var validData = App.Database.LoginValidate(EntryUsername.Text, EntryPassword.Text);
                if (await validData == true)
                {
                    Navigation.InsertPageBefore(new MenuPage(), this);
                    await Navigation.PopAsync();
                    UserDialogs.Instance.HideLoading();
                }
                else
                {
                    await DisplayAlert("Error de inicio de sesion", "Usuario o contraseña incorrectos", "Aceptar");
                    UserDialogs.Instance.HideLoading();
                }

            }
            else
            {
                await DisplayAlert("Advertencia", "Ingrese email y contraseña por favor", "Aceptar");
                UserDialogs.Instance.HideLoading();
            }
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new RegistarUser());
        }
    }
}
