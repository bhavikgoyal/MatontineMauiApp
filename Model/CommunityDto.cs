using MatontineDigitalApp.Commons;
using MatontineDigitalApp.Commons.contract;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatontineDigitalApp.Model
{
  public class CommunityDto : Credentials, ICloneable, PeriodicityTypeContractInterface
  {

    public CommunityDto()
    {

    }

    public CommunityDto(CommunityInfosDto dto)
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


    [JsonProperty("codecommunaute")]
    public string communityId { get; set; }

    [Refit.AliasAs("nomcommunaute")]
    public string NomCommunaute { get; set; }

    [JsonProperty("prenom")]
    public string Prenom { get; set; }

    [JsonProperty("nom")]
    public string Nom { get; set; }

    [JsonProperty("telephone")]
    public string Telephone { get; set; }

    [JsonProperty("adresse")]
    public string Adresse { get; set; }


    [JsonProperty("languagecode")]
    public string LanguageCode { get; set; }

    [JsonProperty("languagedescription")]
    public string LanguageDescription { get; set; }


    private CountryDto _Country;
    [JsonIgnore()]
    public CountryDto Country
    {
      get => _Country;
      set
      {
        _Country = value;
        CountryCode = _Country?.Code;
        CountryDescription = _Country?.Description;
        CountryIndicatif = _Country?.Indicatif;
        Devise = _Country?.CurrencyCode;
        DeviseDescription = _Country?.CurrencyDescription;
      }
    }

    [JsonProperty("contryindicatif")]
    public string CountryIndicatif { get; set; }

    [JsonProperty("contrycode")]
    public string CountryCode { get; set; }

    [JsonProperty("contrydescription")]
    public string CountryDescription { get; set; }

    [JsonProperty("regioncode")]
    public string RegionCode { get; set; }

    [JsonProperty("regiondescription")]
    public string RegionDescription { get; set; }

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

    [JsonProperty("typecarteidentification")]
    public string TypePieceIdentite { get; set; }

    [JsonProperty("typecarteidentification_description")]
    public string TypePieceIdentiteDescription { get; set; }

    [JsonProperty("numcarteidentification")]
    public string NumeroPieceIdentite { get; set; }

    [JsonProperty("mail")]
    public string Mail { get; set; }

    [JsonProperty("sexe")]
    public string Genre { get; set; }

    [JsonIgnore]
    public bool IsWoman { get => Genre == "FEMME"; }

    [JsonProperty("sexedescription")]
    public string GenreDescription { get; set; }


    [JsonProperty("country")]
    public string Pays { get; set; }

    [JsonProperty("profession")]
    public string Profession { get { return getString(_Profession); } set { _Profession = value; } }
    private string _Profession;

    [JsonProperty("sitmatrimoniale")]
    public string SituationMatrimoniale { get { return getString(_SituationMatrimoniale); } set { _SituationMatrimoniale = value; } }
    private string _SituationMatrimoniale;

    [JsonProperty("habitat")]
    public string Habitat { get { return getString(_Habitat); } set { _Habitat = value; } }
    private string _Habitat;

    [JsonProperty("personneacharge")]
    public string PersonneACharge { get { return getBool(_PersonneACharge); } set { _PersonneACharge = value; } }
    private string _PersonneACharge;

    [JsonProperty("sourcerevenu")]
    public string SourceDeRevenus { get { return getString(_SourceDeRevenus); } set { _SourceDeRevenus = value; } }
    private string _SourceDeRevenus;

    [JsonProperty("possedecomptebancaire")]
    public string ACompteBancaire { get { return getBool(_ACompteBancaire); } set { _ACompteBancaire = value; } }
    private string _ACompteBancaire;

    [JsonProperty("raisondupret")]
    public string UsageDuPret { get { return getString(_UsageDuPret); } set { _UsageDuPret = value; } }
    private string _UsageDuPret;

    [JsonProperty("taillefamille")]
    public string TailleFamille { get { return getInt(_TailleFamille); } set { _TailleFamille = value; } }
    private string _TailleFamille;

    [JsonProperty("comptecourant")]
    public string comptecourant { get { return getString(_comptecourant); } set { _comptecourant = value; } }
    private string _comptecourant;

    [JsonProperty("compteepargne")]
    public string compteepargne { get { return getString(_compteepargne); } set { _compteepargne = value; } }
    private string _compteepargne;

    [JsonProperty("nivetude")]
    public string NiveauEtude { get { return getString(_NiveauEtude); } set { _NiveauEtude = value; } }
    private string _NiveauEtude;

    [JsonProperty("proprietairehabitation")]
    public string Proprietaire { get { return getBool(_Proprietaire); } set { _Proprietaire = value; } }
    private string _Proprietaire;

    [JsonProperty("cotisatonengroupe")]
    public string CotisationGroupee { get { return getBool(_CotisationGroupee); } set { _CotisationGroupee = value; } }
    private string _CotisationGroupee;


    [JsonProperty("revenuestable")]
    public string RevenuStable { get { return getBool(_RevenuStable); } set { _RevenuStable = value; } }
    private string _RevenuStable;

    [JsonProperty("dejagereunetontine")]
    public string GerezTontineActu { get { return getBool(_GerezTontineActu); } set { _GerezTontineActu = value; } }
    private string _GerezTontineActu;

    [JsonProperty("dejamembretontine")]
    public string DejaMemmbreTontine { get { return getBool(_DejaMemmbreTontine); } set { _DejaMemmbreTontine = value; } }
    private string _DejaMemmbreTontine;

    [JsonProperty("montantpretprevu")]
    public string MontantSouhaiterEmprunter
    {
      get { return getInt(_MontantSouhaiterEmprunter); }
      set { _MontantSouhaiterEmprunter = value; }
    }
    private string _MontantSouhaiterEmprunter;

    [JsonProperty("revenupersonnel")]
    public string RevenuPersonnelMensuel { get { return getInt(_RevenuPersonnelMensuel); } set { _RevenuPersonnelMensuel = value; } }
    private string _RevenuPersonnelMensuel;

    [JsonProperty("nbenfants")]
    public string NombreEnfants { get { return getInt(_NombreEnfants); } set { _NombreEnfants = value; } }
    private string _NombreEnfants;

    [JsonProperty("partagedonnees")]
    public string PartageDonnees { get { return _PartageDonnees != null ? getBool(_PartageDonnees) : ""; } set { _PartageDonnees = value; } }
    private string _PartageDonnees;

    [JsonProperty("conditionsgenerales")]
    public string ConditionsGenerales { get { return _ConditionsGenerales != null ? getBool(_ConditionsGenerales) : ""; } set { _ConditionsGenerales = value; } }
    private string _ConditionsGenerales;








    //Généreaux

    [JsonProperty("partenaire")]
    public string Partenaire { get; set; }


    [JsonProperty("partenaire_description")]
    public string PartenaireDescription { get; set; }

    [JsonProperty("monnaie")]
    public string Monnaie { get; set; }

    [JsonProperty("langue")]
    public string Langue { get; set; }

    [JsonProperty("dateformat")]
    public string FormatDate { get; set; } = "dd/MM/yyyy";

    [JsonProperty("sepmillier")]
    public string SeparateurMillier { get; set; }

    [JsonProperty("sepdecimal")]
    public string SeparateurDeDecimal { get; set; }

    //
    [JsonProperty("montantparticipation")]
    public string Montant { get { return getAmount(_Montant); } set { _Montant = value; } }
    private string _Montant;

    public long GetContributionAmount()
    {
      return toLong(Montant);
    }


    [JsonProperty("devise_description")]
    public string DeviseDescription { get; set; }

    [JsonProperty("devise")]
    public string Devise { get; set; }

    [JsonProperty("membercount")]
    public int? MemberCount { get; set; }

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


    [JsonProperty("typeperiodicite_description")]
    public string TypePeriodiciteDescription { get; set; }

    [JsonProperty("modepaiement")]
    public string ModePaiement { get { return getString(_ModePaiement); } set { _ModePaiement = value; } }
    private string _ModePaiement;


    [JsonProperty("modepaiementdescription")]
    public string ModePaiementDescription { get; set; }


    [JsonIgnore]
    public string OtpSmSCode { get; set; }

    [JsonIgnore]
    public string __Title { get { return Prenom + " " + Nom; } }

    [JsonIgnore]
    public string __Description { get { return Translate.mobilenumber + ": " + Telephone; } }




    public CountryDto GetCountryDto()
    {
      return CommonsResources.Countries.Find((e) => e.Code == this.CountryCode);
    }

    public object Clone()
    {
      return MemberwiseClone();
    }

    public string GetPeriodicityTypeCode()
    {
      return TypePeriodicite;
    }

    //-Génereaux
  }
}
