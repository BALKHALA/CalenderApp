using System;
using Xamarin.Forms;

namespace Calendar
{
    public partial class EventsViewCell : StackLayout
    {
        public static IDeleteEvent delete;

        public EventsViewCell()
        {
            InitializeComponent();
        }

        private void OnDeleteClicked(object sender, EventArgs e)
        {
            var item = (Button)sender;
            delete.DeleteEvent((int)item.CommandParameter);
        }
    }
}
