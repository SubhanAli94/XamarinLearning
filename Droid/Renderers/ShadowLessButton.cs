using System;
using Android.Content;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(HelloWorldForms.ButtonWithoutShadow), typeof(HelloWorldForms.Droid.Effects.ShadowLessButton))]
namespace HelloWorldForms.Droid.Effects
{
    public class ShadowLessButton : ButtonRenderer
    {
        public ShadowLessButton(Context context) : base(context)
        {
        }

        protected override void OnElementChanged(ElementChangedEventArgs<Button> e)
        {
            base.OnElementChanged(e);

            if(Control != null){
                Control.Elevation = 0;

            }
        }
    }
}
