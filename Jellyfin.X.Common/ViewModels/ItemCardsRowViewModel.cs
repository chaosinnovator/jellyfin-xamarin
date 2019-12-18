using Jellyfin.X.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace Jellyfin.X.ViewModels
{
    public class ItemCardsRowViewModel : INotifyPropertyChanged
    {
        readonly IList<ItemCard> cardSource;
        ItemCard selectedCard;
        int selectionCount = 1;

        public ObservableCollection<ItemCard> Cards = new ObservableCollection<ItemCard>();
        public IList<ItemCard> EmptyCards { get; private set; }

        public ItemCard SelectedCard
        {
            get
            {
                return selectedCard;
            }
            set
            {
                if (selectedCard != value)
                {
                    selectedCard = value;
                }
            }
        }

        ObservableCollection<object> selectedCards;
        public ObservableCollection<object> SelectedCards
        {
            get
            {
                return selectedCards;
            }
            set
            {
                if (selectedCards != value)
                {
                    selectedCards = value;
                }
            }
        }

        public string SelectedCardMessage { get; private set; }

        public ICommand DeleteCommand => new Command<ItemCard>(RemoveCard);
        public ICommand FilterCommand => new Command<string>(FilterItems);
        public ICommand CardSelectionChangedCommand => new Command(CardSelectionChanged);

        public ItemCardsRowViewModel()
        {
            cardSource = new List<ItemCard>();
        }

        void FilterItems(string filter)
        {
            var filteredItems = cardSource.Where(card => card.Title.ToLower().Contains(filter.ToLower())).ToList();
            foreach (var card in cardSource)
            {
                if (!filteredItems.Contains(card))
                {
                    Cards.Remove(card);
                }
                else
                {
                    if (!Cards.Contains(card))
                    {
                        Cards.Add(card);
                    }
                }
            }
        }

        void CardSelectionChanged()
        {
            SelectedCardMessage = $"Selection {selectionCount}: {SelectedCard.Title}";
            System.Diagnostics.Debug.WriteLine(SelectedCardMessage);
            OnPropertyChanged(nameof(SelectedCardMessage));
            selectionCount++;
        }

        void RemoveCard(ItemCard card)
        {
            if (Cards.Contains(card))
            {
                Cards.Remove(card);
            }
        }

        #region INotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;

        void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion
    }
}
