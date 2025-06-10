using MatontineDigitalApp.Model;
using MatontineDigitalApp.Pages.Authentification;

namespace MatontineDigitalApp.Pages.GetStarted;

public partial class GetStart : ContentPage
{
    GetStartedPageModel getStartedPageModel = new GetStartedPageModel();

    public GetStart()
    {
        InitializeComponent();
    }

    public string SubjectLabel
    {
        get => (string)GetValue(SubjectLabelProperty);
        set => SetValue(SubjectLabelProperty, value);
    }

    public static readonly BindableProperty SubjectLabelProperty =
        BindableProperty.Create(nameof(SubjectLabel), typeof(string), typeof(GetStart), default(string));

    protected override void OnAppearing()
    {
        base.OnAppearing();
        SubjectLabel = "Create your Account";
    }

    private void OnImage1Tapped(object sender, TappedEventArgs e)
    {
        getStartedPageModel.FrenchLanguage = "FR";
        getStartedPageModel.EnglishLanguage = null;
        HighlightSelectedLanguage();
    }

    private void OnImage2Tapped(object sender, TappedEventArgs e)
    {
        getStartedPageModel.EnglishLanguage = "EN";
        getStartedPageModel.FrenchLanguage = null;
        HighlightSelectedLanguage();
    }

    private void HighlightSelectedLanguage()
    {
        if (getStartedPageModel.FrenchLanguage == "FR")
        {
            borderOption1.Stroke = Colors.Green;
            borderOption2.Stroke = Colors.Transparent;
        }
        else if (getStartedPageModel.EnglishLanguage == "EN")
        {
            borderOption1.Stroke = Colors.Transparent;
            borderOption2.Stroke = Colors.Green;
        }
    }

    protected override void OnApplyTemplate()
    {
        base.OnApplyTemplate();

        if (GetTemplateChild("BackButtonContainer") is Layout backLayout)
        {
            var existingRecognizer = backLayout.GestureRecognizers.FirstOrDefault(g => g is TapGestureRecognizer) as TapGestureRecognizer;
            if (existingRecognizer == null)
            {
                var tapGestureRecognizer = new TapGestureRecognizer();
                tapGestureRecognizer.Tapped += OnBackButtonClicked;
                backLayout.GestureRecognizers.Add(tapGestureRecognizer);
            }
            else
            {
                existingRecognizer.Tapped -= OnBackButtonClicked;
                existingRecognizer.Tapped += OnBackButtonClicked;
            }           
            
            backLayout.IsVisible = true;
          
        }

        if (GetTemplateChild("NextButtonContainer") is Border nextBorder)
        {
            var existingRecognizer = nextBorder.GestureRecognizers.FirstOrDefault(g => g is TapGestureRecognizer) as TapGestureRecognizer;
            if (existingRecognizer == null)
            {
                var tapGestureRecognizer = new TapGestureRecognizer();
                tapGestureRecognizer.Tapped += OnNextButtonClicked;
                nextBorder.GestureRecognizers.Add(tapGestureRecognizer);
            }
            else
            {
                existingRecognizer.Tapped -= OnNextButtonClicked;
                existingRecognizer.Tapped += OnNextButtonClicked;
            }
        }
    }

    private async void OnBackButtonClicked(object sender, TappedEventArgs e)
    {
        try
        {
           
                await App.Current.MainPage.Navigation.PopModalAsync();
          
        }
        catch (Exception ex)
        {
            System.Diagnostics.Debug.WriteLine($"Navigation Error: {ex.Message}");
        }
    }

    private async void OnNextButtonClicked(object sender, TappedEventArgs e)
    {
        try
        {
            await App.Current.MainPage.Navigation.PushAsync(new CountryPage(getStartedPageModel));
        }
        catch (Exception ex)
        {
            System.Diagnostics.Debug.WriteLine($"Navigation Error: {ex.Message}");
            await DisplayAlert("Error", "Could not navigate to the next page.", "OK");
        }
    }
}
