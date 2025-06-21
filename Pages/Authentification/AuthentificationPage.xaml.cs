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
using Newtonsoft.Json;

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
	private async void Connexion(string login, string password)
	{
		aiLayout.IsVisible = true;
	
		try
		{
			var credential = new Credentials { plogin = login, ppassword = password };
		
			string jsonResponse = await MaTontineAPIUtils.Instance.Login(credential);
		
			if (string.IsNullOrWhiteSpace(jsonResponse))
			{
			
				await DisplayAlert("API Error", "Received an empty response from the server.", "OK");
				aiLayout.IsVisible = false;
				return;
			}

		
			try
			{
				var profile = JsonConvert.DeserializeObject<UserProfile>(jsonResponse);
				
				if (profile != null && profile.isconnected)
				{
					
					aiLayout.IsVisible = false;
					await App.Current.MainPage.Navigation.PushAsync(new HomePage());
				}
				else
				{
					
					await DisplayAlert("Login Failed", profile?.errormessage ?? "Could not connect.", "OK");
				}
			}
			catch (Newtonsoft.Json.JsonSerializationException serEx)
			{
				
				await DisplayAlert("JSON Serialization Error!", $"Message: {serEx.Message}\n\nPath: {serEx.Path}\nLine: {serEx.LineNumber}, Pos: {serEx.LinePosition}", "OK");
			}
			catch (Newtonsoft.Json.JsonReaderException readEx)
			{
			
				await DisplayAlert("JSON Reader Error!", $"Message: {readEx.Message}\n\nPath: {readEx.Path}\nLine: {readEx.LineNumber}, Pos: {readEx.LinePosition}", "OK");
			}
			catch (Exception deserEx)
			{
			
				await DisplayAlert("Deserialization Error!", $"Message: {deserEx.Message}\n\nJSON was:\n{jsonResponse}", "OK");
			}
		}
		catch (Exception ex)
		{
		
			await DisplayAlert("General Error", ex.Message, "OK");
		}
		finally
		{
			if (aiLayout.IsVisible)
			{
				aiLayout.IsVisible = false;
			}
			
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