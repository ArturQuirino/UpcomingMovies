using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using UpcomingMovies.Views;
using Microsoft.Practices.Unity;
using Microsoft.Practices.ServiceLocation;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace UpcomingMovies
{
    public partial class App : Application
    {

        public App()
        {
            BootStrapperIoC.Init();
            InitializeComponent();


            MainPage = new MainPage();
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
