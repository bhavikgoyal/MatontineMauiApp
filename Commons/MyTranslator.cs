using MatontineDigitalApp.Commons.components.parameter;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatontineDigitalApp.Commons
{
  public class MyTranslator
  {
    private static readonly Lazy<MyTranslator> lazy
        = new Lazy<MyTranslator>(() => new MyTranslator());


    public static MyTranslator INSTANCE { get => lazy.Value; }

    public static string CurrentLanguageCD { get; set; } = CommonsResources.getSystemLanguage();

    private static Dictionary<string, string> translateDictionary = new Dictionary<string, string>();

    public static void InitTranslateData(List<SimpleListItemData> data, string languageCD)
    {
      //CurrentLanguageCD = languageCD;

      if (data == null || data.Count <= 0) return;

      translateDictionary.Clear();
      try
      {
        translateDictionary = data.GroupBy(x => x.Code).ToDictionary(group => group.Key, group => group.First().Description);
      }
      catch (Exception e)
      {

      }
    }

    public string translate(string key, string defaultValue = null)
    {

      try
      {
        return translateDictionary[key];
      }
      catch (KeyNotFoundException ex)
      {
        Debug.WriteLine(ex.Message);
        if (defaultValue == null)
        {
          return key;
        }
        else
        {
          return defaultValue;
        }
      }
    }
  }
}
