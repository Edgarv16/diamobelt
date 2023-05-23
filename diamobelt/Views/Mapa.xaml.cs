using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.GoogleMaps;
using Xamarin.Forms.Xaml;

namespace diamobelt.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Mapa : ContentPage
    {
        public Mapa()
        {
            InitializeComponent();
            Pin MiUbi = new Pin()
            {
                Type = PinType.Place,
                Label = "Fabrica de Muebles Alexander",
                Address = "Calle 27 de NOviembre y Francisco Teran",
                Position = new Position(0.33469669703401445, -78.16981902586791), // 0.33469669703401445, -78.16981902586791
                Tag = "id_miubi",
            };
            map.Pins.Add(MiUbi);
            map.MoveToRegion(MapSpan.FromCenterAndRadius(MiUbi.Position, Distance.FromMeters(500)));
        }
    }
}