using MatontineDigitalApp.Commons;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace MatontineDigitalApp.ViewModels
{
  public class MainPageViewModel : INotifyPropertyChanged
  {
    public event PropertyChangedEventHandler PropertyChanged;
    protected virtual void NotifyPropertyChanged([CallerMemberName] string propertyName = null)
    {
      PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
    #region
    private string _lblManage;
    public string lblManage
    {
      get
      {
        return _lblManage;
      }
      set
      {
        _lblManage = value;
        NotifyPropertyChanged(nameof(lblManage));
      }
    }

    private string _lblgroupsdigitally;
    public string lblgroupsdigitally
    {
      get
      {
        return _lblgroupsdigitally;
      }
      set
      {
        _lblgroupsdigitally = value;
        NotifyPropertyChanged(nameof(lblgroupsdigitally));
      }
    }
    #endregion

    private INavigation Navigation { get; set; }
    public MainPageViewModel(INavigation navigation)
    {
      Navigation = navigation;
      lblManage = Translate.manage;
      lblgroupsdigitally = Translate.groupsdigitally;
    }
  }
}
