using Xamarin.Forms;

namespace Calendar
{
    public class App : Application
    {
        private NavigationPage appNavigation;

        public App()
        {
            CurrentApp = this;
            // The root page of your application
            SetNavigationPage();
            MainPage = appNavigation;
        }

        public static App CurrentApp { get; set; }

        private void SetNavigationPage()
        {
            appNavigation = GetNavigationPage(new CalendarPageView());
            MainPage = appNavigation;
            return;
        }

        private NavigationPage GetNavigationPage(Page view)
        {
            var navigation = new NavigationPage(view);
            Device.OnPlatform(iOS: () =>
            {
                navigation.BarTextColor = Color.FromHex("#2196F3");
            });

            return navigation;
        }
    }
}
