namespace MatontineDigitalApp.Pages.GetStarted;

public partial class SelectPartenerPage : ContentPage
{
  private string _selectedPartnerName;

  public SelectPartenerPage()
  {
    InitializeComponent();
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
    if (string.IsNullOrEmpty(_selectedPartnerName))
    {
      await DisplayAlert("Selection Required", "Please select a partner to continue.", "OK");
      return; 
    }

    try
    {
      await App.Current.MainPage.Navigation.PushAsync(new ManagerPersonalDetailsPage());
    }
    catch (Exception ex)
    {
      System.Diagnostics.Debug.WriteLine($"Navigation Error: {ex.Message}");
      await DisplayAlert("Error", "Could not navigate to the next page.", "OK");
    }
  }

  private void OnPartnerTapped(object sender, TappedEventArgs e)
  {
    AfrimoneyBorder.Stroke = Colors.LightGray;
    MatontineBorder.Stroke = Colors.LightGray;
    Partner3Border.Stroke = Colors.LightGray;

    if (sender is Border tappedBorder)
    {
      tappedBorder.Stroke = Color.FromArgb("#27ae60");

      _selectedPartnerName = tappedBorder.AutomationId ?? tappedBorder.ClassId ?? tappedBorder.StyleId ?? "Unknown";

      if (tappedBorder == AfrimoneyBorder) _selectedPartnerName = "Afrimoney";
      else if (tappedBorder == MatontineBorder) _selectedPartnerName = "Matontine";
      else if (tappedBorder == Partner3Border) _selectedPartnerName = "Partner 3";
    }
  }

  public string SubjectLabel
  {
    get => (string)GetValue(SubjectLabelProperty);
    set => SetValue(SubjectLabelProperty, value);
  }

  public static readonly BindableProperty SubjectLabelProperty =
      BindableProperty.Create(nameof(SubjectLabel), typeof(string), typeof(SelectPartenerPage), default(string));

  protected override void OnAppearing()
  {
    base.OnAppearing();
    SubjectLabel = "Create your Account";
  }
}