using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatontineDigitalApp.Model
{
  public class CountryDto
  {
    [JsonProperty("key")]
    public string Code { get; set; }

    [JsonProperty("value")]
    public string Description { get; set; }

    [JsonProperty("pricing")]
    public string Pricing { get; set; }

    [JsonProperty("currencycode")]
    public string CurrencyCode { get; set; }

    [JsonProperty("currencydescription")]
    public string CurrencyDescription { get; set; }

    [JsonProperty("currencyformat")]
    public string CurrencyFormat { get; set; } = "";

    [JsonProperty("indicatif")]
    public string Indicatif { get; set; }

    [JsonProperty("imagebase64")]
    public string FlagBase64 { get; set; }


    [JsonProperty("telephonelength")]
    public long TelephoneLength { get; set; } = 9;

    [JsonProperty("telephoneformat")]
    public string TelephoneFormat { get; set; } = "## ### ## ##";

    [JsonProperty("cnilength")]
    public long CniLength { get; set; } = 13;

    [JsonProperty("cniformat")]
    public string CniFormat { get; set; } = "# ### #### #####";

    //[JsonIgnore]
    //public string DisplayPricing { get => Utils.FormatAmount(Pricing,  CurrencyDescription); }

    [JsonIgnore]
    public ImageSource FlagImage { get => Utils.Base64ToImage(FlagBase64); }
  }
}
