# XamarinLearning
This is a sample Xamarin learning project. This project is tested just on Android Smart phone.

# Project description
This is a project with cloned screen from 7-Eleven. Screens are Login, SignUp, Location Selection, and a Home Page. Graphics used in this project are taken from different free online resource providing websites.

# Screenshots
<img src="https://user-images.githubusercontent.com/22730931/35192432-d6b7dadc-feb3-11e7-93c4-34695488fe63.jpeg" width="240" height="400" /> <img src="https://user-images.githubusercontent.com/22730931/35192429-d659be34-feb3-11e7-9230-74fd38032c2a.jpeg" width="240" height="400" /> <img src="https://user-images.githubusercontent.com/22730931/35192431-d6892bce-feb3-11e7-8b96-d2833b443821.jpeg" width="240" height="400" /> <img src="https://user-images.githubusercontent.com/22730931/35192427-d5e8aca8-feb3-11e7-9f64-14692852be70.jpeg" width="240" height="400" /> <img src="https://user-images.githubusercontent.com/22730931/35192428-d62a7c64-feb3-11e7-88e2-f3c44e2d5658.jpeg" width="240" height="400" /> 


# How to use it?
Run on Android smart phone or on emulator. After splash screen there will be a welcome page. On Welcome page there are three options for user to navigate towards Home page, which are following:
1. Tap Skip - Location Selection Screen - Tap on any box
2. Tap SignUp -  Fill data in all fields and click checkbox - Location Selection Screen - Tap on any box
3. Enter username and password if you have any - Location Selection Screen - Tap on any box

## Field validations
Currently there are only validations for not leaving any field empty.

# OpenSource Api
1. Following is a free Rest Api available online to display dog images.
https://dog.ceo/api/breed/hound/images

# Pages Used
1. ContentPage
2. MasterDetail Page

# Layouts Used
1. StackLayout
2. Absolute Layout

# Custom Renderers Used
1. Custom renderer for changing cursor drawable in entry and to set IME options. This is just for android.
2. Custom Renderer for Date Picker.
3. Custom Renderer for Shadowless button.

# Effects
Underline effect used to remove underline of entry. This is just for android

# Nugets Used
### For graphics:
1. Xamarin.FFImageLoading.Forms
2. Xamarin.FFImageLoading.Transformations

### For locally storing user credentials
1. Xam.Plugins.Settings

### For Checking Internet connectivity
1. Xam.Plugin.Connectivity

### For Json Parsing
1. NewtonSoft.Json

# Useful Links
### For Xamarin:
1. https://developer.xamarin.com/
2. Stackoverflow

### For assets
1. https://material.io/icons/ alongside with others

### For warming up my C#
1. https://www.tutorialspoint.com/csharp/index.htm

# Time taking tasks
1. It took me alot while designing Home Screen. Because there is not any native view available to populate list data in grid. As I use Recyclerview with GridLayoutManager in Android. 
#### Final Approach
1. I used ListView with two items in Same ViewCell using Grid. I created a model and pass two list items' params as references in model's constructor and while iterating the list I used to iterate two position ahead to avoid any dublicate entry in same ListView cell.


# Confessions
1. Alot of refactoring is required as this project is emerged from HelloWorld learning project.
2. Missing functionality of Logout
3. There is not profile screen just a blank page.
4. While scrolling th list there are jerks, it requires R&D to avoid this. What I tried is to use a Nuget to cache images, it improved performance to some extent but not much.
