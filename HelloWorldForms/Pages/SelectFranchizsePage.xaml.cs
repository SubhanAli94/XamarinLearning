using Xamarin.Forms;
using System;
using HelloWorldForms.Helpers;

namespace HelloWorldForms.Pages
{
    public partial class SelectFranchizsePage : ContentPage
    {
        public SelectFranchizsePage()
        {
            NavigationPage.SetHasNavigationBar(this, false);
            InitializeComponent();

            var tapGestureRecognizer = new TapGestureRecognizer();
            tapGestureRecognizer.Tapped += (sender, e) =>
            {
                Navigation.PushAsync(new HomePage());
            };

            listStack.GestureRecognizers.Add(tapGestureRecognizer);
            mapStack.GestureRecognizers.Add(tapGestureRecognizer);
        }
    }
}
