using System;
using System.Collections.Generic;
using System.Net.Http;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Xamarin.Forms;
using System.Net.NetworkInformation;
using System.Windows.Input;
using System.Diagnostics;
using Plugin.Connectivity;
using PropertyChanged;
using FFImageLoading.Forms;

namespace HelloWorldForms.MenuItems
{
    public partial class MenuItem1 : ContentPage
    {


        public MenuItem1()
        {
            InitializeComponent();

            NavigationPage.SetHasNavigationBar(this, false);

            NetworkInterface.GetIsNetworkAvailable();

            LoadData();

            this.BindingContext = this;

            this.IsBusy = true;

            int localCounter = 0;
            MessagingCenter.Subscribe<CustomItem, string>(this, "ItemCounter", (obj, counter) =>
            {

                if (counter == "Inc")
                {
                    localCounter++;
                }
                else
                {
                    if (localCounter > 0)
                    {
                        localCounter--;
                    }
                }
                itemCounterLabel.Text = localCounter.ToString();
                int price = 2;
                price = price * localCounter;
                priceLabel.Text = price.ToString() + ".00";
            });

        }

        void MenuIconTapListener(object sender, System.EventArgs e)
        {
            MessagingCenter.Send<MenuItem1>(this, "OpenMenu");
        }


        public async void LoadData()
        {
            var content = "";


            if (CrossConnectivity.Current.IsConnected)
            {
                HttpClient client = new HttpClient();
                var RestURL = "https://dog.ceo/api/breed/hound/images";
                client.BaseAddress = new Uri(RestURL);
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage response = await client.GetAsync(RestURL);

                response.EnsureSuccessStatusCode();
                content = await response.Content.ReadAsStringAsync();

                JObject joResponse = JObject.Parse(content);
                JArray array = (JArray)joResponse["message"];

                List<CustomItem> list = new List<CustomItem>();

                for (int j = 0; j < array.Count; j += 2)
                {
                    String ci = j + 1 < array.Count ? array[j + 1].ToString() : null;
                    list.Add(new CustomItem(array[j].ToString(), ci, "fav.png", "fav.png", j.ToString(), (j + 1).ToString()));
                }

                ListView1.ItemTapped += (object sender, ItemTappedEventArgs e) =>
                {
                    // don't do anything if we just de-selected the row
                    if (e.Item == null) return;
                    // do something with e.SelectedItem
                    ((ListView)sender).SelectedItem = null; // de-select the row
                };

                ListView1.ItemsSource = list;

                this.IsBusy = false;
            }
        }
    }
}
