using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Informacion
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }
        async void Continue_Click(object sender, EventArgs eventArgs)
        {
            if (await ValidarFormulario())
            {
                await DisplayAlert("Exito", "Todos tus campos cumplieron las validaciones", "Ok");

            }


        }
        private async Task<bool> ValidarFormulario()
        {
            //Si el valor en el entry es vacio
            if (String.IsNullOrWhiteSpace(UserName.Text))
            {
                await this.DisplayAlert("Advertencia", "El Campo de nombre es obligatorio", "Ok");
                return false;

            }
            //Valida que solo se ingrese letras
            else if (!UserName.Text.ToCharArray().All(Char.IsLetter))
            {
                await this.DisplayAlert("Advertencia", "Tu informacion contiene numeros", "Ok");
                return false;
            }
            else
            {
                //Valida si se ingresan caracteres especiales
                string caracterEspecial = @"^[^ ][a-zA-Z]+[^ ]$";
                bool resultado = Regex.IsMatch(UserName.Text, caracterEspecial, RegexOptions.IgnoreCase);
                if (!resultado)
                {
                    await this.DisplayAlert("Advertencia", "No se aceptan caracterres especiales", "Intentar de nuevo");
                    return false;
                }

            }
            if (String.IsNullOrWhiteSpace(UserEmail.Text))
            {
                await this.DisplayAlert("Advertencia", "El Campo de Email es obligatorio", "Ok");
                return false;

            }
            else{
                string caracter = @"\A(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?)\Z";
                bool isEmail = Regex.IsMatch(UserEmail.Text, caracter, RegexOptions.IgnoreCase);
                if (!isEmail)
                {
                    await this.DisplayAlert("Advertencia", "El formato del correo electronico es incorrecto", "ok");
                    return false;
                }

            }
           

            if (String.IsNullOrWhiteSpace(UserCelular.Text))
            {
                await this.DisplayAlert("Advertencia", "El Campo de celular es obligatorio", "Ok");
                return false;

            }
            else if (UserCelular.Text.Length != 10)
            {
                await this.DisplayAlert("Advertencia", "El celular debe se de 10 digitos", "Ok");
                return false;

            }
            else
            {
                if (!UserCelular.Text.ToCharArray().All(Char.IsDigit))
                {
                    await this.DisplayAlert("Advertencia", "El formato de celular es incorrecto solo numeros", "Ok");
                    return false;

                }

            }
            return true;
        }

    }
}
