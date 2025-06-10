using MatontineDigitalApp.Commons;
using MatontineDigitalApp.Pages.Signin;

namespace MatontineDigitalApp.home 
{
  [XamlCompilation(XamlCompilationOptions.Compile)]
  public partial class HomePage : MyContentPageWithTemplate
  {
    public HomeTabbedPage TabbedPage { get; set; }

    public static readonly BindableProperty WelcomeMessageProperty = BindableProperty.Create(nameof(WelcomeMessage), typeof(string), typeof(HomePage), "Welcome Back!");
    public string WelcomeMessage { get => (string)GetValue(WelcomeMessageProperty); set { SetValue(WelcomeMessageProperty, value); welcomeLbl.Text = value; } }

    public static readonly BindableProperty LocationMessageProperty = BindableProperty.Create(nameof(LocationMessage), typeof(string), typeof(HomePage), "Location");
    public string LocationMessage { get => (string)GetValue(LocationMessageProperty); set { SetValue(LocationMessageProperty, value); regionCuntryLbl.Text = value; } }

    public HomePage()
    {
      InitializeComponent();
      //MyTemplate.HideNavBtn = true;
      Shell.SetNavBarIsVisible(this, false);
      communityMenuItem.HomeTab = HomeTabEnum.Community;
      membersMenuItem.HomeTab = HomeTabEnum.Members;
      reportingMenuItem.HomeTab = HomeTabEnum.Tontines;
      servicesMenuItem.HomeTab = HomeTabEnum.Services;

      RefreshData();

    }
    public override void RefreshData()
    {
      base.RefreshData();
      //Title = Translate.home;

      welcomeLbl.Text = Translate.welcomeback + " " + CommonsResources.ConnectedUser.profile_name + "!";
      regionCuntryLbl.Text = CommonsResources.ConnectedUser.ProfileDispalyRegionCuntry;

      MyTemplate.SubjectText = "";
      MyTemplate.TitleText = "";
      MyTemplate.SubTitleText = "";
      MyTemplate.HideNavBtn = true;

      communityMenuItem.Title = Translate.community;
      membersMenuItem.Title = Translate.members;
      reportingMenuItem.Title = Translate.tontines;
      servicesMenuItem.Title = Translate.services;

      profileMenuItem.Title = Translate.profile;
      contactMenuItem.Title = Translate.contact;
      logoutMenuItem.Title = Translate.logout;

      MyTemplate.RefreshTemplateCircleImage();
    }

    protected override void OnAppearing()
    {
      base.OnAppearing();           
    }

    protected override void OnApplyTemplate()
    {
      base.OnApplyTemplate();

      if (GetTemplateChild("BackButtonContainer") is Layout backLayout)
      {
        backLayout.IsVisible = false;

      }

      if (GetTemplateChild("NextButtonContainer") is Border nextBorder)
      {
        nextBorder.IsVisible = false;
      }
    }
  }
}