using System;

namespace Calendar
{
    public partial class SearchEventsView : BaseView
    {
        private EventsDb eventsDb;

        public SearchEventsView()
        {
            InitializeComponent();
            eventsDb = new EventsDb();
        }

        private void OnBackButtonTapped(object sender, EventArgs e)
        {
            Pop();
        }

        private void OnSearchButtonTapped(object sender, EventArgs e)
        {
            lstView.IsVisible = true;
            SearchData();
        }

        private void SearchData()
        {
            if (searchEntry.Text != null)
            {
                lstView.ItemsSource = eventsDb.GetSearchData(searchEntry.Text.Trim());
            }
        }
    }
}
