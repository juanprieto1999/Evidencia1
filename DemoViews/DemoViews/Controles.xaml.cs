using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace DemoViews
{
    public partial class Controles : ContentPage
    {
        void Handle_Toggled(object sender, Xamarin.Forms.ToggledEventArgs e)
        {
            var estado = this.swEstado.IsToggled;
            if (this.swEstado.IsToggled)
            {
                DisplayAlert("Switch", "Estoy Encendido", "Aceptar");
            }
            else
            {
                DisplayAlert(
                    "Switch",
                    "Estoy Apagado",
                    "Aceptar");
            }
        }

    


    void Handle_ValueChanged(object sender, Xamarin.Forms.ValueChangedEventArgs e)
    {
        labCambio.Text = slider.Value.ToString();
    }

    void Handle_TextChanged(object sender, Xamarin.Forms.TextChangedEventArgs e)
    {
        DisplayAlert("Buscando", "Buscando Resultados", "Aceptar");
    }

    void Handle_SearchButtonPressed(object sender, System.EventArgs e)
    {
        DisplayAlert("Cambiando", "Este texto esta cambiando", "Aceptar");
    }

    public Controles()
    {
        InitializeComponent();

    }
    void Deportivo_SelectedIndexChange(Object sender, EventArgs e)
    {
        var elementoseleccionado = Deportivo.SelectedItem.ToString();
        DisplayAlert("Conduciras un", elementoseleccionado, "Vamos!");


    }
    void btnSimular_Clicked(Object sender, EventArgs e)
    {
        var progreso = progressNum.Progress;
        if (progreso == 1)
        {
            progressNum.ProgressTo(.1, 250, Easing.SpringOut);

        }
        else
        {
            progressNum.ProgressTo(1, 300, Easing.Linear);

        }

    }
    void stepEvent(object sender, Xamarin.Forms.ValueChangedEventArgs e)
    {
        lbDisplay.Text = steeper.Value.ToString();


    }

}
}
