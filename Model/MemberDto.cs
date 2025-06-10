using MatontineDigitalApp.Commons;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatontineDigitalApp.Model
{
    public class MemberDto : Credentials, ICloneable
    {
        [JsonProperty("positiontirage")]
        public string PositionTirage { get; set; } = " ";

        [JsonProperty("gestionnaire")]
        public string communityId { get; set; }

        private string _id;
        [JsonProperty("code")]
        public string id
        {
            get
            {
                if (string.IsNullOrEmpty(_id))
                {
                    return "0";
                }
                return _id;
            }
            set { _id = value; }
        }

        [JsonProperty("prenom")]
        public string Prenom { get; set; }

        [JsonProperty("nom")]
        public string Nom { get; set; }

        public string DisplayName { get => Prenom + " " + Nom; }

        [JsonProperty("telephone")]
        public string Telephone { get; set; }

        [JsonProperty("telephoneindicatif")]
        public string TelephoneIndicatif { get; set; }

        public string DisplayTelephone { get => TelephoneIndicatif + Telephone; }

        [JsonProperty("adresse")]
        public string Adresse { get; set; }


        [JsonProperty("region")]
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
                __DateNaissance = DateTime.MinValue.ToString("yyyy-MM-dd", CultureInfo.InvariantCulture);
                return DateTime.MinValue;
            }
            set
            {
                __DateNaissance = value.ToString("yyyy-MM-dd", CultureInfo.InvariantCulture);
            }
        }


        [JsonProperty("nationalite")]
        public string Nationalite { get => " "; }

        [JsonProperty("typecarteidentification")]
        public string TypePieceIdentite { get; set; }

        [JsonProperty("typecarteidentificationdescription")]
        public string TypePieceIdentite_description { get; set; }

        [JsonProperty("numcarteidentification")]
        public string NumeroPieceIdentite { get; set; }

        [JsonProperty("lieunaissance")]
        public string LieuNaissance { get => " "; }

        [JsonProperty("datedelivrance")]
        public string _DateDelivrance { get => " "; }
        /*[JsonProperty("datedelivrance")]
        public string _DateDelivrance { get { return __DateDelivrance; } set { __DateDelivrance = value; } }
        private string __DateDelivrance;

        [JsonIgnore]
        public DateTime DateDelivrance
        {
            get
            {
                if (!string.IsNullOrEmpty(__DateDelivrance))
                    return DateTime.ParseExact(__DateDelivrance, "yyyy-MM-dd", CultureInfo.InvariantCulture);
                return DateTime.Now;
            }
            set
            {
                __DateDelivrance = value.ToString("yyyy-MM-dd", CultureInfo.InvariantCulture);
            }
        }*/

        [JsonProperty("country")]
        public string Pays { get; set; }

        [JsonProperty("codecategorie")]
        public string CodeCategorie { get => " "; }

        [JsonProperty("nompere")]
        public string NomPere { get => " "; }

        [JsonProperty("nommere")]
        public string NomMere { get => " "; }

        [JsonProperty("mail")]
        public string Mail { get { return getString(_Mail); } set { _Mail = value; } }
        private string _Mail;

        [JsonProperty("modepaiement")]
        public string ModePaiement { get { return getString(_ModePaiement); } set { _ModePaiement = value; } }
        private string _ModePaiement;


        [JsonProperty("modepaiementdescription")]
        public string ModePaiementDescription { get; set; }

        [JsonProperty("category")]
        public string Categorie { get; set; }

        [JsonProperty("sexe")]
        public string Gender { get; set; }

        [JsonIgnore]
        public bool IsWoman { get => Gender == "FEMME"; }

        [JsonProperty("sexedescription")]
        public string GenderDescription { get; set; }

        [JsonIgnore]
        public ImageSource GenrePhoto
        {
            get
            {
                if (IsWoman)
                {
                    return ImageSource.FromResource("MatontineDigitalApp.Images.favatartransparentback.png");
                }
                return ImageSource.FromResource("MatontineDigitalApp.Images.mavatartransparentback.png");
            }
        }

        [JsonProperty("city")]
        public string Ville { get; set; }

        [JsonProperty("guardianphone")]
        public string NumeroTelTuteur { get { return getString(_NumeroTelTuteur); } set { _NumeroTelTuteur = value; } }
        private string _NumeroTelTuteur;

        [JsonProperty("relationship")]
        public string LiensParente { get { return getString(_LiensParente); } set { _LiensParente = value; } }
        private string _LiensParente;

        [JsonProperty("guardianemail")]
        public string MailTuteur { get { return getString(_MailTuteur); } set { _MailTuteur = value; } }
        private string _MailTuteur;



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

        [JsonProperty("profession")]
        public string Profession { get { return getString(_Profession); } set { _Profession = value; } }
        private string _Profession;


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

        [JsonProperty("biometrieimage1")]
        public string ImageEmpreinteGauche { get; set; }

        [JsonProperty("biometriemunitie1")]
        public string MinutieEmpreinteGauche { get; set; }

        [JsonProperty("biometriequalite1")]
        public int QualiteEmpreinteGauche { get; set; } = 0;




        [JsonProperty("biometrieimage2")]
        public string ImageEmpreinteDroit { get; set; }

        [JsonProperty("biometriemunitie2")]
        public string MinutieEmpreinteDroit { get; set; }

        [JsonProperty("biometriequalite2")]
        public int QualiteEmpreinteDroit { get; set; } = 0;



        [JsonProperty("photo")]
        public string Photo { get; set; }

        [JsonProperty("signature")]
        public string Signature { get; set; }


        [JsonProperty("justificatifadresse")]
        public string JustificatifAdresse { get; set; }

        [JsonProperty("carteidentification")]
        public string CarteIdentification { get; set; }


        [JsonProperty("dejagagne")]
        public string dejagagne { get; set; } = Translate.no;
        //public string dejagagne { get { return getBool(_dejagagne); } set { _dejagagne = value; } }
        //private string _dejagagne;

        [JsonProperty("dejagagne_description")]
        public string dejagagneDescription { get; set; }

        [JsonProperty("desactiver")]
        public string desactiver { get; set; } = Translate.no;
        //public string desactiver { get { return getBool(_desactiver); } set { _desactiver = value; } }
        //private string _desactiver;

        [JsonProperty("desactiver_description")]
        public string desactiverDescription { get; set; }

        [JsonProperty("SUGGESTEDPROVIDER")]
        public string suggestedprovider { get { return getString(_suggestedprovider); } set { _suggestedprovider = value; } }
        private string _suggestedprovider;


        [JsonProperty("statut")]
        public string Statut { get => "true"; }


        [JsonIgnore]
        public string __Title { get { return Prenom + " " + Nom; } }

        [JsonIgnore]
        public string __Description { get { return Translate.mobilenumber + ": " + Telephone; } }

        [JsonIgnore]
        public bool isDataLoaded { get; set; } = false;

        [JsonIgnore]
        public bool IsAutopayEnabled { get; set; } = false;
        [JsonIgnore]
        public bool CanSelect { get; set; } = false;

        [JsonIgnore]
        public bool IsAutopayEnabledButton { get; set; } = false;

        [JsonProperty("paymentcheck")]
        public bool paymentcheck { get; set; }

        [JsonProperty("lstassignedservice")]
        public List<string> ListServiceCodes { get; set; } = new List<string>();

        [JsonProperty("lstcontributionhistory")]
        public List<MemberContributionHistoryDto> ListContributionHistory { get; set; } = new List<MemberContributionHistoryDto>();

        [JsonProperty("lstreport")]
        public List<ReportItemDto> ListReportItems { get; set; } = new List<ReportItemDto>();

        public bool IsSelected { get; set; }

        public object Clone()
        {
            return this.MemberwiseClone();
        }
    }
}
