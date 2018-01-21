using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace HelloWorldForms.Pages
{
    public partial class FrenchiseSelectionPage : ContentPage
    {
        public FrenchiseSelectionPage()
        {
            NavigationPage.SetHasNavigationBar(this, false);
            InitializeComponent();

            var tapGestureRecognizer = new TapGestureRecognizer();
            tapGestureRecognizer.Tapped += (sender, e) =>
            {
                Navigation.PushAsync(new HomePage());
            };

            imagesa.GestureRecognizers.Add(tapGestureRecognizer);
        }

        void Handle_Clicked(object sender, System.EventArgs e)
        {
            Navigation.PushAsync(new HomePage());
        }
    }
}
