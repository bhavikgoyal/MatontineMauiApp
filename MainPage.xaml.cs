using MatontineDigitalApp.Pages.Authentification;
using MatontineDigitalApp.ViewModels;

namespace MatontineDigitalApp
{
  public partial class MainPage : ContentPage
  {
    public MainPage()
    {
      InitializeComponent();
      BindingContext = new MainPageViewModel(Navigation);
    }
    private async void GetNextPage_Tapped(object sender, EventArgs e)
    {
      await Navigation.PushModalAsync(new AuthentificationHomePage());
    }

  }
}
