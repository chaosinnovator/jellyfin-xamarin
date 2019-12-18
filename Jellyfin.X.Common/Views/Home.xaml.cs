using MediaBrowser.Model.Session;
using System.Linq;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Jellyfin.X.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Home : ContentPage
    {
        public Home()
        {
            InitializeComponent();

            DoApiTest();
        }

        public async void DoApiTest()
        {
            var capabilities = new ClientCapabilities();

            await App.State.Client.ReportCapabilities(capabilities);

            App.State.Client.RemoteLoggedOut += OnClientRemoteLoggedOut; ;

            var items = await App.State.Client.GetItemsAsync(new ApiClient.Model.ItemQuery
            {
                UserId = App.State.Client.CurrentUserId,

                SortBy = new[] { MediaBrowser.Model.Querying.ItemSortBy.DateCreated },
                SortOrder = MediaBrowser.Model.Entities.SortOrder.Descending,

                Filters = new[] { MediaBrowser.Model.Querying.ItemFilter.IsNotFolder },

                Limit = 10,

                Recursive = true
            });

            TestText.Text = "Got up to 10 items: " + string.Join(",", items.Items.Select(o => o.Name));
        }

        private void OnClientRemoteLoggedOut(object sender, MediaBrowser.Model.Events.GenericEventArgs<ApiClient.Model.RemoteLogoutReason> e)
        {
            App.Current.MainPage = new Views.Login();
        }
    }
}