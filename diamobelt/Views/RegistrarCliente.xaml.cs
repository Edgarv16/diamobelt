using diamobelt.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace diamobelt.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RegistrarCliente : ContentPage
    {
        public RegistrarCliente()
        {
            InitializeComponent();
            NavigationPage.SetHasBackButton(this, false);
        }
        public RegistrarCliente(Clientes client)
        {
            InitializeComponent();
            txtNumeroIdentificacion.Text = client.cedula.ToString();
            txtApellidosNombre.Text = client.nombresApellidos.ToString();
            txtCelular.Text = client.telefono.ToString();
            txtEmail.Text = client.correo.ToString();
            txtDireccion.Text= client.direccion.ToString();
            NavigationPage.SetHasBackButton(this, false);

        }

        private void btnEliminar_Clicked(object sender, EventArgs e)
        {
            try
            {
                WebClient cliente = new WebClient();
                var parametros = new System.Collections.Specialized.NameValueCollection();
                byte[] res = cliente.UploadValues("http://192.168.5.10/diamobelt/Clientes.php?cedula=" + txtNumeroIdentificacion.Text, "DELETE", parametros);
                var r = System.Text.ASCIIEncoding.UTF8.GetString(res);
                DisplayAlert("Mensaje de éxito", "Dato Eliminado", "Cerrar");
                Navigation.PushAsync(new ListaClientes());
            }
            catch (Exception ex)
            {
                DisplayAlert("Error", ex.Message, "Cerrar");
            }

        }

        private void btnActualizar_Clicked(object sender, EventArgs e)
        {
            try
            {
                WebClient cliente = new WebClient();
                var parametros = new System.Collections.Specialized.NameValueCollection();
                cliente.UploadValues("http://192.168.5.10/diamobelt/Clientes.php?cedula=" + txtNumeroIdentificacion.Text + "&nombresApellidos=" + txtApellidosNombre.Text + "&telefono=" + txtCelular.Text + "&correo=" + txtEmail.Text + "&direccion=" + txtDireccion.Text + "&estado=" + "1", "PUT", parametros);
                DisplayAlert("Mensaje de éxito", "Dato Actualizado con éxito", "Cerrar");
                Navigation.PushAsync(new ListaClientes());
            }
            catch (Exception ex)
            {
                DisplayAlert("Error", ex.Message, "Cerrar");
            }
        }

        private void btnRegresar_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new Views.ListaClientes());
        }

        private void btnGuardar_Clicked(object sender, EventArgs e)
        {
            try
            {
                WebClient cliente = new WebClient();
                var parametros = new System.Collections.Specialized.NameValueCollection();
                parametros.Add("cedula", txtNumeroIdentificacion.Text);
                parametros.Add("nombresApellidos", txtApellidosNombre.Text);
                parametros.Add("telefono", txtCelular.Text);
                parametros.Add("correo", txtEmail.Text);
                parametros.Add("direccion", txtDireccion.Text);
                parametros.Add("estado", "1");
                cliente.UploadValues("http://192.168.5.10/diamobelt/Clientes.php", "POST", parametros);
                DisplayAlert("Alerta", "Cliente Registrado con éxito", "Salir");
                Navigation.PushAsync(new Views.RegistrarCliente());
                txtNumeroIdentificacion.Text = "";
                txtApellidosNombre.Text = "";
                txtCelular.Text = "";
                txtEmail.Text = "";
                txtDireccion.Text = "";

            }
            catch (Exception ex)
            {
                DisplayAlert("Información: ", ex.Message, "Cerrar");
            }
        }
    }
}