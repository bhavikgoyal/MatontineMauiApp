

namespace MatontineDigitalApp.Commons.components.customs
{
  [XamlCompilation(XamlCompilationOptions.Compile)]
  public partial class MySimpleSwitchView : ContentView
	{

    public event EventHandler BtnLeftClicked;
    public event EventHandler BtnCenterClicked;
    public event EventHandler BtnRigthClicked;

    private View currentContent;
    public MySimpleSwitchView()
		{
      InitializeComponent();

      horizontalBtn.BtnLeftClicked += HorizontalBtn_BtnLeftClicked;
      horizontalBtn.BtnCenterClicked += HorizontalBtn_BtnCenterClicked;
      horizontalBtn.BtnRigthClicked += HorizontalBtn_BtnRigthClicked;
    }

    private void HorizontalBtn_BtnLeftClicked(object sender, EventArgs e)
    {
      SetCurrentView(LeftContent);
      BtnLeftClicked?.Invoke(sender, e);
    }

    private void HorizontalBtn_BtnCenterClicked(object sender, EventArgs e)
    {
      SetCurrentView(CenterContent);
      BtnCenterClicked?.Invoke(sender, e);
    }

    private void HorizontalBtn_BtnRigthClicked(object sender, EventArgs e)
    {
      SetCurrentView(RigthContent);
      BtnRigthClicked?.Invoke(sender, e);
    }

    public string BtnLeftText
    {
      get => horizontalBtn.BtnLeftText;
      set => horizontalBtn.BtnLeftText = value;
    }

    public string BtnCenterText
    {
      get => horizontalBtn.BtnCenterText;
      set => horizontalBtn.BtnCenterText = value;
    }

    public string BtnRigthText
    {
      get => horizontalBtn.BtnRigthText;
      set => horizontalBtn.BtnRigthText = value;
    }

    private View _LeftContent;
    public View LeftContent
    {
      get => _LeftContent;
      set
      {
        SetCurrentView(value);
        _LeftContent = value;
      }
    }

    public View CenterContent { get; set; }
    public View RigthContent { get; set; }

    private void SetCurrentView(View v)
    {
      currentContent = v;
      BodyContent.Content = v;
    }
  }
}