using App_ISSSTE.Helpers;
using App_ISSSTE.Interfaces;
using App_ISSSTE.Models;
using Newtonsoft.Json;
using SQLite;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App_ISSSTE.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]

    public partial class MenuPage : MasterDetailPage
    {
        public List<MasterPageItem> MenuList { get; set; }
        public MenuPage()
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
            MenuList = new List<MasterPageItem>
            {

                //Adding menu items to menuList and you can define title ,page and icon
                new MasterPageItem() { Title = "Inicio", Icon = "casa.png", TargetType = typeof(HomePage) },
                new MasterPageItem() { Title = "Por entregar", Icon = "porentregar.png", TargetType = typeof(SettingPage) },
                new MasterPageItem() { Title = "Entregados", Icon = "carro.png", TargetType = typeof(DatosPacientes) },
                new MasterPageItem() { Title = "Respaldo", Icon = "estadistica.png", TargetType = typeof(LogoutPage) }
            };

            // Setting our list to be ItemSource for ListView in MainPage.xaml
            navigationDrawerList.ItemsSource = MenuList;

            // Initial navigation, this can be used for our home page
            Detail = new NavigationPage((Page)Activator.CreateInstance(typeof(HomePage)));

        }

        // Event for Menu Item selection, here we are going to handle navigation based
        // on user selection in menu ListView
        private void OnMenuItemSelected(object sender, SelectedItemChangedEventArgs e)
        {

            var item = (MasterPageItem)e.SelectedItem;
            Type page = item.TargetType;

            Detail = new NavigationPage((Page)Activator.CreateInstance(page));
            IsPresented = false;
        }
        public async void Cerrar(object sender, EventArgs e)
        {
            var answer = await DisplayAlert("Cerrar", "¿Usted desea cerrar sesión ? ", "Si", "No");
            if (answer)
            {
                Navigation.InsertPageBefore(new LoginPage(), this);
                await Navigation.PopAsync();

            }
            else
            {

            }
        }

    }
}
