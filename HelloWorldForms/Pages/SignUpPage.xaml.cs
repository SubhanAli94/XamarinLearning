using System;
using System.Collections.Generic;
using HelloWorldForms.Pages;

using Xamarin.Forms;
using HelloWorldForms.Models;
using Newtonsoft.Json;
using HelloWorldForms.Helpers;
using Microsoft.VisualBasic;
using Xamarin.Forms.Internals;

namespace HelloWorldForms
{
    public partial class SignUpPage : ContentPage
    {
        private string dateSelected;
        private bool isCheckedTermsAndConditions;
        
        public SignUpPage()
        {
            InitializeComponent();

            setEntryActions();
        }

        private void setEntryActions()
        {
            firstnameEntry.ReturnKeyType = CustomEntry.ReturnKeyTypes.Next;
            lastNameEntry.ReturnKeyType = CustomEntry.ReturnKeyTypes.Next;
            usernameEntry.ReturnKeyType = CustomEntry.ReturnKeyTypes.Next;
            emailEntry.ReturnKeyType = CustomEntry.ReturnKeyTypes.Next;
            passwordEntry.ReturnKeyType = CustomEntry.ReturnKeyTypes.Next;
            confirmPasswordEntry.ReturnKeyType = CustomEntry.ReturnKeyTypes.Next;
            mobileNumberEntry.ReturnKeyType = CustomEntry.ReturnKeyTypes.Done;

            firstnameEntry.Completed += (sender, e) => {
                lastNameEntry.Focus();
            };
            lastNameEntry.Completed += (sender, e) => {
                datePicker.Focus();
            };
            usernameEntry.Completed += (sender, e) => {
                emailEntry.Focus();
            };
            emailEntry.Completed += (sender, e) => {
                passwordEntry.Focus();
            };
            passwordEntry.Completed += (sender, e) => {
                confirmPasswordEntry.Focus();
            };
            confirmPasswordEntry.Completed += (sender, e) => {
                mobileNumberEntry.Focus();
            };
        }

        private bool fieldsValidator()
        {
            if(String.IsNullOrEmpty(firstnameEntry.Text) ||
               String.IsNullOrEmpty(lastNameEntry.Text) ||
               String.IsNullOrEmpty(dateSelected) ||
               String.IsNullOrEmpty(usernameEntry.Text) ||
               String.IsNullOrEmpty(emailEntry.Text) ||
               String.IsNullOrEmpty(passwordEntry.Text) ||
               String.IsNullOrEmpty(mobileNumberEntry.Text)
              ){
                DisplayAlert("Error!", "Please fill proper data in all fields", "OK");
                return false;
            }else if(!passwordEntry.Text.Equals(confirmPasswordEntry.Text)){
                DisplayAlert("Error!", "Password mismatch!", "OK");
                return false;
            }else if(!isCheckedTermsAndConditions){
                DisplayAlert("Error!", "Please accept terms and conditions.", "OK");
                return false;
            }else{
                return true;
            }
        }

        private async void storeCredentials()
        {
            SignupModel signUpModel = new SignupModel
            {
                firstName = firstnameEntry.Text,
                lastName = lastNameEntry.Text,
                username = usernameEntry.Text,
                email = emailEntry.Text,
                password = passwordEntry.Text,
                date = dateSelected,
                mobileNumber = mobileNumberEntry.Text,
                isTermsAndConditionsAccepted = isCheckedTermsAndConditions
                                                
            };

            string serializedSignUpModel = JsonConvert.SerializeObject(signUpModel);
            Settings.UserSignUpData = serializedSignUpModel;

            Settings.UserLoggedInStatus = true;
            await Navigation.PushAsync(new SelectFranchizsePage());
        }

        void Handle_DateSelected(object sender, Xamarin.Forms.DateChangedEventArgs e)
        {
            dateSelected = e.NewDate.Date.ToString();
            usernameEntry.Focus();
        }

        void Handle_CheckChanged(object sender, System.EventArgs e)
        {
            isCheckedTermsAndConditions = checkboxControl.Checked;
        }

        void Handle_SubmitClicked(object sender, System.EventArgs e)
        {
            if (fieldsValidator())
            {
                storeCredentials();
                Navigation.RemovePage(this);
            }
        }
    }
}
