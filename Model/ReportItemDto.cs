using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatontineDigitalApp.Model
{
  public class ReportItemDto : Credentials, ICloneable
  {
    [JsonProperty("ServiceCode")]
    public string ServiceCode { get; set; }

    [JsonProperty("Code")]
    public string Code { get; set; }

    [JsonProperty("Nom")]
    public string Nom { get; set; }

    [JsonProperty("Description")]
    public string Description { get; set; }

    [JsonProperty("ColorHex")]
    public string ColorHex { get; set; }

    public Color Color
    {
      get
      {
        var hex = "#2980b9";

        if (ColorHex == null || ColorHex == "")
        {
          switch (Code)
          {
            case "Contributed": hex = "#f68b2c"; break;
            case "Contribution": hex = "#2bb673"; break;
            case "Won": hex = "#b22256"; break;
            case "DateWon": hex = "#605ea5"; break;

            case "StartDate": hex = "#f68b2c"; break;
            case "Target": hex = "#2bb673"; break;
            case "NofSavers": hex = "#b22256"; break;
            case "TotalSaved": hex = "#605ea5"; break;
          }
        }
        else
        {
          hex = ColorHex;
        }

        return Color.FromHex(hex);
      }
    }

    public object Clone()
    {
      return this.MemberwiseClone();
    }
  }
}
