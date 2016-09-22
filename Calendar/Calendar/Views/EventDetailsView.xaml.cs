using System;
using Calendar.ViewModel;

namespace Calendar
{
    public partial class EventDetailsView : BaseView
    {
        private int rowCount = 0;
        private EventsDb eventsDb;
        
        private EventsDetailsViewModel eventsDetailsViewModel;

        public EventDetailsView(CalendarEvents _calendarEvents)
        {
            InitializeComponent();
            eventsDetailsViewModel = new  EventsDetailsViewModel(_calendarEvents);
            BindingContext = eventsDetailsViewModel;
            eventsDb = new EventsDb();
        }

        private void OnBackButtonTapped(object sender, EventArgs e)
        {
            Pop();
        }

       private void OnUpdateClicked(object sender, EventArgs e)
        {
            eventsDb.Update(eventsDetailsViewModel.calendarEvents);
        }
    }
}
