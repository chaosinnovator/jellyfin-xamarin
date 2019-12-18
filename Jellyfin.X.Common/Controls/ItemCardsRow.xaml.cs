using Jellyfin.X.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Jellyfin.X.Controls
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ItemCardsRow : Grid
    {
        public static readonly BindableProperty RowTitleProperty = BindableProperty.Create(nameof(RowTitle), typeof(string), typeof(ItemCardsRow), default(string), BindingMode.OneWay);
        public string RowTitle
        {
            get
            {
                return (string)GetValue(RowTitleProperty);
            }

            set
            {
                SetValue(RowTitleProperty, value);
            }
        }

        public bool HasRowTitle
        {
            get
            {
                return !string.IsNullOrEmpty(RowTitle);
            }
        }

        public static readonly BindableProperty ScrollControlsVisibleProperty = BindableProperty.Create(nameof(ScrollControlsVisible), typeof(bool), typeof(ItemCardsRow), default(string), BindingMode.OneWay);
        public bool ScrollControlsVisible
        {
            get
            {
                return (bool)GetValue(ScrollControlsVisibleProperty);
            }

            set
            {
                SetValue(ScrollControlsVisibleProperty, value);
            }
        }

        public ItemCardsRowViewModel ViewModel;

        public ItemCardsRow()
        {
            InitializeComponent();

            ViewModel = new ItemCardsRowViewModel();

            cardCollection.ItemsSource = ViewModel.Cards;
        }

        private int firstVisibleItemIndex = 0;
        private int lastVisibleItemIndex = 0;

        private void LeftButton_Clicked(object sender, EventArgs e)
        {
            if (firstVisibleItemIndex == 0)
            {
                return;
            }
            cardCollection.ScrollTo(firstVisibleItemIndex - 1, -1, ScrollToPosition.Start);
        }

        private void RightButton_Clicked(object sender, EventArgs e)
        {
            if (lastVisibleItemIndex == ViewModel.Cards.Count - 1)
            {
                return;
            }
            cardCollection.ScrollTo(lastVisibleItemIndex + 1, -1, ScrollToPosition.Start);
        }

        private void OnUserCollectionScrolled(object sender, ItemsViewScrolledEventArgs e)
        {
            // This doesn't work on UWP at the moment.
            firstVisibleItemIndex = e.FirstVisibleItemIndex;
            lastVisibleItemIndex = e.LastVisibleItemIndex;

            leftButton.IsEnabled = firstVisibleItemIndex > 0;
            rightButton.IsEnabled = lastVisibleItemIndex < ViewModel.Cards.Count - 1;
        }
    }
}