using MatontineDigitalApp.Commons;
using MatontineDigitalApp.Model;
using MatontineDigitalApp.Pages.Authentification;
using MatontineDigitalApp.ViewModels;

[assembly: ExportFont("MaterialIconsRegular.ttf", Alias = "Material")]
[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace MatontineDigitalApp
{
  public partial class App : Application
  {
    CommunityDto communityDto = new CommunityDto();
    public App()
    {
      InitializeComponent();
      getTranslateData();
      MainPage = new AppShell();
      CommonsResources.PutTestData();
    }

    protected override async void OnStart()
    {
      await getTranslateData(); 
    }
    public static async Task getTranslateData()
    {
      try
      {
        if (Connectivity.Current.NetworkAccess == NetworkAccess.Internet)
        {
          var traductionData = await MaTontineAPIUtils.Instance.GetTranslateData(CommonsResources.credentials);
          //MyTranslator.InitTranslateData(traductionData, CommonsResources.credentials.plangue);
          Commons.CommonsResources.listData = await MaTontineAPIUtils.Instance.GetListData(CommonsResources.credentials);
        }
        else
        {
          System.Diagnostics.Debug.WriteLine("INFO: No internet access. Attempting to load translations locally.");
        }
      }
      catch (Exception ex)
      {
        System.Diagnostics.Debug.WriteLine($"Error in getTranslateData: {ex}");
      }
    }
    private void OnBackTapped(object sender, TappedEventArgs e)
    {

    }
    public static void GoToAuthentificationHomePage()
    {
      Application.Current.MainPage = new NavigationPage(new AuthentificationPage());
    }
  }
}
