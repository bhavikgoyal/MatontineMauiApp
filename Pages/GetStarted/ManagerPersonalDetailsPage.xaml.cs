namespace MatontineDigitalApp.Pages.GetStarted;

public partial class ManagerPersonalDetailsPage : ContentPage
{
	public ManagerPersonalDetailsPage()
	{
		InitializeComponent();
	}

  private async void MonthSelector_Tapped(object sender, TappedEventArgs e)
  {
    var months = new[] { "January", "February", "March", "April", "May", "June", "July", "August", "September", "October", "November", "December" };

    string selectedMonth = await DisplayActionSheet("Select a Month", "Cancel", null, months);

    if (!string.IsNullOrEmpty(selectedMonth) && selectedMonth != "Cancel")
    {
      MonthLabel.Text = selectedMonth;
      MonthLabel.TextColor = Colors.Black;
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
      await App.Current.MainPage.Navigation.PushAsync(new GenderPage());
    }
    catch (Exception ex)
    {
      System.Diagnostics.Debug.WriteLine($"Navigation Error: {ex.Message}");
      await DisplayAlert("Error", "Could not navigate to the next page.", "OK");
    }
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
}