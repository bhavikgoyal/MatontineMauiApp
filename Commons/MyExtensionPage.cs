using Acr.UserDialogs;
using MatontineDigitalApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatontineDigitalApp.Commons
{
  public static class MyExtensionPage
  {


    public static View GetTemplateEx(this Page page, View contentView, int padding = 5)
    {

      return new StackLayout
      {
        Padding = new Thickness(padding),
        VerticalOptions = LayoutOptions.StartAndExpand,
        HorizontalOptions = LayoutOptions.FillAndExpand,
        Children =
                        {
                            new ScrollView
                            {
                                Padding = new Thickness(padding),
                                Content = contentView
                            }
                        }
      };

    }

    public static Task<bool> YesNoAlertEx(this Page page, string message)
    {
      return page.DisplayAlert(CommonsResources.AppName, message, Translate.yes, Translate.no);
    }
    public static Task<bool> DeleteCancelAlertEx(this Page page, string message)
    {
      return page.DisplayAlert(CommonsResources.AppName, message, Translate.delete, Translate.cancel);
    }

    public static Task OkAlertEx(this Page page, string message)
    {
      return page.DisplayAlert(CommonsResources.AppName, message, Translate.ok);
    }

    public static void ShowLoadingEx(this Page page)
    {
#if ANDROID
      UserDialogs.Instance.ShowLoading(Translate.loading);
#endif
#if IOS                                                   
      UserDialogs.Instance.ShowLoading(Translate.loading);

#endif
    }

    public static void HideLoadingEx(this Page page)
    {
#if ANDROID
      UserDialogs.Instance.HideLoading();
#endif
#if IOS
      UserDialogs.Instance.HideLoading();
#endif

    }

    public static void httpCallEx(this Page page, Func<Task> funcHttpCall)
    {
      ShowLoadingEx(page);
      //httpCallNoLoadingEx(page, funcHttpCall);

      Action onFinish = () =>
      {
        HideLoadingEx(page);
      };

      MaTontineAPIUtils.httpCall(page, funcHttpCall, onFinish);
    }

    public static void httpCallNoLoadingEx(this Page page, Func<Task> funcHttpCall)
    {
      Action onFinish = () =>
      {
        HideLoadingEx(page);
      };

      MaTontineAPIUtils.httpCall(page, funcHttpCall, onFinish);
    }

    public static bool isTabletEx(this Microsoft.Maui.Controls.Page page)
    {
      return DeviceInfo.Idiom == DeviceIdiom.Tablet;
    }

    public static bool isPhoneEx(this Page page)
    {
      return Device.Idiom == TargetIdiom.Phone;
    }

  }
}
