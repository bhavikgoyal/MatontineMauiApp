using MatontineDigitalApp.Commons;
using MatontineDigitalApp.Services;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace MatontineDigitalApp.Model
{
  public class UserProfile : Credentials, ICloneable
  {

    [JsonProperty("isadmin")]
    public bool isadmin { get; set; }
    [JsonProperty("isconnected")]
    public bool isconnected { get; set; }
    [JsonProperty("errormessage")]
    public string errormessage { get; set; }

    [JsonProperty("dashboardurl")]
    public string dashboardurl { get; set; }
    [JsonProperty("membersurl")]
    public string membersurl { get; set; }
    [JsonProperty("servicesurl")]
    public string servicesurl { get; set; }
    [JsonProperty("contributionsurl")]
    public string contributionsurl { get; set; }
    [JsonProperty("advancesurl")]
    public string advancesurl { get; set; }

    [JsonProperty("profile_communityid")]
    public string profile_community_id { get; set; }
    [JsonProperty("profile_community")]
    public string profile_community { get; set; }
    [JsonProperty("profile_surname")]
    public string profile_surname { get; set; }
    [JsonProperty("profile_name")]
    public string profile_name { get; set; }

    [JsonProperty("profile_gender")]
    public string profile_gender { get; set; }
    [JsonProperty("profile_partner")]
    public string profile_partner { get; set; }
    [JsonProperty("profile_partner_description")]
    public string profile_partner_description { get; set; }
    [JsonProperty("profile_datenaissance")]
    public string profile_datenaissance { get; set; }



    [System.Text.Json.Serialization.JsonIgnore]
    public bool IsWoman { get => profile_gender == "FEMME"; }

    [JsonProperty("profile_gender_description")]
    public string profile_gender_description { get; set; }

    private CountryDto _CountryDto;
    [System.Text.Json.Serialization.JsonIgnore()]
    public CountryDto CountryDto
    {
      get => _CountryDto;
      set
      {
        _CountryDto = value;
        profile_country = _CountryDto?.Code;
        ProfileCountryDescription = _CountryDto?.Description;
        ProfileContryIndicatif = _CountryDto?.Indicatif;
        ProfileCurrency = _CountryDto?.CurrencyCode;
        ProfileCurrencyDescription = _CountryDto?.CurrencyDescription;
      }
    }

    [JsonProperty("profile_country_indicatif")]
    public string ProfileContryIndicatif { get; set; }

    [JsonProperty("profile_country")]
    public string profile_country { get; set; }

    [JsonProperty("profile_country_description")]
    public string ProfileCountryDescription { get; set; }

    [JsonProperty("profile_region")]
    public string profileRegion { get; set; }

    [JsonProperty("profile_region_description")]
    public string ProfileRegionDescription { get; set; }

    [JsonProperty("profile_currency")]
    public string ProfileCurrency { get; set; }

    [JsonProperty("profile_currency_description")]
    public string ProfileCurrencyDescription { get; set; }


    public string ProfileDispalyRegionCuntry { get => ProfileRegionDescription + ", " + ProfileCountryDescription; }

    public string ProfileDisplayName { get => profile_name + " " + profile_surname; }


    [JsonProperty("date_de_naissance")]
    public string _DateNaissance { get { return __DateNaissance; } set { __DateNaissance = value; } }
    private string __DateNaissance;

    public DateTime DateNaissance
    {
      get
      {
        if (!string.IsNullOrEmpty(__DateNaissance))
          return DateTime.ParseExact(__DateNaissance, "yyyy-MM-dd", CultureInfo.InvariantCulture);
        return DateTime.Now;
      }
      set
      {
        __DateNaissance = value.ToString("yyyy-MM-dd", CultureInfo.InvariantCulture);
      }
    }


    [JsonProperty("profile_phonenumber")]
    public string profile_phonenumber { get; set; }


    [JsonProperty("profile_address")]
    public string profile_address { get; set; }




    [JsonProperty("profile_idtype")]
    public string profile_idtype { get; set; }
    [JsonProperty("profile_idnumber")]
    public string profile_idnumber { get; set; }
    [JsonProperty("profile_email")]
    public string profile_email { get; set; }

    [JsonProperty("getsolde_command")]
    public string getsolde_command { get; set; }
    [JsonProperty("getpayment_command")]
    public string getpayment_command { get; set; }

    [JsonProperty("autopay")]
    public bool autopay { get; set; }

    //[JsonProperty("paymentcheck")]
    //public bool paymentcheck { get; set; }

    public bool paymentauthorization { get; set; }


    [JsonProperty("langue")]
    public string langue { get; set; }

    [JsonProperty("langue_description")]
    public string LangueDescription { get; set; }

    [JsonProperty("partner")]
    public string Partner { get; set; }

    [JsonProperty("partner_description")]
    public string PartnerDescription { get; set; }


    [JsonProperty("dateformat")]
    public string FormatDate { get; set; } = "dd/MM/yyyy";

    [JsonProperty("sepmillier")]
    public string SeparateurMillier { get; set; } = " ";

    [JsonProperty("sepdecimal")]
    public string SeparateurDeDecimal { get; set; } = " ";


    //Services
    [JsonProperty("services")]
    public List<ServiceDto> services { get; set; }


    public List<SimpleListItemData> lstcommunaute { get; set; }

    [JsonProperty("lstmembreOLD")]
    public List<SimpleListItemData> lstmembre { get; set; }

    [JsonProperty("lstserviceOLD")]
    public List<SimpleListItemData> lstservice { get; set; }



    [JsonProperty("lstmembre")]
    public List<MemberDto> ListMembers { get; set; }

    [JsonProperty("lstservice")]
    public List<ServiceDto> ListServices { get; set; }

    [JsonProperty("lstmgains")]
    public List<MgainsDto> ListMgains { get; set; }
        public string CountryCode { get; internal set; }

        public CountryDto GetCountryDto()
    {
      return CommonsResources.Countries.Find((e) => e.Code == this.profile_country);
    }

    public object Clone()
    {
      return this.MemberwiseClone();
    }
  }
}
