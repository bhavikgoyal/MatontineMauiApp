using MatontineDigitalApp.Commons;
using MatontineDigitalApp.Model;
using MatontineDigitalApp.Pages.Signin;
using Plugin.Fingerprint.Abstractions;
using Plugin.Fingerprint;
using MatontineDigitalApp.ViewModels.LogInPageModel;
using MatontineDigitalApp.Services;
using MatontineDigitalApp.ViewModels;
using MatontineDigitalApp.home;
using ContentPage = Microsoft.Maui.Controls.ContentPage;

namespace MatontineDigitalApp.Pages.Authentification;

public partial class AuthentificationPage : ContentPage
{
  public static readonly BindableProperty SubjectLabelProperty =
     BindableProperty.Create(nameof(SubjectLabel), typeof(string), typeof(LoginHome), default(string));

  private bool fingerPrintExist;
  private ParameterEntity _parameter;

  public string SubjectLabel
  {
    get => (string)GetValue(SubjectLabelProperty);
    set => SetValue(SubjectLabelProperty, value);
  }
  public AuthentificationPage()
	{
		InitializeComponent();
    useFingerPrintLBL.Text = Translate.usefingerprintnexttime;
    rememberMeLBL.Text = Translate.rememberme;
    this._parameter = MyDB.Instance.GetParameterAsync().Result;
    if (this._parameter == null)
    {
      this._parameter = new ParameterEntity();
    }
    if (_parameter.rememberMe)
    {
      loginEntry.Text = _parameter.login;
      passwordEntry.Text = _parameter.password;
      rememberMeCheckBox.IsChecked = true;
    }

    Device.BeginInvokeOnMainThread(new Action(async () =>
    {
      await InitFingerprintProcessAsync();

    }));
    BindingContext = new LogInViewModel(Navigation);
  }

  private async Task InitFingerprintProcessAsync()
  {
    aiLayout.IsVisible = true;
    var availability = await CrossFingerprint.Current.GetAvailabilityAsync(true);

    this.fingerPrintExist =
        availability == FingerprintAvailability.Available
           || availability == FingerprintAvailability.NoPermission;


    useFingerPrintSL.IsVisible = fingerPrintExist;


    if (!_parameter.useFingerPrint)
    {
      aiLayout.IsVisible = false;
      return;
    }


    useFingerPrintCheckBox.IsChecked = true;

    var request = new AuthenticationRequestConfiguration(CommonsResources.AppName, Translate.logintoyouraccount);
    var result = await CrossFingerprint.Current.AuthenticateAsync(request);

    aiLayout.IsVisible = false;
    if (result.Authenticated)
    {
      aiLayout.IsVisible = true;
      Connexion(_parameter.login, _parameter.password);
    }

  }

  protected override void OnAppearing()
  {
    base.OnAppearing();
    SubjectLabel = "Community Management";
    lblLoading.Text = Translate.loading;
  }

  protected override void OnApplyTemplate()
  {
    base.OnApplyTemplate();

    if (GetTemplateChild("BackButtonContainer") is Layout backLayout)
    {
      var existingRecognizer = backLayout.GestureRecognizers.FirstOrDefault(g => g is TapGestureRecognizer) as TapGestureRecognizer;
      if (existingRecognizer == null)
      {
        var tapGestureRecognizer = new TapGestureRecognizer();
        tapGestureRecognizer.Tapped += OnBackButtonClicked;
        backLayout.GestureRecognizers.Add(tapGestureRecognizer);
      }
      else
      {
        existingRecognizer.Tapped -= OnBackButtonClicked;
        existingRecognizer.Tapped += OnBackButtonClicked;
      }

      backLayout.IsVisible = true;

    }

    if (GetTemplateChild("NextButtonContainer") is Border nextBorder)
    {
      var existingRecognizer = nextBorder.GestureRecognizers.FirstOrDefault(g => g is TapGestureRecognizer) as TapGestureRecognizer;
      if (existingRecognizer == null)
      {
        var tapGestureRecognizer = new TapGestureRecognizer();
        tapGestureRecognizer.Tapped += OnNextButtonClicked;
        nextBorder.GestureRecognizers.Add(tapGestureRecognizer);
      }
      else
      {
        existingRecognizer.Tapped -= OnNextButtonClicked;
        existingRecognizer.Tapped += OnNextButtonClicked;
      }
    }
  }

  private async void OnNextButtonClicked(object sender, TappedEventArgs e)
  {
    aiLayout.IsVisible = true;
    string textLogin = loginEntry.Text;
    string textPassword = passwordEntry.Text;



    if (string.IsNullOrWhiteSpace(textLogin) || string.IsNullOrWhiteSpace(textPassword))
    {
      if (string.IsNullOrWhiteSpace(textLogin))
        App.Current.MainPage.DisplayAlert("MaTontine", Translate.pleaseenteryourloginandpassword, "Ok");

      if (string.IsNullOrWhiteSpace(textPassword))
        App.Current.MainPage.DisplayAlert("MaTontine", Translate.pleaseenteryourloginandpassword, "Ok");
      aiLayout.IsVisible = false;
      return;
    }
    Connexion(textLogin, textPassword);
  }
  //private async void Connexion(string login, string password)
  //{
  //  try
  //  {
  //    var credential = new Credentials { plogin = login, ppassword = password };
  //    aiLayout.IsVisible = true;
  //    var profile = await MaTontineAPIUtils.Instance.Login(credential);

  //    if (profile.isconnected)
  //    {
  //      credential.plangue = profile.langue;
  //      Preferences.Set("UserLG", profile.langue);
  //      Preferences.Set("GESTIONNAIREID", profile.profile_community_id);
  //      if (profile != null &&
  //     profile.ListMembers != null &&
  //     profile.ListMembers.Count > 0 &&
  //     profile.ListMembers[0] != null &&
  //     profile.ListMembers[0].ListContributionHistory != null &&
  //     profile.ListMembers[0].ListContributionHistory.Count > 0 &&
  //     profile.ListMembers[0].ListContributionHistory[0] != null &&
  //     !string.IsNullOrEmpty(profile.ListMembers[0].ListContributionHistory[0].ServiceCode))
  //      {
  //        Preferences.Set("GROUPNAME", profile.ListMembers[0].ListContributionHistory[0].ServiceCode);
  //      }

  //      Preferences.Remove("MGAINCOUNTS");
  //      if (profile.ListMgains != null)
  //      {
  //        Preferences.Set("LASTDRAWDATE", profile.ListMgains[0].dategain);
  //        Preferences.Set("MGAINCOUNTS", profile.ListMgains.Count);
  //      }
  //      Preferences.Set("AUTOPAY", profile.autopay);
  //      CommonsResources.ConnectedUser = profile;
  //      CommonsResources.credentials = credential;

  //      await MyDB.Instance.SaveParameterAsync(rememberMeCheckBox.IsChecked, useFingerPrintCheckBox.IsChecked, credential);

  //      if (credential.plangue != MyTranslator.CurrentLanguageCD)
  //      {
  //        await MaTontineAPIUtils.GetTranslateData(this, null, credential.plangue);

  //        //var translateData = await MaTontineAPIUtils.Instance.GetTranslateData(credential);
  //        //MyTranslator.InitTranslateData(translateData, credential.plangue);
  //      }
  //      var listData = await MaTontineAPIUtils.Instance.GetListData(CommonsResources.credentials);
  //      if (listData != null)
  //      {
  //        CommonsResources.listData = listData;
  //      }
  //      aiLayout.IsVisible = false;
  //      App.Current.MainPage.Navigation.PushAsync(new HomeTabbedPage());
  //    }
  //    else
  //    {
  //      await DisplayAlert(CommonsResources.AppName, profile.errormessage,
  //          Translate.ok);
  //    }
  //  }
  //  catch (Exception ex)
  //  {
  //    aiLayout.IsVisible = false;
  //    await DisplayAlert(CommonsResources.AppName, ex.Message, Translate.ok);
  //  }
  //  finally
  //  {
  //    aiLayout.IsVisible = false;
  //  }
  //}


  private async void Connexion(string login, string password)
  {
    try
    {
      aiLayout.IsVisible = true;

      // Set default language and dummy user data
      Preferences.Set("UserLG", "fr");
      Preferences.Set("GESTIONNAIREID", "test-id");
      Preferences.Set("GROUPNAME", "test-group");
      Preferences.Set("AUTOPAY", false);
      Preferences.Set("MGAINCOUNTS", 0);

      // Create dummy user profile
      CommonsResources.ConnectedUser = new UserProfile
      {
        isconnected = true,
        langue = "fr",
        profile_community_id = "test-id",
        ListMembers = new List<MemberDto>(),
        ListMgains = new List<MgainsDto>(),
        autopay = false
      };

      CommonsResources.credentials = new Credentials
      {
        plogin = login,
        ppassword = password,
        plangue = "fr"
      };

      // Save parameters locally
      await MyDB.Instance.SaveParameterAsync(
          rememberMeCheckBox.IsChecked,
          useFingerPrintCheckBox.IsChecked,
          CommonsResources.credentials);

      aiLayout.IsVisible = false;

      // Navigate to home page directly
      await App.Current.MainPage.Navigation.PushAsync(new HomePage());
    }
    catch (Exception ex)
    {
      await DisplayAlert(CommonsResources.AppName, ex.Message, Translate.ok);
    }
    finally
    {
      aiLayout.IsVisible = false;
    }
  }

  private async void OnBackButtonClicked(object sender, TappedEventArgs e)
  {
    try
    {

      await App.Current.MainPage.Navigation.PopModalAsync();

    }
    catch (Exception ex)
    {
      System.Diagnostics.Debug.WriteLine($"Navigation Error: {ex.Message}");
    }
  }
}