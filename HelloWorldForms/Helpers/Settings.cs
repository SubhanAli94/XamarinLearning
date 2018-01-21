// Helpers/Settings.cs
using Plugin.Settings;
using Plugin.Settings.Abstractions;

namespace HelloWorldForms.Helpers
{
	/// <summary>
	/// This is the Settings static class that can be used in your Core solution or in any
	/// of your client applications. All settings are laid out the same exact way with getters
	/// and setters. 
	/// </summary>
	public static class Settings
	{
		private static ISettings AppSettings
		{
			get
			{
				return CrossSettings.Current;
			}
		}

		#region Setting Constants

		private const string SignUpKey = "signUpKey_key";
		private static readonly string SignUpDefault = string.Empty;

        private const string SignInKey = "signInKey_key";
        private static readonly string SignInDefault = string.Empty;

        private const string UserLoggedInKey = "userLoggedIn_key";
        private static readonly bool UserLoggedInDefault = false;

		#endregion


		public static string UserSignUpData
		{
			get
			{
				return AppSettings.GetValueOrDefault(SignUpKey, SignUpDefault);
			}
			set
			{
				AppSettings.AddOrUpdateValue(SignUpKey, value);
			}
		}

        public static string UserSignInData
        {
            get
            {
                return AppSettings.GetValueOrDefault(SignInKey, SignInDefault);
            }
            set
            {
                AppSettings.AddOrUpdateValue(SignInKey, value);
            }
        }

        public static bool UserLoggedInStatus
        {
            get
            {
                return AppSettings.GetValueOrDefault(UserLoggedInKey, UserLoggedInDefault);
            }
            set
            {
                AppSettings.AddOrUpdateValue(UserLoggedInKey, value);
            }
        }

	}
}