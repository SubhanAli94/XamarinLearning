using System;
using System.Diagnostics;
using System.Windows.Input;
using PropertyChanged;
using Xamarin.Forms;
using System.ComponentModel;
using FFImageLoading.Forms;
using System.Reflection;
using System.Runtime.CompilerServices;

namespace HelloWorldForms.MenuItems
{
    /**
     * Custom Model is an item in list view as list view in Xamarin.forms
     * contains one ViewCell in an item so I used GridView and place two 
     * custom items side by side in single view cell and initialized them 
     * with single model.
     */
    public class CustomItem : INotifyPropertyChanged
    {
        #region Items image sources
        //left image source
        public string DogImage1 { get; set; }

        //right image source
        public string DogImage2 { get; set; }
        #endregion

        #region Dog Names
        public string LeftDogName { get; set; }

        public string RightDogName { get; set; }
        #endregion

        #region Item Click Commands
        //left item click command
        public ICommand ItemClickListener1 { get; }

        //right item click command
        public ICommand ItemClickListener2 { get; }
        #endregion

        #region favourite/unfavourite icon click commands
        //left item favourite icon click command
        public ICommand leftFavoriteIconClickListener { get; }

        //right item favourite icon click command
        public ICommand rightFavoriteIconClickListener { get; }

        #endregion

        #region defining image sources fields and properties for favourite icons
        //image source field to left favourite/unfavourite icon
        public string leftFavImageSource;

        //image source property to left favourite/unfavourite icon
        public string leftFavouriteImageSource
        {
            get { return leftFavImageSource; }
            set { leftFavImageSource = value; OnPropertyChanged(); }
        }

        //image source field to right favourite/unfavourite icon
        public string rightFavImageSource;

        //image source property to right favourite/unfavourite icon
        public string rightFavouriteImageSource
        {
            get { return rightFavImageSource; }
            set { rightFavImageSource = value; OnPropertyChanged(); }
        }
        #endregion

        #region fields for indexes of left and right items in view cell for testing purpose.
        //index of left item in list of items
        public string index1 { get; set; }

        //index of right item in list of items
        public string index2 { get; set; }
        #endregion


        #region Increment/Decrement quantity icons click commands
        //left item increment quantity command
        public ICommand leftIncIconClickListener { get; }

        //right item increment quantity command
        public ICommand leftDecIconClickListener { get; }

        //left item increment quantity command
        public ICommand rightIncIconClickListener { get; }

        //right item increment quantity command
        public ICommand rightDecIconClickListener { get; }
        #endregion

        #region quantity counters and checks for items selected
        //variables and properties to keep track of items selection
        public bool _isLeftItemSelected;
        public bool IsLeftItemSelected
        {
            set { _isLeftItemSelected = value; OnPropertyChanged(); }
            get { return _isLeftItemSelected; }
        }

        public bool _isRightItemSelected;
        public bool IsRightItemSelected
        {
            get { return _isRightItemSelected; }
            set { _isRightItemSelected = value; OnPropertyChanged(); }
        }


        public int _leftItemCounter = 1;
        public int LeftItemCounter
        {
            get { return _leftItemCounter; }
            set { _leftItemCounter = value; OnPropertyChanged(); }
        }

        public int _rightItemCounter = 1;
        public int RightItemCounter
        {
            get { return _rightItemCounter; }
            set { _rightItemCounter = value; OnPropertyChanged(); }
        }
        #endregion

        //Overloaded constructor with params of left and right items source, fav iconsand indices 
        public CustomItem(String imageSrc1, String imageSrc2, String leftFavouriteImageSource, String rightFavouriteImageSource, string index1, string index2)
        {
            //assigning values to model's fields
            DogImage1 = imageSrc1;
            DogImage2 = imageSrc2;
            this.leftFavouriteImageSource = leftFavouriteImageSource;
            this.rightFavouriteImageSource = rightFavouriteImageSource;

            this.index1 = index1;
            this.index2 = index2;

            this.LeftDogName = "Hound Dog " + index1;
            this.RightDogName = "Hound Dog " + index2;

            //init left item click command
            ItemClickListener1 = new Command(new Action(() =>
            {
                Debug.WriteLine("Yay" + DogImage1.ToString() + " : " + index1);
				if(!IsLeftItemSelected){
					MessagingCenter.Send<CustomItem, string>(this, "ItemCounter", "Inc");
				}

                this.IsLeftItemSelected = true;

            }));

            //init right item click command
            ItemClickListener2 = new Command(new Action(() =>
            {
                Debug.WriteLine("Yay" + DogImage2.ToString() + " : " + index2);
				if (!IsRightItemSelected)
				{
					MessagingCenter.Send<CustomItem, string>(this, "ItemCounter", "Inc");
				}

                this.IsRightItemSelected = true;

            }));

            //init left favourite icon click command and change icon on conditional basis
            leftFavoriteIconClickListener = new Command<CustomItem>(customItem =>
            {
                if (this.leftFavouriteImageSource == "fav.png")
                {
                    this.leftFavouriteImageSource = "fav_filled.png";
                }
                else
                {
                    this.leftFavouriteImageSource = "fav.png";
                }
                Debug.WriteLine("Yay: " + customItem.ToString() + leftFavouriteImageSource.ToString() + " : " + index1);
            });

            //init right favourite icon click command and change icon on conditional basis
            rightFavoriteIconClickListener = new Command<CustomItem>(customItem =>
            {
                if (this.rightFavouriteImageSource == "fav.png")
                {
                    this.rightFavouriteImageSource = "fav_filled.png";
                }
                else
                {
                    this.rightFavouriteImageSource = "fav.png";
                }
                Debug.WriteLine("Yay: " + customItem.ToString() + rightFavouriteImageSource.ToString() + " : " + index2);

            });

            //Left Item's Increment Click Command Initialization
            leftIncIconClickListener = new Command(() =>
            {
                ++this.LeftItemCounter;
                MessagingCenter.Send<CustomItem, string>(this, "ItemCounter", "Inc");
            });

            //Left Item's Decrement Click Command Initialization
            leftDecIconClickListener = new Command(() =>
            {

                if (this.LeftItemCounter > 1)
                {
                    --this.LeftItemCounter;
                    MessagingCenter.Send<CustomItem, string>(this, "ItemCounter", "Dec");
                }
                else
                {
                    this.IsLeftItemSelected = false;
					MessagingCenter.Send<CustomItem, string>(this, "ItemCounter", "Dec");
                }
            });

            //Right Item's Increment Click Command Initialization
            rightIncIconClickListener = new Command(() =>
            {
                ++this.RightItemCounter;
                MessagingCenter.Send<CustomItem, string>(this, "ItemCounter", "Inc");
            });

            //Right Item's Decrement Click Command Initialization
            rightDecIconClickListener = new Command(() =>
            {

                if (this.RightItemCounter > 1)
                {
                    --this.RightItemCounter;
                    MessagingCenter.Send<CustomItem, string>(this, "ItemCounter", "Dec");
                }
                else
                {
                    this.IsRightItemSelected = false;
					MessagingCenter.Send<CustomItem, string>(this, "ItemCounter", "Dec");
                }
            });

        }

        //INotifyPropertyChanged event
        public event PropertyChangedEventHandler PropertyChanged;

        //method to notify UI about property changed
        private void OnPropertyChanged([CallerMemberNameAttribute] string nameOfProperty = null)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(nameOfProperty));
        }
    }
}
