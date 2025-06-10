using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatontineDigitalApp.Model
{
  public class MemberContributionHistoryDto : ICloneable
  {
    public string ServiceCode { get; set; }

    public string PeriodeDescription { get; set; }
    public string StatusCode { get; set; }
    public string StatusDecription { get; set; }

    //public Color StatusColor
    //{
    //  get
    //  {
    //    switch (StatusCode)
    //    {
    //      case "EARLY": return Color.Green;
    //      case "ON-TIME": return Color.Orange;
    //      default: return Color.Red; //"LATE"
    //    }
    //  }
    //}

    public object Clone()
    {
      return this.MemberwiseClone();
    }
  }
}
