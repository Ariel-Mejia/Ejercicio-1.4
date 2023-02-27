using System;
using Tarea4.Controllers;
using Tarea4.Views;
using System.IO;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Tarea4
{
    public partial class App : Application
    {
        static DBInformacion basedatos;
        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new ListaInformacion());
        }
        public static DBInformacion BaseDatos
        {
            get
            {
                if (basedatos == null)
                {
                    basedatos = new DBInformacion(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "EmpleadosDB.db3"));
                }
                return basedatos;
            }
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
