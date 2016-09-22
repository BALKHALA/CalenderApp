using System;
using Xamarin.Forms;

namespace Calendar
{
    public partial class CalendarPageView : BaseView,IDeleteEvent
    {
        EventsDb eventsDb;

        public CalendarPageView()
        {
            InitializeComponent();
            eventsDb = new EventsDb();
            EventsViewCell.delete = this;
        }

        private void OnSearchButtonTapped(object sender, EventArgs e)
        {
            Push(new SearchEventsView());
        }

        private void OnAddNewTapped(object sender, EventArgs e)
        {
            Push(new AddNewEventView());
        }

        public async void DeleteEvent(int Id)
        {
            var answer = await DisplayAlert("Delete Event", "Are you sure you want to delete event?", "Yes", "No");

            if (answer)
            {
                string date = eventsDb.Get(Id).Date;
                eventsDb.Delete(Id);
                lstView.ItemsSource = eventsDb.GetEventsByDate(date);
            }
        }

        private void OnDateSelected(object sender, DateTime e)
        {
            lstView.ItemsSource = eventsDb.GetEventsByDate(e.Date.ToString("d"));
        }

        private async void OnEventRowTapped(object sender, ItemTappedEventArgs e)
        {
            await AwaitedPush(new EventDetailsView((CalendarEvents)e.Item));
        }
    }
}

