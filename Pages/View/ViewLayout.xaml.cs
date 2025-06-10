using MauiView = Microsoft.Maui.Controls.View;

namespace MatontineDigitalApp.Pages.View
{
    public partial class ViewLayout : ContentView
    {
        public ViewLayout()
        {
            InitializeComponent();

        }
        public void SetLabelText(string text)
        {
            subjectLBL.Text = text; 
        }

    }
}
