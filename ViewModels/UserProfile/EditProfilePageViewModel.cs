using MatontineDigitalApp.Commons;
using MatontineDigitalApp.home;
using MatontineDigitalApp.Model;
using MatontineDigitalApp.Pages.inscription;
using MatontineDigitalApp.Services;
using MatontineDigitalApp.ViewModels;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace MatontineDigitalApp.ViewModelsUserProfile
{
	public class EditProfilePageViewModel : INotifyPropertyChanged
	{
		public event PropertyChangedEventHandler PropertyChanged;

		private UserProfile _userProfile;

		private string _communityName;
		public string CommunityName
		{
			get => _communityName;
			set => SetProperty(ref _communityName, value);
		}

		private string _firstName;
		public string FirstName
		{
			get => _firstName;
			set => SetProperty(ref _firstName, value);
		}

		private string _lastName;
		public string LastName
		{
			get => _lastName;
			set => SetProperty(ref _lastName, value);
		}

		private string _gender;
		public string Gender
		{
			get => _gender;
			set => SetProperty(ref _gender, value);
		}

		private string _phoneNumber;
		public string PhoneNumber
		{
			get => _phoneNumber;
			set => SetProperty(ref _phoneNumber, value);
		}
        private string _country;
		public string Country
		{
			get => _country;
			set => SetProperty(ref _country, value);
		}

        private string _countryCode;


        public string CountryCode
        {
            get => _countryCode;
            set => SetProperty(ref _countryCode, value);
        }
 
        private string _region;
		public string Region
		{
			get => _region;
			set => SetProperty(ref _region, value);
		}

		private string _currency;
		public string Currency
		{
			get => _currency;
			set => SetProperty(ref _currency, value);
		}

		//private string _language;
		//public string Language
		//{
		//	get => _language;
		//	set => SetProperty(ref _language, value);
		//}

		private string _langue;
		public string langue
		{
			get => _langue;
			set => SetProperty(ref _langue, value);
		}

		private string _dateFormat;
		public string FormatDate
		{
			get => _dateFormat;
			set => SetProperty(ref _dateFormat, value);
		}

		private string _thousandsSeparator;
		public string ThousandsSeparator
		{
			get => _thousandsSeparator;
			set => SetProperty(ref _thousandsSeparator, value);
		}

		private string _decimalSeparator;
		public string DecimalSeparator
		{
			get => _decimalSeparator;
			set => SetProperty(ref _decimalSeparator, value);
		}
   
        public UserProfile UserProfile
        {
            get => _userProfile;
            private set => SetProperty(ref _userProfile, value);
        }
        private string selectedCountryCode;
        private string _ProfileCountryDescription;
        private string _SelectedCountryName;

       // public string SelectedCountryName { get; private set; }
        public string ProfileCountryDescription
        {
            get => _ProfileCountryDescription;
            set => SetProperty(ref _ProfileCountryDescription, value);
        }
        public string GenderCode => _userProfile.profile_gender;

       public string SelectedCountryCode { get; private set; }
      
        public EditProfilePageViewModel(UserProfile profile)
		{
			_userProfile = profile;

			CommunityName = profile.profile_community ?? "";
			FirstName = profile.profile_name ?? "";
			LastName = profile.profile_surname ?? "";
			Gender = profile.profile_gender_description ?? "";
			PhoneNumber = profile.profile_phonenumber ?? "";
			Country = profile.ProfileCountryDescription ?? "";
			Region = profile.ProfileRegionDescription ?? "";
			Currency = profile.ProfileCurrencyDescription ?? "";
            langue = profile.LangueDescription ?? "";
			langue = profile.langue ?? "";
			FormatDate = profile.FormatDate ?? "";
			ThousandsSeparator = profile.SeparateurMillier ?? "";
			DecimalSeparator = profile.SeparateurDeDecimal ?? "";
		}

		public async Task<bool> UpdateProfileAsync()
		{
			try
			{
				var updatedProfile = new UserProfile
				{
					profile_community = CommunityName,
					profile_name = FirstName,
					profile_surname = LastName,
					profile_gender_description = Gender,
					profile_phonenumber = PhoneNumber?.Split(' ').LastOrDefault() ?? "",
					ProfileCountryDescription = Country,
					ProfileRegionDescription = Region,
					ProfileCurrencyDescription = Currency,
					LangueDescription = langue,
					FormatDate = FormatDate,
					SeparateurMillier = ThousandsSeparator,
					SeparateurDeDecimal = DecimalSeparator,
					langue = langue
				};

				var result = await MaTontineAPIUtils.Instance.UpdateProfile(updatedProfile);

				if (result?.Savingstatus == true)
				{
					CommonsResources.ConnectedUser = result;
					return true;
				}

				return false;
			}
			catch (Exception ex)
			{
				Console.WriteLine($"❌ Error: {ex.Message}");
				return false;
			}
		}

     

        public void UpdateGender(string code, string description)
        {
            _userProfile.profile_gender = code;
            _userProfile.profile_gender_description = description;

            Gender = description;
        }
        //public void UpdateCountry(string code, string name)
        //{
        //    SelectedCountryCode = code;
        //    SelectedCountryName = name;

        //    CountryCode = code;   
        //    Country = name;    
        //}
   
        //public void UpdateCountry(string code, string description)
        //{
        //    SelectedCountryCode = code;
        //    Country = description;
        //}





        public void UpdateCountry(string code, string description)
        {
           
            _userProfile.ProfileCountryDescription = description;
            CountryCode = code;
            Country = description;
        }

        protected void OnPropertyChanged(string propertyName) =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        protected bool SetProperty<T>(ref T storage, T value, [CallerMemberName] string propertyName = null)
		{
			if (Equals(storage, value)) return false;
			storage = value;
			OnPropertyChanged(propertyName);
			return true;
		}

        public async Task DELETEEntry()
        {
            if (UserProfile == null)
            {
                await Application.Current.MainPage.DisplayAlert("Error", "No profile loaded to delete.", "OK");
                return;
            }

            bool confirm = await Application.Current.MainPage.DisplayAlert(
                "Confirm",
                "Are you sure you want to delete your profile?",
                "Yes",
                "No"
            );

            if (!confirm) return;

            var result = await MaTontineAPIUtils.Instance.MaTontineDeleteProfile(new
            {
                plogin = CommonsResources.credentials.plogin,
                ppassword = CommonsResources.credentials.ppassword,
                langue = UserProfile.langue,
                pcode = UserProfile.profile_community_id,
                token = "8569f412-9kgf-392f-9d56-529687452102" // Replace with secure token logic
            });

            await Application.Current.MainPage.DisplayAlert("Info", result.Savingmessage, "OK");

            if (result.Savingstatus)
            {
                // Optionally clear local data and redirect
                Application.Current.MainPage = new HomePage();
            }
        }
    }
}
