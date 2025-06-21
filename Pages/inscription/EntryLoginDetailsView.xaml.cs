using MatontineDigitalApp.Commons;
using MatontineDigitalApp.Commons.templates;
using MatontineDigitalApp.Model;
using MatontineDigitalApp.ViewModels;
using System.Diagnostics.Metrics;
using Utils = MatontineDigitalApp.Commons.Utils;

namespace MatontineDigitalApp.Pages.inscription;

public partial class EntryLoginDetailsView : MyDefaultTemplateInfosView
{
	private MyContentPage page;
	private CommunityDto communityDto;
	private Action<string> loginDetailsDataIsValidAction;
	private CountryDto countrie;

	public EntryLoginDetailsView(MyContentPage page, CommunityDto communityDto, Action<string> loginDetailsDataIsValidAction)
	{
		this.page = page;
		this.communityDto = communityDto;
		this.loginDetailsDataIsValidAction = loginDetailsDataIsValidAction;



		loginEntry.Text = string.Empty;
		RefreshData();
	}
		 public override void RefreshData()
	{
		TitleText = Translate.logindetails;
		SubTitleText = Translate.pleaseenteryourlogindetails;

		loginEntry.Title = Translate.login2;
		passwordEntry.Title = Translate.password;
		retypePasswordEntry.Title = Translate.retypepassword;
		mobileNumberEntry.Title = $"{communityDto.CountryIndicatif} {Translate.mobilenumber}";

		countrie = communityDto.GetCountryDto();
		mobileNumberEntry.PhoneNumberBehaviorFormat = countrie?.TelephoneFormat;
	}

	public override bool HasValidData()
	{
		loginEntry.InitMessageError();
		passwordEntry.InitMessageError();
		retypePasswordEntry.InitMessageError();
		mobileNumberEntry.InitMessageError();

		string errorMessage = "";

		if (Utils.IsBlankOrNull(loginEntry.Text))
		{
			loginEntry.InitMessageError(Translate.pleaseenteryourlogin);
			errorMessage += $"{Translate.pleaseenteryourlogin}.\n";
		}

		if (Utils.IsBlankOrNull(passwordEntry.Text))
		{
			passwordEntry.InitMessageError(Translate.pleaseenteryourpassword);
			errorMessage += $"{Translate.pleaseenteryourpassword}.\n";
		}

		if (!Utils.IsBlankOrNull(passwordEntry.Text) && passwordEntry.Text != retypePasswordEntry.Text)
		{
			passwordEntry.InitMessageError(Translate.passwordisnotthesame);
			retypePasswordEntry.InitMessageError(Translate.passwordisnotthesame);
			errorMessage += $"{Translate.passwordisnotthesame}.\n";
		}

		if (Utils.IsBlankOrNull(mobileNumberEntry.Text))
		{
			mobileNumberEntry.InitMessageError(Translate.pleaseenteryourmobilenumber);
			errorMessage += $"{Translate.pleaseenteryourmobilenumber}.\n";
		}

		if (!Utils.IsBlankOrNull(mobileNumberEntry.Text))
		{
			var t = mobileNumberEntry.GetClearText();
			if (countrie != null && countrie.TelephoneLength != t.Length)
			{
				mobileNumberEntry.InitMessageError(Translate.incorrectphonenumber);
				errorMessage += $"{Translate.incorrectphonenumber}.\n";
			}
		}

		if (!string.IsNullOrWhiteSpace(errorMessage))
		{
			//throw new ValidationMessageException(errorMessage);
		}

		communityDto.plogin = loginEntry.Text;
		communityDto.ppassword = passwordEntry.Text;
		communityDto.Telephone = mobileNumberEntry.Text;

		DoHttpValidation();

		return false;
	}

	private void DoHttpValidation()
	{
		page.httpCall(async () =>
		{
			var req = new Credentials
			{
				plogin = communityDto.plogin,
				ppassword = communityDto.ppassword,
				ptelephone = communityDto.Telephone,
				plangue = MyTranslator.CurrentLanguageCD
			};

			var response = await MaTontineAPIUtils.Instance.ValidationLoginAndTelephone(req);

			await page.OkAlert(response.message);

			if (!response.error && !string.IsNullOrEmpty(response.smscode))
			{
				loginDetailsDataIsValidAction?.Invoke(response.smscode);
			}
		});
	}
}
