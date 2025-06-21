using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Maui.Controls;

namespace MatontineDigitalApp.Commons
{
	public class MyContentPage : ContentPage, IMyPage
	{
		public MyContentPage()
		{
			// Hide navigation bar for this page in MAUI
			Shell.SetNavBarIsVisible(this, false);
		}

		public virtual void RefreshData()
		{
			// Implement any refresh logic here
		}

		public bool IsModal()
		{
			if (GetType() == typeof(NavigationPage))
			{
				return Shell.Current.Navigation.ModalStack.Any(p => ((NavigationPage)p).CurrentPage.Equals(this));
			}
			else
			{
				return Shell.Current.Navigation.ModalStack.Any(p => p.Equals(this));
			}
		}

		public Task<Page> MyGenericsNavigationPopAsync()
		{
			if (IsModal())
			{
				return Shell.Current.Navigation.PopModalAsync();
			}

			return Shell.Current.Navigation.PopAsync();
		}

		public View GetTemplate(View contentView, int padding = 5)
		{
			return this.GetTemplateEx(contentView, padding);
		}

		public Task<bool> YesNoAlert(string message)
		{
			return this.YesNoAlertEx(message);
		}

		public Task<bool> DeleteCancelAlert(string message)
		{
			return this.DeleteCancelAlertEx(message);
		}

		public Task OkAlert(string message)
		{
			return this.OkAlertEx(message);
		}

		public void ShowLoading()
		{
			this.ShowLoadingEx();
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

		public bool isTablet()
		{
			return this.isTabletEx();
		}

		public bool isPhone()
		{
			return this.isPhoneEx();
		}

		public Task MyNavigationPopAsync(Page destPage)
		{
			return Task.Run(async () =>
			{
				this.ShowLoadingEx();
				await Shell.Current.Navigation.PushAsync(destPage);
				this.HideLoadingEx();
			});
		}
	}
}
