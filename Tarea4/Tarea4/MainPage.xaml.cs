using Plugin.Media;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Tarea4.Models;

namespace Tarea4
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        byte[] imageToSave;

        private async void btnFoto_Clicked(object sender, EventArgs e)
        {

            var takepic = await CrossMedia.Current.TakePhotoAsync(new Plugin.Media.Abstractions.StoreCameraMediaOptions
            {
                Directory = "PhotoApp",
                Name = DateTime.Now.ToString() + "_foto.jpg",
                SaveToAlbum = true
            });

            await DisplayAlert("Ubicacion de la foto: ", takepic.Path, "Ok");

            if (takepic != null)
            {
                imageToSave = null;
                MemoryStream memoryStream = new MemoryStream();

                takepic.GetStream().CopyTo(memoryStream);
                imageToSave = memoryStream.ToArray();

                img.Source = ImageSource.FromStream(() => { return takepic.GetStream(); });
            }
        }

        private async void btnSQlite_Clicked(object sender, EventArgs e)
        {
            var empleado = new Informacion
            {
                nombres = txtnombre.Text,
                descripcion = txtdescripcion.Text,
                imagen = imageToSave
            };

            var resultado = await App.BaseDatos.EmpleSave(empleado);

            if (resultado != 0)
            {
                await DisplayAlert("Aviso", "Informacion Ingresada con Exito!!!", "Ok");
            }
            else
            {
                await DisplayAlert("Aviso", "Ha Ocurrido un Error", "Ok");
            }


            await Navigation.PopAsync();
        }


        private byte[] GetImageBytes(Stream stream)
        {
            byte[] ImageBytes;
            using (var memoryStream = new System.IO.MemoryStream())
            {
                stream.CopyTo(memoryStream);
                ImageBytes = memoryStream.ToArray();
            }
            return ImageBytes;
        }




    }




}

   
