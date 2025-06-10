using MatontineDigitalApp.Commons;
using MatontineDigitalApp.Pages.About;
using MatontineDigitalApp.Pages.Authentification;
using MatontineDigitalApp.Pages.GetStarted;
using MatontineDigitalApp.Pages.Signin;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace MatontineDigitalApp.ViewModels
{
  public class AuthentificationHomeViewModel : INotifyPropertyChanged
  {
    public event PropertyChangedEventHandler PropertyChanged;
    protected virtual void NotifyPropertyChanged([CallerMemberName] string propertyName = null)
    {
      PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
    #region
    private string _signin;
    public string signin
    {
      get
      {
        return _signin;
      }
      set
      {
        _signin = value;
        NotifyPropertyChanged(nameof(signin));
      }
    }


    private string _getstarted;
    public string getstarted
    {
      get
      {
        return _getstarted;
      }
      set
      {
        _getstarted = value;
        NotifyPropertyChanged(nameof(getstarted));
      }
    }
    private string _getpricing;
    public string getpricing
    {
      get
      {
        return _getpricing;
      }
      set
      {
        _getpricing = value;
        NotifyPropertyChanged(nameof(getpricing));
      }
    }
    #endregion

    #region

    private Command _getPricingCommand;
    public Command getPricingCommand
    {
      get { return _getPricingCommand; }
    }

    private Command _getStartedCommand;
    public Command getStartedCommand
    {
      get { return _getStartedCommand; }
    }

    private Command _signinCommand;
    public Command signinCommand
    {
      get { return _signinCommand; }
    }
    #endregion

    private INavigation Navigation { get; set; }
    public AuthentificationHomeViewModel(INavigation navigation)
    {
      Navigation = navigation;
      signin = Translate.signin;
      getpricing = Translate.getpricing;
      getstarted = Translate.getstarted;

      _getPricingCommand = new Command(async () => await PricingCommandData());
      _getStartedCommand = new Command(async () => await StartedCommandData());
      _signinCommand = new Command(async () => await signinCommandData());
    }

    private async Task PricingCommandData()
    {
      await Navigation.PushModalAsync(new GetPricingPage());
    }
    private async Task StartedCommandData()
    {
      await Navigation.PushModalAsync(new GetStart());
    }
    private async Task signinCommandData()
    {
      await Navigation.PushModalAsync(new AuthentificationPage());
    }
  }
}
