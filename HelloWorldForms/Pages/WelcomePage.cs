using Xamarin.Forms;
using System;
using HelloWorldForms.Pages;
using HelloWorldForms.Helpers;
using Newtonsoft.Json;
using HelloWorldForms.Models;

namespace HelloWorldForms
{
    public partial class WelcomePage : ContentPage
    {

        private WelcomePage Instance;
        public WelcomePage()
        {
            NavigationPage.SetHasNavigationBar(this, false);
            InitializeComponent();

            usernameEntry.ReturnKeyType = CustomEntry.ReturnKeyTypes.Next;
            passwordEntry.ReturnKeyType = CustomEntry.ReturnKeyTypes.Done;

            usernameEntry.Completed += (sender, e) =>
            {
                passwordEntry.Focus();
            };

            Instance = this;

            var tapGestureRecognizer = new TapGestureRecognizer();
            tapGestureRecognizer.Tapped += (sender, e) =>
            {
                Navigation.PushAsync(new SignUpPage());
            };

            signUpLabel.GestureRecognizers.Add(tapGestureRecognizer);

        }

        async void Handle_Signin_Clicked(object sender, System.EventArgs e)
        {
            if(isValidData()){
                Settings.UserLoggedInStatus = true;
                await Navigation.PushAsync(new SelectFranchizsePage());
				usernameEntry.Text = "";
				passwordEntry.Text = "";
                Navigation.RemovePage(this);
            }
        }

        async void Handle_Skip_Clicked(object sender, System.EventArgs e)
        {
            await Navigation.PushAsync(new SelectFranchizsePage());
			usernameEntry.Text = "";
			passwordEntry.Text = "";
        }

        private bool isValidData()
        {
            SignupModel signUpModel = JsonConvert.DeserializeObject<SignupModel>(Settings.UserSignUpData);
            string username = usernameEntry.Text;
            string password = passwordEntry.Text;

            if (signUpModel == null)
            {
                DisplayAlert("Error!", "User doesnot exist", "OK");
                return false;
            }
            else
            {
                if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
                {
                    DisplayAlert("Error!", "Please enter username and password", "OK");
                    return false;
                }
                else if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
                {
                    DisplayAlert("Error!", "Please enter username and password", "OK");
                    return false;
                }
                else if (!username.Equals(signUpModel.username) && !password.Equals(signUpModel.password))
                {
                    DisplayAlert("Error!", "Please enter correct username and password", "OK");
                    return false;
                }
                else
                {
                    return true;
                }
            }
        }
    }
}
