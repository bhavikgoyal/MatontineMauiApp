namespace MatontineDigitalApp.Commons.templates
{
  [ContentProperty("Child")]
  [XamlCompilation(XamlCompilationOptions.Compile)]
  public partial class MyDefaultTemplate : ContentView
  {
    public event EventHandler RigthBtnClicked;
    public event EventHandler LeftBtnClicked;
    private bool itemIsTapped = false;

    public MyDefaultTemplate()
    {
      InitializeComponent();
      RefreshTemplateCircleImage();
    }

    public void RefreshTemplateCircleImage(string gender = null)
    {
      bool? isWoman = CommonsResources.ConnectedUser?.IsWoman;
      if (gender != null)
      {
        isWoman = CommonsResources.IsWoman(gender);
      }

      if ((bool)isWoman)
      {
        subjectIMG.Source = "favatarwhiteback.png";
      }
      else
      {
        subjectIMG.Source = "mavatarwhiteback.png";
      }
    }

    public MyContentPage MyContentPage { get; set; }

    public void UpdateChildView(MyDefaultTemplateInfosView view)
    {
      SubjectText = view.SubjectText;
      TitleText = view.TitleText;
      SubTitleText = view.SubTitleText;
      NextBtnText = view.RigthBtnText;
      HideNavBtn = view.HideNavBtn;
      HideNavLeftBtn = view.HideNavLeftBtn;
      HideNavRightBtn = view.HideNavRightBtn;
      Body = view;
    }

    public View Body
    {
      get => BodyContent.Content;
      set => BodyContent.Content = value;
    }

    private async void NextNav_Tapped(object sender, EventArgs e)
    {
      if (itemIsTapped) return;
      itemIsTapped = true;

      RigthBtnClicked?.Invoke(sender, e);

      await Task.Delay(500);
      itemIsTapped = false;
    }

    private void PrevNav_Tapped(object sender, EventArgs e)
    {
      if (LeftBtnClicked != null)
      {
        LeftBtnClicked.Invoke(sender, e);
      }
      else
      {
        MyContentPage?.MyGenericsNavigationPopAsync();
      }
    }

    public string SubjectText
    {
      get => subjectLBL.Text;
      set
      {
        subjectLBL.Text = value;
        if (value == null || value == "")
        {
          subjectLBL.IsVisible = false;
          subjectIMG.IsVisible = true;
        }
        else
        {
          subjectLBL.IsVisible = true;
          subjectIMG.IsVisible = false;
        }
      }
    }

    public string TitleText
    {
      get => titleLBL.Text;
      set
      {
        titleLBL.Text = value;
        if (value == null || value == "")
        {
          titleSTL.IsVisible = false;
        }
        else
        {
          titleSTL.IsVisible = true;
        }
      }
    }

    public string SubTitleText
    {
      get => subTitleLBL.Text;
      set
      {
        subTitleLBL.Text = value;
        if (value == null || value == "")
        {
          subTitleLBL.IsVisible = false;
        }
        else
        {
          subTitleLBL.IsVisible = true;
        }
      }
    }

    public string NextBtnText
    {
      get => nextBL.Text;
      set => nextBL.Text = value;
    }

    public bool HideNavBtn
    {
      set
      {
        footerGRID.IsVisible = !value;
        if (value)
        {
          Grid.SetRowSpan(contentScrollView, 2);
        }
        else
        {
          Grid.SetRowSpan(contentScrollView, 1);
        }

      }
    }

    public bool HideNavRightBtn
    {
      set => nextNavView.IsVisible = !value;
    }

    public bool HideNavLeftBtn
    {
      set => prevNavView.IsVisible = !value;
    }

  }
}