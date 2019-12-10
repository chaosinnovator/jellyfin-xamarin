using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Jellyfin.X
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();

            DoApiTest();
        }

        public async void DoApiTest()
        {
            string serverAddress = "http://localhost:8096";

            var logger = new MediaBrowser.Model.Logging.NullLogger();

            var capabilities = new MediaBrowser.Model.Session.ClientCapabilities();

            var device = new Jellyfin.ApiClient.Device
            {
                DeviceName = "Xamarin Client Test",
                DeviceId = "Xamarin Client ID"
            };

            var cryptoProvider = new Jellyfin.ApiClient.Cryptography.CryptographyProvider();

            var client = new Jellyfin.ApiClient.ApiClient(logger, serverAddress, "Xamarin Client Name", device, "Test version", cryptoProvider);

            var authResult = await client.AuthenticateUserAsync("user", "pass");

            await client.ReportCapabilities(capabilities);

            client.RemoteLoggedOut += Client_RemoteLoggedOut;

            MediaBrowser.Model.Querying.QueryResult<MediaBrowser.Model.Dto.BaseItemDto> items = await client.GetItemsAsync(new ApiClient.Model.ItemQuery
            {
                UserId = client.CurrentUserId,

                SortBy = new[] { MediaBrowser.Model.Querying.ItemSortBy.DateCreated },
                SortOrder = MediaBrowser.Model.Entities.SortOrder.Descending,

                Filters = new[] { MediaBrowser.Model.Querying.ItemFilter.IsNotFolder },

                Limit = 10,

                Recursive = true
            });

            System.Diagnostics.Debug.WriteLine(authResult.User);

            MediaBrowser.Model.Dto.BaseItemDto firstItem = items.Items.FirstOrDefault();
            System.Diagnostics.Debug.WriteLine(firstItem.Name);
        }

        private void Client_RemoteLoggedOut(object sender, MediaBrowser.Model.Events.GenericEventArgs<ApiClient.Model.RemoteLogoutReason> e)
        {
            throw new NotImplementedException();
        }
    }
}
