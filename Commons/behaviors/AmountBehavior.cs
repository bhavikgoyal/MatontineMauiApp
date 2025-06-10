using CommunityToolkit.Maui.Behaviors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatontineDigitalApp.Commons.behaviors
{
  public class AmountBehavior : NumericValidationBehavior
  {
    public override bool LengthIsChecked()
    {
      return false;
    }
  }
}
