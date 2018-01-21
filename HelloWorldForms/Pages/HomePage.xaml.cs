using System;

using Xamarin.Forms;
using System.Collections.Generic;
using HelloWorldForms.MasterPageItems;
using HelloWorldForms.MenuItems;
using System.Runtime.InteropServices;

namespace HelloWorldForms
{
    public partial class HomePage : MasterDetailPage
    {
        public List<MasterPageItem> menuItems { get; set; }

        public HomePage()
        {
            InitializeComponent();

            NavigationPage.SetHasNavigationBar(this, false);

            menuItems = new List<MasterPageItem>();

            var Page1 = new MasterPageItem { Title = "Promotions", Icon = "ic_local_offer_black_24dp.png", TargetType = typeof(MenuItem1) };
            var Page2 = new MasterPageItem { Title = "Profile", Icon = "profile.png", TargetType = typeof(MenuItem2) };

            menuItems.Add(Page1);
            menuItems.Add(Page2);

            navigationDrawerList.ItemsSource = menuItems;


            //Detail = new ContentPage(new MenuItem1());
            Detail = new MenuItem1();

            MessagingCenter.Subscribe<MenuItem1>(this, "OpenMenu", (sender) =>
            {
                IsPresented = true;
            });

            MessagingCenter.Subscribe<MenuItem2>(this, "OpenMenu", (sender) =>
            {
                IsPresented = true;
            });

            navigationDrawerList.ItemTapped += (sender, e) =>
            {
                var item = (MasterPageItem)e.Item;
                Type page = item.TargetType;

                Detail = new NavigationPage((Page)Activator.CreateInstance(page));
                IsPresented = false;

            };

        }
    }
}
