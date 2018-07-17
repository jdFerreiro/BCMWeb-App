using BCMWeb.Models;
using BCMWeb.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace BCMWeb.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class LoginPage : ContentPage
	{
		public LoginPage ()
		{
			InitializeComponent ();
            NavigationPage.SetHasNavigationBar(this, false);
            switch (Device.RuntimePlatform)
            {
                case Device.iOS:
                    break;
                case Device.Android:
                    break;
                case Device.UWP:
                    break;
            }
            this.lblErrorCodigo.Text = string.Empty;
            this.lblErrorGeneral.Text = string.Empty;
            this.lblErrorPassw.Text = string.Empty;
            this.entCodigo.Text = string.Empty;
            this.entPasw.Text = string.Empty;
            this.btnClear.Clicked += BtnClear_Clicked;
            this.btnLogin.Clicked += BtnLogin_Clicked;
            this.entCodigo.Completed += EntCodigo_Completed;
            this.entPasw.Completed += EntPasw_Completed;
        }
        private void EntPasw_Completed(object sender, EventArgs e)
        {
            this.btnLogin.Focus();
        }
        private void EntCodigo_Completed(object sender, EventArgs e)
        {
            this.entPasw.Focus();
        }
        private void BtnClear_Clicked(object sender, EventArgs e)
        {
            this.entCodigo.Text = string.Empty;
            this.entPasw.Text = string.Empty;
            this.lblErrorCodigo.Text = string.Empty;
            this.lblErrorGeneral.Text = string.Empty;
            this.lblErrorPassw.Text = string.Empty;
        }
        private async void BtnLogin_Clicked(object sender, EventArgs e)
        {
            bool _hasError = false;
            IsBusy = true;

            if (string.IsNullOrEmpty(this.entCodigo.Text))
            {
                lblErrorCodigo.Text = "Debe indicar su código de usuario";
                _hasError = true;
            }
            if (string.IsNullOrEmpty(this.entPasw.Text))
            {
                lblErrorPassw.Text = "Debe indicar su contraseña";
                _hasError = true;
            }

            if (_hasError)
            {
                IsBusy = false;
                return;
            }

            TokenModel _token = await DataService.GetToken(entCodigo.Text, entPasw.Text);
            if (!string.IsNullOrEmpty(_token.ErrorMessage))
            {
                if (_token.ErrorMessage.ToLowerInvariant().Contains("task"))
                {
                    lblErrorGeneral.Text = "Tiempo de espera excedido. Verifique su conexión a internet e intente de  n";
                    IsBusy = false;
                    return;
                }
            }

            string _url = "api/Usuario/GetByCredentials/" + entCodigo.Text.Trim() + "/" + entPasw.Text.Trim();
            UsuarioModel _usuarioModel = await DataService.GetDataUsuario(_url, _token.AccessToken);

            await this.Navigation.PopAsync();
            await this.Navigation.PushAsync(new )
        }
    }
}