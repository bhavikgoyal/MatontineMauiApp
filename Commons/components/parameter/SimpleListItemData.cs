using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatontineDigitalApp.Commons.components.parameter
{
  public class SimpleListItemData : IEquatable<SimpleListItemData>
  {
    [JsonProperty("key")]
    public string Code { get; set; }

    [JsonProperty("value")]
    public string Description { get; set; }

    [JsonProperty("imagebase64")]
    public string ImageBase64 { get; set; }
    [JsonIgnore]
    public ImageSource Image { get => Utils.Base64ToImage(ImageBase64); }

    [JsonProperty("amount")]
    public long Amount { get; set; }

    [JsonProperty("amount_devise")]
    public string AmountDevise { get; set; }

    [JsonProperty("member_count")]
    public int MemberCount { get; set; }

    public string DescriptionOLD { get; set; }

    public string __Title { get { return Description; } }

    public string __Description
    {
      get
      {
        return DescriptionOLD != null ? DescriptionOLD : "";
      }
    }

    public bool Equals(SimpleListItemData other)
    {
      return Code.Equals(other.Code);
    }
  }
}
