using MatontineDigitalApp.Commons;
using MatontineDigitalApp.Commons.templates;
using MatontineDigitalApp.Model;

namespace MatontineDigitalApp.Pages.inscription;

public partial class InscriptionMasterPage : ContentPage
{
		private CommunityDto communityDto;
		private MyCustomViewStepNavigator stepNavigator = new MyCustomViewStepNavigator();
		//private CreateCommunityPage createCommunityPage;

		public InscriptionMasterPage()
		{
			//InitializeComponent();

			////InitStepView();
			//template.RigthBtnClicked += Template_RigthBtnClicked;
			//template.LeftBtnClicked += Template_LeftBtnClicked;


			MessagingCenter.Subscribe<EventArgs, string>(this, MyEvent.LanguageChange, (sender, args) =>
			{
				stepNavigator.RefresLanguageData();
				stepNavigator.ForEach((v) => {
					v.View.SubjectText = Translate.createyouraccount;
					v.View.RigthBtnText = Translate.next;
				});

			});

		}

		//private void InitStepView()
		//{
		//	communityDto = new CommunityDto();

		//	stepNavigator = new MyCustomViewStepNavigator
		//	{
		//		Template = template
		//	};

		//	AddViewToNav("STEP01", new SelectLanguageView(this,
		//			(code, descr) => {
		//				communityDto.LanguageCode = code;
		//				communityDto.LanguageDescription = descr;
		//			},
		//			() => {
		//				stepNavigator.Next();
		//			}
		//	));

		//	var regionView = new SelectRegionView(this, () => communityDto.CountryCode,
		//	(e) =>
		//	{
		//		communityDto.RegionCode = e.Code;
		//		communityDto.RegionDescription = e.Description;
		//	});

		//	AddViewToNav("STEP02", new SelectContryView(this, (c) => {
		//		communityDto.Country = c;
		//		communityDto.RegionCode = null;
		//		communityDto.RegionDescription = null;
		//		regionView.ResetItemSelected();
		//	}));

		//	AddViewToNav("STEP03", regionView);

		//	//AddViewToNav("STEP04", new EntryMobileNumber(communityDto));

		//	AddViewToNav("STEP05", new EntryLoginDetailsView(this, communityDto, (otpSmsCode) => {
		//		communityDto.OtpSmSCode = otpSmsCode;
		//		stepNavigator.Next();
		//	}));

		//	AddViewToNav("STEP06", new EntryOtpView(communityDto));
		//	AddViewToNav("STEP07", new SelectPartenerView(communityDto));
		//	AddViewToNav("STEP08", new EntryManagerPersonalDetailsView(communityDto));

		//	AddViewToNav("STEP09", new SelectGenderView((code, descr) => {
		//		communityDto.Genre = code;
		//		communityDto.GenreDescription = descr;
		//		template.RefreshTemplateCircleImage(code);
		//	}));

		//	AddViewToNav("STEP10", new EntryPieceIdentiteView(() => communityDto.CountryCode, (type, descr, num) => {
		//		communityDto.TypePieceIdentite = type;
		//		communityDto.TypePieceIdentiteDescription = descr;
		//		communityDto.NumeroPieceIdentite = num;
		//	}));

		//	AddViewToNav("STEP11", new VerifyMangerDetailsView(communityDto), Translate.confirm);

		//	stepNavigator.Start();
		//}

		private void AddViewToNav(string s, MyDefaultTemplateInfosView v, string rightBtnText = null)
		{
			v.SubjectText = Translate.createyouraccount;
			if (rightBtnText != null)
			{
				v.RigthBtnText = rightBtnText;
			}
			stepNavigator.Add(new MyCustomViewStep(s, v));
		}

		private void Template_LeftBtnClicked(object sender, EventArgs e)
		{

			if (stepNavigator.IsFirstStep())
			{
				Navigation.PopAsync();
			}
			else
			{
				stepNavigator.Prev();
			}

		}

		//private CreateCommunityPage GetCreateCommunityPage()
		//{
		//	if (createCommunityPage is null)
		//	{
		//		createCommunityPage = new CreateCommunityPage(communityDto);
		//	}

		//	return createCommunityPage;
		//}

		private async void Template_RigthBtnClicked(object sender, EventArgs e)
		{
			//try
			//{
			//	if (!stepNavigator.CurrentStepIsValid())
			//	{
			//		return;
			//	}

			//															 if (stepNavigator.IsLastStep())
			//	{
			//		await Navigation.PushAsync(GetCreateCommunityPage());
			//	}
			//	else
			//	{
			//		stepNavigator.Next();
			//	}
			//}
			//catch (ValidationMessageException ex)
			//{
			//	await OkAlert(ex.Message);
			//}

		}

}
