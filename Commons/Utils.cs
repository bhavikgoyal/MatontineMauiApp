using MatontineDigitalApp.Services;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatontineDigitalApp.Commons
{
  public class Utils
  {
    public static bool IsBlankOrNull(string s)
    {
      return s == null || s.Trim() == "";
    }

    public static string FormatAmount(string pamount)
    {
      return FormatAmount(ToLong(pamount));
    }

    public static string FormatAmount(long pamount, string pcurrency = null)
    {
      var amountFormated = String.Format(CultureInfo.CreateSpecificCulture("fr-FR"), "{0:n0}", pamount);

      if (pcurrency == null)
      {
        return amountFormated;
      }
      else
      {
        return amountFormated + " " + pcurrency;
      }

    }

    public static long ToLong(string s)
    {
      try
      {
        return long.Parse(s?.Replace(" ", ""));
      }
      catch (Exception e)
      {
        return 0;
      }
    }


    public static ImageSource Base64ToImage(string base64)
    {
      if (string.IsNullOrWhiteSpace(base64))
      {
        return null;
      }

      return ImageSource.FromStream(() => {
        return new MemoryStream(Convert.FromBase64String(base64));
      });
    }


    public static string ClearFormatText(string text, string currentFormat)
    {
      if (string.IsNullOrEmpty(currentFormat) || string.IsNullOrEmpty(text))
      {
        return text;
      }
      var lst = currentFormat.Distinct();

      var str = text;
      foreach (var c in lst)
      {
        if (c != '0')
        {
          str = str.Replace(c.FROMOBJECTVALUETOSTRING(), "");
        }
      }

      return str;
    }


  }
}
