using MatontineDigitalApp.Commons;
using MatontineDigitalApp.Model;
using MatontineDigitalApp.Services;
using Newtonsoft.Json;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Microsoft.Maui.Controls;
using MatontineDigitalApp.ViewModels;
using MatontineDigitalApp.home;

namespace MatontineDigitalApp.ViewModelsUserProfile
{
    public class DisplayProfilePageViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        // Private backing fields
        private string _communityName, _firstName, _lastName, _gender, _phoneNumber;
        private string _country, _region, _currency, _langue, _dateFormat, _thousandsSeparator, _decimalSeparator;
        private UserProfile _userProfile;

        // Public bindable properties
        public string CommunityName { get => _communityName; set => SetProperty(ref _communityName, value); }
        public string FirstName { get => _firstName; set => SetProperty(ref _firstName, value); }
        public string LastName { get => _lastName; set => SetProperty(ref _lastName, value); }
        public string Gender { get => _gender; set => SetProperty(ref _gender, value); }
        public string PhoneNumber { get => _phoneNumber; set => SetProperty(ref _phoneNumber, value); }
        public string Country { get => _country; set => SetProperty(ref _country, value); }
        public string Region { get => _region; set => SetProperty(ref _region, value); }
        public string Currency { get => _currency; set => SetProperty(ref _currency, value); }
        public string langue { get => _langue; set => SetProperty(ref _langue, value); }
        public string DateFormat { get => _dateFormat; set => SetProperty(ref _dateFormat, value); }
        public string ThousandsSeparator { get => _thousandsSeparator; set => SetProperty(ref _thousandsSeparator, value); }
        public string DecimalSeparator { get => _decimalSeparator; set => SetProperty(ref _decimalSeparator, value); }

        public UserProfile UserProfile
        {
            get => _userProfile;
            private set => SetProperty(ref _userProfile, value);
        }

        public DisplayProfilePageViewModel() { }

        public async Task LoadProfileValues(string login, string password)
        {
            try
            {
                var credential = new Credentials
                {
                    plogin = login,
                    ppassword = password
                };

                string jsonResponse = await MaTontineAPIUtils.Instance.Login(credential);
                Console.WriteLine("API Response: " + jsonResponse);

                var profile = JsonConvert.DeserializeObject<UserProfile>(jsonResponse);

                if (profile != null)
                {
                    UserProfile = profile;

                    CommunityName = profile.profile_community;
                    FirstName = profile.profile_name;
                    LastName = profile.profile_surname;
                    Gender = profile.profile_gender_description;
                    PhoneNumber = $"{profile.ProfileContryIndicatif} {profile.profile_phonenumber}";
                    Country = profile.ProfileCountryDescription;
                    Region = profile.ProfileRegionDescription;
                    Currency = profile.ProfileCurrencyDescription;
                    langue = profile.LangueDescription;
                    DateFormat = profile.FormatDate;
                    ThousandsSeparator = profile.SeparateurMillier;
                    DecimalSeparator = profile.SeparateurDeDecimal;

                    CommonsResources.ConnectedUser = profile;
                }
                else
                {
                    Console.WriteLine("Failed to parse profile data.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error loading profile: {ex.Message}");
            }
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

        protected void OnPropertyChanged([CallerMemberName] string name = null) =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));

        protected bool SetProperty<T>(ref T storage, T value, [CallerMemberName] string propertyName = null)
        {
            if (Equals(storage, value)) return false;
            storage = value;
            OnPropertyChanged(propertyName);
            return true;
        }
    }
}
