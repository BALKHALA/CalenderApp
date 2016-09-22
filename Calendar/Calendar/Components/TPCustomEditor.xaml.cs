using PropertyChanged;
using System;
using System.Windows.Input;
using Xamarin.Forms;

namespace Calendar
{
    [ImplementPropertyChanged]
    public partial class TPCustomEditor : StackLayout
    {
        public static readonly BindableProperty PlaceholderProperty = BindableProperty.Create("Placeholder", typeof(String), typeof(String), "");

        public static readonly BindableProperty MaxLengthProperty = BindableProperty.Create("MaxLength", typeof(int), typeof(TPCustomEntry), int.MaxValue);

        public static readonly BindableProperty TextProperty = BindableProperty.Create("Text", typeof(String), typeof(TPCustomEntry), "", BindingMode.TwoWay, null, handleTextChanged);

        private static void handleTextChanged(BindableObject bindable, object oldValue, object newValue)
        {
            if (newValue == null)
                newValue = "";
            ((TPCustomEditor)bindable).OnChange();
        }

        public TPEditor Editor
        {
            get { return editor; }
        }

        public int MaxLength
        {
            get { return (int)base.GetValue(MaxLengthProperty); }
            set { base.SetValue(MaxLengthProperty, value); }
        }

        private void OnChange()
        {
            if (!string.IsNullOrEmpty(Text))
            {
                if (editor.IsFocused)
                {
                    LabelColor = Color.FromHex("#0492d2");
                    UnderlineErrorMessage = Color.FromHex("#0492d2");
                }
                else
                    LabelColor = Color.FromHex("#666666");

            }
            else
            {
                LabelColor = Color.Transparent;
                UnderlineErrorMessage = Color.FromHex("#787a7c");
            }
        }

        public static readonly BindableProperty IconProperty = BindableProperty.Create("Icon", typeof(String), typeof(String), "");

        public static readonly BindableProperty LabelTextProperty = BindableProperty.Create("Text", typeof(String), typeof(TPLabel), "");

        public static readonly BindableProperty LabelColorProperty = BindableProperty.Create("TextColor", typeof(Color), typeof(TPLabel), Color.Transparent);

        public static readonly BindableProperty IsPasswordProperty = BindableProperty.Create("IsPassword", typeof(Boolean), typeof(TPEntry), false);

        public static readonly BindableProperty IsEnableProperty = BindableProperty.Create("IsEnable", typeof(Boolean), typeof(Boolean), true);

        public static readonly BindableProperty UnderlineErrorMessageProperty = BindableProperty.Create("UnderlineErrorMessage", typeof(Color), typeof(BoxView), Color.FromHex("#787a7c"));

        public static readonly BindableProperty ErrorMessageTextColorProperty = BindableProperty.Create("ErrorMessageTextColor", typeof(Color), typeof(TPLabel), Color.Red);

        public static readonly BindableProperty KeyboardProperty = BindableProperty.Create("Keyboard", typeof(Keyboard), typeof(TPEntry), Keyboard.Chat);

        public static readonly BindableProperty PlaceHolderFontSizeProperty = BindableProperty.Create("PlaceHolderTextSize", typeof(int), typeof(TPLabel), 12);

        public static readonly BindableProperty AutoClearOnIconClickProperty = BindableProperty.Create("ShouldClearOnImageClick", typeof(Boolean), typeof(Boolean), false);

        public ICommand ClearFieldValue { get; set; }

        public bool ShouldClearOnImageClick
        {
            get { return (bool)base.GetValue(AutoClearOnIconClickProperty); }
            set { base.SetValue(AutoClearOnIconClickProperty, value); }
        }

        public int PlaceHolderTextSize
        {
            get { return (int)base.GetValue(PlaceHolderFontSizeProperty); }
            set { base.SetValue(PlaceHolderFontSizeProperty, value); }
        }

        public Color PlaceholderColor
        {
            get;
            set;
        }

        public Keyboard Keyboard
        {
            get { return (Keyboard)base.GetValue(KeyboardProperty); }
            set { base.SetValue(KeyboardProperty, value); }
        }

        public Color ErrorMessageTextColor
        {
            get { return (Color)base.GetValue(ErrorMessageTextColorProperty); }
            set { base.SetValue(ErrorMessageTextColorProperty, value); }
        }

        public Color UnderlineErrorMessage
        {
            get { return (Color)base.GetValue(UnderlineErrorMessageProperty); }
            set { base.SetValue(UnderlineErrorMessageProperty, value); }
        }

        public bool IsPassword
        {
            get { return (Boolean)base.GetValue(IsPasswordProperty); }
            set { base.SetValue(IsPasswordProperty, value); }
        }

        public bool IsEnable
        {
            get { return (Boolean)base.GetValue(IsEnableProperty); }
            set { base.SetValue(IsEnableProperty, value); }
        }

        public Color LabelColor
        {
            get { return (Color)base.GetValue(LabelColorProperty); }
            set { base.SetValue(LabelColorProperty, value); }
        }

        public String LabelText
        {
            get { return (String)base.GetValue(LabelTextProperty); }
            set { base.SetValue(LabelTextProperty, value); }
        }

      
        public String Placeholder
        {
            get { return (String)base.GetValue(PlaceholderProperty); }
            set { base.SetValue(PlaceholderProperty, value); }
        }

        public String Text
        {
            get { return (String)base.GetValue(TextProperty); }
            set { base.SetValue(TextProperty, value); }
        }

        public String Icon
        {
            get { return (String)base.GetValue(IconProperty); }
            set { base.SetValue(IconProperty, value); }
        }

        public bool IsError
        {
            get { return !string.IsNullOrEmpty(LabelText) ? true : false; }
            set
            {
                if (value)
                {
                    LabelColor = IsFieldEmpty ? Color.Transparent : Color.FromHex("#ed1c24");
                    UnderlineErrorMessage = Color.FromHex("#ed1c24");
                }
                else
                {
                    UnderlineErrorMessage = Color.FromHex("#787a7c");
                    LabelText = string.Empty;
                }
            }
        }

        public bool IsFieldEmpty
        {
            get; set;
        }

        void OnFieldFocused(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(editor.Text))
            {
                LabelColor = Color.FromHex("#0492d2");
                UnderlineErrorMessage = Color.FromHex("#0492d2");
            }
        }

        void OnFieldUnfocused(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(editor.Text))
                LabelColor = Color.FromHex("#666666");


            UnderlineErrorMessage = Color.FromHex("#787a7c");

        }         
               

        public TPCustomEditor()
        {
            InitializeComponent();
            root.BindingContext = this;
            PlaceholderColor = Color.FromHex("#666666");
            this.ClearFieldValue = new Command(() =>
            {
                if (ShouldClearOnImageClick && Text.Length > 0)
                {
                    IsFieldEmpty = true;
                    Text = String.Empty;
                    ClearValue(TextProperty);
                }
            });
        }

        public void SetFocus()
        {
            editor.Focus();
        }

        public void Clear()
        {
            editor.Text = "";
            IsFieldEmpty = true;
            Text = String.Empty;
            ClearValue(TextProperty);
        }

    }
}
