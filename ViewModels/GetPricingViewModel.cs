using MatontineDigitalApp.Commons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatontineDigitalApp.ViewModels
{
  [XamlCompilation(XamlCompilationOptions.Compile)]
  public class GetPricingViewModel
  {
    #region Command

    private Command _OnImageTappedOne;
    public Command OnImageTappedOne
    {
      get { return _OnImageTappedOne; }
    }

    private Command _OnImageTappedTwo;
    public Command OnImageTappedTwo
    {
      get { return _OnImageTappedTwo; }
    }
    #endregion
    public INavigation Navigation { get; set; }
    public GetPricingViewModel(INavigation navigation)
    {
      Navigation = navigation;
      _OnImageTappedOne = new Command(async () => await OnImageTappedDataOne());
      _OnImageTappedTwo = new Command(async () => await OnImageTappedDataTwo());
    }
    public async Task OnImageTappedDataOne()
    {
      App.Current.MainPage.DisplayAlert("MaTonine", "For only 500 FCFA monthly subscription per member, register on the MaTontine application to do your digital tontine AND subscribe to Tontine ++ for a change to win prizes up to 1,000,000 FCFA.", "OK");
    }
    public async Task OnImageTappedDataTwo()
    {
      App.Current.MainPage.DisplayAlert("MaTonine", "For only 48D monthly subscription,you can have access to our Digital Osusu as well as Osusu ++, with the opportunity to win up to 100,0000D in prizes.", "OK");
    }
  }
}
