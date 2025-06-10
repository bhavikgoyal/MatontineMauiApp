using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MatontineDigitalApp.Commons;
using MatontineDigitalApp.Commons.contract;
using MatontineDigitalApp.Model;
using Newtonsoft.Json;

namespace MatontineDigitalApp.Services
{
  public class ServiceDto : Credentials, ICloneable, PeriodicityTypeContractInterface
  {
    [JsonIgnore]
    public Color ActiveColor
    {
      get
      {
        if (MemberCount <= 0)
        {
          return Colors.LightGray;
        }

        return CommonsResources.primaryColor;
      }
    }

    [JsonProperty("id")]
    public string ServiceId { get; set; }


    [JsonProperty("code")]
    public string ServiceCode { get; set; }

    [JsonIgnore]
    public string Service { get; set; }

    [JsonProperty("nom")]
    public string Nom { get; set; }


    [JsonProperty("typeservice")]
    public string TypeService { get; set; }

    [JsonProperty("typeservicedescription")]
    public string TypeServiceDescription { get; set; }

    [JsonProperty("typeserviceamountdescription")]
    public string TypeServiceAmountDescription { get; set; }

    [JsonProperty("datencours")]
    public string _DateDemarage { get { return __DateDemarage; } set { __DateDemarage = value; } }
    private string __DateDemarage;


    [JsonIgnore]
    public DateTime DateDemarage
    {
      get
      {
        if (!string.IsNullOrEmpty(__DateDemarage))
        {
          if (__DateDemarage.Contains("/"))
          {
            return DateTime.ParseExact(__DateDemarage, "dd/MM/yyyy", CultureInfo.InvariantCulture);
          }
          else
          {
            return DateTime.ParseExact(__DateDemarage, "yyyy-MM-dd", CultureInfo.InvariantCulture);
          }

        }
        return DateTime.Now;
      }
      set
      {
        __DateDemarage = value.ToString("yyyy-MM-dd", CultureInfo.InvariantCulture);
      }
    }

    [JsonIgnore]
    public string DateDemarageForDisplay
    {
      get
      {
        try
        {
          return DateDemarage.ToString("dd/MM/yyyy", CultureInfo.InvariantCulture);
        }
        catch (Exception ex)
        {
          Debug.WriteLine("DateDemarageForDisplay:" + ex);
          Debug.WriteLine(ex.StackTrace);
          return "";
        }
      }
    }

    [JsonProperty("datefin")]
    public string _DateFin { get { return __DateFin; } set { __DateFin = value; } }
    private string __DateFin;


    [JsonIgnore]
    public DateTime DateFin
    {
      get
      {
        if (!string.IsNullOrEmpty(__DateFin))
        {
          if (__DateFin.Contains("/"))
          {
            return DateTime.ParseExact(__DateFin, "dd/MM/yyyy", CultureInfo.InvariantCulture);
          }
          else
          {
            return DateTime.ParseExact(__DateFin, "yyyy-MM-dd", CultureInfo.InvariantCulture);
          }

        }
        return DateTime.Now;
      }
      set
      {
        __DateFin = value.ToString("yyyy-MM-dd", CultureInfo.InvariantCulture);
      }
    }

    [JsonIgnore]
    public string DateFinForDisplay
    {
      get
      {
        try
        {
          return DateFin.ToString("dd/MM/yyyy", CultureInfo.InvariantCulture);
        }
        catch (Exception ex)
        {
          Debug.WriteLine("DateFinForDisplay:" + ex);
          Debug.WriteLine(ex.StackTrace);
          return "";
        }
      }
    }



    [JsonProperty("montantparticipation")]
    public string Montant { get { return getAmount(_Montant); } set { _Montant = value; } }
    private string _Montant;
    public long Amount { get => toLong(Montant); }
    public string AmountFormated { get => Model.Utils.FormatAmount(_Montant); }


    [JsonProperty("frais")]
    public string Frais { get { return getAmount(_Frais); } set { _Frais = value; } }
    private string _Frais;
    public long FeesAmount { get => toLong(Frais); }
    public string FeesAmountFormated { get => Model.Utils.FormatAmount(_Frais); }


    [JsonProperty("fraisdescription")]
    public string FeesAmountDescription { get; set; }

    public bool FeesAmountVisible { get => !string.IsNullOrWhiteSpace(FeesAmountDescription); }


    [JsonProperty("typeperiodicite")]
    public string TypePeriodicite { get { return getString(_TypePeriodicite); } set { _TypePeriodicite = value; } }
    private string _TypePeriodicite;

    [JsonProperty("typeperiodicitedescription")]
    public string TypePeriodiciteDescription { get; set; }

    [JsonProperty("periodicite")]
    public string Periodicite { get { return getInt(_Periodicite); } set { _Periodicite = value; } }
    private string _Periodicite;


    [JsonProperty("maxperiodicite")]
    public string MaxPeriodicite { get { return getInt(_MaxPeriodicite); } set { _MaxPeriodicite = value; } }
    private string _MaxPeriodicite;

    [JsonProperty("nombregagnantpartirage")]
    public string NombreDeGagnant { get { return getInt(_NombreDeGagnant); } set { _NombreDeGagnant = value; } }
    private string _NombreDeGagnant;

    [JsonProperty("jourstirage")]
    public string JourDuTirage { get { return getInt(_JourDuTirage); } set { _JourDuTirage = value; } }
    private string _JourDuTirage;

    [JsonProperty("assignation")]
    public string Assigner { get { return getBool(_Assigner); } set { _Assigner = value; } }
    private string _Assigner;

    [JsonProperty("enable")]
    public string Actif { get { return getBool(_Actif); } set { _Actif = value; } }
    private string _Actif;


    [JsonProperty("membercount")]
    public int MemberCount { get; set; }

    [JsonIgnore]
    public string __Title { get { return Nom; } }

    [JsonIgnore]
    public bool DisplayDateDemarage { get; set; } = true;

    [JsonIgnore]
    public bool DisplayActif { get; set; } = false;

    [JsonIgnore]
    public string __Description
    {
      get
      {
        var _desc = "";

        ; if (DateDemarage != null && DisplayDateDemarage)
        {
          _desc = "\n" + Translate.datedebut + ": " + DateDemarage.ToString("dd/MM/yyyy");
        }

        var _actif = "";
        if (Actif != null && DisplayActif)
        {
          var r = Actif == "false" ? Translate.no : Translate.yes;
          _actif = "\n" + Translate.actif + ": " + r;
        }

        return Translate.code + ": " + Service + _desc + _actif;
      }
    }

    public object Clone()
    {
      return this.MemberwiseClone();
    }

    public string GetPeriodicityTypeCode()
    {
      return TypePeriodicite;
    }

    [JsonIgnore]
    public bool IsTontine { get => TypeService == "TONTINE"; }

    [JsonIgnore]
    public bool NotTontine { get => TypeService != "TONTINE"; }


    [JsonIgnore]
    public bool CanUseDateFin { get => TypeService == "EPARGNE"; }
    public bool CanUseMaxPeriodicite { get => TypeService == "ASSURANCE"; }

    public enum CategoryServiceEnum
    {
      TONTINE,
      OTHERS,
      ALL
    }

  }
}

