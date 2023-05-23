using Plugin.Media;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace diamobelt
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class Producto : ContentPage
	{
		public Producto ()
		{
			InitializeComponent ();
            //Image.Source = ImageSource.FromFile("nombre_de_la_imagen.jpg");
        }

        public object Imagen { get; private set; }

        private async void btnTomarFoto_Clicked(object sender, EventArgs e)
        {

			await DisplayAlert("No Camara",":(No  camara available.","Ok");
			return;

            var file = await CrossMedia.Current.TakePhotoAsync(new Plugin.Media.Abstractions.StoreCameraMediaOptions
            {
                Directory = "Sample",
                Name = "test.png",
                SaveToAlbum = true,
                CompressionQuality = 75,
                CustomPhotoSize = 50,
                PhotoSize = Plugin.Media.Abstractions.PhotoSize.MaxWidthHeight,
                MaxWidthHeight = 2000,
                DefaultCamera = Plugin.Media.Abstractions.CameraDevice.Front
            }) ;
            if (file == null)
                return;

            await DisplayAlert("File Location",file.Path,"Ok");

            /*Imagen.Source = ImageSource.FromStream(() =>
            {
                var stream = file.GetStream();
                return stream;

            });*/
        }
    }
}