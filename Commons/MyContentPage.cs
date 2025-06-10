namespace MatontineDigitalApp.Commons
{
  public partial class MyContentPage : Microsoft.Maui.Controls.ContentPage, IMyPage
  {
    public MyContentPage()
    {
      NavigationPage.SetHasNavigationBar(this, false);
    }

    public virtual void RefreshData()
    {

    }

    public void HideLoading()
    {
      this.HideLoadingEx();
    }

    public void httpCall(Func<Task> httpCall)
    {
      this.httpCallEx(httpCall);
    }

    public void httpCallNoLoading(Func<Task> httpCall)
    {
      this.httpCallNoLoadingEx(httpCall);
    }

    public bool isPhone()
    {
      return this.isPhoneEx();
    }

    public bool isTablet()
    {
      return this.isTabletEx();
    }

    public void ShowLoading()
    {
      this.ShowLoadingEx();
    }
    public Task OkAlert(string message)
    {
      return this.OkAlertEx(message);
    }
    public void MyGenericsNavigationPopAsync()
    {
      App.Current.MainPage.Navigation.PopModalAsync();
    }
  }
}