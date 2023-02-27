using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tarea4.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Tarea4.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ListaInformacion : ContentPage
    {
        public ListaInformacion()
        {
            InitializeComponent();
        }

        private async void ToolbarItem_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new MainPage());
        }

        protected async override void OnAppearing()
        {
            base.OnAppearing();

            listapersonas.ItemsSource = await App.BaseDatos.obtenerListaEmple();
        }


        private async void listapersonas_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            var persona = (Informacion)e.Item;
            VerImagen page = new VerImagen();
            page.BindingContext = persona;
            await Navigation.PushAsync(page);
        }
    }
}
