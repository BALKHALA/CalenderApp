
using Xamarin.Forms;

namespace Calendar
{
    public partial class TPEntry : Entry
    {
       
        public TPEntry()
        {
            InitializeComponent();
            this.TextColor = Color.FromHex("#333333");
            this.PlaceholderColor = Color.FromHex("#666666");
        }
    }
}

