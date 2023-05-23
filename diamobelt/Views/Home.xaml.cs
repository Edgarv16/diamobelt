using diamobelt.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace diamobelt.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Home : ContentPage
    {
        private const string Url = "http://192.168.5.10/diamobelt/Pedidos.php";
        private readonly HttpClient cliente = new HttpClient();
        private ObservableCollection<Pedidos> post;
        public Home()
        {
            InitializeComponent();
            Obtener();
        }

        public async void Obtener()
        {
            var content = await cliente.GetStringAsync(Url);
            List<Pedidos> posts = JsonConvert.DeserializeObject<List<Pedidos>>(content);
            post = new ObservableCollection<Pedidos>(posts);
            ListaPedidos.ItemsSource = post;
        }

        private void btn_Clientes_Clicked(object sender, EventArgs e)
        {

        }

        private void btn_Productos_Clicked(object sender, EventArgs e)
        {

        }

        private void btnUsuarios_Clicked(object sender, EventArgs e)
        {

        }

        private void btnProductos_Clicked(object sender, EventArgs e)
        {

        }

        private void btnClientes_Clicked(object sender, EventArgs e)
        {

        }

        private void ListaPedidos_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {

        }
    }
}