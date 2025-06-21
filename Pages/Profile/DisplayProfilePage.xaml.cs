using MatontineDigitalApp.Commons;
using MatontineDigitalApp.Model;
using MatontineDigitalApp.ViewModelsUserProfile;
using System;

namespace MatontineDigitalApp.Pages.Profile
{
    public partial class DisplayProfilePage : MyContentPageWithTemplate
    {
        private readonly DisplayProfilePageViewModel _viewModel;

        public DisplayProfilePage()
        {
            InitializeComponent();
            _viewModel = new DisplayProfilePageViewModel();
            BindingContext = _viewModel;
            MyTemplate.RigthBtnClicked += OnEditClicked;
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();

            await _viewModel.LoadProfileValues("aba", "aba");
        }

        private async void OnEditClicked(object sender, EventArgs e)
        {
            var userProfile = _viewModel.UserProfile;

            if (userProfile == null)
            {
                await DisplayAlert("Error", "No profile data found.", "OK");
                return;
            }

            // Navigate to the edit profile page
            await Navigation.PushModalAsync(new EditProfilePage(userProfile));
        }

        private async void OnDeleteClicked(object sender, EventArgs e)
        {
            await _viewModel.DELETEEntry();
        }
    }
}
