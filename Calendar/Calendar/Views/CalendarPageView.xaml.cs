using System;
using System.Collections.ObjectModel;
using Calendar.ViewModel;
using Xamarin.Forms;

namespace Calendar
{
    public partial class CalendarPageView : BaseView
    {
        public ObservableCollection<EventsViewModel> eventslisting { get; set; }

        public CalendarPageView()
        {
            ShowNavigationBar(false);

            InitializeComponent();

            eventslisting = new ObservableCollection<EventsViewModel>();
            eventslisting.Add(new EventsViewModel {Name = "Pay bills online", RowColor = Color.FromHex("#f44336"), Image = "delete"});
            eventslisting.Add(new EventsViewModel {Name = "Meeting with John", RowColor = Color.FromHex("#2196F3"), Image = "delete" });
            eventslisting.Add(new EventsViewModel {Name = "Book vacation", RowColor = Color.FromHex("#f44336"), Image = "delete" });
            eventslisting.Add(new EventsViewModel {Name = "Book vacation", RowColor = Color.FromHex("#2196F3"), Image = "delete" });
            eventslisting.Add(new EventsViewModel {Name = "Book vacation", RowColor = Color.FromHex("#f44336"), Image = "delete" });
            eventslisting.Add(new EventsViewModel {Name = "Book vacation", RowColor = Color.FromHex("#2196F3"), Image = "delete" });
            eventslisting.Add(new EventsViewModel {Name = "Book vacation", RowColor = Color.FromHex("#f44336"), Image = "delete" });
            eventslisting.Add(new EventsViewModel {Name = "Book vacation", RowColor = Color.FromHex("#2196F3"), Image = "delete" });
            eventslisting.Add(new EventsViewModel {Name = "Book vacation", RowColor = Color.FromHex("#f44336"), Image = "delete" });
            lstView.ItemsSource = eventslisting;
        }

        private void OnSearchButtonTapped(object sender, EventArgs e)
        {
            Push(new SearchEventsView());
        }

        private void OnAddNewTapped(object sender, EventArgs e)
        {
            Push(new AddNewEventView());
        }
    }
}

