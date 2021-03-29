using Acr.UserDialogs;
using App_ISSSTE.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App_ISSSTE.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class UsersListPage : ContentPage
    {
        public UsersListPage()
        {
            InitializeComponent();
            NavigationPage.SetHasBackButton(this, false);

            this.LoadPacientes();
        }

        public async void LoadPacientes()
        {
            UserDialogs.Instance.ShowLoading("Cargando datos");
            await Task.Delay(1000);
            listUser.ItemsSource = await App.UserDB.GetUsers();
            UserDialogs.Instance.HideLoading();
        }
    }
}