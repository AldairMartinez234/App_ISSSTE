using App_ISSSTE.Models;
using App_ISSSTE.Pages;
using System;
using System.IO;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App_ISSSTE
{
    public partial class App : Application
    {
        static Database database;
        static UserDB userDB;
        public static Database Database
        {
            get
            {
                if (database == null)
                {
                    database = new Database(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "control_issste1.db3"));
                }
                return database;
            }
        }

        public static UserDB UserDB
        {
            get
            {
                if (userDB == null)
                {
                    userDB = new UserDB(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "control_issste1.db3"));
                }
                return userDB;
            }
        }

        public App()
        {
            InitializeComponent();
            
            MainPage = new NavigationPage(new LoginPage());
        }



        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
