using Newtonsoft.Json;
using Refit;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatontineDigitalApp.Model
{
  public class CommunityInfosDto : Credentials, ICloneable
  {
    public CommunityInfosDto()
    {

    }

    public CommunityInfosDto(CommunityDto dto)
    {
      plogin = dto.plogin;
      ppassword = dto.ppassword;
      communityId = dto.communityId;
      NomCommunaute = dto.NomCommunaute;
      Partenaire = dto.Partenaire;
      PartenaireDescription = dto.PartenaireDescription;
      Montant = dto.Montant;
      TypePeriodicite = dto.TypePeriodicite;
      TypePeriodiciteDescription = dto.TypePeriodiciteDescription;
      Periodicite = dto.Periodicite;
      NombreDeGagnant = dto.NombreDeGagnant;
      JourDuTirage = dto.JourDuTirage;

      StartDate = dto.StartDate;

      Prenom = dto.Prenom;
      Nom = dto.Nom;
      DateNaissance = dto.DateNaissance;
      Telephone = dto.Telephone;
      TypePieceIdentite = dto.TypePieceIdentite;
      TypePieceIdentiteDescription = dto.TypePieceIdentiteDescription;
      NumeroPieceIdentite = dto.NumeroPieceIdentite;
      Genre = dto.Genre;
      GenreDescription = dto.GenreDescription;

      LanguageCode = dto.LanguageCode;
      LanguageDescription = dto.LanguageDescription;

      CountryIndicatif = dto.CountryIndicatif;
      CountryCode = dto.CountryCode;
      CountryDescription = dto.CountryDescription;
      RegionCode = dto.RegionCode;
      RegionDescription = dto.RegionDescription;
      Devise = dto.Devise;
      DeviseDescription = dto.DeviseDescription;

      FormatDate = dto.FormatDate;
      SeparateurMillier = dto.SeparateurMillier;
      SeparateurDeDecimal = dto.SeparateurDeDecimal;

      ModePaiement = dto.ModePaiement;
      ModePaiementDescription = dto.ModePaiementDescription;

    }


    [JsonProperty("code")]
    public string communityId { get; set; }

    [AliasAs("nomcommunaute")]
    public string NomCommunaute { get; set; }


    [JsonProperty("prenom")]
    public string Prenom { get; set; }

    [JsonProperty("nom")]
    public string Nom { get; set; }


    [JsonProperty("datedenaissance")]
    public string _DateNaissance { get { return __DateNaissance; } set { __DateNaissance = value; } }
    private string __DateNaissance;

    [JsonIgnore]
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

    [JsonProperty("telephone")]
    public string Telephone { get; set; }


    [JsonProperty("typecarteidentification")]
    public string TypePieceIdentite { get; set; }

    [JsonProperty("typecarteidentification_description")]
    public string TypePieceIdentiteDescription { get; set; }

    [JsonProperty("numcarteidentification")]
    public string NumeroPieceIdentite { get; set; }

    [JsonProperty("sexe")]
    public string Genre { get; set; }

    [JsonIgnore]
    public bool IsWoman { get => Genre == "FEMME"; }

    [JsonProperty("sexe_description")]
    public string GenreDescription { get; set; }



    [JsonProperty("langue")]
    public string LanguageCode { get; set; }

    [JsonProperty("languedescription")]
    public string LanguageDescription { get; set; }

    [JsonProperty("countryindicatif")]
    public string CountryIndicatif { get; set; }

    [JsonProperty("countrycode")]
    public string CountryCode { get; set; }

    [JsonProperty("countrydescription")]
    public string CountryDescription { get; set; }

    [JsonProperty("region")]
    public string RegionCode { get; set; }

    [JsonProperty("regiondescription")]
    public string RegionDescription { get; set; }

    [JsonProperty("monnaie")]
    public string Devise { get; set; }

    [JsonProperty("monnaie_description")]
    public string DeviseDescription { get; set; }



    [JsonProperty("startdate")]
    public string _StartDate { get { return __StartDate; } set { __StartDate = value; } }
    private string __StartDate;

    [JsonIgnore]
    public DateTime StartDate
    {
      get
      {
        if (!string.IsNullOrEmpty(__StartDate))
          return DateTime.ParseExact(__StartDate, "yyyy-MM-dd", CultureInfo.InvariantCulture);
        return DateTime.Now;
      }
      set
      {
        __StartDate = value.ToString("yyyy-MM-dd", CultureInfo.InvariantCulture);
      }
    }


    [JsonProperty("dateformat")]
    public string FormatDate { get; set; } = "dd/MM/yyyy";

    [JsonProperty("sepmillier")]
    public string SeparateurMillier { get; set; }

    [JsonProperty("sepdecimal")]
    public string SeparateurDeDecimal { get; set; }



    [JsonProperty("partenaire")]
    public string Partenaire { get; set; }

    [JsonProperty("partenaire_description")]
    public string PartenaireDescription { get; set; }



    [JsonProperty("montantparticipation")]
    public string Montant { get { return getAmount(_Montant); } set { _Montant = value; } }
    private string _Montant;

    public long GetContributionAmount()
    {
      return toLong(Montant);
    }

    [JsonProperty("typeperiodicite_description")]
    public string TypePeriodiciteDescription { get; set; }

    [JsonProperty("typeperiodicite")]
    public string TypePeriodicite { get { return getString(_TypePeriodicite); } set { _TypePeriodicite = value; } }
    private string _TypePeriodicite;

    [JsonProperty("periodicite")]
    public string Periodicite { get { return getInt(_Periodicite); } set { _Periodicite = value; } }
    private string _Periodicite;

    [JsonProperty("nombregagnantpartirage")]
    public string NombreDeGagnant { get { return getInt(_NombreDeGagnant); } set { _NombreDeGagnant = value; } }
    private string _NombreDeGagnant;

    [JsonProperty("jourstirage")]
    public string JourDuTirage { get { return getInt(_JourDuTirage); } set { _JourDuTirage = value; } }
    private string _JourDuTirage;

    [JsonProperty("modepaiement")]
    public string ModePaiement { get { return getString(_ModePaiement); } set { _ModePaiement = value; } }
    private string _ModePaiement;


    [JsonProperty("modepaiementdescription")]
    public string ModePaiementDescription { get; set; }

    public object Clone()
    {
      return MemberwiseClone();
    }

  }
}
