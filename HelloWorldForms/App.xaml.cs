using Xamarin.Forms;
using HelloWorldForms.Helpers;
using HelloWorldForms.Pages;
using DLToolkit.Forms.Controls;

namespace HelloWorldForms
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            FlowListView.Init(); 

            if(!Settings.UserLoggedInStatus){
                MainPage = new NavigationPage(new WelcomePage());    
            }else{
                MainPage = new NavigationPage(new SelectFranchizsePage());    
            }
			MainPage.SetValue(NavigationPage.BarBackgroundColorProperty, Color.LightGray);
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
