using System;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Calendar
{
    public partial class BaseView : ContentPage
    {
        public BaseView()
        {
            InitializeComponent();
            NavigationPage.SetBackButtonTitle(this, "");
        }

        public View PageContent
        {
            get { return PageContentContainer.Content; }
            set { PageContentContainer.Content = value; }
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            NavigationPage.SetHasBackButton(this, ShouldShowBackButton());
        }

        protected virtual bool ShouldShowBackButton()
        {
            return true;
        }

        protected void ShowNavigationBar(bool value)
        {
            NavigationPage.SetHasNavigationBar(this, value);
        }

        protected void Push(Page page)
        {
            Navigation.PushAsync(page);
        }

        protected async Task AwaitedPush(Page page)
        {
            await Navigation.PushAsync(page);
        }

        protected async Task AwaitedPush(Page page, View sender)
        {
            sender.InputTransparent = true;
            await AwaitedPush(page);
            sender.InputTransparent = false;
        }

        protected async Task AwaitedPush(Page page, Button sender)
        {
            sender.IsEnabled = false;
            await AwaitedPush(page);
            sender.IsEnabled = true;
        }

        protected bool ShouldPop()
        {
            return Navigation.NavigationStack.Count > 1;
        }

        protected void Pop()
        {
            if (ShouldPop())
            {
                this.Navigation.PopAsync();
            }
        }

        protected async Task AwaitedPop()
        {
            if (ShouldPop())
            {
                await Navigation.PopAsync();
            }
        }

        protected async Task AwaitedPop(View sender)
        {
            sender.InputTransparent = true;
            sender.IsEnabled = false;
            await AwaitedPop();
            sender.InputTransparent = false;
            sender.IsEnabled = true;
        }

        //Pops to provided Page Type.
        protected async Task<bool> AwaitedPopToPage(Type pageType)
        {
            int pageOffsetFromCurrent = FindPageOffset(pageType);
            return await AwaitedPopToPageAtOffset(pageOffsetFromCurrent);
        }

        protected async Task<bool> AwaitedPopToPage(Type pageType, View sender)
        {
            sender.InputTransparent = true;
            sender.IsEnabled = false;
            int pageOffsetFromCurrent = FindPageOffset(pageType);
            return await AwaitedPopToPageAtOffset(pageOffsetFromCurrent);
        }

        //Pops to page at provided Offset.
        private async Task<bool> AwaitedPopToPageAtOffset(int pageOffsetFromCurrent)
        {
            if (pageOffsetFromCurrent == 0)
                return false;

            for (var i = pageOffsetFromCurrent; i > 1; i--)
            {
                RemovePageAtOffset(1);
            }
            await AwaitedPop();
            return true;
        }

        //Gets the offset from current page, of provided Page Type. If not found returns 0. 
        private int FindPageOffset(Type pageType)
        {
            int pageOffsetFromCurrent = 0;
            int currentPageIndex = Navigation.NavigationStack.Count - 1;
            for (var index = currentPageIndex - 1; index >= 0; index--)
            {
                if (Navigation.NavigationStack[index].GetType() == pageType)
                {
                    pageOffsetFromCurrent = currentPageIndex - index;
                    break;
                }
            }
            return pageOffsetFromCurrent;
        }

        //Removes page at provided Offset.
        protected void RemovePageAtOffset(int offsetFromCurrent)
        {
            Navigation.RemovePage(
                Navigation.NavigationStack[Navigation.NavigationStack.Count - offsetFromCurrent - 1]);
        }

        private string getPageTitle(Page page)
        {
            return (!string.IsNullOrEmpty(page.Title) ? page.Title : page.GetType().Name);
        }

        public virtual bool OnNavigateBack()
        {
            return true;
        }
    }
}