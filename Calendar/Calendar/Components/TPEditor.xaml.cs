using Xamarin.Forms;

namespace Calendar
{
    public partial class TPEditor : Editor
    {
        public static readonly BindableProperty PlaceholderProperty = BindableProperty.Create("Placeholder", typeof(string), typeof(string), "");

        public string Placeholder
        {
            get { return (string)base.GetValue(PlaceholderProperty); }
            set { base.SetValue(PlaceholderProperty, value); }
        }

        public TPEditor()
        {
            InitializeComponent();
            this.TextColor = Color.FromHex("#333333");
        }

        public void Resize()
        {
            this.InvalidateMeasure();
        }
    }

}

