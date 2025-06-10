using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatontineDigitalApp.Commons
{
    public class Translate
    {
        private static string translate(string defaultValue = null)
        {
            string key = new StackTrace().GetFrame(1).GetMethod().Name.Substring(4);
            return MyTranslator.INSTANCE.translate(key, defaultValue);
        }

        public static string telephonecourt { get => translate("Tel"); }
        public static string a { get => translate(); }
        public static string home { get => translate("Home"); }
        public static string actif { get => translate(); }
        public static string activationservice { get => translate(); }
        public static string administrateur { get => translate(); }
        public static string administration { get => translate(); }
        public static string address { get => translate("Address"); }
        public static string advances_fees { get => translate(); }
        public static string affichezmoins { get => translate(); }
        public static string affichezplus { get => translate(); }
        public static string age { get => translate(); }
        public static string ageminimumautorise { get => translate(); }
        public static string ajour { get => translate(); }
        public static string ajouter { get => translate(); }
        public static string amountsavedtodate { get => translate(); }
        public static string annuler { get => translate(); }
        public static string assignation { get => translate(); }
        public static string assurance { get => translate(); }
        public static string assurancefutur { get => translate(); }
        public static string autres { get => translate(); }
        public static string avance { get => translate(); }
        public static string avancefuture { get => translate(); }
        public static string avancegain { get => translate(); }
        public static string avancerecue { get => translate(); }
        public static string avantle { get => translate(); }
        public static string averageinsurance { get => translate(); }
        public static string averagesavings { get => translate(); }
        public static string beneficiaires { get => translate(); }
        public static string beneficiaryreport { get => translate(); }
        public static string bienvenuemantontine { get => translate(); }
        public static string category { get => translate(); }
        public static string cgap { get => translate(); }
        public static string chaquesemaine { get => translate(); }
        public static string chargementfichier { get => translate(); }
        public static string chargementfichierom { get => translate(); }
        public static string charger { get => translate(); }
        public static string chargermembre { get => translate(); }
        public static string chiffrecle { get => translate(); }
        public static string chiffrecommunaute { get => translate(); }
        public static string choixcommunauteobligatoire { get => translate(); }
        public static string city { get => translate(); }
        public static string CNI { get => translate(); }
        public static string code { get => translate(); }
        public static string codesms { get => translate(); }
        public static string commission { get => translate(); }
        public static string commissionepargnesociale { get => translate(); }
        public static string commissionpret { get => translate(); }
        public static string community { get => translate("Community"); }
        public static string communauteinfobulle { get => translate(); }
        public static string communautes { get => translate(); }
        public static string comptebancaire { get => translate(); }
        public static string comptecourant { get => translate(); }
        public static string compteepargne { get => translate(); }
        public static string consultation { get => translate(); }
        public static string contact { get => translate("Contact"); }
        public static string contactinformation { get => translate("Contact Information"); }
        public static string cotisation { get => translate(); }
        public static string cotisationacejour { get => translate(); }
        public static string cotisationcommunaute { get => translate(); }
        public static string cotisationdesmembres { get => translate(); }
        public static string cotisationengroupe { get => translate(); }
        public static string cotisationinfobulle { get => translate(); }
        public static string cotisationmembre { get => translate(); }
        public static string cotisationmensmoy { get => translate(); }
        public static string cotisationmensuelle { get => translate(); }
        public static string cotisationminimum { get => translate(); }
        public static string cumulative { get => translate(); }
        public static string datedebut { get => translate(); }
        public static string datedelivrance { get => translate(); }
        public static string birthday { get => translate("Birthday"); }
        public static string datedenaissanceinfobulle { get => translate(); }
        public static string datedepot { get => translate(); }
        public static string datepaiement { get => translate(); }
        public static string datepret { get => translate(); }
        public static string de { get => translate(); }
        public static string deconnexion { get => translate(); }
        public static string alreadywon { get => translate("Already Won?"); }
        public static string deactivated { get => translate("Deactivated?"); }
        public static string demarrage { get => translate(); }
        public static string departement { get => translate(); }
        public static string depot { get => translate(); }
        public static string derniertirage { get => translate(); }
        public static string description { get => translate(); }
        public static string disable { get => translate(); }
        public static string doublonscni { get => translate(); }
        public static string doublonslogin { get => translate(); }
        public static string doublonstelephone { get => translate(); }
        public static string dumois { get => translate(); }
        public static string duration { get => translate(); }
        public static string dureemaximumremboursement { get => translate(); }
        public static string dureepret { get => translate(); }
        public static string edition { get => translate(); }
        public static string effacer { get => translate(); }
        public static string EN { get => translate(); }
        public static string enavance { get => translate(); }
        public static string enddate { get => translate("End Date"); }
        public static string enregistreavecsucces { get => translate(); }
        public static string save { get => translate("Save"); }
        public static string enretard { get => translate(); }
        public static string enrolement { get => translate(); }
        public static string envoyer { get => translate(); }
        public static string erreurconnexion { get => translate(); }
        public static string erreursysteme { get => translate(); }
        public static string erreurtraitement { get => translate(); }
        public static string expectedsavings { get => translate(); }
        public static string femme { get => translate(); }
        public static string fermer { get => translate(); }
        public static string ficheevaluation { get => translate(); }
        public static string financial { get => translate(); }
        public static string fonctionnalite { get => translate(); }
        public static string forcetirage { get => translate(); }
        public static string dateformat { get => translate("Date Format"); }
        public static string FR { get => translate(); }
        public static string frais { get => translate(); }
        public static string fraisgestion { get => translate(); }
        public static string frequence { get => translate(); }
        public static string gagne { get => translate(); }
        public static string gain { get => translate(); }
        public static string gainacejour { get => translate(); }
        public static string gainmensuel { get => translate(); }
        public static string gainnet { get => translate(); }
        public static string GB { get => translate(); }
        public static string gender { get => translate("Gender"); }
        public static string pleaseselectyourgender { get => translate("Please select a gender"); }
        public static string geretontine { get => translate(); }
        public static string gestionbeneficiaire { get => translate(); }
        public static string gestioncourante { get => translate(); }
        public static string gestionmembre { get => translate(); }
        public static string manager { get => translate("Manager"); }
        public static string gestionsecurite { get => translate(); }
        public static string gestionservice { get => translate(); }
        public static string gestionutilisateur { get => translate(); }
        public static string groupetontine { get => translate(); }
        public static string guardianemail { get => translate(); }
        public static string guardianphone { get => translate(); }
        public static string habitat { get => translate(); }
        public static string homepage { get => translate(); }
        public static string homme { get => translate(); }
        public static string hypothese { get => translate(); }
        public static string identification { get => translate(); }
        public static string impaye { get => translate(); }
        public static string information { get => translate(); }
        public static string informationsuravance { get => translate(); }
        public static string informationsurpret { get => translate(); }
        public static string informationtontine { get => translate(); }
        public static string infoscomplementaires { get => translate(); }
        public static string initialiser { get => translate(); }
        public static string inscription { get => translate(); }
        public static string insurancehistory { get => translate(); }
        public static string insurancesummary { get => translate(); }
        public static string insurancetarget { get => translate(); }
        public static string interet { get => translate(); }
        public static string jour { get => translate(); }
        public static string jourcollecte { get => translate(); }
        public static string jourdutirage { get => translate(); }
        public static string jourdutirageinfobulle { get => translate(); }
        public static string jourpaiement { get => translate(); }
        public static string jourpaiement1 { get => translate(); }
        public static string joursenretard { get => translate(); }
        public static string language { get => translate("Language"); }
        public static string langueinfobulle { get => translate(); }
        public static string latepayments { get => translate(); }
        public static string le { get => translate(); }
        public static string lga { get => translate(); }
        public static string lieudenaissance { get => translate(); }
        public static string listecommunaute { get => translate(); }
        public static string listemembre { get => translate(); }
        public static string listeservice { get => translate(); }
        public static string loadfinancialdata { get => translate(); }
        public static string localisation { get => translate(); }
        public static string login2 { get => translate("Login"); }
        public static string login { get => translate("Log In"); }
        public static string loginerror { get => translate(); }
        public static string logininfobulle { get => translate(); }
        public static string pleaseenteryourlogin { get => translate("Please enter your Login"); }
        public static string pleaseenteryourloginandpassword { get => translate("Please enter your Login and Password"); }
        public static string emailaddress { get => translate("Email address"); }
        public static string mailenvoye { get => translate(); }
        public static string mailerror { get => translate(); }
        public static string management { get => translate(); }
        public static string managementreport { get => translate(); }
        public static string manuel { get => translate(); }
        public static string maxpretautorise { get => translate(); }
        public static string membre { get => translate(); }
        public static string membrenoncotise { get => translate(); }
        public static string members { get => translate("Members"); }
        public static string membermanagement { get => translate("Member Management"); }
        public static string membreservice { get => translate(); }
        public static string membreverification { get => translate(); }
        public static string menutableaubord { get => translate(); }
        public static string message { get => translate(); }
        public static string paymentmethod { get => translate("Payment Method"); }
        public static string modifier { get => translate(); }
        public static string mois { get => translate(); }
        public static string mois1 { get => translate(); }
        public static string mois10 { get => translate(); }
        public static string Mois10Court { get => translate(); }
        public static string mois11 { get => translate(); }
        public static string Mois11Court { get => translate(); }
        public static string mois12 { get => translate(); }
        public static string Mois12Court2 { get => translate(); }
        public static string mois13 { get => translate(); }
        public static string mois14 { get => translate(); }
        public static string mois15 { get => translate(); }
        public static string mois16 { get => translate(); }
        public static string mois17 { get => translate(); }
        public static string mois18 { get => translate(); }
        public static string mois19 { get => translate(); }
        public static string Mois1Court { get => translate(); }
        public static string mois2 { get => translate(); }
        public static string mois20 { get => translate(); }
        public static string mois21 { get => translate(); }
        public static string mois22 { get => translate(); }
        public static string mois23 { get => translate(); }
        public static string mois24 { get => translate(); }
        public static string Mois2Court { get => translate(); }
        public static string mois3 { get => translate(); }
        public static string Mois3Court { get => translate(); }
        public static string mois4 { get => translate(); }
        public static string Mois4Court { get => translate(); }
        public static string mois5 { get => translate(); }
        public static string Mois5Court { get => translate(); }
        public static string mois6 { get => translate(); }
        public static string Mois6Court { get => translate(); }
        public static string mois7 { get => translate(); }
        public static string Mois7Court { get => translate(); }
        public static string mois8 { get => translate(); }
        public static string Mois8Court { get => translate(); }
        public static string mois9 { get => translate(); }
        public static string Mois9Court { get => translate(); }
        public static string moisgagne { get => translate(); }
        public static string monnaie { get => translate(); }
        public static string monnaieinfobulle { get => translate(); }
        public static string amount { get => translate("Amount"); }
        public static string montantdepot { get => translate(); }
        public static string montantemprunt { get => translate(); }
        public static string montantempruntinfobulle { get => translate(); }
        public static string montantmaxautorisepret { get => translate(); }
        public static string montantmoyenpret { get => translate(); }
        public static string montantnonremourser { get => translate(); }
        public static string montanttotalemprunte { get => translate(); }
        public static string montanttotalrembourse { get => translate(); }
        public static string moyennetaillegroupe { get => translate(); }
        public static string nationalite { get => translate(); }
        public static string nbenfants { get => translate(); }
        public static string newcommunaute { get => translate(); }
        public static string newsmscode { get => translate(); }
        public static string nivetude { get => translate(); }
        public static string lastname { get => translate("Last Name"); }
        public static string surname { get => translate("Surname"); }
        public static string nombreautreservice { get => translate(); }
        public static string nombrecaracteremax { get => translate(); }
        public static string nombredemembre { get => translate(); }
        public static string nombredemembreparservice { get => translate(); }
        public static string nombredeservice { get => translate(); }
        public static string nombreemprunteur { get => translate(); }
        public static string nombregagnant { get => translate(); }
        public static string nombregroupetontine { get => translate(); }
        public static string nombrejourretardavanttirage { get => translate(); }
        public static string nombremaximumpretgroupe { get => translate(); }
        public static string nombremois { get => translate(); }
        public static string nombremoisavantpret { get => translate(); }
        public static string nombretirage { get => translate(); }
        public static string nombretiragerestant { get => translate(); }
        public static string no { get => translate("No"); }
        public static string notecredit { get => translate(); }
        public static string nouveaumembre { get => translate(); }
        public static string numberofinsured { get => translate(); }
        public static string numberofsaver { get => translate(); }
        public static string numeroidentificationincorrect { get => translate(); }
        public static string numerotelephoneincorrect { get => translate(); }
        public static string numerotransaction { get => translate(); }
        public static string idnumber { get => translate("ID Number"); }
        public static string dobandid { get => translate("DOB & ID"); }
        public static string pleaseenteryouridnumber { get => translate("Please enter your ID Number"); }
        public static string incorrectidnumber { get => translate("Incorrect ID Number"); }
        public static string selectyourdateofbirth { get => translate("Please select your date of birth and enter your ID Number"); }
        public static string numpieceidentiteinfobulle { get => translate(); }
        public static string objectifpret { get => translate(); }
        public static string yes { get => translate("Yes"); }
        public static string paiement { get => translate(); }
        public static string paiementcommission { get => translate(); }
        public static string paiementgain { get => translate(); }
        public static string paiementgainavance { get => translate(); }
        public static string paiementprime { get => translate(); }
        public static string parametregeneraux { get => translate(); }
        public static string settings { get => translate("Settings"); }
        public static string membercard { get => translate("Membership Card"); }
        public static string membername { get => translate("Member Name"); }
        public static string membernumber { get => translate("Member Number"); }
        public static string memberactive { get => translate("Member Active?"); }
        public static string partenaire { get => translate(); }
        public static string participation { get => translate(); }
        public static string password { get => translate("Password"); }
        public static string rememberme { get => translate("Remember me"); }
        public static string usefingerprintnexttime { get => translate("Use fingerprint next time"); }
        public static string retypepassword { get => translate("Retype password"); }
        public static string passwordisnotthesame { get => translate("Password is not the same"); }
        public static string passwordinfobulle { get => translate(); }
        public static string passwordreset { get => translate("Password reset"); }
        public static string passwordinitialisation { get => translate(); }
        public static string passwordmodifie { get => translate(); }
        public static string passwordnouveau { get => translate(); }
        public static string pleaseenteryourpassword { get => translate("Please enter your password"); }
        public static string pleaseenteryoursmscode { get => translate("Password enter your SMS code"); }
        public static string forgot { get => translate("Forgot ?"); }
        public static string passwordoublie { get => translate(); }
        public static string paymentreport { get => translate(); }
        public static string periodicity { get => translate("Periodicity"); }
        public static string personneacharge { get => translate(); }
        public static string pieceidentite { get => translate(); }
        public static string plustardle { get => translate(); }
        public static string point { get => translate(); }
        public static string policynumber { get => translate(); }
        public static string possedecomptebancaire { get => translate(); }
        public static string pourcentagecotreussie { get => translate(); }
        public static string precedent { get => translate(); }
        public static string name { get => translate("Name"); } //prenom
        public static string name2 { get => translate("Name"); } // nom (Pour communitauté
        public static string nameandsurname { get => translate("Name & Surname"); }
        public static string pleaseenteryourname { get => translate("Please enter your Name"); }
        public static string pleaseenteryourlastname { get => translate("Please enter your Last Name"); }
        public static string pret { get => translate(); }
        public static string pretavance { get => translate(); }
        public static string pretdu { get => translate(); }
        public static string pretdurembourseimpaye { get => translate(); }
        public static string pretfutur { get => translate(); }
        public static string pretretard { get => translate(); }
        public static string primeassurance { get => translate(); }
        public static string principal { get => translate(); }
        public static string privacynotice { get => translate(); }
        public static string profession { get => translate(); }
        public static string profile { get => translate("Profile"); }
        public static string proprietairehabitation { get => translate(); }
        public static string reporting { get => translate("Reporting"); }
        public static string rapportassurance { get => translate(); }
        public static string rapportcommunaute { get => translate(); }
        public static string rapportdifferentservice { get => translate(); }
        public static string rapportepargne { get => translate(); }
        public static string rapportmembre { get => translate(); }
        public static string recapitulatifcotisation { get => translate(); }
        public static string recapitulatifremboursement { get => translate(); }
        public static string rechercher { get => translate(); }
        public static string relationship { get => translate(); }
        public static string rembourse { get => translate(); }
        public static string remboursement { get => translate(); }
        public static string remboursementavance { get => translate(); }
        public static string remboursementavanceretard { get => translate(); }
        public static string remboursementimpaye { get => translate(); }
        public static string remboursementpret { get => translate(); }
        public static string remboursementretard { get => translate(); }
        public static string representant { get => translate(); }
        public static string reussie { get => translate(); }
        public static string revenu { get => translate(); }
        public static string revenuestable { get => translate(); }
        public static string revenumensuel { get => translate(); }
        public static string revenumensuelinfobulle { get => translate(); }
        public static string sales { get => translate(); }
        public static string savingshistory { get => translate(); }
        public static string savingssummary { get => translate(); }
        public static string savingstarget { get => translate(); }
        public static string score { get => translate(); }
        public static string scorecommunaute { get => translate(); }
        public static string scoredelacommunaute { get => translate(); }
        public static string scoreinitial { get => translate(); }
        public static string scoreinitialcommunaute { get => translate(); }
        public static string scoremaximum { get => translate(); }
        public static string scoreminimum { get => translate(); }
        public static string scoremoymembre { get => translate(); }
        public static string scorepersonnel { get => translate(); }
        public static string securite { get => translate(); }
        public static string semaine { get => translate(); }
        public static string decimalseparator { get => translate("Decimal Separator"); }
        public static string thousandsseparator { get => translate("Thousands Separator"); }
        public static string service { get => translate(); }
        public static string serviceparmembre { get => translate(); }
        public static string services { get => translate("Services"); }
        public static string otherservices { get => translate("Other Services"); }
        public static string services_advances { get => translate(); }
        public static string services_insurrance { get => translate(); }
        public static string savings { get => translate("Savings"); }
        public static string tontineservice { get => translate("Tontine Service"); }
        public static string tontinemanagement { get => translate("Tontine Management"); }
        public static string tontines { get => translate("Tontines"); }
        public static string services_summary { get => translate(); }
        public static string sessiontimeout { get => translate(); }
        public static string sitmatrimoniale { get => translate(); }
        public static string situationavance { get => translate(); }
        public static string situationcotisation { get => translate(); }
        public static string smscodetexte { get => translate("SMS Code"); }
        public static string SN { get => translate(); }
        public static string solde { get => translate(); }
        public static string sourcerevenu { get => translate(); }
        public static string sponsorreport { get => translate(); }
        public static string startdate { get => translate("Start Date"); }
        public static string state { get => translate(); }
        public static string statut { get => translate(); }
        public static string statutcommunaute { get => translate(); }
        public static string suggestedprovider { get => translate(); }
        public static string suivant { get => translate(); }
        public static string summarytransactions { get => translate(); }
        public static string suppressioncommunaute { get => translate(); }
        public static string suppressionimpossible { get => translate(); }
        public static string suppressiontransaction { get => translate(); }
        public static string supprimer { get => translate(); }
        public static string tableaudebord { get => translate(); }
        public static string taillefamille { get => translate(); }
        public static string taillefamilleinfobulle { get => translate(); }
        public static string taillefamilleminimum { get => translate(); }
        public static string taillegroupe { get => translate(); }
        public static string taux { get => translate(); }
        public static string tauxcommissiongestionnaireassurance { get => translate(); }
        public static string tauxcommissiongestionnaireepargne { get => translate(); }
        public static string tauxcommissiongestionnairepret { get => translate(); }
        public static string tauxcommissionpartenaire { get => translate(); }
        public static string tauxinteret { get => translate(); }
        public static string tauxpaiementcommission { get => translate(); }
        public static string telechargermodele { get => translate(); }
        public static string telechargertermecontrat { get => translate(); }
        public static string mobilenumber { get => translate("Mobile Number"); }
        public static string telephoneinfobulle { get => translate(); }
        public static string tendande { get => translate(); }
        public static string termecontrat { get => translate(); }
        public static string tirage { get => translate(); }
        public static string tirageprogress { get => translate(); }
        public static string tiragereject { get => translate(); }
        public static string tontine { get => translate(); }
        public static string tontineavance { get => translate(); }
        public static string tontinefinissant { get => translate(); }
        public static string tontineinfo { get => translate(); }
        public static string tontineretard { get => translate(); }
        public static string tontines_contributions { get => translate(); }
        public static string tontines_geolocalisation { get => translate(); }
        public static string tontines_repayments { get => translate(); }
        public static string tontines_summary { get => translate(); }
        public static string total { get => translate(); }
        public static string totaldepot { get => translate(); }
        public static string tous { get => translate(); }
        public static string touscommunaute { get => translate(); }
        public static string tousmembre { get => translate(); }
        public static string tousservice { get => translate(); }
        public static string transactionfees { get => translate(); }
        public static string typeidentificationinfobulle { get => translate(); }
        public static string typeperiodicite { get => translate(); }
        public static string typeperiodiciteinfobulle { get => translate(); }
        public static string typepieceidentite { get => translate(); }
        public static string US { get => translate(); }
        public static string usageavance { get => translate(); }
        public static string usagepret { get => translate(); }
        public static string utilisateur { get => translate(); }
        public static string valeur { get => translate(); }
        public static string valeurobligatoire { get => translate(); }
        public static string validation { get => translate(); }
        public static string validationpieceidentite { get => translate(); }
        public static string valider { get => translate(); }
        public static string verification { get => translate("Verification"); }
        public static string pleaseconfirmyourdetailsbelow { get => translate("Please confirm your details below"); }
        public static string visualiser { get => translate(); }
        public static string zipcode { get => translate(); }

        //CUSTOM
        public static string GetEdition(string p)
        {
            return edition + " " + p;
        }

        public static string GetConfirmationSuppression(string entityName)
        {
            return string.Format(confirmationsuppression, entityName);
        }

        //NEW
        public static string ok { get => "OK"; } //"Ok"
        public static string loading { get => translate("Loading ..."); } //"Chargement ..."
        public static string doyouwanttologoutoftheapplication { get => translate("Do you want to log out of the application ?"); } // "Voulez - vous vous déconnecter de l'application ?"
        public static string connectionhomepage { get => translate("Do you want to log out of the application ?"); } // "Voulez - vous vous déconnecter de l'application ?"
        public static string cnimessagetaillevalidation { get => translate(); } // "Veuillez saisir un CNI de 13 Chiffres"
        public static string listevide { get => translate(); } // "Liste vide"
        public static string veuillezsaisirdesdonnesvalide { get => translate(); } // "Veuillez saisir des données valide!"
        public static string confirmationsuppression { get => translate(); } // "Confirmez-vous la suppresion de {0} ?"

        public static string urlmanuelutilisateur { get => translate(); }

        //For New Version

        //Authentification Home page
        public static string manageyourcommunity { get => translate("Manage your Community!"); }
        public static string manageyourtontine { get => translate("Manage your tontine or do communal savings"); }
        public static string getpricing { get => translate("Get Pricing"); }
        public static string getstarted { get => translate("Get Started"); }
        public static string signin { get => translate("Sign In"); }

        //Commons
        public static string next { get => translate("Next"); }
        public static string back { get => translate("Back"); }
        public static string skip { get => translate("Skip?"); }

        public static string newversion { get => translate("New Version"); }
        public static string updatemessage { get => translate("There is a new version of this app available. Would you like to update now?"); }


        public static string IsInternetOff { get => translate("Internet Connection"); }
        public static string IsInternetOffmessage { get => translate("Please check the internet connection."); }

        public static string manage { get => translate("Manage"); }
        public static string managefr { get => translate("Gérer votre tontine en version"); }
        public static string groupsdigitallyfr { get => translate("digitale!"); }
        public static string groupsdigitally { get => translate("your savings groups digitally!"); }
        public static string groupsdigitallyGM { get => translate("your Osusu digitally!"); }
        public static string patnermoth { get => translate("Thanks to our partners you can benefit from:"); }
        public static string securedcontributions { get => translate("Secured contributions"); }
        public static string earncommissionsmanaging { get => translate("Savings products"); }
        public static string monthlycashprizes { get => translate("Monthly cash prizes of up D100,000"); }
        public static string affordableloans { get => translate("Mobile money bonus"); }
        public static string watchthisfirst { get => translate("Watch this first!  "); }
        public static string learncreatecommunity { get => translate("To learn how to create your community."); }
        public static string moneybonus { get => translate("To learn how to create your community."); }
        public static string andmoremuch { get => translate("And much more!"); }


        //Inscription
        public static string createyouraccount { get => translate("Create your Account"); }
        public static string pleaseselectyourlanguage { get => translate("Please select your language"); }
        public static string country { get => translate("Country"); }
        public static string pleaseselectyourcountry { get => translate("Please select your country"); }
        public static string regionandcountry { get => translate("Region & Country"); }
        public static string region { get => translate("Region"); }
        public static string pleaseselectyourregion { get => translate("Please select your region"); }
        public static string pleaseenteryourmobilenumber { get => translate("Please enter your Mobile Number"); }
        public static string incorrectphonenumber { get => translate("Incorrect phone number"); }
        public static string logindetails { get => translate("Login details"); }
        public static string pleaseenteryourlogindetails { get => translate("Please enter your login details"); }
        public static string pleaseenteryoursmscodeandnewpassword { get => translate("Please enter your SMS code and your new Password"); }

        public static string sixdigitcode { get => translate("6-digit Code"); }
        public static string pleaseselecttheTermsandconditions { get => translate("Please select the Terms & Conditions"); }
        public static string pleasesubmitthesixdigitconfirmationcodesentto { get => translate("Please submit the 6-digit confirmation code sent to"); }
        public static string cgulfirsttext { get => translate("I agree to MaTontine's "); }
        public static string cgulinktext { get => translate("Terms of Use "); }
        public static string cgulfirsttextprivacy { get => translate("as well as the "); }
        public static string cgulfirsttextprivacypolicy { get => translate("Privacy Policy "); }
        public static string cgulfirsttextprivacyMa { get => translate("of MaTontine."); }
        public static string cgulasttext { get => translate(" including monthly billing agreement."); }
        public static string cgulinkmobileapp { get => translate("https://matontine.online/term-of-use.pdf"); }

        public static string partner { get => translate("Partner"); }
        public static string selectapartner { get => translate("Select a partner"); }


        public static string personaldetails { get => translate("Personal Details"); }
        public static string enteryournameanddateofbirth { get => translate("Enter your name and date of birth"); }

        public static string pleaseenteryourcorrectbirthday { get => translate("Please enter your correct birthday"); }
        public static string thedateofbirthcannotbeaftertoday { get => translate("The date of birth cannot be after today"); }

        public static string confirm { get => translate("Confirm"); }

        public static string pleaseentersixdigitcode { get => translate("Please enter your 6-digit code"); }
        public static string sixdigitcodeinvalid { get => translate("The 6-digit code you entered is not valid"); }


        public static string createyourcommunity { get => translate("Create your Community"); }
        public static string communityname { get => translate("Community Name"); }
        public static string communitynamerequired { get => translate("Please enter your community name"); }

        public static string msginfosforcreateyourcommunity { get => translate("By clicking on the next button you confirm that all the participants of your group are over the age of 18"); }


        public static string contribution { get => translate("Contribution"); }
        public static string contributionamount { get => translate("Contribution Amount"); }
        public static string enteryourregularcontribution { get => translate("Enter your regular contribution"); }

        public static string periodicitytype { get => translate("Periodicity Type"); }
        public static string monthly { get => translate("Monthly"); }
        public static string weekly { get => translate("Weekly"); }
        public static string enterthefrequencyofyourcontribution { get => translate("Enter the frequency of your contribution. You cannot change this once you start"); }


        public static string enterhowoftenperperiodtocontribute { get => translate("Enter how often per period to contribute (e.g. every 2 months). You cannot change this once you start"); }

        public static string numberofwinners { get => translate("Number of Winners"); }
        public static string enterthenumberofwinnersperdraw { get => translate("Enter the number of winners per draw"); }


        public static string drawday { get => translate("Draw Day"); }
        public static string enterdayofthedraw { get => translate("Enter the day of the draw. It should be one week/month before your first draw"); }


        public static string drawposition { get => translate("Draw Position"); }

        public static string success { get => translate("Success"); }
        public static string congratulationCommunityCreation { get => translate("Congratulations, you have successfully created your community"); }


        public static string communitymanagement { get => translate("Community Management"); }
        public static string logintoyouraccount { get => translate("Log into your account"); }
        public static string donthaveanyaccount { get => translate("Don't have any account?"); }
        public static string createone { get => translate("Create One !"); }



        public static string updatemember { get => translate("Update Member"); }
        public static string addmembers { get => translate("Add Members"); }
        public static string membership { get => translate("Membership"); }
        public static string selectcontactlist { get => translate("Select from Contact List"); }

        public static string paymentprovider { get => translate("Payment Provider"); }
        public static string selectpaymentprovider { get => translate("Select the payment provider"); }

        public static string addmoremembers { get => translate("Add More Members"); }
        public static string addthemlater { get => translate("Add Them Later"); }

        public static string welcomeback { get => translate("Welcome Back"); }
        public static string logout { get => translate("Logout"); }

        public static string keyinfo { get => translate("Key Info"); }
        public static string supplementary { get => translate("Supplementary"); }

        public static string dyouconfirmthedeletionfor { get => translate("Do you confirm the deletion for"); }

        public static string history { get => translate("History"); }
        public static string currency { get => translate("Currency"); }



        public static string contact_adresse { get => translate("Avenue Cheik Anta Diop Immeuble BarSalam 4eme Etage, Porte C"); }
        public static string contact_telephone { get => translate("+221 33 849 14 30"); }

        public static string whatsappnumber { get => translate("WhatsApp Number"); }
        public static string contact_email { get => translate("info@matontine.com"); }

        public static string pleaseselectatontinetoreporton { get => translate("Please select a tontine to report on"); }
        public static string done { get => translate("Done"); }

        public static string monthlypricepermember { get => translate("Monthly price per member"); }
        public static string getpricingvariable { get => translate("Get Pricing variable"); }

        public static string pleaseselect { get => translate("Please Select"); }
        public static string miseajour { get => translate("Update"); }


        public static string month { get => translate("Month"); }
        public static string perweek { get => translate("Week"); }

        public static string nationalid { get => translate("National ID"); }
        public static string others { get => translate("Others"); }

        public static string positionnothing { get => translate("Nothing"); }


        public static string whatsappitemdescription { get => translate("Recommend MaTontine"); } //Recommend MaTontine to another manager via WhatsApp

        public static string whatsappmessage
        {
            get => translate("Hi #CONTACT_NAME#, "
                        + "%0a%0a"
                        + "I wanted to share MaTontine with you.  I use the application to manage my tontine group and I find it very useful.  I think you would it find it very helpful as well. "
                        + "%0a%0a"
                        + "You can click on the link below to download their app."
                        + "%0a"
                        + "Android: https://play.google.com/store "
                        );
        }

        public static string datefin { get => translate("End date"); }
        public static string maxperiodicite { get => translate("Number of months"); }
        public static string logoutforlanguage { get => translate("Do you want to log out of the application for reload a traduction ?"); }
        public static string invalidedate { get => translate("The date is invalid"); }

        public static void LogAll(bool propDifToVal = false, string sep = "\t")
        {
            Translate t = new Translate();
            foreach (var p in t.GetType().GetProperties())
            {
                var n = p.Name;
                var v = p.GetValue(t).ToString();

                if (propDifToVal)
                {
                    if (n == v) continue;
                }

                System.Console.WriteLine(n + sep + v);
            }
        }

        public static string deleteprofilemsg { get => translate("Deleting your community will delete all your information completely!"); }

        public static string deleteprofilebtn { get => translate("Delete Community"); }
        public static string delete { get => translate("Delete"); }
        public static string cancel { get => translate("Cancel"); }
        public static string update { get => translate("Update"); }
        public static string pleaseselectmembers { get => translate("Please select members."); }
        public static string paymentsuccess { get => translate("Payments are successfully processed."); }
    }
}
