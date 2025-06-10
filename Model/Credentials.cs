using MatontineDigitalApp.Commons;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatontineDigitalApp.Model
{
  public class Credentials
  {
    public string plogin { get; set; }
    public string ppassword { get; set; }
    public string psmscode { get; set; }
    public string plangue { get; set; } = Preferences.Get("UserLG", null) == null ? CommonsResources.getSystemLanguage() : Preferences.Get("UserLG", null);
    public string ptelephone { get; set; }


    public string getString(string s)
    {
      return (s == null) ? "" : s;
    }

    public string getInt(string s)
    {
      return (s == null) ? "0" : s;
    }

    public string getAmount(string s)
    {
      try
      {
        return int.Parse(s?.Replace(" ", "").Replace(".", "")).ToString();
      }
      catch (Exception e)
      {
        return "0";
      }
    }

    public long toLong(string s)
    {
      try
      {
        return long.Parse(s?.Replace(" ", "").Replace(".", ""));
      }
      catch (Exception e)
      {
        return 0;
      }
    }

    public int toInt(string s)
    {
      try
      {
        return int.Parse(s?.Replace(" ", ""));
      }
      catch (Exception e)
      {
        return 0;
      }
    }

    public string getBool(string s)
    {
      return (s == null) ? "false" : s;
    }



    [JsonProperty("savingstatus")]
    public bool Savingstatus { get; set; }

    [JsonProperty("savingmessage")]
    public string Savingmessage { get; set; }
  }
}
