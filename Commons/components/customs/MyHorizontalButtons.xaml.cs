namespace MatontineDigitalApp.Commons.components.customs
{

  public partial class MyHorizontalButtons : ContentView
  {
    public event EventHandler BtnLeftClicked;
    public event EventHandler BtnCenterClicked;
    public event EventHandler BtnRigthClicked;

    //Button currentBtn;
    BtnLayoutEnum currentBtnLayout = BtnLayoutEnum.LEFT;


    public Command MyLeftBtnCommand { get; }
    public Command MyCenterBtnCommand { get; }
    public Command MyRigthBtnCommand { get; }
    public MyHorizontalButtons()
    {
      InitializeComponent();

      MyLeftBtnCommand = new Command(() =>
      {
        currentBtnLayout = BtnLayoutEnum.LEFT;
        SwitchBtnSelectedColor();
        BtnLeftClicked?.Invoke(currentBtnLayout, EventArgs.Empty);
      });

      MyCenterBtnCommand = new Command(() =>
      {
        currentBtnLayout = BtnLayoutEnum.CENTER;
        SwitchBtnSelectedColor();
        BtnCenterClicked?.Invoke(currentBtnLayout, EventArgs.Empty);
      });

      MyRigthBtnCommand = new Command(() =>
      {
        currentBtnLayout = BtnLayoutEnum.RIGTH;
        SwitchBtnSelectedColor();
        BtnRigthClicked?.Invoke(currentBtnLayout, EventArgs.Empty);
      });

      BindingContext = this;

      btnLeftLayout.IsVisible = false;
      btnCenterLayout.IsVisible = false;
      btnRigthLayout.IsVisible = false;
      RefreshBtnGridCol();
    }

    public void SelectBtn(BtnLayoutEnum btnType)
    {
      currentBtnLayout = btnType;
      SwitchBtnSelectedColor();
    }

    private void RefreshBtnGridCol()
    {
      ToggleGridCol(btnLeftLayout, 0);
      ToggleGridCol(btnCenterLayout, 1);
      ToggleGridCol(btnRigthLayout, 2);
    }

    private void SwitchBtnSelectedColor()
    {
      ToggleSelectedBtnColor(btnLeftLayout, leftLBL, BtnLayoutEnum.LEFT);
      ToggleSelectedBtnColor(btnCenterLayout, centerLBL, BtnLayoutEnum.CENTER);
      ToggleSelectedBtnColor(btnRigthLayout, rigthLBL, BtnLayoutEnum.RIGTH);

    }

    private void ToggleSelectedBtnColor(View v, Label lbl, BtnLayoutEnum t)
    {
      if (t == currentBtnLayout)
      {
        v.BackgroundColor = CommonsResources.primaryColor;
        lbl.FontAttributes = FontAttributes.Bold;
        lbl.TextColor = Colors.White;
      }
      else
      {
        v.BackgroundColor = Colors.Transparent;
        lbl.FontAttributes = FontAttributes.None;
        lbl.TextColor = Colors.Gray;

      }

    }

    private void ToggleGridCol(View v, int colIndex)
    {
      if (v.IsVisible)
      {
        btnGRID.ColumnDefinitions[colIndex].Width = GridLength.Star;
      }
      else
      {
        btnGRID.ColumnDefinitions[colIndex].Width = new GridLength(0);
      }

      this.IsVisible = !(!btnLeftLayout.IsVisible && !btnCenterLayout.IsVisible && !btnRigthLayout.IsVisible);

    }
    public string BtnLeftText
    {
      get => leftLBL.Text;
      set
      {
        leftLBL.Text = value;
        btnLeftLayout.IsVisible = (value != null && value != "");

        ToggleGridCol(btnLeftLayout, 0);
      }
    }
    public string BtnCenterText
    {
      get => centerLBL.Text;
      set
      {
        centerLBL.Text = value;
        btnCenterLayout.IsVisible = (value != null && value != "");

        ToggleGridCol(btnCenterLayout, 1);
      }
    }

    public string BtnRigthText
    {
      get => rigthLBL.Text;
      set
      {
        rigthLBL.Text = value;
        btnRigthLayout.IsVisible = (value != null && value != "");

        ToggleGridCol(btnRigthLayout, 2);
      }
    }

  }
  public enum BtnLayoutEnum
  {
    LEFT,
    CENTER,
    RIGTH
  }
}