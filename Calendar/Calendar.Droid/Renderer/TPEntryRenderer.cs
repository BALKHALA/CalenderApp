using Android.Widget;
using Calendar;
using Calendar.Droid;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(TPEntry), typeof(TPEntryRenderer))]

namespace Calendar.Droid
{
    public class TPEntryRenderer : EntryRenderer
    {
        public TPEntryRenderer()
        {
        }

        protected override void OnElementChanged(ElementChangedEventArgs<Entry> e)
        {
            base.OnElementChanged(e);
            var nativeEntry = (TextView)Control;

            var Label = (TPEntry)Element;
            nativeEntry.Background = null;
            nativeEntry.SetPadding(0, nativeEntry.PaddingTop, 70, nativeEntry.PaddingBottom);
        }
    }
}