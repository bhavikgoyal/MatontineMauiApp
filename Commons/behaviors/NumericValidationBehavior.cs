using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatontineDigitalApp.Commons.behaviors
{
  public class NumericValidationBehavior : Behavior<Entry>
  {

    private List<Char> lstDistintFormatChar = new List<char>();
    private string _format;
    public string Format
    {
      get => _format;
      set
      {
        _format = value;
        lstDistintFormatChar.Clear();
        if (string.IsNullOrEmpty(value))
        {
          return;
        }
        lstDistintFormatChar = _format.Distinct().ToList();
      }
    }

    protected override void OnAttachedTo(Entry entry)
    {
      entry.TextChanged += OnEntryTextChanged;
      base.OnAttachedTo(entry);
    }

    protected override void OnDetachingFrom(Entry entry)
    {
      entry.TextChanged -= OnEntryTextChanged;
      base.OnDetachingFrom(entry);
    }

    private void OnEntryTextChanged(object sender, TextChangedEventArgs args)
    {
      if (string.IsNullOrWhiteSpace(args.NewTextValue))
      {
        return;
      }

      var str = args.NewTextValue;


      str = ClearFormatChar(str);

      bool isValid = str.ToCharArray().All(x => char.IsDigit(x));

      var validText = isValid ? str : args.NewTextValue.Remove(args.NewTextValue.Length - 1);

      if (validText.Length == 0 || !isValid)
      {
        ((Entry)sender).Text = validText;
        return;
      }

      try
      {
        validText = long.Parse(validText).ToString(Format);

        if (LengthIsChecked())
        {
          if (!string.IsNullOrEmpty(Format))
          {
            validText = (validText.Length > Format.Replace("\\", "").Length) ? validText.Remove(validText.Length - 1) : validText;
          }
        }
      }
      catch (Exception ex)
      {
        System.Diagnostics.Debug.WriteLine(ex.Message);
        System.Diagnostics.Debug.WriteLine(ex.StackTrace);
      }

        ((Entry)sender).Text = validText;

    }

    private string ClearFormatChar(string s)
    {
      var str = s;
      foreach (var c in lstDistintFormatChar)
      {
        if (c != '0')
        {
          str = str.Replace(c.ToString(), "");
        }
      }

      return str;
    }

    public virtual bool LengthIsChecked()
    {
      return true;
    }


  }
}
