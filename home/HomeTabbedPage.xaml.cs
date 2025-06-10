using MatontineDigitalApp.Commons;
using MatontineDigitalApp.home;
using Microsoft.Maui.Controls.PlatformConfiguration;
using Microsoft.Maui.Controls.PlatformConfiguration.AndroidSpecific;
using TabbedPage = Microsoft.Maui.Controls.TabbedPage;

namespace MatontineDigitalApp.home
{
  public partial class HomeTabbedPage : TabbedPage
  {
    public static readonly BindableProperty IsHiddenProperty = BindableProperty.Create("IsTabHidden", typeof(bool), typeof(HomeTabbedPage), false);
    private MatontineDigitalApp.home.HomePage homePage;
    //private ListServicesPage listServicesPage;
    //private ListMemberPage listMemberPage;
    //private ListServicesTontinePage listServicesTontinePage;
    //private ListServicesOthersPage listServicesOthersPage;

    //public bool IsTabHidden
    //{
    //  set { SetValue(IsHiddenProperty, value); }
    //  get { return (bool)GetValue(IsHiddenProperty); }
    //}

    //public HomeTabbedPage()
    //{                                                                                   
     
    //  Shell.SetNavBarIsVisible(this, false);
    //  NavigationPage.SetHasNavigationBar(this, false);
    //  NavigationPage.SetHasNavigationBar(this, false);
    //  InitializeComponent();
 
    //  InitTab();

    //  UnselectedTabColor = Colors.LightGray;
    //  SelectedTabColor = CommonsResources.primaryColor;

    //  this.CurrentPageChanged += HomeTabbedPage_CurrentPageChanged;

    //  BarBackgroundColor = Colors.White;
    //  On<Microsoft.Maui.Controls.PlatformConfiguration.Android>().SetToolbarPlacement(ToolbarPlacement.Bottom);

    //  IsTabHidden = true;

    //  var refresDataAction = new Action<EventArgs, string>((sender, args) =>
    //  {
    //    homePage.RefreshData();
    //    listServicesPage.RefreshData();
    //    //listMemberPage.RefreshData();
    //    //listServicesTontinePage.RefreshData();
    //    //listServicesOthersPage.RefreshData();

    //    for (var i = 0; i < Children.Count; i++)
    //    {
    //      var newTitle = "";
    //      switch (i)
    //      {
    //        case 0: newTitle = homePage.Title; break;
    //        case 1: newTitle = listServicesPage.Title; break;
    //        //case 2: newTitle = listMemberPage.Title; break;
    //        //case 3: newTitle = listServicesTontinePage.Title; break;
    //        //case 4: newTitle = listServicesOthersPage.Title; break;
    //        default: break;
    //      }

    //      Children.ElementAt(i).Title = newTitle;
    //    }

    //  });

    //  MessagingCenter.Subscribe<EventArgs, string>(this, MyEvent.RefreshData, refresDataAction);
    //  MessagingCenter.Subscribe<EventArgs, string>(this, MyEvent.ProfileUpdated, refresDataAction);
    //  MessagingCenter.Subscribe<EventArgs, string>(this, MyEvent.LanguageChange, refresDataAction);

    //}

    //private void InitTab()
    //{
    //  homePage = new HomePage
    //  {
    //    TabbedPage = this
    //  };
    //  Children.Add(homePage);

    //  //Tab Community
    //  listServicesPage = new ListServicesPage();
    //  Children.Add(new NavigationPage(listServicesPage)
    //  {
    //    Title = listServicesPage.Title,
    //    IconImageSource = listServicesPage.IconImageSource
    //  });

    //  //Tab Members
    //  listMemberPage = new ListMemberPage();
    //  Children.Add(new NavigationPage(listMemberPage)
    //  {
    //    Title = listMemberPage.Title,
    //    IconImageSource = listMemberPage.IconImageSource
    //  });

    //  //Tab Tontine
    //  listServicesTontinePage = new ListServicesTontinePage();
    //  Children.Add(new NavigationPage(listServicesTontinePage)
    //  {
    //    Title = listServicesTontinePage.Title,
    //    IconImageSource = listServicesTontinePage.IconImageSource
    //  });

    //  //Tab Services
    //  listServicesOthersPage = new ListServicesOthersPage();
    //  Children.Add(new NavigationPage(listServicesOthersPage)
    //  {
    //    Title = listServicesOthersPage.Title,
    //    IconImageSource = listServicesOthersPage.IconImageSource
    //  });
    //}

    //public void NavToTab(HomeTabEnum homeTab)
    //{
    //  CurrentPage = Children[(int)homeTab];
    //  Preferences.Remove("CheckBoxInSavingGroup");
    //  if (homeTab == HomeTabEnum.Tontines)
    //  {
    //    Preferences.Set("CheckBoxInSavingGroup", true);
    //  }
    //  else
    //  {
    //    Preferences.Set("CheckBoxInSavingGroup", false);
    //  }
    //}

    //private void HomeTabbedPage_CurrentPageChanged(object sender, EventArgs e)
    //{
    //  var i = this.Children.IndexOf(this.CurrentPage);
    //  System.Diagnostics.Debug.WriteLine("Page No:" + i);

    //  IsTabHidden = (i == 0);
    //  if (i == (int)HomeTabEnum.Tontines)
    //  {
    //    Preferences.Set("CheckBoxInSavingGroup", true);
    //  }
    //  else
    //  {
    //    Preferences.Set("CheckBoxInSavingGroup", false);
    //  }
    //}

    //protected override bool OnBackButtonPressed()
    //{
    //  if (Navigation.NavigationStack.Count <= 1 && Navigation.ModalStack.Count <= 0)
    //  {
    //    Device.BeginInvokeOnMainThread(new Action(async () => {

    //      var currentTabPageIndex = this.Children.IndexOf(this.CurrentPage);
    //      if (currentTabPageIndex == 0)
    //      {
    //        var ok = await MyExtensionPage.YesNoAlertEx(this, Translate.doyouwanttologoutoftheapplication);

    //        if (ok)
    //        {
    //          App.GoToAuthentificationHomePage();
    //        }
    //      }
    //      else
    //      {
    //        this.NavToTab(HomeTabEnum.Home);
    //      }

    //    }));

    //    //Stop the back button
    //    return true;
    //  }
    //  // Continue going back
    //  base.OnBackButtonPressed();
    //  return false;
    //}
  }
}