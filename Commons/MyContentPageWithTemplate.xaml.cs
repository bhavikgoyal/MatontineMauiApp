using MatontineDigitalApp.Commons.templates;

namespace MatontineDigitalApp.Commons
{
  public partial class MyContentPageWithTemplate : MyContentPage
  {
    
    public MyContentPageWithTemplate()
    {
      InitializeComponent();
      NavigationPage.SetHasNavigationBar(this, false);
      MyTemplate.MyContentPage = this;
    }

    public View TemplateBody
    {
      get => TemplateBodyContent.Content;
      set => TemplateBodyContent.Content = value;
    }

    public MyDefaultTemplate MyTemplate { get => template; }
  }
}