using MatontineDigitalApp.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatontineDigitalApp.community.dto
{
  public class CommunityListItemData
  {
    private CommunityDto item;

    public CommunityListItemData()
    {

    }

    public CommunityListItemData(CommunityDto item)
    {
      this.item = item;

      this.Code = item.communityId;
      this.Name = item.NomCommunaute;
      this.Amount = item.GetContributionAmount();
      this.AmountDevise = item.Devise;
      this.MemberCount = item.MemberCount;
    }

    public CommunityDto Community { get => item; }

    public string Code { get; set; }
    public string Name { get; set; }
    public long Amount { get; set; }
    public string AmountDevise { get; set; }
    public int? MemberCount { get; set; }

    public string DisplayAmount
    {
      get
      {
        return Amount + " " + AmountDevise;
      }
    }

    public override string ToString()
    {
      return Name;
    }
  }
}
