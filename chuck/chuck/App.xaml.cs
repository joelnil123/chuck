using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using chuck.Services;
using chuck.Mocks;

namespace chuck
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            DependencyService.Register<IApiServices, ApiServices>();
            //DependencyService.Register<IApiServices, ApiServiceMock>();
            MainPage = new NavigationPage(new MainPage());
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
