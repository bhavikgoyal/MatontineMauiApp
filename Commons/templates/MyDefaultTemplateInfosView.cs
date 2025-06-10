using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatontineDigitalApp.Commons.templates
{
  public class MyDefaultTemplateInfosView : ContentView
  {
    public MyDefaultTemplateInfosView()
    {
    }

    public virtual bool HasValidData()
    {
      return true;
    }

    public virtual void RefreshData()
    {
    }


    public virtual void MyOnDisplayed()
    {
    }

    public string SubjectText { get; set; } = "Subject";
    public string TitleText { get; set; } = "Title";
    public string SubTitleText { get; set; } = "Subtitle";
    public string RigthBtnText { get; set; } = Translate.next;

    public bool HideNavLeftBtn { get; set; } = false;
    public bool HideNavRightBtn { get; set; } = false;
    public bool HideNavBtn { get; set; } = false;


  }
}
