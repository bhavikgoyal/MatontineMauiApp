using CommunityToolkit.Maui.Views;
using MatontineDigitalApp.Commons;
using MatontineDigitalApp.Commons.components;
using MatontineDigitalApp.Model;
using MatontineDigitalApp.Pages.inscription;
using MatontineDigitalApp.ViewModelsUserProfile;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace MatontineDigitalApp.Pages.Profile;

public partial class EditProfilePage : ContentPage
{
    private readonly EditProfilePageViewModel _viewModel;

    public EditProfilePage(UserProfile userProfile)
    {
        InitializeComponent();
        _viewModel = new EditProfilePageViewModel(userProfile);
        BindingContext = _viewModel;
    }

    private async void ManagerGenderEntry_Tapped(object sender, EventArgs e)
    {
        var popup = new MyPopup(
            (code, desc) =>
            {
                _viewModel.UpdateGender(code, desc);
            },
            initGender: _viewModel.GenderCode
        );

        await Navigation.PushModalAsync(popup);
    }
    //private async void CountryEntry_Tapped(object sender, EventArgs e)
    //{
    //    if (BindingContext is not EditProfilePageViewModel vm)
    //        return;

    //    try
    //    {
    //        var selectCountryPage = new SelectCountryView(selectedCountry =>
    //        {
    //            vm.Country = selectedCountry.Description;
    //            vm.CountryCode = selectedCountry.Code;
    //            vm.Currency = selectedCountry.CurrencyDescription;
    //        }, vm.CountryCode);

    //        await Shell.Current.Navigation.PushAsync(selectCountryPage);
    //    }
    //    catch (Exception ex)
    //    {
    //        await DisplayAlert("Navigation Error", ex.Message, "OK");
    //    }
    //}

    private async void CountryEntry_Tapped(object sender, EventArgs e)
    {
        var popup = new SelectCountryView(
            parentPage: this,
            onCountrySelected: country =>
            {
                if (country != null)
                {
                    _viewModel.UpdateCountry(country.Code, country.Description);
                }
            },
            defaultCountryCode: _viewModel.SelectedCountryCode
        );

        await Navigation.PushModalAsync(popup);
    }


    //private async void CountryEntry_Tapped(object sender, EventArgs e)
    //{
    //    if (BindingContext is not EditProfilePageViewModel vm)
    //        return;

    //    try
    //    {
    //        // Create the SelectCountryView instance with all required parameters
    //        var selectCountryView = new SelectCountryView(
    //            parentPage: this, 
    //            countrySelectedAction: selectedCountry =>
    //            {
    //                if (selectedCountry != null)
    //                {
    //                    vm.UpdateCountry(
    //                        selectedCountry.Code,
    //                        selectedCountry.Description

    //                    );
    //                }
    //            },
    //            defaultCountryCode: vm.CountryCode
    //        );

    //        // Navigate to the modal page
    //        await Navigation.PushModalAsync(selectCountryView);
    //    }
    //    catch (Exception ex)
    //    {
    //        await DisplayAlert("Navigation Error", ex.Message, "OK");
    //    }
    //}


    //private async void CountryEntry_Tapped(object sender, EventArgs e)
    //{
    //    //var popup = new MyPopup(
    //    //    (CountryDto selectedCountry) =>
    //    //    {
    //    //        _viewModel.UpdateCountry(selectedCountry.Code, selectedCountry.Description);
    //    //    },
    //    //    //initCountryCode: _viewModel.CountryCode // pass the initial country code, not gender
    //    //);

    //    //await Navigation.PushModalAsync(popup);
    //}

    private async void UpdateProfile_Clicked(object sender, EventArgs e)
    {
        try
        {
            bool isSuccess = await _viewModel.UpdateProfileAsync();
            string message = isSuccess ? "Profile updated successfully!" : "Profile update failed.";
            await DisplayAlert("Update", message, "OK");
        }
        catch (Exception ex)
        {
            await DisplayAlert("Error", $"Update failed: {ex.Message}", "OK");
        }
    }

    private async void OnDeleteClicked(object sender, EventArgs e)
    {
        await _viewModel.DELETEEntry();
    }

  
}
