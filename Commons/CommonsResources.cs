using MatontineDigitalApp.Model;
using MatontineDigitalApp.Services;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatontineDigitalApp.Commons
{
  class CommonsResources
  {
    public static ListDataDto listData { get; set; } = new ListDataDto();
    public static UserProfile ConnectedUser { get; set; } = new UserProfile();
    public static Credentials credentials { get; set; } = new Credentials();

    public static List<CountryDto> Countries { get => listData.lstpays; }

    private static string _RegionsCountryCode;
    public static string RegionsCountryCode
    {
      get => _RegionsCountryCode;
      set
      {
        if (value != _RegionsCountryCode)
        {
          Regions.Clear();
        }

        _RegionsCountryCode = value;
      }
    }

    public static bool IsWoman(string gender)
    {
      return gender == "FEMME";
    }

    public static List<SimpleListItemData> Regions { get; set; } = new List<SimpleListItemData>();

    public static List<SimpleListItemData> Parteners { get => listData.lstpartenaire; }

    public static List<SimpleListItemData> PaymentMethods { get => listData.lstmodepaiement; }

    public static List<SimpleListItemData> Periodicities { get => listData.lstperiodicite; }
    public static List<SimpleListItemData> NumberOfWinnersList { get => listData.lstnombregagnantpartirage; }

    internal static string DisplayAmount(object montant, CountryDto countryDto = null)
    {
      if (montant == null) return "";
      if (countryDto == null)
      {
        countryDto = ConnectedUser.GetCountryDto();
      };

      var s = montant.FROMOBJECTVALUETOSTRING();

      try
      {
        return long.Parse(s?.Replace(" ", "").Replace(".", "")).ToString(countryDto?.CurrencyFormat);
      }
      catch
      {
        return "0";
      }


    }

    public static List<SimpleListItemData> DrawDateList { get => listData.lstjourstirage; }

    public static string AppName = "MaTontine";
    public static Color primaryColor = Color.FromHex("#27ae60");
    public static Color secondaryColor = Color.FromHex("#229b55");
    public static Color accentColor = Color.FromHex("#cddc39");

    public static StackLayout GetToolBar(Page page)
    {
      var logo = new Image
      {
        Source = "matontine_logo.png",
        Aspect = Aspect.AspectFit,
        HeightRequest = 30,
        VerticalOptions = LayoutOptions.Center
      };
      var tapGesture = new TapGestureRecognizer();
      tapGesture.Tapped += (s, e) => {
        //page.Navigation.PushModalAsync(new HomePageOld());
      };

      logo.GestureRecognizers.Add(tapGesture);

      return new StackLayout
      {
        BackgroundColor = CommonsResources.primaryColor,
        HorizontalOptions = LayoutOptions.FillAndExpand,
        VerticalOptions = LayoutOptions.Start,
        Padding = new Thickness(0, 10, 0, 8),
        HeightRequest = 40,
        Children =
                {
                    new StackLayout
                    {
                        VerticalOptions = LayoutOptions.CenterAndExpand,
                        HorizontalOptions = LayoutOptions.Center,
                        Children = { logo }
                    }
                }
      };
    }

    public static StackLayout GetTitleHeader(string title, Color color)
    {
      return new StackLayout
      {
        Padding = new Thickness(5),
        BackgroundColor = color,
        HorizontalOptions = LayoutOptions.FillAndExpand,
        VerticalOptions = LayoutOptions.Center,
        Children =
                {
                    new Label {
                        Text = title,
                        TextColor = Color.FromHex("#FFF"),
                        HorizontalOptions = LayoutOptions.CenterAndExpand,
                        FontAttributes = FontAttributes.Bold,
                    }
}
      };
    }

    public static string getSystemLanguage()
    {
      return CultureInfo.CurrentUICulture.TwoLetterISOLanguageName.ToUpper();
    }

    public static CountryDto GetSelected()
    {
      return CommonsResources.listData.lstpays.ToList().Where(x => x.Code == ConnectedUser.profile_country).FirstOrDefault();
    }

    public static bool isSystemLangage(string langue)
    {
      if (langue == null) return false;

      return getSystemLanguage().Equals(langue.Trim().ToUpper());
    }

    public static string ToTitleCase(string value)
    {
      CultureInfo cultureInfo = Thread.CurrentThread.CurrentCulture;
      TextInfo textInfo = cultureInfo.TextInfo;
      return textInfo.ToTitleCase(((string)value));
    }

    /*public static List<SimpleListItemData> YesNoData { get; set; } = new List<SimpleListItemData>
    {
        new SimpleListItemData{Code = "true", Designation = "Oui"},
        new SimpleListItemData{Code = "false", Designation = "Non"},
    };

    public static List<SimpleListItemData> YesData { get; set; } = new List<SimpleListItemData>
    {
        new SimpleListItemData{Code = "true", Designation = "Oui"}
    };*/



    public static List<SimpleListItemData> YesNoData { get => listData.lstyesno; }
    public static List<SimpleListItemData> YesData { get => listData.lstyes; }


    public static List<SimpleListItemData> TypePieceData { get { return listData.lsttypepieceidentification; } }

    public static List<SimpleListItemData> CategorieData { get { return listData.lstcategorie; } }

    public static List<SimpleListItemData> ModePaiementData { get { return listData.lstmodepaiement; } }

    public static List<SimpleListItemData> GenreData { get { return listData.lstgenre; } }

    public static List<SimpleListItemData> PaysData { get { return listData.lstpays_old; } }

    public static List<SimpleListItemData> SiuationMatrimonialeData { get { return listData.lstsituationmatrimoniale; } }

    public static List<SimpleListItemData> HabitatData { get { return listData.lsthabitat; } }

    public static List<SimpleListItemData> NiveauEtudeData { get { return listData.lstniveauetude; } }

    public static List<SimpleListItemData> SourceRevenusData { get { return listData.lstsourcerevenue; } }

    public static List<SimpleListItemData> ProfessionData { get { return listData.lstprofession; } }

    public static List<SimpleListItemData> UsagePretData { get { return listData.lstusagepret; } }



    public static List<SimpleListItemData> LiensParenteData { get { return listData.lstlienparente; } }
    public static List<SimpleListItemData> TypePeriodiciteData { get { return listData.lsttypeperiodicite; } }
    public static List<SimpleListItemData> PeriodiciteData { get { return listData.lstperiodicite; } }
    public static List<SimpleListItemData> NombreGagnantParTirageData { get { return listData.lstnombregagnantpartirage; } }
    public static List<SimpleListItemData> JoursTirageData { get { return listData.lstjourstirage; } }


    public static List<SimpleListItemData> MonnaieData { get => listData.lstmonnaie; }
    public static List<SimpleListItemData> LangueData { get => listData.lstlangue; }
    public static List<SimpleListItemData> FormatDeDateData { get => listData.lstdateformat; }
    public static List<SimpleListItemData> SeparateurDeMillierData { get => listData.lstsepmillier; }
    //public static List<SimpleListItemData> SeparateurDeDecimalData { get => listData.lstsepdecimal; }
    public static List<SimpleListItemData> SeparateurDeDecimalData
    {
      get => new List<SimpleListItemData> {
             new SimpleListItemData{Code = ",", Description = ","},
            new SimpleListItemData{Code = ".", Description = "."},
        };
    }

    public static List<SimpleListItemData> PartenaireData { get => listData.lstpartenaire; }

    public static List<SimpleListItemData> FilterCommunauteData { get => ConnectedUser.lstcommunaute; }
    public static List<SimpleListItemData> FilterMembreData { get => ConnectedUser.lstmembre; }
    public static List<SimpleListItemData> FilterServiceData { get => ConnectedUser.lstservice; }


    public static List<ServiceDto> GetServices(ServiceDto.CategoryServiceEnum cat)
    {
        if (ConnectedUser.ListServices is null)
        {
            return new List<ServiceDto>();
        }

        if (cat == ServiceDto.CategoryServiceEnum.ALL)
        {
            return ConnectedUser.ListServices;
        }

        bool isForTontine = cat == ServiceDto.CategoryServiceEnum.TONTINE;

        return ConnectedUser.ListServices.FindAll(e => e.IsTontine == isForTontine);
    }

    public static List<ReportItemDto> GetReportItems(MemberDto member, ServiceDto service)
    {
      if (member.ListReportItems is null)
      {
        return new List<ReportItemDto>();
      }
      return member.ListReportItems.FindAll(e => e.ServiceCode == service.ServiceCode);
    }

    public static List<MemberContributionHistoryDto> GetContributionHistory(MemberDto member, ServiceDto service)
    {
      if (member.ListContributionHistory is null)
      {
        return new List<MemberContributionHistoryDto>();
      }
      return member.ListContributionHistory.FindAll(e => e.ServiceCode == service.ServiceCode);
    }


    public static List<MemberDto> GetMembers(ServiceDto dto = null, bool memberInService = true)
    {


      if (ConnectedUser.ListMembers is null)
      {
        return new List<MemberDto>();
      }

      if (dto is null)
      {
        return ConnectedUser.ListMembers;
      }

      if (memberInService)
      {
        return ConnectedUser.ListMembers.FindAll(e => e.ListServiceCodes.Contains(dto.ServiceCode));
      }
      else
      {
        return ConnectedUser.ListMembers.FindAll(e => !e.ListServiceCodes.Contains(dto.ServiceCode));
      }


    }



    private static List<SimpleListItemData> GetNumberSimpleList(int indexTo, int indexFrom)
    {
      var res = new List<SimpleListItemData>();
      for (var i = indexTo; i <= indexFrom; i++)
      {
        res.Add(new SimpleListItemData
        {
          Code = i.FROMOBJECTVALUETOSTRING(),
          Description = i.FROMOBJECTVALUETOSTRING()
        });
      }

      return res;
    }


    public static void PutTestData()
    {

      if (true) return;
   
      //Regions
      Regions = GetTestRegions();
      RegionsCountryCode = "SN";


      listData.lstperiodicite = GetNumberSimpleList(1, 31);
      listData.lstnombregagnantpartirage = GetNumberSimpleList(1, 10);
      listData.lstjourstirage = GetNumberSimpleList(1, 30);

      // Countries
      listData.lstpays = new List<CountryDto>
            {
                new CountryDto {
                    Code = "SN",
                    Description = "Senegal",
                    Pricing = "200",
                    CurrencyCode = "XOF",
                    CurrencyDescription = "FCFA",
                    Indicatif = "+221",
                    FlagBase64 = "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"
                },
                new CountryDto {
                    Code = "GB",
                    Description = "Gambia",
                    Pricing = "10",
                    CurrencyCode = "GMD",
                    CurrencyDescription = "GMD",
                    Indicatif = "+222",
                    FlagBase64 = "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"
                },
            };


      //Partners
      listData.lstpartenaire = new List<SimpleListItemData>
        {
            new SimpleListItemData
            {
                Code = "1",
                Description = "MaTontine",
                ImageBase64 = "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"
            }
        };

      //PaymentMethod
      listData.lstmodepaiement = new List<SimpleListItemData>
        {
            new SimpleListItemData{
                Code = "WAVE",
                Description = "Wave",
                ImageBase64 = "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"
            },
            new SimpleListItemData{
                Code = "WIZALL",
                Description = "Wizall",
                ImageBase64 = "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"
            },
        };



      //CONNECTED USER
      ConnectedUser = new UserProfile
      {
        profile_name = "Fanta",
        profile_surname = "DIOP",
        profile_community = "Yakhar",
        profile_gender = "F",
        ProfileRegionDescription = "Guediawye",
        ProfileCountryDescription = "Senegal",
        ProfileContryIndicatif = "+221",
        profile_phonenumber = "774569812",
        ProfileCurrencyDescription = "FCFA",
        LangueDescription = "English",
        FormatDate = "DD/MM/YYYY",
        SeparateurMillier = "Space",
        SeparateurDeDecimal = ",",
        ListServices = new List<ServiceDto>
            {
                new ServiceDto
                {
                    ServiceId = "Fatick",
                    Nom = "Fatick",
                    Montant = "50000",
                    DateDemarage = DateTime.Now,
                    MemberCount = 9,
                    TypePeriodiciteDescription = "Monthly",
                    Periodicite = "1",
                    NombreDeGagnant = "1",
                    JourDuTirage = "10",
                    TypeService = "AUTRE",
                    TypeServiceDescription = "Service",
                    TypeServiceAmountDescription = "Amount",
                },
                new ServiceDto
                {
                    ServiceId = "Yakhar01",
                    Nom = "Yakhar01",
                    Montant = "10000",
                    DateDemarage = DateTime.Now,
                    MemberCount = 14,
                    TypePeriodiciteDescription = "Monthly",
                    Periodicite = "1",
                    NombreDeGagnant = "1",
                    JourDuTirage = "10",
                    TypeService = "TONTINE",
                    TypeServiceDescription = "Tontine",
                    TypeServiceAmountDescription = "Contribution",
                },
                new ServiceDto
                {
                    ServiceId = "Yakhar02",
                    Nom = "Yakhar02",
                    Montant = "8000",
                    DateDemarage = DateTime.Now,
                    MemberCount = 22,
                    TypePeriodiciteDescription = "Monthly",
                    Periodicite = "1",
                    NombreDeGagnant = "1",
                    JourDuTirage = "10",
                    TypeService = "TONTINE",
                    TypeServiceDescription = "Tontine",
                    TypeServiceAmountDescription = "Contribution",
                },
            },//END SERVICE
        ListMembers = new List<MemberDto> {
                new MemberDto {
                    Nom = "Akporiaye",
                    Prenom = "Bernie",
                    TelephoneIndicatif = "+221",
                    Telephone = "777894556",
                    Gender = "M",
                    ListContributionHistory = new List<MemberContributionHistoryDto>
                    {
                        new MemberContributionHistoryDto
                        {
                            PeriodeDescription = "Jan-2020",
                            StatusCode = "EARLY",
                            StatusDecription = "Early",
                            ServiceCode = "Yakhar01"
                        },
                        new MemberContributionHistoryDto
                        {
                            PeriodeDescription = "Fev-2020",
                            StatusCode = "ON-TIME",
                            StatusDecription = "On-time",
                            ServiceCode = "Yakhar01"
                        },
                        new MemberContributionHistoryDto
                        {
                            PeriodeDescription = "Mar-2020",
                            StatusCode = "LATE",
                            StatusDecription = "Late",
                            ServiceCode = "Yakhar01"
                        },
                        new MemberContributionHistoryDto
                        {
                            PeriodeDescription = "Apr-2020",
                            StatusCode = "EARLY",
                            StatusDecription = "Early",
                            ServiceCode = "Yakhar01"
                        },
                    },
                    ListServiceCodes = new List<string> {
                        "Fatick",
                        "Yakhar01",
                        "Yakhar02",
                    },
                    ListReportItems = new List<ReportItemDto>
                    {
                        new ReportItemDto
                        {
                            Code = "Contributed",
                            Nom = "Contributed",
                            Description = "500 000 F",
                            ServiceCode = "Yakhar01"
                        },
                        new ReportItemDto
                        {
                            Code = "Contribution",
                            Nom = "Contribution",
                            Description = "250 000 F",
                            ServiceCode = "Yakhar01"
                        },
                        new ReportItemDto
                        {
                            Code = "Won",
                            Nom = "Won",
                            Description = "Yes",
                            ServiceCode = "Yakhar01"
                        },
                        new ReportItemDto
                        {
                            Code = "DateWon",
                            Nom = "Date Won",
                            Description = "01/01/2020",
                            ServiceCode = "Yakhar01"
                        },
                        new ReportItemDto
                        {
                            Code = "StartDate",
                            Nom = "Start Date",
                            Description = "01/01/2020",
                            ServiceCode = "Fatick"
                        },
                        new ReportItemDto
                        {
                            Code = "Target",
                            Nom = "Target",
                            Description = "250 000 F",
                            ServiceCode = "Fatick"
                        },
                        new ReportItemDto
                        {
                            Code = "NofSavers",
                            Nom = "# of Savers",
                            Description = "10",
                            ServiceCode = "Fatick"
                        },
                        new ReportItemDto
                        {
                            Code = "TotalSaved",
                            Nom = "Total Saved",
                            Description = "100 000 F",
                            ServiceCode = "Fatick"
                        },
                    }
                },
                new MemberDto
                {
                    Nom = "Toure",
                    Prenom = "Aminata",
                    TelephoneIndicatif = "+221",
                    Telephone = "784561256",
                    Gender = "F",
                    ListContributionHistory = new List<MemberContributionHistoryDto>
                    {
                        new MemberContributionHistoryDto
                        {
                            PeriodeDescription = "Jan-2020",
                            StatusCode = "LATE",
                            StatusDecription = "Late"
                        },
                        new MemberContributionHistoryDto
                        {
                            PeriodeDescription = "Fev-2020",
                            StatusCode = "LATE",
                            StatusDecription = "Late"
                        },
                        new MemberContributionHistoryDto
                        {
                            PeriodeDescription = "Mar-2020",
                            StatusCode = "LATE",
                            StatusDecription = "Late"
                        },
                        new MemberContributionHistoryDto
                        {
                            PeriodeDescription = "Apr-2020",
                            StatusCode = "EARLY",
                            StatusDecription = "Early"
                        },
                    },
                    ListServiceCodes = new List<string> {
                        "Fatick",
                        "Yakhar01",
                        "Yakhar02",
                    }
                },
                new MemberDto
                {
                    Nom = "Diop",
                    Prenom = "Mohamed",
                    TelephoneIndicatif = "+221",
                    Telephone = "334567845",
                    Gender = "M",
                    ListContributionHistory = new List<MemberContributionHistoryDto>
                    {
                        new MemberContributionHistoryDto
                        {
                            PeriodeDescription = "Jan-2020",
                            StatusCode = "EARLY",
                            StatusDecription = "Early"
                        },
                        new MemberContributionHistoryDto
                        {
                            PeriodeDescription = "Fev-2020",
                            StatusCode = "ON-TIME",
                            StatusDecription = "On-time"
                        },
                        new MemberContributionHistoryDto
                        {
                            PeriodeDescription = "Mar-2020",
                            StatusCode = "LATE",
                            StatusDecription = "Late"
                        },
                        new MemberContributionHistoryDto
                        {
                            PeriodeDescription = "Apr-2020",
                            StatusCode = "EARLY",
                            StatusDecription = "Early"
                        },
                    },
                    ListServiceCodes = new List<string> {
                        "Yakhar01",
                        "Yakhar02",
                    }
                },

                new MemberDto {
                    Nom = "Akporiaye",
                    Prenom = "Bernie",
                    TelephoneIndicatif = "+221",
                    Telephone = "777894556",
                    Gender = "M",
                    ListContributionHistory = new List<MemberContributionHistoryDto>
                    {
                        new MemberContributionHistoryDto
                        {
                            PeriodeDescription = "Jan-2020",
                            StatusCode = "EARLY",
                            StatusDecription = "Early"
                        },
                        new MemberContributionHistoryDto
                        {
                            PeriodeDescription = "Fev-2020",
                            StatusCode = "ON-TIME",
                            StatusDecription = "On-time"
                        },
                        new MemberContributionHistoryDto
                        {
                            PeriodeDescription = "Mar-2020",
                            StatusCode = "LATE",
                            StatusDecription = "Late"
                        },
                        new MemberContributionHistoryDto
                        {
                            PeriodeDescription = "Apr-2020",
                            StatusCode = "EARLY",
                            StatusDecription = "Early"
                        },
                    },
                    ListServiceCodes = new List<string> {
                        "Yakhar02",
                    }
                },
                new MemberDto
                {
                    Nom = "Toure",
                    Prenom = "Aminata",
                    TelephoneIndicatif = "+221",
                    Telephone = "784561256",
                    Gender = "F",
                    ListContributionHistory = new List<MemberContributionHistoryDto>
                    {
                        new MemberContributionHistoryDto
                        {
                            PeriodeDescription = "Jan-2020",
                            StatusCode = "EARLY",
                            StatusDecription = "Early"
                        },
                        new MemberContributionHistoryDto
                        {
                            PeriodeDescription = "Fev-2020",
                            StatusCode = "ON-TIME",
                            StatusDecription = "On-time"
                        },
                        new MemberContributionHistoryDto
                        {
                            PeriodeDescription = "Mar-2020",
                            StatusCode = "LATE",
                            StatusDecription = "Late"
                        },
                        new MemberContributionHistoryDto
                        {
                            PeriodeDescription = "Apr-2020",
                            StatusCode = "EARLY",
                            StatusDecription = "Early"
                        },
                    },
                    ListServiceCodes = new List<string> {
                        "Fatick",
                    }
                },

            },//END MEBERS

      };
    }


    /// <summary>
    /// Regions
    /// </summary>
    /// <returns></returns>
    private static List<SimpleListItemData> GetTestRegions()
    {
      Func<string, SimpleListItemData> conv = (v) =>
      {
        return new SimpleListItemData
        {
          Code = v,
          Description = v
        };
      };

      return new List<SimpleListItemData>
            {
                conv("Bakel"),
                conv("Bambey"),
                conv("Bignona"),
                conv("Birkilane"),
                conv("Bounkiling"),
                conv("Dagana"),
                conv("Dakar"),
                conv("Diourbel"),
                conv("Fatick"),
                conv("Foundiougne"),
                conv("Gossas"),
                conv("Goudiry"),
                conv("Goudomp"),
                conv("Guédiawaye"),
                conv("Guinguinéo"),
                conv("Kaffrine"),
                conv("Kanel"),
                conv("Kaolack"),
                conv("Kébémer"),
                conv("Kédougou"),
                conv("Kolda"),
                conv("Koumpentoum"),
                conv("Koungheul"),
                conv("Linguère"),
                conv("Louga"),
                conv("Malem Hoddar"),
                conv("Matam"),
                conv("Mbacké"),
                conv("M'bour"),
                conv("Médina Yoro Foulah"),
                conv("Nioro du Rip"),
                conv("Oussouye"),
                conv("Pikine"),
                conv("Podor"),
                conv("Ranérou Ferlo"),
                conv("Rufisque"),
                conv("Saint-Louis"),
                conv("Salémata"),
                conv("Saraya"),
                conv("Sédhiou"),
                conv("Tambacounda"),
                conv("Thiès"),
                conv("Tivaouane"),
                conv("Vélingara"),
                conv("Ziguinchor")
            };

    }
  }
}
