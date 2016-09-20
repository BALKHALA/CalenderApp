using System;

namespace Calendar
{
    public partial class AddNewEventView : BaseView
    {
        public AddNewEventView()
        {
            InitializeComponent();
        }

        private void OnBackButtonTapped(object sender, EventArgs e)
        {
            Pop();
        }
    }
}
