using MatontineDigitalApp.Pages.inscription;
using Microsoft.Maui.Controls;
using System;

namespace MatontineDigitalApp.Commons.components
{
    public partial class MyPopup : ContentPage
    {
        private readonly Action<string, string> _onGenderSelectedCallback;
        private string selectedValue;
        private string selectedDescription;

        public MyPopup(Action<string, string> onGenderSelectedCallback, string initGender = null)
        {
            InitializeComponent();

            _onGenderSelectedCallback = onGenderSelectedCallback;

            // Load the gender selection view and insert into ContentView
            var genderView = new SelectGenderView(OnGenderSelected, initGender);
            bodyContent.Content = genderView;
        }

        private void OnGenderSelected(string value, string description)
        {
            selectedValue = value;
            selectedDescription = description;

            // Optional: immediately invoke callback (or only on Done)
            _onGenderSelectedCallback?.Invoke(value, description);
        }

        private async void btnDone_Clicked(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(selectedValue))
            {
                await DisplayAlert("Selection Required", "Please select a gender before continuing.", "OK");
                return;
            }

            // Close modal
            await Navigation.PopModalAsync();
        }
    }
}
