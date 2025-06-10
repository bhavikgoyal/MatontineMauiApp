//using SQLite;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Text.Json.Serialization;
//using System.Threading.Tasks;

//namespace MatontineDigitalApp.Model
//{
//  public class ProfileModel
//  {
//    public class Lstmembre
//    {
//      public int code { get; set; }
//      public int gestionnaire { get; set; }
//      public object fullName { get; set; }
//      public string prenom { get; set; }
//      public string nom { get; set; }
//      public string typecarteidentification { get; set; }
//      public string numcarteidentification { get; set; }
//      public string datedelivrance { get; set; }
//      public string telephone { get; set; }
//      public string adresse { get; set; }
//      public string deparment { get; set; }
//      public string mail { get; set; }
//      public string nompere { get; set; }
//      public string nommere { get; set; }
//      public string codecategorie { get; set; }
//      public string nationalite { get; set; }
//      public string lieunaissance { get; set; }
//      public string modepaiement { get; set; }
//      public bool dejagagne { get; set; }
//      public string sexe { get; set; }
//      public string city { get; set; }
//      public string guardianphone { get; set; }
//      public string guardianemail { get; set; }
//      public string suggestedprovider { get; set; }
//      public string category { get; set; }
//      public string datedenaissance { get; set; }
//      public string relationship { get; set; }
//      public string sitmatrimoniale { get; set; }
//      public string nivetude { get; set; }
//      public string habitat { get; set; }
//      public bool proprietairehabitation { get; set; }
//      public bool personneacharge { get; set; }
//      public int nbenfants { get; set; }
//      public bool cotisatonengroupe { get; set; }
//      public string sourcerevenu { get; set; }
//      public bool revenuestable { get; set; }
//      public bool dejamembretontine { get; set; }
//      public string profession { get; set; }
//      public bool dejagereunetontine { get; set; }
//      public bool possedecomptebancaire { get; set; }
//      public int montantpretprevu { get; set; }
//      public string raisondupret { get; set; }
//      public int revenupersonnel { get; set; }
//      public int taillefamille { get; set; }
//      public bool desactiver { get; set; }
//      public string country { get; set; }
//      public string comptecourant { get; set; }
//      public string compteepargne { get; set; }
//      public bool partagedonnees { get; set; }
//      public bool conditionsgenerales { get; set; }
//      public bool conditionsbic { get; set; }
//      public string positiontirage { get; set; }
//      public object statut { get; set; }
//      public string GUARANTORNAME { get; set; }
//      public string GUARANTORTELEPHONENUMBER { get; set; }
//      public string SECONDSIGNATORYNAME { get; set; }
//      public string SECONDSIGNATORYTELEPHONENUMBER { get; set; }
//      public string THIRDSIGNATORYNAME { get; set; }
//      public string THIRDSIGNATORYTELEPHONENUMBER { get; set; }
//      public bool savingstatus { get; set; }
//      public object savingmessage { get; set; }
//    }

//    public class Lstservice
//    {
//      public int id { get; set; }
//      public string code { get; set; }
//      public string nom { get; set; }
//      public string typeservice { get; set; }
//      public string typeservicedescription { get; set; }
//      public string typeserviceamountdescription { get; set; }
//      public string datencours { get; set; }
//      public string datefin { get; set; }
//      public string montantparticipation { get; set; }
//      public object frais { get; set; }
//      public object fraisdescription { get; set; }
//      public string typeperiodicite { get; set; }
//      public string typeperiodicitedescription { get; set; }
//      public string periodicite { get; set; }
//      public string maxperiodicite { get; set; }
//      public string nombregagnantpartirage { get; set; }
//      public string jourstirage { get; set; }
//      public string enable { get; set; }
//      public string membercount { get; set; }
//      public bool savingstatus { get; set; }
//      public object savingmessage { get; set; }
//    }




//    public class Member
//    {
//      [SQLite.PrimaryKey, SQLite.AutoIncrement]
//      public int ID { get; set; }
//      [JsonPropertyName("code")]
//      public int code { get; set; }

//      [JsonPropertyName("gestionnaire")]
//      public int gestionnaire { get; set; }

//      [JsonPropertyName("fullName")]
//      public string fullName { get; set; }

//      [JsonPropertyName("prenom")]
//      public string prenom { get; set; }

//      [JsonPropertyName("nom")]
//      public string nom { get; set; }

//      [JsonPropertyName("typecarteidentification")]
//      public string typecarteidentification { get; set; }

//      [JsonPropertyName("numcarteidentification")]
//      public string numcarteidentification { get; set; }

//      [JsonPropertyName("datedelivrance")]
//      public string datedelivrance { get; set; }

//      [JsonPropertyName("telephone")]
//      public string telephone { get; set; }

//      [JsonPropertyName("adresse")]
//      public string adresse { get; set; }

//      [JsonPropertyName("deparment")]
//      public string deparment { get; set; }

//      [JsonPropertyName("mail")]
//      public string mail { get; set; }

//      [JsonPropertyName("nompere")]
//      public string nompere { get; set; }

//      [JsonPropertyName("nommere")]
//      public string nommere { get; set; }

//      [JsonPropertyName("codecategorie")]
//      public string codecategorie { get; set; }

//      [JsonPropertyName("nationalite")]
//      public string nationalite { get; set; }

//      [JsonPropertyName("lieunaissance")]
//      public string lieunaissance { get; set; }

//      [JsonPropertyName("modepaiement")]
//      public string modepaiement { get; set; }

//      [JsonPropertyName("dejagagne")]
//      public bool dejagagne { get; set; }

//      [JsonPropertyName("sexe")]
//      public string sexe { get; set; }

//      [JsonPropertyName("city")]
//      public string city { get; set; }

//      [JsonPropertyName("guardianphone")]
//      public string guardianphone { get; set; }

//      [JsonPropertyName("guardianemail")]
//      public string guardianemail { get; set; }

//      [JsonPropertyName("suggestedprovider")]
//      public string suggestedprovider { get; set; }

//      [JsonPropertyName("category")]
//      public string category { get; set; }

//      [JsonPropertyName("datedenaissance")]
//      public string datedenaissance { get; set; }

//      [JsonPropertyName("relationship")]
//      public string relationship { get; set; }

//      [JsonPropertyName("sitmatrimoniale")]
//      public string sitmatrimoniale { get; set; }

//      [JsonPropertyName("nivetude")]
//      public string nivetude { get; set; }

//      [JsonPropertyName("habitat")]
//      public string habitat { get; set; }

//      [JsonPropertyName("proprietairehabitation")]
//      public bool proprietairehabitation { get; set; }

//      [JsonPropertyName("personneacharge")]
//      public bool personneacharge { get; set; }

//      [JsonPropertyName("nbenfants")]
//      public int nbenfants { get; set; }

//      [JsonPropertyName("cotisatonengroupe")]
//      public bool cotisatonengroupe { get; set; }

//      [JsonPropertyName("sourcerevenu")]
//      public string sourcerevenu { get; set; }
//      [JsonPropertyName("revenuestable")]
//      public bool revenuestable { get; set; }
//      [JsonPropertyName("dejamembretontine")]
//      public bool dejamembretontine { get; set; }
//      [JsonPropertyName("profession")]
//      public string profession { get; set; }

//      [JsonPropertyName("dejagereunetontine")]
//      public bool dejagereunetontine { get; set; }
//      [JsonPropertyName("possedecomptebancaire")]
//      public bool possedecomptebancaire { get; set; }
//      [JsonPropertyName("montantpretprevu")]
//      public int montantpretprevu { get; set; }
//      [JsonPropertyName("raisondupret")]
//      public string raisondupret { get; set; }
//      [JsonPropertyName("revenupersonnel")]
//      public int revenupersonnel { get; set; }
//      [JsonPropertyName("taillefamille")]
//      public int taillefamille { get; set; }
//      [JsonPropertyName("desactiver")]
//      public bool desactiver { get; set; }
//      [JsonPropertyName("country")]
//      public string country { get; set; }
//      [JsonPropertyName("comptecourant")]
//      public string comptecourant { get; set; }
//      [JsonPropertyName("compteepargne")]
//      public string compteepargne { get; set; }
//      [JsonPropertyName("partagedonnees")]
//      public bool partagedonnees { get; set; }
//      [JsonPropertyName("conditionsgenerales")]
//      public bool conditionsgenerales { get; set; }
//      [JsonPropertyName("conditionsbic")]
//      public bool conditionsbic { get; set; }
//      [JsonPropertyName("positiontirage")]
//      public string positiontirage { get; set; }
//      [JsonPropertyName("statut")]
//      public string statut { get; set; }
//      [JsonPropertyName("GUARANTORNAME")]
//      public string GUARANTORNAME { get; set; }
//      [JsonPropertyName("GUARANTORTELEPHONENUMBER")]
//      public string GUARANTORTELEPHONENUMBER { get; set; }
//      [JsonPropertyName("SECONDSIGNATORYNAME")]
//      public string SECONDSIGNATORYNAME { get; set; }
//      [JsonPropertyName("SECONDSIGNATORYTELEPHONENUMBER")]
//      public string SECONDSIGNATORYTELEPHONENUMBER { get; set; }
//      [JsonPropertyName("THIRDSIGNATORYNAME")]
//      public string THIRDSIGNATORYNAME { get; set; }
//      [JsonPropertyName("THIRDSIGNATORYTELEPHONENUMBER")]
//      public string THIRDSIGNATORYTELEPHONENUMBER { get; set; }
//      [JsonPropertyName("savingstatus")]
//      public bool savingstatus { get; set; }
//      [JsonPropertyName("savingmessage")]
//      public string savingmessage { get; set; }
//      [JsonPropertyName("messagestatus")]
//      public bool? messagestatus { get; set; }
//      [JsonPropertyName("messageid")]
//      public int? messageid { get; set; }
//      [JsonPropertyName("smppmessage")]
//      public string smppmessage { get; set; }

//      [JsonPropertyName("geparsoc2")]
//      public bool? geparsoc2 { get; set; }
//      [JsonIgnore]
//      [Ignore]
//      public object Translate { get; internal set; }
//      [JsonIgnore]
//      [Ignore]
//      public ImageSource genderImage { get; set; }

//    }
//  }
//}
