using System;
using Android.Content;
using Android.Support.V7.Graphics.Drawable;
using Android.Widget;
using HelloWorldForms.Droid.Renderers;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android.AppCompat;
using Plugin.Settings;
using Android.Database;
using System.Runtime.CompilerServices;
using Android.App;
using Android.Icu.Util;
using Android.Util;

[assembly: ExportRenderer(typeof(HelloWorldForms.HomePage), typeof(IconNavigationPageRenderer))]
namespace HelloWorldForms.Droid.Renderers
{
    public class IconNavigationPageRenderer : MasterDetailPageRenderer
    {
        MainActivity mainActivity;
        public IconNavigationPageRenderer(Context context) : base(context)
        {
            mainActivity = Context as MainActivity;
        }
    
        protected override void OnLayout(bool changed, int l, int t, int r, int b)
        {
            base.OnLayout(changed, l, t, r, b);
            var toolbar = FindViewById<Android.Support.V7.Widget.Toolbar>(Resource.Id.toolbar);
            if (toolbar != null)
            {
                for (var i = 0; i < toolbar.ChildCount; i++)
                {
                    var imageButton = toolbar.GetChildAt(i) as ImageButton;

                    var drawerArrow = imageButton?.Drawable as DrawerArrowDrawable;
                    if (drawerArrow == null)
                        continue;
                    
                    //imageButton.SetImageDrawable(Context.GetDrawable(Resource.Drawable.ic_menu_black_24dp));
                }
            }
        }
    }
}
