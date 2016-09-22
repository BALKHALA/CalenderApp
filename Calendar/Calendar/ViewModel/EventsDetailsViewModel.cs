using Xamarin.Forms;

namespace Calendar.ViewModel
{
    public class EventsDetailsViewModel
    {
        public CalendarEvents calendarEvents { get; set; }

        public EventsDetailsViewModel(CalendarEvents _calendarEvents)
        {
            calendarEvents = _calendarEvents;
        }
    }
}
