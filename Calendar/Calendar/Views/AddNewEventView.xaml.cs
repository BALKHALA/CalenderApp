using System;
using System.Linq;

namespace Calendar
{
    public partial class AddNewEventView : BaseView
    {
        private int rowCount = 0;

        public AddNewEventView()
        {
            InitializeComponent();
        }

        private void OnBackButtonTapped(object sender, EventArgs e)
        {
            Pop();
        }

        private void OnAddClicked(object sender, EventArgs e)
        {
            EventsDb eventsDb = new EventsDb();

            CalendarEvents calendarEvents = new CalendarEvents();

            calendarEvents.Id = eventsDb.GetAll().Count() == rowCount ? rowCount : eventsDb.GetAll().Count() + 1;
            calendarEvents.Title = eventTitle.Text.Trim();
            calendarEvents.Date = "20/09/2016";
            calendarEvents.RowColor = "#2196F3";

            eventsDb.Insert(calendarEvents);
        }
    }
}
