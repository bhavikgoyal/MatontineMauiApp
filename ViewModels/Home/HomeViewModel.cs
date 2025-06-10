using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatontineDigitalApp.ViewModels.Home
{
  public class HomeViewModel
  {
    public INavigation Navigation { get; set; }
    public HomeViewModel(INavigation navigation)
    {
      Navigation = navigation;
    }
  }
}
