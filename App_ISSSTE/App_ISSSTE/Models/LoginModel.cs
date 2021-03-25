using App_ISSSTE.Models;
using App_ISSSTE.Pages;
using App_ISSSTE.Service;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace App_ISSSTE
{
    public class LoginModel : BaseModel
    {
       
        public string Username { get; set; }
        public string Password { get; set; }

        private bool _isRefreshing;

        private bool _isBusy;

        public bool IsRefreshing
        {
            get => _isRefreshing;
            set { _isRefreshing = value; OnPropertyChanged(); }
        }

        public ICommand RefreshCommand { private set; get; }

        public LoginModel()
        {
            //.. constructor - code omitted
            IsRemembered = true;
            IsEnabled = true;
            
           
        }

        // methods - code omitted

     

        public bool IsBusy
        {
            get => _isBusy;
            set
            {
                _isBusy = value;
                OnPropertyChanged();
            }
        }


        public ICommand LoginCommand
        {
            get
            {
                return new RelayCommand(Login);
            }
        }
        #region Attributes
        private string contrasena;
        private bool isRunning;
        private bool isEnabled;
        private string usuario;

        #endregion

        #region Properties
        public string Usuario
        {
            get { return usuario; }
            set { SetValue(ref usuario, value); }
        }
        public string Contrasena
        {
            get { return contrasena; }
            set { SetValue(ref contrasena, value); }
        }
        public bool IsRunning
        {
            get { return isRunning; }
            set { SetValue(ref isRunning, value); }
        }
        public bool IsRemembered
        {
            get;
            set;
        }

        public bool IsEnabled
        {
            get { return isEnabled; }
            set { SetValue(ref isEnabled, value); }
        }
        #endregion

        #region Commands

        public async void Login()
        {
            await Application.Current.MainPage.Navigation.PushModalAsync(new MenuPage(), false);

        }
        #endregion
    }

}
