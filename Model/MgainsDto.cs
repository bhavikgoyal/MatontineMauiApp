using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatontineDigitalApp.Model
{
  public class MgainsDto : Credentials, ICloneable
  {
    [JsonProperty("numenreg")]
    public int numenreg { get; set; }

    [JsonProperty("gestionnaire")]
    public int gestionnaire { get; set; }

    [JsonProperty("membre")]
    public int membre { get; set; }

    [JsonProperty("groupe")]
    public string groupe { get; set; }

    [JsonProperty("montant")]
    public decimal montant { get; set; }

    [JsonProperty("remnpret")]
    public decimal remnpret { get; set; }

    [JsonProperty("montantgagne")]
    public decimal montantgagne { get; set; }

    [JsonProperty("dategain")]
    public string dategain { get; set; }

    [JsonProperty("paid")]
    public bool paid { get; set; }
    [JsonProperty("lstassignedservice")]
    public List<string> ListServiceCodes { get; set; } = new List<string>();

    public object Clone()
    {
      return this.MemberwiseClone();
    }
  }
}
