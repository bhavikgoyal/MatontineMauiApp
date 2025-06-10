using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatontineDigitalApp.Model
{
  public class MdepotDto : Credentials, ICloneable
  {
    [JsonProperty("gestionnaire")]
    public int gestionnaire { get; set; }


    [JsonProperty("groupe")]
    public string groupe { get; set; }


    [JsonProperty("membre")]
    public int membre { get; set; }


    public object Clone()
    {
      return this.MemberwiseClone();
    }
  }
}
