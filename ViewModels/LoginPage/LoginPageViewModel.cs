using MatontineDigitalApp.Commons;
using MatontineDigitalApp.home;
using MatontineDigitalApp.Model;
using MatontineDigitalApp.Services;
using Microsoft.Maui.Controls; // Needed for Command
using System;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Windows.Input;
using Microsoft.Maui.Storage; // For Preferences
using System.Diagnostics;
using Refit;
using System.Xml.Serialization;

namespace MatontineDigitalApp.ViewModels.LoginPage
{
	public class LoginPageViewModel : INotifyPropertyChanged
	{
		private string _plogin;
		public string Plogin
		{
			get => _plogin;
			set { _plogin = value; OnPropertyChanged(); }
		}

		private string _ppassword;
		public string Ppassword
		{
			get => _ppassword;
			set { _ppassword = value; OnPropertyChanged(); }
		}

		private bool _rememberMe;
		public bool RememberMe
		{
			get => _rememberMe;
			set { _rememberMe = value; OnPropertyChanged(); }
		}

		private bool _useFingerPrint;
		public bool UseFingerPrint
		{
			get => _useFingerPrint;
			set { _useFingerPrint = value; OnPropertyChanged(); }
		}

		private bool _isBusy;
		public bool IsBusy
		{
			get => _isBusy;
			set { _isBusy = value; OnPropertyChanged(); }
		}

		public ICommand SubmitCommand { get; }

		public LoginPageViewModel()
		{
			//SubmitCommand = new Command(async () => await Connexion());
		}
		//private async Task Connexion()
		//{
		//	try
		//	{
		//		IsBusy = true;

		//		var credentials = new Credentials
		//		{
		//			plogin = Plogin,
		//			ppassword = Ppassword
		//		};

		//		var profile = await MaTontineAPIUtils.Login(credentials);

		//		if (profile.isconnected)
		//		{
		//			await Shell.Current.GoToAsync("//HomeTabbedPage");
		//		}
		//		else
		//		{
		//			await Application.Current.MainPage.DisplayAlert("Login Failed", profile.errormessage, "OK");
		//		}
		//	}
		//	catch (Exception ex)
		//	{
		//		await Application.Current.MainPage.DisplayAlert("Error", ex.Message, "OK");
		//	}
		//	finally
		//	{
		//		IsBusy = false;
		//	}
		//}



		public event PropertyChangedEventHandler PropertyChanged;
		protected void OnPropertyChanged([CallerMemberName] string name = null) =>
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
	}
}
