using Acr.UserDialogs;
using SQLite;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App_ISSSTE.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class municipio : ContentPage
    {
        public municipio()
        {
            InitializeComponent(); 
            if (Connectivity.NetworkAccess != NetworkAccess.Internet)
            {
                DisplayAlert("IMPORTANTE", "La aplicación esta sin internet, asi que solo funcionara con los datos almacenados previamente.", "Aceptar");
                App.Database.CargarInicial();
                this.Loadmuni();
            }
            else
            {
                DisplayAlert("URGENTE", "Se recomienda sincronizar los datos", "Aceptar");
                App.Database.Loadmuni();
                App.Database.CargarInicial();
                this.Loadmuni();
            }
            MyListViewmuni.RefreshCommand = new Command(() =>
            {
                
            });
           

        }

        public async void Loadmuni()
        {
            UserDialogs.Instance.ShowLoading("Cargando datos");
            await Task.Delay(1000);
            MyListViewmuni.ItemsSource = await App.Database.GetPeopleAsyncmuni();
            UserDialogs.Instance.HideLoading();
        }

        public async void LoadRefreshingmuni()
        {
            UserDialogs.Instance.ShowLoading("Actulizando datos");
            await Task.Delay(1000);
            App.Database.Loadmuni();
            App.Database.CargarInicial();
            MyListViewmuni.ItemsSource = await App.Database.GetPeopleAsyncmuni();
            MyListViewmuni.IsRefreshing = false;
            UserDialogs.Instance.HideLoading();
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            var buttonClickHandler = (Button)sender;
            Grid stackLayout = (Grid)buttonClickHandler.Parent;
            Label label = (Label)stackLayout.Children[0];
            string id = label.Text;
            Console.WriteLine("Holaaaaaa amor = " + id);
            await Navigation.PushAsync(new SettingPage());

        }

        private void municipio_Searched_TextChanged(object sender, TextChangedEventArgs e)
        {
            var databasePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "control_issste1.db3");
            var db = new SQLiteConnection(databasePath);
            SQLiteConnection connection = new SQLiteConnection(databasePath);
            var keyWord = municipio_Searched.Text;
            if (keyWord.Length >= 1)
            {
                MyListViewmuni.IsVisible = false;
                Buscadormuni.IsVisible = true;
                var get_docnumb = db.Query<municipio>("SELECT * FROM sepomex WHERE nombre LIKE ?", "%" + municipio_Searched.Text + "%");
                Buscadormuni.ItemsSource = get_docnumb;
            }
            else
            {
                Buscadormuni.IsVisible = false;
                MyListViewmuni.IsVisible = true;
            }
        }

        private void Buscadormuni_ItemTapped(object sender, ItemTappedEventArgs e)
        {

        }

        private void MyListViewmuni_ItemTapped(object sender, ItemTappedEventArgs e)
        {

        }
    }
    }




   
    

    
