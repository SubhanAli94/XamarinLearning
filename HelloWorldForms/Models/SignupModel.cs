using System;
namespace HelloWorldForms.Models
{
    public class SignupModel
    {
        public string firstName { get; set; } 
        public string lastName { get; set; } 
        public string username { get; set; } 
        public string date { get; set; } 
        public string email { get; set; } 
        public string password { get; set; } 
        public string mobileNumber { get; set; } 
        public string agreement { get; set; } 
        public bool isTermsAndConditionsAccepted { get; set; }
    }
}
