using App_ISSSTE.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App_ISSSTE.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RegistarUser : ContentPage
    {
        readonly Users user = new Users();
        
        public RegistarUser()
        {
            InitializeComponent();
            NavigationPage.SetHasBackButton(this, false);
            emailEntry.ReturnCommand = new Command(() => userNameEntry.Focus());
            userNameEntry.ReturnCommand = new Command(() => passwordEntry.Focus());
            passwordEntry.ReturnCommand = new Command(() => confirmpasswordEntry.Focus());
            confirmpasswordEntry.ReturnCommand = new Command(() => rol.Focus());
        }

        private async void signUp_Clicked(object sender, EventArgs e)
        {
            if ((string.IsNullOrWhiteSpace(userNameEntry.Text)) || (string.IsNullOrWhiteSpace(emailEntry.Text)) ||
                (string.IsNullOrWhiteSpace(passwordEntry.Text)) || (string.IsNullOrWhiteSpace(rol.Text)) ||
                (string.IsNullOrEmpty(userNameEntry.Text)) || (string.IsNullOrEmpty(emailEntry.Text)) ||
                (string.IsNullOrEmpty(passwordEntry.Text)) || (string.IsNullOrEmpty(rol.Text)))

            {
                await DisplayAlert("Introducir datos", "Ingrese datos válidos", "Aceptar");
            }
            else if (!string.Equals(passwordEntry.Text, confirmpasswordEntry.Text))
            {
                warningLabel.Text = "Ingrese la misma contraseña";
                passwordEntry.Text = string.Empty;
                confirmpasswordEntry.Text = string.Empty;
                warningLabel.TextColor = Color.IndianRed;
                warningLabel.IsVisible = true;
            }
            else
            {
                user.Email = emailEntry.Text;
                user.Name = userNameEntry.Text;
                user.Password = passwordEntry.Text;
                user.Rol = rol.Text;
                try
                {
                    Task<string> retrunvalue = App.Database.AddUser(user);
                    await retrunvalue;
                    string returns = retrunvalue.Result;

                    if ( returns == "Añadido exitosamente")
                    {
                        await DisplayAlert("Agregar usuario", returns, "Aceptar");
                        await Navigation.PushAsync(new LoginPage());
                    }
                    else
                    {
                        await DisplayAlert("Agregar usuario", returns, "Aceptar");
                        warningLabel.IsVisible = false;
                        emailEntry.Text = string.Empty;
                        userNameEntry.Text = string.Empty;
                        passwordEntry.Text = string.Empty;
                        confirmpasswordEntry.Text = string.Empty;
                        rol.Text = string.Empty;
                    }
                }
                catch (Exception ex)
                {
                    Debug.WriteLine(ex);
                }
            }
            //users.name = fullNameEntry.Text;
            //users.userName = userNameEntry.Text;
            //users.password = passwordEntry.Text;
            //users.phone = phoneEntry.Text.ToString();

        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new LoginPage());
        }
    }
}