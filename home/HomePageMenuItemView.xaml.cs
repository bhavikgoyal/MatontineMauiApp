namespace MatontineDigitalApp.home
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class HomePageMenuItemView : ContentView
  {
    public event EventHandler ItemClicked;
    public HomePageMenuItemView()
		{
			InitializeComponent();
		}
    public HomeTabEnum HomeTab { get; set; }

    public string Title
    {
      get => label.Text;
      set => label.Text = value;
    }

    public ImageSource Image
    {
      get => img.Source;
      set => img.Source = value;
    }

    private void Item_Tapped(object sender, EventArgs e)
    {
      Preferences.Remove("CheckBoxInSavingGroup");
      if (this.Title == "Savings Groups" || this.Title == "Groupe d'épargne")
      {
        Preferences.Set("CheckBoxInSavingGroup", true);
      }
      else
      {
        Preferences.Set("CheckBoxInSavingGroup", false);
      }
      ItemClicked?.Invoke(this, e);
    }
  }
}