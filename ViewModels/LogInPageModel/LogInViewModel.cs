using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatontineDigitalApp.ViewModels.LogInPageModel
{
  public class LogInViewModel
  {
    public INavigation Navigation { get; set; }
    public LogInViewModel(INavigation navigation) 
    {
      Navigation = navigation;
    }
  }
}
