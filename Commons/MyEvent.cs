using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatontineDigitalApp.Commons
{
  public class MyEvent
  {
    public static readonly string AddNewDataNotification = "AddNewDataNotification";
    public static readonly string EditDataNotification = "EditDataNotification";
    public static readonly string RemoveDataNotification = "RemoveDataNotification";


    public static readonly string P_GENEREAUX_UPDATE = "P_GENEREAUX_UPDATE";
    public static readonly string P_GESTIONNAIRE_UPDATE = "P_GESTIONNAIRE_UPDATE";
    public static readonly string P_SERVICES_UPDATE = "P_SERVICES_UPDATE";


    public static readonly string RefreshData = "RefreshData";
    public static readonly string LanguageChange = "LanguageChange";
    public static readonly string ProfileUpdated = "ProfileUpdated";


    public static void SendRefreshDataEvent()
    {
      MessagingCenter.Send(EventArgs.Empty, MyEvent.RefreshData, "");
    }

    public static void SendLanguageChangeEvent()
    {
      Device.BeginInvokeOnMainThread(() => {
        MessagingCenter.Send(EventArgs.Empty, MyEvent.LanguageChange, "");
      });
    }

    public static void SendProfileUpdatedEvent()
    {
      MessagingCenter.Send(EventArgs.Empty, MyEvent.ProfileUpdated, "");
    }
  }
}
