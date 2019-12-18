using Jellyfin.X.Helpers;
using Jellyfin.X.Models;
using Jellyfin.X.ViewModels;
using MediaBrowser.Model.Net;
using System;
using MediaBrowser.Controller.Authentication;
using MediaBrowser.Model.Events;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Jellyfin.X.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Login : ContentPage
    {
        ItemCardsRowViewModel RowViewModel;
        public Login()
        {
            InitializeComponent();

            RowViewModel = new ItemCardsRowViewModel();

            App.State.Client.OnAuthenticated += OnClientAuthenticated;

            CheckPublicUsers();
        }

        private void OnClientAuthenticated(object sender, GenericEventArgs<AuthenticationResult> e)
        {
            App.Current.MainPage = new Views.Home();
        }

        private async void CheckPublicUsers()
        {
            var publicUsers = await App.State.Client.GetPublicUsersAsync();

            if (publicUsers.Length > 0)
            {
                usersView.IsVisible = true;
                cancelButton.IsVisible = true;
            }
            else
            {
                manualLoginView.IsVisible = true;
            }

            foreach (var user in publicUsers)
            {
                var imgUrl = App.State.Client.GetUserImageUrl(user, new MediaBrowser.Model.Dto.ImageOptions
                {
                    Width = 300,
                    Quality = 90,
                });
                userCollection.ViewModel.Cards.Add(new ItemCard()
                {
                    BaseColor = SolidColorProvider.NextRandomColor,
                    BaseTextColor = SolidColorProvider.ThisColorAccent,
                    ImageSourceUri = imgUrl,
                    Title = user.Name,
                    Width = 200,
                    AspectRatio = AspectRatio.Square,
                });
            }
        }

        private void ManualButton_Clicked(object sender, EventArgs e)
        {
            usersView.IsVisible = false;
            manualLoginView.IsVisible = true;
        }

        private async void SignInButton_Clicked(object sender, EventArgs e)
        {
            // TODO: display loading icon here
            try
            {
                var authResult = await App.State.Client.AuthenticateUserAsync(usernameEntry.Text, passwordEntry.Text);
            }
            catch (HttpException)
            {
                // TODO: Failed, show fail message
                return;
            }
        }

        private void CancelButton_Clicked(object sender, EventArgs e)
        {
            manualLoginView.IsVisible = false;
            usersView.IsVisible = true;
        }

        private void ForgotButton_Clicked(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }
    }
}