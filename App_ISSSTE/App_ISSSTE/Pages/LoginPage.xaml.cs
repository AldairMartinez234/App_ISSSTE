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
            
            LoginService services = new LoginService();
            LoginModel loginviewmodel = new LoginModel();
            var getLoginDetails = await services.CheckLoginIfExists(EntryUsername.Text, EntryPassword.Text);

            if (getLoginDetails)
            {
                
               
                Navigation.InsertPageBefore(new MenuPage (), this);
                await Navigation.PopAsync();
                

            }
            else
            {
                await DisplayAlert("Error", "El correo o la contraseña son incorrectos o no existen", "Aceptar");
            }
            UserDialogs.Instance.HideLoading();
        }
    }
}