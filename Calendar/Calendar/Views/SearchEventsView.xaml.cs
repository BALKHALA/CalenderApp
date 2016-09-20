using System;
using System.Collections.ObjectModel;
using Calendar.ViewModel;
using Xamarin.Forms;

namespace Calendar
{
    public partial class SearchEventsView : BaseView
    {
        public ObservableCollection<EventsViewModel> eventslisting { get; set; }

        public SearchEventsView()
        {
            InitializeComponent();

            eventslisting = new ObservableCollection<EventsViewModel>();
            for (int i = 0; i < 50; i++)
            {
                if (i % 1 == 0)
                {
                    eventslisting.Add(new EventsViewModel { Name = "Pay bills online", RowColor = Color.FromHex("#f44336") });
                }

                eventslisting.Add(new EventsViewModel { Name = "Pay bills online", RowColor = Color.FromHex("#2196F3") });
            }
            lstView.ItemsSource = eventslisting;
        }

        private void OnBackButtonTapped(object sender, EventArgs e)
        {
            Pop();
        }

        private void OnSearchButtonTapped(object sender, EventArgs e)
        {
            lstView.IsVisible = true;
        }
    }
}
