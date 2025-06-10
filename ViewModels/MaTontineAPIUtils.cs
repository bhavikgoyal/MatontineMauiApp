using MatontineDigitalApp.Commons;
using MatontineDigitalApp.Model;
using MatontineDigitalApp.native;
using MatontineDigitalApp.Services;
using Plugin.Connectivity;
using Refit;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using ContentPage = Microsoft.Maui.Controls.ContentPage;

namespace MatontineDigitalApp.ViewModels
{
  public class MaTontineAPIUtils
  {
    private static readonly string BASE_URL = "https://matontine.online:85/WebService.asmx";


    // " http://demoapi.visitmydemo.com/WebService.asmx";

    public static string DOWNLOAD_URL = BASE_URL + "/MaTontineReporting?plogin={0}&ppassword={1}&preporting={2}&pfiletype={3}" +
        "&pgestionnaire={4}&pservice={5}&pmembre={6}&pgroupe={7}";

    private static readonly Lazy<IMaTontineAPI> lazy =
        new Lazy<IMaTontineAPI>(() => getInstance());

    public static NetworkAccess accessType = Connectivity.Current.NetworkAccess;
    private static IMaTontineAPI getInstance()
    {
      var httpClient = new HttpClient(new HttpLoggingHandler())
      {
        BaseAddress = new Uri(BASE_URL)
      };
      return RestService.For<IMaTontineAPI>(httpClient);
    }

    public static IMaTontineAPI Instance
    {
      get
      {
        return lazy.Value;
      }
    }

    public static void downloadReportFile(string reporting, string fileType, string groupe, string communauteFilter, string serviceFilter, string membreFilter)
    {
      var url = string.Format(DOWNLOAD_URL,
          CommonsResources.credentials.plogin,
          CommonsResources.credentials.ppassword,
          reporting,
          fileType,
          communauteFilter,
          serviceFilter,
          membreFilter,
          groupe);
      downloadFile(url);
    }

    public static void downloadFile(string fileUrl)
    {
      INativeCustom nativeUssd = DependencyService.Get<INativeCustom>();
      nativeUssd.download(fileUrl);
    }

    public static Task GetTranslateData(ContentPage page, Action onFinish = null, string planguage = null)
    {
      return Task.Run(() => {

        var languageCode = "";

        if (string.IsNullOrEmpty(planguage))
        {
          if (string.IsNullOrEmpty(CommonsResources.credentials?.plangue))
          {
            languageCode = CommonsResources.getSystemLanguage();
          }
          else
          {
            languageCode = CommonsResources.credentials.plangue;
          }
        }
        else
        {
          languageCode = planguage;
        }

        /*if (true)
        {
            if (onFinish != null) onFinish();
            return;
        }*/

        Func<Task> httpCall = async () =>
        {
          var listData = await MaTontineAPIUtils.Instance.GetTranslateData(new Credentials { plangue = languageCode });
          //MyTranslator.InitTranslateData(listData, languageCode);
          MyEvent.SendLanguageChangeEvent();
        };

        MaTontineAPIUtils.httpCall(page, httpCall, onFinish);

      });
    }

    public static void InjectCredentials(Credentials req)
    {
      req.plogin = CommonsResources.credentials.plogin;
      req.ppassword = CommonsResources.credentials.ppassword;
    }

    public async static void httpCall(Page page, Func<Task> httpCall, Action onFinish = null)
    {
      try
      {
        if (CrossConnectivity.Current.IsConnected)
        {
          await httpCall();
        }
        else
        {
          var langue = CultureInfo.CurrentUICulture.TwoLetterISOLanguageName;
          var m = langue == "FR" ? "Veuillez vérifier la connexion internet." : "Please check the internet connection.";
          await page.DisplayAlert(CommonsResources.AppName, m, "Ok");
        }
      }
      catch (Exception ex)
      {
        System.Diagnostics.Debug.WriteLine(ex.Message);
        System.Diagnostics.Debug.WriteLine(ex.StackTrace);
        await page.DisplayAlert("HttpCall EROOR", ex.Message, "Ok");
      }
      if (onFinish != null)
      {
        Device.BeginInvokeOnMainThread(() => {
          onFinish();
        });
      }
    }

  }
}
