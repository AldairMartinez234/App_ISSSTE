using Acr.UserDialogs;
using App_ISSSTE.Helpers;
using App_ISSSTE.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App_ISSSTE.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DatosPacientes : ContentPage
    {
        public DatosPacientes(string paciente)
        {
            InitializeComponent();
            Id.Text = paciente;
        }
        protected override async void OnAppearing()
        {
            var databasePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "control_issste1.db3");
            var db = new SQLiteConnection(databasePath);
            var get_docnumb = db.Query<Pacientes>("SELECT * FROM Pacientes WHERE id = ?",  Id.Text );
            listadatos.ItemsSource = get_docnumb;
            base.OnAppearing();
        }

        public async void Registro(object sender, EventArgs e)
        {
            UserDialogs.Instance.ShowLoading("Verificando codigo...");
            var databasePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "control_issste1.db3");
            var db = new SQLiteConnection(databasePath);

            var pedidocodigo = new Pedidos { entregados ="Pedido Entregado", codigo_entrega = Codigo.Text, pacientes_id = Id.Text };
            db.Insert(pedidocodigo);

            HttpClient client = new HttpClient
            {
                BaseAddress = new Uri(Constants.BaseApiAddress)
            };
            string url = string.Format("api/paciente/entregados/");
            string response = await client.GetStringAsync(url + Id.Text +"/"+ Codigo.Text);
            UserDialogs.Instance.HideLoading();
            await DisplayAlert("Verificacion", "Codigo Correcto", "OK");
        }
    }
}






