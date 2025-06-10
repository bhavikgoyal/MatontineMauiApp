using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatontineDigitalApp.Commons.components.parameter
{
  public class SimpleListItemDataConverter : IValueConverter
  {
    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
      if (value != null)
      {
        return new SimpleListItemData { Code = value as string };
      }
      return new SimpleListItemData();
    }


    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    {
      if (value != null)
      {
        var item = value as SimpleListItemData;
        return item.Code;
      }
      return "";
    }

  }
}
