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
            //hide navigation bar
            NavigationPage.SetHasNavigationBar(this, false);
            InitializeComponent();

            //set IME options
            usernameEntry.ReturnKeyType = CustomEntry.ReturnKeyTypes.Next;
            passwordEntry.ReturnKeyType = CustomEntry.ReturnKeyTypes.Done;

            //on done/next pressed transfer focus to next field
            usernameEntry.Completed += (sender, e) =>
            {
                passwordEntry.Focus();
            };

            Instance = this;

            //tap gesture for signup label
            var tapGestureRecognizer = new TapGestureRecognizer();
            tapGestureRecognizer.Tapped += (sender, e) =>
            {
                //start signup page
                Navigation.PushAsync(new SignUpPage());
            };

            signUpLabel.GestureRecognizers.Add(tapGestureRecognizer);

        }

        /**
         * SignIn Click Handler
         * After field validating set user status to login
         * start Franchise location selection page
         * set username and password entry to empty
         * */
        async void Handle_Signin_Clicked(object sender, System.EventArgs e)
        {
            if(isValidData()){

                //set login status
                Settings.UserLoggedInStatus = true;

                //start Frenchise selection page
                await Navigation.PushAsync(new SelectFranchizsePage());

                //set field data to empty
				usernameEntry.Text = "";
				passwordEntry.Text = "";

                //remove current page from back stack to avoid navigation back to login page after successful login
                Navigation.RemovePage(this);
            }
        }

        /*
         * Skip Click Handler
         * Start frenchise selection page
         * set fields data to empty
         */
        async void Handle_Skip_Clicked(object sender, System.EventArgs e)
        {
            //start fields navigation page
            await Navigation.PushAsync(new SelectFranchizsePage());

            //se fields data to empty
			usernameEntry.Text = "";
			passwordEntry.Text = "";
        }

        /*
         * Validate form data and show alert
         * 
         * Take data form fields and validate if it is not empty or null or whitespace and show warning alert 
         * accordingly
         * 
         * Check if field data matches with the existing one in local stoareg
         * 
         */
        private bool isValidData()
        {
            //Fetching signup model from storage
            SignupModel signUpModel = JsonConvert.DeserializeObject<SignupModel>(Settings.UserSignUpData);

            //taking data form fields
            string username = usernameEntry.Text;
            string password = passwordEntry.Text;

            //checking signup model's nullability
            if (signUpModel == null)
            {
                //show alert if model is null
                DisplayAlert("Error!", "User doesnot exist", "OK");
                return false;
            }
            else
            {
                //check if fields data is null or empty
                if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
                {
                    //show alert dialog
                    DisplayAlert("Error!", "Please enter username and password", "OK");
                    return false;
                }

                //check if fields daata is null or comprising of empty space
                else if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
                {
                    //show alert
                    DisplayAlert("Error!", "Please enter username and password", "OK");
                    return false;
                }

                //check if fields data matches with data from storage
                else if (!username.Equals(signUpModel.username) && !password.Equals(signUpModel.password))
                {
                    //show alert
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
