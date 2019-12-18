using Jellyfin.X.Helpers;
using Microsoft.Extensions.Logging.Abstractions;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Jellyfin.X
{
    public partial class App : Application
    {
        public static ApplicationState State;
        public App()
        {
            InitializeComponent();

            Uri serverAddress = new Uri("http://localhost:8096");
            var logger = NullLogger.Instance;
            var device = new ApiClient.Device
            {
                DeviceName = "Xamarin Client Test",
                DeviceId = "Xamarin Client ID"
            };
            State = new ApplicationState
            {
                Client = new ApiClient.ApiClient(logger, serverAddress, "Xamarin Client Name", device, "v0.0.1")
            };

            MainPage = new Views.Login();
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
