using MatontineDigitalApp.Commons;
using MatontineDigitalApp.Pages.About;
using MatontineDigitalApp.Pages.GetStarted;
using MatontineDigitalApp.Pages.Signin;
using MatontineDigitalApp.Pages.View;
using MatontineDigitalApp.ViewModels;

namespace MatontineDigitalApp.Pages.Authentification;

public partial class AuthentificationHomePage : MyContentPage
{
  private bool tapOnItem = false;


  public AuthentificationHomePage()
  {
    BindingContext = new AuthentificationHomeViewModel(Navigation);
    NavigationPage.SetHasNavigationBar(this, false);
    InitializeComponent();
    BindingContext = this;
    RefreshData();

    MessagingCenter.Subscribe<EventArgs, string>(this, MyEvent.LanguageChange, (sender, args) =>
    {
      RefreshData();
    });
  }

  public override void RefreshData()
  {
    base.RefreshData();

    manageYourCommunityLBL.Text = Translate.manageyourcommunity;
    manageyourtontineLBL.Text = Translate.manageyourtontine;
    getstartedLBL.Text = Translate.getstarted;
    signinLBL.Text = Translate.signin;
    getprincingLBL.Text = Translate.getpricing;
    //Device.BeginInvokeOnMainThread(async () =>
    //{
    //  await AppUpdate();
    //});
  }

  private async void NavTosGetPricingPage_Tapped(object sender, TappedEventArgs e)
  {
    await Navigation.PushModalAsync(new GetPricingPage());
  }

  private async void NavTosGetStartedFirstPage_Tapped(object sender, TappedEventArgs e)
  {
    await Navigation.PushModalAsync(new GetStart());
  }

  private async void NavTosignInPage_Tapped(object sender, TappedEventArgs e)
  {
    await Navigation.PushModalAsync(new AuthentificationPage());
  }
  //public async Task AppUpdate()
  //{
  //  var t = CrossLatestVersion.Current;
  //  bool isLatest = await t.IsUsingLatestVersion();
  //  if (isLatest)
  //  {

  //  }
  //  else
  //  {
  //    bool result = await Application.Current.MainPage.DisplayAlert(Translate.newversion, Translate.updatemessage, Translate.yes, Translate.no);
  //    if (result)
  //    {
  //      await t.OpenAppInStore();
  //    }

  //  }
  //}

}