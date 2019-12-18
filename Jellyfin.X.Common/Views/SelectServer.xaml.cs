using Jellyfin.ApiClient.Model;
using Jellyfin.X.Helpers;
using Jellyfin.X.Models;
using Jellyfin.X.ViewModels;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Jellyfin.X.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    [DesignTimeVisible(true)]
    public partial class SelectServer : ContentView
    {
        ItemCardsRowViewModel RowViewModel;
        public SelectServer()
        {
            InitializeComponent();

            RowViewModel = new ItemCardsRowViewModel();

            DoTest();
        }

        public async void DoTest()
        {
            var psi = await MainPage.client.GetPublicSystemInfoAsync();
            serverCollection.ViewModel.Cards.Add(new ItemCard()
            {
                Title = psi.ServerName,
                Detail = psi.LocalAddress,
                BaseColor = SolidColorProvider.NextRandomColor,
                BaseTextColor = SolidColorProvider.ThisColorAccent,
                BorderColor = Color.Transparent,
            });
        }

        private void AddServerButton_Clicked(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }
    }
}