using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatontineDigitalApp.Commons
{
  public interface IMyPage
  {
    void ShowLoading();
    void HideLoading();

    void httpCall(Func<Task> httpCall);
    void httpCallNoLoading(Func<Task> httpCall);

    bool isTablet();

    bool isPhone();
  }
}
