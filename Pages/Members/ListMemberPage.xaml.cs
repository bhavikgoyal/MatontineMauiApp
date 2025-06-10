using MatontineDigitalApp.Model;
using MatontineDigitalApp.ViewModels.MemberView;
using System.Collections.ObjectModel;

namespace MatontineDigitalApp.Pages.Members;

public partial class ListMemberPage : ContentPage
{
    public ObservableCollection<MemberDto> MyItems { get; } = new ObservableCollection<MemberDto>();
    public bool DeleteBtnIsVisible { get; set; } = true;

    public event EventHandler<MemberDto> MemberSelected;
    public event EventHandler<MemberDto> MemberSelectedForDeletion;
    public event EventHandler<MemberDto> MemberSelectedForPayment;
    //public string Updatelbl { get; set; } = Translate.update;
    public Command<MemberDto> MyCommand { get; }
    public Command<MemberDto> MyDeleteCommand { get; }
    public Command<MemberDto> MyPaymentCommand { get; }
    public ListMemberPage()
	  {
		    InitializeComponent();
        BindingContext = new MemberViewModel(Navigation);
        //MyCommand = new Command<MemberDto>((obj) => {
        //    var item = obj;
        //    MemberSelected?.Invoke(this, item);
        //    //System.Diagnostics.Debug.WriteLine("Member Selected: " + item.DisplayName);
        //});

        //MyDeleteCommand = new Command<MemberDto>((obj) => {
        //    var item = obj;
        //    MemberSelectedForDeletion?.Invoke(this, item);
        //    //System.Diagnostics.Debug.WriteLine("Member Selected For Deletion: " + item.DisplayName);
        //});

        //MyPaymentCommand = new Command<MemberDto>((obj) => {
        //    var item = obj;
        //    MemberSelectedForPayment?.Invoke(this, item);
        //    System.Diagnostics.Debug.WriteLine("Member Selected For Payment");
        //});

        //BindingContext = this;
    }

    public List<MemberDto> ItemsData
    {
        set
        {
            //bool AUTOPAY = Preferences.Get("AUTOPAY", false);
            //bool checkBox = Preferences.Get("CheckBoxInSavingGroup", false);
            MyItems.Clear();
            foreach (var item in value)
            {
                //item.IsAutopayEnabled = checkBox && !AUTOPAY;
                //IsAutopayEnabledButton.IsVisible = checkBox && !AUTOPAY;
                //item.CanSelect = !item.paymentcheck;
                //if (!item.CanSelect)
                //    item.IsSelected = true;
                MyItems.Add(item);
            }
        }
    }
}