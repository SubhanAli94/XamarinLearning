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

            //hide navigztion bar
            NavigationPage.SetHasNavigationBar(this, false);

            LoadData();

            this.BindingContext = this;

            //use for showing Loading status
            this.IsBusy = true;

            //local counter used to display counter in cart at top right corner
            int localCounter = 0;

            //MessageCentre Subscription for getting selected items' quantity
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

                //show counter in cart
                itemCounterLabel.Text = localCounter.ToString();

                //as price is static for all items so multipy it with counter
                int price = 2;
                price = price * localCounter;

                //show price in label
                priceLabel.Text = price.ToString() + ".00";
            });

        }

        //open Master page upon clicking the menu icon by sending message through message centre
        void MenuIconTapListener(object sender, System.EventArgs e)
        {
            MessagingCenter.Send<MenuItem1>(this, "OpenMenu");
        }


        //method to load data from api
        public async void LoadData()
        {
            var content = "";

            //checked if internet is availabe
            if (CrossConnectivity.Current.IsConnected)
            {
                //make HTTP request
                HttpClient client = new HttpClient();
                var RestURL = "https://dog.ceo/api/breed/hound/images";
                client.BaseAddress = new Uri(RestURL);
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage response = await client.GetAsync(RestURL);

                response.EnsureSuccessStatusCode();
                content = await response.Content.ReadAsStringAsync();

                //parsing response
                JObject joResponse = JObject.Parse(content);
                JArray array = (JArray)joResponse["message"];

                List<CustomItem> list = new List<CustomItem>();

                //iterting list to set data in list view
                for (int j = 0; j < array.Count; j += 2)
                {
                    String ci = j + 1 < array.Count ? array[j + 1].ToString() : null;
                    list.Add(new CustomItem(array[j].ToString(), ci, "fav.png", "fav.png", j.ToString(), (j + 1).ToString()));
                }

                //hide selected item colot
                ListView1.ItemTapped += (object sender, ItemTappedEventArgs e) =>
                {
                    // don't do anything if we just de-selected the row
                    if (e.Item == null) return;
                    // do something with e.SelectedItem
                    ((ListView)sender).SelectedItem = null; // de-select the row
                };


                //setting list to list view source
                ListView1.ItemsSource = list;


                //hide loading status
                this.IsBusy = false;
            }
        }
    }
}
