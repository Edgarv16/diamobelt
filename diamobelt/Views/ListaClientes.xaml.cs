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
    public partial class ListaClientes : ContentPage
    {
        private const string Url = "http://192.168.5.10/diamobelt/Clientes.php";
        private readonly HttpClient cliente = new HttpClient();
        private ObservableCollection<Clientes> post;
        public ListaClientes()
        {
            InitializeComponent();
            Obtener();
        }

        public async void Obtener()
        {
            var content = await cliente.GetStringAsync(Url);
            List<Clientes> posts = JsonConvert.DeserializeObject<List<Clientes>>(content);
            post = new ObservableCollection<Clientes>(posts);
            ListClient.ItemsSource = post;
        }

        private async void menEliminar_Clicked(object sender, EventArgs e)
        {
        
        }

        private void ListClient_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var obj = (Clientes)e.SelectedItem;

            if (!string.IsNullOrEmpty(obj.cedula.ToString()))
            {
                if (obj != null)
                {

                    Navigation.PushAsync(new RegistrarCliente(obj));
                }

            }
        }

        private void btnNuevoCliente_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new Views.RegistrarCliente());
        }

        private void btnRegresar_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new Views.Home());
        }
    }
}