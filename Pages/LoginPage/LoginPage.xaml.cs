using CommunityToolkit.Maui.Views;
using MatontineDigitalApp.Commons;
using MatontineDigitalApp.ViewModels;
using MatontineDigitalApp.ViewModels.LoginPage;

namespace MatontineDigitalApp.Pages.LoginPage
{
	public partial class LoginPage : MyContentPage
	{
		public LoginPage()
		{
			//InitializeComponent();
			BindingContext = new LoginPageViewModel();
		}

		protected override void OnAppearing()
		{
			base.OnAppearing();
			if (!BaseViewModel.offlineModel && BaseViewModel.accessType != NetworkAccess.Internet)
			{
				CheckInternetAccessOrNot();
			}
		}

		private void CheckInternetAccessOrNot()
		{





		}
	}
}
