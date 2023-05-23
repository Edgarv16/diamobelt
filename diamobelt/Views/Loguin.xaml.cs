using diamobelt.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http;
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
        private const string BaseUrl = "http://192.168.5.10/diamobelt";
        //private readonly HttpClient user = new HttpClient();
        private ObservableCollection<Usuarios> post;
        public Loguin()
        {
            InitializeComponent();

            
        }

        private async void btnLoguin_Clicked(object sender, EventArgs e)
        {
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    string usuario = txtUsuario.Text;
                    string contrasena = txtClave.Text;

                    string url = $"{BaseUrl}/VerificarUsuario.php?nombre={usuario}";

                    HttpResponseMessage response = await client.GetAsync(url);

                    if (response.IsSuccessStatusCode)
                    {
                        // Si la solicitud es exitosa, verifica la respuesta del servicio web
                        string resultado = await response.Content.ReadAsStringAsync();

                        //await DisplayAlert("Éxito", "Usuario válido", "OK");
                        await Navigation.PushAsync(new Views.Home());

                    }
                    else
                    {
                        // Si la solicitud no es exitosa, maneja el error apropiadamente                      
                        await DisplayAlert("Error", "Usuario inválido", "OK");
                        
                    }
                }

            }
            catch (Exception ex)
            {

                await DisplayAlert("Alerta", ex.Message, "Aceptar");
            }
        }    

        private void imgbotonUbicanos_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new Views.Mapa());


           
        }
    }
}