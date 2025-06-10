using MatontineDigitalApp.Commons;
using MatontineDigitalApp.Pages.GetStarted;
using MatontineDigitalApp.ViewModels;
using ContentPage = Microsoft.Maui.Controls.ContentPage;

namespace MatontineDigitalApp.Pages.About;

public partial class GetPricingPage : ContentPage
{
  public GetPricingPage()
  {
    InitializeComponent();
    BindingContext = new GetPricingViewModel(Navigation);
  }


  private async void OnImageTapped(object sender, EventArgs e)
  {
    var tappedImage = sender as Image;

    //if (tappedImage == imgOption1)
    //{
    //    DisplayAlert("Clicked", "Option 1 clicked", "OK");
    //}
    //else if (tappedImage == imgOption2)
    //{
    //    DisplayAlert("Clicked", "Option 2 clicked", "OK");
    //}
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
    SubjectLabel = "About";

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

    if (GetTemplateChild("nextNavView") is Grid nextBorder)
    {
      //var existingRecognizer = nextBorder.GestureRecognizers.FirstOrDefault(g => g is TapGestureRecognizer) as TapGestureRecognizer;
      //if (existingRecognizer == null)
      //{

      //  var tapGestureRecognizer = new TapGestureRecognizer();
      //  //tapGestureRecognizer.Tapped += OnNextButtonClicked;
      //  nextBorder.GestureRecognizers.Add(tapGestureRecognizer);
      //}
      //else
      //{
      //  //existingRecognizer.Tapped -= OnNextButtonClicked;
      //  //existingRecognizer.Tapped += OnNextButtonClicked;
      //}
      nextBorder.IsVisible = false;
      
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


}