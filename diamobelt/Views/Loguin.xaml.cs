using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.GoogleMaps;
using Xamarin.Forms.Xaml;

namespace diamobelt
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Loguin : ContentPage
    {
        public Loguin()
        {
            InitializeComponent();

            
        }

        private void btnLoguin_Clicked(object sender, EventArgs e)
        {

        }

        private void imgbotonUbicanos_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new Views.Mapa());


           
        }
    }
}